using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace mdlRelatoriosJanelas
{
	/// <summary>
	/// Summary description for frmFRelatoriosCaneta.
	/// </summary>
	public class frmFRelatoriosCaneta : mdlComponentesGraficos.FormFlutuante
	{
		#region Constantes
		private const int ESTILO_SOLIDO = 1;
		private const int ESTILO_PONTO = 2;
		private const int ESTILO_TRAÇO = 3;
		private const int ESTILO_TRAÇO_PONTO = 4;
		private const int ESTILO_TRAÇO_PONTO_PONTO = 5;
		#endregion
		#region Atributos
		private mdlTratamentoErro.clsTratamentoErro m_cls_ter_tratadorErro; 
		private string m_strEnderecoExecutavel; 
	    private int m_nEspessura; 
	    private System.Drawing.Drawing2D.DashStyle m_styEstilo; 
		private System.Drawing.Color m_corCaneta; 
	    private bool m_bAtivado = false; 
		public bool m_bModificado; 

		internal System.Windows.Forms.GroupBox m_gbGeral;
		internal System.Windows.Forms.VScrollBar m_vsbEspessura;
		internal System.Windows.Forms.Label m_lbEstilo;
		internal System.Windows.Forms.Panel m_pnExemplo;
		internal System.Windows.Forms.Label n_lbEspessura;
		internal System.Windows.Forms.Button m_btOk;
		internal System.Windows.Forms.Button m_btCancelar;
		private System.Windows.Forms.TextBox m_txtEspessura;
		private mdlComponentesGraficos.ComboBox m_cbEstilo;
		internal System.Windows.Forms.PictureBox m_picCaneta;
		internal System.Windows.Forms.Label m_lbCaneta;
		internal System.Windows.Forms.Button m_btCorCaneta;
		private System.ComponentModel.Container components = null;
		#endregion
		#region Constructors and Destructors
		public frmFRelatoriosCaneta(ref mdlTratamentoErro.clsTratamentoErro tratadorErro ,string enderecoExecutavel, int  espessura , System.Drawing.Drawing2D.DashStyle estilo,System.Drawing.Color corCaneta)
		{
	        m_cls_ter_tratadorErro = tratadorErro;
		    m_strEnderecoExecutavel = enderecoExecutavel;
	        m_nEspessura = espessura;
		    m_styEstilo = estilo;
			m_corCaneta = corCaneta;
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmFRelatoriosCaneta));
			this.m_gbGeral = new System.Windows.Forms.GroupBox();
			this.m_picCaneta = new System.Windows.Forms.PictureBox();
			this.m_lbCaneta = new System.Windows.Forms.Label();
			this.m_btCorCaneta = new System.Windows.Forms.Button();
			this.m_cbEstilo = new mdlComponentesGraficos.ComboBox();
			this.m_txtEspessura = new System.Windows.Forms.TextBox();
			this.m_vsbEspessura = new System.Windows.Forms.VScrollBar();
			this.m_lbEstilo = new System.Windows.Forms.Label();
			this.m_pnExemplo = new System.Windows.Forms.Panel();
			this.n_lbEspessura = new System.Windows.Forms.Label();
			this.m_btOk = new System.Windows.Forms.Button();
			this.m_btCancelar = new System.Windows.Forms.Button();
			this.m_gbGeral.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_gbGeral
			// 
			this.m_gbGeral.Controls.Add(this.m_picCaneta);
			this.m_gbGeral.Controls.Add(this.m_lbCaneta);
			this.m_gbGeral.Controls.Add(this.m_btCorCaneta);
			this.m_gbGeral.Controls.Add(this.m_cbEstilo);
			this.m_gbGeral.Controls.Add(this.m_txtEspessura);
			this.m_gbGeral.Controls.Add(this.m_vsbEspessura);
			this.m_gbGeral.Controls.Add(this.m_lbEstilo);
			this.m_gbGeral.Controls.Add(this.m_pnExemplo);
			this.m_gbGeral.Controls.Add(this.n_lbEspessura);
			this.m_gbGeral.Controls.Add(this.m_btOk);
			this.m_gbGeral.Controls.Add(this.m_btCancelar);
			this.m_gbGeral.Location = new System.Drawing.Point(3, -2);
			this.m_gbGeral.Name = "m_gbGeral";
			this.m_gbGeral.Size = new System.Drawing.Size(220, 176);
			this.m_gbGeral.TabIndex = 2;
			this.m_gbGeral.TabStop = false;
			// 
			// m_picCaneta
			// 
			this.m_picCaneta.Image = ((System.Drawing.Image)(resources.GetObject("m_picCaneta.Image")));
			this.m_picCaneta.Location = new System.Drawing.Point(47, 80);
			this.m_picCaneta.Name = "m_picCaneta";
			this.m_picCaneta.Size = new System.Drawing.Size(16, 16);
			this.m_picCaneta.TabIndex = 85;
			this.m_picCaneta.TabStop = false;
			// 
			// m_lbCaneta
			// 
			this.m_lbCaneta.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lbCaneta.Location = new System.Drawing.Point(71, 81);
			this.m_lbCaneta.Name = "m_lbCaneta";
			this.m_lbCaneta.Size = new System.Drawing.Size(120, 16);
			this.m_lbCaneta.TabIndex = 84;
			this.m_lbCaneta.Text = "Traçado";
			// 
			// m_btCorCaneta
			// 
			this.m_btCorCaneta.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.m_btCorCaneta.Location = new System.Drawing.Point(10, 76);
			this.m_btCorCaneta.Name = "m_btCorCaneta";
			this.m_btCorCaneta.Size = new System.Drawing.Size(24, 24);
			this.m_btCorCaneta.TabIndex = 83;
			this.m_btCorCaneta.Click += new System.EventHandler(this.m_btCorCaneta_Click);
			// 
			// m_cbEstilo
			// 
			this.m_cbEstilo.Location = new System.Drawing.Point(72, 48);
			this.m_cbEstilo.Name = "m_cbEstilo";
			this.m_cbEstilo.Size = new System.Drawing.Size(136, 21);
			this.m_cbEstilo.TabIndex = 76;
			this.m_cbEstilo.TextChanged += new System.EventHandler(this.m_cbEstilo_TextChanged);
			// 
			// m_txtEspessura
			// 
			this.m_txtEspessura.Location = new System.Drawing.Point(72, 18);
			this.m_txtEspessura.Name = "m_txtEspessura";
			this.m_txtEspessura.Size = new System.Drawing.Size(112, 20);
			this.m_txtEspessura.TabIndex = 75;
			this.m_txtEspessura.Text = "";
			// 
			// m_vsbEspessura
			// 
			this.m_vsbEspessura.Location = new System.Drawing.Point(190, 18);
			this.m_vsbEspessura.Maximum = 500;
			this.m_vsbEspessura.Name = "m_vsbEspessura";
			this.m_vsbEspessura.Size = new System.Drawing.Size(16, 24);
			this.m_vsbEspessura.TabIndex = 74;
			this.m_vsbEspessura.Value = 1;
			this.m_vsbEspessura.ValueChanged += new System.EventHandler(this.m_vsbEspessura_ValueChanged);
			// 
			// m_lbEstilo
			// 
			this.m_lbEstilo.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lbEstilo.Location = new System.Drawing.Point(7, 54);
			this.m_lbEstilo.Name = "m_lbEstilo";
			this.m_lbEstilo.Size = new System.Drawing.Size(40, 16);
			this.m_lbEstilo.TabIndex = 71;
			this.m_lbEstilo.Text = "Estilo:";
			// 
			// m_pnExemplo
			// 
			this.m_pnExemplo.BackColor = System.Drawing.Color.White;
			this.m_pnExemplo.Location = new System.Drawing.Point(10, 108);
			this.m_pnExemplo.Name = "m_pnExemplo";
			this.m_pnExemplo.Size = new System.Drawing.Size(200, 32);
			this.m_pnExemplo.TabIndex = 70;
			// 
			// n_lbEspessura
			// 
			this.n_lbEspessura.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.n_lbEspessura.Location = new System.Drawing.Point(6, 22);
			this.n_lbEspessura.Name = "n_lbEspessura";
			this.n_lbEspessura.Size = new System.Drawing.Size(63, 16);
			this.n_lbEspessura.TabIndex = 69;
			this.n_lbEspessura.Text = "Espessura:";
			// 
			// m_btOk
			// 
			this.m_btOk.BackColor = System.Drawing.SystemColors.Control;
			this.m_btOk.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btOk.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btOk.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btOk.Image = ((System.Drawing.Image)(resources.GetObject("m_btOk.Image")));
			this.m_btOk.Location = new System.Drawing.Point(50, 145);
			this.m_btOk.Name = "m_btOk";
			this.m_btOk.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btOk.Size = new System.Drawing.Size(57, 25);
			this.m_btOk.TabIndex = 66;
			this.m_btOk.Click += new System.EventHandler(this.m_btOk_Click);
			// 
			// m_btCancelar
			// 
			this.m_btCancelar.BackColor = System.Drawing.SystemColors.Control;
			this.m_btCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btCancelar.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btCancelar.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btCancelar.Image = ((System.Drawing.Image)(resources.GetObject("m_btCancelar.Image")));
			this.m_btCancelar.Location = new System.Drawing.Point(114, 145);
			this.m_btCancelar.Name = "m_btCancelar";
			this.m_btCancelar.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btCancelar.Size = new System.Drawing.Size(57, 25);
			this.m_btCancelar.TabIndex = 67;
			this.m_btCancelar.Click += new System.EventHandler(this.m_btCancelar_Click);
			// 
			// frmFRelatoriosCaneta
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(226, 176);
			this.Controls.Add(this.m_gbGeral);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.HelpButton = true;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmFRelatoriosCaneta";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Traçado";
			this.Load += new System.EventHandler(this.frmFRelatoriosCaneta_Load);
			this.m_gbGeral.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Eventos
			#region Formulario
				private void frmFRelatoriosCaneta_Load(object sender, System.EventArgs e)
				{
					MostraCor();
					RefreshEstilos();
					RefreshInterface();
				}
			#endregion
			#region Diversos
				private void m_vsbEspessura_ValueChanged(object sender, System.EventArgs e)
				{
					if (m_bAtivado)
					{
						if (m_vsbEspessura.Value > 1)
						{
							if (m_nEspessura > 1)
								m_nEspessura--;
						}
						else
						{
							if (m_nEspessura < 10)
								m_nEspessura++;
						}
						m_bAtivado = false;
						m_vsbEspessura.Value = 1;
						m_bAtivado = true;
						m_txtEspessura.Text = m_nEspessura.ToString();
						RefreshExemplo();
					}
				}

				private void m_cbEstilo_TextChanged(object sender, System.EventArgs e)
				{
                    Object obj = m_cbEstilo.ReturnObjectSelectedItem();
					if (obj != null)
					{
						switch(Int32.Parse(obj.ToString()))
						{
			                case ESTILO_SOLIDO:
						        m_styEstilo = System.Drawing.Drawing2D.DashStyle.Solid;
								break;
							case ESTILO_PONTO:
								m_styEstilo = System.Drawing.Drawing2D.DashStyle.Dot;
								break;
							case ESTILO_TRAÇO:
								m_styEstilo = System.Drawing.Drawing2D.DashStyle.Dash;
								break;
							case ESTILO_TRAÇO_PONTO:
								m_styEstilo = System.Drawing.Drawing2D.DashStyle.DashDot;
								break;
							case ESTILO_TRAÇO_PONTO_PONTO:
								m_styEstilo = System.Drawing.Drawing2D.DashStyle.DashDotDot;
								break;
						}
						RefreshExemplo();
					}
				}
			#endregion
			#region Botoes
				private void m_btCorCaneta_Click(object sender, System.EventArgs e)
				{
					System.Windows.Forms.ColorDialog dlgColor = new System.Windows.Forms.ColorDialog();
					dlgColor.FullOpen = true;
					dlgColor.Color = m_corCaneta;
					if (dlgColor.ShowDialog() == System.Windows.Forms.DialogResult.OK)
					{
						m_corCaneta = dlgColor.Color;
						RefreshInterface();
						RefreshExemplo();
					}
			
				}

				private void m_btOk_Click(object sender, System.EventArgs e)
				{
					m_bModificado = true;
					this.Close();
				}

				private void m_btCancelar_Click(object sender, System.EventArgs e)
				{
					m_bModificado = false;
					this.Close();
				}
			#endregion
		#endregion
		#region Cores
		private void MostraCor()
		{
			mdlPaletaDeCores.clsPaletaDeCores clsPaletaCores = new mdlPaletaDeCores.clsPaletaDeCores(m_strEnderecoExecutavel + "sisco.ini","SiscobrasCorSecundaria");
			this.BackColor = clsPaletaCores.retornaCorAtual();
			for (int nCont = 0 ;nCont < this.Controls.Count; nCont++)
			{
				this.Controls[nCont].BackColor = this.BackColor;
				for (int nCont2 = 0 ;nCont2 < this.Controls[nCont].Controls.Count; nCont2++)
				{
					if ((this.Controls[nCont].Controls[nCont2].GetType().ToString() != "mdlComponentesGraficos.ComboBox") && (this.Controls[nCont].Controls[nCont2].GetType().ToString() != "System.Windows.Forms.TextBox"))
						this.Controls[nCont].Controls[nCont2].BackColor = this.BackColor;

					for (int nCont3 = 0 ;nCont3 < this.Controls[nCont].Controls[nCont2].Controls.Count; nCont3++)
					{
						if ((this.Controls[nCont].Controls[nCont2].Controls[nCont3].GetType().ToString() != "mdlComponentes.compListView") && (this.Controls[nCont].Controls[nCont2].Controls[nCont3].GetType().ToString() != "System.Windows.Forms.TreeView"))
							this.Controls[nCont].Controls[nCont2].Controls[nCont3].BackColor = this.BackColor;
					}
				}
			}
		}
		#endregion

		#region Refreshs
			private void RefreshEstilos()
			{
				m_cbEstilo.Clear();
	            m_cbEstilo.AddItem("Sólido", ESTILO_SOLIDO);
				m_cbEstilo.AddItem("Ponto", ESTILO_PONTO);
				m_cbEstilo.AddItem("Traço", ESTILO_TRAÇO);
				m_cbEstilo.AddItem("Traço-Ponto", ESTILO_TRAÇO_PONTO);
				m_cbEstilo.AddItem("Traço-Ponto-Ponto", ESTILO_TRAÇO_PONTO_PONTO);
			}
			
			private void  RefreshInterface()
			{
				m_bAtivado = false;
				m_txtEspessura.Text = m_nEspessura.ToString();
				switch(m_styEstilo)
				{
					case System.Drawing.Drawing2D.DashStyle.Solid:
						m_cbEstilo.SelectItem(ESTILO_SOLIDO);
						break;
					case System.Drawing.Drawing2D.DashStyle.Dot:
						m_cbEstilo.SelectItem(ESTILO_PONTO);
						break;
					case System.Drawing.Drawing2D.DashStyle.Dash:
						m_cbEstilo.SelectItem(ESTILO_TRAÇO);
						break;
					case System.Drawing.Drawing2D.DashStyle.DashDot:
						m_cbEstilo.SelectItem(ESTILO_TRAÇO_PONTO);
						break;
					case System.Drawing.Drawing2D.DashStyle.DashDotDot:
						m_cbEstilo.SelectItem(ESTILO_TRAÇO_PONTO_PONTO);
						break;
					default:
						m_cbEstilo.SelectItem(ESTILO_SOLIDO);
						break;
				}
				m_btCorCaneta.BackColor = m_corCaneta;		
				m_bAtivado = true;
			}

			private void RefreshExemplo()
			{
				System.Drawing.Graphics graf;
				System.Drawing.Pen caneta;
				System.Drawing.Bitmap imagem = new System.Drawing.Bitmap(m_pnExemplo.Width, m_pnExemplo.Height);
	            graf = System.Drawing.Graphics.FromImage(imagem);
				caneta = new System.Drawing.Pen(m_corCaneta, m_nEspessura);
				caneta.DashStyle = m_styEstilo;
				graf.FillRectangle(new System.Drawing.SolidBrush(System.Drawing.Color.White), 0, 0, m_pnExemplo.Width, m_pnExemplo.Height);
				graf.DrawLine(caneta, 5, ((int)m_pnExemplo.Height / 2), ((int)m_pnExemplo.Width - 10), ((int)m_pnExemplo.Height / 2));
				graf = null;
				m_pnExemplo.BackgroundImage = (System.Drawing.Image)imagem.Clone();
				imagem = null;
			}
		#endregion 
		#region Retorno
			public void RetornaValores(out int espessura,out System.Drawing.Drawing2D.DashStyle estilo,out System.Drawing.Color corCaneta)
			{
				espessura = m_nEspessura;
				estilo = m_styEstilo;
				corCaneta = m_corCaneta;
			}
		#endregion

	}
}
