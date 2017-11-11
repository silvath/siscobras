using System;
using System.Collections;
using System.Windows.Forms;

namespace mdlAgentes.Frames
{
	/// <summary>
	/// Summary description for frmFListaAgentes.
	/// </summary>
	internal class frmFListaAgentes : mdlComponentesGraficos.FormFlutuante
	{
		#region Atributos
		protected mdlTratamentoErro.clsTratamentoErro m_cls_ter_tratadorErro;
		protected string m_strEnderecoExecutavel;

		public bool m_bModificado = false;
		protected bool m_bAtiva = true;

		private System.Windows.Forms.GroupBox m_gbFrame;
		private System.Windows.Forms.GroupBox m_gbFields;
		private mdlComponentesGraficos.ListView m_lvAgentes;
		private System.Windows.Forms.Button m_btContatos;
		private System.Windows.Forms.Button m_btExcluir;
		private System.Windows.Forms.Button m_btEditar;
		private System.Windows.Forms.Button m_btNovo;
		private System.Windows.Forms.Button m_btOk;
		private System.Windows.Forms.Button m_btCancelar;
		private System.Windows.Forms.Button m_btTrocarCor;
		private System.Windows.Forms.ColumnHeader m_chFirst;
		private System.Windows.Forms.ToolTip m_ttAgentes;
		private System.Windows.Forms.ImageList m_ilBotaoExtra;
		private System.ComponentModel.IContainer components;
		#endregion

