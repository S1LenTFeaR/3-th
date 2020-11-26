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
            this.brail1 = new Visual_Program.brail();
            this.SuspendLayout();
            // 
            // brail1
            // 
            this.brail1.BackColor = System.Drawing.SystemColors.Control;
            this.brail1.Location = new System.Drawing.Point(12, 12);
            this.brail1.Name = "brail1";
            this.brail1.size = 30F;
            this.brail1.Size = new System.Drawing.Size(411, 366);
            this.brail1.TabIndex = 3;
            this.brail1.text = "Тестирование Брайля";
            this.brail1.Load += new System.EventHandler(this.Brail1_Load);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(435, 390);
            this.Controls.Add(this.brail1);
            this.Name = "Form1";
            this.Text = "Шрифт Брайля";
            this.ResumeLayout(false);

        }

        #endregion
        private brail brail1;
    }
}

