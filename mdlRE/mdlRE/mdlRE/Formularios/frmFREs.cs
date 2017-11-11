using System;
//using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace mdlRE.Formularios
{
	/// <summary>
	/// Summary description for frmFREs.
	/// </summary>
	public class frmFREs : System.Windows.Forms.Form
	{
		#region Delegates
			public delegate void delCallRefreshREs(ref mdlComponentesGraficos.ListView lvRes);
			public delegate void delCallShowConfiguracoes();
			public delegate bool delCallShowRENovo();
			public delegate bool delCallShowREEditar(int nIdRe);
			public delegate bool delCallShowRERemover(int nIdRe);
			public delegate bool delCallShowREInformacoes(int nIdRe);
			public delegate bool delCallSalvaDados();
		#endregion
		#region Events
			public event delCallRefreshREs eCallRefreshREs;
			public event delCallShowConfiguracoes eCallShowConfiguracoes;
			public event delCallShowRENovo eCallShowRENovo;
			public event delCallShowREEditar eCallShowREEditar;
			public event delCallShowRERemover eCallShowRERemover;
			public event delCallShowREInformacoes eCallShowREInformacoes;
			public event delCallSalvaDados eCallSalvaDados;
		#endregion
		#region Events Methods
			public virtual void OnCallRefreshREs()
			{
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				if (eCallRefreshREs != null)
					eCallRefreshREs(ref m_lvREs);
				this.Cursor = System.Windows.Forms.Cursors.Default;
			}

			protected virtual void OnCallShowConfiguracoes()
			{
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				if (eCallShowConfiguracoes != null)
					eCallShowConfiguracoes();
				this.Cursor = System.Windows.Forms.Cursors.Default;
			}

			protected virtual bool OnCallShowRENovo()
			{				
				bool bRetorno = false;
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				if (eCallShowRENovo != null)
					bRetorno = eCallShowRENovo();
				this.Cursor = System.Windows.Forms.Cursors.Default;
				return(bRetorno);
			}

			protected virtual bool OnCallShowREEditar()
			{
				bool bRetorno = false;
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				if (eCallShowREEditar != null)
				{
					if (m_lvREs.SelectedItems.Count > 0)
					{
						int nIdRe = Int32.Parse(m_lvREs.SelectedItems[0].Tag.ToString());
						bRetorno = eCallShowREEditar(nIdRe);
					}
				}
				this.Cursor = System.Windows.Forms.Cursors.Default;
				return(bRetorno);
			}

			protected virtual bool OnCallShowRERemover()
			{
				bool bRetorno = false;
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				if (eCallShowRERemover != null)
				{
					if (m_lvREs.SelectedItems.Count > 0)
					{
						int nIdRe = Int32.Parse(m_lvREs.SelectedItems[0].Tag.ToString());
						bRetorno = eCallShowRERemover(nIdRe);
					}
				}
				this.Cursor = System.Windows.Forms.Cursors.Default;
				return(bRetorno);
			}

			protected virtual void OnCallShowREInformacoes()
			{
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				if (eCallShowREInformacoes != null)
				{
					if (m_lvREs.SelectedItems.Count > 0)
					{
						int nIdRE = Int32.Parse(m_lvREs.SelectedItems[0].Tag.ToString());
						if (eCallShowREInformacoes(nIdRE))
							OnCallRefreshREs();
					}
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

		#region Atributos
			private bool m_bModificado;
			private string m_strEnderecoExecutavel;

			private System.Windows.Forms.GroupBox m_gbMain;
			private System.Windows.Forms.GroupBox m_gbREs;
			internal System.Windows.Forms.Button m_btOk;
			internal System.Windows.Forms.Button m_btCancelar;
			private mdlComponentesGraficos.ListView m_lvREs;
			public System.Windows.Forms.Button m_btConfiguracoes;
			public System.Windows.Forms.Button m_btREExclui;
			public System.Windows.Forms.Button m_btRENovo;
			private System.Windows.Forms.ToolTip m_ttDicas;
		private System.Windows.Forms.ColumnHeader m_chNumero;
		public System.Windows.Forms.Button m_btREEditar;
			private System.ComponentModel.IContainer components;
		#endregion
		#region Propriedades
			public bool Modificado
			{
				get
				{
					return(m_bModificado);
				}
			}
		#endregion
		#region Constructores
			public frmFREs(string strEnderecoExecutavel)
			{
				m_strEnderecoExecutavel = strEnderecoExecutavel;
				InitializeComponent();
				vMostraCor();
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmFREs));
			this.m_gbMain = new System.Windows.Forms.GroupBox();
			this.m_btOk = new System.Windows.Forms.Button();
			this.m_btCancelar = new System.Windows.Forms.Button();
			this.m_gbREs = new System.Windows.Forms.GroupBox();
			this.m_btREEditar = new System.Windows.Forms.Button();
			this.m_btConfiguracoes = new System.Windows.Forms.Button();
			this.m_btREExclui = new System.Windows.Forms.Button();
			this.m_btRENovo = new System.Windows.Forms.Button();
			this.m_lvREs = new mdlComponentesGraficos.ListView();
			this.m_chNumero = new System.Windows.Forms.ColumnHeader();
			this.m_ttDicas = new System.Windows.Forms.ToolTip(this.components);
			this.m_gbMain.SuspendLayout();
			this.m_gbREs.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_gbMain
			// 
			this.m_gbMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_gbMain.Controls.Add(this.m_btOk);
			this.m_gbMain.Controls.Add(this.m_btCancelar);
			this.m_gbMain.Controls.Add(this.m_gbREs);
			this.m_gbMain.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_gbMain.Location = new System.Drawing.Point(4, -2);
			this.m_gbMain.Name = "m_gbMain";
			this.m_gbMain.Size = new System.Drawing.Size(378, 375);
			this.m_gbMain.TabIndex = 0;
			this.m_gbMain.TabStop = false;
			// 
			// m_btOk
			// 
			this.m_btOk.BackColor = System.Drawing.SystemColors.Control;
			this.m_btOk.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btOk.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btOk.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btOk.Image = ((System.Drawing.Image)(resources.GetObject("m_btOk.Image")));
			this.m_btOk.Location = new System.Drawing.Point(133, 343);
			this.m_btOk.Name = "m_btOk";
			this.m_btOk.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btOk.Size = new System.Drawing.Size(57, 25);
			this.m_btOk.TabIndex = 12;
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
			this.m_btCancelar.Location = new System.Drawing.Point(197, 343);
			this.m_btCancelar.Name = "m_btCancelar";
			this.m_btCancelar.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btCancelar.Size = new System.Drawing.Size(57, 25);
			this.m_btCancelar.TabIndex = 13;
			this.m_ttDicas.SetToolTip(this.m_btCancelar, "Cancelar");
			this.m_btCancelar.Click += new System.EventHandler(this.m_btCancelar_Click);
			// 
			// m_gbREs
			// 
			this.m_gbREs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_gbREs.Controls.Add(this.m_btREEditar);
			this.m_gbREs.Controls.Add(this.m_btConfiguracoes);
			this.m_gbREs.Controls.Add(this.m_btREExclui);
			this.m_gbREs.Controls.Add(this.m_btRENovo);
			this.m_gbREs.Controls.Add(this.m_lvREs);
			this.m_gbREs.Location = new System.Drawing.Point(7, 7);
			this.m_gbREs.Name = "m_gbREs";
			this.m_gbREs.Size = new System.Drawing.Size(367, 329);
			this.m_gbREs.TabIndex = 0;
			this.m_gbREs.TabStop = false;
			this.m_gbREs.Text = "REs";
			// 
			// m_btREEditar
			// 
			this.m_btREEditar.BackColor = System.Drawing.SystemColors.Control;
			this.m_btREEditar.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btREEditar.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btREEditar.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btREEditar.Image = ((System.Drawing.Image)(resources.GetObject("m_btREEditar.Image")));
			this.m_btREEditar.Location = new System.Drawing.Point(172, 14);
			this.m_btREEditar.Name = "m_btREEditar";
			this.m_btREEditar.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btREEditar.Size = new System.Drawing.Size(25, 25);
			this.m_btREEditar.TabIndex = 22;
			this.m_btREEditar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.m_ttDicas.SetToolTip(this.m_btREEditar, "Editar");
			this.m_btREEditar.Click += new System.EventHandler(this.m_btREEditar_Click);
			// 
			// m_btConfiguracoes
			// 
			this.m_btConfiguracoes.BackColor = System.Drawing.SystemColors.Control;
			this.m_btConfiguracoes.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btConfiguracoes.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btConfiguracoes.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btConfiguracoes.Image = ((System.Drawing.Image)(resources.GetObject("m_btConfiguracoes.Image")));
			this.m_btConfiguracoes.Location = new System.Drawing.Point(8, 15);
			this.m_btConfiguracoes.Name = "m_btConfiguracoes";
			this.m_btConfiguracoes.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btConfiguracoes.Size = new System.Drawing.Size(25, 25);
			this.m_btConfiguracoes.TabIndex = 21;
			this.m_btConfiguracoes.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.m_btConfiguracoes.Visible = false;
			// 
			// m_btREExclui
			// 
			this.m_btREExclui.BackColor = System.Drawing.SystemColors.Control;
			this.m_btREExclui.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btREExclui.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btREExclui.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btREExclui.Image = ((System.Drawing.Image)(resources.GetObject("m_btREExclui.Image")));
			this.m_btREExclui.Location = new System.Drawing.Point(199, 14);
			this.m_btREExclui.Name = "m_btREExclui";
			this.m_btREExclui.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btREExclui.Size = new System.Drawing.Size(25, 25);
			this.m_btREExclui.TabIndex = 20;
			this.m_btREExclui.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.m_ttDicas.SetToolTip(this.m_btREExclui, "Excluir");
			this.m_btREExclui.Click += new System.EventHandler(this.m_btREExclui_Click);
			// 
			// m_btRENovo
			// 
			this.m_btRENovo.BackColor = System.Drawing.SystemColors.Control;
			this.m_btRENovo.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btRENovo.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btRENovo.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btRENovo.Image = ((System.Drawing.Image)(resources.GetObject("m_btRENovo.Image")));
			this.m_btRENovo.Location = new System.Drawing.Point(145, 14);
			this.m_btRENovo.Name = "m_btRENovo";
			this.m_btRENovo.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btRENovo.Size = new System.Drawing.Size(25, 25);
			this.m_btRENovo.TabIndex = 19;
			this.m_btRENovo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.m_ttDicas.SetToolTip(this.m_btRENovo, "Novo");
			this.m_btRENovo.Click += new System.EventHandler(this.m_btRENovo_Click);
			// 
			// m_lvREs
			// 
			this.m_lvREs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_lvREs.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																					  this.m_chNumero});
			this.m_lvREs.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
			this.m_lvREs.HideSelection = false;
			this.m_lvREs.Location = new System.Drawing.Point(7, 42);
			this.m_lvREs.Name = "m_lvREs";
			this.m_lvREs.Size = new System.Drawing.Size(352, 280);
			this.m_lvREs.TabIndex = 0;
			this.m_lvREs.View = System.Windows.Forms.View.Details;
			this.m_lvREs.DoubleClick += new System.EventHandler(this.m_lvREs_DoubleClick);
			// 
			// m_chNumero
			// 
			this.m_chNumero.Text = "m_chNumero";
			this.m_chNumero.Width = 300;
			// 
			// m_ttDicas
			// 
			this.m_ttDicas.AutomaticDelay = 100;
			this.m_ttDicas.AutoPopDelay = 5000;
			this.m_ttDicas.InitialDelay = 100;
			this.m_ttDicas.ReshowDelay = 20;
			// 
			// frmFREs
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(386, 375);
			this.Controls.Add(this.m_gbMain);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmFREs";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "REs";
			this.Load += new System.EventHandler(this.frmFREs_Load);
			this.m_gbMain.ResumeLayout(false);
			this.m_gbREs.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Eventos
			#region Formulario
				private void frmFREs_Load(object sender, System.EventArgs e)
				{
					OnCallRefreshREs();
				}
			#endregion
			#region ListView
				private void m_lvREs_DoubleClick(object sender, System.EventArgs e)
				{
					OnCallShowREInformacoes();
				}
			#endregion
			#region Botoes
				private void m_btRENovo_Click(object sender, System.EventArgs e)
				{
					if (OnCallShowRENovo())
						OnCallRefreshREs();
				}

				private void m_btREEditar_Click(object sender, System.EventArgs e)
				{
					if (OnCallShowREEditar())
						OnCallRefreshREs();
				}

				private void m_btREExclui_Click(object sender, System.EventArgs e)
				{
					if (OnCallShowRERemover())
						OnCallRefreshREs();
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
