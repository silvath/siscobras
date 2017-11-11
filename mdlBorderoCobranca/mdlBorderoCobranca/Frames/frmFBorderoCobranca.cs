using System;
using System.Collections;
using System.Windows.Forms;

namespace mdlBorderoCobranca.Frames
{
	/// <summary>
	/// Summary description for frmFBorderoCobranca.
	/// </summary>
	internal class frmFBorderoCobranca : mdlComponentesGraficos.FormFlutuante
	{
		#region Atributos
		protected mdlTratamentoErro.clsTratamentoErro m_cls_ter_tratadorErro;
		protected string m_strEnderecoExecutavel;

		public bool m_bModificado = false;

		private bool m_bAtivado = true;

		private System.Windows.Forms.GroupBox m_gbFrame;
		private System.Windows.Forms.GroupBox m_gbFields;
		private System.Windows.Forms.Label m_lEntregar;
		private mdlComponentesGraficos.ComboBox m_cbEntregarDocumentos;
		private System.Windows.Forms.Label m_lTextoProtestar;
		private System.Windows.Forms.Label m_lProtestar;
		private mdlComponentesGraficos.TextBox m_tbDias;
		private System.Windows.Forms.Label m_lTextoDias;
		private System.Windows.Forms.Button m_btOk;
		private System.Windows.Forms.Button m_btCancelar;
		#endregion
		private System.Windows.Forms.ToolTip m_ttCobrance;
		private System.ComponentModel.IContainer components;

