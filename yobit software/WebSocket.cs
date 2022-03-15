using System;
using System.Drawing;
using System.Linq;
using WebSocketSharp;

namespace yobit_software
{
    public partial class Form1
    {
        private void WebSocket_start()
        {
            string[] message_array;
            var ws = new WebSocket("wss://pro-pusher.com/");
            ws.Origin = "https://yobit.net";
            ws.OnMessage += (sender, Message) =>
            {
                // message : [36,8459502800938507,2670751664575343,{},["[300,1,\"PAK\",\"BTC\",\"0.00000015\",\"200\",\"0.00000029\",\"0.00000005\",\"65917167.78826904\",\"11.96083069\",\"11.96083069\"]"]]
                // 36,8464396815689224,8370293604295211,,8059,2,BCHABC,BTC,0.02872705,0.1,0.02960000,0.02870300,9736.32298686,284.18896423,284.18896423
                //[0]36
                //[1]8464396815689224
                //[2]8370293604295211
                //[3]
                //[4]8059
                //[5]2 1-buy 2-sell
                //[6]BCHABC
                //[7]BTC
                //[8]0.02872705 price
                //[9]0.1
                //[10]0.02960000
                //[11]0.02870300
                //[12]9736.32298686
                //[13]284.18896423
                //[14]284.18896423
                string message = Message.Data.Replace(" ", "").Replace("message:[", "").Replace("{", "").Replace("}", "").Replace("[", "").Replace("]", "").Replace("\"", "").Replace("\\", "");
                Console.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " message2 : " + Message.Data);
                if ((Message.Data.ToString().IndexOf("36,") != -1) && (Message.Data.ToString().IndexOf("ETH") == -1) && (Message.Data.ToString().IndexOf("DOGE") == -1) && (Message.Data.ToString().IndexOf("YO") == -1) && (Message.Data.ToString().IndexOf("WAVES") == -1) && (Message.Data.ToString().IndexOf("USD") == -1) && (Message.Data.ToString().IndexOf("RUR") == -1))
                {
                    message_array = message.Split(',').ToArray();
                    if (message_array.Length == 15)
                    {
                        int est = 0;
                        for (int n = 0; n <= instrumenty_kol_yobit; n++)
                        {
                            if (instrumenty_yobit_array[n, 0] == message_array[6] + "/" + message_array[7]) est = n;
                        }
                        if (est != 0)
                        {
                            dataGridView_yobit.Invoke(new Action(() => dataGridView_yobit.Rows[est - 1].Cells["proc"].Value = message_array[9]));
                            dataGridView_yobit.Invoke(new Action(() => dataGridView_yobit.Rows[est - 1].Cells["volBTC"].Value = message_array[14]));
                        }
                        else
                        {
                            {
                                ws.Send("[32,7403684586532254,{},\"trhist" + message_array[4] + "\"]");
                                instrumenty_kol_yobit++;
                                instrumenty_yobit_array[instrumenty_kol_yobit, 0] = message_array[6] + "/" + message_array[7];
                                instrumenty_yobit_array[instrumenty_kol_yobit, 1] = "1";
                                instrumenty_yobit_array[instrumenty_kol_yobit, 6] = rgb_yobit.Next(0, 255).ToString();
                                instrumenty_yobit_array[instrumenty_kol_yobit, 7] = rgb_yobit.Next(0, 255).ToString();
                                instrumenty_yobit_array[instrumenty_kol_yobit, 8] = rgb_yobit.Next(0, 255).ToString();
                                instrumenty_yobit_array[instrumenty_kol_yobit, 9] = "1";
                                dataGridView_yobit.Invoke(new Action(() => dataGridView_yobit.Rows.Add(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"), message_array[6] + "/" + message_array[7], "", "", message_array[9], message_array[14], "1")));
                                dataGridView_yobit.Invoke(new Action(() => dataGridView_yobit.Rows[instrumenty_kol_yobit - 1].DefaultCellStyle.BackColor = Color.Honeydew));
                                dataGridView_yobit.Rows[instrumenty_kol_yobit - 1].Cells["name"].Style.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(instrumenty_yobit_array[instrumenty_kol_yobit, 6]),
                                    Convert.ToInt32(instrumenty_yobit_array[instrumenty_kol_yobit, 7]), Convert.ToInt32(instrumenty_yobit_array[instrumenty_kol_yobit, 8]));
                                if (dataGridView_yobit.Rows[instrumenty_kol_yobit - 1].Cells["proc"].Value != null)
                                    if (dataGridView_yobit.Rows[instrumenty_kol_yobit - 1].Cells["proc"].Value.ToString() != "")
                                    {
                                        graph_yobit[instrumenty_kol_yobit, 1000] = dataGridView_yobit.Rows[instrumenty_kol_yobit - 1].Cells["proc"].Value.ToString();
                                    }
                            }
                        }
                    }
                    if (message_array.Length == 12)
                    {
                        int est = 0;
                        for (int n = 0; n <= instrumenty_kol_yobit; n++)
                        {
                            if (instrumenty_yobit_array[n, 0] == message_array[6] + "/" + message_array[7]) est = n;
                        }
                        if (est != 0)
                        {
                            instrumenty_yobit_array[est, 9] = (Convert.ToInt32(instrumenty_yobit_array[est, 9]) + 1).ToString();

                            instrumenty_yobit_array[est, Convert.ToInt32(instrumenty_yobit_array[est, 9]) * 5 + 10] = message_array[11];
                            instrumenty_yobit_array[est, Convert.ToInt32(instrumenty_yobit_array[est, 9]) * 5 + 11] = message_array[8];
                            instrumenty_yobit_array[est, Convert.ToInt32(instrumenty_yobit_array[est, 9]) * 5 + 12] = message_array[9];
                            instrumenty_yobit_array[est, Convert.ToInt32(instrumenty_yobit_array[est, 9]) * 5 + 14] = DateTime.Now.ToString();

                            if (dataGridView_yobit.Rows[est - 1].Cells["proc"].Value != null)
                                if (dataGridView_yobit.Rows[est - 1].Cells["proc"].Value.ToString() != "")
                                {
                                    graph_yobit[est, 1000] = dataGridView_yobit.Rows[est - 1].Cells["proc"].Value.ToString();

                                }
                            dataGridView_yobit.Invoke(new Action(() => dataGridView_yobit.Rows[est - 1].Cells["change"].Value = message_array[8]));
                            dataGridView_yobit.Invoke(new Action(() => dataGridView_yobit.Rows[est - 1].Cells["volume"].Value = message_array[9]));
                            dataGridView_yobit.Invoke(new Action(() => dataGridView_yobit.Rows[est - 1].Cells["kolvo"].Value = Convert.ToInt32(instrumenty_yobit_array[est, 9])));

                            message_array_color[est, 0] = message_array_color[est, 0] + 1;
                            message_array_color[est, 1] = Convert.ToInt32(message_array[5]);
                        }
                        else
                        {
                            instrumenty_kol_yobit++;
                            instrumenty_yobit_array[instrumenty_kol_yobit, 0] = message_array[6] + "/" + message_array[7];
                            instrumenty_yobit_array[instrumenty_kol_yobit, 1] = "1";
                            instrumenty_yobit_array[instrumenty_kol_yobit, 6] = rgb_yobit.Next(0, 255).ToString();
                            instrumenty_yobit_array[instrumenty_kol_yobit, 7] = rgb_yobit.Next(0, 255).ToString();
                            instrumenty_yobit_array[instrumenty_kol_yobit, 8] = rgb_yobit.Next(0, 255).ToString();
                            instrumenty_yobit_array[instrumenty_kol_yobit, 9] = "1";
                            instrumenty_yobit_array[instrumenty_kol_yobit, 15] = message_array[11];
                            instrumenty_yobit_array[instrumenty_kol_yobit, 16] = message_array[8];
                            instrumenty_yobit_array[instrumenty_kol_yobit, 17] = message_array[9];
                            instrumenty_yobit_array[instrumenty_kol_yobit, 19] = DateTime.Now.ToString();
 //                           dataGridView_yobit.Invoke(new Action(() => dataGridView_yobit.Rows.Add(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"),message_array[6] + "/" + message_array[7], message_array[8], message_array[9])));
                            dataGridView_yobit.Invoke(new Action(() => dataGridView_yobit.Rows[instrumenty_kol_yobit - 1].DefaultCellStyle.BackColor = Color.Honeydew));
                            dataGridView_yobit.Rows[instrumenty_kol_yobit - 1].Cells["name"].Style.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(instrumenty_yobit_array[instrumenty_kol_yobit, 6]),
                                Convert.ToInt32(instrumenty_yobit_array[instrumenty_kol_yobit, 7]), Convert.ToInt32(instrumenty_yobit_array[instrumenty_kol_yobit, 8]));
                            message_array_color[instrumenty_kol_yobit, 0] = 1;
                        }
                        try
                        {
                            graph = 1;
                            g = Graphics.FromImage(bmp_yobit);
                            g.Clear(Color.White);
                            g.DrawLine(new Pen(Color.FromArgb(230, 230, 230)), 0, pictureBox_yobit.Height / 2, pictureBox_yobit.Width, pictureBox_yobit.Height / 2);
                            for (int n = 1; n <= instrumenty_kol_yobit; n++)
                            {
                                if (instrumenty_yobit_array[n, 1] == "1")
                                {
                                    int pred = 0; float znach = 0;
                                    for (int k = 0; k <= 1000; k++)
                                    {
                                        if (graph_yobit[n, k] != null)
                                        {
                                            if (pred == 0)
                                            {
                                                pred = k; znach = Convert.ToSingle(graph_yobit[n, k].ToString().Replace(".", ","));
                                            }
                                            else
                                            {
                                                g.DrawLine(new Pen(Color.FromArgb(Convert.ToInt32(instrumenty_yobit_array[n, 6]), Convert.ToInt32(instrumenty_yobit_array[n, 7]), Convert.ToInt32(instrumenty_yobit_array[n, 8]))),
                                                    (pred + 2),
                                                    pictureBox_yobit.Height / 2 - znach * graph_massht_yobit,
                                                    (k + 2),
                                                    pictureBox_yobit.Height / 2 - Convert.ToSingle(graph_yobit[n, k].ToString().Replace(".", ",")) * graph_massht_yobit);
                                                pred = k; znach = Convert.ToSingle(graph_yobit[n, k].ToString().Replace(".", ","));
                                            }
                                            if (graph_yobit[n, k] != null)
                                                if (graph_yobit[n, k] != "")
                                                {
                                                    g.DrawLine(new Pen(Color.FromArgb(Convert.ToInt32(instrumenty_yobit_array[n, 6]), Convert.ToInt32(instrumenty_yobit_array[n, 7]), Convert.ToInt32(instrumenty_yobit_array[n, 8]))),
                                                            (k + 2) - 1,
                                                            pictureBox_yobit.Height / 2 - Convert.ToSingle(graph_yobit[n, k].ToString().Replace(".", ",")) * graph_massht_yobit - 1,
                                                            (k + 2) + 1,
                                                            pictureBox_yobit.Height / 2 - Convert.ToSingle(graph_yobit[n, k].ToString().Replace(".", ",")) * graph_massht_yobit + 1);
                                                    g.DrawLine(new Pen(Color.FromArgb(Convert.ToInt32(instrumenty_yobit_array[n, 6]), Convert.ToInt32(instrumenty_yobit_array[n, 7]), Convert.ToInt32(instrumenty_yobit_array[n, 8]))),
                                                        (k + 2) + 1,
                                                        pictureBox_yobit.Height / 2 - Convert.ToSingle(graph_yobit[n, k].ToString().Replace(".", ",")) * graph_massht_yobit - 1,
                                                        (k + 2) - 1,
                                                        pictureBox_yobit.Height / 2 - Convert.ToSingle(graph_yobit[n, k].ToString().Replace(".", ",")) * graph_massht_yobit + 1);
                                                }
                                        }
                                    }
                                }
                            }
                            pictureBox_yobit.Image = bmp_yobit;
                            graph = 0;
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " error gr1 " + ex);
                        }
                    }
                }
            };
            ws.OnError += (sender, error) => Console.WriteLine((DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " OnError: " + error.Message));
            ws.OnClose += (sender, OnClose) => Console.WriteLine((DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " OnClose: " + OnClose.Code.ToString()));
            ws.Connect();
            ws.Send("[1,\"restricted_realm\",{\"roles\":{\"caller\":{\"features\":{\"caller_identification\":true,\"progressive_call_results\":true}},\"callee\":{\"features\":{\"caller_identification\":true,\"pattern_based_registration\":true,\"shared_registration\":true,\"progressive_call_results\":true,\"registration_revocation\":true}},\"publisher\":{\"features\":{\"publisher_identification\":true,\"subscriber_blackwhite_listing\":true,\"publisher_exclusion\":true}},\"subscriber\":{\"features\":{\"publisher_identification\":true,\"pattern_based_subscription\":true,\"subscription_revocation\":true}}}}]");
            ws.Send("[32,5859204059174672,{},\"ticker\"]");
        }
    }
}
    