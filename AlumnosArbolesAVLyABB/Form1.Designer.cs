namespace AlumnosArbolesAVLyABB
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
            btnBuscar = new Button();
            txtCarnet = new TextBox();
            label1 = new Label();
            button1 = new Button();
            lstDatos = new ListBox();
            SuspendLayout();
            // 
            // btnBuscar
            // 
            btnBuscar.Location = new Point(30, 47);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(99, 47);
            btnBuscar.TabIndex = 0;
            btnBuscar.Text = "BUSCAR";
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // txtCarnet
            // 
            txtCarnet.Location = new Point(290, 60);
            txtCarnet.Multiline = true;
            txtCarnet.Name = "txtCarnet";
            txtCarnet.Size = new Size(165, 34);
            txtCarnet.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label1.Location = new Point(144, 73);
            label1.Name = "label1";
            label1.Size = new Size(140, 21);
            label1.TabIndex = 5;
            label1.Text = "INGRESAR CARNE";
            // 
            // button1
            // 
            button1.Location = new Point(30, 125);
            button1.Name = "button1";
            button1.Size = new Size(101, 56);
            button1.TabIndex = 6;
            button1.Text = "MOSTRAR DATOS";
            button1.UseVisualStyleBackColor = true;
            button1.Click += btnMostrarDatos_Click;
            // 
            // lstDatos
            // 
            lstDatos.FormattingEnabled = true;
            lstDatos.ItemHeight = 15;
            lstDatos.Location = new Point(137, 125);
            lstDatos.Name = "lstDatos";
            lstDatos.Size = new Size(569, 184);
            lstDatos.TabIndex = 7;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            BackColor = SystemColors.GradientInactiveCaption;
            ClientSize = new Size(737, 321);
            Controls.Add(lstDatos);
            Controls.Add(button1);
            Controls.Add(label1);
            Controls.Add(txtCarnet);
            Controls.Add(btnBuscar);
            Name = "Form1";
            Text = "AVLvsABB";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnBuscar;
        private TextBox txtCarnet;
        private Label label1;
        private Button button1;
        private ListBox lstDatos;
    }
}