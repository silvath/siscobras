using System;
using System.Collections;
using System.Windows.Forms;

namespace mdlMoeda
{
	/// <summary>
	/// Summary description for frmFMoeda.
	/// </summary>
	internal class frmFMoeda : mdlComponentesGraficos.FormFlutuante
	{
		
		#region Atributos
			private string m_strEnderecoExecutavel = "";
			private System.ComponentModel.IContainer components;
			private System.Windows.Forms.GroupBox m_gbFrame;
			private System.Windows.Forms.ListView m_lvMoedas;
			internal System.Windows.Forms.ColumnHeader ColumnHeader1;
			internal System.Windows.Forms.ColumnHeader ColumnHeader2;
			private System.Windows.Forms.Button m_btOk;
			private System.Windows.Forms.Button m_btCancelar;
			private System.Windows.Forms.Button m_btTrocaCor;
			private System.Windows.Forms.GroupBox m_gbFields;
			private System.Windows.Forms.CheckBox m_ckMostrarSimbolo;
			private System.Windows.Forms.ToolTip m_ttMoedas;
		    public bool m_bModificado = false;
			// ***************************************************************************************************
		#endregion
		#region Delegates
			public delegate bool delCallMostrarQuestionamentoSimboloMoeda();
		    public delegate void delCallRefreshMoedas(ref System.Windows.Forms.ListView lvMoedas);
		    public delegate void delCallCarregaMoeda();
			public delegate void delCallCarregaInterace(ref System.Windows.Forms.ListView lvMoedas,out bool bMostrarSimboloMoeda);
			public delegate void delCallSalvaInterface(ref System.Windows.Forms.ListView lvMoedas,bool bMostrarSimboloMoeda);
			public delegate void delCallSalvaMoeda();
		#endregion
		#region Events
			public event delCallMostrarQuestionamentoSimboloMoeda eCallMostrarQuestionamentoSimboloMoeda;
			public event delCallRefreshMoedas eCallRefreshMoedas;
			public event delCallCarregaMoeda eCallCarregaMoeda;
			public event delCallCarregaInterace eCallCarregaInterace; 
			public event delCallSalvaInterface eCallSalvaInterface;
			public event delCallSalvaMoeda eCallSalvaMoeda;
		#endregion
		#region Events Methods
			protected virtual bool OnCallMostrarQuestionamentoSimboloMoeda()
			{
				bool bRetorno = false;
				if (eCallMostrarQuestionamentoSimboloMoeda != null)
					bRetorno = eCallMostrarQuestionamentoSimboloMoeda();
				return(bRetorno);
			} 

			protected virtual void OnCallRefreshMoedas()
			{
				if (eCallRefreshMoedas != null)
					eCallRefreshMoedas(ref this.m_lvMoedas);
			} 

			protected virtual void OnCallCarregaMoeda()
			{
				if (eCallCarregaMoeda != null)
					eCallCarregaMoeda();
			} 

			protected virtual void OnCallCarregaInterace()
			{
				if (eCallCarregaInterace != null)
				{
					bool bMostrarSimboloMoeda;
					eCallCarregaInterace(ref this.m_lvMoedas,out bMostrarSimboloMoeda);
					m_ckMostrarSimbolo.Checked = bMostrarSimboloMoeda;
				}
			} 

			protected virtual void OnCallSalvaInterface()
			{
				if (eCallSalvaInterface != null)
				{
					eCallSalvaInterface (ref this.m_lvMoedas,m_ckMostrarSimbolo.Checked);
				}
			} 

