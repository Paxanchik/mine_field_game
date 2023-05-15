namespace mine_game
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panelMineField = new System.Windows.Forms.Panel();
            this.Buttonmine = new System.Windows.Forms.Button();
            this.label_x = new System.Windows.Forms.Label();
            this.label_Y = new System.Windows.Forms.Label();
            this.label_D = new System.Windows.Forms.Label();
            this.label_S = new System.Windows.Forms.Label();
            this.timer_game = new System.Windows.Forms.Timer(this.components);
            this.panelMineField.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMineField
            // 
            this.panelMineField.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.panelMineField.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelMineField.Controls.Add(this.Buttonmine);
            this.panelMineField.Location = new System.Drawing.Point(46, 50);
            this.panelMineField.Name = "panelMineField";
            this.panelMineField.Size = new System.Drawing.Size(750, 500);
            this.panelMineField.TabIndex = 0;
            this.panelMineField.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelMineField_MouseMove);
            // 
            // Buttonmine
            // 
            this.Buttonmine.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Buttonmine.Image = ((System.Drawing.Image)(resources.GetObject("Buttonmine.Image")));
            this.Buttonmine.Location = new System.Drawing.Point(359, 200);
            this.Buttonmine.Name = "Buttonmine";
            this.Buttonmine.Size = new System.Drawing.Size(50, 50);
            this.Buttonmine.TabIndex = 0;
            this.Buttonmine.UseVisualStyleBackColor = true;
            this.Buttonmine.Click += new System.EventHandler(this.Buttonmine_Click);
            // 
            // label_x
            // 
            this.label_x.AutoSize = true;
            this.label_x.Location = new System.Drawing.Point(43, 21);
            this.label_x.Name = "label_x";
            this.label_x.Size = new System.Drawing.Size(35, 13);
            this.label_x.TabIndex = 1;
            this.label_x.Text = "label1";
            this.label_x.Visible = false;
            // 
            // label_Y
            // 
            this.label_Y.AutoSize = true;
            this.label_Y.Location = new System.Drawing.Point(43, 34);
            this.label_Y.Name = "label_Y";
            this.label_Y.Size = new System.Drawing.Size(35, 13);
            this.label_Y.TabIndex = 2;
            this.label_Y.Text = "label1";
            this.label_Y.Visible = false;
            // 
            // label_D
            // 
            this.label_D.AutoSize = true;
            this.label_D.Location = new System.Drawing.Point(155, 21);
            this.label_D.Name = "label_D";
            this.label_D.Size = new System.Drawing.Size(35, 13);
            this.label_D.TabIndex = 3;
            this.label_D.Text = "label2";
            this.label_D.Visible = false;
            // 
            // label_S
            // 
            this.label_S.AutoSize = true;
            this.label_S.Location = new System.Drawing.Point(105, 26);
            this.label_S.Name = "label_S";
            this.label_S.Size = new System.Drawing.Size(35, 13);
            this.label_S.TabIndex = 4;
            this.label_S.Text = "label3";
            // 
            // timer_game
            // 
            this.timer_game.Tick += new System.EventHandler(this.timer_game_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(833, 582);
            this.Controls.Add(this.label_S);
            this.Controls.Add(this.label_D);
            this.Controls.Add(this.label_Y);
            this.Controls.Add(this.label_x);
            this.Controls.Add(this.panelMineField);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Минное поле";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panelMineField.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelMineField;
        private System.Windows.Forms.Button Buttonmine;
        private System.Windows.Forms.Label label_x;
        private System.Windows.Forms.Label label_Y;
        private System.Windows.Forms.Label label_D;
        private System.Windows.Forms.Label label_S;
        private System.Windows.Forms.Timer timer_game;
    }
}

