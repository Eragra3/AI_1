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
            this.button2 = new System.Windows.Forms.Button();
            this.StartGEOM70ScriptButton = new System.Windows.Forms.Button();
            this.StartBasicScriptButton = new System.Windows.Forms.Button();
            this.mutationMethodCB = new System.Windows.Forms.ComboBox();
            this.crossoverMethodCB = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.startAlgorithmButton = new System.Windows.Forms.Button();
            this.randomizeButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
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
            this.splitContainer1.Panel1.Controls.Add(this.button2);
            this.splitContainer1.Panel1.Controls.Add(this.StartGEOM70ScriptButton);
            this.splitContainer1.Panel1.Controls.Add(this.StartBasicScriptButton);
            this.splitContainer1.Panel1.Controls.Add(this.mutationMethodCB);
            this.splitContainer1.Panel1.Controls.Add(this.crossoverMethodCB);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.startAlgorithmButton);
            this.splitContainer1.Panel1.Controls.Add(this.randomizeButton);
            this.splitContainer1.Panel1.Controls.Add(this.button1);
            this.splitContainer1.Size = new System.Drawing.Size(886, 484);
            this.splitContainer1.SplitterDistance = 295;
            this.splitContainer1.TabIndex = 1;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(3, 151);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(289, 23);
            this.button2.TabIndex = 9;
            this.button2.Text = "Start GEOM40 Script";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // StartGEOM70ScriptButton
            // 
            this.StartGEOM70ScriptButton.Location = new System.Drawing.Point(3, 122);
            this.StartGEOM70ScriptButton.Name = "StartGEOM70ScriptButton";
            this.StartGEOM70ScriptButton.Size = new System.Drawing.Size(289, 23);
            this.StartGEOM70ScriptButton.TabIndex = 8;
            this.StartGEOM70ScriptButton.Text = "Start GEOM70 Script";
            this.StartGEOM70ScriptButton.UseVisualStyleBackColor = true;
            this.StartGEOM70ScriptButton.Click += new System.EventHandler(this.StartGEOM70ScriptButton_Click);
            // 
            // StartBasicScriptButton
            // 
            this.StartBasicScriptButton.Location = new System.Drawing.Point(3, 92);
            this.StartBasicScriptButton.Name = "StartBasicScriptButton";
            this.StartBasicScriptButton.Size = new System.Drawing.Size(289, 23);
            this.StartBasicScriptButton.TabIndex = 7;
            this.StartBasicScriptButton.Text = "Start Basic Script";
            this.StartBasicScriptButton.UseVisualStyleBackColor = true;
            this.StartBasicScriptButton.Click += new System.EventHandler(this.StartBasicScriptButton_Click);
            // 
            // mutationMethodCB
            // 
            this.mutationMethodCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.mutationMethodCB.FormattingEnabled = true;
            this.mutationMethodCB.Location = new System.Drawing.Point(147, 455);
            this.mutationMethodCB.Name = "mutationMethodCB";
            this.mutationMethodCB.Size = new System.Drawing.Size(145, 21);
            this.mutationMethodCB.TabIndex = 6;
            this.mutationMethodCB.SelectionChangeCommitted += new System.EventHandler(this.mutationMethodCB_SelectionChangeCommitted);
            // 
            // crossoverMethodCB
            // 
            this.crossoverMethodCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.crossoverMethodCB.FormattingEnabled = true;
            this.crossoverMethodCB.Location = new System.Drawing.Point(147, 428);
            this.crossoverMethodCB.Name = "crossoverMethodCB";
            this.crossoverMethodCB.Size = new System.Drawing.Size(145, 21);
            this.crossoverMethodCB.TabIndex = 5;
            this.crossoverMethodCB.SelectionChangeCommitted += new System.EventHandler(this.crossoverMethodCB_SelectionChangeCommitted);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 458);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Mutation Method";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 431);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Crossover Method";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(3, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(289, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Read File";
            this.button1.UseVisualStyleBackColor = true;
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
            this.splitContainer1.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button randomizeButton;
        private System.Windows.Forms.Button startAlgorithmButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.ComboBox crossoverMethodCB;
        public System.Windows.Forms.ComboBox mutationMethodCB;
        private System.Windows.Forms.Button StartBasicScriptButton;
        private System.Windows.Forms.Button StartGEOM70ScriptButton;
        private System.Windows.Forms.Button button2;
    }
}

