using System;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace mdlPEInfo
{
	/// <summary>
	/// Summary description for frmFPDF.
	/// </summary>
	internal class frmFPDF : System.Windows.Forms.Form
	{
		#region Delegates
			public delegate void delCallCarregaDocumentos(ref System.Windows.Forms.TreeView tvDocumentos);
			public delegate int delCallCarregaIndexImagemRelatorio(int nIdRelatorio);
			public delegate bool delCallSalvarPDF(ref System.Windows.Forms.TreeView tvPDF);
		#endregion
		#region Events
			public event delCallCarregaDocumentos eCallCarregaDocumentos;
			public event delCallCarregaIndexImagemRelatorio eCallCarregaIndexImagemRelatorio;
			public event delCallSalvarPDF eCallSalvarPDF;
		#endregion
		#region Events Methods
			protected virtual void OnCallCarregaDocumentos()
			{
				if (eCallCarregaDocumentos != null)
					eCallCarregaDocumentos(ref m_tvDocumentos);
			}

			protected virtual int OnCallCarregaIndexImagemRelatorio(int nIdRelatorio)
			{
				int nReturn = 0;
				if (eCallCarregaIndexImagemRelatorio != null)
					nReturn = eCallCarregaIndexImagemRelatorio(nIdRelatorio);
				return(nReturn);
			}

			protected virtual bool OnCallSalvarPDF()
			{
				bool bRetorno = false;
				if (eCallSalvarPDF != null)
					bRetorno = eCallSalvarPDF(ref m_tvPDF);
				return(bRetorno);
			}
		#endregion

		#region Atributos
			private System.Windows.Forms.ToolTip m_ttDicas;
			private System.Windows.Forms.Button m_btRetira;
			private System.Windows.Forms.Button m_btInsere;
			private System.ComponentModel.IContainer components;
			private System.Windows.Forms.GroupBox m_gbPrincipal;
			private System.Windows.Forms.Button m_btOk;
		private System.Windows.Forms.ImageList m_ilDocumentos;
		public System.Windows.Forms.Button m_btDocumentoAcima;
		public System.Windows.Forms.Button m_btDocumentoAbaixo;
		private System.Windows.Forms.GroupBox m_gbDocumentosDisponiveis;
		private System.Windows.Forms.TreeView m_tvDocumentos;
		private System.Windows.Forms.GroupBox m_gbDocumentosExportar;
		private System.Windows.Forms.TreeView m_tvPDF;
			private System.Windows.Forms.Button m_btCancelar;
		#endregion
		#region Construtores
			public frmFPDF(System.Drawing.Color clrCor)
			{
				InitializeComponent();
				vMostraCor(clrCor);
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmFPDF));
			this.m_gbPrincipal = new System.Windows.Forms.GroupBox();
			this.m_gbDocumentosExportar = new System.Windows.Forms.GroupBox();
			this.m_tvPDF = new System.Windows.Forms.TreeView();
			this.m_ilDocumentos = new System.Windows.Forms.ImageList(this.components);
			this.m_btDocumentoAcima = new System.Windows.Forms.Button();
			this.m_btDocumentoAbaixo = new System.Windows.Forms.Button();
			this.m_gbDocumentosDisponiveis = new System.Windows.Forms.GroupBox();
			this.m_tvDocumentos = new System.Windows.Forms.TreeView();
			this.m_btRetira = new System.Windows.Forms.Button();
			this.m_btInsere = new System.Windows.Forms.Button();
			this.m_btOk = new System.Windows.Forms.Button();
			this.m_btCancelar = new System.Windows.Forms.Button();
			this.m_ttDicas = new System.Windows.Forms.ToolTip(this.components);
			this.m_gbPrincipal.SuspendLayout();
			this.m_gbDocumentosExportar.SuspendLayout();
			this.m_gbDocumentosDisponiveis.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_gbPrincipal
			// 
			this.m_gbPrincipal.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_gbPrincipal.Controls.Add(this.m_gbDocumentosExportar);
			this.m_gbPrincipal.Controls.Add(this.m_gbDocumentosDisponiveis);
			this.m_gbPrincipal.Controls.Add(this.m_btRetira);
			this.m_gbPrincipal.Controls.Add(this.m_btInsere);
			this.m_gbPrincipal.Controls.Add(this.m_btOk);
			this.m_gbPrincipal.Controls.Add(this.m_btCancelar);
			this.m_gbPrincipal.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_gbPrincipal.Location = new System.Drawing.Point(4, -2);
			this.m_gbPrincipal.Name = "m_gbPrincipal";
			this.m_gbPrincipal.Size = new System.Drawing.Size(428, 536);
			this.m_gbPrincipal.TabIndex = 0;
			this.m_gbPrincipal.TabStop = false;
			// 
			// m_gbDocumentosExportar
			// 
			this.m_gbDocumentosExportar.Controls.Add(this.m_tvPDF);
			this.m_gbDocumentosExportar.Controls.Add(this.m_btDocumentoAcima);
			this.m_gbDocumentosExportar.Controls.Add(this.m_btDocumentoAbaixo);
			this.m_gbDocumentosExportar.Location = new System.Drawing.Point(6, 277);
			this.m_gbDocumentosExportar.Name = "m_gbDocumentosExportar";
			this.m_gbDocumentosExportar.Size = new System.Drawing.Size(418, 230);
			this.m_gbDocumentosExportar.TabIndex = 65;
			this.m_gbDocumentosExportar.TabStop = false;
			this.m_gbDocumentosExportar.Text = "Documentos Exportar";
			// 
			// m_tvPDF
			// 
			this.m_tvPDF.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_tvPDF.HideSelection = false;
			this.m_tvPDF.ImageList = this.m_ilDocumentos;
			this.m_tvPDF.Location = new System.Drawing.Point(40, 13);
			this.m_tvPDF.Name = "m_tvPDF";
			this.m_tvPDF.SelectedImageIndex = 10;
			this.m_tvPDF.Size = new System.Drawing.Size(370, 211);
			this.m_tvPDF.TabIndex = 64;
			// 
			// m_ilDocumentos
			// 
			this.m_ilDocumentos.ImageSize = new System.Drawing.Size(16, 16);
			this.m_ilDocumentos.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("m_ilDocumentos.ImageStream")));
			this.m_ilDocumentos.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// m_btDocumentoAcima
			// 
			this.m_btDocumentoAcima.BackColor = System.Drawing.SystemColors.Control;
			this.m_btDocumentoAcima.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btDocumentoAcima.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btDocumentoAcima.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btDocumentoAcima.Image = ((System.Drawing.Image)(resources.GetObject("m_btDocumentoAcima.Image")));
			this.m_btDocumentoAcima.Location = new System.Drawing.Point(7, 91);
			this.m_btDocumentoAcima.Name = "m_btDocumentoAcima";
			this.m_btDocumentoAcima.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btDocumentoAcima.Size = new System.Drawing.Size(25, 25);
			this.m_btDocumentoAcima.TabIndex = 62;
			this.m_ttDicas.SetToolTip(this.m_btDocumentoAcima, "Move documento para cima");
			this.m_btDocumentoAcima.Click += new System.EventHandler(this.m_btDocumentoAcima_Click);
			// 
			// m_btDocumentoAbaixo
			// 
			this.m_btDocumentoAbaixo.BackColor = System.Drawing.SystemColors.Control;
			this.m_btDocumentoAbaixo.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btDocumentoAbaixo.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btDocumentoAbaixo.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btDocumentoAbaixo.Image = ((System.Drawing.Image)(resources.GetObject("m_btDocumentoAbaixo.Image")));
			this.m_btDocumentoAbaixo.Location = new System.Drawing.Point(7, 123);
			this.m_btDocumentoAbaixo.Name = "m_btDocumentoAbaixo";
			this.m_btDocumentoAbaixo.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btDocumentoAbaixo.Size = new System.Drawing.Size(25, 25);
			this.m_btDocumentoAbaixo.TabIndex = 63;
			this.m_ttDicas.SetToolTip(this.m_btDocumentoAbaixo, "Mover documento para baixo");
			this.m_btDocumentoAbaixo.Click += new System.EventHandler(this.m_btDocumentoAbaixo_Click);
			// 
			// m_gbDocumentosDisponiveis
			// 
			this.m_gbDocumentosDisponiveis.Controls.Add(this.m_tvDocumentos);
			this.m_gbDocumentosDisponiveis.Location = new System.Drawing.Point(6, 7);
			this.m_gbDocumentosDisponiveis.Name = "m_gbDocumentosDisponiveis";
			this.m_gbDocumentosDisponiveis.Size = new System.Drawing.Size(417, 233);
			this.m_gbDocumentosDisponiveis.TabIndex = 64;
			this.m_gbDocumentosDisponiveis.TabStop = false;
			this.m_gbDocumentosDisponiveis.Text = "Documentos Disponíveis";
			// 
			// m_tvDocumentos
			// 
			this.m_tvDocumentos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_tvDocumentos.HideSelection = false;
			this.m_tvDocumentos.ImageList = this.m_ilDocumentos;
			this.m_tvDocumentos.Location = new System.Drawing.Point(5, 13);
			this.m_tvDocumentos.Name = "m_tvDocumentos";
			this.m_tvDocumentos.SelectedImageIndex = 10;
			this.m_tvDocumentos.Size = new System.Drawing.Size(405, 215);
			this.m_tvDocumentos.TabIndex = 17;
			// 
			// m_btRetira
			// 
			this.m_btRetira.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btRetira.Image = ((System.Drawing.Image)(resources.GetObject("m_btRetira.Image")));
			this.m_btRetira.Location = new System.Drawing.Point(218, 242);
			this.m_btRetira.Name = "m_btRetira";
			this.m_btRetira.Size = new System.Drawing.Size(40, 35);
			this.m_btRetira.TabIndex = 40;
			this.m_ttDicas.SetToolTip(this.m_btRetira, "Remover documento");
			this.m_btRetira.Click += new System.EventHandler(this.m_btRetira_Click);
			// 
			// m_btInsere
			// 
			this.m_btInsere.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btInsere.Image = ((System.Drawing.Image)(resources.GetObject("m_btInsere.Image")));
			this.m_btInsere.Location = new System.Drawing.Point(170, 242);
			this.m_btInsere.Name = "m_btInsere";
			this.m_btInsere.Size = new System.Drawing.Size(40, 35);
			this.m_btInsere.TabIndex = 14;
			this.m_ttDicas.SetToolTip(this.m_btInsere, "Inserir documento");
			this.m_btInsere.Click += new System.EventHandler(this.m_btInsere_Click);
			// 
			// m_btOk
			// 
			this.m_btOk.BackColor = System.Drawing.SystemColors.Control;
			this.m_btOk.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btOk.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btOk.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btOk.Image = ((System.Drawing.Image)(resources.GetObject("m_btOk.Image")));
			this.m_btOk.Location = new System.Drawing.Point(154, 508);
			this.m_btOk.Name = "m_btOk";
			this.m_btOk.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btOk.Size = new System.Drawing.Size(57, 25);
			this.m_btOk.TabIndex = 10;
			this.m_ttDicas.SetToolTip(this.m_btOk, "Criar documento");
			this.m_btOk.Click += new System.EventHandler(this.m_btOk_Click);
			// 
			// m_btCancelar
			// 
			this.m_btCancelar.BackColor = System.Drawing.SystemColors.Control;
			this.m_btCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btCancelar.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btCancelar.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btCancelar.Image = ((System.Drawing.Image)(resources.GetObject("m_btCancelar.Image")));
			this.m_btCancelar.Location = new System.Drawing.Point(218, 508);
			this.m_btCancelar.Name = "m_btCancelar";
			this.m_btCancelar.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btCancelar.Size = new System.Drawing.Size(57, 25);
			this.m_btCancelar.TabIndex = 11;
			this.m_ttDicas.SetToolTip(this.m_btCancelar, "Cancelar");
			this.m_btCancelar.Click += new System.EventHandler(this.m_btCancelar_Click);
			// 
			// m_ttDicas
			// 
			this.m_ttDicas.AutomaticDelay = 100;
			this.m_ttDicas.AutoPopDelay = 5000;
			this.m_ttDicas.InitialDelay = 100;
			this.m_ttDicas.ReshowDelay = 20;
			// 
			// frmFPDF
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(434, 535);
			this.Controls.Add(this.m_gbPrincipal);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmFPDF";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Exportar Documento";
			this.Load += new System.EventHandler(this.frmFPDF_Load);
			this.m_gbPrincipal.ResumeLayout(false);
			this.m_gbDocumentosExportar.ResumeLayout(false);
			this.m_gbDocumentosDisponiveis.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Eventos
			#region Formulario
				private void frmFPDF_Load(object sender, System.EventArgs e)
				{
					OnCallCarregaDocumentos();
				
				}
			#endregion
			#region Botoes
				private void m_btInsere_Click(object sender, System.EventArgs e)
				{
					if (m_tvDocumentos.SelectedNode != null)
					{
						System.Windows.Forms.TreeNode tvnCurrent = m_tvDocumentos.SelectedNode;
						m_tvDocumentos.Nodes.Remove(m_tvDocumentos.SelectedNode);
						m_tvPDF.Nodes.Add(tvnCurrent);
						m_tvDocumentos.SelectedNode = null;
						}
				}

				private void m_btRetira_Click(object sender, System.EventArgs e)
				{
					if (m_tvPDF.SelectedNode != null)
					{
						System.Windows.Forms.TreeNode tvnCurrent = m_tvPDF.SelectedNode;
						m_tvPDF.Nodes.Remove(m_tvPDF.SelectedNode);
						m_tvDocumentos.Nodes.Add(tvnCurrent);
						m_tvPDF.SelectedNode = null;
					}
				}

				private void m_btDocumentoAcima_Click(object sender, System.EventArgs e)
				{
					if ((m_tvPDF.SelectedNode != null) && (m_tvPDF.SelectedNode.PrevNode != null))
					{
						System.Windows.Forms.TreeNode clone = (System.Windows.Forms.TreeNode)m_tvPDF.SelectedNode.Clone();
						m_tvPDF.SelectedNode.Text = m_tvPDF.SelectedNode.PrevNode.Text;
						m_tvPDF.SelectedNode.ImageIndex = m_tvPDF.SelectedNode.PrevNode.ImageIndex;
						m_tvPDF.SelectedNode.Tag = m_tvPDF.SelectedNode.PrevNode.Tag;
						m_tvPDF.SelectedNode = m_tvPDF.SelectedNode.PrevNode;
						m_tvPDF.SelectedNode.Text = clone.Text;
						m_tvPDF.SelectedNode.ImageIndex = clone.ImageIndex;
						m_tvPDF.SelectedNode.Tag = clone.Tag;
					}
				}

				private void m_btDocumentoAbaixo_Click(object sender, System.EventArgs e)
				{
					if ((m_tvPDF.SelectedNode != null) && (m_tvPDF.SelectedNode.NextNode != null))
					{
						System.Windows.Forms.TreeNode clone = (System.Windows.Forms.TreeNode)m_tvPDF.SelectedNode.Clone();
						m_tvPDF.SelectedNode.Text = m_tvPDF.SelectedNode.NextNode.Text;
						m_tvPDF.SelectedNode.ImageIndex = m_tvPDF.SelectedNode.NextNode.ImageIndex;
						m_tvPDF.SelectedNode.Tag = m_tvPDF.SelectedNode.NextNode.Tag;
						m_tvPDF.SelectedNode = m_tvPDF.SelectedNode.NextNode;
						m_tvPDF.SelectedNode.Text = clone.Text;
						m_tvPDF.SelectedNode.ImageIndex = clone.ImageIndex;
						m_tvPDF.SelectedNode.Tag = clone.Tag;
					}
				}

				private void m_btOk_Click(object sender, System.EventArgs e)
				{
					if (m_tvPDF.Nodes.Count > 0)
						if (OnCallSalvarPDF())
							this.Close();
				}

				private void m_btCancelar_Click(object sender, System.EventArgs e)
				{
					this.Close();
				}
			#endregion
		#endregion

		#region Cores
		private void vMostraCor(System.Drawing.Color clrCor)
		{
			this.BackColor = clrCor;
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
				case "System.Windows.Forms.TreeView":
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
