using System;
using System.Drawing;
using System.Windows.Forms;

namespace yobit_software
{
    public partial class Form1
    {
        private void dataGridView_edit()
        {
            dataGridView_yobit.ReadOnly = true;
            dataGridView_yobit.Columns.Add("time", "Time adding");
            dataGridView_yobit.Columns["time"].Width = 160;
            dataGridView_yobit.Columns.Add("name", "Pair");
            dataGridView_yobit.Columns["name"].Width = 140;
            dataGridView_yobit.Columns.Add("change", "Price");
            dataGridView_yobit.Columns["change"].Width = 130;
            dataGridView_yobit.Columns.Add("volume", "Volume");
            dataGridView_yobit.Columns["volume"].Width = 130;
            dataGridView_yobit.Columns.Add("proc", "Сhange in 24 hours");
            dataGridView_yobit.Columns["proc"].Width = 130;
            dataGridView_yobit.Columns.Add("volBTC", "Volume in 24 hours");
            dataGridView_yobit.Columns["volBTC"].Width = 130;
            dataGridView_yobit.Columns.Add("kolvo", "Amount of deals");
            dataGridView_yobit.Columns["kolvo"].Width = 130;
            dataGridView_yobit.ColumnHeadersDefaultCellStyle.Font = new Font(dataGridView_yobit.ColumnHeadersDefaultCellStyle.Font.FontFamily, 9f, FontStyle.Regular);
            dataGridView_yobit.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView_yobit.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            info_label_text = new ToolStripLabel();
            info_label_text.Text = "Start";

            graph_massht_yobit = pictureBox_yobit.Height / Convert.ToSingle(proc_yobit.Text) / 2;
        }
    }
}