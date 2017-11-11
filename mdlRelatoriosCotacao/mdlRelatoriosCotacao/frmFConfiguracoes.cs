using System;
//using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace mdlRelatoriosCotacao
{
	/// <summary>
	/// Summary description for frmFConfiguracoes.
	/// </summary>
	public class frmFConfiguracoes : System.Windows.Forms.Form
	{
		#region Delegates
			public delegate void delCallCarregaDados(out int nTipoAgrupamento,out bool bDetalharProdutos,out bool bMostrarGrupo);
			public delegate bool delCallSalvaDados(int nTipoAgrupamento,bool bDetalharProdutos,bool bMostrarGrupo);
		#endregion
		#region Events
			public event delCallCarregaDados eCallCarregaDados;	
			public event delCallSalvaDados eCallSalvaDados;	
		#endregion
		#region Events Methods
			protected virtual void OnCallCarregaDados()
			{
				if (eCallCarregaDados != null)
				{
					int nTipoAgrupamento;
					bool bDetalharProdutos;
					bool bMostrarGrupo;
					eCallCarregaDados(out nTipoAgrupamento,out bDetalharProdutos,out bMostrarGrupo);
					switch(nTipoAgrupamento)
					{
						case 0:
							m_rbNormal.Checked = true;
							break;
						case 1:
							m_rbNcm.Checked = true;
							break;
						case 2:
							m_rbNaladi.Checked = true;
							break;
						case 3:
							m_rbGrupoPersonalizavel.Checked = true;
							break;

					}
					m_ckDetalhesProdutos.Checked = bDetalharProdutos;
					m_ckMostrarGrupo.Checked = bMostrarGrupo;
					RefreshInterface();
				}
			}

			protected virtual bool OnCallSalvaDados()
			{
				bool bRetorno = false;
				if (eCallSalvaDados != null)
				{
					int nTipoAgrupamento = 0;
					if (m_rbNormal.Checked)
						nTipoAgrupamento = 0;
					if (m_rbNcm.Checked)
						nTipoAgrupamento = 1;
					if (m_rbNaladi.Checked)
						nTipoAgrupamento = 2;
					if (m_rbGrupoPersonalizavel.Checked)
						nTipoAgrupamento = 3;
					bRetorno = eCallSalvaDados(nTipoAgrupamento,m_ckDetalhesProdutos.Checked,m_ckMostrarGrupo.Checked);
				}
				return(bRetorno);
			}
		#endregion

		#region Atributes
			private bool m_bModificado = false;

			private System.Windows.Forms.GroupBox m_gbMain;
			internal System.Windows.Forms.Button m_btOk;
			internal System.Windows.Forms.Button m_btCancelar;
			private System.Windows.Forms.GroupBox m_gbApresentar;
			private System.Windows.Forms.CheckBox m_ckDetalhesProdutos;
		private System.Windows.Forms.GroupBox m_gbAgrupar;
		private System.Windows.Forms.RadioButton m_rbNaladi;
		private System.Windows.Forms.RadioButton m_rbNcm;
		private System.Windows.Forms.RadioButton m_rbNormal;
		private System.Windows.Forms.RadioButton m_rbGrupoPersonalizavel;
		private System.Windows.Forms.GroupBox m_ckMostrar;
		private System.Windows.Forms.CheckBox m_ckMostrarGrupo;
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
	
			public bool DetalharProdutos
			{
				set
				{
					m_ckDetalhesProdutos.Checked = value;
				}
				get
				{
					return(m_ckDetalhesProdutos.Checked);
				}
			}
		#endregion
		#region Constructor and Destructors
	 		public frmFConfiguracoes(string strEnderecoExecutavel)
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmFConfiguracoes));
			this.m_gbMain = new System.Windows.Forms.GroupBox();
			this.m_gbAgrupar = new System.Windows.Forms.GroupBox();
			this.m_rbGrupoPersonalizavel = new System.Windows.Forms.RadioButton();
			this.m_rbNaladi = new System.Windows.Forms.RadioButton();
			this.m_rbNcm = new System.Windows.Forms.RadioButton();
			this.m_rbNormal = new System.Windows.Forms.RadioButton();
			this.m_btOk = new System.Windows.Forms.Button();
			this.m_btCancelar = new System.Windows.Forms.Button();
			this.m_gbApresentar = new System.Windows.Forms.GroupBox();
			this.m_ckDetalhesProdutos = new System.Windows.Forms.CheckBox();
			this.m_ckMostrar = new System.Windows.Forms.GroupBox();
			this.m_ckMostrarGrupo = new System.Windows.Forms.CheckBox();
			this.m_gbMain.SuspendLayout();
			this.m_gbAgrupar.SuspendLayout();
			this.m_gbApresentar.SuspendLayout();
			this.m_ckMostrar.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_gbMain
			// 
			this.m_gbMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_gbMain.Controls.Add(this.m_ckMostrar);
			this.m_gbMain.Controls.Add(this.m_gbAgrupar);
			this.m_gbMain.Location = new System.Drawing.Point(5, -2);
			this.m_gbMain.Name = "m_gbMain";
			this.m_gbMain.Size = new System.Drawing.Size(264, 204);
			this.m_gbMain.TabIndex = 0;
			this.m_gbMain.TabStop = false;
			// 
			// m_gbAgrupar
			// 
			this.m_gbAgrupar.Controls.Add(this.m_rbGrupoPersonalizavel);
			this.m_gbAgrupar.Controls.Add(this.m_rbNaladi);
			this.m_gbAgrupar.Controls.Add(this.m_rbNcm);
			this.m_gbAgrupar.Controls.Add(this.m_rbNormal);
			this.m_gbAgrupar.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_gbAgrupar.Location = new System.Drawing.Point(8, 8);
			this.m_gbAgrupar.Name = "m_gbAgrupar";
			this.m_gbAgrupar.Size = new System.Drawing.Size(249, 88);
			this.m_gbAgrupar.TabIndex = 18;
			this.m_gbAgrupar.TabStop = false;
			this.m_gbAgrupar.Text = "Agrupar por";
			// 
			// m_rbGrupoPersonalizavel
			// 
			this.m_rbGrupoPersonalizavel.Location = new System.Drawing.Point(8, 63);
			this.m_rbGrupoPersonalizavel.Name = "m_rbGrupoPersonalizavel";
			this.m_rbGrupoPersonalizavel.Size = new System.Drawing.Size(184, 16);
			this.m_rbGrupoPersonalizavel.TabIndex = 3;
			this.m_rbGrupoPersonalizavel.Text = "Grupo Personalizavel";
			this.m_rbGrupoPersonalizavel.CheckedChanged += new System.EventHandler(this.m_rbGrupoPersonalizavel_CheckedChanged);
			// 
			// m_rbNaladi
			// 
			this.m_rbNaladi.Location = new System.Drawing.Point(8, 48);
			this.m_rbNaladi.Name = "m_rbNaladi";
			this.m_rbNaladi.Size = new System.Drawing.Size(184, 16);
			this.m_rbNaladi.TabIndex = 2;
			this.m_rbNaladi.Text = "Naladi";
			this.m_rbNaladi.CheckedChanged += new System.EventHandler(this.m_rbNaladi_CheckedChanged);
			// 
			// m_rbNcm
			// 
			this.m_rbNcm.Location = new System.Drawing.Point(9, 32);
			this.m_rbNcm.Name = "m_rbNcm";
			this.m_rbNcm.Size = new System.Drawing.Size(184, 16);
			this.m_rbNcm.TabIndex = 1;
			this.m_rbNcm.Text = "Ncm";
			this.m_rbNcm.CheckedChanged += new System.EventHandler(this.m_rbNcm_CheckedChanged);
			// 
			// m_rbNormal
			// 
			this.m_rbNormal.Checked = true;
			this.m_rbNormal.Location = new System.Drawing.Point(9, 16);
			this.m_rbNormal.Name = "m_rbNormal";
			this.m_rbNormal.Size = new System.Drawing.Size(184, 16);
			this.m_rbNormal.TabIndex = 0;
			this.m_rbNormal.TabStop = true;
			this.m_rbNormal.Text = "Normal";
			this.m_rbNormal.CheckedChanged += new System.EventHandler(this.m_rbNormal_CheckedChanged);
			// 
			// m_btOk
			// 
			this.m_btOk.BackColor = System.Drawing.SystemColors.Control;
			this.m_btOk.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btOk.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btOk.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btOk.Image = ((System.Drawing.Image)(resources.GetObject("m_btOk.Image")));
			this.m_btOk.Location = new System.Drawing.Point(77, 171);
			this.m_btOk.Name = "m_btOk";
			this.m_btOk.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btOk.Size = new System.Drawing.Size(57, 25);
			this.m_btOk.TabIndex = 22;
			this.m_btOk.Click += new System.EventHandler(this.m_btOk_Click);
			// 
			// m_btCancelar
			// 
			this.m_btCancelar.BackColor = System.Drawing.SystemColors.Control;
			this.m_btCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btCancelar.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btCancelar.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btCancelar.Image = ((System.Drawing.Image)(resources.GetObject("m_btCancelar.Image")));
			this.m_btCancelar.Location = new System.Drawing.Point(141, 171);
			this.m_btCancelar.Name = "m_btCancelar";
			this.m_btCancelar.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btCancelar.Size = new System.Drawing.Size(57, 25);
			this.m_btCancelar.TabIndex = 23;
			this.m_btCancelar.Click += new System.EventHandler(this.m_btCancelar_Click);
			// 
			// m_gbApresentar
			// 
			this.m_gbApresentar.Controls.Add(this.m_ckDetalhesProdutos);
			this.m_gbApresentar.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_gbApresentar.Location = new System.Drawing.Point(11, 93);
			this.m_gbApresentar.Name = "m_gbApresentar";
			this.m_gbApresentar.Size = new System.Drawing.Size(249, 38);
			this.m_gbApresentar.TabIndex = 21;
			this.m_gbApresentar.TabStop = false;
			this.m_gbApresentar.Text = "Detalhar";
			// 
			// m_ckDetalhesProdutos
			// 
			this.m_ckDetalhesProdutos.Location = new System.Drawing.Point(9, 15);
			this.m_ckDetalhesProdutos.Name = "m_ckDetalhesProdutos";
			this.m_ckDetalhesProdutos.Size = new System.Drawing.Size(223, 16);
			this.m_ckDetalhesProdutos.TabIndex = 0;
			this.m_ckDetalhesProdutos.Text = "Produtos filhos";
			// 
			// m_ckMostrar
			// 
			this.m_ckMostrar.Controls.Add(this.m_ckMostrarGrupo);
			this.m_ckMostrar.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_ckMostrar.Location = new System.Drawing.Point(5, 132);
			this.m_ckMostrar.Name = "m_ckMostrar";
			this.m_ckMostrar.Size = new System.Drawing.Size(249, 38);
			this.m_ckMostrar.TabIndex = 22;
			this.m_ckMostrar.TabStop = false;
			this.m_ckMostrar.Text = "Mostrar";
			// 
			// m_ckMostrarGrupo
			// 
			this.m_ckMostrarGrupo.Location = new System.Drawing.Point(9, 15);
			this.m_ckMostrarGrupo.Name = "m_ckMostrarGrupo";
			this.m_ckMostrarGrupo.Size = new System.Drawing.Size(223, 16);
			this.m_ckMostrarGrupo.TabIndex = 0;
			this.m_ckMostrarGrupo.Text = "Grupo";
			// 
			// frmFConfiguracoes
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(274, 203);
			this.Controls.Add(this.m_btOk);
			this.Controls.Add(this.m_btCancelar);
			this.Controls.Add(this.m_gbApresentar);
			this.Controls.Add(this.m_gbMain);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmFConfiguracoes";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Configurações";
			this.Load += new System.EventHandler(this.frmFConfiguracoes_Load);
			this.m_gbMain.ResumeLayout(false);
			this.m_gbAgrupar.ResumeLayout(false);
			this.m_gbApresentar.ResumeLayout(false);
			this.m_ckMostrar.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Eventos
			#region Formulario
				private void frmFConfiguracoes_Load(object sender, System.EventArgs e)
				{
					OnCallCarregaDados();
				}
			#endregion
			#region RadioButtons
				private void m_rbNormal_CheckedChanged(object sender, System.EventArgs e)
				{
					RefreshInterface();
				}

				private void m_rbNcm_CheckedChanged(object sender, System.EventArgs e)
				{
					RefreshInterface();
				}

				private void m_rbNaladi_CheckedChanged(object sender, System.EventArgs e)
				{
					RefreshInterface();
				}

				private void m_rbGrupoPersonalizavel_CheckedChanged(object sender, System.EventArgs e)
				{
					RefreshInterface();
				}
			#endregion
			#region Botoes
				private void m_btOk_Click(object sender, System.EventArgs e)
				{
					if (m_bModificado = OnCallSalvaDados())
					{
						this.Close();
					}
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

		#region Refresh
			private void RefreshInterface()
			{
				m_ckMostrarGrupo.Enabled = m_rbGrupoPersonalizavel.Checked;
			}
		#endregion
	}
}
