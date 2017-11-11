using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace mdlProdutosRomaneio
{
	/// <summary>
	/// Summary description for frmFEmbalagemNova.
	/// </summary>
	internal class frmFEmbalagemNova : System.Windows.Forms.Form
	{
		#region Atributes
			private mdlTratamentoErro.clsTratamentoErro m_cls_ter_tratadorErro; 
			private string m_strEnderecoExecutavel;

			System.Collections.ArrayList m_arlEmbalagens = null;

			public bool m_bModificado = false;

			private System.Windows.Forms.GroupBox m_gbGeral;
			internal System.Windows.Forms.Button m_btOk;
			internal System.Windows.Forms.Button m_btCancelar;
			private System.Windows.Forms.RadioButton m_rbNumero;
			internal System.Windows.Forms.Label m_lbInfo;
			internal System.Windows.Forms.Label m_lbIntervalo;
			internal mdlComponentesGraficos.TextBox m_txtIntervalo;
			private System.Windows.Forms.GroupBox m_gbQuantidade;
			private System.Windows.Forms.GroupBox m_gbIntervalo;
			private System.Windows.Forms.RadioButton m_rbIntervalo;
			internal System.Windows.Forms.Label m_lbQuantidade;
			internal mdlComponentesGraficos.TextBox m_txtQuantidade;
			private System.Windows.Forms.ToolTip m_ttDica;
		private System.Windows.Forms.LinkLabel m_llbIntervalos;
		internal mdlComponentesGraficos.TextBox m_txtSufixo;
		internal mdlComponentesGraficos.TextBox m_txtPrefixo;
		internal System.Windows.Forms.Label m_lbPrefixo;
		internal System.Windows.Forms.Label m_lbSufixo;
			private System.ComponentModel.IContainer components;
		#endregion
		#region Delegates
			public delegate System.Collections.ArrayList delCallArlRetornaEmbalagens(int nQuantidadeEmbalagens);
			public delegate bool delCallEmbalagensInexistentes(ref System.Collections.ArrayList arlEmbalagens);
		#endregion
		#region Events
			public event delCallArlRetornaEmbalagens eCallArlRetornaEmbalagens;
			public event delCallEmbalagensInexistentes eCallEmbalagensInexistentes;
		#endregion
		#region Events Methods
			protected virtual System.Collections.ArrayList OnCallArlRetornaEmbalagens(int nQuantidadeEmbalagens)
			{
				System.Collections.ArrayList arlRetorno = null;
				if (eCallArlRetornaEmbalagens != null)
					arlRetorno = eCallArlRetornaEmbalagens(nQuantidadeEmbalagens);
				return(arlRetorno); 
			}

			protected virtual bool  OnCallEmbalagensInexistentes(ref System.Collections.ArrayList arlEmbalagens)
			{
				bool bRetorno = true;
				if (eCallEmbalagensInexistentes != null)
					bRetorno = eCallEmbalagensInexistentes(ref arlEmbalagens);
				return(bRetorno); 
			}
		#endregion
		#region Constructor and Destructors
			public frmFEmbalagemNova(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, string strEnderecoExecutavel)
			{
				m_cls_ter_tratadorErro = tratadorErro;
				m_strEnderecoExecutavel = strEnderecoExecutavel;

				InitializeComponent();
			}

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

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmFEmbalagemNova));
			this.m_gbGeral = new System.Windows.Forms.GroupBox();
			this.m_gbQuantidade = new System.Windows.Forms.GroupBox();
			this.m_lbQuantidade = new System.Windows.Forms.Label();
			this.m_txtQuantidade = new mdlComponentesGraficos.TextBox();
			this.m_rbIntervalo = new System.Windows.Forms.RadioButton();
			this.m_rbNumero = new System.Windows.Forms.RadioButton();
			this.m_btOk = new System.Windows.Forms.Button();
			this.m_btCancelar = new System.Windows.Forms.Button();
			this.m_gbIntervalo = new System.Windows.Forms.GroupBox();
			this.m_txtSufixo = new mdlComponentesGraficos.TextBox();
			this.m_txtPrefixo = new mdlComponentesGraficos.TextBox();
			this.m_lbPrefixo = new System.Windows.Forms.Label();
			this.m_lbSufixo = new System.Windows.Forms.Label();
			this.m_llbIntervalos = new System.Windows.Forms.LinkLabel();
			this.m_lbInfo = new System.Windows.Forms.Label();
			this.m_lbIntervalo = new System.Windows.Forms.Label();
			this.m_txtIntervalo = new mdlComponentesGraficos.TextBox();
			this.m_ttDica = new System.Windows.Forms.ToolTip(this.components);
			this.m_gbGeral.SuspendLayout();
			this.m_gbQuantidade.SuspendLayout();
			this.m_gbIntervalo.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_gbGeral
			// 
			this.m_gbGeral.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_gbGeral.Controls.Add(this.m_gbQuantidade);
			this.m_gbGeral.Controls.Add(this.m_rbIntervalo);
			this.m_gbGeral.Controls.Add(this.m_rbNumero);
			this.m_gbGeral.Controls.Add(this.m_btOk);
			this.m_gbGeral.Controls.Add(this.m_btCancelar);
			this.m_gbGeral.Controls.Add(this.m_gbIntervalo);
			this.m_gbGeral.Location = new System.Drawing.Point(4, 0);
			this.m_gbGeral.Name = "m_gbGeral";
			this.m_gbGeral.Size = new System.Drawing.Size(304, 266);
			this.m_gbGeral.TabIndex = 0;
			this.m_gbGeral.TabStop = false;
			// 
			// m_gbQuantidade
			// 
			this.m_gbQuantidade.Controls.Add(this.m_lbQuantidade);
			this.m_gbQuantidade.Controls.Add(this.m_txtQuantidade);
			this.m_gbQuantidade.Location = new System.Drawing.Point(8, 29);
			this.m_gbQuantidade.Name = "m_gbQuantidade";
			this.m_gbQuantidade.Size = new System.Drawing.Size(288, 40);
			this.m_gbQuantidade.TabIndex = 1;
			this.m_gbQuantidade.TabStop = false;
			// 
			// m_lbQuantidade
			// 
			this.m_lbQuantidade.Location = new System.Drawing.Point(6, 13);
			this.m_lbQuantidade.Name = "m_lbQuantidade";
			this.m_lbQuantidade.Size = new System.Drawing.Size(67, 16);
			this.m_lbQuantidade.TabIndex = 15;
			this.m_lbQuantidade.Text = "Quantidade:";
			// 
			// m_txtQuantidade
			// 
			this.m_txtQuantidade.Location = new System.Drawing.Point(74, 10);
			this.m_txtQuantidade.Name = "m_txtQuantidade";
			this.m_txtQuantidade.Size = new System.Drawing.Size(208, 20);
			this.m_txtQuantidade.TabIndex = 2;
			this.m_txtQuantidade.Text = "";
			// 
			// m_rbIntervalo
			// 
			this.m_rbIntervalo.Location = new System.Drawing.Point(8, 72);
			this.m_rbIntervalo.Name = "m_rbIntervalo";
			this.m_rbIntervalo.Size = new System.Drawing.Size(280, 16);
			this.m_rbIntervalo.TabIndex = 14;
			this.m_rbIntervalo.Text = "Desejo inserir as embalagens  pelo intervalo";
			this.m_rbIntervalo.CheckedChanged += new System.EventHandler(this.m_rbIntervalo_CheckedChanged);
			// 
			// m_rbNumero
			// 
			this.m_rbNumero.Checked = true;
			this.m_rbNumero.Location = new System.Drawing.Point(7, 15);
			this.m_rbNumero.Name = "m_rbNumero";
			this.m_rbNumero.Size = new System.Drawing.Size(280, 16);
			this.m_rbNumero.TabIndex = 13;
			this.m_rbNumero.TabStop = true;
			this.m_rbNumero.Text = "Desejo inserir as embalagens  pela quantidade";
			this.m_rbNumero.CheckedChanged += new System.EventHandler(this.m_rbNumero_CheckedChanged);
			// 
			// m_btOk
			// 
			this.m_btOk.BackColor = System.Drawing.SystemColors.Control;
			this.m_btOk.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btOk.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btOk.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btOk.Image = ((System.Drawing.Image)(resources.GetObject("m_btOk.Image")));
			this.m_btOk.Location = new System.Drawing.Point(89, 235);
			this.m_btOk.Name = "m_btOk";
			this.m_btOk.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btOk.Size = new System.Drawing.Size(57, 25);
			this.m_btOk.TabIndex = 5;
			this.m_ttDica.SetToolTip(this.m_btOk, "Confirmar");
			this.m_btOk.Click += new System.EventHandler(this.m_btOk_Click);
			// 
			// m_btCancelar
			// 
			this.m_btCancelar.BackColor = System.Drawing.SystemColors.Control;
			this.m_btCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btCancelar.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btCancelar.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btCancelar.Image = ((System.Drawing.Image)(resources.GetObject("m_btCancelar.Image")));
			this.m_btCancelar.Location = new System.Drawing.Point(153, 235);
			this.m_btCancelar.Name = "m_btCancelar";
			this.m_btCancelar.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btCancelar.Size = new System.Drawing.Size(57, 25);
			this.m_btCancelar.TabIndex = 6;
			this.m_ttDica.SetToolTip(this.m_btCancelar, "Cancelar");
			this.m_btCancelar.Click += new System.EventHandler(this.m_btCancelar_Click);
			// 
			// m_gbIntervalo
			// 
			this.m_gbIntervalo.Controls.Add(this.m_txtIntervalo);
			this.m_gbIntervalo.Controls.Add(this.m_txtSufixo);
			this.m_gbIntervalo.Controls.Add(this.m_txtPrefixo);
			this.m_gbIntervalo.Controls.Add(this.m_lbPrefixo);
			this.m_gbIntervalo.Controls.Add(this.m_lbSufixo);
			this.m_gbIntervalo.Controls.Add(this.m_llbIntervalos);
			this.m_gbIntervalo.Controls.Add(this.m_lbInfo);
			this.m_gbIntervalo.Controls.Add(this.m_lbIntervalo);
			this.m_gbIntervalo.Enabled = false;
			this.m_gbIntervalo.Location = new System.Drawing.Point(8, 84);
			this.m_gbIntervalo.Name = "m_gbIntervalo";
			this.m_gbIntervalo.Size = new System.Drawing.Size(288, 148);
			this.m_gbIntervalo.TabIndex = 3;
			this.m_gbIntervalo.TabStop = false;
			// 
			// m_txtSufixo
			// 
			this.m_txtSufixo.Location = new System.Drawing.Point(210, 36);
			this.m_txtSufixo.Name = "m_txtSufixo";
			this.m_txtSufixo.Size = new System.Drawing.Size(72, 20);
			this.m_txtSufixo.TabIndex = 106;
			this.m_txtSufixo.Text = "";
			// 
			// m_txtPrefixo
			// 
			this.m_txtPrefixo.Location = new System.Drawing.Point(74, 35);
			this.m_txtPrefixo.Name = "m_txtPrefixo";
			this.m_txtPrefixo.Size = new System.Drawing.Size(72, 20);
			this.m_txtPrefixo.TabIndex = 104;
			this.m_txtPrefixo.Text = "";
			// 
			// m_lbPrefixo
			// 
			this.m_lbPrefixo.Location = new System.Drawing.Point(20, 38);
			this.m_lbPrefixo.Name = "m_lbPrefixo";
			this.m_lbPrefixo.Size = new System.Drawing.Size(51, 16);
			this.m_lbPrefixo.TabIndex = 105;
			this.m_lbPrefixo.Text = "Prefixo:";
			// 
			// m_lbSufixo
			// 
			this.m_lbSufixo.Location = new System.Drawing.Point(158, 39);
			this.m_lbSufixo.Name = "m_lbSufixo";
			this.m_lbSufixo.Size = new System.Drawing.Size(51, 16);
			this.m_lbSufixo.TabIndex = 107;
			this.m_lbSufixo.Text = "Sufixo:";
			// 
			// m_llbIntervalos
			// 
			this.m_llbIntervalos.Location = new System.Drawing.Point(56, 109);
			this.m_llbIntervalos.Name = "m_llbIntervalos";
			this.m_llbIntervalos.Size = new System.Drawing.Size(198, 27);
			this.m_llbIntervalos.TabIndex = 100;
			this.m_llbIntervalos.TabStop = true;
			this.m_llbIntervalos.Text = "Clique aqui caso não tenha entendido como montar os intervalos.";
			this.m_llbIntervalos.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_llbIntervalos_LinkClicked);
			// 
			// m_lbInfo
			// 
			this.m_lbInfo.ForeColor = System.Drawing.Color.Red;
			this.m_lbInfo.Location = new System.Drawing.Point(31, 62);
			this.m_lbInfo.Name = "m_lbInfo";
			this.m_lbInfo.Size = new System.Drawing.Size(255, 40);
			this.m_lbInfo.TabIndex = 16;
			this.m_lbInfo.Text = "Separe com ponto-e-vírgula os números e/ou  intervalos de embalagens a serem adic" +
				"ionados. Ex.: 1;3;5-12;4";
			// 
			// m_lbIntervalo
			// 
			this.m_lbIntervalo.Location = new System.Drawing.Point(18, 13);
			this.m_lbIntervalo.Name = "m_lbIntervalo";
			this.m_lbIntervalo.Size = new System.Drawing.Size(62, 16);
			this.m_lbIntervalo.TabIndex = 15;
			this.m_lbIntervalo.Text = "Intervalo:";
			// 
			// m_txtIntervalo
			// 
			this.m_txtIntervalo.Location = new System.Drawing.Point(74, 10);
			this.m_txtIntervalo.Name = "m_txtIntervalo";
			this.m_txtIntervalo.Size = new System.Drawing.Size(208, 20);
			this.m_txtIntervalo.TabIndex = 4;
			this.m_txtIntervalo.Text = "";
			// 
			// m_ttDica
			// 
			this.m_ttDica.AutomaticDelay = 100;
			this.m_ttDica.AutoPopDelay = 5000;
			this.m_ttDica.InitialDelay = 100;
			this.m_ttDica.ReshowDelay = 20;
			// 
			// frmFEmbalagemNova
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 13);
			this.ClientSize = new System.Drawing.Size(314, 272);
			this.Controls.Add(this.m_gbGeral);
			this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "frmFEmbalagemNova";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Novas Embalagens";
			this.Load += new System.EventHandler(this.frmFEmbalagemNova_Load);
			this.m_gbGeral.ResumeLayout(false);
			this.m_gbQuantidade.ResumeLayout(false);
			this.m_gbIntervalo.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region ShowDialogInformacoesIntervalo
			private void ShowDialogInformacoesIntervalo()
			{
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				frmFVolumeNovoInformacaoIntervalo formFInformacoesIntervalo = new frmFVolumeNovoInformacaoIntervalo(m_strEnderecoExecutavel);
				formFInformacoesIntervalo.ShowDialog();
				string strInvervalo = "";
				string strPrefixo = "";
				string strSufixo = "";
				formFInformacoesIntervalo.vRetornaValores(out strInvervalo,out strPrefixo,out strSufixo);
				m_txtIntervalo.Text = strInvervalo;
				m_txtPrefixo.Text = strPrefixo;
				m_txtSufixo.Text = strSufixo;
				formFInformacoesIntervalo = null;
				this.Cursor = System.Windows.Forms.Cursors.Default;
			}
		#endregion

		#region Eventos
			#region Formulario
				private void frmFEmbalagemNova_Load(object sender, System.EventArgs e)
				{
					MostraCor();
				}
			#endregion
			#region RadioButton
				private void m_rbNumero_CheckedChanged(object sender, System.EventArgs e)
				{
					RefreshInterfaceRadioButtons();				
				}

				private void m_rbIntervalo_CheckedChanged(object sender, System.EventArgs e)
				{
					RefreshInterfaceRadioButtons();
				}
			#endregion
			#region LinkButtons
				private void m_llbIntervalos_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
				{
					ShowDialogInformacoesIntervalo();
				}
			#endregion
			#region Botoes
				private void m_btOk_Click(object sender, System.EventArgs e)
				{
					bool bOk = false;
					string strMensagem = "";
					System.Collections.ArrayList arlEmbalagens = null;
					// Verificando a opção escolhida 
					if (m_rbNumero.Checked)
					{
						// Quantidade
						int nQuantidadeEmbalagens = 0;
						try
						{
							nQuantidadeEmbalagens = Int32.Parse(this.m_txtQuantidade.Text);
							arlEmbalagens = OnCallArlRetornaEmbalagens(nQuantidadeEmbalagens);
							bOk = true;
						}catch{
                            bOk = false;
							strMensagem = "Você deve digitar um valor numérico na quantidade de embalagens a inserir";
						}
					}else{
						// Intervalo
						arlEmbalagens = clsProdutosRomaneio.arlRetornaIntervalo(m_txtIntervalo.Text,m_txtPrefixo.Text,m_txtSufixo.Text);
						if ((arlEmbalagens == null) && (m_txtIntervalo.Text != ""))
						{
							strMensagem = "Você digitou um intervalo errado.";
							bOk = false;
						}else{
							bOk = true;
						}
					}

					if (bOk)
					{
						if (!OnCallEmbalagensInexistentes(ref arlEmbalagens))
						{
							bOk = false;
							strMensagem = "Algumas das embalagens que você esta tentando inserir já existe";
						}
					}
					if (bOk)
					{
						m_arlEmbalagens = arlEmbalagens;
						m_bModificado = true;
						this.Close();
					}else{
						mdlMensagens.clsMensagens.ShowInformation("Siscobras.NET",mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.mdlProdutosRomaneio_frmFEmbalagemNova_MensagemOK).Replace("TAG",strMensagem));
						//MessageBox.Show(strMensagem,"Siscobras.NET",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
					}
				}

				private void m_btCancelar_Click(object sender, System.EventArgs e)
				{
					m_bModificado = false;
					this.Close();
				}
			#endregion
		#endregion
		#region Cores Formulario
			private void MostraCor()
			{
				try
				{
					mdlPaletaDeCores.clsPaletaDeCores clsPaletaCores = new mdlPaletaDeCores.clsPaletaDeCores(m_strEnderecoExecutavel + "sisco.ini","SiscobrasCorSecundaria");
					this.BackColor = clsPaletaCores.retornaCorAtual();
					for (int nCont = 0 ;nCont < this.Controls.Count; nCont++)
					{
						this.Controls[nCont].BackColor = this.BackColor;
						for (int nCont2 = 0 ;nCont2 < this.Controls[nCont].Controls.Count; nCont2++)
						{
							if ((this.Controls[nCont].Controls[nCont2].GetType().ToString() != "mdlComponentesGraficos.TextBox") && (this.Controls[nCont].Controls[nCont2].GetType().ToString() != "mdlComponentesGraficos.TreeView"))
								this.Controls[nCont].Controls[nCont2].BackColor = this.BackColor;

							for (int nCont3 = 0 ;nCont3 < this.Controls[nCont].Controls[nCont2].Controls.Count; nCont3++)
							{
								if ((this.Controls[nCont].Controls[nCont2].Controls[nCont3].GetType().ToString() != "mdlComponentesGraficos.TextBox") && (this.Controls[nCont].Controls[nCont2].Controls[nCont3].GetType().ToString() != "mdlComponentesGraficos.TreeView"))
									this.Controls[nCont].Controls[nCont2].Controls[nCont3].BackColor = this.BackColor;
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

		#region Refresh da Interface
			private void RefreshInterfaceRadioButtons()
			{
				if (m_rbNumero.Checked)
				{
					m_gbQuantidade.Enabled = true;
					m_gbIntervalo.Enabled = false;
					m_txtQuantidade.Focus();
				}else{
					m_gbQuantidade.Enabled = false;
					m_gbIntervalo.Enabled = true;
					m_txtIntervalo.Focus();
				}
			}
		#endregion

		#region Retorno
		public void RetornaValores(out System.Collections.ArrayList arlEmbalagens)
		{
			arlEmbalagens = m_arlEmbalagens;
		}
		#endregion

	}
}
