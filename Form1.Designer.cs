namespace AppAsync
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnIniciar = new Button();
            lbResultados = new ListBox();
            lblStatus = new Label();
            SuspendLayout();
            // 
            // btnIniciar
            // 
            btnIniciar.Location = new Point(27, 202);
            btnIniciar.Name = "btnIniciar";
            btnIniciar.Size = new Size(280, 23);
            btnIniciar.TabIndex = 0;
            btnIniciar.Text = "Iniciar Tarefas";
            btnIniciar.UseVisualStyleBackColor = true;
            btnIniciar.Click += btnIniciar_Click;
            // 
            // lbResultados
            // 
            lbResultados.FormattingEnabled = true;
            lbResultados.Location = new Point(27, 12);
            lbResultados.Name = "lbResultados";
            lbResultados.Size = new Size(280, 184);
            lbResultados.TabIndex = 1;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(27, 242);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(38, 15);
            lblStatus.TabIndex = 2;
            lblStatus.Text = "label1";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(342, 288);
            Controls.Add(lblStatus);
            Controls.Add(lbResultados);
            Controls.Add(btnIniciar);
            Name = "Form1";
            Text = "Async";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnIniciar;
        private ListBox lbResultados;
        private Label lblStatus;
    }
}