		#region Construtores & Destrutores
		public frmFListaAgentes(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, string EnderecoExecutavel)
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
		public delegate void delCallCarregaDadosInterface(ref mdlComponentesGraficos.ListView lvAgentes, ref System.Windows.Forms.Button btEditar, ref System.Windows.Forms.Button btExcluir, ref System.Windows.Forms.Button btContatos, out string strCaption);
		public delegate void delCallSalvaDadosInterface(ref mdlComponentesGraficos.ListView lvAgentes);
		public delegate void delCallSalvaDadosBD(bool bModificado);
		public delegate void delCallEditaAgente();
		public delegate void delCallCadastraAgente();
		public delegate void delCallExcluiAgente(ref mdlComponentesGraficos.ListView lvAgentes);
		public delegate void delCallListaContatos();
		#endregion
		#region Events
		public event delCallCarregaDadosInterface eCallCarregaDadosInterface;
		public event delCallSalvaDadosInterface eCallSalvaDadosInterface;
		public event delCallSalvaDadosBD eCallSalvaDadosBD;
		public event delCallEditaAgente eCallEditaAgente;
		public event delCallCadastraAgente eCallCadastraAgente;
		public event delCallExcluiAgente eCallExcluiAgente;
		public event delCallListaContatos eCallListaContatos;
		#endregion
		#region Events Methods
		protected virtual void OnCallCarregaDadosInterface(out string strCaption)
		{
			strCaption = "";
			if (eCallCarregaDadosInterface != null)
				eCallCarregaDadosInterface(ref m_lvAgentes, ref m_btEditar, ref m_btExcluir, ref m_btContatos, out strCaption);
		}
		protected virtual void OnCallSalvaDadosInterface()
		{
			if (eCallSalvaDadosInterface != null)
				eCallSalvaDadosInterface(ref m_lvAgentes);
		}
		protected virtual void OnCallSalvaDadosBD()
		{
			if (eCallSalvaDadosBD != null)
				eCallSalvaDadosBD(m_bModificado);
		}
		protected virtual void OnCallEditaAgente()
		{
			if (eCallEditaAgente != null)
				eCallEditaAgente();
		}
		protected virtual void OnCallCadastraAgente()
		{
			if (eCallCadastraAgente != null)
				eCallCadastraAgente();
		}
		protected virtual void OnCallExcluiAgente()
		{
			if (eCallExcluiAgente != null)
				eCallExcluiAgente(ref m_lvAgentes);
		}
		protected virtual void OnCallListaContatos()
		{
			if (eCallListaContatos != null)
				eCallListaContatos();
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmFListaAgentes));
			this.m_gbFrame = new System.Windows.Forms.GroupBox();
			this.m_btTrocarCor = new System.Windows.Forms.Button();
			this.m_btOk = new System.Windows.Forms.Button();
			this.m_btCancelar = new System.Windows.Forms.Button();
			this.m_gbFields = new System.Windows.Forms.GroupBox();
			this.m_btContatos = new System.Windows.Forms.Button();
			this.m_ilBotaoExtra = new System.Windows.Forms.ImageList(this.components);
			this.m_btExcluir = new System.Windows.Forms.Button();
			this.m_btEditar = new System.Windows.Forms.Button();
			this.m_btNovo = new System.Windows.Forms.Button();
			this.m_lvAgentes = new mdlComponentesGraficos.ListView();
			this.m_chFirst = new System.Windows.Forms.ColumnHeader();
			this.m_ttAgentes = new System.Windows.Forms.ToolTip(this.components);
			this.m_gbFrame.SuspendLayout();
			this.m_gbFields.SuspendLayout();
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
			this.m_gbFrame.Size = new System.Drawing.Size(278, 293);
			this.m_gbFrame.TabIndex = 0;
			this.m_gbFrame.TabStop = false;
			// 
			// m_btTrocarCor
			// 
			this.m_btTrocarCor.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.m_btTrocarCor.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(64)), ((System.Byte)(0)));
			this.m_btTrocarCor.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btTrocarCor.Location = new System.Drawing.Point(4, 10);
			this.m_btTrocarCor.Name = "m_btTrocarCor";
			this.m_btTrocarCor.Size = new System.Drawing.Size(4, 4);
			this.m_btTrocarCor.TabIndex = 3;
			this.m_ttAgentes.SetToolTip(this.m_btTrocarCor, "Cor");
			this.m_btTrocarCor.Click += new System.EventHandler(this.m_btTrocarCor_Click);
			// 
			// m_btOk
			// 
			this.m_btOk.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.m_btOk.BackColor = System.Drawing.SystemColors.Control;
			this.m_btOk.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btOk.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btOk.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btOk.Image = ((System.Drawing.Image)(resources.GetObject("m_btOk.Image")));
			this.m_btOk.Location = new System.Drawing.Point(79, 262);
			this.m_btOk.Name = "m_btOk";
			this.m_btOk.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btOk.Size = new System.Drawing.Size(57, 25);
			this.m_btOk.TabIndex = 1;
			this.m_ttAgentes.SetToolTip(this.m_btOk, "Confirmar");
			this.m_btOk.Click += new System.EventHandler(this.m_btOk_Click);
			// 
			// m_btCancelar
			// 
			this.m_btCancelar.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.m_btCancelar.BackColor = System.Drawing.SystemColors.Control;
			this.m_btCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btCancelar.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btCancelar.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btCancelar.Image = ((System.Drawing.Image)(resources.GetObject("m_btCancelar.Image")));
			this.m_btCancelar.Location = new System.Drawing.Point(143, 262);
			this.m_btCancelar.Name = "m_btCancelar";
			this.m_btCancelar.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btCancelar.Size = new System.Drawing.Size(57, 25);
			this.m_btCancelar.TabIndex = 2;
			this.m_ttAgentes.SetToolTip(this.m_btCancelar, "Cancelar");
			this.m_btCancelar.Click += new System.EventHandler(this.m_btCancelar_Click);
			// 
			// m_gbFields
			// 
			this.m_gbFields.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_gbFields.Controls.Add(this.m_btContatos);
			this.m_gbFields.Controls.Add(this.m_btExcluir);
			this.m_gbFields.Controls.Add(this.m_btEditar);
			this.m_gbFields.Controls.Add(this.m_btNovo);
			this.m_gbFields.Controls.Add(this.m_lvAgentes);
			this.m_gbFields.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_gbFields.Location = new System.Drawing.Point(8, 8);
			this.m_gbFields.Name = "m_gbFields";
			this.m_gbFields.Size = new System.Drawing.Size(262, 249);
			this.m_gbFields.TabIndex = 0;
			this.m_gbFields.TabStop = false;
			// 
			// m_btContatos
			// 
			this.m_btContatos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.m_btContatos.BackColor = System.Drawing.SystemColors.Control;
			this.m_btContatos.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btContatos.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btContatos.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btContatos.ImageIndex = 0;
			this.m_btContatos.ImageList = this.m_ilBotaoExtra;
			this.m_btContatos.Location = new System.Drawing.Point(228, 19);
			this.m_btContatos.Name = "m_btContatos";
			this.m_btContatos.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btContatos.Size = new System.Drawing.Size(25, 25);
			this.m_btContatos.TabIndex = 4;
			this.m_btContatos.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.m_ttAgentes.SetToolTip(this.m_btContatos, "Contatos");
			this.m_btContatos.Click += new System.EventHandler(this.m_btContatos_Click);
			// 
			// m_ilBotaoExtra
			// 
			this.m_ilBotaoExtra.ImageSize = new System.Drawing.Size(20, 20);
			this.m_ilBotaoExtra.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("m_ilBotaoExtra.ImageStream")));
			this.m_ilBotaoExtra.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// m_btExcluir
			// 
			this.m_btExcluir.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.m_btExcluir.BackColor = System.Drawing.SystemColors.Control;
			this.m_btExcluir.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btExcluir.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btExcluir.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btExcluir.Image = ((System.Drawing.Image)(resources.GetObject("m_btExcluir.Image")));
			this.m_btExcluir.Location = new System.Drawing.Point(151, 20);
			this.m_btExcluir.Name = "m_btExcluir";
			this.m_btExcluir.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btExcluir.Size = new System.Drawing.Size(25, 25);
			this.m_btExcluir.TabIndex = 3;
			this.m_btExcluir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.m_ttAgentes.SetToolTip(this.m_btExcluir, "Excluir");
			this.m_btExcluir.Click += new System.EventHandler(this.m_btExcluir_Click);
			// 
			// m_btEditar
			// 
			this.m_btEditar.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.m_btEditar.BackColor = System.Drawing.SystemColors.Control;
			this.m_btEditar.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btEditar.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btEditar.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btEditar.Image = ((System.Drawing.Image)(resources.GetObject("m_btEditar.Image")));
			this.m_btEditar.Location = new System.Drawing.Point(119, 20);
			this.m_btEditar.Name = "m_btEditar";
			this.m_btEditar.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btEditar.Size = new System.Drawing.Size(25, 25);
			this.m_btEditar.TabIndex = 2;
			this.m_btEditar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.m_ttAgentes.SetToolTip(this.m_btEditar, "Editar");
			this.m_btEditar.Click += new System.EventHandler(this.m_btEditar_Click);
			// 
			// m_btNovo
			// 
			this.m_btNovo.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.m_btNovo.BackColor = System.Drawing.SystemColors.Control;
			this.m_btNovo.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btNovo.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btNovo.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btNovo.Image = ((System.Drawing.Image)(resources.GetObject("m_btNovo.Image")));
			this.m_btNovo.Location = new System.Drawing.Point(87, 20);
			this.m_btNovo.Name = "m_btNovo";
			this.m_btNovo.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btNovo.Size = new System.Drawing.Size(25, 25);
			this.m_btNovo.TabIndex = 1;
			this.m_btNovo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.m_ttAgentes.SetToolTip(this.m_btNovo, "Novo");
			this.m_btNovo.Click += new System.EventHandler(this.m_btNovo_Click);
			// 
			// m_lvAgentes
			// 
			this.m_lvAgentes.Activation = System.Windows.Forms.ItemActivation.OneClick;
			this.m_lvAgentes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_lvAgentes.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																						  this.m_chFirst});
			this.m_lvAgentes.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lvAgentes.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
			this.m_lvAgentes.HideSelection = false;
			this.m_lvAgentes.Location = new System.Drawing.Point(8, 50);
			this.m_lvAgentes.Name = "m_lvAgentes";
			this.m_lvAgentes.Size = new System.Drawing.Size(245, 191);
			this.m_lvAgentes.TabIndex = 5;
			this.m_ttAgentes.SetToolTip(this.m_lvAgentes, "Selecione o agente");
			this.m_lvAgentes.View = System.Windows.Forms.View.Details;
			this.m_lvAgentes.DoubleClick += new System.EventHandler(this.m_lvAgentes_DoubleClick);
			this.m_lvAgentes.Click += new System.EventHandler(this.m_lvAgentes_Click);
			this.m_lvAgentes.SelectedIndexChanged += new System.EventHandler(this.m_lvAgentes_SelectedIndexChanged);
			this.m_lvAgentes.MouseUp += new System.Windows.Forms.MouseEventHandler(this.m_lvAgentes_MouseUp);
			// 
			// m_chFirst
			// 
			this.m_chFirst.Width = 200;
			// 
			// m_ttAgentes
			// 
			this.m_ttAgentes.AutomaticDelay = 100;
			this.m_ttAgentes.AutoPopDelay = 5000;
			this.m_ttAgentes.InitialDelay = 100;
			this.m_ttAgentes.ReshowDelay = 20;
			// 
			// frmFListaAgentes
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(282, 295);
			this.Controls.Add(this.m_gbFrame);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmFListaAgentes";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Transportador / Agente de Embarque";
			this.Load += new System.EventHandler(this.frmFListaAgentes_Load);
			this.m_gbFrame.ResumeLayout(false);
			this.m_gbFields.ResumeLayout(false);
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
								"mdlComponentesGraficos.ListView") ||
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
		private void frmFListaAgentes_Load(object sender, System.EventArgs e)
		{
			try
			{
				string strCaption;
				this.mostraCor();
				OnCallCarregaDadosInterface(out strCaption);
				m_chFirst.Width = m_lvAgentes.Width - 10;
				if (strCaption.Trim() != "")
					this.Text = strCaption;
			}
			catch (Exception err)
			{
				Object erro = err;
			}
		}
		#endregion
		#region Cancelar
		private void m_btCancelar_Click(object sender, System.EventArgs e)
		{
			m_bModificado = false;
			this.Close();
		}
		#endregion
		#region Cor
		private void m_btTrocarCor_Click(object sender, System.EventArgs e)
		{
			this.trocaCor();
		}
		#endregion
		#region Ok
		private void m_btOk_Click(object sender, System.EventArgs e)
		{
			try
			{
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				//if (m_lvAgentes.SelectedItems.Count > 0)
				//{
					m_bModificado = true;
					OnCallSalvaDadosInterface();
					OnCallSalvaDadosBD();
					this.Close();
				//}
				this.Cursor = System.Windows.Forms.Cursors.Default;
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#region Selected Index Changed
		private void m_lvAgentes_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			try
			{
				if (m_bAtiva)
				{
					m_bAtiva = false;
					OnCallSalvaDadosInterface();
					m_bAtiva = true;
				}
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#region Agentes
		private void m_lvAgentes_Click(object sender, System.EventArgs e)
		{
			try
			{
				if (m_bAtiva)
				{
					m_bAtiva = false;
					OnCallSalvaDadosInterface();
					m_bAtiva = true;
				}
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#region Double Click
		private void m_lvAgentes_DoubleClick(object sender, System.EventArgs e)
		{
			try
			{
				m_btEditar_Click(sender, e);
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#region Mouse UP
		private void m_lvAgentes_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			try
			{
				if (m_lvAgentes.GetItemAt(e.X, e.Y) != null)
				{
					if (m_bAtiva)
					{
						m_bAtiva = false;
						OnCallSalvaDadosInterface();
						m_bAtiva = true;
					}
				}
				else
				{
					if (m_bAtiva)
					{
						m_bAtiva = false;
						m_lvAgentes.SelectedItems.Clear();
						OnCallSalvaDadosInterface();
						m_bAtiva = true;
					}
				}
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#region Editar
		private void m_btEditar_Click(object sender, System.EventArgs e)
		{
			string strCaption;
			if (m_lvAgentes.SelectedItems.Count > 0)
			{
				OnCallEditaAgente();
				OnCallCarregaDadosInterface(out strCaption);
			}
		}
		#endregion
		#region Cadastrar
		private void m_btNovo_Click(object sender, System.EventArgs e)
		{
			string strCaption;
			OnCallCadastraAgente();
			OnCallCarregaDadosInterface(out strCaption);
		}
		#endregion
		#region Excluir
		private void m_btExcluir_Click(object sender, System.EventArgs e)
		{
			string strCaption;
			if (m_lvAgentes.SelectedItems.Count > 0)
			{
				OnCallExcluiAgente();
				OnCallCarregaDadosInterface(out strCaption);
			}
		}
		#endregion
		#region Editar
		private void m_btContatos_Click(object sender, System.EventArgs e)
		{
			string strCaption;
			if (m_lvAgentes.SelectedItems.Count > 0)
			{
				OnCallListaContatos();
				OnCallCarregaDadosInterface(out strCaption);
			}
		}
		#endregion
		#endregion
	}
}
