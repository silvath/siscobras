using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace mdlArmadores.Formularios
{
	/// <summary>
	/// Summary description for frmFNavios.
	/// </summary>
	internal class frmFNavios : System.Windows.Forms.Form
	{
		#region Delegates
			public delegate void delCallNaviosRefresh(int nIdArmador,ref System.Windows.Forms.ListView lvNavios);
			public delegate void delCallNavioCarregaSelecionado(out int nIdNavio);
			public delegate void delCallNavioSalvaSelecionado(int nIdNavio);
			public delegate bool delCallNavioNovo(int nIdArmador);
			public delegate bool delCallNavioEditar(int nIdArmador,int nIdNavio);
			public delegate bool delCallNavioExcluir(int nIdArmador,ref System.Collections.ArrayList arlArmadores,bool bSilent);
			public delegate bool delCallSalvaDados(int nIdArmador,int nIdNavio);
		#endregion
		#region Events
			public event delCallNaviosRefresh eCallNaviosRefresh;	
			public event delCallNavioCarregaSelecionado eCallNavioCarregaSelecionado;	
			public event delCallNavioSalvaSelecionado eCallNavioSalvaSelecionado;	
			public event delCallNavioNovo eCallNavioNovo;	
			public event delCallNavioEditar eCallNavioEditar;	
			public event delCallNavioExcluir eCallNavioExcluir;	
			public event delCallSalvaDados eCallSalvaDados;
		#endregion
		#region Events Methods
			protected virtual void OnCallNaviosRefresh()
			{
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				if (eCallNaviosRefresh != null)
					eCallNaviosRefresh(m_nIdArmador,ref m_lvNavios);
				this.Cursor = System.Windows.Forms.Cursors.Default;
			}

			protected virtual void OnCallNavioCarregaSelecionado()
			{
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				m_lvNavios.SelectedItems.Clear();
				if (eCallNavioCarregaSelecionado != null)
				{
					int nIdNavio;
					eCallNavioCarregaSelecionado(out nIdNavio);
					foreach(System.Windows.Forms.ListViewItem lviNavio in m_lvNavios.Items)
					{
						if (Int32.Parse(lviNavio.Tag.ToString()) == nIdNavio)
						{
							lviNavio.Selected = true;
							break;
						}
					}
				}
				this.Cursor = System.Windows.Forms.Cursors.Default;
			}

			protected virtual void OnCallNavioSalvaSelecionado()
			{
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				if (eCallNavioSalvaSelecionado != null)
				{
					int nIdNavio = -1;
					if (m_lvNavios.SelectedItems.Count > 0)
						nIdNavio = Int32.Parse(m_lvNavios.SelectedItems[0].Tag.ToString());
					eCallNavioSalvaSelecionado(nIdNavio);
				}
				this.Cursor = System.Windows.Forms.Cursors.Default;
			}

			protected virtual bool OnCallNavioNovo()
			{
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				bool bRetorno = false;
				if (eCallNavioNovo != null)
					bRetorno = eCallNavioNovo(m_nIdArmador);
				this.Cursor = System.Windows.Forms.Cursors.Default;
				return(bRetorno);
			}

			protected virtual bool OnCallNavioEditar()
			{
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				bool bRetorno = false;
				if ((eCallNavioEditar != null) && (m_lvNavios.SelectedItems.Count > 0))
					bRetorno = eCallNavioEditar(m_nIdArmador,Int32.Parse(m_lvNavios.SelectedItems[0].Tag.ToString()));
				this.Cursor = System.Windows.Forms.Cursors.Default;
				return(bRetorno);
			}

			protected virtual bool OnCallNavioExcluir()
			{
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				bool bRetorno = false;
				if ((eCallNavioExcluir != null) && (m_lvNavios.SelectedItems.Count > 0))
				{
					System.Collections.ArrayList arlNavios = new ArrayList();
					foreach(System.Windows.Forms.ListViewItem lviNavio in m_lvNavios.SelectedItems)
						arlNavios.Add(Int32.Parse(lviNavio.Tag.ToString()));
					bRetorno = eCallNavioExcluir(m_nIdArmador,ref arlNavios,false);
				}
				this.Cursor = System.Windows.Forms.Cursors.Default;
				return(bRetorno);
			}

			protected virtual bool OnCallSalvaDados()
			{	
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				bool bRetorno = false;
				if ((eCallSalvaDados != null))
				{
					int nIdNavio = -1;
					if (m_lvNavios.SelectedItems.Count > 0)
						nIdNavio = Int32.Parse(m_lvNavios.SelectedItems[0].Tag.ToString());
					bRetorno = eCallSalvaDados(m_nIdArmador,nIdNavio);
				}
				this.Cursor = System.Windows.Forms.Cursors.Default;
				return(bRetorno);
			}
		#endregion

		#region Atributes
			public bool m_bModificado = false;
			private string m_strEnderecoExecutavel = "";

			private int m_nIdArmador = -1;

			private System.Windows.Forms.ToolTip m_ttDicas;
			private System.ComponentModel.IContainer components;
			private System.Windows.Forms.GroupBox m_gbGeral;
			private System.Windows.Forms.Button m_btOk;
			private System.Windows.Forms.Button m_btCancelar;
			private System.Windows.Forms.GroupBox m_gbNavios;
			private System.Windows.Forms.Button m_btExcluir;
			private System.Windows.Forms.Button m_btEditar;
			private System.Windows.Forms.Button m_btNovo;
			private System.Windows.Forms.ListView m_lvNavios;
		#endregion
		#region Constructors and Destructors
			public frmFNavios(string strEnderecoExecutavel,int nIdArmador)
			{
				m_strEnderecoExecutavel = strEnderecoExecutavel;
				m_nIdArmador = nIdArmador;
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmFNavios));
			this.m_gbGeral = new System.Windows.Forms.GroupBox();
			this.m_btOk = new System.Windows.Forms.Button();
			this.m_btCancelar = new System.Windows.Forms.Button();
			this.m_gbNavios = new System.Windows.Forms.GroupBox();
			this.m_btExcluir = new System.Windows.Forms.Button();
			this.m_btEditar = new System.Windows.Forms.Button();
			this.m_btNovo = new System.Windows.Forms.Button();
			this.m_lvNavios = new System.Windows.Forms.ListView();
			this.m_ttDicas = new System.Windows.Forms.ToolTip(this.components);
			this.m_gbGeral.SuspendLayout();
			this.m_gbNavios.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_gbGeral
			// 
			this.m_gbGeral.Controls.Add(this.m_btOk);
			this.m_gbGeral.Controls.Add(this.m_btCancelar);
			this.m_gbGeral.Controls.Add(this.m_gbNavios);
			this.m_gbGeral.Location = new System.Drawing.Point(3, 0);
			this.m_gbGeral.Name = "m_gbGeral";
			this.m_gbGeral.Size = new System.Drawing.Size(277, 210);
			this.m_gbGeral.TabIndex = 2;
			this.m_gbGeral.TabStop = false;
			// 
			// m_btOk
			// 
			this.m_btOk.BackColor = System.Drawing.SystemColors.Control;
			this.m_btOk.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btOk.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btOk.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btOk.Image = ((System.Drawing.Image)(resources.GetObject("m_btOk.Image")));
			this.m_btOk.Location = new System.Drawing.Point(80, 179);
			this.m_btOk.Name = "m_btOk";
			this.m_btOk.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btOk.Size = new System.Drawing.Size(57, 25);
			this.m_btOk.TabIndex = 3;
			this.m_ttDicas.SetToolTip(this.m_btOk, "Confirmar");
			this.m_btOk.Click += new System.EventHandler(this.m_btOk_Click);
			// 
			// m_btCancelar
			// 
			this.m_btCancelar.BackColor = System.Drawing.SystemColors.Control;
			this.m_btCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btCancelar.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btCancelar.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btCancelar.Image = ((System.Drawing.Image)(resources.GetObject("m_btCancelar.Image")));
			this.m_btCancelar.Location = new System.Drawing.Point(144, 179);
			this.m_btCancelar.Name = "m_btCancelar";
			this.m_btCancelar.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btCancelar.Size = new System.Drawing.Size(57, 25);
			this.m_btCancelar.TabIndex = 4;
			this.m_ttDicas.SetToolTip(this.m_btCancelar, "Cancelar");
			this.m_btCancelar.Click += new System.EventHandler(this.m_btCancelar_Click);
			// 
			// m_gbNavios
			// 
			this.m_gbNavios.Controls.Add(this.m_btExcluir);
			this.m_gbNavios.Controls.Add(this.m_btEditar);
			this.m_gbNavios.Controls.Add(this.m_btNovo);
			this.m_gbNavios.Controls.Add(this.m_lvNavios);
			this.m_gbNavios.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_gbNavios.Location = new System.Drawing.Point(7, 9);
			this.m_gbNavios.Name = "m_gbNavios";
			this.m_gbNavios.Size = new System.Drawing.Size(265, 167);
			this.m_gbNavios.TabIndex = 0;
			this.m_gbNavios.TabStop = false;
			this.m_gbNavios.Text = "Navios";
			// 
			// m_btExcluir
			// 
			this.m_btExcluir.BackColor = System.Drawing.SystemColors.Control;
			this.m_btExcluir.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btExcluir.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btExcluir.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btExcluir.Image = ((System.Drawing.Image)(resources.GetObject("m_btExcluir.Image")));
			this.m_btExcluir.Location = new System.Drawing.Point(144, 17);
			this.m_btExcluir.Name = "m_btExcluir";
			this.m_btExcluir.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btExcluir.Size = new System.Drawing.Size(25, 25);
			this.m_btExcluir.TabIndex = 7;
			this.m_btExcluir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.m_ttDicas.SetToolTip(this.m_btExcluir, "Excluir");
			this.m_btExcluir.Click += new System.EventHandler(this.m_btExcluir_Click);
			// 
			// m_btEditar
			// 
			this.m_btEditar.BackColor = System.Drawing.SystemColors.Control;
			this.m_btEditar.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btEditar.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btEditar.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btEditar.Image = ((System.Drawing.Image)(resources.GetObject("m_btEditar.Image")));
			this.m_btEditar.Location = new System.Drawing.Point(116, 17);
			this.m_btEditar.Name = "m_btEditar";
			this.m_btEditar.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btEditar.Size = new System.Drawing.Size(25, 25);
			this.m_btEditar.TabIndex = 6;
			this.m_btEditar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.m_ttDicas.SetToolTip(this.m_btEditar, "Editar");
			this.m_btEditar.Click += new System.EventHandler(this.m_btEditar_Click);
			// 
			// m_btNovo
			// 
			this.m_btNovo.BackColor = System.Drawing.SystemColors.Control;
			this.m_btNovo.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btNovo.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btNovo.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btNovo.Image = ((System.Drawing.Image)(resources.GetObject("m_btNovo.Image")));
			this.m_btNovo.Location = new System.Drawing.Point(88, 17);
			this.m_btNovo.Name = "m_btNovo";
			this.m_btNovo.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btNovo.Size = new System.Drawing.Size(25, 25);
			this.m_btNovo.TabIndex = 5;
			this.m_btNovo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.m_ttDicas.SetToolTip(this.m_btNovo, "Novo");
			this.m_btNovo.Click += new System.EventHandler(this.m_btNovo_Click);
			// 
			// m_lvNavios
			// 
			this.m_lvNavios.HideSelection = false;
			this.m_lvNavios.Location = new System.Drawing.Point(8, 45);
			this.m_lvNavios.Name = "m_lvNavios";
			this.m_lvNavios.Size = new System.Drawing.Size(248, 115);
			this.m_lvNavios.TabIndex = 0;
			this.m_lvNavios.View = System.Windows.Forms.View.List;
			// 
			// frmFNavios
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(282, 216);
			this.Controls.Add(this.m_gbGeral);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmFNavios";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Navios";
			this.Load += new System.EventHandler(this.frmFNavios_Load);
			this.m_gbGeral.ResumeLayout(false);
			this.m_gbNavios.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Eventos
			#region Formulario
				private void frmFNavios_Load(object sender, System.EventArgs e)
				{
					vMostraCor();
					OnCallNaviosRefresh();
					OnCallNavioCarregaSelecionado();
				}
			#endregion
			#region Botoes
				private void m_btNovo_Click(object sender, System.EventArgs e)
				{
					if (OnCallNavioNovo())
						OnCallNaviosRefresh();
				}

				private void m_btEditar_Click(object sender, System.EventArgs e)
				{
					if (OnCallNavioEditar())
						OnCallNaviosRefresh();
				}

				private void m_btExcluir_Click(object sender, System.EventArgs e)
				{
					if (OnCallNavioExcluir())
						OnCallNaviosRefresh();
				}

				private void m_btOk_Click(object sender, System.EventArgs e)
				{
					OnCallNavioSalvaSelecionado();
					if (m_bModificado = OnCallSalvaDados())
						this.Close();
				}

				private void m_btCancelar_Click(object sender, System.EventArgs e)
				{
					this.Close();
				}
			#endregion
		#endregion

		#region Cores
			private void vMostraCor()
			{
				mdlPaletaDeCores.clsPaletaDeCores clsPaletaCores = new mdlPaletaDeCores.clsPaletaDeCores(m_strEnderecoExecutavel + "sisco.ini","SiscobrasCorSecundaria");
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
	}
}
