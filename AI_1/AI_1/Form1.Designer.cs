namespace AI_1
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.startAlgorithmButton = new System.Windows.Forms.Button();
            this.randomizeButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.Console_AI = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Location = new System.Drawing.Point(12, 12);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.startAlgorithmButton);
            this.splitContainer1.Panel1.Controls.Add(this.randomizeButton);
            this.splitContainer1.Panel1.Controls.Add(this.button1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.Console_AI);
            this.splitContainer1.Size = new System.Drawing.Size(886, 484);
            this.splitContainer1.SplitterDistance = 295;
            this.splitContainer1.TabIndex = 1;
            // 
            // startAlgorithmButton
            // 
            this.startAlgorithmButton.Location = new System.Drawing.Point(3, 62);
            this.startAlgorithmButton.Name = "startAlgorithmButton";
            this.startAlgorithmButton.Size = new System.Drawing.Size(289, 23);
            this.startAlgorithmButton.TabIndex = 2;
            this.startAlgorithmButton.Text = "Start Algorithm";
            this.startAlgorithmButton.UseVisualStyleBackColor = true;
            this.startAlgorithmButton.Click += new System.EventHandler(this.startAlgorithmButton_Click);
            // 
            // randomizeButton
            // 
            this.randomizeButton.Location = new System.Drawing.Point(3, 32);
            this.randomizeButton.Name = "randomizeButton";
            this.randomizeButton.Size = new System.Drawing.Size(289, 23);
            this.randomizeButton.TabIndex = 1;
            this.randomizeButton.Text = "Randomize";
            this.randomizeButton.UseVisualStyleBackColor = true;
            this.randomizeButton.Click += new System.EventHandler(this.randomizeButton_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(3, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(289, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Read File";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.ReadFile);
            // 
            // Console_AI
            // 
            this.Console_AI.AcceptsReturn = true;
            this.Console_AI.AcceptsTab = true;
            this.Console_AI.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Console_AI.Location = new System.Drawing.Point(3, 3);
            this.Console_AI.MaxLength = 200000;
            this.Console_AI.Multiline = true;
            this.Console_AI.Name = "Console_AI";
            this.Console_AI.ReadOnly = true;
            this.Console_AI.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Console_AI.Size = new System.Drawing.Size(581, 478);
            this.Console_AI.TabIndex = 0;
            this.Console_AI.TextChanged += new System.EventHandler(this.Console_AI_TextChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(910, 508);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TextBox Console_AI;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button randomizeButton;
        private System.Windows.Forms.Button startAlgorithmButton;
    }
}

