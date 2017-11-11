using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace mdlCriacaoDocumentos.Assistentes
{
	/// <summary>
	/// Summary description for frmFAssistente.
	/// </summary>
	public class frmFAssistente : System.Windows.Forms.Form
	{
		#region Atributes
			private System.Collections.ArrayList m_arlItens = null;
			private bool m_bConfirm = false;
			private bool m_bModificado = false;

			private bool m_bAutomatic = false;
			private bool m_bForceAllItens = false;

			private System.Windows.Forms.GroupBox m_gbMain;
			private System.Windows.Forms.Button m_btOk;
			private System.Windows.Forms.Button m_btCancelar;
			public System.Windows.Forms.ImageList m_ilBandeiras;
			private System.ComponentModel.IContainer components;
		#endregion
		#region Properties
			public bool Modificado
			{
				get
				{
					return(m_bModificado);
				}
			}

			public bool Confirm
			{
				get
				{
					return(m_bConfirm);
				}
			}

			public bool Automatic
			{
				set
				{
					m_bAutomatic = value;
				}
			}

			public bool ForceAllItens
			{
				set
				{
					m_bForceAllItens = value;
				}
			}
		#endregion
		#region Contructors and Destructors
			public frmFAssistente()
			{
				InitializeComponent();
			}

			public frmFAssistente(ref System.Collections.ArrayList arlItens,string strEnderecoExecutavel)
			{
				m_arlItens = arlItens;
				InitializeComponent();
				vMostraCor(strEnderecoExecutavel);
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmFAssistente));
			this.m_gbMain = new System.Windows.Forms.GroupBox();
			this.m_btOk = new System.Windows.Forms.Button();
			this.m_btCancelar = new System.Windows.Forms.Button();
			this.m_ilBandeiras = new System.Windows.Forms.ImageList(this.components);
			this.m_gbMain.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_gbMain
			// 
			this.m_gbMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_gbMain.Controls.Add(this.m_btOk);
			this.m_gbMain.Controls.Add(this.m_btCancelar);
			this.m_gbMain.Location = new System.Drawing.Point(4, -2);
			this.m_gbMain.Name = "m_gbMain";
			this.m_gbMain.Size = new System.Drawing.Size(284, 286);
			this.m_gbMain.TabIndex = 0;
			this.m_gbMain.TabStop = false;
			// 
			// m_btOk
			// 
			this.m_btOk.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.m_btOk.BackColor = System.Drawing.SystemColors.Control;
			this.m_btOk.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btOk.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btOk.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btOk.Image = ((System.Drawing.Image)(resources.GetObject("m_btOk.Image")));
			this.m_btOk.Location = new System.Drawing.Point(81, 256);
			this.m_btOk.Name = "m_btOk";
			this.m_btOk.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btOk.Size = new System.Drawing.Size(57, 25);
			this.m_btOk.TabIndex = 12;
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
			this.m_btCancelar.Location = new System.Drawing.Point(145, 256);
			this.m_btCancelar.Name = "m_btCancelar";
			this.m_btCancelar.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btCancelar.Size = new System.Drawing.Size(57, 25);
			this.m_btCancelar.TabIndex = 13;
			this.m_btCancelar.Click += new System.EventHandler(this.m_btCancelar_Click);
			// 
			// m_ilBandeiras
			// 
			this.m_ilBandeiras.ImageSize = new System.Drawing.Size(16, 16);
			this.m_ilBandeiras.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("m_ilBandeiras.ImageStream")));
			this.m_ilBandeiras.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// frmFAssistente
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(292, 287);
			this.Controls.Add(this.m_gbMain);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmFAssistente";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Assistente";
			this.Load += new System.EventHandler(this.frmFAssistente_Load);
			this.m_gbMain.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Eventos
			#region Formulario
				private void frmFAssistente_Load(object sender, System.EventArgs e)
				{
					vCreateItens();
					vStartAutomatic();
				}
			#endregion
			#region LinkLabel
				private void llbInserir_Click(object sender, EventArgs e)
				{
					System.Windows.Forms.LinkLabel llbInserir = (System.Windows.Forms.LinkLabel)sender;
					vItemClick(llbInserir.Text);
				}
			#endregion
			#region Botoes
				private void m_btOk_Click(object sender, System.EventArgs e)
				{
					m_bConfirm = true;
					this.Close();
				}

				private void m_btCancelar_Click(object sender, System.EventArgs e)
				{
					m_bConfirm = false;
					this.Close();
				}
			#endregion
		#endregion

		#region Cores
			private void vMostraCor(string strEnderecoExecutavel)
			{
				mdlPaletaDeCores.clsPaletaDeCores clsPaletaCores = new mdlPaletaDeCores.clsPaletaDeCores(strEnderecoExecutavel + "sisco.ini","SiscobrasCorSecundaria");
				this.BackColor = clsPaletaCores.retornaCorAtual();
				System.Windows.Forms.Control ctrControleChild;
				for (int nCont = 0 ;nCont < this.Controls.Count; nCont++)
				{
					ctrControleChild = this.Controls[nCont];
					vPaintControl(ref ctrControleChild,this.BackColor);
				}
			}

			private void vPaintControl(ref System.Windows.Forms.Control ctrControle,System.Drawing.Color clrBackColor)
			{
				switch(ctrControle.GetType().ToString())
				{
					case "mdlComponentesGraficos.ListView":
					case "System.Windows.Forms.ListView":
					case "mdlComponentesGraficos.ComboBox":
					case "mdlComponentesGraficos.TextBox":
						break;

					default:
						ctrControle.BackColor = clrBackColor;
						break;
				}
				System.Windows.Forms.Control ctrControleChild;
				for (int nCont = 0 ;nCont < ctrControle.Controls.Count; nCont++)
				{
					ctrControleChild = ctrControle.Controls[nCont];
					vPaintControl(ref ctrControleChild,clrBackColor);
				}
			}
		#endregion

		#region Automatic
			private void vStartAutomatic()
			{
				if (m_bAutomatic)
				{
					for(int i = 0; i < m_arlItens.Count;i++)
					{
						clsAssistenteItem item = (clsAssistenteItem)m_arlItens[i]; 
						if ((!item.OnCallPreenchido()) || (m_bForceAllItens))
						{
							vItemClick(item.Nome);
							break;
						}
					}
				}
			}
		#endregion
		#region Itens
			private void vCreateItens()
			{
				int nY = 20;
				for(int i = 0; i < m_arlItens.Count;i++)
				{
					clsAssistenteItem objInserir = (clsAssistenteItem)m_arlItens[i];
					System.Windows.Forms.LinkLabel llbInserir = new LinkLabel();
					llbInserir.Name = objInserir.Nome.Replace(" ","");
					llbInserir.Text = objInserir.Nome;
					llbInserir.Font = new System.Drawing.Font("Arial",10,System.Drawing.FontStyle.Bold);
					llbInserir.Top = nY;
					llbInserir.Left = 15;
					llbInserir.Width = 250;
					llbInserir.Click += new EventHandler(llbInserir_Click);
					m_gbMain.Controls.Add(llbInserir);
					nY += 20;
					vPaintItem(llbInserir.Text);
				}
				this.Height = nY + 60;
			}

			private void vPaintItem(string strItem)
			{
				for(int i = 0;i < m_gbMain.Controls.Count;i++)
				{
					System.Windows.Forms.Control ctrlCurrent = m_gbMain.Controls[i];
					if (ctrlCurrent.Text == strItem)
					{
						if (bPreenchidoItem(strItem))
							((System.Windows.Forms.LinkLabel)ctrlCurrent).LinkColor = System.Drawing.Color.Green;
						else
							((System.Windows.Forms.LinkLabel)ctrlCurrent).LinkColor = System.Drawing.Color.Red;
						break;
					}
				}
			}

			private void vItemClick(string strItem)
			{
				if(bShowDialogItem(strItem))
				{
					m_bModificado = true;
					vPaintItem(strItem);
					bool bPass = false;
					for(int i = 0; i < m_arlItens.Count;i++)
					{
						clsAssistenteItem item = (clsAssistenteItem)m_arlItens[i]; 
						if ((bPass))
						{
							if ((!item.OnCallPreenchido()) || (this.m_bForceAllItens))
							{
								vItemClick(item.Nome);
								break;
							}
						}else{
							bPass = (item.Nome == strItem);
						}
					}
					if (m_bAutomatic)
					{
						m_bConfirm = true;
						this.Close();
					}
				}
			}

			private bool bPreenchidoItem(string strItem)
			{
				for(int i = 0; i < m_arlItens.Count;i++)
				{
					clsAssistenteItem item = (clsAssistenteItem)m_arlItens[i];
					if (item.Nome == strItem)
						return(item.OnCallPreenchido());
				}
				return(false);
			}

			private bool bShowDialogItem(string strItem)
			{
				for(int i = 0; i < m_arlItens.Count;i++)
				{
					clsAssistenteItem item = (clsAssistenteItem)m_arlItens[i];
					if (item.Nome == strItem)
						return(item.OnCallShowDialog());
				}
				return(false);
			}			
		#endregion
	}
}
