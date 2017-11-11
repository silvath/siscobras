using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace mdlSD.Formularios
{
	/// <summary>
	/// Summary description for frmFSDVincular.
	/// </summary>
	public class frmFSDVincular : System.Windows.Forms.Form
	{
		#region Delegates
			public delegate void delCallRefreshREs(ref mdlComponentesGraficos.ListView lvRes);
			public delegate void delCallRefreshREsVinculados(int nIdSD,ref mdlComponentesGraficos.ListView lvResPEs);
			public delegate bool delCallREVincular(int nIdSD,int nIdRe);
			public delegate bool delCallREDesvincular(int nIdRe);
		#endregion
		#region Events
			public event delCallRefreshREs eCallRefreshREs;
			public event delCallRefreshREsVinculados eCallRefreshREsVinculados;
			public event delCallREVincular eCallREVincular;
			public event delCallREDesvincular eCallREDesvincular;
		#endregion
		#region Events Methods
			public virtual void OnCallRefreshREs()
			{
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				if (eCallRefreshREs != null)
					eCallRefreshREs(ref m_lvREs);
				this.Cursor = System.Windows.Forms.Cursors.Default;
			}

			public virtual void OnCallRefreshREsVinculados()
			{
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				if (eCallRefreshREsVinculados != null)
					eCallRefreshREsVinculados(m_nIdSD,ref m_lvREsVinculados);
				this.Cursor = System.Windows.Forms.Cursors.Default;
			}

			public virtual bool OnCallREVincular()
			{
				bool bReturno = false;
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				if ((eCallREVincular != null) && (m_lvREs.SelectedItems.Count > 0))
					bReturno = eCallREVincular(m_nIdSD,Int32.Parse(m_lvREs.SelectedItems[0].Tag.ToString()));
				this.Cursor = System.Windows.Forms.Cursors.Default;
				return(bReturno);
			}

			public virtual bool OnCallREDesvincular()
			{
				bool bReturno = false;
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				if ((eCallREDesvincular != null) && (m_lvREsVinculados.SelectedItems.Count > 0))
					bReturno = eCallREDesvincular(Int32.Parse(m_lvREsVinculados.SelectedItems[0].Tag.ToString()));
				this.Cursor = System.Windows.Forms.Cursors.Default;
				return(bReturno);
			}
		#endregion

		#region Atributos
			private int m_nIdSD = -1;
			public bool m_bModificado = false;
			private System.Windows.Forms.GroupBox m_gbMain;
			internal System.Windows.Forms.Button m_btCancelar;
			internal System.Windows.Forms.Button m_btOk;
			private System.Windows.Forms.Button m_btRERemove;
			private System.Windows.Forms.Button m_btREInsere;
			private System.Windows.Forms.GroupBox m_gbREsVinculados;
			private mdlComponentesGraficos.ListView m_lvREsVinculados;
			private System.Windows.Forms.GroupBox m_gbREs;
			private mdlComponentesGraficos.ListView m_lvREs;
			private System.Windows.Forms.ColumnHeader m_chREPE;
			private System.Windows.Forms.ColumnHeader m_chRENumero;
			private System.Windows.Forms.ToolTip m_ttDicas;
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
		#region Construtores
			public frmFSDVincular(string strEnderecoExecutavel,int nIdSD)
			{
				m_nIdSD = nIdSD;
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmFSDVincular));
			this.m_gbMain = new System.Windows.Forms.GroupBox();
			this.m_btCancelar = new System.Windows.Forms.Button();
			this.m_btOk = new System.Windows.Forms.Button();
			this.m_btRERemove = new System.Windows.Forms.Button();
			this.m_btREInsere = new System.Windows.Forms.Button();
			this.m_gbREsVinculados = new System.Windows.Forms.GroupBox();
			this.m_lvREsVinculados = new mdlComponentesGraficos.ListView();
			this.m_chREPE = new System.Windows.Forms.ColumnHeader();
			this.m_gbREs = new System.Windows.Forms.GroupBox();
			this.m_lvREs = new mdlComponentesGraficos.ListView();
			this.m_chRENumero = new System.Windows.Forms.ColumnHeader();
			this.m_ttDicas = new System.Windows.Forms.ToolTip(this.components);
			this.m_gbMain.SuspendLayout();
			this.m_gbREsVinculados.SuspendLayout();
			this.m_gbREs.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_gbMain
			// 
			this.m_gbMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_gbMain.Controls.Add(this.m_btCancelar);
			this.m_gbMain.Controls.Add(this.m_btOk);
			this.m_gbMain.Controls.Add(this.m_btRERemove);
			this.m_gbMain.Controls.Add(this.m_btREInsere);
			this.m_gbMain.Controls.Add(this.m_gbREsVinculados);
			this.m_gbMain.Controls.Add(this.m_gbREs);
			this.m_gbMain.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_gbMain.Location = new System.Drawing.Point(3, -2);
			this.m_gbMain.Name = "m_gbMain";
			this.m_gbMain.Size = new System.Drawing.Size(309, 325);
			this.m_gbMain.TabIndex = 1;
			this.m_gbMain.TabStop = false;
			// 
			// m_btCancelar
			// 
			this.m_btCancelar.BackColor = System.Drawing.SystemColors.Control;
			this.m_btCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btCancelar.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btCancelar.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btCancelar.Image = ((System.Drawing.Image)(resources.GetObject("m_btCancelar.Image")));
			this.m_btCancelar.Location = new System.Drawing.Point(156, 295);
			this.m_btCancelar.Name = "m_btCancelar";
			this.m_btCancelar.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btCancelar.Size = new System.Drawing.Size(57, 25);
			this.m_btCancelar.TabIndex = 11;
			this.m_ttDicas.SetToolTip(this.m_btCancelar, "Cancelar");
			this.m_btCancelar.Click += new System.EventHandler(this.m_btCancelar_Click);
			// 
			// m_btOk
			// 
			this.m_btOk.BackColor = System.Drawing.SystemColors.Control;
			this.m_btOk.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btOk.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btOk.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btOk.Image = ((System.Drawing.Image)(resources.GetObject("m_btOk.Image")));
			this.m_btOk.Location = new System.Drawing.Point(92, 295);
			this.m_btOk.Name = "m_btOk";
			this.m_btOk.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btOk.Size = new System.Drawing.Size(57, 25);
			this.m_btOk.TabIndex = 10;
			this.m_ttDicas.SetToolTip(this.m_btOk, "Confirmar");
			this.m_btOk.Click += new System.EventHandler(this.m_btOk_Click);
			// 
			// m_btRERemove
			// 
			this.m_btRERemove.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btRERemove.Image = ((System.Drawing.Image)(resources.GetObject("m_btRERemove.Image")));
			this.m_btRERemove.Location = new System.Drawing.Point(155, 145);
			this.m_btRERemove.Name = "m_btRERemove";
			this.m_btRERemove.Size = new System.Drawing.Size(60, 40);
			this.m_btRERemove.TabIndex = 8;
			this.m_ttDicas.SetToolTip(this.m_btRERemove, "Desvincular");
			this.m_btRERemove.Click += new System.EventHandler(this.m_btRERemove_Click);
			// 
			// m_btREInsere
			// 
			this.m_btREInsere.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btREInsere.Image = ((System.Drawing.Image)(resources.GetObject("m_btREInsere.Image")));
			this.m_btREInsere.Location = new System.Drawing.Point(91, 145);
			this.m_btREInsere.Name = "m_btREInsere";
			this.m_btREInsere.Size = new System.Drawing.Size(60, 40);
			this.m_btREInsere.TabIndex = 7;
			this.m_ttDicas.SetToolTip(this.m_btREInsere, "Vincular");
			this.m_btREInsere.Click += new System.EventHandler(this.m_btREInsere_Click);
			// 
			// m_gbREsVinculados
			// 
			this.m_gbREsVinculados.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_gbREsVinculados.Controls.Add(this.m_lvREsVinculados);
			this.m_gbREsVinculados.Location = new System.Drawing.Point(5, 187);
			this.m_gbREsVinculados.Name = "m_gbREsVinculados";
			this.m_gbREsVinculados.Size = new System.Drawing.Size(299, 104);
			this.m_gbREsVinculados.TabIndex = 1;
			this.m_gbREsVinculados.TabStop = false;
			this.m_gbREsVinculados.Text = "REs vinculados a esta DDE";
			// 
			// m_lvREsVinculados
			// 
			this.m_lvREsVinculados.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_lvREsVinculados.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																								this.m_chREPE});
			this.m_lvREsVinculados.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
			this.m_lvREsVinculados.HideSelection = false;
			this.m_lvREsVinculados.Location = new System.Drawing.Point(4, 15);
			this.m_lvREsVinculados.Name = "m_lvREsVinculados";
			this.m_lvREsVinculados.Size = new System.Drawing.Size(286, 80);
			this.m_lvREsVinculados.TabIndex = 1;
			this.m_lvREsVinculados.View = System.Windows.Forms.View.Details;
			// 
			// m_chREPE
			// 
			this.m_chREPE.Text = "m_chREPE";
			this.m_chREPE.Width = 200;
			// 
			// m_gbREs
			// 
			this.m_gbREs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_gbREs.Controls.Add(this.m_lvREs);
			this.m_gbREs.Location = new System.Drawing.Point(6, 7);
			this.m_gbREs.Name = "m_gbREs";
			this.m_gbREs.Size = new System.Drawing.Size(299, 136);
			this.m_gbREs.TabIndex = 0;
			this.m_gbREs.TabStop = false;
			this.m_gbREs.Text = "REs";
			// 
			// m_lvREs
			// 
			this.m_lvREs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_lvREs.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																					  this.m_chRENumero});
			this.m_lvREs.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
			this.m_lvREs.HideSelection = false;
			this.m_lvREs.Location = new System.Drawing.Point(7, 15);
			this.m_lvREs.Name = "m_lvREs";
			this.m_lvREs.Size = new System.Drawing.Size(283, 113);
			this.m_lvREs.TabIndex = 0;
			this.m_lvREs.View = System.Windows.Forms.View.Details;
			// 
			// m_chRENumero
			// 
			this.m_chRENumero.Text = "m_chRENumero";
			this.m_chRENumero.Width = 200;
			// 
			// m_ttDicas
			// 
			this.m_ttDicas.AutomaticDelay = 100;
			this.m_ttDicas.AutoPopDelay = 5000;
			this.m_ttDicas.InitialDelay = 100;
			this.m_ttDicas.ReshowDelay = 20;
			// 
			// frmFSDVincular
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(314, 327);
			this.Controls.Add(this.m_gbMain);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmFSDVincular";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Vinculando REs a DDE";
			this.Load += new System.EventHandler(this.frmFSDVincular_Load);
			this.m_gbMain.ResumeLayout(false);
			this.m_gbREsVinculados.ResumeLayout(false);
			this.m_gbREs.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Eventos
			#region Formulario
				private void frmFSDVincular_Load(object sender, System.EventArgs e)
				{
					OnCallRefreshREs();
					OnCallRefreshREsVinculados();
				}
			#endregion
			#region Botoes
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

				private void m_btREInsere_Click(object sender, System.EventArgs e)
				{
					if (OnCallREVincular())
					{
						OnCallRefreshREs();
						OnCallRefreshREsVinculados();
					}
				}

				private void m_btRERemove_Click(object sender, System.EventArgs e)
				{
					if (OnCallREDesvincular())
					{
						OnCallRefreshREs();
						OnCallRefreshREsVinculados();
					}
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
	}
}
