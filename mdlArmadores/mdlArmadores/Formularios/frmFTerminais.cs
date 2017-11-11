using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace mdlArmadores.Formularios
{
	/// <summary>
	/// Summary description for frmFTerminais.
	/// </summary>
	internal class frmFTerminais : System.Windows.Forms.Form
	{
		#region Delegates
			public delegate void delCallTerminaisRefresh(ref System.Windows.Forms.ListView lvTerminais);
			public delegate void delCallTerminaisCarregaSelecionado(out int nIdTerminal);
			public delegate void delCallTerminaisSalvaSelecionado(int nIdTerminal);
			public delegate bool delCallTerminaisNovo();
			public delegate bool delCallTerminaisEditar(int nIdTerminais);
			public delegate bool delCallTerminaisExcluir(ref System.Collections.ArrayList arlTerminais,bool bSilent);
			public delegate bool delCallShowDialogContatos(int nIdTerminais);
			public delegate bool delCallSalvaDados();
		#endregion
		#region Events
			public event delCallTerminaisRefresh eCallTerminaisRefresh;	
			public event delCallTerminaisCarregaSelecionado eCallTerminaisCarregaSelecionado;	
			public event delCallTerminaisSalvaSelecionado eCallTerminaisSalvaSelecionado;	
			public event delCallTerminaisNovo eCallTerminaisNovo;	
			public event delCallTerminaisEditar eCallTerminaisEditar;	
			public event delCallTerminaisExcluir eCallTerminaisExcluir;	
			public event delCallShowDialogContatos eCallShowDialogContatos;	
			public event delCallSalvaDados eCallSalvaDados;
		#endregion
		#region Events Methods
			protected virtual void OnCallTerminaisRefresh()
			{
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				if (eCallTerminaisRefresh != null)
				{
					eCallTerminaisRefresh(ref m_lvTerminais);
				}
				this.Cursor = System.Windows.Forms.Cursors.Default;
			}

			protected virtual void OnCallTerminaisCarregaSelecionado()
			{
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				m_lvTerminais.SelectedItems.Clear();
				if (eCallTerminaisCarregaSelecionado != null)
				{
					int nIdTerminal;
					eCallTerminaisCarregaSelecionado(out nIdTerminal);
					foreach(System.Windows.Forms.ListViewItem lviTerminal in m_lvTerminais.Items)
					{
						if (Int32.Parse(lviTerminal.Tag.ToString()) == nIdTerminal)
						{
							lviTerminal.Selected = true;
							break;
						}
					}
				}
				this.Cursor = System.Windows.Forms.Cursors.Default;
			}

			protected virtual void OnCallTerminaisSalvaSelecionado()
			{
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				if (eCallTerminaisSalvaSelecionado != null)
				{
					int nIdTerminal = -1;
					if (m_lvTerminais.SelectedItems.Count > 0)
						nIdTerminal = Int32.Parse(m_lvTerminais.SelectedItems[0].Tag.ToString());
					eCallTerminaisSalvaSelecionado(nIdTerminal);
				}
				this.Cursor = System.Windows.Forms.Cursors.Default;
			}


			protected virtual bool OnCallTerminaisNovo()
			{
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				bool bRetorno = false;
				if (eCallTerminaisNovo != null)
					bRetorno = eCallTerminaisNovo();
				this.Cursor = System.Windows.Forms.Cursors.Default;
				return(bRetorno);
			}

			protected virtual bool OnCallTerminaisEditar()
			{
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				bool bRetorno = false;
				if ((eCallTerminaisEditar != null) && (m_lvTerminais.SelectedItems.Count > 0))
					bRetorno = eCallTerminaisEditar(Int32.Parse(m_lvTerminais.SelectedItems[0].Tag.ToString()));
				this.Cursor = System.Windows.Forms.Cursors.Default;;
				return(bRetorno);
			}

			protected virtual bool OnCallTerminaisExcluir()
			{
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				bool bRetorno = false;
				if ((eCallTerminaisExcluir != null) && (m_lvTerminais.SelectedItems.Count > 0))
				{
					System.Collections.ArrayList arlTerminais = new ArrayList();
					foreach(System.Windows.Forms.ListViewItem lviTerminal in m_lvTerminais.SelectedItems)
						arlTerminais.Add(Int32.Parse(lviTerminal.Tag.ToString()));
					bRetorno = eCallTerminaisExcluir(ref arlTerminais,false);
				}
				this.Cursor = System.Windows.Forms.Cursors.Default;
				return(bRetorno);
			}

			protected virtual void OnCallShowDialogContatos()
			{
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				if ((eCallShowDialogContatos != null) && (m_lvTerminais.SelectedItems.Count > 0))
				{
					OnCallTerminaisSalvaSelecionado();
					eCallShowDialogContatos(Int32.Parse(m_lvTerminais.SelectedItems[0].Tag.ToString()));
				}
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
			private System.Windows.Forms.GroupBox m_gbTerminais;
			private System.Windows.Forms.Button m_btContatos;
			private System.Windows.Forms.Button m_btExcluir;
			private System.Windows.Forms.Button m_btEditar;
			private System.Windows.Forms.Button m_btNovo;
		private System.Windows.Forms.ListView m_lvTerminais;
		#endregion
		#region Constructors and Destructors
			public frmFTerminais(string strEnderecoExecutavel)
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmFTerminais));
			this.m_gbGeral = new System.Windows.Forms.GroupBox();
			this.m_btOk = new System.Windows.Forms.Button();
			this.m_btCancelar = new System.Windows.Forms.Button();
			this.m_gbTerminais = new System.Windows.Forms.GroupBox();
			this.m_btContatos = new System.Windows.Forms.Button();
			this.m_btExcluir = new System.Windows.Forms.Button();
			this.m_btEditar = new System.Windows.Forms.Button();
			this.m_btNovo = new System.Windows.Forms.Button();
			this.m_lvTerminais = new System.Windows.Forms.ListView();
			this.m_ttDicas = new System.Windows.Forms.ToolTip(this.components);
			this.m_gbGeral.SuspendLayout();
			this.m_gbTerminais.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_gbGeral
			// 
			this.m_gbGeral.Controls.Add(this.m_btOk);
			this.m_gbGeral.Controls.Add(this.m_btCancelar);
			this.m_gbGeral.Controls.Add(this.m_gbTerminais);
			this.m_gbGeral.Location = new System.Drawing.Point(3, -2);
			this.m_gbGeral.Name = "m_gbGeral";
			this.m_gbGeral.Size = new System.Drawing.Size(308, 312);
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
			this.m_ttDicas.SetToolTip(this.m_btCancelar, "Cancelar");
			this.m_btCancelar.Click += new System.EventHandler(this.m_btCancelar_Click);
			// 
			// m_gbTerminais
			// 
			this.m_gbTerminais.Controls.Add(this.m_btContatos);
			this.m_gbTerminais.Controls.Add(this.m_btExcluir);
			this.m_gbTerminais.Controls.Add(this.m_btEditar);
			this.m_gbTerminais.Controls.Add(this.m_btNovo);
			this.m_gbTerminais.Controls.Add(this.m_lvTerminais);
			this.m_gbTerminais.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_gbTerminais.Location = new System.Drawing.Point(7, 9);
			this.m_gbTerminais.Name = "m_gbTerminais";
			this.m_gbTerminais.Size = new System.Drawing.Size(297, 271);
			this.m_gbTerminais.TabIndex = 0;
			this.m_gbTerminais.TabStop = false;
			this.m_gbTerminais.Text = "Terminais";
			// 
			// m_btContatos
			// 
			this.m_btContatos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.m_btContatos.BackColor = System.Drawing.SystemColors.Control;
			this.m_btContatos.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btContatos.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btContatos.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btContatos.Image = ((System.Drawing.Image)(resources.GetObject("m_btContatos.Image")));
			this.m_btContatos.Location = new System.Drawing.Point(264, 17);
			this.m_btContatos.Name = "m_btContatos";
			this.m_btContatos.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btContatos.Size = new System.Drawing.Size(25, 25);
			this.m_btContatos.TabIndex = 8;
			this.m_btContatos.Text = "N";
			this.m_btContatos.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.m_ttDicas.SetToolTip(this.m_btContatos, "Contatos");
			this.m_btContatos.Click += new System.EventHandler(this.m_btContatos_Click);
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
			// m_lvTerminais
			// 
			this.m_lvTerminais.HideSelection = false;
			this.m_lvTerminais.Location = new System.Drawing.Point(8, 45);
			this.m_lvTerminais.Name = "m_lvTerminais";
			this.m_lvTerminais.Size = new System.Drawing.Size(280, 216);
			this.m_lvTerminais.TabIndex = 0;
			this.m_lvTerminais.View = System.Windows.Forms.View.List;
			// 
			// m_ttDicas
			// 
			this.m_ttDicas.AutomaticDelay = 100;
			this.m_ttDicas.AutoPopDelay = 5000;
			this.m_ttDicas.InitialDelay = 100;
			this.m_ttDicas.ReshowDelay = 20;
			// 
			// frmFTerminais
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(312, 312);
			this.Controls.Add(this.m_gbGeral);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmFTerminais";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Terminais";
			this.Load += new System.EventHandler(this.frmFTerminais_Load);
			this.m_gbGeral.ResumeLayout(false);
			this.m_gbTerminais.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Eventos
			#region Formulario
				private void frmFTerminais_Load(object sender, System.EventArgs e)
				{
					vMostraCor();
					OnCallTerminaisRefresh();
					OnCallTerminaisCarregaSelecionado();
				}
			#endregion
			#region Botoes
				private void m_btNovo_Click(object sender, System.EventArgs e)
				{
					if (OnCallTerminaisNovo())
						OnCallTerminaisRefresh();
				}

				private void m_btEditar_Click(object sender, System.EventArgs e)
				{
					if(OnCallTerminaisEditar())
						OnCallTerminaisRefresh();
				}

				private void m_btExcluir_Click(object sender, System.EventArgs e)
				{
					if (OnCallTerminaisExcluir())
						OnCallTerminaisRefresh();
				}

				private void m_btContatos_Click(object sender, System.EventArgs e)
				{
					OnCallShowDialogContatos();
				}

				private void m_btOk_Click(object sender, System.EventArgs e)
				{
					OnCallTerminaisSalvaSelecionado();
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
