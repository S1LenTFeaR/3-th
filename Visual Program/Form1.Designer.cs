namespace Visual_Program
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
            this.numericQ = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.numericR = new System.Windows.Forms.NumericUpDown();
            this.labelStatus = new System.Windows.Forms.Label();
            this.mouseBox = new Visual_Program.MouseBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericQ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericR)).BeginInit();
            this.SuspendLayout();
            // 
            // numericQ
            // 
            this.numericQ.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numericQ.Location = new System.Drawing.Point(79, 317);
            this.numericQ.Maximum = new decimal(new int[] {
            150,
            0,
            0,
            0});
            this.numericQ.Name = "numericQ";
            this.numericQ.Size = new System.Drawing.Size(68, 24);
            this.numericQ.TabIndex = 4;
            this.numericQ.Validated += new System.EventHandler(this.NumericQ_Validated);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 319);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 18);
            this.label1.TabIndex = 2;
            this.label1.Text = "Допуск";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(153, 319);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 18);
            this.label2.TabIndex = 5;
            this.label2.Text = "Радиус";
            // 
            // numericR
            // 
            this.numericR.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numericR.Location = new System.Drawing.Point(217, 315);
            this.numericR.Maximum = new decimal(new int[] {
            130,
            0,
            0,
            0});
            this.numericR.Name = "numericR";
            this.numericR.Size = new System.Drawing.Size(68, 24);
            this.numericR.TabIndex = 6;
            this.numericR.Validated += new System.EventHandler(this.NumericR_Validated);
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelStatus.Location = new System.Drawing.Point(12, 351);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(282, 24);
            this.labelStatus.TabIndex = 7;
            this.labelStatus.Text = "Ведите курсор по окружности";
            // 
            // mouseBox
            // 
            this.mouseBox.Location = new System.Drawing.Point(3, 3);
            this.mouseBox.Name = "mouseBox";
            this.mouseBox.Size = new System.Drawing.Size(300, 300);
            this.mouseBox.TabIndex = 8;
            this.mouseBox.MoveMouseCircularPath += new System.EventHandler(this.MouseBox_MoveMouseCircularPath);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(306, 384);
            this.Controls.Add(this.mouseBox);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.numericR);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numericQ);
            this.Name = "Form1";
            this.Text = "Вращение";
            ((System.ComponentModel.ISupportInitialize)(this.numericQ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericR)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.NumericUpDown numericQ;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericR;
        private System.Windows.Forms.Label labelStatus;
        private MouseBox mouseBox;
    }
}

