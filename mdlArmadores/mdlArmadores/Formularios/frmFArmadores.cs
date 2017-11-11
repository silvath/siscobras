using System;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace mdlArmadores.Formularios
{
	/// <summary>
	/// Summary description for frmFArmadores.
	/// </summary>
	internal class frmFArmadores : System.Windows.Forms.Form
	{
		#region Delegates
			public delegate void delCallArmadoresRefresh(ref System.Windows.Forms.ListView lvArmadores);
			public delegate void delCallArmadoresCarregaSelecionado(out int nIdArmador);
			public delegate void delCallArmadoresSalvaSelecionado(int nIdArmador);
			public delegate bool delCallArmadoresNovo();
			public delegate bool delCallArmadoresEditar(int nIdArmador);
			public delegate bool delCallArmadoresExcluir(ref System.Collections.ArrayList arlArmadores,bool bSilent);
			public delegate bool delCallArmadoresNavios(int nIdArmador);
			public delegate bool delCallSalvaDados();
		#endregion
		#region Events
			public event delCallArmadoresRefresh eCallArmadoresRefresh;	
			public event delCallArmadoresCarregaSelecionado eCallArmadoresCarregaSelecionado;	
			public event delCallArmadoresSalvaSelecionado eCallArmadoresSalvaSelecionado;	
			public event delCallArmadoresNovo eCallArmadoresNovo;	
			public event delCallArmadoresEditar eCallArmadoresEditar;	
			public event delCallArmadoresExcluir eCallArmadoresExcluir;	
			public event delCallArmadoresNavios eCallArmadoresNavios;	
			public event delCallSalvaDados eCallSalvaDados;
		#endregion
		#region Events Methods
			protected virtual void OnCallArmadoresRefresh()
			{
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				if (eCallArmadoresRefresh != null)
				{
					eCallArmadoresRefresh(ref m_lvArmadores);
				}
				this.Cursor = System.Windows.Forms.Cursors.Default;
			}

			protected virtual void OnCallArmadoresCarregaSelecionado()
			{
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				m_lvArmadores.SelectedItems.Clear();
				if (eCallArmadoresCarregaSelecionado != null)
				{
					int nIdArmador;
					eCallArmadoresCarregaSelecionado(out nIdArmador);
					foreach(System.Windows.Forms.ListViewItem lviArmador in m_lvArmadores.Items)
					{
						if (Int32.Parse(lviArmador.Tag.ToString()) == nIdArmador)
						{
							lviArmador.Selected = true;
							break;
						}
					}
				}
				this.Cursor = System.Windows.Forms.Cursors.Default;
			}

			protected virtual void OnCallArmadoresSalvaSelecionado()
			{
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				if (eCallArmadoresSalvaSelecionado != null)
				{
					int nIdArmador = -1;
					if (m_lvArmadores.SelectedItems.Count > 0)
						nIdArmador = Int32.Parse(m_lvArmadores.SelectedItems[0].Tag.ToString());
					eCallArmadoresSalvaSelecionado(nIdArmador);
				}
				this.Cursor = System.Windows.Forms.Cursors.Default;
			}

			protected virtual bool OnCallArmadoresNovo()
			{
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				bool bRetorno = false;
				if (eCallArmadoresNovo != null)
					bRetorno = eCallArmadoresNovo();
				this.Cursor = System.Windows.Forms.Cursors.Default;
				return(bRetorno);
			}

			protected virtual bool OnCallArmadoresEditar()
			{
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				bool bRetorno = false;
				if ((eCallArmadoresEditar != null) && (m_lvArmadores.SelectedItems.Count > 0))
					bRetorno = eCallArmadoresEditar(Int32.Parse(m_lvArmadores.SelectedItems[0].Tag.ToString()));
				this.Cursor = System.Windows.Forms.Cursors.Default;
				return(bRetorno);
			}

			protected virtual bool OnCallArmadoresExcluir()
			{
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				bool bRetorno = false;
				if ((eCallArmadoresExcluir != null) && (m_lvArmadores.SelectedItems.Count > 0))
				{
					System.Collections.ArrayList arlArmadores = new ArrayList();
					foreach(System.Windows.Forms.ListViewItem lviArmadores in m_lvArmadores.SelectedItems)
						arlArmadores.Add(Int32.Parse(lviArmadores.Tag.ToString()));
					bRetorno = eCallArmadoresExcluir(ref arlArmadores,false);
				}
				this.Cursor = System.Windows.Forms.Cursors.Default;
				return(bRetorno);
			}

			protected virtual void OnCallArmadoresNavios()
			{
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				if ((eCallArmadoresNavios != null) && (m_lvArmadores.SelectedItems.Count > 0))
					eCallArmadoresNavios(Int32.Parse(m_lvArmadores.SelectedItems[0].Tag.ToString()));
				this.Cursor = System.Windows.Forms.Cursors.Default;
			}

			protected virtual bool OnCallSalvaDados()
			{	
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				bool bRetorno = false;
				if (eCallSalvaDados != null)
					bRetorno = eCallSalvaDados();
				this.Cursor = System.Windows.Forms.Cursors.Default;
				return(bRetorno);
			}
		#endregion

		#region Atributes
			public bool m_bModificado = false;
			private string m_strEnderecoExecutavel = "";

			private System.Windows.Forms.ToolTip m_ttDicas;
			private System.ComponentModel.IContainer components;
			private System.Windows.Forms.GroupBox m_gbGeral;
			private System.Windows.Forms.Button m_btOk;
			private System.Windows.Forms.Button m_btCancelar;
			private System.Windows.Forms.Button m_btExcluir;
			private System.Windows.Forms.Button m_btEditar;
			private System.Windows.Forms.Button m_btNovo;
			private System.Windows.Forms.GroupBox m_gbArmadores;
			private System.Windows.Forms.Button m_btNavios;
			private System.Windows.Forms.ListView m_lvArmadores;
		#endregion
		#region Constructors and Destructors
			public frmFArmadores(string strEnderecoExecutavel)
			{
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmFArmadores));
			this.m_gbGeral = new System.Windows.Forms.GroupBox();
			this.m_btOk = new System.Windows.Forms.Button();
			this.m_btCancelar = new System.Windows.Forms.Button();
			this.m_gbArmadores = new System.Windows.Forms.GroupBox();
			this.m_btNavios = new System.Windows.Forms.Button();
			this.m_btExcluir = new System.Windows.Forms.Button();
			this.m_btEditar = new System.Windows.Forms.Button();
			this.m_btNovo = new System.Windows.Forms.Button();
			this.m_lvArmadores = new System.Windows.Forms.ListView();
			this.m_ttDicas = new System.Windows.Forms.ToolTip(this.components);
			this.m_gbGeral.SuspendLayout();
			this.m_gbArmadores.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_gbGeral
			// 
			this.m_gbGeral.Controls.Add(this.m_btOk);
			this.m_gbGeral.Controls.Add(this.m_btCancelar);
			this.m_gbGeral.Controls.Add(this.m_gbArmadores);
			this.m_gbGeral.Location = new System.Drawing.Point(3, -1);
			this.m_gbGeral.Name = "m_gbGeral";
			this.m_gbGeral.Size = new System.Drawing.Size(308, 312);
			this.m_gbGeral.TabIndex = 1;
			this.m_gbGeral.TabStop = false;
			// 
			// m_btOk
			// 
			this.m_btOk.BackColor = System.Drawing.SystemColors.Control;
			this.m_btOk.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btOk.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btOk.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btOk.Image = ((System.Drawing.Image)(resources.GetObject("m_btOk.Image")));
			this.m_btOk.Location = new System.Drawing.Point(100, 282);
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
			this.m_btCancelar.Location = new System.Drawing.Point(164, 282);
			this.m_btCancelar.Name = "m_btCancelar";
			this.m_btCancelar.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btCancelar.Size = new System.Drawing.Size(57, 25);
			this.m_btCancelar.TabIndex = 4;
			this.m_ttDicas.SetToolTip(this.m_btCancelar, "Excluir");
			this.m_btCancelar.Click += new System.EventHandler(this.m_btCancelar_Click);
			// 
			// m_gbArmadores
			// 
			this.m_gbArmadores.Controls.Add(this.m_btNavios);
			this.m_gbArmadores.Controls.Add(this.m_btExcluir);
			this.m_gbArmadores.Controls.Add(this.m_btEditar);
			this.m_gbArmadores.Controls.Add(this.m_btNovo);
			this.m_gbArmadores.Controls.Add(this.m_lvArmadores);
			this.m_gbArmadores.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_gbArmadores.Location = new System.Drawing.Point(7, 9);
			this.m_gbArmadores.Name = "m_gbArmadores";
			this.m_gbArmadores.Size = new System.Drawing.Size(297, 271);
			this.m_gbArmadores.TabIndex = 0;
			this.m_gbArmadores.TabStop = false;
			this.m_gbArmadores.Text = "Armadores";
			// 
			// m_btNavios
			// 
			this.m_btNavios.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.m_btNavios.BackColor = System.Drawing.SystemColors.Control;
			this.m_btNavios.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btNavios.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btNavios.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btNavios.Image = ((System.Drawing.Image)(resources.GetObject("m_btNavios.Image")));
			this.m_btNavios.Location = new System.Drawing.Point(264, 17);
			this.m_btNavios.Name = "m_btNavios";
			this.m_btNavios.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btNavios.Size = new System.Drawing.Size(25, 25);
			this.m_btNavios.TabIndex = 8;
			this.m_btNavios.Text = "N";
			this.m_btNavios.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.m_ttDicas.SetToolTip(this.m_btNavios, "Navios");
			this.m_btNavios.Click += new System.EventHandler(this.m_btNavios_Click);
			// 
			// m_btExcluir
			// 
			this.m_btExcluir.BackColor = System.Drawing.SystemColors.Control;
			this.m_btExcluir.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btExcluir.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btExcluir.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btExcluir.Image = ((System.Drawing.Image)(resources.GetObject("m_btExcluir.Image")));
			this.m_btExcluir.Location = new System.Drawing.Point(168, 16);
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
			this.m_btEditar.Location = new System.Drawing.Point(136, 16);
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
			this.m_btNovo.Location = new System.Drawing.Point(104, 16);
			this.m_btNovo.Name = "m_btNovo";
			this.m_btNovo.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btNovo.Size = new System.Drawing.Size(25, 25);
			this.m_btNovo.TabIndex = 5;
			this.m_btNovo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.m_ttDicas.SetToolTip(this.m_btNovo, "Novo");
			this.m_btNovo.Click += new System.EventHandler(this.m_btNovo_Click);
			// 
			// m_lvArmadores
			// 
			this.m_lvArmadores.HideSelection = false;
			this.m_lvArmadores.Location = new System.Drawing.Point(8, 45);
			this.m_lvArmadores.Name = "m_lvArmadores";
			this.m_lvArmadores.Size = new System.Drawing.Size(280, 216);
			this.m_lvArmadores.TabIndex = 0;
			this.m_lvArmadores.View = System.Windows.Forms.View.List;
			// 
			// m_ttDicas
			// 
			this.m_ttDicas.AutomaticDelay = 100;
			this.m_ttDicas.AutoPopDelay = 5000;
			this.m_ttDicas.InitialDelay = 100;
			this.m_ttDicas.ReshowDelay = 20;
			// 
			// frmFArmadores
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(314, 312);
			this.Controls.Add(this.m_gbGeral);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmFArmadores";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Armadores";
			this.Load += new System.EventHandler(this.frmFArmadores_Load);
			this.m_gbGeral.ResumeLayout(false);
			this.m_gbArmadores.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Eventos
			#region Formulario
				private void frmFArmadores_Load(object sender, System.EventArgs e)
				{
					vMostraCor();
					OnCallArmadoresRefresh();
					OnCallArmadoresCarregaSelecionado();
				}
			#endregion
			#region Botoes
				private void m_btNovo_Click(object sender, System.EventArgs e)
				{
					if (OnCallArmadoresNovo())
						OnCallArmadoresRefresh();
				}

				private void m_btEditar_Click(object sender, System.EventArgs e)
				{
					if (OnCallArmadoresEditar())
						OnCallArmadoresRefresh();
				}

				private void m_btExcluir_Click(object sender, System.EventArgs e)
				{
					if (OnCallArmadoresExcluir())
						OnCallArmadoresRefresh();
				}

				private void m_btNavios_Click(object sender, System.EventArgs e)
				{
					OnCallArmadoresNavios();
				}

				private void m_btOk_Click(object sender, System.EventArgs e)
				{
					OnCallArmadoresSalvaSelecionado();
					if (OnCallSalvaDados())
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
