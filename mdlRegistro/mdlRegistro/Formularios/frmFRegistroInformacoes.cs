using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace mdlRegistro
{
	/// <summary>
	/// Summary description for frmFRegistroInformacoes.
	/// </summary>
	internal class frmFRegistroInformacoes : System.Windows.Forms.Form
	{
		#region Delegates
			public delegate void delCallCarregaDados(out int nRegistroRealizacaoProcessosExportacao,out string strRegistroRealizacaoProcessosExportacao,out int nRegistroConhecimentoSiscobras,out string strRegistroConhecimentoSiscobras);
			public delegate void delCallSalvaDados(int nRegistroRealizacaoProcessosExportacao,string strRegistroRealizacaoProcessosExportacao,int nRegistroConhecimentoSiscobras, string strRegistroConhecimentoSiscobras);
			public delegate bool delCallCodigoClienteGenerate();
			public delegate void delCallSalvaDadosBD();
		#endregion
		#region Events
			public event delCallCarregaDados eCallCarregaDados;
			public event delCallSalvaDados eCallSalvaDados;
			public event delCallCodigoClienteGenerate eCallCodigoClienteGenerate;
			public event delCallSalvaDadosBD eCallSalvaDadosBD;
		#endregion
		#region Events Methods
			protected virtual void OnCallCarregaDados()
			{
				if (eCallCarregaDados != null)
				{
					eCallCarregaDados(out m_nRegistroRealizacaoProcessosExportacao,out m_strRegistroRealizacaoProcessosExportacao,out m_nRegistroConhecimentoSiscobras,out m_strRegistroConhecimentoSiscobras);
				}
			}

			protected virtual void OnCallSalvaDados()
			{
				if (eCallSalvaDados != null)
				{
					eCallSalvaDados(m_nRegistroRealizacaoProcessosExportacao,m_strRegistroRealizacaoProcessosExportacao,m_nRegistroConhecimentoSiscobras,m_strRegistroConhecimentoSiscobras);
				}
			}

			protected virtual bool OnCallCodigoClienteGenerate()
			{
				bool bRetorno = false;
				if (eCallCodigoClienteGenerate != null)
				{
					bRetorno = eCallCodigoClienteGenerate();
				}
				return(bRetorno);
			}

			protected virtual void OnCallSalvaDadosBD()
			{
				if (eCallSalvaDadosBD != null)
				{
					this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
					eCallSalvaDadosBD();
					this.Cursor = System.Windows.Forms.Cursors.Default;
				}
			}
		#endregion
		#region Atributos
			private mdlTratamentoErro.clsTratamentoErro m_cls_ter_TratadorErro = null;
			private string m_strEnderecoExecutavel = "";

			// Dados 
			private int m_nRegistroRealizacaoProcessosExportacao = 0;
			private string m_strRegistroRealizacaoProcessosExportacao = "";
			private int m_nRegistroConhecimentoSiscobras = 0;
			private string m_strRegistroConhecimentoSiscobras = "";

			internal mdlRegistro.Resposta m_enumResposta = mdlRegistro.Resposta.Cancelar;

			private System.Windows.Forms.GroupBox m_gbGeral;
			private System.Windows.Forms.GroupBox m_gbIdentificacao;
			internal System.Windows.Forms.Button m_btVoltar;
			internal System.Windows.Forms.Button m_btCancelar;
			private System.Windows.Forms.GroupBox groupBox1;
			private System.Windows.Forms.GroupBox m_gbImagem;
			private System.Windows.Forms.PictureBox m_picImagem;
			internal System.Windows.Forms.Button m_btConcluir;
			private System.Windows.Forms.RadioButton m_rbConhecimentoSiscobras4;
			private System.Windows.Forms.RadioButton m_rbConhecimentoSiscobras3;
			private System.Windows.Forms.RadioButton m_rbConhecimentoSiscobras5;
			private System.Windows.Forms.RadioButton m_rbConhecimentoSiscobras2;
			private System.Windows.Forms.RadioButton m_rbConhecimentoSiscobras1;
			private mdlComponentesGraficos.TextBox m_txtConhecimentoSiscobras5;
			private mdlComponentesGraficos.TextBox m_txtProcessoExportacao3;
			private System.Windows.Forms.RadioButton m_rbProcessoExportacao3;
			private System.Windows.Forms.RadioButton m_rbProcessoExportacao4;
			private System.Windows.Forms.RadioButton m_rbProcessoExportacao2;
			private System.Windows.Forms.RadioButton m_rbProcessoExportacao1;
			private mdlComponentesGraficos.TextBox m_txtProcessoExportacao4;
			private System.Windows.Forms.ToolTip m_ttDica;
			private System.ComponentModel.IContainer components;
		#endregion
		#region Constructors and Destructors 
			public frmFRegistroInformacoes(ref mdlTratamentoErro.clsTratamentoErro cls_ter_TratadorErro,string strEnderecoExecutavel)
			{
				m_cls_ter_TratadorErro = cls_ter_TratadorErro;
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmFRegistroInformacoes));
			this.m_gbGeral = new System.Windows.Forms.GroupBox();
			this.m_btConcluir = new System.Windows.Forms.Button();
			this.m_gbImagem = new System.Windows.Forms.GroupBox();
			this.m_picImagem = new System.Windows.Forms.PictureBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.m_rbConhecimentoSiscobras4 = new System.Windows.Forms.RadioButton();
			this.m_rbConhecimentoSiscobras3 = new System.Windows.Forms.RadioButton();
			this.m_rbConhecimentoSiscobras5 = new System.Windows.Forms.RadioButton();
			this.m_rbConhecimentoSiscobras2 = new System.Windows.Forms.RadioButton();
			this.m_rbConhecimentoSiscobras1 = new System.Windows.Forms.RadioButton();
			this.m_txtConhecimentoSiscobras5 = new mdlComponentesGraficos.TextBox();
			this.m_gbIdentificacao = new System.Windows.Forms.GroupBox();
			this.m_txtProcessoExportacao3 = new mdlComponentesGraficos.TextBox();
			this.m_rbProcessoExportacao3 = new System.Windows.Forms.RadioButton();
			this.m_rbProcessoExportacao4 = new System.Windows.Forms.RadioButton();
			this.m_rbProcessoExportacao2 = new System.Windows.Forms.RadioButton();
			this.m_rbProcessoExportacao1 = new System.Windows.Forms.RadioButton();
			this.m_txtProcessoExportacao4 = new mdlComponentesGraficos.TextBox();
			this.m_btVoltar = new System.Windows.Forms.Button();
			this.m_btCancelar = new System.Windows.Forms.Button();
			this.m_ttDica = new System.Windows.Forms.ToolTip(this.components);
			this.m_gbGeral.SuspendLayout();
			this.m_gbImagem.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.m_gbIdentificacao.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_gbGeral
			// 
			this.m_gbGeral.Controls.Add(this.m_btConcluir);
			this.m_gbGeral.Controls.Add(this.m_gbImagem);
			this.m_gbGeral.Controls.Add(this.groupBox1);
			this.m_gbGeral.Controls.Add(this.m_gbIdentificacao);
			this.m_gbGeral.Controls.Add(this.m_btVoltar);
			this.m_gbGeral.Controls.Add(this.m_btCancelar);
			this.m_gbGeral.Location = new System.Drawing.Point(6, 2);
			this.m_gbGeral.Name = "m_gbGeral";
			this.m_gbGeral.Size = new System.Drawing.Size(429, 409);
			this.m_gbGeral.TabIndex = 2;
			this.m_gbGeral.TabStop = false;
			// 
			// m_btConcluir
			// 
			this.m_btConcluir.BackColor = System.Drawing.SystemColors.Control;
			this.m_btConcluir.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btConcluir.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btConcluir.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btConcluir.Image = ((System.Drawing.Image)(resources.GetObject("m_btConcluir.Image")));
			this.m_btConcluir.Location = new System.Drawing.Point(248, 376);
			this.m_btConcluir.Name = "m_btConcluir";
			this.m_btConcluir.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btConcluir.Size = new System.Drawing.Size(57, 25);
			this.m_btConcluir.TabIndex = 15;
			this.m_ttDica.SetToolTip(this.m_btConcluir, "Salvar e Prosseguir");
			this.m_btConcluir.Click += new System.EventHandler(this.m_btConcluir_Click);
			// 
			// m_gbImagem
			// 
			this.m_gbImagem.Controls.Add(this.m_picImagem);
			this.m_gbImagem.Location = new System.Drawing.Point(8, 7);
			this.m_gbImagem.Name = "m_gbImagem";
			this.m_gbImagem.Size = new System.Drawing.Size(416, 112);
			this.m_gbImagem.TabIndex = 50;
			this.m_gbImagem.TabStop = false;
			// 
			// m_picImagem
			// 
			this.m_picImagem.Image = ((System.Drawing.Image)(resources.GetObject("m_picImagem.Image")));
			this.m_picImagem.Location = new System.Drawing.Point(8, 16);
			this.m_picImagem.Name = "m_picImagem";
			this.m_picImagem.Size = new System.Drawing.Size(400, 88);
			this.m_picImagem.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.m_picImagem.TabIndex = 0;
			this.m_picImagem.TabStop = false;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.m_rbConhecimentoSiscobras4);
			this.groupBox1.Controls.Add(this.m_rbConhecimentoSiscobras3);
			this.groupBox1.Controls.Add(this.m_rbConhecimentoSiscobras5);
			this.groupBox1.Controls.Add(this.m_rbConhecimentoSiscobras2);
			this.groupBox1.Controls.Add(this.m_rbConhecimentoSiscobras1);
			this.groupBox1.Controls.Add(this.m_txtConhecimentoSiscobras5);
			this.groupBox1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.groupBox1.Location = new System.Drawing.Point(9, 247);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(415, 124);
			this.groupBox1.TabIndex = 8;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Como você soube do Siscobras";
			// 
			// m_rbConhecimentoSiscobras4
			// 
			this.m_rbConhecimentoSiscobras4.Location = new System.Drawing.Point(16, 63);
			this.m_rbConhecimentoSiscobras4.Name = "m_rbConhecimentoSiscobras4";
			this.m_rbConhecimentoSiscobras4.Size = new System.Drawing.Size(263, 16);
			this.m_rbConhecimentoSiscobras4.TabIndex = 12;
			this.m_rbConhecimentoSiscobras4.Text = "Amigo";
			// 
			// m_rbConhecimentoSiscobras3
			// 
			this.m_rbConhecimentoSiscobras3.Location = new System.Drawing.Point(16, 47);
			this.m_rbConhecimentoSiscobras3.Name = "m_rbConhecimentoSiscobras3";
			this.m_rbConhecimentoSiscobras3.Size = new System.Drawing.Size(263, 16);
			this.m_rbConhecimentoSiscobras3.TabIndex = 11;
			this.m_rbConhecimentoSiscobras3.Text = "Telefone";
			// 
			// m_rbConhecimentoSiscobras5
			// 
			this.m_rbConhecimentoSiscobras5.Location = new System.Drawing.Point(16, 79);
			this.m_rbConhecimentoSiscobras5.Name = "m_rbConhecimentoSiscobras5";
			this.m_rbConhecimentoSiscobras5.Size = new System.Drawing.Size(352, 16);
			this.m_rbConhecimentoSiscobras5.TabIndex = 13;
			this.m_rbConhecimentoSiscobras5.Text = "Outros meios";
			// 
			// m_rbConhecimentoSiscobras2
			// 
			this.m_rbConhecimentoSiscobras2.Location = new System.Drawing.Point(16, 31);
			this.m_rbConhecimentoSiscobras2.Name = "m_rbConhecimentoSiscobras2";
			this.m_rbConhecimentoSiscobras2.Size = new System.Drawing.Size(304, 16);
			this.m_rbConhecimentoSiscobras2.TabIndex = 10;
			this.m_rbConhecimentoSiscobras2.Text = "Correio";
			// 
			// m_rbConhecimentoSiscobras1
			// 
			this.m_rbConhecimentoSiscobras1.Checked = true;
			this.m_rbConhecimentoSiscobras1.Location = new System.Drawing.Point(16, 17);
			this.m_rbConhecimentoSiscobras1.Name = "m_rbConhecimentoSiscobras1";
			this.m_rbConhecimentoSiscobras1.Size = new System.Drawing.Size(352, 16);
			this.m_rbConhecimentoSiscobras1.TabIndex = 9;
			this.m_rbConhecimentoSiscobras1.TabStop = true;
			this.m_rbConhecimentoSiscobras1.Text = "Internet";
			// 
			// m_txtConhecimentoSiscobras5
			// 
			this.m_txtConhecimentoSiscobras5.Location = new System.Drawing.Point(36, 98);
			this.m_txtConhecimentoSiscobras5.Name = "m_txtConhecimentoSiscobras5";
			this.m_txtConhecimentoSiscobras5.Size = new System.Drawing.Size(360, 20);
			this.m_txtConhecimentoSiscobras5.TabIndex = 14;
			this.m_txtConhecimentoSiscobras5.Text = "";
			// 
			// m_gbIdentificacao
			// 
			this.m_gbIdentificacao.Controls.Add(this.m_txtProcessoExportacao3);
			this.m_gbIdentificacao.Controls.Add(this.m_rbProcessoExportacao3);
			this.m_gbIdentificacao.Controls.Add(this.m_rbProcessoExportacao4);
			this.m_gbIdentificacao.Controls.Add(this.m_rbProcessoExportacao2);
			this.m_gbIdentificacao.Controls.Add(this.m_rbProcessoExportacao1);
			this.m_gbIdentificacao.Controls.Add(this.m_txtProcessoExportacao4);
			this.m_gbIdentificacao.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_gbIdentificacao.Location = new System.Drawing.Point(8, 117);
			this.m_gbIdentificacao.Name = "m_gbIdentificacao";
			this.m_gbIdentificacao.Size = new System.Drawing.Size(416, 129);
			this.m_gbIdentificacao.TabIndex = 1;
			this.m_gbIdentificacao.TabStop = false;
			this.m_gbIdentificacao.Text = "Como você realiza atualmente seus processos de exportação";
			// 
			// m_txtProcessoExportacao3
			// 
			this.m_txtProcessoExportacao3.Location = new System.Drawing.Point(38, 67);
			this.m_txtProcessoExportacao3.Name = "m_txtProcessoExportacao3";
			this.m_txtProcessoExportacao3.Size = new System.Drawing.Size(360, 20);
			this.m_txtProcessoExportacao3.TabIndex = 5;
			this.m_txtProcessoExportacao3.Text = "";
			// 
			// m_rbProcessoExportacao3
			// 
			this.m_rbProcessoExportacao3.Location = new System.Drawing.Point(17, 52);
			this.m_rbProcessoExportacao3.Name = "m_rbProcessoExportacao3";
			this.m_rbProcessoExportacao3.Size = new System.Drawing.Size(263, 16);
			this.m_rbProcessoExportacao3.TabIndex = 4;
			this.m_rbProcessoExportacao3.Text = "Software especifico de comercio exterior";
			// 
			// m_rbProcessoExportacao4
			// 
			this.m_rbProcessoExportacao4.Location = new System.Drawing.Point(18, 87);
			this.m_rbProcessoExportacao4.Name = "m_rbProcessoExportacao4";
			this.m_rbProcessoExportacao4.Size = new System.Drawing.Size(352, 16);
			this.m_rbProcessoExportacao4.TabIndex = 6;
			this.m_rbProcessoExportacao4.Text = "Outros meios";
			// 
			// m_rbProcessoExportacao2
			// 
			this.m_rbProcessoExportacao2.Location = new System.Drawing.Point(16, 33);
			this.m_rbProcessoExportacao2.Name = "m_rbProcessoExportacao2";
			this.m_rbProcessoExportacao2.Size = new System.Drawing.Size(304, 16);
			this.m_rbProcessoExportacao2.TabIndex = 3;
			this.m_rbProcessoExportacao2.Text = "Softwares de processamento de texto e planilhas";
			// 
			// m_rbProcessoExportacao1
			// 
			this.m_rbProcessoExportacao1.Checked = true;
			this.m_rbProcessoExportacao1.Location = new System.Drawing.Point(16, 17);
			this.m_rbProcessoExportacao1.Name = "m_rbProcessoExportacao1";
			this.m_rbProcessoExportacao1.Size = new System.Drawing.Size(352, 16);
			this.m_rbProcessoExportacao1.TabIndex = 2;
			this.m_rbProcessoExportacao1.TabStop = true;
			this.m_rbProcessoExportacao1.Text = "Nunca exportei";
			// 
			// m_txtProcessoExportacao4
			// 
			this.m_txtProcessoExportacao4.Location = new System.Drawing.Point(38, 103);
			this.m_txtProcessoExportacao4.Name = "m_txtProcessoExportacao4";
			this.m_txtProcessoExportacao4.Size = new System.Drawing.Size(360, 20);
			this.m_txtProcessoExportacao4.TabIndex = 7;
			this.m_txtProcessoExportacao4.Text = "";
			// 
			// m_btVoltar
			// 
			this.m_btVoltar.BackColor = System.Drawing.SystemColors.Control;
			this.m_btVoltar.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btVoltar.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btVoltar.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btVoltar.Image = ((System.Drawing.Image)(resources.GetObject("m_btVoltar.Image")));
			this.m_btVoltar.Location = new System.Drawing.Point(121, 375);
			this.m_btVoltar.Name = "m_btVoltar";
			this.m_btVoltar.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btVoltar.Size = new System.Drawing.Size(57, 25);
			this.m_btVoltar.TabIndex = 16;
			this.m_ttDica.SetToolTip(this.m_btVoltar, "Voltar");
			this.m_btVoltar.Click += new System.EventHandler(this.m_btVoltar_Click);
			// 
			// m_btCancelar
			// 
			this.m_btCancelar.BackColor = System.Drawing.SystemColors.Control;
			this.m_btCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btCancelar.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btCancelar.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btCancelar.Image = ((System.Drawing.Image)(resources.GetObject("m_btCancelar.Image")));
			this.m_btCancelar.Location = new System.Drawing.Point(185, 375);
			this.m_btCancelar.Name = "m_btCancelar";
			this.m_btCancelar.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btCancelar.Size = new System.Drawing.Size(57, 25);
			this.m_btCancelar.TabIndex = 17;
			this.m_ttDica.SetToolTip(this.m_btCancelar, "Cancelar");
			this.m_btCancelar.Click += new System.EventHandler(this.m_btCancelar_Click);
			// 
			// m_ttDica
			// 
			this.m_ttDica.AutomaticDelay = 100;
			this.m_ttDica.AutoPopDelay = 5000;
			this.m_ttDica.InitialDelay = 100;
			this.m_ttDica.ReshowDelay = 20;
			// 
			// frmFRegistroInformacoes
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(442, 416);
			this.Controls.Add(this.m_gbGeral);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmFRegistroInformacoes";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Informações adicionais";
			this.Load += new System.EventHandler(this.frmFRegistroInformacoes_Load);
			this.m_gbGeral.ResumeLayout(false);
			this.m_gbImagem.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.m_gbIdentificacao.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Carregamento dos Dados Interface
			private void vCarregaDadosInterface()
			{
				// Como Realiza Processos de Exportacao
				switch(m_nRegistroRealizacaoProcessosExportacao)
				{
					case 1:
						m_rbProcessoExportacao1.Checked = true;
						break;
					case 2:
						m_rbProcessoExportacao2.Checked = true;
						break;
					case 3:
						m_rbProcessoExportacao3.Checked = true;
						m_txtProcessoExportacao3.Text = m_strRegistroRealizacaoProcessosExportacao;
						break;
					case 4:
						m_rbProcessoExportacao4.Checked = true;
						m_txtProcessoExportacao4.Text = m_strRegistroRealizacaoProcessosExportacao;
						break;
				}

				// Como soube da Siscobras
				switch(m_nRegistroConhecimentoSiscobras)
				{
					case 1:
						m_rbConhecimentoSiscobras1.Checked = true;
						break;
					case 2:
						m_rbConhecimentoSiscobras2.Checked = true;
						break;
					case 3:
						m_rbConhecimentoSiscobras3.Checked = true;
						break;
					case 4:
						m_rbConhecimentoSiscobras4.Checked = true;
						break;
					case 5:
						m_rbConhecimentoSiscobras5.Checked = true;
						m_txtConhecimentoSiscobras5.Text = m_strRegistroConhecimentoSiscobras;
						break;
				}
			}
		#endregion
		#region Salvamento dos Dados da Interface
			private bool bSalvaDadosInterface()
			{
				// Como Realiza os Processos 
				m_nRegistroRealizacaoProcessosExportacao = 0;
				if (m_rbProcessoExportacao1.Checked)
				{
					m_nRegistroRealizacaoProcessosExportacao = 1;
				}else{
					if (m_rbProcessoExportacao2.Checked)
					{
						m_nRegistroRealizacaoProcessosExportacao = 2;
					}else{
						if (m_rbProcessoExportacao3.Checked)
						{
							m_nRegistroRealizacaoProcessosExportacao = 3;
							m_strRegistroRealizacaoProcessosExportacao = m_txtProcessoExportacao3.Text; 
						}else{
							if (m_rbProcessoExportacao4.Checked)
							{
								m_nRegistroRealizacaoProcessosExportacao = 4;
								m_strRegistroRealizacaoProcessosExportacao = m_txtProcessoExportacao4.Text; 
							}
						}
					}
				}

				// Conhecimento do Siscobras
				m_nRegistroConhecimentoSiscobras = 0;
				if (m_rbConhecimentoSiscobras1.Checked)
				{
					m_nRegistroConhecimentoSiscobras = 1;
				}else{
					if (m_rbConhecimentoSiscobras2.Checked)
					{
						m_nRegistroConhecimentoSiscobras = 2;
					}else{
						if (m_rbConhecimentoSiscobras3.Checked)
						{
							m_nRegistroConhecimentoSiscobras = 3;
						}else{
							if (m_rbConhecimentoSiscobras4.Checked)
							{
								m_nRegistroConhecimentoSiscobras = 4;
							}else{
								if (m_rbConhecimentoSiscobras5.Checked)
								{
									m_nRegistroConhecimentoSiscobras = 5;
									m_strRegistroConhecimentoSiscobras = m_txtConhecimentoSiscobras5.Text;
								}
							}
						}
					}
				}
				return(true);
			}
		#endregion

		#region Eventos 
			#region Formulario
				private void frmFRegistroInformacoes_Load(object sender, System.EventArgs e)
				{
					MostraCor();
					OnCallCarregaDados();
					vCarregaDadosInterface();
				}
			#endregion
			#region Botoes
				private void m_btVoltar_Click(object sender, System.EventArgs e)
				{
					m_enumResposta = mdlRegistro.Resposta.Voltar;
					this.Close();
				}

				private void m_btCancelar_Click(object sender, System.EventArgs e)
				{
					m_enumResposta = mdlRegistro.Resposta.Cancelar;
					this.Close();
				}

				private void m_btConcluir_Click(object sender, System.EventArgs e)
				{
					if (bSalvaDadosInterface())
					{
						OnCallSalvaDados();
						if (OnCallCodigoClienteGenerate())
						{
							OnCallSalvaDadosBD();
							m_enumResposta = mdlRegistro.Resposta.Continuar;
							this.Close();
						}
					}
				}
			#endregion
		#endregion
		#region Cores
			private void MostraCor()
			{
				mdlPaletaDeCores.clsPaletaDeCores clsPaletaCores = new mdlPaletaDeCores.clsPaletaDeCores(m_strEnderecoExecutavel + "sisco.ini","CoresSecundarias");
				this.BackColor = clsPaletaCores.retornaCorAtual();
				for (int nCont = 0 ;nCont < this.Controls.Count; nCont++)
				{
					this.Controls[nCont].BackColor = this.BackColor;
					for (int nCont2 = 0 ;nCont2 < this.Controls[nCont].Controls.Count; nCont2++)
					{
						if ((this.Controls[nCont].Controls[nCont2].GetType().ToString() != "mdlComponentesGraficos.TextBox") && (this.Controls[nCont].Controls[nCont2].GetType().ToString() != "System.Windows.Forms.Panel"))
							this.Controls[nCont].Controls[nCont2].BackColor = this.BackColor;

						for (int nCont3 = 0 ;nCont3 < this.Controls[nCont].Controls[nCont2].Controls.Count; nCont3++)
						{
							if ((this.Controls[nCont].Controls[nCont2].Controls[nCont3].GetType().ToString() != "mdlComponentesGraficos.TextBox") && (this.Controls[nCont].Controls[nCont2].Controls[nCont3].GetType().ToString() != "mdlComponentesGraficos.ComboBox"))
								this.Controls[nCont].Controls[nCont2].Controls[nCont3].BackColor = this.BackColor;
						}
					}
				}
			}
		#endregion
	}
}
