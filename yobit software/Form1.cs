using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace yobit_software
{
    public partial class Form1 : Form
    {
        ToolStripLabel info_label_text;
        int instrumenty_kol_yobit = 0;
        string[,] instrumenty_yobit_array = new string[200, 500000];
        Random rgb_yobit = new Random();
        string[,] graph_yobit = new string[4000, 2000];
        int[,] message_array_color = new int[400, 400];

        float graph_massht_yobit = 0;
        Bitmap bmp_yobit = new Bitmap(1000, 1000);
        Graphics g;
        byte graph = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView_edit();
            WebSocket_start();
        }

        private void time_step_timer_yobit_Tick(object sender, EventArgs e)
        {
            {
                time_step_timer_yobit.Interval = Convert.ToInt32(time_step_yobit.Text);
                for (int n = 1; n <= instrumenty_kol_yobit; n++)
                {
                    for (int k = 0; k < 1000; k++)
                    {
                        graph_yobit[n, k] = graph_yobit[n, k + 1]; graph_yobit[n, k + 1] = null;
                    }
                }
                try
                {
                    if (graph == 0)
                    {
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
                        pictureBox_yobit.Image = bmp_yobit;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " error graph:" + ex);
                }
            }
        }

        private void proc_yobit_TextChanged(object sender, EventArgs e)
        {
            graph_massht_yobit = pictureBox_yobit.Height / Convert.ToSingle(proc_yobit.Text) / 2;
        }

        private void dataGridView_yobit_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            System.Diagnostics.Process.Start("chrome.exe", "https://yobit.io/ru/trade/" + dataGridView_yobit.Rows[e.RowIndex].Cells["name"].EditedFormattedValue.ToString());
        }
    }


    public class dataGridView_yobit : DataGridView
    {
        public dataGridView_yobit()
        {
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.DoubleBuffer |
              ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint, true);
            this.UpdateStyles();
        }
    }
}
