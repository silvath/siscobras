using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace mdlRelatoriosRomaneio.Formularios
{
	/// <summary>
	/// Summary description for frmFConfiguracoesProdutos.
	/// </summary>
	public class frmFConfiguracoesProdutos : System.Windows.Forms.Form
	{
		#region Atributes
			private string m_strEnderecoExecutavel= "";
			private bool m_bModificado = false;

			private System.Windows.Forms.GroupBox m_gbMain;
			private System.Windows.Forms.Button m_btOk;
			private System.Windows.Forms.Button m_btCancelar;
		private System.Windows.Forms.CheckBox m_ckReplicarInformacoesVolumes;
		private System.Windows.Forms.CheckBox m_ckMostrarVolumesConscutivos;
		private System.Windows.Forms.CheckBox m_ckMostrarEmbalagensConsecutivas;
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

			public bool MostrarVolumesConsecutivos
			{
				set
				{
					m_ckMostrarVolumesConscutivos.Checked = value;
				}
				get
				{
					return(m_ckMostrarVolumesConscutivos.Checked);
				}
			}

			public bool MostrarEmbalagensConsecutivos
			{
				set
				{
					m_ckMostrarEmbalagensConsecutivas.Checked = value;
				}
				get
				{
					return(m_ckMostrarEmbalagensConsecutivas.Checked);
				}
			}
		
			public bool ReplicarInformacoesVolumes
			{
				set
				{
					m_ckReplicarInformacoesVolumes.Checked = value;
				}
				get
				{
					return(m_ckReplicarInformacoesVolumes.Checked);
				}
			}
		#endregion
		#region Constructors and Destructors
			public frmFConfiguracoesProdutos(string strEnderecoExecutavel)
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmFConfiguracoesProdutos));
			this.m_gbMain = new System.Windows.Forms.GroupBox();
			this.m_btOk = new System.Windows.Forms.Button();
			this.m_btCancelar = new System.Windows.Forms.Button();
			this.m_ckReplicarInformacoesVolumes = new System.Windows.Forms.CheckBox();
			this.m_ckMostrarVolumesConscutivos = new System.Windows.Forms.CheckBox();
			this.m_ckMostrarEmbalagensConsecutivas = new System.Windows.Forms.CheckBox();
			this.m_gbMain.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_gbMain
			// 
			this.m_gbMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_gbMain.Controls.Add(this.m_ckMostrarEmbalagensConsecutivas);
			this.m_gbMain.Controls.Add(this.m_ckMostrarVolumesConscutivos);
			this.m_gbMain.Controls.Add(this.m_btOk);
			this.m_gbMain.Controls.Add(this.m_btCancelar);
			this.m_gbMain.Controls.Add(this.m_ckReplicarInformacoesVolumes);
			this.m_gbMain.Location = new System.Drawing.Point(6, -2);
			this.m_gbMain.Name = "m_gbMain";
			this.m_gbMain.Size = new System.Drawing.Size(224, 100);
			this.m_gbMain.TabIndex = 1;
			this.m_gbMain.TabStop = false;
			// 
			// m_btOk
			// 
			this.m_btOk.BackColor = System.Drawing.SystemColors.Control;
			this.m_btOk.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btOk.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btOk.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btOk.Image = ((System.Drawing.Image)(resources.GetObject("m_btOk.Image")));
			this.m_btOk.Location = new System.Drawing.Point(51, 70);
			this.m_btOk.Name = "m_btOk";
			this.m_btOk.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btOk.Size = new System.Drawing.Size(57, 25);
			this.m_btOk.TabIndex = 7;
			this.m_btOk.Click += new System.EventHandler(this.m_btOk_Click);
			// 
			// m_btCancelar
			// 
			this.m_btCancelar.BackColor = System.Drawing.SystemColors.Control;
			this.m_btCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btCancelar.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btCancelar.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btCancelar.Image = ((System.Drawing.Image)(resources.GetObject("m_btCancelar.Image")));
			this.m_btCancelar.Location = new System.Drawing.Point(115, 70);
			this.m_btCancelar.Name = "m_btCancelar";
			this.m_btCancelar.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btCancelar.Size = new System.Drawing.Size(57, 25);
			this.m_btCancelar.TabIndex = 8;
			this.m_btCancelar.Click += new System.EventHandler(this.m_btCancelar_Click);
			// 
			// m_ckReplicarInformacoesVolumes
			// 
			this.m_ckReplicarInformacoesVolumes.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_ckReplicarInformacoesVolumes.Location = new System.Drawing.Point(5, 48);
			this.m_ckReplicarInformacoesVolumes.Name = "m_ckReplicarInformacoesVolumes";
			this.m_ckReplicarInformacoesVolumes.Size = new System.Drawing.Size(208, 16);
			this.m_ckReplicarInformacoesVolumes.TabIndex = 0;
			this.m_ckReplicarInformacoesVolumes.Text = "Replicar informações volumes";
			// 
			// m_ckMostrarVolumesConscutivos
			// 
			this.m_ckMostrarVolumesConscutivos.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_ckMostrarVolumesConscutivos.Location = new System.Drawing.Point(5, 12);
			this.m_ckMostrarVolumesConscutivos.Name = "m_ckMostrarVolumesConscutivos";
			this.m_ckMostrarVolumesConscutivos.Size = new System.Drawing.Size(208, 16);
			this.m_ckMostrarVolumesConscutivos.TabIndex = 9;
			this.m_ckMostrarVolumesConscutivos.Text = "Mostrar Volumes Consecutivos";
			// 
			// m_ckMostrarEmbalagensConsecutivas
			// 
			this.m_ckMostrarEmbalagensConsecutivas.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_ckMostrarEmbalagensConsecutivas.Location = new System.Drawing.Point(5, 30);
			this.m_ckMostrarEmbalagensConsecutivas.Name = "m_ckMostrarEmbalagensConsecutivas";
			this.m_ckMostrarEmbalagensConsecutivas.Size = new System.Drawing.Size(216, 16);
			this.m_ckMostrarEmbalagensConsecutivas.TabIndex = 10;
			this.m_ckMostrarEmbalagensConsecutivas.Text = "Mostrar Embalabens Consecutivas";
			// 
			// frmFConfiguracoesProdutos
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(234, 103);
			this.Controls.Add(this.m_gbMain);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmFConfiguracoesProdutos";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Configurações";
			this.m_gbMain.ResumeLayout(false);
			this.ResumeLayout(false);

		}
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

		#region Eventos
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
			#endregion
		#endregion
	}
}
