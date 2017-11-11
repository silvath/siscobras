using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace mdlPesos
{
	/// <summary>
	/// Summary description for frmFPesosUnidade.
	/// </summary>
	public class frmFPesosUnidade : System.Windows.Forms.Form
	{
		#region Delegates
			public delegate void delCallModificaPesoLiquido();
			public delegate void delCallModificaPesoBruto();
		#endregion
		#region Events
			public event delCallModificaPesoLiquido eCallModificaPesoLiquido;	
			public event delCallModificaPesoBruto eCallModificaPesoBruto;	
		#endregion
		#region Events Methods
			protected virtual void OnCallModificaPesoLiquido()
			{
				if (eCallModificaPesoLiquido != null)
					eCallModificaPesoLiquido();
			}

			protected virtual void OnCallModificaPesoBruto()
			{
				if (eCallModificaPesoBruto != null)
					eCallModificaPesoBruto();
			}
		#endregion

		#region Atributes
			private bool m_bModificado = false;
			private System.Windows.Forms.GroupBox m_gbMain;
			private System.Windows.Forms.Button m_btCancel;
			private System.Windows.Forms.Button m_btOk;
			private System.Windows.Forms.GroupBox m_gbFields;
			private System.Windows.Forms.Label m_lPesoBruto;
			private System.Windows.Forms.Label m_lPesoLiquido;
			internal mdlComponentesGraficos.TextBox m_txtPesoBruto;
			internal mdlComponentesGraficos.TextBox m_txtPesoLiquido;
			private System.Windows.Forms.Button m_btUnidadePesoLiquido;
			private System.Windows.Forms.Button m_btUnidadePesoBruto;
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

			public string PesoLiquido
			{
				set
				{
					m_txtPesoLiquido.Text = value;
				}
			}

			public string PesoLiquidoUnidade
			{
				set
				{
					m_btUnidadePesoLiquido.Text = value;
				}
			}

			public string PesoBruto
			{
				set
				{
					m_txtPesoBruto.Text = value;
				}
			}

			public string PesoBrutoUnidade
			{
				set
				{
					m_btUnidadePesoBruto.Text = value;
				}
			}
		#endregion
		#region Constructors and Destructors
			public frmFPesosUnidade(string strEnderecoExecutavel)
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmFPesosUnidade));
			this.m_gbMain = new System.Windows.Forms.GroupBox();
			this.m_gbFields = new System.Windows.Forms.GroupBox();
			this.m_lPesoBruto = new System.Windows.Forms.Label();
			this.m_lPesoLiquido = new System.Windows.Forms.Label();
			this.m_txtPesoBruto = new mdlComponentesGraficos.TextBox();
			this.m_txtPesoLiquido = new mdlComponentesGraficos.TextBox();
			this.m_btUnidadePesoLiquido = new System.Windows.Forms.Button();
			this.m_btUnidadePesoBruto = new System.Windows.Forms.Button();
			this.m_btCancel = new System.Windows.Forms.Button();
			this.m_btOk = new System.Windows.Forms.Button();
			this.m_gbMain.SuspendLayout();
			this.m_gbFields.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_gbMain
			// 
			this.m_gbMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_gbMain.Controls.Add(this.m_gbFields);
			this.m_gbMain.Controls.Add(this.m_btCancel);
			this.m_gbMain.Controls.Add(this.m_btOk);
			this.m_gbMain.Location = new System.Drawing.Point(4, -1);
			this.m_gbMain.Name = "m_gbMain";
			this.m_gbMain.Size = new System.Drawing.Size(339, 116);
			this.m_gbMain.TabIndex = 0;
			this.m_gbMain.TabStop = false;
			// 
			// m_gbFields
			// 
			this.m_gbFields.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_gbFields.Controls.Add(this.m_lPesoBruto);
			this.m_gbFields.Controls.Add(this.m_lPesoLiquido);
			this.m_gbFields.Controls.Add(this.m_txtPesoBruto);
			this.m_gbFields.Controls.Add(this.m_txtPesoLiquido);
			this.m_gbFields.Controls.Add(this.m_btUnidadePesoLiquido);
			this.m_gbFields.Controls.Add(this.m_btUnidadePesoBruto);
			this.m_gbFields.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_gbFields.Location = new System.Drawing.Point(6, 6);
			this.m_gbFields.Name = "m_gbFields";
			this.m_gbFields.Size = new System.Drawing.Size(330, 74);
			this.m_gbFields.TabIndex = 9;
			this.m_gbFields.TabStop = false;
			// 
			// m_lPesoBruto
			// 
			this.m_lPesoBruto.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lPesoBruto.Location = new System.Drawing.Point(10, 43);
			this.m_lPesoBruto.Name = "m_lPesoBruto";
			this.m_lPesoBruto.Size = new System.Drawing.Size(104, 16);
			this.m_lPesoBruto.TabIndex = 0;
			this.m_lPesoBruto.Text = "Peso Bruto Total:";
			// 
			// m_lPesoLiquido
			// 
			this.m_lPesoLiquido.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lPesoLiquido.Location = new System.Drawing.Point(10, 17);
			this.m_lPesoLiquido.Name = "m_lPesoLiquido";
			this.m_lPesoLiquido.Size = new System.Drawing.Size(110, 16);
			this.m_lPesoLiquido.TabIndex = 0;
			this.m_lPesoLiquido.Text = "Peso Líquido Total:";
			// 
			// m_txtPesoBruto
			// 
			this.m_txtPesoBruto.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_txtPesoBruto.Location = new System.Drawing.Point(120, 40);
			this.m_txtPesoBruto.Name = "m_txtPesoBruto";
			this.m_txtPesoBruto.OnlyNumbers = true;
			this.m_txtPesoBruto.ReadOnly = true;
			this.m_txtPesoBruto.Size = new System.Drawing.Size(168, 20);
			this.m_txtPesoBruto.TabIndex = 3;
			this.m_txtPesoBruto.Text = "";
			this.m_txtPesoBruto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// m_txtPesoLiquido
			// 
			this.m_txtPesoLiquido.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_txtPesoLiquido.Location = new System.Drawing.Point(121, 14);
			this.m_txtPesoLiquido.Name = "m_txtPesoLiquido";
			this.m_txtPesoLiquido.OnlyNumbers = true;
			this.m_txtPesoLiquido.ReadOnly = true;
			this.m_txtPesoLiquido.Size = new System.Drawing.Size(167, 20);
			this.m_txtPesoLiquido.TabIndex = 1;
			this.m_txtPesoLiquido.Text = "";
			this.m_txtPesoLiquido.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// m_btUnidadePesoLiquido
			// 
			this.m_btUnidadePesoLiquido.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btUnidadePesoLiquido.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btUnidadePesoLiquido.Location = new System.Drawing.Point(292, 10);
			this.m_btUnidadePesoLiquido.Name = "m_btUnidadePesoLiquido";
			this.m_btUnidadePesoLiquido.Size = new System.Drawing.Size(36, 28);
			this.m_btUnidadePesoLiquido.TabIndex = 10;
			this.m_btUnidadePesoLiquido.Click += new System.EventHandler(this.m_btUnidadePesoLiquido_Click);
			// 
			// m_btUnidadePesoBruto
			// 
			this.m_btUnidadePesoBruto.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btUnidadePesoBruto.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btUnidadePesoBruto.Location = new System.Drawing.Point(292, 39);
			this.m_btUnidadePesoBruto.Name = "m_btUnidadePesoBruto";
			this.m_btUnidadePesoBruto.Size = new System.Drawing.Size(36, 28);
			this.m_btUnidadePesoBruto.TabIndex = 11;
			this.m_btUnidadePesoBruto.Click += new System.EventHandler(this.m_btUnidadePesoBruto_Click);
			// 
			// m_btCancel
			// 
			this.m_btCancel.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.m_btCancel.Image = ((System.Drawing.Image)(resources.GetObject("m_btCancel.Image")));
			this.m_btCancel.Location = new System.Drawing.Point(175, 88);
			this.m_btCancel.Name = "m_btCancel";
			this.m_btCancel.Size = new System.Drawing.Size(57, 25);
			this.m_btCancel.TabIndex = 8;
			this.m_btCancel.Click += new System.EventHandler(this.m_btCancel_Click);
			// 
			// m_btOk
			// 
			this.m_btOk.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btOk.Image = ((System.Drawing.Image)(resources.GetObject("m_btOk.Image")));
			this.m_btOk.Location = new System.Drawing.Point(111, 88);
			this.m_btOk.Name = "m_btOk";
			this.m_btOk.Size = new System.Drawing.Size(57, 25);
			this.m_btOk.TabIndex = 7;
			this.m_btOk.Click += new System.EventHandler(this.m_btOk_Click);
			// 
			// frmFPesosUnidade
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(346, 119);
			this.Controls.Add(this.m_gbMain);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmFPesosUnidade";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Pesos";
			this.m_gbMain.ResumeLayout(false);
			this.m_gbFields.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Eventos
			#region Botoes
				private void m_btUnidadePesoLiquido_Click(object sender, System.EventArgs e)
				{
					OnCallModificaPesoLiquido();
				}

				private void m_btUnidadePesoBruto_Click(object sender, System.EventArgs e)
				{
					OnCallModificaPesoBruto();
				}

				private void m_btOk_Click(object sender, System.EventArgs e)
				{
					m_bModificado = true;
					this.Close();
				}

				private void m_btCancel_Click(object sender, System.EventArgs e)
				{
					m_bModificado = false;
					this.Close();
				}
			#endregion
		#endregion

		#region Cores
			private void vMostraCor(string strEnderecoExecutavel)
			{
				mdlPaletaDeCores.clsPaletaDeCores clsPaletaCores = new mdlPaletaDeCores.clsPaletaDeCores(strEnderecoExecutavel + mdlConstantes.clsConstantes.DEFAULT_CONFIG_FILENAME,"SiscobrasCorSecundaria");
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