			protected virtual void OnCallSalvaMoeda()
			{
				if (eCallSalvaMoeda != null)
					eCallSalvaMoeda();
			} 
		#endregion
		#region Constructor e Destructor
			public frmFMoeda(string strEnderecoExecutavel)
			{
				m_strEnderecoExecutavel = strEnderecoExecutavel;
				//
				// Required for Windows Form Designer support
				//
				InitializeComponent();

				//
				// TODO: Add any constructor code after InitializeComponent call
				//
				MostraCor();
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
		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmFMoeda));
			this.m_gbFrame = new System.Windows.Forms.GroupBox();
			this.m_ckMostrarSimbolo = new System.Windows.Forms.CheckBox();
			this.m_btTrocaCor = new System.Windows.Forms.Button();
			this.m_btOk = new System.Windows.Forms.Button();
			this.m_btCancelar = new System.Windows.Forms.Button();
			this.m_gbFields = new System.Windows.Forms.GroupBox();
			this.m_lvMoedas = new System.Windows.Forms.ListView();
			this.ColumnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.ColumnHeader2 = new System.Windows.Forms.ColumnHeader();
			this.m_ttMoedas = new System.Windows.Forms.ToolTip(this.components);
			this.m_gbFrame.SuspendLayout();
			this.m_gbFields.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_gbFrame
			// 
			this.m_gbFrame.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_gbFrame.Controls.Add(this.m_ckMostrarSimbolo);
			this.m_gbFrame.Controls.Add(this.m_btTrocaCor);
			this.m_gbFrame.Controls.Add(this.m_btOk);
			this.m_gbFrame.Controls.Add(this.m_btCancelar);
			this.m_gbFrame.Controls.Add(this.m_gbFields);
			this.m_gbFrame.Location = new System.Drawing.Point(2, 0);
			this.m_gbFrame.Name = "m_gbFrame";
			this.m_gbFrame.Size = new System.Drawing.Size(246, 270);
			this.m_gbFrame.TabIndex = 0;
			this.m_gbFrame.TabStop = false;
			// 
			// m_ckMostrarSimbolo
			// 
			this.m_ckMostrarSimbolo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_ckMostrarSimbolo.Location = new System.Drawing.Point(9, 219);
			this.m_ckMostrarSimbolo.Name = "m_ckMostrarSimbolo";
			this.m_ckMostrarSimbolo.Size = new System.Drawing.Size(176, 16);
			this.m_ckMostrarSimbolo.TabIndex = 69;
			this.m_ckMostrarSimbolo.Text = "Mostrar símbolo moeda.";
			this.m_ttMoedas.SetToolTip(this.m_ckMostrarSimbolo, "Mostrar símbolo anexo aos valores");
			// 
			// m_btTrocaCor
			// 
			this.m_btTrocaCor.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(64)), ((System.Byte)(0)));
			this.m_btTrocaCor.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btTrocaCor.Location = new System.Drawing.Point(3, 8);
			this.m_btTrocaCor.Name = "m_btTrocaCor";
			this.m_btTrocaCor.Size = new System.Drawing.Size(4, 4);
			this.m_btTrocaCor.TabIndex = 68;
			this.m_ttMoedas.SetToolTip(this.m_btTrocaCor, "Cor");
			this.m_btTrocaCor.Click += new System.EventHandler(this.btTrocarCor_Click);
			// 
			// m_btOk
			// 
			this.m_btOk.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.m_btOk.BackColor = System.Drawing.SystemColors.Control;
			this.m_btOk.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btOk.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btOk.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btOk.Image = ((System.Drawing.Image)(resources.GetObject("m_btOk.Image")));
			this.m_btOk.Location = new System.Drawing.Point(63, 239);
			this.m_btOk.Name = "m_btOk";
			this.m_btOk.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btOk.Size = new System.Drawing.Size(57, 25);
			this.m_btOk.TabIndex = 66;
			this.m_ttMoedas.SetToolTip(this.m_btOk, "Confirmar");
			this.m_btOk.Click += new System.EventHandler(this.btOk_Click);
			// 
			// m_btCancelar
			// 
			this.m_btCancelar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.m_btCancelar.BackColor = System.Drawing.SystemColors.Control;
			this.m_btCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btCancelar.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btCancelar.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btCancelar.Image = ((System.Drawing.Image)(resources.GetObject("m_btCancelar.Image")));
			this.m_btCancelar.Location = new System.Drawing.Point(127, 239);
			this.m_btCancelar.Name = "m_btCancelar";
			this.m_btCancelar.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btCancelar.Size = new System.Drawing.Size(57, 25);
			this.m_btCancelar.TabIndex = 67;
			this.m_ttMoedas.SetToolTip(this.m_btCancelar, "Cancelar");
			this.m_btCancelar.Click += new System.EventHandler(this.btCancelar_Click);
			// 
			// m_gbFields
			// 
			this.m_gbFields.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_gbFields.Controls.Add(this.m_lvMoedas);
			this.m_gbFields.Location = new System.Drawing.Point(8, 8);
			this.m_gbFields.Name = "m_gbFields";
			this.m_gbFields.Size = new System.Drawing.Size(229, 208);
			this.m_gbFields.TabIndex = 59;
			this.m_gbFields.TabStop = false;
			// 
			// m_lvMoedas
			// 
			this.m_lvMoedas.Activation = System.Windows.Forms.ItemActivation.OneClick;
			this.m_lvMoedas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_lvMoedas.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																						 this.ColumnHeader1,
																						 this.ColumnHeader2});
			this.m_lvMoedas.FullRowSelect = true;
			this.m_lvMoedas.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
			this.m_lvMoedas.HideSelection = false;
			this.m_lvMoedas.Location = new System.Drawing.Point(8, 13);
			this.m_lvMoedas.MultiSelect = false;
			this.m_lvMoedas.Name = "m_lvMoedas";
			this.m_lvMoedas.Size = new System.Drawing.Size(212, 187);
			this.m_lvMoedas.TabIndex = 1;
			this.m_ttMoedas.SetToolTip(this.m_lvMoedas, "Selecionar moeda");
			this.m_lvMoedas.View = System.Windows.Forms.View.Details;
			this.m_lvMoedas.DoubleClick += new System.EventHandler(this.m_lvMoedas_DoubleClick);
			// 
			// ColumnHeader1
			// 
			this.ColumnHeader1.Width = 180;
			// 
			// ColumnHeader2
			// 
			this.ColumnHeader2.Width = 0;
			// 
			// m_ttMoedas
			// 
			this.m_ttMoedas.AutomaticDelay = 100;
			this.m_ttMoedas.AutoPopDelay = 5000;
			this.m_ttMoedas.InitialDelay = 100;
			this.m_ttMoedas.ReshowDelay = 20;
			// 
			// frmFMoeda
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(250, 272);
			this.Controls.Add(this.m_gbFrame);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmFMoeda";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Moedas";
			this.Load += new System.EventHandler(this.frmFMoeda_Load);
			this.m_gbFrame.ResumeLayout(false);
			this.m_gbFields.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Eventos
			private void frmFMoeda_Load(object sender, System.EventArgs e)
			{
				m_ckMostrarSimbolo.Visible = OnCallMostrarQuestionamentoSimboloMoeda();
				OnCallRefreshMoedas();
				OnCallCarregaMoeda();
				OnCallCarregaInterace();
			}

			private void m_lvMoedas_DoubleClick(object sender, System.EventArgs e)
			{
				if (m_lvMoedas.SelectedItems.Count > 0)
				{
					OnCallSalvaInterface();
					OnCallSalvaMoeda();
					m_bModificado = true;
					this.Close();
				}
			}

			private void m_lvMoedas_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
			{
				if (m_lvMoedas.SelectedItems.Count > 0)
				{
					OnCallSalvaInterface();
					OnCallSalvaMoeda();
					m_bModificado = true;
					this.Close();
				}
			}

			private void btOk_Click(object sender, System.EventArgs e)
			{
				if (m_lvMoedas.SelectedItems.Count == 1)
				{
					OnCallSalvaInterface();
					OnCallSalvaMoeda();
					m_bModificado = true;
					this.Close();
				}
				else
				{
					mdlMensagens.clsMensagens.ShowInformation(this.Text,mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.mdlMoeda_frmFMoeda_SelecionarUmaMoeda));
				}
			}

			private void btCancelar_Click(object sender, System.EventArgs e)
			{
				m_bModificado = false;
				this.Close();
			}
		#endregion

		#region Cores
			private void btTrocarCor_Click(object sender, System.EventArgs e)
			{
				TrocaCor();
			}

			private void MostraCor()
			{
				mdlPaletaDeCores.clsPaletaDeCores modPaletaCores = new mdlPaletaDeCores.clsPaletaDeCores(m_strEnderecoExecutavel + "sisco.ini", "SiscobrasCorSecundaria");
				this.BackColor = modPaletaCores.retornaCorAtual();
				for(int nCont = 0; nCont < this.Controls.Count;nCont++)
				{
					this.Controls[nCont].BackColor = this.BackColor;
					for(int nCont2 = 0 ;nCont2 < this.Controls[nCont].Controls.Count;nCont2++)
					{
						if (this.Controls[nCont].Controls[nCont2].GetType().ToString() != "System.Windows.Forms.ListView")
							this.Controls[nCont].Controls[nCont2].BackColor = this.BackColor;
					}
				}
			}

			private void TrocaCor()
			{
				mdlPaletaDeCores.clsPaletaDeCores modPaletaCores = new mdlPaletaDeCores.clsPaletaDeCores(m_strEnderecoExecutavel + "sisco.ini", "SiscobrasCorSecundaria");
				modPaletaCores.mostraCorAtual();
				MostraCor();
			}
		#endregion

	}
}
