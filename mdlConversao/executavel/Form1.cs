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

			private System.Windows.Forms.GroupBox m_gbGeral;
			private System.Windows.Forms.GroupBox m_gbValorExtenso;
			private System.Windows.Forms.GroupBox m_gbTruncamento;
			private System.Windows.Forms.Label m_lbValor;
			private System.Windows.Forms.TextBox m_txtValor;
			private System.Windows.Forms.TextBox m_txtPrecisao;
			private System.Windows.Forms.Label m_lbPrecisao;
			private System.Windows.Forms.TextBox m_txtRetorno;
			private System.Windows.Forms.Label m_lbRetorno;
			private System.Windows.Forms.Button m_btTruncamento;
		private System.Windows.Forms.Button m_btValorExtenso;
		private System.Windows.Forms.GroupBox m_gbRetorno;
		private System.Windows.Forms.TextBox m_txtRetornoGeral;
		private System.Windows.Forms.TextBox m_txtValorExtenso;
		private System.Windows.Forms.Label m_lbValorExtenso;
		private System.Windows.Forms.TextBox m_txtIdioma;
		private System.Windows.Forms.Label m_lbIdioma;
		private System.Windows.Forms.TextBox m_txtMoeda;
		private System.Windows.Forms.Label m_lbMoeda;
		private System.Windows.Forms.GroupBox m_gbRound;
		private System.Windows.Forms.Button m_btRound;
		private System.Windows.Forms.TextBox m_txtRoundRetorno;
		private System.Windows.Forms.Label m_lbRoundRetorno;
		private System.Windows.Forms.TextBox m_txtRoundDecimals;
		private System.Windows.Forms.Label m_lbRoundDecimals;
		private System.Windows.Forms.TextBox m_txtRoundValor;
		private System.Windows.Forms.Label m_lvRoundValor;
			/// <summary>
			/// Required designer variable.
			/// </summary>
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
			this.m_btValorExtenso = new System.Windows.Forms.Button();
			this.m_gbGeral = new System.Windows.Forms.GroupBox();
			this.m_gbRound = new System.Windows.Forms.GroupBox();
			this.m_btRound = new System.Windows.Forms.Button();
			this.m_txtRoundRetorno = new System.Windows.Forms.TextBox();
			this.m_lbRoundRetorno = new System.Windows.Forms.Label();
			this.m_txtRoundDecimals = new System.Windows.Forms.TextBox();
			this.m_lbRoundDecimals = new System.Windows.Forms.Label();
			this.m_txtRoundValor = new System.Windows.Forms.TextBox();
			this.m_lvRoundValor = new System.Windows.Forms.Label();
			this.m_gbTruncamento = new System.Windows.Forms.GroupBox();
			this.m_btTruncamento = new System.Windows.Forms.Button();
			this.m_txtRetorno = new System.Windows.Forms.TextBox();
			this.m_lbRetorno = new System.Windows.Forms.Label();
			this.m_txtPrecisao = new System.Windows.Forms.TextBox();
			this.m_lbPrecisao = new System.Windows.Forms.Label();
			this.m_txtValor = new System.Windows.Forms.TextBox();
			this.m_lbValor = new System.Windows.Forms.Label();
			this.m_gbValorExtenso = new System.Windows.Forms.GroupBox();
			this.m_txtMoeda = new System.Windows.Forms.TextBox();
			this.m_lbMoeda = new System.Windows.Forms.Label();
			this.m_txtIdioma = new System.Windows.Forms.TextBox();
			this.m_lbIdioma = new System.Windows.Forms.Label();
			this.m_txtValorExtenso = new System.Windows.Forms.TextBox();
			this.m_lbValorExtenso = new System.Windows.Forms.Label();
			this.m_gbRetorno = new System.Windows.Forms.GroupBox();
			this.m_txtRetornoGeral = new System.Windows.Forms.TextBox();
			this.m_gbGeral.SuspendLayout();
			this.m_gbRound.SuspendLayout();
			this.m_gbTruncamento.SuspendLayout();
			this.m_gbValorExtenso.SuspendLayout();
			this.m_gbRetorno.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_btValorExtenso
			// 
			this.m_btValorExtenso.Location = new System.Drawing.Point(11, 136);
			this.m_btValorExtenso.Name = "m_btValorExtenso";
			this.m_btValorExtenso.Size = new System.Drawing.Size(88, 23);
			this.m_btValorExtenso.TabIndex = 0;
			this.m_btValorExtenso.Text = "Valor Extenso";
			this.m_btValorExtenso.Click += new System.EventHandler(this.button1_Click);
			// 
			// m_gbGeral
			// 
			this.m_gbGeral.Controls.Add(this.m_gbRound);
			this.m_gbGeral.Controls.Add(this.m_gbTruncamento);
			this.m_gbGeral.Controls.Add(this.m_gbValorExtenso);
			this.m_gbGeral.Location = new System.Drawing.Point(4, -1);
			this.m_gbGeral.Name = "m_gbGeral";
			this.m_gbGeral.Size = new System.Drawing.Size(540, 329);
			this.m_gbGeral.TabIndex = 2;
			this.m_gbGeral.TabStop = false;
			// 
			// m_gbRound
			// 
			this.m_gbRound.Controls.Add(this.m_btRound);
			this.m_gbRound.Controls.Add(this.m_txtRoundRetorno);
			this.m_gbRound.Controls.Add(this.m_lbRoundRetorno);
			this.m_gbRound.Controls.Add(this.m_txtRoundDecimals);
			this.m_gbRound.Controls.Add(this.m_lbRoundDecimals);
			this.m_gbRound.Controls.Add(this.m_txtRoundValor);
			this.m_gbRound.Controls.Add(this.m_lvRoundValor);
			this.m_gbRound.Location = new System.Drawing.Point(193, 184);
			this.m_gbRound.Name = "m_gbRound";
			this.m_gbRound.Size = new System.Drawing.Size(191, 136);
			this.m_gbRound.TabIndex = 4;
			this.m_gbRound.TabStop = false;
			this.m_gbRound.Text = "Round";
			// 
			// m_btRound
			// 
			this.m_btRound.Location = new System.Drawing.Point(60, 64);
			this.m_btRound.Name = "m_btRound";
			this.m_btRound.TabIndex = 13;
			this.m_btRound.Text = "Round";
			this.m_btRound.Click += new System.EventHandler(this.m_btRound_Click);
			// 
			// m_txtRoundRetorno
			// 
			this.m_txtRoundRetorno.Location = new System.Drawing.Point(58, 96);
			this.m_txtRoundRetorno.Name = "m_txtRoundRetorno";
			this.m_txtRoundRetorno.Size = new System.Drawing.Size(112, 20);
			this.m_txtRoundRetorno.TabIndex = 12;
			this.m_txtRoundRetorno.Text = "";
			// 
			// m_lbRoundRetorno
			// 
			this.m_lbRoundRetorno.Location = new System.Drawing.Point(10, 102);
			this.m_lbRoundRetorno.Name = "m_lbRoundRetorno";
			this.m_lbRoundRetorno.Size = new System.Drawing.Size(53, 16);
			this.m_lbRoundRetorno.TabIndex = 11;
			this.m_lbRoundRetorno.Text = "Retorno:";
			// 
			// m_txtRoundDecimals
			// 
			this.m_txtRoundDecimals.Location = new System.Drawing.Point(58, 40);
			this.m_txtRoundDecimals.Name = "m_txtRoundDecimals";
			this.m_txtRoundDecimals.Size = new System.Drawing.Size(112, 20);
			this.m_txtRoundDecimals.TabIndex = 10;
			this.m_txtRoundDecimals.Text = "5";
			// 
			// m_lbRoundDecimals
			// 
			this.m_lbRoundDecimals.Location = new System.Drawing.Point(7, 48);
			this.m_lbRoundDecimals.Name = "m_lbRoundDecimals";
			this.m_lbRoundDecimals.Size = new System.Drawing.Size(56, 16);
			this.m_lbRoundDecimals.TabIndex = 9;
			this.m_lbRoundDecimals.Text = "Decimals:";
			// 
			// m_txtRoundValor
			// 
			this.m_txtRoundValor.Location = new System.Drawing.Point(57, 16);
			this.m_txtRoundValor.Name = "m_txtRoundValor";
			this.m_txtRoundValor.Size = new System.Drawing.Size(112, 20);
			this.m_txtRoundValor.TabIndex = 8;
			this.m_txtRoundValor.Text = "123,123456789";
			// 
			// m_lvRoundValor
			// 
			this.m_lvRoundValor.Location = new System.Drawing.Point(10, 24);
			this.m_lvRoundValor.Name = "m_lvRoundValor";
			this.m_lvRoundValor.Size = new System.Drawing.Size(40, 16);
			this.m_lvRoundValor.TabIndex = 7;
			this.m_lvRoundValor.Text = "Valor:";
			// 
			// m_gbTruncamento
			// 
			this.m_gbTruncamento.Controls.Add(this.m_btTruncamento);
			this.m_gbTruncamento.Controls.Add(this.m_txtRetorno);
			this.m_gbTruncamento.Controls.Add(this.m_lbRetorno);
			this.m_gbTruncamento.Controls.Add(this.m_txtPrecisao);
			this.m_gbTruncamento.Controls.Add(this.m_lbPrecisao);
			this.m_gbTruncamento.Controls.Add(this.m_txtValor);
			this.m_gbTruncamento.Controls.Add(this.m_lbValor);
			this.m_gbTruncamento.Location = new System.Drawing.Point(8, 184);
			this.m_gbTruncamento.Name = "m_gbTruncamento";
			this.m_gbTruncamento.Size = new System.Drawing.Size(184, 136);
			this.m_gbTruncamento.TabIndex = 3;
			this.m_gbTruncamento.TabStop = false;
			this.m_gbTruncamento.Text = "Truncamento";
			// 
			// m_btTruncamento
			// 
			this.m_btTruncamento.Location = new System.Drawing.Point(61, 68);
			this.m_btTruncamento.Name = "m_btTruncamento";
			this.m_btTruncamento.TabIndex = 6;
			this.m_btTruncamento.Text = "Trunc";
			this.m_btTruncamento.Click += new System.EventHandler(this.m_btTruncamento_Click);
			// 
			// m_txtRetorno
			// 
			this.m_txtRetorno.Location = new System.Drawing.Point(59, 96);
			this.m_txtRetorno.Name = "m_txtRetorno";
			this.m_txtRetorno.Size = new System.Drawing.Size(112, 20);
			this.m_txtRetorno.TabIndex = 5;
			this.m_txtRetorno.Text = "";
			// 
			// m_lbRetorno
			// 
			this.m_lbRetorno.Location = new System.Drawing.Point(11, 104);
			this.m_lbRetorno.Name = "m_lbRetorno";
			this.m_lbRetorno.Size = new System.Drawing.Size(53, 16);
			this.m_lbRetorno.TabIndex = 4;
			this.m_lbRetorno.Text = "Retorno:";
			// 
			// m_txtPrecisao
			// 
			this.m_txtPrecisao.Location = new System.Drawing.Point(59, 44);
			this.m_txtPrecisao.Name = "m_txtPrecisao";
			this.m_txtPrecisao.Size = new System.Drawing.Size(112, 20);
			this.m_txtPrecisao.TabIndex = 3;
			this.m_txtPrecisao.Text = "0,001";
			// 
			// m_lbPrecisao
			// 
			this.m_lbPrecisao.Location = new System.Drawing.Point(8, 48);
			this.m_lbPrecisao.Name = "m_lbPrecisao";
			this.m_lbPrecisao.Size = new System.Drawing.Size(56, 16);
			this.m_lbPrecisao.TabIndex = 2;
			this.m_lbPrecisao.Text = "Precisao:";
			// 
			// m_txtValor
			// 
			this.m_txtValor.Location = new System.Drawing.Point(58, 20);
			this.m_txtValor.Name = "m_txtValor";
			this.m_txtValor.Size = new System.Drawing.Size(112, 20);
			this.m_txtValor.TabIndex = 1;
			this.m_txtValor.Text = "214,70000006";
			// 
			// m_lbValor
			// 
			this.m_lbValor.Location = new System.Drawing.Point(11, 23);
			this.m_lbValor.Name = "m_lbValor";
			this.m_lbValor.Size = new System.Drawing.Size(40, 16);
			this.m_lbValor.TabIndex = 0;
			this.m_lbValor.Text = "Valor:";
			// 
			// m_gbValorExtenso
			// 
			this.m_gbValorExtenso.Controls.Add(this.m_txtMoeda);
			this.m_gbValorExtenso.Controls.Add(this.m_lbMoeda);
			this.m_gbValorExtenso.Controls.Add(this.m_txtIdioma);
			this.m_gbValorExtenso.Controls.Add(this.m_lbIdioma);
			this.m_gbValorExtenso.Controls.Add(this.m_txtValorExtenso);
			this.m_gbValorExtenso.Controls.Add(this.m_lbValorExtenso);
			this.m_gbValorExtenso.Controls.Add(this.m_btValorExtenso);
			this.m_gbValorExtenso.Location = new System.Drawing.Point(8, 7);
			this.m_gbValorExtenso.Name = "m_gbValorExtenso";
			this.m_gbValorExtenso.Size = new System.Drawing.Size(520, 169);
			this.m_gbValorExtenso.TabIndex = 2;
			this.m_gbValorExtenso.TabStop = false;
			this.m_gbValorExtenso.Text = "Conversao Valor Extenso";
			// 
			// m_txtMoeda
			// 
			this.m_txtMoeda.Location = new System.Drawing.Point(56, 64);
			this.m_txtMoeda.Name = "m_txtMoeda";
			this.m_txtMoeda.Size = new System.Drawing.Size(128, 20);
			this.m_txtMoeda.TabIndex = 7;
			this.m_txtMoeda.Text = "28";
			// 
			// m_lbMoeda
			// 
			this.m_lbMoeda.Location = new System.Drawing.Point(8, 68);
			this.m_lbMoeda.Name = "m_lbMoeda";
			this.m_lbMoeda.Size = new System.Drawing.Size(40, 16);
			this.m_lbMoeda.TabIndex = 6;
			this.m_lbMoeda.Text = "Moeda:";
			// 
			// m_txtIdioma
			// 
			this.m_txtIdioma.Location = new System.Drawing.Point(56, 40);
			this.m_txtIdioma.Name = "m_txtIdioma";
			this.m_txtIdioma.Size = new System.Drawing.Size(128, 20);
			this.m_txtIdioma.TabIndex = 5;
			this.m_txtIdioma.Text = "pt-BR";
			// 
			// m_lbIdioma
			// 
			this.m_lbIdioma.Location = new System.Drawing.Point(8, 43);
			this.m_lbIdioma.Name = "m_lbIdioma";
			this.m_lbIdioma.Size = new System.Drawing.Size(40, 16);
			this.m_lbIdioma.TabIndex = 4;
			this.m_lbIdioma.Text = "Idioma:";
			// 
			// m_txtValorExtenso
			// 
			this.m_txtValorExtenso.Location = new System.Drawing.Point(56, 16);
			this.m_txtValorExtenso.Name = "m_txtValorExtenso";
			this.m_txtValorExtenso.Size = new System.Drawing.Size(128, 20);
			this.m_txtValorExtenso.TabIndex = 3;
			this.m_txtValorExtenso.Text = "18.164,11";
			// 
			// m_lbValorExtenso
			// 
			this.m_lbValorExtenso.Location = new System.Drawing.Point(8, 19);
			this.m_lbValorExtenso.Name = "m_lbValorExtenso";
			this.m_lbValorExtenso.Size = new System.Drawing.Size(40, 16);
			this.m_lbValorExtenso.TabIndex = 2;
			this.m_lbValorExtenso.Text = "Valor:";
			// 
			// m_gbRetorno
			// 
			this.m_gbRetorno.Controls.Add(this.m_txtRetornoGeral);
			this.m_gbRetorno.Location = new System.Drawing.Point(8, 336);
			this.m_gbRetorno.Name = "m_gbRetorno";
			this.m_gbRetorno.Size = new System.Drawing.Size(536, 184);
			this.m_gbRetorno.TabIndex = 3;
			this.m_gbRetorno.TabStop = false;
			this.m_gbRetorno.Text = "Retorno";
			// 
			// m_txtRetornoGeral
			// 
			this.m_txtRetornoGeral.Location = new System.Drawing.Point(16, 16);
			this.m_txtRetornoGeral.Multiline = true;
			this.m_txtRetornoGeral.Name = "m_txtRetornoGeral";
			this.m_txtRetornoGeral.Size = new System.Drawing.Size(512, 160);
			this.m_txtRetornoGeral.TabIndex = 0;
			this.m_txtRetornoGeral.Text = "";
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(552, 526);
			this.Controls.Add(this.m_gbRetorno);
			this.Controls.Add(this.m_gbGeral);
			this.Name = "Form1";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Conversao";
			this.m_gbGeral.ResumeLayout(false);
			this.m_gbRound.ResumeLayout(false);
			this.m_gbTruncamento.ResumeLayout(false);
			this.m_gbValorExtenso.ResumeLayout(false);
			this.m_gbRetorno.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Converte Valor Extenso 
			private void button1_Click(object sender, System.EventArgs e)
			{
				m_txtRetornoGeral.Text = mdlConversao.clsValorExtenso.strRetornaValorExtenso(double.Parse(m_txtValorExtenso.Text),m_txtIdioma.Text,Int32.Parse(m_txtMoeda.Text));
			}
		#endregion

		#region Truncamento
			private void m_btTruncamento_Click(object sender, System.EventArgs e)
			{
				m_txtRetorno.Text = mdlConversao.clsTruncamento.dTrunca(double.Parse(m_txtValor.Text),double.Parse(m_txtPrecisao.Text)).ToString();
			}
		#endregion
		#region Round
			private void m_btRound_Click(object sender, System.EventArgs e)
			{
				m_txtRoundRetorno.Text = mdlConversao.clsTruncamento.dRound(double.Parse(m_txtRoundValor.Text),Int32.Parse(m_txtRoundDecimals.Text)).ToString();
			}
		#endregion
	}
}
