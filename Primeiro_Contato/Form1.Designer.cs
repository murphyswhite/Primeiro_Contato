
namespace Primeiro_Contato
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.open_file = new System.Windows.Forms.Button();
            this.label_escoha = new System.Windows.Forms.Label();
            this.labelarquivo = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.button_enviar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.labelnumero = new System.Windows.Forms.Label();
            this.labelnome = new System.Windows.Forms.Label();
            this.labelimagem = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cont = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // open_file
            // 
            resources.ApplyResources(this.open_file, "open_file");
            this.open_file.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.open_file.Cursor = System.Windows.Forms.Cursors.Hand;
            this.open_file.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.open_file.Image = global::Primeiro_Contato.Properties.Resources.icons8_import_32;
            this.open_file.Name = "open_file";
            this.open_file.UseVisualStyleBackColor = false;
            this.open_file.Click += new System.EventHandler(this.open_file_Click);
            // 
            // label_escoha
            // 
            resources.ApplyResources(this.label_escoha, "label_escoha");
            this.label_escoha.Name = "label_escoha";
            this.label_escoha.Click += new System.EventHandler(this.label1_Click);
            // 
            // labelarquivo
            // 
            resources.ApplyResources(this.labelarquivo, "labelarquivo");
            this.labelarquivo.ForeColor = System.Drawing.Color.Red;
            this.labelarquivo.Name = "labelarquivo";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Name = "label1";
            this.label1.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Name = "label2";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // richTextBox1
            // 
            resources.ApplyResources(this.richTextBox1, "richTextBox1");
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // button_enviar
            // 
            resources.ApplyResources(this.button_enviar, "button_enviar");
            this.button_enviar.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.button_enviar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_enviar.Image = global::Primeiro_Contato.Properties.Resources.icons8_email_send_321;
            this.button_enviar.Name = "button_enviar";
            this.button_enviar.UseVisualStyleBackColor = false;
            this.button_enviar.Click += new System.EventHandler(this.button_enviar_Click);
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Name = "label3";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // labelnumero
            // 
            resources.ApplyResources(this.labelnumero, "labelnumero");
            this.labelnumero.Name = "labelnumero";
            this.labelnumero.Click += new System.EventHandler(this.labelnumero_Click);
            // 
            // labelnome
            // 
            resources.ApplyResources(this.labelnome, "labelnome");
            this.labelnome.Name = "labelnome";
            this.labelnome.Click += new System.EventHandler(this.labelnome_Click);
            // 
            // labelimagem
            // 
            resources.ApplyResources(this.labelimagem, "labelimagem");
            this.labelimagem.Name = "labelimagem";
            this.labelimagem.Click += new System.EventHandler(this.labelimagem_Click);
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // cont
            // 
            resources.ApplyResources(this.cont, "cont");
            this.cont.Name = "cont";
            this.cont.TextChanged += new System.EventHandler(this.cont_TextChanged);
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.BackColor = System.Drawing.Color.Gainsboro;
            this.label6.Name = "label6";
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cont);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.labelimagem);
            this.Controls.Add(this.labelnome);
            this.Controls.Add(this.labelnumero);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button_enviar);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelarquivo);
            this.Controls.Add(this.label_escoha);
            this.Controls.Add(this.open_file);
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button open_file;
        private System.Windows.Forms.Label label_escoha;
        private System.Windows.Forms.Label labelarquivo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button button_enviar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labelnumero;
        private System.Windows.Forms.Label labelnome;
        private System.Windows.Forms.Label labelimagem;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox cont;
        private System.Windows.Forms.Label label6;
    }
}

