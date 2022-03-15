
namespace yobit_software
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dataGridView_yobit = new System.Windows.Forms.DataGridView();
            this.pictureBox_yobit = new System.Windows.Forms.PictureBox();
            this.proc_yobit = new System.Windows.Forms.TextBox();
            this.time_step_yobit = new System.Windows.Forms.TextBox();
            this.time_step_timer_yobit = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_yobit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_yobit)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView_yobit
            // 
            this.dataGridView_yobit.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_yobit.Location = new System.Drawing.Point(1, 2);
            this.dataGridView_yobit.Name = "dataGridView_yobit";
            this.dataGridView_yobit.Size = new System.Drawing.Size(1000, 336);
            this.dataGridView_yobit.TabIndex = 0;
            this.dataGridView_yobit.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView_yobit_CellMouseDoubleClick);
            // 
            // pictureBox_yobit
            // 
            this.pictureBox_yobit.Location = new System.Drawing.Point(1, 342);
            this.pictureBox_yobit.Name = "pictureBox_yobit";
            this.pictureBox_yobit.Size = new System.Drawing.Size(1000, 362);
            this.pictureBox_yobit.TabIndex = 78;
            this.pictureBox_yobit.TabStop = false;
            // 
            // proc_yobit
            // 
            this.proc_yobit.Location = new System.Drawing.Point(8, 357);
            this.proc_yobit.Name = "proc_yobit";
            this.proc_yobit.Size = new System.Drawing.Size(37, 20);
            this.proc_yobit.TabIndex = 81;
            this.proc_yobit.Text = "1000";
            this.proc_yobit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.proc_yobit.TextChanged += new System.EventHandler(this.proc_yobit_TextChanged);
            // 
            // time_step_yobit
            // 
            this.time_step_yobit.Location = new System.Drawing.Point(937, 678);
            this.time_step_yobit.Name = "time_step_yobit";
            this.time_step_yobit.Size = new System.Drawing.Size(56, 20);
            this.time_step_yobit.TabIndex = 80;
            this.time_step_yobit.Text = "1000";
            this.time_step_yobit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // time_step_timer_yobit
            // 
            this.time_step_timer_yobit.Enabled = true;
            this.time_step_timer_yobit.Interval = 1000;
            this.time_step_timer_yobit.Tick += new System.EventHandler(this.time_step_timer_yobit_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(936, 665);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 82;
            this.label1.Text = "Interval, ms";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 344);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 83;
            this.label2.Text = "Percent";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1003, 707);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.proc_yobit);
            this.Controls.Add(this.time_step_yobit);
            this.Controls.Add(this.pictureBox_yobit);
            this.Controls.Add(this.dataGridView_yobit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "Form1";
            this.Text = "Yobit";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_yobit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_yobit)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_yobit;
        private System.Windows.Forms.PictureBox pictureBox_yobit;
        private System.Windows.Forms.TextBox proc_yobit;
        private System.Windows.Forms.TextBox time_step_yobit;
        private System.Windows.Forms.Timer time_step_timer_yobit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