		#region Construtores & Destrutores
		public frmFBorderoCobranca(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, string EnderecoExecutavel)
		{
			InitializeComponent();

			m_cls_ter_tratadorErro = tratadorErro;
			m_strEnderecoExecutavel = EnderecoExecutavel;
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
		public delegate void delCallCarregaDadosInterface(ref mdlComponentesGraficos.ComboBox cbEntregar, ref System.Windows.Forms.Label lProtestar, ref mdlComponentesGraficos.TextBox tbDias, ref System.Windows.Forms.Label lTextoProtestar, ref System.Windows.Forms.Label lTextoDias);
		public delegate void delCallTrocarProtesto(ref System.Windows.Forms.Label lProtestar);
		public delegate void delCallSalvaDadosInterface(ref mdlComponentesGraficos.ComboBox cbEntregar, ref System.Windows.Forms.Label lProtestar, ref mdlComponentesGraficos.TextBox tbDias);
		public delegate void delCallSalvaDadosBD();
		#endregion
		#region Events
		public event delCallCarregaDadosInterface eCallCarregaDadosInterface;
		public event delCallTrocarProtesto eCallTrocarProtesto;
		public event delCallSalvaDadosInterface eCallSalvaDadosInterface;
		public event delCallSalvaDadosBD eCallSalvaDadosBD;
		#endregion
		#region Events Methods
		protected virtual void OnCallCarregaDadosInterface()
		{
			if (eCallCarregaDadosInterface != null)
				eCallCarregaDadosInterface(ref m_cbEntregarDocumentos, ref m_lProtestar, ref m_tbDias, ref m_lTextoProtestar, ref m_lTextoDias);
		}
		protected virtual void OnCallTrocarProtesto()
		{
			if (eCallTrocarProtesto != null)
				eCallTrocarProtesto(ref m_lProtestar);
		}
		protected virtual void OnCallSalvaDadosInterface()
		{
			if (eCallSalvaDadosInterface != null)
				eCallSalvaDadosInterface(ref m_cbEntregarDocumentos, ref m_lProtestar, ref m_tbDias);
		}
		protected virtual void OnCallSalvaDadosBD()
		{
			if (eCallSalvaDadosBD != null)
				eCallSalvaDadosBD();
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmFBorderoCobranca));
			this.m_gbFrame = new System.Windows.Forms.GroupBox();
			this.m_btOk = new System.Windows.Forms.Button();
			this.m_btCancelar = new System.Windows.Forms.Button();
			this.m_gbFields = new System.Windows.Forms.GroupBox();
			this.m_lTextoDias = new System.Windows.Forms.Label();
			this.m_tbDias = new mdlComponentesGraficos.TextBox();
			this.m_lProtestar = new System.Windows.Forms.Label();
			this.m_lTextoProtestar = new System.Windows.Forms.Label();
			this.m_cbEntregarDocumentos = new mdlComponentesGraficos.ComboBox();
			this.m_lEntregar = new System.Windows.Forms.Label();
			this.m_ttCobrance = new System.Windows.Forms.ToolTip(this.components);
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
			this.m_gbFrame.Size = new System.Drawing.Size(306, 125);
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
			this.m_btOk.Location = new System.Drawing.Point(93, 94);
			this.m_btOk.Name = "m_btOk";
			this.m_btOk.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btOk.Size = new System.Drawing.Size(57, 25);
			this.m_btOk.TabIndex = 7;
			this.m_ttCobrance.SetToolTip(this.m_btOk, "Confirmar");
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
			this.m_btCancelar.Location = new System.Drawing.Point(157, 94);
			this.m_btCancelar.Name = "m_btCancelar";
			this.m_btCancelar.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btCancelar.Size = new System.Drawing.Size(57, 25);
			this.m_btCancelar.TabIndex = 8;
			this.m_ttCobrance.SetToolTip(this.m_btCancelar, "Cancelar");
			this.m_btCancelar.Click += new System.EventHandler(this.m_btCancelar_Click);
			// 
			// m_gbFields
			// 
			this.m_gbFields.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_gbFields.Controls.Add(this.m_lTextoDias);
			this.m_gbFields.Controls.Add(this.m_tbDias);
			this.m_gbFields.Controls.Add(this.m_lProtestar);
			this.m_gbFields.Controls.Add(this.m_lTextoProtestar);
			this.m_gbFields.Controls.Add(this.m_cbEntregarDocumentos);
			this.m_gbFields.Controls.Add(this.m_lEntregar);
			this.m_gbFields.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_gbFields.Location = new System.Drawing.Point(8, 8);
			this.m_gbFields.Name = "m_gbFields";
			this.m_gbFields.Size = new System.Drawing.Size(290, 81);
			this.m_gbFields.TabIndex = 0;
			this.m_gbFields.TabStop = false;
			this.m_gbFields.Text = "Cobrança";
			// 
			// m_lTextoDias
			// 
			this.m_lTextoDias.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.m_lTextoDias.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lTextoDias.Location = new System.Drawing.Point(140, 54);
			this.m_lTextoDias.Name = "m_lTextoDias";
			this.m_lTextoDias.Size = new System.Drawing.Size(143, 16);
			this.m_lTextoDias.TabIndex = 6;
			this.m_lTextoDias.Text = "dia(s) após o vencimento";
			this.m_lTextoDias.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// m_tbDias
			// 
			this.m_tbDias.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.m_tbDias.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_tbDias.Location = new System.Drawing.Point(114, 51);
			this.m_tbDias.MaxLength = 2;
			this.m_tbDias.Name = "m_tbDias";
			this.m_tbDias.OnlyNumbers = true;
			this.m_tbDias.Size = new System.Drawing.Size(20, 21);
			this.m_tbDias.TabIndex = 5;
			this.m_tbDias.Text = "15";
			this.m_tbDias.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.m_ttCobrance.SetToolTip(this.m_tbDias, "Digite o número de dias");
			// 
			// m_lProtestar
			// 
			this.m_lProtestar.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.m_lProtestar.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.m_lProtestar.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_lProtestar.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lProtestar.Location = new System.Drawing.Point(77, 54);
			this.m_lProtestar.Name = "m_lProtestar";
			this.m_lProtestar.Size = new System.Drawing.Size(28, 16);
			this.m_lProtestar.TabIndex = 3;
			this.m_lProtestar.Text = "Sim";
			this.m_lProtestar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.m_ttCobrance.SetToolTip(this.m_lProtestar, "Protestar?");
			this.m_lProtestar.Click += new System.EventHandler(this.m_lProtestar_Click);
			// 
			// m_lTextoProtestar
			// 
			this.m_lTextoProtestar.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.m_lTextoProtestar.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lTextoProtestar.Location = new System.Drawing.Point(16, 54);
			this.m_lTextoProtestar.Name = "m_lTextoProtestar";
			this.m_lTextoProtestar.Size = new System.Drawing.Size(58, 16);
			this.m_lTextoProtestar.TabIndex = 2;
			this.m_lTextoProtestar.Text = "Protestar:";
			this.m_lTextoProtestar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// m_cbEntregarDocumentos
			// 
			this.m_cbEntregarDocumentos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_cbEntregarDocumentos.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_cbEntregarDocumentos.Location = new System.Drawing.Point(142, 19);
			this.m_cbEntregarDocumentos.Name = "m_cbEntregarDocumentos";
			this.m_cbEntregarDocumentos.Size = new System.Drawing.Size(140, 23);
			this.m_cbEntregarDocumentos.TabIndex = 1;
			this.m_ttCobrance.SetToolTip(this.m_cbEntregarDocumentos, "Selecione");
			this.m_cbEntregarDocumentos.SelectedIndexChanged += new System.EventHandler(this.m_cbEntregarDocumentos_SelectedIndexChanged);
			// 
			// m_lEntregar
			// 
			this.m_lEntregar.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lEntregar.Location = new System.Drawing.Point(8, 24);
			this.m_lEntregar.Name = "m_lEntregar";
			this.m_lEntregar.Size = new System.Drawing.Size(128, 16);
			this.m_lEntregar.TabIndex = 0;
			this.m_lEntregar.Text = "Entregar Documentos:";
			this.m_lEntregar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// m_ttCobrance
			// 
			this.m_ttCobrance.AutomaticDelay = 100;
			this.m_ttCobrance.AutoPopDelay = 5000;
			this.m_ttCobrance.InitialDelay = 100;
			this.m_ttCobrance.ReshowDelay = 20;
			// 
			// frmFBorderoCobranca
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(310, 127);
			this.Controls.Add(this.m_gbFrame);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmFBorderoCobranca";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Cobrança";
			this.Load += new System.EventHandler(this.frmFBorderoCobranca_Load);
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
								"mdlComponentesGraficos.ComboBox"))
							{
								this.Controls[cont].Controls[cont2].Controls[cont3].BackColor = this.BackColor;
							}
							if ((this.Controls[cont].Controls[cont2].Controls[cont3].Name == "m_lProtestar") &&
								(this.Controls[cont].Controls[cont2].Controls[cont3].GetType().ToString() == 
								"System.Windows.Forms.Label"))
							{
								this.Controls[cont].Controls[cont2].Controls[cont3].BackColor = System.Drawing.Color.White;
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

		#region Eventos
		#region Troca Protesto
		private void m_lProtestar_Click(object sender, System.EventArgs e)
		{
			if (m_bAtivado)
			{
				m_bAtivado = false;
				OnCallTrocarProtesto();
				OnCallSalvaDadosInterface();
				OnCallCarregaDadosInterface();
				m_bAtivado = true;
			}
		}
		#endregion
		#region Selected Index Changed
		private void m_cbEntregarDocumentos_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (m_bAtivado)
			{
				m_bAtivado = false;
				OnCallSalvaDadosInterface();
				OnCallCarregaDadosInterface();
				m_bAtivado = true;
			}
		}
		#endregion
		#region Cancelar
		private void m_btCancelar_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}
		#endregion
		#region Ok
		private void m_btOk_Click(object sender, System.EventArgs e)
		{
			int nDias =  0;
			try { 
				nDias = Int32.Parse(m_tbDias.Text);
			} 
			catch { nDias = 0; };
			if (nDias > 0)
			{
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				OnCallSalvaDadosInterface();
				OnCallSalvaDadosBD();
				this.Close();
				this.Cursor = System.Windows.Forms.Cursors.Default;
			}
			else
			{
				mdlMensagens.clsMensagens.ShowError("Siscobras", mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.mdlBorderoCobranca_frmFBorderoCobranca_DiasInvalido), System.Windows.Forms.MessageBoxButtons.OK);
			}
		}
		#endregion
		#region Load
		private void frmFBorderoCobranca_Load(object sender, System.EventArgs e)
		{
			m_bAtivado = false;
			OnCallCarregaDadosInterface();
			this.mostraCor();
			m_bAtivado = true;
		}
		#endregion
		#endregion
	}
}
