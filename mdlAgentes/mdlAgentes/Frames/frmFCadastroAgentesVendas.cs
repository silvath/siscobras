using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace mdlAgentes.Frames
{
	/// <summary>
	/// Summary description for frmFCadastroAgentesVendas.
	/// </summary>
	internal class frmFCadastroAgentesVendas : mdlComponentesGraficos.FormFlutuante
	{
		#region Atributos
		protected mdlTratamentoErro.clsTratamentoErro m_cls_ter_tratadorErro;
		protected string m_strEnderecoExecutavel;

		public bool m_bModificado = false;

		private bool m_bCadastroNovo = false;

		private System.Windows.Forms.GroupBox m_gbFrame;
		private System.Windows.Forms.GroupBox m_gbFields;
		private System.Windows.Forms.Label m_lNomeAgente;
		private System.Windows.Forms.Label m_lEndereco;
		private System.Windows.Forms.Label m_lCidade;
		private System.Windows.Forms.Label m_lPais;
		private mdlComponentesGraficos.TextBox m_tbNomeAgente;
		private mdlComponentesGraficos.TextBox m_tbEndereco;
		private mdlComponentesGraficos.TextBox m_tbCidade;
		private mdlComponentesGraficos.ComboBox m_cbPaises;
		private System.Windows.Forms.Button m_btOk;
		private System.Windows.Forms.Button m_btCancelar;
		private mdlComponentesGraficos.TextBox m_tbSite;
		private mdlComponentesGraficos.TextBox m_tbEmail;
		private System.Windows.Forms.Label m_lSite;
		private System.Windows.Forms.Label m_lEmail;
		private System.Windows.Forms.ToolTip m_ttCadastroAgenteVenda;
		private System.ComponentModel.IContainer components;
		#endregion

		#region Construtores & Destrutores
		public frmFCadastroAgentesVendas(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, string EnderecoExecutavel, bool bCadastroNovo)
		{
			InitializeComponent();

			m_cls_ter_tratadorErro = tratadorErro;
			m_strEnderecoExecutavel = EnderecoExecutavel;
			m_bCadastroNovo = bCadastroNovo;
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}
		#endregion

		#region Delegate
		public delegate void delCallCarregaDadosInterface(ref mdlComponentesGraficos.TextBox tbNome, ref mdlComponentesGraficos.TextBox tbEndereco, ref mdlComponentesGraficos.TextBox tbCidade, ref mdlComponentesGraficos.ComboBox cbPais, ref mdlComponentesGraficos.TextBox tbEmail, ref mdlComponentesGraficos.TextBox tbSite);
		public delegate void delCallSalvaDadosInterface(ref mdlComponentesGraficos.TextBox tbNome, ref mdlComponentesGraficos.TextBox tbEndereco, ref mdlComponentesGraficos.TextBox tbCidade, ref mdlComponentesGraficos.ComboBox cbPais, ref mdlComponentesGraficos.TextBox tbEmail, ref mdlComponentesGraficos.TextBox tbSite);
		public delegate void delCallSalvaDadosBD(bool bModificado);
		#endregion
		#region Events
		public event delCallCarregaDadosInterface eCallCarregaDadosInterface;
		public event delCallSalvaDadosInterface eCallSalvaDadosInterface;
		public event delCallSalvaDadosBD eCallSalvaDadosBD;
		#endregion
		#region Events Methods
		protected virtual void OnCallCarregaDadosInterface()
		{
			if (eCallCarregaDadosInterface != null)
				eCallCarregaDadosInterface(ref m_tbNomeAgente, ref m_tbEndereco, ref m_tbCidade, ref m_cbPaises, ref m_tbEmail, ref m_tbSite);
		}
		protected virtual void OnCallSalvaDadosInterface()
		{
			if (eCallSalvaDadosInterface != null)
				eCallSalvaDadosInterface(ref m_tbNomeAgente, ref m_tbEndereco, ref m_tbCidade, ref m_cbPaises, ref m_tbEmail, ref m_tbSite);
		}
		protected virtual void OnCallSalvaDadosBD()
		{
			if (eCallSalvaDadosBD != null)
				eCallSalvaDadosBD(m_bModificado);
		}
		#endregion

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmFCadastroAgentesVendas));
			this.m_gbFrame = new System.Windows.Forms.GroupBox();
			this.m_btOk = new System.Windows.Forms.Button();
			this.m_btCancelar = new System.Windows.Forms.Button();
			this.m_gbFields = new System.Windows.Forms.GroupBox();
			this.m_tbSite = new mdlComponentesGraficos.TextBox();
			this.m_tbEmail = new mdlComponentesGraficos.TextBox();
			this.m_lSite = new System.Windows.Forms.Label();
			this.m_lEmail = new System.Windows.Forms.Label();
			this.m_cbPaises = new mdlComponentesGraficos.ComboBox();
			this.m_tbCidade = new mdlComponentesGraficos.TextBox();
			this.m_tbEndereco = new mdlComponentesGraficos.TextBox();
			this.m_tbNomeAgente = new mdlComponentesGraficos.TextBox();
			this.m_lPais = new System.Windows.Forms.Label();
			this.m_lCidade = new System.Windows.Forms.Label();
			this.m_lEndereco = new System.Windows.Forms.Label();
			this.m_lNomeAgente = new System.Windows.Forms.Label();
			this.m_ttCadastroAgenteVenda = new System.Windows.Forms.ToolTip(this.components);
			this.m_gbFrame.SuspendLayout();
			this.m_gbFields.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_gbFrame
			// 
			this.m_gbFrame.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_gbFrame.Controls.Add(this.m_btOk);
			this.m_gbFrame.Controls.Add(this.m_btCancelar);
			this.m_gbFrame.Controls.Add(this.m_gbFields);
			this.m_gbFrame.Location = new System.Drawing.Point(2, 0);
			this.m_gbFrame.Name = "m_gbFrame";
			this.m_gbFrame.Size = new System.Drawing.Size(230, 209);
			this.m_gbFrame.TabIndex = 0;
			this.m_gbFrame.TabStop = false;
			// 
			// m_btOk
			// 
			this.m_btOk.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.m_btOk.BackColor = System.Drawing.SystemColors.Control;
			this.m_btOk.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btOk.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btOk.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btOk.Image = ((System.Drawing.Image)(resources.GetObject("m_btOk.Image")));
			this.m_btOk.Location = new System.Drawing.Point(55, 178);
			this.m_btOk.Name = "m_btOk";
			this.m_btOk.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btOk.Size = new System.Drawing.Size(57, 25);
			this.m_btOk.TabIndex = 5;
			this.m_ttCadastroAgenteVenda.SetToolTip(this.m_btOk, "Confirmar");
			this.m_btOk.Click += new System.EventHandler(this.m_btOk_Click);
			// 
			// m_btCancelar
			// 
			this.m_btCancelar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.m_btCancelar.BackColor = System.Drawing.SystemColors.Control;
			this.m_btCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btCancelar.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btCancelar.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btCancelar.Image = ((System.Drawing.Image)(resources.GetObject("m_btCancelar.Image")));
			this.m_btCancelar.Location = new System.Drawing.Point(119, 178);
			this.m_btCancelar.Name = "m_btCancelar";
			this.m_btCancelar.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btCancelar.Size = new System.Drawing.Size(57, 25);
			this.m_btCancelar.TabIndex = 6;
			this.m_ttCadastroAgenteVenda.SetToolTip(this.m_btCancelar, "Cancelar");
			this.m_btCancelar.Click += new System.EventHandler(this.m_btCancelar_Click);
			// 
			// m_gbFields
			// 
			this.m_gbFields.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_gbFields.Controls.Add(this.m_tbSite);
			this.m_gbFields.Controls.Add(this.m_tbEmail);
			this.m_gbFields.Controls.Add(this.m_lSite);
			this.m_gbFields.Controls.Add(this.m_lEmail);
			this.m_gbFields.Controls.Add(this.m_cbPaises);
			this.m_gbFields.Controls.Add(this.m_tbCidade);
			this.m_gbFields.Controls.Add(this.m_tbEndereco);
			this.m_gbFields.Controls.Add(this.m_tbNomeAgente);
			this.m_gbFields.Controls.Add(this.m_lPais);
			this.m_gbFields.Controls.Add(this.m_lCidade);
			this.m_gbFields.Controls.Add(this.m_lEndereco);
			this.m_gbFields.Controls.Add(this.m_lNomeAgente);
			this.m_gbFields.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_gbFields.Location = new System.Drawing.Point(8, 8);
			this.m_gbFields.Name = "m_gbFields";
			this.m_gbFields.Size = new System.Drawing.Size(214, 165);
			this.m_gbFields.TabIndex = 0;
			this.m_gbFields.TabStop = false;
			this.m_gbFields.Text = "Cadastro / Edição";
			// 
			// m_tbSite
			// 
			this.m_tbSite.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_tbSite.Location = new System.Drawing.Point(67, 138);
			this.m_tbSite.Name = "m_tbSite";
			this.m_tbSite.Size = new System.Drawing.Size(139, 20);
			this.m_tbSite.TabIndex = 13;
			this.m_tbSite.Text = "";
			// 
			// m_tbEmail
			// 
			this.m_tbEmail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_tbEmail.Location = new System.Drawing.Point(67, 114);
			this.m_tbEmail.Name = "m_tbEmail";
			this.m_tbEmail.Size = new System.Drawing.Size(139, 20);
			this.m_tbEmail.TabIndex = 12;
			this.m_tbEmail.Text = "";
			// 
			// m_lSite
			// 
			this.m_lSite.Location = new System.Drawing.Point(8, 141);
			this.m_lSite.Name = "m_lSite";
			this.m_lSite.Size = new System.Drawing.Size(32, 16);
			this.m_lSite.TabIndex = 11;
			this.m_lSite.Text = "Site:";
			this.m_lSite.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// m_lEmail
			// 
			this.m_lEmail.Location = new System.Drawing.Point(8, 117);
			this.m_lEmail.Name = "m_lEmail";
			this.m_lEmail.Size = new System.Drawing.Size(40, 16);
			this.m_lEmail.TabIndex = 10;
			this.m_lEmail.Text = "E-mail:";
			this.m_lEmail.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// m_cbPaises
			// 
			this.m_cbPaises.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_cbPaises.AutoCompleteCaseSensitive = false;
			this.m_cbPaises.GoToNextControlWithEnter = true;
			this.m_cbPaises.Location = new System.Drawing.Point(67, 89);
			this.m_cbPaises.Name = "m_cbPaises";
			this.m_cbPaises.Size = new System.Drawing.Size(139, 22);
			this.m_cbPaises.TabIndex = 9;
			this.m_ttCadastroAgenteVenda.SetToolTip(this.m_cbPaises, "Selecione o país");
			// 
			// m_tbCidade
			// 
			this.m_tbCidade.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_tbCidade.Location = new System.Drawing.Point(67, 65);
			this.m_tbCidade.Name = "m_tbCidade";
			this.m_tbCidade.Size = new System.Drawing.Size(139, 20);
			this.m_tbCidade.TabIndex = 7;
			this.m_tbCidade.Text = "";
			// 
			// m_tbEndereco
			// 
			this.m_tbEndereco.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_tbEndereco.Location = new System.Drawing.Point(67, 41);
			this.m_tbEndereco.Name = "m_tbEndereco";
			this.m_tbEndereco.Size = new System.Drawing.Size(139, 20);
			this.m_tbEndereco.TabIndex = 6;
			this.m_tbEndereco.Text = "";
			// 
			// m_tbNomeAgente
			// 
			this.m_tbNomeAgente.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_tbNomeAgente.Location = new System.Drawing.Point(67, 17);
			this.m_tbNomeAgente.Name = "m_tbNomeAgente";
			this.m_tbNomeAgente.Size = new System.Drawing.Size(139, 20);
			this.m_tbNomeAgente.TabIndex = 5;
			this.m_tbNomeAgente.Text = "";
			// 
			// m_lPais
			// 
			this.m_lPais.Location = new System.Drawing.Point(8, 92);
			this.m_lPais.Name = "m_lPais";
			this.m_lPais.Size = new System.Drawing.Size(30, 16);
			this.m_lPais.TabIndex = 4;
			this.m_lPais.Text = "País:";
			this.m_lPais.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// m_lCidade
			// 
			this.m_lCidade.Location = new System.Drawing.Point(8, 68);
			this.m_lCidade.Name = "m_lCidade";
			this.m_lCidade.Size = new System.Drawing.Size(43, 16);
			this.m_lCidade.TabIndex = 2;
			this.m_lCidade.Text = "Cidade:";
			this.m_lCidade.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// m_lEndereco
			// 
			this.m_lEndereco.Location = new System.Drawing.Point(8, 44);
			this.m_lEndereco.Name = "m_lEndereco";
			this.m_lEndereco.Size = new System.Drawing.Size(56, 16);
			this.m_lEndereco.TabIndex = 1;
			this.m_lEndereco.Text = "Endereço:";
			this.m_lEndereco.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// m_lNomeAgente
			// 
			this.m_lNomeAgente.Location = new System.Drawing.Point(8, 20);
			this.m_lNomeAgente.Name = "m_lNomeAgente";
			this.m_lNomeAgente.Size = new System.Drawing.Size(38, 14);
			this.m_lNomeAgente.TabIndex = 0;
			this.m_lNomeAgente.Text = "Nome:";
			this.m_lNomeAgente.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// m_ttCadastroAgenteVenda
			// 
			this.m_ttCadastroAgenteVenda.AutomaticDelay = 100;
			this.m_ttCadastroAgenteVenda.AutoPopDelay = 5000;
			this.m_ttCadastroAgenteVenda.InitialDelay = 100;
			this.m_ttCadastroAgenteVenda.ReshowDelay = 20;
			// 
			// frmFCadastroAgentesVendas
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(234, 211);
			this.Controls.Add(this.m_gbFrame);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmFCadastroAgentesVendas";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Agente de Venda";
			this.Load += new System.EventHandler(this.frmFCadastroAgentesVendas_Load);
			this.m_gbFrame.ResumeLayout(false);
			this.m_gbFields.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Procedimentos Para Troca de Cor
		/// <summary>
		/// Troca a cor do Formulario Controlado
		/// </summary>
		private void trocaCor()
		{
			try
			{
				mdlPaletaDeCores.clsPaletaDeCores controlPaletaCores = new mdlPaletaDeCores.clsPaletaDeCores(m_strEnderecoExecutavel + "sisco.ini", "SiscobrasCorSecundaria");
				controlPaletaCores.mostraCorAtual();
				mostraCor();
			} 
			catch (Exception erro) 
			{
				Object err = (Object)erro;
				m_cls_ter_tratadorErro.trataErro(ref err);
			}
		}
		/// <summary>
		/// Mostra a cor do Formulario Controlado
		/// </summary>
		private void mostraCor()
		{
			try
			{
				mdlPaletaDeCores.clsPaletaDeCores controlPaletaDeCores = new mdlPaletaDeCores.clsPaletaDeCores(m_strEnderecoExecutavel + "sisco.ini", "SiscobrasCorSecundaria");
				this.BackColor = controlPaletaDeCores.retornaCorAtual();
				for (int cont = 0; cont < this.Controls.Count; cont++) 
				{
					this.Controls[cont].BackColor = this.BackColor;
					for (int cont2 = 0; cont2 < this.Controls[cont].Controls.Count; cont2++)
					{
						if ((this.Controls[cont].Controls[cont2].GetType().ToString() != "System.Windows.Forms.ListView") && (this.Controls[cont].Controls[cont2].GetType().ToString() != "mdlComponentes.compTextNumber"))
						{
							this.Controls[cont].Controls[cont2].BackColor = this.BackColor;
						}
						for (int cont3 = 0; cont3 < this.Controls[cont].Controls[cont2].Controls.Count; cont3++)
						{
							if ((this.Controls[cont].Controls[cont2].Controls[cont3].GetType().ToString() != 
								"mdlComponentesGraficos.TextBox") && (this.Controls[cont].Controls[cont2].Controls[cont3].GetType().ToString() != 
								"mdlComponentesGraficos.ComboBox") ||
								((this.Controls[cont].Controls[cont2].Controls[cont3].Name == "m_lvDadosImportadores") &&
								(this.Controls[cont].Controls[cont2].Controls[cont3].GetType().ToString() == 
								"mdlComponentesGraficos.ListView")))
							{
								this.Controls[cont].Controls[cont2].Controls[cont3].BackColor = this.BackColor;
							}
						}
					}
				}
			} 
			catch (Exception erro) 
			{ 
				Object err = (Object)erro;
				m_cls_ter_tratadorErro.trataErro(ref err);
			}
		}

		#endregion

		#region Get & Set
		public void setTextoGroupBox(string strTexto)
		{
			m_gbFields.Text = strTexto;
		}
		#endregion

		#region Eventos
		#region Load
		private void frmFCadastroAgentesVendas_Load(object sender, System.EventArgs e)
		{
			mostraCor();
			OnCallCarregaDadosInterface();
			if (m_bCadastroNovo == false)
			{
				this.Text = "Edição Agente de Vendas";
			}
			else
			{
				this.Text = "Cadastro Agente de Vendas";
			}
		}
		#endregion
		#region Cancelar
		private void m_btCancelar_Click(object sender, System.EventArgs e)
		{
			m_bModificado = false;
			this.Close();		
		}
		#endregion
		#region Ok
		private void m_btOk_Click(object sender, System.EventArgs e)
		{
			if (m_cbPaises.ReturnObjectSelectedItem() != null)
			{
				if (m_tbNomeAgente.Text.Trim() != "")
				{
					if (m_tbEndereco.Text.Trim() != "")
					{
						m_bModificado = true;
						OnCallSalvaDadosInterface();
						OnCallSalvaDadosBD();
						this.Close();
					}
				}
			}
		}
		#endregion
		#endregion
	}
}
