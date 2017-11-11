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
			private mdlTratamentoErro.clsTratamentoErro	m_cls_ter_TratadorErro = new mdlTratamentoErro.clsTratamentoErro();
			private System.Windows.Forms.GroupBox m_gbGeral;
			private System.Windows.Forms.Label m_lbEnderecoExecutavel;
			private System.Windows.Forms.TextBox m_txtEnderecoExecutavel;
			private System.Windows.Forms.Button m_bDataBaseConfigurated;
			private System.Windows.Forms.TextBox m_txtRetorno;
			private System.Windows.Forms.Label m_lbRetorno;
			private System.Windows.Forms.Button m_bDataBaseConfiguratedRight;
		private System.Windows.Forms.Button m_btReturnDataBaseAccess;
		private System.Windows.Forms.Button m_btShowDataBaseConfig;
			private System.ComponentModel.Container components = null;
		#endregion
		#region Constructors and Destructors
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
			this.m_gbGeral = new System.Windows.Forms.GroupBox();
			this.m_btReturnDataBaseAccess = new System.Windows.Forms.Button();
			this.m_btShowDataBaseConfig = new System.Windows.Forms.Button();
			this.m_bDataBaseConfiguratedRight = new System.Windows.Forms.Button();
			this.m_txtRetorno = new System.Windows.Forms.TextBox();
			this.m_lbRetorno = new System.Windows.Forms.Label();
			this.m_bDataBaseConfigurated = new System.Windows.Forms.Button();
			this.m_txtEnderecoExecutavel = new System.Windows.Forms.TextBox();
			this.m_lbEnderecoExecutavel = new System.Windows.Forms.Label();
			this.m_gbGeral.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_gbGeral
			// 
			this.m_gbGeral.Controls.Add(this.m_btReturnDataBaseAccess);
			this.m_gbGeral.Controls.Add(this.m_btShowDataBaseConfig);
			this.m_gbGeral.Controls.Add(this.m_bDataBaseConfiguratedRight);
			this.m_gbGeral.Controls.Add(this.m_txtRetorno);
			this.m_gbGeral.Controls.Add(this.m_lbRetorno);
			this.m_gbGeral.Controls.Add(this.m_bDataBaseConfigurated);
			this.m_gbGeral.Controls.Add(this.m_txtEnderecoExecutavel);
			this.m_gbGeral.Controls.Add(this.m_lbEnderecoExecutavel);
			this.m_gbGeral.Location = new System.Drawing.Point(3, 0);
			this.m_gbGeral.Name = "m_gbGeral";
			this.m_gbGeral.Size = new System.Drawing.Size(565, 128);
			this.m_gbGeral.TabIndex = 0;
			this.m_gbGeral.TabStop = false;
			// 
			// m_btReturnDataBaseAccess
			// 
			this.m_btReturnDataBaseAccess.Location = new System.Drawing.Point(424, 48);
			this.m_btReturnDataBaseAccess.Name = "m_btReturnDataBaseAccess";
			this.m_btReturnDataBaseAccess.Size = new System.Drawing.Size(128, 32);
			this.m_btReturnDataBaseAccess.TabIndex = 7;
			this.m_btReturnDataBaseAccess.Text = "Return";
			this.m_btReturnDataBaseAccess.Click += new System.EventHandler(this.m_btReturnDataBaseAccess_Click);
			// 
			// m_btShowDataBaseConfig
			// 
			this.m_btShowDataBaseConfig.Location = new System.Drawing.Point(288, 48);
			this.m_btShowDataBaseConfig.Name = "m_btShowDataBaseConfig";
			this.m_btShowDataBaseConfig.Size = new System.Drawing.Size(128, 32);
			this.m_btShowDataBaseConfig.TabIndex = 6;
			this.m_btShowDataBaseConfig.Text = "ShowDataBaseConfig";
			this.m_btShowDataBaseConfig.Click += new System.EventHandler(this.m_btDataBaseConfigurate_Click);
			// 
			// m_bDataBaseConfiguratedRight
			// 
			this.m_bDataBaseConfiguratedRight.Location = new System.Drawing.Point(151, 48);
			this.m_bDataBaseConfiguratedRight.Name = "m_bDataBaseConfiguratedRight";
			this.m_bDataBaseConfiguratedRight.Size = new System.Drawing.Size(128, 32);
			this.m_bDataBaseConfiguratedRight.TabIndex = 5;
			this.m_bDataBaseConfiguratedRight.Text = "ConfiguratedRight";
			this.m_bDataBaseConfiguratedRight.Click += new System.EventHandler(this.m_bDataBaseConfiguratedRight_Click);
			// 
			// m_txtRetorno
			// 
			this.m_txtRetorno.Location = new System.Drawing.Point(88, 96);
			this.m_txtRetorno.Name = "m_txtRetorno";
			this.m_txtRetorno.Size = new System.Drawing.Size(467, 20);
			this.m_txtRetorno.TabIndex = 4;
			this.m_txtRetorno.Text = "";
			// 
			// m_lbRetorno
			// 
			this.m_lbRetorno.Location = new System.Drawing.Point(32, 104);
			this.m_lbRetorno.Name = "m_lbRetorno";
			this.m_lbRetorno.Size = new System.Drawing.Size(48, 16);
			this.m_lbRetorno.TabIndex = 3;
			this.m_lbRetorno.Text = "Retorno:";
			// 
			// m_bDataBaseConfigurated
			// 
			this.m_bDataBaseConfigurated.Location = new System.Drawing.Point(16, 48);
			this.m_bDataBaseConfigurated.Name = "m_bDataBaseConfigurated";
			this.m_bDataBaseConfigurated.Size = new System.Drawing.Size(128, 32);
			this.m_bDataBaseConfigurated.TabIndex = 2;
			this.m_bDataBaseConfigurated.Text = "Configurated";
			this.m_bDataBaseConfigurated.Click += new System.EventHandler(this.m_bDataBaseConfigurated_Click);
			// 
			// m_txtEnderecoExecutavel
			// 
			this.m_txtEnderecoExecutavel.Location = new System.Drawing.Point(121, 12);
			this.m_txtEnderecoExecutavel.Name = "m_txtEnderecoExecutavel";
			this.m_txtEnderecoExecutavel.Size = new System.Drawing.Size(431, 20);
			this.m_txtEnderecoExecutavel.TabIndex = 1;
			this.m_txtEnderecoExecutavel.Text = "F:\\Projetos\\Siscobras\\Binarios\\";
			// 
			// m_lbEnderecoExecutavel
			// 
			this.m_lbEnderecoExecutavel.Location = new System.Drawing.Point(9, 15);
			this.m_lbEnderecoExecutavel.Name = "m_lbEnderecoExecutavel";
			this.m_lbEnderecoExecutavel.Size = new System.Drawing.Size(119, 16);
			this.m_lbEnderecoExecutavel.TabIndex = 0;
			this.m_lbEnderecoExecutavel.Text = "Endereco Executavel:";
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(578, 136);
			this.Controls.Add(this.m_gbGeral);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "Form1";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Data Base Config";
			this.m_gbGeral.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Negocio
			private void m_bDataBaseConfigurated_Click(object sender, System.EventArgs e)
			{
				mdlDataBaseConfig.clsDataBaseConfig	obj = new mdlDataBaseConfig.clsDataBaseConfig(ref m_cls_ter_TratadorErro,m_txtEnderecoExecutavel.Text);
				m_txtRetorno.Text = obj.bDataBaseConfigurated().ToString();
			}

			private void m_bDataBaseConfiguratedRight_Click(object sender, System.EventArgs e)
			{
				mdlDataBaseConfig.clsDataBaseConfig	obj = new mdlDataBaseConfig.clsDataBaseConfig(ref m_cls_ter_TratadorErro,m_txtEnderecoExecutavel.Text);
				m_txtRetorno.Text = obj.bDataBaseConfiguratedRight().ToString();
			}

			private void m_btDataBaseConfigurate_Click(object sender, System.EventArgs e)
			{
				mdlDataBaseConfig.clsDataBaseConfig	obj = new mdlDataBaseConfig.clsDataBaseConfig(ref m_cls_ter_TratadorErro,m_txtEnderecoExecutavel.Text);
				m_txtRetorno.Text = obj.ShowDataBaseConfig().ToString();
			}

			private void m_btReturnDataBaseAccess_Click(object sender, System.EventArgs e)
			{
				mdlDataBaseConfig.clsDataBaseConfig	obj = new mdlDataBaseConfig.clsDataBaseConfig(ref m_cls_ter_TratadorErro,m_txtEnderecoExecutavel.Text);
				mdlDataBaseAccess.clsDataBaseAccess m_cls_dba_Connection;
				obj.ReturnDataBaseAccess(out m_cls_dba_Connection);
				m_txtRetorno.Text = m_cls_dba_Connection.ToString();
			}
		#endregion
	}
}
