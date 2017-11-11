using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace mdlSD.Formularios
{
	/// <summary>
	/// Summary description for frmFSDVincularPE.
	/// </summary>
	public class frmFSDVincularPE : System.Windows.Forms.Form
	{
		#region Delegates
			public delegate void delCallRefreshSDs(ref mdlComponentesGraficos.ListView lvSDs);
			public delegate bool delCallShowSDNovo();
			public delegate bool delCallShowSDEditar(int nIdSD);
			public delegate bool delCallShowSDRemover(int nIdSD);
			public delegate void delCallRefreshREs(ref mdlComponentesGraficos.ListView lvRes);
			public delegate void delCallRefreshREsVinculados(int nIdSD,ref mdlComponentesGraficos.ListView lvResPEs);
			public delegate bool delCallREVincular(int nIdSD,int nIdRe);
			public delegate bool delCallREDesvincular(int nIdRe);
			public delegate void delCallPersonalizavel(out bool bPersonalizavel,out string strPersonalizavel);
		#endregion
		#region Events
			public event delCallRefreshSDs eCallRefreshSDs;
			public event delCallShowSDNovo eCallShowSDNovo;
			public event delCallShowSDEditar eCallShowSDEditar;
			public event delCallShowSDRemover eCallShowSDRemover;
			public event delCallRefreshREs eCallRefreshREs;
			public event delCallRefreshREsVinculados eCallRefreshREsVinculados;
			public event delCallREVincular eCallREVincular;
			public event delCallREDesvincular eCallREDesvincular;
			public event delCallPersonalizavel eCallPersonalizavel;
		#endregion
		#region Events Methods
			public virtual void OnCallRefreshSDs()
			{
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				if (eCallRefreshSDs != null)
					eCallRefreshSDs(ref m_lvSDs);
				this.Cursor = System.Windows.Forms.Cursors.Default;
			}

			protected virtual bool OnCallShowSDNovo()
			{				
				bool bRetorno = false;
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				if (eCallShowSDNovo != null)
					bRetorno = eCallShowSDNovo();
				this.Cursor = System.Windows.Forms.Cursors.Default;
				return(bRetorno);
			}

			protected virtual bool OnCallShowSDEditar()
			{
				bool bRetorno = false;
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				if (eCallShowSDEditar != null)
				{
					if (m_lvSDs.SelectedItems.Count > 0)
					{
						int nIdSD = Int32.Parse(m_lvSDs.SelectedItems[0].Tag.ToString());
						bRetorno = eCallShowSDEditar(nIdSD);
					}
				}
				this.Cursor = System.Windows.Forms.Cursors.Default;
				return(bRetorno);
			}

			protected virtual bool OnCallShowSDRemover()
			{
				bool bRetorno = false;
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				if (eCallShowSDRemover != null)
				{
					if (m_lvSDs.SelectedItems.Count > 0)
					{
						int nIdSD = Int32.Parse(m_lvSDs.SelectedItems[0].Tag.ToString());
						bRetorno = eCallShowSDRemover(nIdSD);
					}
				}
				this.Cursor = System.Windows.Forms.Cursors.Default;
				return(bRetorno);
			}

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
				if ((eCallRefreshREsVinculados != null) && (m_lvSDs.SelectedItems.Count > 0))
					eCallRefreshREsVinculados(Int32.Parse(m_lvSDs.SelectedItems[0].Tag.ToString()),ref m_lvREsVinculados);
				this.Cursor = System.Windows.Forms.Cursors.Default;
			}

			public virtual bool OnCallREVincular()
			{
				bool bReturno = false;
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				if ((eCallREVincular != null) && (m_lvSDs.SelectedItems.Count > 0) && (m_lvREs.SelectedItems.Count > 0))
					bReturno = eCallREVincular(Int32.Parse(m_lvSDs.SelectedItems[0].Tag.ToString()),Int32.Parse(m_lvREs.SelectedItems[0].Tag.ToString()));
				this.Cursor = System.Windows.Forms.Cursors.Default;
				OnCallPersonalizavel();
				return(bReturno);
			}

			public virtual bool OnCallREDesvincular()
			{
				bool bReturno = false;
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				if ((eCallREDesvincular != null) && (m_lvREsVinculados.SelectedItems.Count > 0))
					bReturno = eCallREDesvincular(Int32.Parse(m_lvREsVinculados.SelectedItems[0].Tag.ToString()));
				this.Cursor = System.Windows.Forms.Cursors.Default;
				OnCallPersonalizavel();
				return(bReturno);
			}

			public virtual bool OnCallPersonalizavel()
			{
				bool bReturno = false;
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				if (eCallPersonalizavel != null)
				{
					bool bPersonalizavel = false;
					string strPersonalizavel = "";
					eCallPersonalizavel(out bPersonalizavel,out strPersonalizavel);
					this.PersonalizavelAtivo = bPersonalizavel;
					this.Personalizavel = strPersonalizavel;
				}
				this.Cursor = System.Windows.Forms.Cursors.Default;
				return(bReturno);
			}
		#endregion

		#region Atributos
			private bool m_bModificado = false;
		private System.Windows.Forms.GroupBox m_gbMain;
		internal System.Windows.Forms.Button m_btCancelar;
		internal System.Windows.Forms.Button m_btOk;
		private System.Windows.Forms.GroupBox m_gbREs;
		private mdlComponentesGraficos.ListView m_lvREs;
		private System.Windows.Forms.ColumnHeader m_chRENumero;
		private System.Windows.Forms.GroupBox m_gbREsVinculados;
		private mdlComponentesGraficos.ListView m_lvREsVinculados;
		private System.Windows.Forms.ColumnHeader m_chREPE;
		private System.Windows.Forms.GroupBox m_gbSDs;
		public System.Windows.Forms.Button m_btSDEditar;
		public System.Windows.Forms.Button m_btSDExclui;
		public System.Windows.Forms.Button m_btSDNovo;
		private mdlComponentesGraficos.ListView m_lvSDs;
		private System.Windows.Forms.ColumnHeader m_chNumero;
		private System.Windows.Forms.Button m_btRERemove;
		private System.Windows.Forms.Button m_btREInsere;
		private System.Windows.Forms.GroupBox m_gbPersonalizavel;
		private mdlComponentesGraficos.TextBox m_txtPersonalizavel;
			private System.ComponentModel.Container components = null;
		#endregion
		#region Properties
			public bool Modificado
			{
				get
				{
					return(m_bModificado);
				}
			}

			public bool PersonalizavelAtivo
			{
				set
				{
					m_txtPersonalizavel.Enabled = value;
				}
				get
				{
					return(m_txtPersonalizavel.Enabled);
				}
			}

			public string Personalizavel
			{
				set
				{
					m_txtPersonalizavel.Text = value;
				}
				get
				{
					return(m_txtPersonalizavel.Text);
				}
			}
		#endregion
		#region Constructors
		public frmFSDVincularPE(string strEnderecoExecutavel)
		{
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmFSDVincularPE));
			this.m_gbMain = new System.Windows.Forms.GroupBox();
			this.m_gbPersonalizavel = new System.Windows.Forms.GroupBox();
			this.m_txtPersonalizavel = new mdlComponentesGraficos.TextBox();
			this.m_btRERemove = new System.Windows.Forms.Button();
			this.m_btREInsere = new System.Windows.Forms.Button();
			this.m_gbSDs = new System.Windows.Forms.GroupBox();
			this.m_btSDEditar = new System.Windows.Forms.Button();
			this.m_btSDExclui = new System.Windows.Forms.Button();
			this.m_btSDNovo = new System.Windows.Forms.Button();
			this.m_lvSDs = new mdlComponentesGraficos.ListView();
			this.m_chNumero = new System.Windows.Forms.ColumnHeader();
			this.m_gbREsVinculados = new System.Windows.Forms.GroupBox();
			this.m_lvREsVinculados = new mdlComponentesGraficos.ListView();
			this.m_chREPE = new System.Windows.Forms.ColumnHeader();
			this.m_gbREs = new System.Windows.Forms.GroupBox();
			this.m_lvREs = new mdlComponentesGraficos.ListView();
			this.m_chRENumero = new System.Windows.Forms.ColumnHeader();
			this.m_btCancelar = new System.Windows.Forms.Button();
			this.m_btOk = new System.Windows.Forms.Button();
			this.m_gbMain.SuspendLayout();
			this.m_gbPersonalizavel.SuspendLayout();
			this.m_gbSDs.SuspendLayout();
			this.m_gbREsVinculados.SuspendLayout();
			this.m_gbREs.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_gbMain
			// 
			this.m_gbMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_gbMain.Controls.Add(this.m_gbPersonalizavel);
			this.m_gbMain.Controls.Add(this.m_btRERemove);
			this.m_gbMain.Controls.Add(this.m_btREInsere);
			this.m_gbMain.Controls.Add(this.m_gbSDs);
			this.m_gbMain.Controls.Add(this.m_gbREsVinculados);
			this.m_gbMain.Controls.Add(this.m_gbREs);
			this.m_gbMain.Controls.Add(this.m_btCancelar);
			this.m_gbMain.Controls.Add(this.m_btOk);
			this.m_gbMain.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_gbMain.Location = new System.Drawing.Point(5, -2);
			this.m_gbMain.Name = "m_gbMain";
			this.m_gbMain.Size = new System.Drawing.Size(490, 431);
			this.m_gbMain.TabIndex = 0;
			this.m_gbMain.TabStop = false;
			// 
			// m_gbPersonalizavel
			// 
			this.m_gbPersonalizavel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_gbPersonalizavel.Controls.Add(this.m_txtPersonalizavel);
			this.m_gbPersonalizavel.Location = new System.Drawing.Point(5, 313);
			this.m_gbPersonalizavel.Name = "m_gbPersonalizavel";
			this.m_gbPersonalizavel.Size = new System.Drawing.Size(481, 88);
			this.m_gbPersonalizavel.TabIndex = 24;
			this.m_gbPersonalizavel.TabStop = false;
			this.m_gbPersonalizavel.Text = "Pesonalizável";
			// 
			// m_txtPersonalizavel
			// 
			this.m_txtPersonalizavel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_txtPersonalizavel.Location = new System.Drawing.Point(8, 16);
			this.m_txtPersonalizavel.Multiline = true;
			this.m_txtPersonalizavel.Name = "m_txtPersonalizavel";
			this.m_txtPersonalizavel.Size = new System.Drawing.Size(464, 64);
			this.m_txtPersonalizavel.TabIndex = 0;
			this.m_txtPersonalizavel.Text = "";
			// 
			// m_btRERemove
			// 
			this.m_btRERemove.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btRERemove.Image = ((System.Drawing.Image)(resources.GetObject("m_btRERemove.Image")));
			this.m_btRERemove.Location = new System.Drawing.Point(373, 185);
			this.m_btRERemove.Name = "m_btRERemove";
			this.m_btRERemove.Size = new System.Drawing.Size(60, 40);
			this.m_btRERemove.TabIndex = 18;
			this.m_btRERemove.Click += new System.EventHandler(this.m_btRERemove_Click);
			// 
			// m_btREInsere
			// 
			this.m_btREInsere.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btREInsere.Image = ((System.Drawing.Image)(resources.GetObject("m_btREInsere.Image")));
			this.m_btREInsere.Location = new System.Drawing.Point(309, 185);
			this.m_btREInsere.Name = "m_btREInsere";
			this.m_btREInsere.Size = new System.Drawing.Size(60, 40);
			this.m_btREInsere.TabIndex = 17;
			this.m_btREInsere.Click += new System.EventHandler(this.m_btREInsere_Click);
			// 
			// m_gbSDs
			// 
			this.m_gbSDs.Controls.Add(this.m_btSDEditar);
			this.m_gbSDs.Controls.Add(this.m_btSDExclui);
			this.m_gbSDs.Controls.Add(this.m_btSDNovo);
			this.m_gbSDs.Controls.Add(this.m_lvSDs);
			this.m_gbSDs.Location = new System.Drawing.Point(6, 6);
			this.m_gbSDs.Name = "m_gbSDs";
			this.m_gbSDs.Size = new System.Drawing.Size(238, 177);
			this.m_gbSDs.TabIndex = 16;
			this.m_gbSDs.TabStop = false;
			this.m_gbSDs.Text = "DDEs";
			// 
			// m_btSDEditar
			// 
			this.m_btSDEditar.BackColor = System.Drawing.SystemColors.Control;
			this.m_btSDEditar.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btSDEditar.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btSDEditar.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btSDEditar.Image = ((System.Drawing.Image)(resources.GetObject("m_btSDEditar.Image")));
			this.m_btSDEditar.Location = new System.Drawing.Point(108, 14);
			this.m_btSDEditar.Name = "m_btSDEditar";
			this.m_btSDEditar.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btSDEditar.Size = new System.Drawing.Size(25, 25);
			this.m_btSDEditar.TabIndex = 22;
			this.m_btSDEditar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.m_btSDEditar.Click += new System.EventHandler(this.m_btSDEditar_Click);
			// 
			// m_btSDExclui
			// 
			this.m_btSDExclui.BackColor = System.Drawing.SystemColors.Control;
			this.m_btSDExclui.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btSDExclui.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btSDExclui.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btSDExclui.Image = ((System.Drawing.Image)(resources.GetObject("m_btSDExclui.Image")));
			this.m_btSDExclui.Location = new System.Drawing.Point(136, 14);
			this.m_btSDExclui.Name = "m_btSDExclui";
			this.m_btSDExclui.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btSDExclui.Size = new System.Drawing.Size(25, 25);
			this.m_btSDExclui.TabIndex = 20;
			this.m_btSDExclui.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.m_btSDExclui.Click += new System.EventHandler(this.m_btSDExclui_Click);
			// 
			// m_btSDNovo
			// 
			this.m_btSDNovo.BackColor = System.Drawing.SystemColors.Control;
			this.m_btSDNovo.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btSDNovo.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btSDNovo.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btSDNovo.Image = ((System.Drawing.Image)(resources.GetObject("m_btSDNovo.Image")));
			this.m_btSDNovo.Location = new System.Drawing.Point(80, 14);
			this.m_btSDNovo.Name = "m_btSDNovo";
			this.m_btSDNovo.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btSDNovo.Size = new System.Drawing.Size(25, 25);
			this.m_btSDNovo.TabIndex = 19;
			this.m_btSDNovo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.m_btSDNovo.Click += new System.EventHandler(this.m_btSDNovo_Click);
			// 
			// m_lvSDs
			// 
			this.m_lvSDs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_lvSDs.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																					  this.m_chNumero});
			this.m_lvSDs.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
			this.m_lvSDs.HideSelection = false;
			this.m_lvSDs.Location = new System.Drawing.Point(7, 42);
			this.m_lvSDs.Name = "m_lvSDs";
			this.m_lvSDs.Size = new System.Drawing.Size(223, 128);
			this.m_lvSDs.TabIndex = 0;
			this.m_lvSDs.View = System.Windows.Forms.View.Details;
			this.m_lvSDs.SelectedIndexChanged += new System.EventHandler(this.m_lvSDs_SelectedIndexChanged);
			// 
			// m_chNumero
			// 
			this.m_chNumero.Text = "m_chNumero";
			this.m_chNumero.Width = 200;
			// 
			// m_gbREsVinculados
			// 
			this.m_gbREsVinculados.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_gbREsVinculados.Controls.Add(this.m_lvREsVinculados);
			this.m_gbREsVinculados.Location = new System.Drawing.Point(5, 225);
			this.m_gbREsVinculados.Name = "m_gbREsVinculados";
			this.m_gbREsVinculados.Size = new System.Drawing.Size(481, 88);
			this.m_gbREsVinculados.TabIndex = 15;
			this.m_gbREsVinculados.TabStop = false;
			this.m_gbREsVinculados.Text = "REs vinculados a DDE";
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
			this.m_lvREsVinculados.Size = new System.Drawing.Size(468, 64);
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
			this.m_gbREs.Controls.Add(this.m_lvREs);
			this.m_gbREs.Location = new System.Drawing.Point(246, 6);
			this.m_gbREs.Name = "m_gbREs";
			this.m_gbREs.Size = new System.Drawing.Size(238, 177);
			this.m_gbREs.TabIndex = 14;
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
			this.m_lvREs.Size = new System.Drawing.Size(222, 154);
			this.m_lvREs.TabIndex = 0;
			this.m_lvREs.View = System.Windows.Forms.View.Details;
			// 
			// m_chRENumero
			// 
			this.m_chRENumero.Text = "m_chRENumero";
			this.m_chRENumero.Width = 200;
			// 
			// m_btCancelar
			// 
			this.m_btCancelar.BackColor = System.Drawing.SystemColors.Control;
			this.m_btCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btCancelar.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btCancelar.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btCancelar.Image = ((System.Drawing.Image)(resources.GetObject("m_btCancelar.Image")));
			this.m_btCancelar.Location = new System.Drawing.Point(249, 402);
			this.m_btCancelar.Name = "m_btCancelar";
			this.m_btCancelar.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btCancelar.Size = new System.Drawing.Size(57, 25);
			this.m_btCancelar.TabIndex = 13;
			this.m_btCancelar.Click += new System.EventHandler(this.m_btCancelar_Click);
			// 
			// m_btOk
			// 
			this.m_btOk.BackColor = System.Drawing.SystemColors.Control;
			this.m_btOk.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btOk.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btOk.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btOk.Image = ((System.Drawing.Image)(resources.GetObject("m_btOk.Image")));
			this.m_btOk.Location = new System.Drawing.Point(185, 402);
			this.m_btOk.Name = "m_btOk";
			this.m_btOk.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btOk.Size = new System.Drawing.Size(57, 25);
			this.m_btOk.TabIndex = 12;
			this.m_btOk.Click += new System.EventHandler(this.m_btOk_Click);
			// 
			// frmFSDVincularPE
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(498, 431);
			this.Controls.Add(this.m_gbMain);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmFSDVincularPE";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Vincular REs as DDEs";
			this.Load += new System.EventHandler(this.frmFSDVincularPE_Load);
			this.m_gbMain.ResumeLayout(false);
			this.m_gbPersonalizavel.ResumeLayout(false);
			this.m_gbSDs.ResumeLayout(false);
			this.m_gbREsVinculados.ResumeLayout(false);
			this.m_gbREs.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Eventos
			#region Formulario
				private void frmFSDVincularPE_Load(object sender, System.EventArgs e)
				{
					OnCallRefreshSDs();
					OnCallRefreshREs();
				}
			#endregion
			#region ListViews
				private void m_lvSDs_SelectedIndexChanged(object sender, System.EventArgs e)
				{
					OnCallRefreshREsVinculados();
				}
			#endregion
			#region Botoes
				private void m_btSDNovo_Click(object sender, System.EventArgs e)
				{
					if (OnCallShowSDNovo())
						OnCallRefreshSDs();
				}

				private void m_btSDEditar_Click(object sender, System.EventArgs e)
				{
					if (OnCallShowSDEditar())
						OnCallRefreshSDs();
				}

				private void m_btSDExclui_Click(object sender, System.EventArgs e)
				{
					if (OnCallShowSDRemover())
						OnCallRefreshSDs();
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

				private void m_btOk_Click(object sender, System.EventArgs e)
				{
					this.m_bModificado = true;
					this.Close();
				}

				private void m_btCancelar_Click(object sender, System.EventArgs e)
				{
					this.m_bModificado = false;
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
	}
}
