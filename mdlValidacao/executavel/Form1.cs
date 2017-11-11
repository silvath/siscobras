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
			/// <summary>
			/// The main entry point for the application.
			/// </summary>
			[STAThread]
			static void Main() 
			{
				Application.Run(new Form1());
			}
		#endregion

		#region Atributes
			private mdlComponentesGraficos.TextBox textBox1;
			private System.Windows.Forms.Label label1;
			private System.Windows.Forms.Label label2;
			private mdlComponentesGraficos.TextBox textBox2;
			private mdlComponentesGraficos.TextBox m_txtModula11;
			private System.Windows.Forms.Button m_btModulaOnzeReturn;
			private System.Windows.Forms.GroupBox m_gbModula11;
			private System.Windows.Forms.Button m_btModulaOnzeCheck;
			private System.Windows.Forms.Label label3;
			private System.Windows.Forms.GroupBox m_gbGeral;
			private mdlComponentesGraficos.TextBox m_txtRetorno;
			private System.Windows.Forms.Label m_lbRetorno;
			private System.Windows.Forms.GroupBox m_gbRetorno;
			private System.Windows.Forms.GroupBox m_gbCNPJ;
			private System.Windows.Forms.GroupBox m_gbCPF;
			private System.Windows.Forms.GroupBox m_gbModulaDez;
			private mdlComponentesGraficos.TextBox m_txtModula10;
			private System.Windows.Forms.Button m_btModulaDezCheck;
			private System.Windows.Forms.Label m_lbModula10;
			private System.Windows.Forms.Button m_btModulaDezReturn;
		private System.Windows.Forms.Button m_btValidaCNPJ;
		private System.Windows.Forms.Button m_btValidaCPF;
		private System.Windows.Forms.GroupBox m_gbContainer;
		private System.Windows.Forms.Label m_lbContainerNumber;
		private mdlComponentesGraficos.TextBox m_txtContainerNumber;
		private System.Windows.Forms.Button m_btContainerCheck;
		private System.Windows.Forms.Button m_btContainerReturn;
			private System.ComponentModel.Container components = null;
		#endregion
		#region Constructors and Destructors
			public Form1()
			{
				//
				// Required for Windows Form Designer support
				//
				InitializeComponent();

				//
				// TODO: Add any constructor code after InitializeComponent call
				//
			}

			/// <summary>
			/// Clean up any resources being used.
			/// </summary>
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
			this.textBox1 = new mdlComponentesGraficos.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.m_btValidaCNPJ = new System.Windows.Forms.Button();
			this.m_btValidaCPF = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.textBox2 = new mdlComponentesGraficos.TextBox();
			this.m_txtModula11 = new mdlComponentesGraficos.TextBox();
			this.m_btModulaOnzeReturn = new System.Windows.Forms.Button();
			this.m_gbModula11 = new System.Windows.Forms.GroupBox();
			this.m_btModulaOnzeCheck = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.m_gbGeral = new System.Windows.Forms.GroupBox();
			this.m_gbModulaDez = new System.Windows.Forms.GroupBox();
			this.m_txtModula10 = new mdlComponentesGraficos.TextBox();
			this.m_btModulaDezCheck = new System.Windows.Forms.Button();
			this.m_lbModula10 = new System.Windows.Forms.Label();
			this.m_btModulaDezReturn = new System.Windows.Forms.Button();
			this.m_gbCPF = new System.Windows.Forms.GroupBox();
			this.m_gbCNPJ = new System.Windows.Forms.GroupBox();
			this.m_gbRetorno = new System.Windows.Forms.GroupBox();
			this.m_lbRetorno = new System.Windows.Forms.Label();
			this.m_txtRetorno = new mdlComponentesGraficos.TextBox();
			this.m_gbContainer = new System.Windows.Forms.GroupBox();
			this.m_txtContainerNumber = new mdlComponentesGraficos.TextBox();
			this.m_btContainerCheck = new System.Windows.Forms.Button();
			this.m_lbContainerNumber = new System.Windows.Forms.Label();
			this.m_btContainerReturn = new System.Windows.Forms.Button();
			this.m_gbModula11.SuspendLayout();
			this.m_gbGeral.SuspendLayout();
			this.m_gbModulaDez.SuspendLayout();
			this.m_gbCPF.SuspendLayout();
			this.m_gbCNPJ.SuspendLayout();
			this.m_gbRetorno.SuspendLayout();
			this.m_gbContainer.SuspendLayout();
			this.SuspendLayout();
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(54, 14);
			this.textBox1.Mask = true;
			this.textBox1.MaskText = "NN.NNN.NNN/NNNN-NN";
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(112, 20);
			this.textBox1.TabIndex = 0;
			this.textBox1.Text = "43.928.183/0001-12";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(11, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(40, 16);
			this.label1.TabIndex = 1;
			this.label1.Text = "CNPJ:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// m_btValidaCNPJ
			// 
			this.m_btValidaCNPJ.Location = new System.Drawing.Point(6, 36);
			this.m_btValidaCNPJ.Name = "m_btValidaCNPJ";
			this.m_btValidaCNPJ.Size = new System.Drawing.Size(88, 23);
			this.m_btValidaCNPJ.TabIndex = 2;
			this.m_btValidaCNPJ.Text = "Validar CNPJ";
			this.m_btValidaCNPJ.Click += new System.EventHandler(this.button1_Click);
			// 
			// m_btValidaCPF
			// 
			this.m_btValidaCPF.Location = new System.Drawing.Point(6, 38);
			this.m_btValidaCPF.Name = "m_btValidaCPF";
			this.m_btValidaCPF.Size = new System.Drawing.Size(88, 23);
			this.m_btValidaCPF.TabIndex = 5;
			this.m_btValidaCPF.Text = "Validar CPF";
			this.m_btValidaCPF.Click += new System.EventHandler(this.button2_Click);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 17);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(40, 16);
			this.label2.TabIndex = 4;
			this.label2.Text = "CPF:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(55, 13);
			this.textBox2.Mask = true;
			this.textBox2.MaskText = "NNN.NNN.NNN-NN";
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(112, 20);
			this.textBox2.TabIndex = 3;
			this.textBox2.Text = "007.786.449-28";
			// 
			// m_txtModula11
			// 
			this.m_txtModula11.Location = new System.Drawing.Point(72, 18);
			this.m_txtModula11.Name = "m_txtModula11";
			this.m_txtModula11.Size = new System.Drawing.Size(168, 20);
			this.m_txtModula11.TabIndex = 6;
			this.m_txtModula11.Text = "0019100000035420680208634713912010000267821";
			// 
			// m_btModulaOnzeReturn
			// 
			this.m_btModulaOnzeReturn.Location = new System.Drawing.Point(128, 46);
			this.m_btModulaOnzeReturn.Name = "m_btModulaOnzeReturn";
			this.m_btModulaOnzeReturn.Size = new System.Drawing.Size(112, 23);
			this.m_btModulaOnzeReturn.TabIndex = 9;
			this.m_btModulaOnzeReturn.Text = "Return Modula 11";
			this.m_btModulaOnzeReturn.Click += new System.EventHandler(this.m_btModulaOnzeReturn_Click);
			// 
			// m_gbModula11
			// 
			this.m_gbModula11.Controls.Add(this.m_txtModula11);
			this.m_gbModula11.Controls.Add(this.m_btModulaOnzeCheck);
			this.m_gbModula11.Controls.Add(this.label3);
			this.m_gbModula11.Controls.Add(this.m_btModulaOnzeReturn);
			this.m_gbModula11.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_gbModula11.Location = new System.Drawing.Point(7, 9);
			this.m_gbModula11.Name = "m_gbModula11";
			this.m_gbModula11.Size = new System.Drawing.Size(248, 79);
			this.m_gbModula11.TabIndex = 10;
			this.m_gbModula11.TabStop = false;
			this.m_gbModula11.Text = "Modula 11";
			// 
			// m_btModulaOnzeCheck
			// 
			this.m_btModulaOnzeCheck.Location = new System.Drawing.Point(8, 46);
			this.m_btModulaOnzeCheck.Name = "m_btModulaOnzeCheck";
			this.m_btModulaOnzeCheck.Size = new System.Drawing.Size(112, 23);
			this.m_btModulaOnzeCheck.TabIndex = 8;
			this.m_btModulaOnzeCheck.Text = "Check Modula 11";
			this.m_btModulaOnzeCheck.Click += new System.EventHandler(this.m_btModulaOnzeCheck_Click);
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(8, 18);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(64, 16);
			this.label3.TabIndex = 7;
			this.label3.Text = "Modula11:";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// m_gbGeral
			// 
			this.m_gbGeral.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_gbGeral.Controls.Add(this.m_gbContainer);
			this.m_gbGeral.Controls.Add(this.m_gbModulaDez);
			this.m_gbGeral.Controls.Add(this.m_gbCPF);
			this.m_gbGeral.Controls.Add(this.m_gbCNPJ);
			this.m_gbGeral.Controls.Add(this.m_gbRetorno);
			this.m_gbGeral.Controls.Add(this.m_gbModula11);
			this.m_gbGeral.Location = new System.Drawing.Point(5, 1);
			this.m_gbGeral.Name = "m_gbGeral";
			this.m_gbGeral.Size = new System.Drawing.Size(260, 431);
			this.m_gbGeral.TabIndex = 11;
			this.m_gbGeral.TabStop = false;
			// 
			// m_gbModulaDez
			// 
			this.m_gbModulaDez.Controls.Add(this.m_txtModula10);
			this.m_gbModulaDez.Controls.Add(this.m_btModulaDezCheck);
			this.m_gbModulaDez.Controls.Add(this.m_lbModula10);
			this.m_gbModulaDez.Controls.Add(this.m_btModulaDezReturn);
			this.m_gbModulaDez.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_gbModulaDez.Location = new System.Drawing.Point(6, 88);
			this.m_gbModulaDez.Name = "m_gbModulaDez";
			this.m_gbModulaDez.Size = new System.Drawing.Size(248, 79);
			this.m_gbModulaDez.TabIndex = 15;
			this.m_gbModulaDez.TabStop = false;
			this.m_gbModulaDez.Text = "Modula 10";
			// 
			// m_txtModula10
			// 
			this.m_txtModula10.Location = new System.Drawing.Point(72, 18);
			this.m_txtModula10.Name = "m_txtModula10";
			this.m_txtModula10.Size = new System.Drawing.Size(168, 20);
			this.m_txtModula10.TabIndex = 6;
			this.m_txtModula10.Text = "29004590";
			// 
			// m_btModulaDezCheck
			// 
			this.m_btModulaDezCheck.Location = new System.Drawing.Point(8, 46);
			this.m_btModulaDezCheck.Name = "m_btModulaDezCheck";
			this.m_btModulaDezCheck.Size = new System.Drawing.Size(112, 23);
			this.m_btModulaDezCheck.TabIndex = 8;
			this.m_btModulaDezCheck.Text = "Check Modula 10";
			this.m_btModulaDezCheck.Click += new System.EventHandler(this.m_btModulaDezCheck_Click);
			// 
			// m_lbModula10
			// 
			this.m_lbModula10.Location = new System.Drawing.Point(8, 18);
			this.m_lbModula10.Name = "m_lbModula10";
			this.m_lbModula10.Size = new System.Drawing.Size(64, 16);
			this.m_lbModula10.TabIndex = 7;
			this.m_lbModula10.Text = "Modula 10:";
			this.m_lbModula10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// m_btModulaDezReturn
			// 
			this.m_btModulaDezReturn.Location = new System.Drawing.Point(128, 46);
			this.m_btModulaDezReturn.Name = "m_btModulaDezReturn";
			this.m_btModulaDezReturn.Size = new System.Drawing.Size(112, 23);
			this.m_btModulaDezReturn.TabIndex = 9;
			this.m_btModulaDezReturn.Text = "Return Modula 10";
			this.m_btModulaDezReturn.Click += new System.EventHandler(this.m_btModulaDezReturn_Click);
			// 
			// m_gbCPF
			// 
			this.m_gbCPF.Controls.Add(this.m_btValidaCPF);
			this.m_gbCPF.Controls.Add(this.label2);
			this.m_gbCPF.Controls.Add(this.textBox2);
			this.m_gbCPF.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_gbCPF.Location = new System.Drawing.Point(7, 240);
			this.m_gbCPF.Name = "m_gbCPF";
			this.m_gbCPF.Size = new System.Drawing.Size(176, 72);
			this.m_gbCPF.TabIndex = 14;
			this.m_gbCPF.TabStop = false;
			this.m_gbCPF.Text = "CPF";
			// 
			// m_gbCNPJ
			// 
			this.m_gbCNPJ.Controls.Add(this.label1);
			this.m_gbCNPJ.Controls.Add(this.textBox1);
			this.m_gbCNPJ.Controls.Add(this.m_btValidaCNPJ);
			this.m_gbCNPJ.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_gbCNPJ.Location = new System.Drawing.Point(6, 176);
			this.m_gbCNPJ.Name = "m_gbCNPJ";
			this.m_gbCNPJ.Size = new System.Drawing.Size(176, 65);
			this.m_gbCNPJ.TabIndex = 13;
			this.m_gbCNPJ.TabStop = false;
			this.m_gbCNPJ.Text = "CNPJ";
			// 
			// m_gbRetorno
			// 
			this.m_gbRetorno.Controls.Add(this.m_lbRetorno);
			this.m_gbRetorno.Controls.Add(this.m_txtRetorno);
			this.m_gbRetorno.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_gbRetorno.Location = new System.Drawing.Point(5, 384);
			this.m_gbRetorno.Name = "m_gbRetorno";
			this.m_gbRetorno.Size = new System.Drawing.Size(251, 40);
			this.m_gbRetorno.TabIndex = 12;
			this.m_gbRetorno.TabStop = false;
			this.m_gbRetorno.Text = "Retorno";
			// 
			// m_lbRetorno
			// 
			this.m_lbRetorno.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lbRetorno.Location = new System.Drawing.Point(8, 15);
			this.m_lbRetorno.Name = "m_lbRetorno";
			this.m_lbRetorno.Size = new System.Drawing.Size(64, 16);
			this.m_lbRetorno.TabIndex = 11;
			this.m_lbRetorno.Text = "Retorno:";
			this.m_lbRetorno.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// m_txtRetorno
			// 
			this.m_txtRetorno.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_txtRetorno.Location = new System.Drawing.Point(71, 13);
			this.m_txtRetorno.Name = "m_txtRetorno";
			this.m_txtRetorno.Size = new System.Drawing.Size(169, 20);
			this.m_txtRetorno.TabIndex = 10;
			this.m_txtRetorno.Text = "";
			// 
			// m_gbContainer
			// 
			this.m_gbContainer.Controls.Add(this.m_txtContainerNumber);
			this.m_gbContainer.Controls.Add(this.m_btContainerCheck);
			this.m_gbContainer.Controls.Add(this.m_lbContainerNumber);
			this.m_gbContainer.Controls.Add(this.m_btContainerReturn);
			this.m_gbContainer.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_gbContainer.Location = new System.Drawing.Point(8, 312);
			this.m_gbContainer.Name = "m_gbContainer";
			this.m_gbContainer.Size = new System.Drawing.Size(248, 72);
			this.m_gbContainer.TabIndex = 16;
			this.m_gbContainer.TabStop = false;
			this.m_gbContainer.Text = "Container";
			// 
			// m_txtContainerNumber
			// 
			this.m_txtContainerNumber.Location = new System.Drawing.Point(72, 11);
			this.m_txtContainerNumber.Name = "m_txtContainerNumber";
			this.m_txtContainerNumber.Size = new System.Drawing.Size(168, 20);
			this.m_txtContainerNumber.TabIndex = 10;
			this.m_txtContainerNumber.Text = "CTIU2454316";
			// 
			// m_btContainerCheck
			// 
			this.m_btContainerCheck.Location = new System.Drawing.Point(8, 39);
			this.m_btContainerCheck.Name = "m_btContainerCheck";
			this.m_btContainerCheck.Size = new System.Drawing.Size(112, 23);
			this.m_btContainerCheck.TabIndex = 12;
			this.m_btContainerCheck.Text = "Check";
			this.m_btContainerCheck.Click += new System.EventHandler(this.m_btContainerCheck_Click);
			// 
			// m_lbContainerNumber
			// 
			this.m_lbContainerNumber.Location = new System.Drawing.Point(8, 11);
			this.m_lbContainerNumber.Name = "m_lbContainerNumber";
			this.m_lbContainerNumber.Size = new System.Drawing.Size(64, 16);
			this.m_lbContainerNumber.TabIndex = 11;
			this.m_lbContainerNumber.Text = "Number:";
			this.m_lbContainerNumber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// m_btContainerReturn
			// 
			this.m_btContainerReturn.Location = new System.Drawing.Point(128, 39);
			this.m_btContainerReturn.Name = "m_btContainerReturn";
			this.m_btContainerReturn.Size = new System.Drawing.Size(112, 23);
			this.m_btContainerReturn.TabIndex = 13;
			this.m_btContainerReturn.Text = "Return";
			this.m_btContainerReturn.Click += new System.EventHandler(this.m_btContainerReturn_Click);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(272, 438);
			this.Controls.Add(this.m_gbGeral);
			this.Name = "Form1";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Form1";
			this.m_gbModula11.ResumeLayout(false);
			this.m_gbGeral.ResumeLayout(false);
			this.m_gbModulaDez.ResumeLayout(false);
			this.m_gbCPF.ResumeLayout(false);
			this.m_gbCNPJ.ResumeLayout(false);
			this.m_gbRetorno.ResumeLayout(false);
			this.m_gbContainer.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Negocio
			#region Modula 11
				private void m_btModulaOnzeCheck_Click(object sender, System.EventArgs e)
				{
					m_txtRetorno.Text = mdlValidacao.clsModuloOnze.bCheckModula11(this.m_txtModula11.Text,true).ToString();
				}

				private void m_btModulaOnzeReturn_Click(object sender, System.EventArgs e)
				{
					mdlValidacao.clsModuloOnze.m_nDigitoVerificadorDefault = 1;
					m_txtRetorno.Text = mdlValidacao.clsModuloOnze.nReturnModula11(m_txtModula11.Text,true).ToString();
				}
			#endregion
			#region Modula 10
				private void m_btModulaDezReturn_Click(object sender, System.EventArgs e)
				{
					m_txtRetorno.Text =  mdlValidacao.clsModuloDez.nReturnModula10(m_txtModula10.Text).ToString();
				}

				private void m_btModulaDezCheck_Click(object sender, System.EventArgs e)
				{
					m_txtRetorno.Text = mdlValidacao.clsModuloDez.bCheckModula10(m_txtModula10.Text).ToString();
				}
			#endregion
			#region CPF
				private void button2_Click(object sender, System.EventArgs e)
				{
					m_txtRetorno.Text = mdlValidacao.clsCPF.bCheckCPF(this.textBox2.Text).ToString();
				}
			#endregion
			#region CNPJ
				private void button1_Click(object sender, System.EventArgs e)
				{
					m_txtRetorno.Text = mdlValidacao.clsCNPJ.bCheckCNPJ(this.textBox1.Text).ToString();
				}
			#endregion
			#region Container
				private void m_btContainerCheck_Click(object sender, System.EventArgs e)
				{
					m_txtRetorno.Text = mdlValidacao.clsContainer.bCheckContainerDigit(this.m_txtContainerNumber.Text).ToString();
				}

				private void m_btContainerReturn_Click(object sender, System.EventArgs e)
				{
					m_txtRetorno.Text = mdlValidacao.clsContainer.nReturnContainerDigitCheck(this.m_txtContainerNumber.Text).ToString();
				}
			#endregion
		#endregion
	}
}
