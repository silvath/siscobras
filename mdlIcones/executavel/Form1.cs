using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace executavel
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		#region MAIN
			[STAThread]
			static void Main() 
			{
				Application.Run(new Form1());
			}
		#endregion
		#region Atributes
			private System.Windows.Forms.GroupBox m_gbPrincipal;
			private System.Windows.Forms.GroupBox m_gbRetorno;
			private System.Windows.Forms.PictureBox m_picRetorno;
			private System.Windows.Forms.GroupBox m_gbRelatorios;
			private System.Windows.Forms.Button m_btRelatorioSaque;
		private System.Windows.Forms.Button m_btRelatorioFaturaComercial;
			private System.ComponentModel.Container components = null;
		#endregion
		#region Constructor
			public Form1()
			{
				InitializeComponent();
			}

			protected override void Dispose( bool disposing )
			{
				if( disposing )
				{
					if (components != null) 
					{
						components.Dispose();
					}
				}
				base.Dispose( disposing );
			}
		#endregion

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(Form1));
			this.m_gbPrincipal = new System.Windows.Forms.GroupBox();
			this.m_gbRelatorios = new System.Windows.Forms.GroupBox();
			this.m_btRelatorioSaque = new System.Windows.Forms.Button();
			this.m_gbRetorno = new System.Windows.Forms.GroupBox();
			this.m_picRetorno = new System.Windows.Forms.PictureBox();
			this.m_btRelatorioFaturaComercial = new System.Windows.Forms.Button();
			this.m_gbPrincipal.SuspendLayout();
			this.m_gbRelatorios.SuspendLayout();
			this.m_gbRetorno.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_gbPrincipal
			// 
			this.m_gbPrincipal.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_gbPrincipal.Controls.Add(this.m_gbRelatorios);
			this.m_gbPrincipal.Controls.Add(this.m_gbRetorno);
			this.m_gbPrincipal.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_gbPrincipal.Location = new System.Drawing.Point(3, -3);
			this.m_gbPrincipal.Name = "m_gbPrincipal";
			this.m_gbPrincipal.Size = new System.Drawing.Size(277, 274);
			this.m_gbPrincipal.TabIndex = 0;
			this.m_gbPrincipal.TabStop = false;
			// 
			// m_gbRelatorios
			// 
			this.m_gbRelatorios.Controls.Add(this.m_btRelatorioFaturaComercial);
			this.m_gbRelatorios.Controls.Add(this.m_btRelatorioSaque);
			this.m_gbRelatorios.Location = new System.Drawing.Point(7, 7);
			this.m_gbRelatorios.Name = "m_gbRelatorios";
			this.m_gbRelatorios.Size = new System.Drawing.Size(265, 201);
			this.m_gbRelatorios.TabIndex = 1;
			this.m_gbRelatorios.TabStop = false;
			this.m_gbRelatorios.Text = "Relatorios";
			// 
			// m_btRelatorioSaque
			// 
			this.m_btRelatorioSaque.Location = new System.Drawing.Point(8, 16);
			this.m_btRelatorioSaque.Name = "m_btRelatorioSaque";
			this.m_btRelatorioSaque.Size = new System.Drawing.Size(248, 24);
			this.m_btRelatorioSaque.TabIndex = 0;
			this.m_btRelatorioSaque.Text = "Saque";
			this.m_btRelatorioSaque.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.m_btRelatorioSaque.Click += new System.EventHandler(this.m_btRelatorioSaque_Click);
			// 
			// m_gbRetorno
			// 
			this.m_gbRetorno.Controls.Add(this.m_picRetorno);
			this.m_gbRetorno.Location = new System.Drawing.Point(4, 211);
			this.m_gbRetorno.Name = "m_gbRetorno";
			this.m_gbRetorno.Size = new System.Drawing.Size(268, 56);
			this.m_gbRetorno.TabIndex = 0;
			this.m_gbRetorno.TabStop = false;
			this.m_gbRetorno.Text = "Retorno";
			// 
			// m_picRetorno
			// 
			this.m_picRetorno.Location = new System.Drawing.Point(10, 17);
			this.m_picRetorno.Name = "m_picRetorno";
			this.m_picRetorno.Size = new System.Drawing.Size(32, 32);
			this.m_picRetorno.TabIndex = 0;
			this.m_picRetorno.TabStop = false;
			// 
			// m_btRelatorioFaturaComercial
			// 
			this.m_btRelatorioFaturaComercial.Location = new System.Drawing.Point(8, 41);
			this.m_btRelatorioFaturaComercial.Name = "m_btRelatorioFaturaComercial";
			this.m_btRelatorioFaturaComercial.Size = new System.Drawing.Size(248, 24);
			this.m_btRelatorioFaturaComercial.TabIndex = 1;
			this.m_btRelatorioFaturaComercial.Text = "Fatura Comercial";
			this.m_btRelatorioFaturaComercial.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.m_btRelatorioFaturaComercial.Click += new System.EventHandler(this.m_btRelatorioFaturaComercial_Click);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(282, 273);
			this.Controls.Add(this.m_gbPrincipal);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "Form1";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Icones";
			this.m_gbPrincipal.ResumeLayout(false);
			this.m_gbRelatorios.ResumeLayout(false);
			this.m_gbRetorno.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Eventos
			#region Botoes
				private void m_btRelatorioSaque_Click(object sender, System.EventArgs e)
				{
					m_picRetorno.Image = Siscobras.Icones.clsManipuladorIcones.bmpIconeRelatorio(mdlConstantes.Relatorio.Saque);
				}

				private void m_btRelatorioFaturaComercial_Click(object sender, System.EventArgs e)
				{
					m_picRetorno.Image = Siscobras.Icones.clsManipuladorIcones.bmpIconeRelatorio(mdlConstantes.Relatorio.FaturaComercial);
				}
			#endregion
		#endregion

	}
}
