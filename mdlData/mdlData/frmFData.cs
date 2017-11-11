using System;
using System.Collections;
using System.Windows.Forms;

namespace mdlData
{
	/// <summary>
	/// Summary description for frmFData.
	/// </summary>
	internal class frmFData : mdlComponentesGraficos.FormFlutuante
	{
		#region Delegate
			public delegate void delCallLoadInterface(out System.DateTime dtDate,out string strFormat,out System.Globalization.CultureInfo ciIdiom,out string strName);
			public delegate bool delCallShowFormat();
			public delegate bool delCallSaveInterface(System.DateTime dtDate);
		#endregion
		#region Events
			public event delCallLoadInterface eCallLoadInterface;
			public event delCallShowFormat eCallShowFormat;
			public event delCallSaveInterface eCallSaveInterface;
		#endregion
		#region Events Methods
			protected virtual void OnCallLoadInterface()
			{
				if (eCallLoadInterface != null)
				{
					System.DateTime dtDate;
					string strFormat,strName;
					System.Globalization.CultureInfo ciIdiom;
					eCallLoadInterface(out dtDate,out strFormat,out ciIdiom,out strName);
					m_dtDate.CustomFormat = strFormat;
					m_ciIdiomSecondary = ciIdiom;
					m_dtDate.Value = dtDate;
					m_gbDate.Text = strName;
				}
			}
	 
			protected virtual bool OnCallShowFormat()
			{
				bool bReturn = false;
				if (eCallShowFormat != null)
					bReturn = eCallShowFormat();
				return(bReturn);
			}
			protected virtual bool OnCallSaveInterface()
			{
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				bool bReturn = false;
				if (eCallSaveInterface != null)
					bReturn = eCallSaveInterface(m_dtDate.Value);
				this.Cursor = System.Windows.Forms.Cursors.Default;
				return(bReturn);
			}
		#endregion

		#region Atributos
			private mdlTratamentoErro.clsTratamentoErro m_cls_ter_tratadorErro = null;
			private string m_strEnderecoExecutavel = "";
			private System.Globalization.CultureInfo m_ciIdiomSecondary = null; 
			private bool m_bModificado = false;

			private System.Windows.Forms.GroupBox m_gbFrame;
			internal System.Windows.Forms.Button m_btOk;
			internal System.Windows.Forms.Button m_btCancelar;
			internal System.Windows.Forms.Button m_btTrocarCor;
			public System.Windows.Forms.Button m_btEditar;
			private System.Windows.Forms.ToolTip m_ttData;
			private mdlComponentesGraficos.DateTimePicker m_dtDate;
			private System.Windows.Forms.GroupBox m_gbDate;
			private mdlComponentesGraficos.TextBox m_txtDate;
			private System.Windows.Forms.PictureBox m_picIdiom;
			private System.Windows.Forms.PictureBox m_picIdiomSecundary;
			private System.ComponentModel.IContainer components;
		#endregion
		#region Properties
			public System.Drawing.Image ImageIdiom
			{
				set
				{
					if (value == null)
					{
						m_picIdiom.Visible = false;
					}else{
						m_picIdiom.Image = value;
						m_picIdiom.Visible = true;
					}
				}
			}

			public System.Drawing.Image ImageIdiomSecondary
			{
				set
				{
					if (value == null)
					{
						m_picIdiomSecundary.Visible = false;
					}
					else
					{
						m_picIdiomSecundary.Image = value;
						m_picIdiomSecundary.Visible = true;
					}
				}
			}


			public bool EnableSecondIdiom
			{
				set
				{
					m_picIdiomSecundary.Visible = value; 
					m_txtDate.Visible = value; 
					if (value)
						this.Height = 160;
					else
						this.Height = 128;
				}
			}
		#endregion

