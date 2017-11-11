using System;
using System.Collections;
using System.Windows.Forms;

namespace mdlDocumentacao.Frames
{
	/// <summary>
	/// Summary description for frmFQuantidades.
	/// </summary>
	internal class frmFQuantidades : mdlComponentesGraficos.FormFlutuante
	{
		#region Atributos
		protected mdlTratamentoErro.clsTratamentoErro m_cls_ter_tratadorErro;
		protected string m_strEnderecoExecutavel;

		private bool m_bAtivado = true;
		private bool m_bModificado = false;
		private System.Windows.Forms.GroupBox m_gbFrame;
		private System.Windows.Forms.GroupBox m_gbFields;
		private mdlComponentesGraficos.DataGrid m_dgValores;
		private System.Windows.Forms.Button m_btOk;
		private System.Windows.Forms.Button m_btCancelar;
		private System.Windows.Forms.Button m_btTrocarCor;
		private System.Windows.Forms.ToolTip m_ttDocumentos;
		private System.ComponentModel.IContainer components;
		#endregion

		#region Construtores & Destrutores
		public frmFQuantidades(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, string EnderecoExecutavel)
		{
			InitializeComponent();

			m_cls_ter_tratadorErro = tratadorErro;
			m_strEnderecoExecutavel = EnderecoExecutavel;
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
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

		#region Delegate
		public delegate void delCallCarregaDadosTabela(ref mdlComponentesGraficos.DataGrid dgValores);
		public delegate void delCallDataGridEnterEvent(object sender, System.EventArgs e, ref mdlComponentesGraficos.DataGrid dtGridValores);
		public delegate void delCallDataGridLeaveEvent(object sender, System.EventArgs e, ref mdlComponentesGraficos.DataGrid dtGridValores);
		public delegate void delCallDataGridTextChangedEvent(object sender, System.EventArgs e, ref mdlComponentesGraficos.DataGrid dtGridValores);
		public delegate void delCallDataGridKeyDownEvent(object sender, System.Windows.Forms.KeyEventArgs e, ref mdlComponentesGraficos.DataGrid dtGridValores);
		public delegate void delCallDataGridKeyPressEvent(object sender, System.Windows.Forms.KeyPressEventArgs e, ref mdlComponentesGraficos.DataGrid dtGridValores);
		public delegate void delCallDataGridKeyUpEvent(object sender, System.Windows.Forms.KeyEventArgs e, ref mdlComponentesGraficos.DataGrid dtGridValores);
		public delegate void delCallDataGridCurrentCellChangedEvent(object sender, System.EventArgs e, ref mdlComponentesGraficos.DataGrid dtGridValores);
		public delegate void delCallSalvaDadosBD(bool bModificado);
		#endregion
		#region Events
		public event delCallCarregaDadosTabela eCallCarregaDadosTabela;
		public event delCallDataGridEnterEvent eCallDataGridEnterEvent;
		public event delCallDataGridLeaveEvent eCallDataGridLeaveEvent;
		public event delCallDataGridTextChangedEvent eCallDataGridTextChangedEvent;
		public event delCallDataGridKeyDownEvent eCallDataGridKeyDownEvent;
		public event delCallDataGridKeyPressEvent eCallDataGridKeyPressEvent;
		public event delCallDataGridKeyUpEvent eCallDataGridKeyUpEvent;
		public event delCallDataGridCurrentCellChangedEvent eCallDataGridCurrentCellChangedEvent;
		public event delCallSalvaDadosBD eCallSalvaDadosBD;
		#endregion
		#region Events Methods
		protected virtual void OnCallCarregaDadosTabela()
		{
			if (eCallCarregaDadosTabela != null)
				eCallCarregaDadosTabela(ref m_dgValores);
		}
		protected virtual void OnCallDataGridEnterEvent(object sender, System.EventArgs e)
		{
			if (eCallDataGridEnterEvent != null)
				eCallDataGridEnterEvent(sender, e, ref this.m_dgValores);
		}
		protected virtual void OnCallDataGridLeaveEvent(object sender, System.EventArgs e)
		{
			if (eCallDataGridLeaveEvent != null)
				eCallDataGridLeaveEvent(sender, e, ref this.m_dgValores);
		}
		protected virtual void OnCallDataGridTextChangedEvent(object sender, System.EventArgs e)
		{
			if (eCallDataGridTextChangedEvent != null)
				eCallDataGridTextChangedEvent(sender, e, ref this.m_dgValores);
		}
		protected virtual void OnCallDataGridKeyDownEvent(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (eCallDataGridKeyDownEvent != null)
				eCallDataGridKeyDownEvent(sender, e, ref m_dgValores);
		}
		protected virtual void OnCallDataGridKeyPressEvent(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			if (eCallDataGridKeyPressEvent != null)
				eCallDataGridKeyPressEvent(sender, e, ref m_dgValores);
		}
		protected virtual void OnCallDataGridKeyUpEvent(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (eCallDataGridKeyUpEvent != null)
				eCallDataGridKeyUpEvent(sender, e, ref m_dgValores);
		}
		protected virtual void OnCallDataGridCurrentCellChangedEvent(object sender, System.EventArgs e)
		{
			if (eCallDataGridCurrentCellChangedEvent != null)
				eCallDataGridCurrentCellChangedEvent(sender, e, ref this.m_dgValores);
		}
		protected virtual void OnCallSalvaDadosBD()
		{
			if (eCallSalvaDadosBD != null)
				eCallSalvaDadosBD(m_bModificado);
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmFQuantidades));
			this.m_gbFrame = new System.Windows.Forms.GroupBox();
			this.m_btTrocarCor = new System.Windows.Forms.Button();
			this.m_btOk = new System.Windows.Forms.Button();
			this.m_btCancelar = new System.Windows.Forms.Button();
			this.m_gbFields = new System.Windows.Forms.GroupBox();
			this.m_dgValores = new mdlComponentesGraficos.DataGrid();
			this.m_ttDocumentos = new System.Windows.Forms.ToolTip(this.components);
			this.m_gbFrame.SuspendLayout();
			this.m_gbFields.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.m_dgValores)).BeginInit();
			this.SuspendLayout();
			// 
			// m_gbFrame
			// 
			this.m_gbFrame.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_gbFrame.Controls.Add(this.m_btTrocarCor);
			this.m_gbFrame.Controls.Add(this.m_btOk);
			this.m_gbFrame.Controls.Add(this.m_btCancelar);
			this.m_gbFrame.Controls.Add(this.m_gbFields);
			this.m_gbFrame.Location = new System.Drawing.Point(2, 0);
			this.m_gbFrame.Name = "m_gbFrame";
			this.m_gbFrame.Size = new System.Drawing.Size(690, 277);
			this.m_gbFrame.TabIndex = 0;
			this.m_gbFrame.TabStop = false;
			// 
			// m_btTrocarCor
			// 
			this.m_btTrocarCor.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(64)), ((System.Byte)(0)));
			this.m_btTrocarCor.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btTrocarCor.Location = new System.Drawing.Point(4, 10);
			this.m_btTrocarCor.Name = "m_btTrocarCor";
			this.m_btTrocarCor.Size = new System.Drawing.Size(4, 4);
			this.m_btTrocarCor.TabIndex = 5;
			this.m_ttDocumentos.SetToolTip(this.m_btTrocarCor, "Cor");
			this.m_btTrocarCor.Click += new System.EventHandler(this.m_btTrocarCor_Click);
			// 
			// m_btOk
			// 
			this.m_btOk.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.m_btOk.BackColor = System.Drawing.SystemColors.Control;
			this.m_btOk.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btOk.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btOk.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btOk.Image = ((System.Drawing.Image)(resources.GetObject("m_btOk.Image")));
			this.m_btOk.Location = new System.Drawing.Point(285, 246);
			this.m_btOk.Name = "m_btOk";
			this.m_btOk.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btOk.Size = new System.Drawing.Size(57, 25);
			this.m_btOk.TabIndex = 3;
			this.m_ttDocumentos.SetToolTip(this.m_btOk, "Confirmar");
			this.m_btOk.Click += new System.EventHandler(this.m_btOk_Click);
			// 
			// m_btCancelar
			// 
			this.m_btCancelar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.m_btCancelar.BackColor = System.Drawing.SystemColors.Control;
			this.m_btCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btCancelar.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btCancelar.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btCancelar.Image = ((System.Drawing.Image)(resources.GetObject("m_btCancelar.Image")));
			this.m_btCancelar.Location = new System.Drawing.Point(349, 246);
			this.m_btCancelar.Name = "m_btCancelar";
			this.m_btCancelar.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btCancelar.Size = new System.Drawing.Size(57, 25);
			this.m_btCancelar.TabIndex = 4;
			this.m_ttDocumentos.SetToolTip(this.m_btCancelar, "Cancelar");
			this.m_btCancelar.Click += new System.EventHandler(this.m_btCancelar_Click);
			// 
			// m_gbFields
			// 
			this.m_gbFields.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_gbFields.Controls.Add(this.m_dgValores);
			this.m_gbFields.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_gbFields.Location = new System.Drawing.Point(8, 8);
			this.m_gbFields.Name = "m_gbFields";
			this.m_gbFields.Size = new System.Drawing.Size(674, 233);
			this.m_gbFields.TabIndex = 0;
			this.m_gbFields.TabStop = false;
			this.m_gbFields.Text = "Identificar e quantificar";
			// 
			// m_dgValores
			// 
			this.m_dgValores.AcceptsEnter = false;
			this.m_dgValores.AcceptsTab = false;
			this.m_dgValores.AllowSorting = false;
			this.m_dgValores.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_dgValores.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
			this.m_dgValores.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.m_dgValores.CaptionBackColor = System.Drawing.SystemColors.Control;
			this.m_dgValores.CaptionFont = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_dgValores.CaptionForeColor = System.Drawing.SystemColors.ControlText;
			this.m_dgValores.CaptionText = "Valores";
			this.m_dgValores.CaptionVisible = false;
			this.m_dgValores.DataMember = "";
			this.m_dgValores.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_dgValores.HeaderBackColor = System.Drawing.SystemColors.ControlText;
			this.m_dgValores.HeaderForeColor = System.Drawing.SystemColors.ControlLightLight;
			this.m_dgValores.Location = new System.Drawing.Point(8, 19);
			this.m_dgValores.Name = "m_dgValores";
			this.m_dgValores.PreferredColumnWidth = 50;
			this.m_dgValores.RowHeadersVisible = false;
			this.m_dgValores.RowHeaderWidth = 0;
			this.m_dgValores.Size = new System.Drawing.Size(658, 202);
			this.m_dgValores.SortedColumnAscendent = false;
			this.m_dgValores.TabIndex = 0;
			this.m_ttDocumentos.SetToolTip(this.m_dgValores, "Identificar e Quantificar");
			this.m_dgValores.KeyUp += new System.Windows.Forms.KeyEventHandler(this.m_dgValores_KeyUp);
			this.m_dgValores.CurrentCellChanged += new System.EventHandler(this.m_dgValores_CurrentCellChanged);
			// 
			// m_ttDocumentos
			// 
			this.m_ttDocumentos.AutomaticDelay = 100;
			this.m_ttDocumentos.AutoPopDelay = 5000;
			this.m_ttDocumentos.InitialDelay = 100;
			this.m_ttDocumentos.ReshowDelay = 20;
			// 
			// frmFQuantidades
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(694, 279);
			this.Controls.Add(this.m_gbFrame);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmFQuantidades";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Documentos";
			this.Load += new System.EventHandler(this.frmFQuantidades_Load);
			this.m_gbFrame.ResumeLayout(false);
			this.m_gbFields.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.m_dgValores)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		#region Procedimentos Para Troca de Cor
		/// <summary>
		/// Troca a cor do Formulario Controlado
		/// </summary>
		private void trocaCor()
		{
			try
			{
				mdlPaletaDeCores.clsPaletaDeCores controlPaletaCores = new mdlPaletaDeCores.clsPaletaDeCores(m_strEnderecoExecutavel + "sisco.ini", "SiscobrasCorSecundaria");
				controlPaletaCores.mostraCorAtual();
				mostraCor();
			} 
			catch (Exception erro) 
			{
				Object err = (Object)erro;
				m_cls_ter_tratadorErro.trataErro(ref err);
			}
		}
		/// <summary>
		/// Mostra a cor do Formulario Controlado
		/// </summary>
		public void mostraCor()
		{
			try
			{
				mdlPaletaDeCores.clsPaletaDeCores controlPaletaDeCores = new mdlPaletaDeCores.clsPaletaDeCores(m_strEnderecoExecutavel + "sisco.ini", "SiscobrasCorSecundaria");
				this.BackColor = controlPaletaDeCores.retornaCorAtual();
				for (int cont = 0; cont < this.Controls.Count; cont++) 
				{
					this.Controls[cont].BackColor = this.BackColor;
					for (int cont2 = 0; cont2 < this.Controls[cont].Controls.Count; cont2++)
					{
						if ((this.Controls[cont].Controls[cont2].GetType().ToString() != "System.Windows.Forms.ListView") && (this.Controls[cont].Controls[cont2].GetType().ToString() != "mdlComponentes.compTextNumber"))
						{
							this.Controls[cont].Controls[cont2].BackColor = this.BackColor;
						}
						for (int cont3 = 0; cont3 < this.Controls[cont].Controls[cont2].Controls.Count; cont3++)
						{
							if ((this.Controls[cont].Controls[cont2].Controls[cont3].GetType().ToString() != 
								"mdlComponentesGraficos.DataGrid") ||
								((this.Controls[cont].Controls[cont2].Controls[cont3].Name == "m_lvDadosImportadores") &&
								(this.Controls[cont].Controls[cont2].Controls[cont3].GetType().ToString() == 
								"mdlComponentesGraficos.ListView")))
							{
								this.Controls[cont].Controls[cont2].Controls[cont3].BackColor = this.BackColor;
							}
						}
					}
				}
			} 
			catch (Exception erro) 
			{ 
				Object err = (Object)erro;
				m_cls_ter_tratadorErro.trataErro(ref err);
			}
		}

		#endregion

		#region Eventos
		#region Load
		private void frmFQuantidades_Load(object sender, System.EventArgs e)
		{
			this.mostraCor();
			OnCallCarregaDadosTabela();
			if (m_dgValores.VisibleRowCount > 1)
				m_dgValores.CurrentCell = new DataGridCell(0,2);
		}
		#endregion
		#region Data Grid Events
		internal void m_dgValores_Enter(object sender, System.EventArgs e)
		{
			OnCallDataGridEnterEvent(sender, e);
		}
		internal void m_dgValores_Leave(object sender, System.EventArgs e)
		{
			//OnCallDataGridLeaveEvent(sender, e);
		}
		internal void m_dgValores_TextChanged(object sender, System.EventArgs e)
		{
			//OnCallDataGridTextChangedEvent(sender, e);
		}
		internal void m_dgValores_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			OnCallDataGridKeyDownEvent(sender, e);
		}
		internal void m_dgValores_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			OnCallDataGridKeyPressEvent(sender, e);
		}
		internal void m_dgValores_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			OnCallDataGridKeyUpEvent(sender, e);
		}
		private void m_dgValores_CurrentCellChanged(object sender, System.EventArgs e)
		{
			if (m_bAtivado)
			{
				m_bAtivado = false;
				OnCallDataGridCurrentCellChangedEvent(sender, e);
				m_bAtivado = true;
			}
		}
		#endregion
		#region Ok
		private void m_btOk_Click(object sender, System.EventArgs e)
		{
			this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
			m_bModificado = true;
			OnCallSalvaDadosBD();
			this.Cursor = System.Windows.Forms.Cursors.Default;
			this.Close();
		}
		#endregion
		#region Cancelar
		private void m_btCancelar_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}
		#endregion
		#region Cor
		private void m_btTrocarCor_Click(object sender, System.EventArgs e)
		{
			this.trocaCor();
		}
		#endregion
		#endregion
	}
}