		#region Construtors and Destructors
			public frmFData(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, string enderecoExecutavel)
			{
				InitializeComponent();
				m_cls_ter_tratadorErro = tratadorErro;
				m_strEnderecoExecutavel = enderecoExecutavel;
			}
			public frmFData(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, string enderecoExecutavel, bool bEdicaoHabilitada)
			{
				InitializeComponent();

				m_cls_ter_tratadorErro = tratadorErro;
				m_strEnderecoExecutavel = enderecoExecutavel;
				this.m_btEditar.Enabled = bEdicaoHabilitada;
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmFData));
			this.m_gbFrame = new System.Windows.Forms.GroupBox();
			this.m_btOk = new System.Windows.Forms.Button();
			this.m_btCancelar = new System.Windows.Forms.Button();
			this.m_btTrocarCor = new System.Windows.Forms.Button();
			this.m_gbDate = new System.Windows.Forms.GroupBox();
			this.m_picIdiom = new System.Windows.Forms.PictureBox();
			this.m_txtDate = new mdlComponentesGraficos.TextBox();
			this.m_dtDate = new mdlComponentesGraficos.DateTimePicker();
			this.m_btEditar = new System.Windows.Forms.Button();
			this.m_picIdiomSecundary = new System.Windows.Forms.PictureBox();
			this.m_ttData = new System.Windows.Forms.ToolTip(this.components);
			this.m_gbFrame.SuspendLayout();
			this.m_gbDate.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_gbFrame
			// 
			this.m_gbFrame.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_gbFrame.Controls.Add(this.m_btOk);
			this.m_gbFrame.Controls.Add(this.m_btCancelar);
			this.m_gbFrame.Controls.Add(this.m_btTrocarCor);
			this.m_gbFrame.Controls.Add(this.m_gbDate);
			this.m_gbFrame.Location = new System.Drawing.Point(2, 0);
			this.m_gbFrame.Name = "m_gbFrame";
			this.m_gbFrame.Size = new System.Drawing.Size(246, 126);
			this.m_gbFrame.TabIndex = 0;
			this.m_gbFrame.TabStop = false;
			// 
			// m_btOk
			// 
			this.m_btOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.m_btOk.BackColor = System.Drawing.SystemColors.Control;
			this.m_btOk.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btOk.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btOk.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btOk.Image = ((System.Drawing.Image)(resources.GetObject("m_btOk.Image")));
			this.m_btOk.Location = new System.Drawing.Point(63, 94);
			this.m_btOk.Name = "m_btOk";
			this.m_btOk.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btOk.Size = new System.Drawing.Size(57, 27);
			this.m_btOk.TabIndex = 3;
			this.m_ttData.SetToolTip(this.m_btOk, "Confirmar");
			this.m_btOk.Click += new System.EventHandler(this.m_btOk_Click);
			// 
			// m_btCancelar
			// 
			this.m_btCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.m_btCancelar.BackColor = System.Drawing.SystemColors.Control;
			this.m_btCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btCancelar.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btCancelar.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btCancelar.Image = ((System.Drawing.Image)(resources.GetObject("m_btCancelar.Image")));
			this.m_btCancelar.Location = new System.Drawing.Point(127, 94);
			this.m_btCancelar.Name = "m_btCancelar";
			this.m_btCancelar.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btCancelar.Size = new System.Drawing.Size(57, 27);
			this.m_btCancelar.TabIndex = 4;
			this.m_ttData.SetToolTip(this.m_btCancelar, "Cancelar");
			this.m_btCancelar.Click += new System.EventHandler(this.m_btCancelar_Click);
			// 
			// m_btTrocarCor
			// 
			this.m_btTrocarCor.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(64)), ((System.Byte)(0)));
			this.m_btTrocarCor.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btTrocarCor.Location = new System.Drawing.Point(4, 9);
			this.m_btTrocarCor.Name = "m_btTrocarCor";
			this.m_btTrocarCor.Size = new System.Drawing.Size(4, 4);
			this.m_btTrocarCor.TabIndex = 5;
			this.m_ttData.SetToolTip(this.m_btTrocarCor, "Cor");
			this.m_btTrocarCor.Click += new System.EventHandler(this.m_btTrocarCor_Click);
			// 
			// m_gbDate
			// 
			this.m_gbDate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left)));
			this.m_gbDate.Controls.Add(this.m_picIdiom);
			this.m_gbDate.Controls.Add(this.m_txtDate);
			this.m_gbDate.Controls.Add(this.m_dtDate);
			this.m_gbDate.Controls.Add(this.m_btEditar);
			this.m_gbDate.Controls.Add(this.m_picIdiomSecundary);
			this.m_gbDate.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_gbDate.Location = new System.Drawing.Point(8, 8);
			this.m_gbDate.Name = "m_gbDate";
			this.m_gbDate.Size = new System.Drawing.Size(230, 80);
			this.m_gbDate.TabIndex = 0;
			this.m_gbDate.TabStop = false;
			this.m_gbDate.Text = "Edição da Data";
			// 
			// m_picIdiom
			// 
			this.m_picIdiom.Location = new System.Drawing.Point(8, 21);
			this.m_picIdiom.Name = "m_picIdiom";
			this.m_picIdiom.Size = new System.Drawing.Size(25, 25);
			this.m_picIdiom.TabIndex = 8;
			this.m_picIdiom.TabStop = false;
			// 
			// m_txtDate
			// 
			this.m_txtDate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_txtDate.BackColor = System.Drawing.SystemColors.HighlightText;
			this.m_txtDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.m_txtDate.Enabled = false;
			this.m_txtDate.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_txtDate.Location = new System.Drawing.Point(43, 49);
			this.m_txtDate.Name = "m_txtDate";
			this.m_txtDate.Size = new System.Drawing.Size(145, 20);
			this.m_txtDate.TabIndex = 7;
			this.m_txtDate.Text = "";
			this.m_txtDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// m_dtDate
			// 
			this.m_dtDate.CustomFormat = "dd/MM/yyyy";
			this.m_dtDate.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_dtDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.m_dtDate.Location = new System.Drawing.Point(42, 20);
			this.m_dtDate.Name = "m_dtDate";
			this.m_dtDate.Size = new System.Drawing.Size(148, 20);
			this.m_dtDate.TabIndex = 1;
			this.m_dtDate.ValueChanged += new System.EventHandler(this.m_dtDate_ValueChanged);
			// 
			// m_btEditar
			// 
			this.m_btEditar.BackColor = System.Drawing.SystemColors.Control;
			this.m_btEditar.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btEditar.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btEditar.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btEditar.Image = ((System.Drawing.Image)(resources.GetObject("m_btEditar.Image")));
			this.m_btEditar.Location = new System.Drawing.Point(197, 16);
			this.m_btEditar.Name = "m_btEditar";
			this.m_btEditar.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btEditar.Size = new System.Drawing.Size(25, 26);
			this.m_btEditar.TabIndex = 2;
			this.m_btEditar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.m_ttData.SetToolTip(this.m_btEditar, "Editar formato");
			this.m_btEditar.Click += new System.EventHandler(this.m_btEditar_Click);
			// 
			// m_picIdiomSecundary
			// 
			this.m_picIdiomSecundary.Location = new System.Drawing.Point(8, 51);
			this.m_picIdiomSecundary.Name = "m_picIdiomSecundary";
			this.m_picIdiomSecundary.Size = new System.Drawing.Size(25, 25);
			this.m_picIdiomSecundary.TabIndex = 6;
			this.m_picIdiomSecundary.TabStop = false;
			// 
			// m_ttData
			// 
			this.m_ttData.AutomaticDelay = 100;
			this.m_ttData.AutoPopDelay = 5000;
			this.m_ttData.InitialDelay = 100;
			this.m_ttData.ReshowDelay = 20;
			// 
			// frmFData
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(250, 128);
			this.Controls.Add(this.m_gbFrame);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmFData";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Data";
			this.Click += new System.EventHandler(this.frmFData_Load);
			this.Load += new System.EventHandler(this.frmFData_Load);
			this.m_gbFrame.ResumeLayout(false);
			this.m_gbDate.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Eventos
			#region Formulario
				private void frmFData_Load(object sender, System.EventArgs e)
				{
					try
					{
						this.vMostraCor();
						OnCallLoadInterface();
					}
					catch (Exception err)
					{
						Object erro = err;
						m_cls_ter_tratadorErro.trataErro(ref erro);
					}
				}
			#endregion
			#region DataPicker
				private void m_dtDate_ValueChanged(object sender, System.EventArgs e)
				{
					vRefreshDataIdioma();
				}
			#endregion
			#region Botoes
				private void m_btTrocarCor_Click(object sender, System.EventArgs e)
				{
					try
					{
						vShowColor();
					}
					catch (Exception err)
					{
						Object erro = err;
						m_cls_ter_tratadorErro.trataErro(ref erro);
					}
				}

				private void m_btEditar_Click(object sender, System.EventArgs e)
				{
					try
					{
						if (OnCallShowFormat())
						{
							OnCallLoadInterface();
							vRefreshDataIdioma();
						}
					}
					catch (Exception err)
					{
						Object erro = err;
						m_cls_ter_tratadorErro.trataErro(ref erro);
					}
				}

				private void m_btOk_Click(object sender, System.EventArgs e)
				{
					try
					{
						this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
						if (m_bModificado = OnCallSaveInterface())
							this.Close();
						this.Cursor = System.Windows.Forms.Cursors.Default;
					}
					catch (Exception err)
					{
						Object erro = err;
						m_cls_ter_tratadorErro.trataErro(ref erro);
					}
				}

				private void m_btCancelar_Click(object sender, System.EventArgs e)
				{
					try
					{
						this.Close();
					}
					catch (Exception err)
					{
						Object erro = err;
						m_cls_ter_tratadorErro.trataErro(ref erro);
					}
				}
			#endregion
		#endregion

		#region Data Idioma
			private void vRefreshDataIdioma()
			{
				m_txtDate.Text = m_dtDate.Value.ToString(m_dtDate.CustomFormat,m_ciIdiomSecondary);
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

			private void vShowColor()
			{
				mdlPaletaDeCores.clsPaletaDeCores clsPaletaCores = new mdlPaletaDeCores.clsPaletaDeCores(m_strEnderecoExecutavel + "sisco.ini","SiscobrasCorSecundaria");
				clsPaletaCores.mostraCorAtual();
				vMostraCor();
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
