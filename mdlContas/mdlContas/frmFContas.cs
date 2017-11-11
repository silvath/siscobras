using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace mdlContas
{
	/// <summary>
	/// Summary description for frmFContas.
	/// </summary>
	internal class frmFContas : mdlComponentesGraficos.FormFixo
	{
		#region Atributos
		private mdlTratamentoErro.clsTratamentoErro m_cls_ter_tratadorErro = null;
		private string m_strEnderecoExecutavel = "";

		private bool m_bModificado = true;

		private System.Windows.Forms.ToolTip m_ttContas;
		private System.Windows.Forms.ImageList m_ilContas;
		private System.Windows.Forms.Timer m_tmContas;
		private System.Windows.Forms.GroupBox m_gbFrame;
		internal System.Windows.Forms.Button m_btTrocarCor;
		private System.Windows.Forms.Button m_btExcluir;
		private System.Windows.Forms.Button m_btEditar;
		private System.Windows.Forms.Button m_btNovo;
		private mdlComponentesGraficos.ListView m_lvContas;
		private mdlComponentesGraficos.AnimatedPictureBox m_pbBanner;
		private System.ComponentModel.IContainer components;
		#endregion

		#region Construtors and Destrutors
		public frmFContas(ref mdlTratamentoErro.clsTratamentoErro clstratadorErro, string strEnderecoExecutavel)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			m_cls_ter_tratadorErro = clstratadorErro;
			m_strEnderecoExecutavel = strEnderecoExecutavel;

			vInitializeBanners();
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			try
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
			catch
			{
			}
		}
		#endregion

		#region Delegate
		// Delegate para BD
		public delegate void delCallCarregaDadosBD();
		public delegate void delCallCarregaDadosBDContas(ref mdlComponentesGraficos.ListView lvContas);
		public delegate void delCallCarregaDadosInterface(ref mdlComponentesGraficos.ListView lvContas, ref System.Windows.Forms.Button btEditar, ref System.Windows.Forms.Button btExcluir, ref System.Windows.Forms.Button btNovo);
		public delegate void delCallChecaIntegridadeDados();
		public delegate void delCallSalvaDadosInterface(ref mdlComponentesGraficos.ListView lvContas);
		public delegate void delCallSalvaDadosBD(bool bModificado);
		// Delegate para Editar Contas
		public delegate void delCallEditaConta();
		public delegate void delCallCadastraConta();
		public delegate void delCallRemoveConta(ref mdlComponentesGraficos.ListView lvContas);
		public delegate void delCallDuploClique();
		// Delegate para o Banner
		public delegate void delCallAlteraBanner(ref System.Windows.Forms.PictureBox pbBanner);
		public delegate void delCallClickBanner();
		#endregion
		#region Events
		// Eventos BD
		public event delCallCarregaDadosBD eCallCarregaDadosBD;
		public event delCallCarregaDadosBDContas eCallCarregaDadosBDContas;
		public event delCallCarregaDadosInterface eCallCarregaDadosInterface;
		public event delCallChecaIntegridadeDados eCallChecaIntegridadeDados;
		public event delCallSalvaDadosInterface eCallSalvaDadosInterface;
		public event delCallSalvaDadosBD eCallSalvaDadosBD;
		// Eventos Editar / Cadastrar Importadores
		public event delCallEditaConta eCallEditaConta;
		public event delCallCadastraConta eCallCadastraConta;
		public event delCallRemoveConta eCallRemoveConta;
		public event delCallDuploClique eCallDuploClique;
		// Eventos Alterar Banner
		public event delCallAlteraBanner eCallAlteraBanner;
		public event delCallClickBanner eCallClickBanner;
		#endregion
		#region Events Methods
		protected virtual void OnCallCarregaDadosBD()
		{
			if (eCallCarregaDadosBD != null)
				eCallCarregaDadosBD();
		}
		protected virtual void OnCallCarregaDadosBDContas()
		{
			if (eCallCarregaDadosBDContas != null)
				eCallCarregaDadosBDContas(ref this.m_lvContas);
		} 
		protected virtual void OnCallCarregaDadosInterface()
		{
			if (eCallCarregaDadosInterface != null)
				eCallCarregaDadosInterface(ref this.m_lvContas, ref this.m_btEditar, ref this.m_btExcluir, ref m_btNovo);
		}
		protected virtual void OnCallChecaIntegridadeDados()
		{
			if (eCallChecaIntegridadeDados != null)
				eCallChecaIntegridadeDados();
		}
		protected virtual void OnCallSalvaDadosInterface()
		{
			if (eCallSalvaDadosInterface != null)
				eCallSalvaDadosInterface(ref this.m_lvContas);
		} 

		protected virtual void OnCallSalvaDadosBD()
		{
			if (eCallSalvaDadosBD != null)
				eCallSalvaDadosBD(this.m_bModificado);
		}
		protected virtual void OnCallCadastraConta()
		{
			if (eCallCadastraConta != null)
				eCallCadastraConta();
		}
		protected virtual void OnCallEditaConta()
		{
			if (eCallEditaConta != null)
				eCallEditaConta();
		}
		protected virtual void OnCallRemoveConta()
		{
			if (eCallRemoveConta != null)
				eCallRemoveConta(ref this.m_lvContas);
		}
		protected virtual void OnCallDuploClique()
		{
			if (eCallDuploClique != null)
				eCallDuploClique();
		}
		protected virtual void OnCallAlteraBanner()
		{
//			if (eCallAlteraBanner != null)
//				eCallAlteraBanner(ref this.m_pbBanner);
		}
		protected virtual void OnCallClickBanner()
		{
			if (eCallClickBanner != null)
				eCallClickBanner();
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmFContas));
			this.m_ilContas = new System.Windows.Forms.ImageList(this.components);
			this.m_ttContas = new System.Windows.Forms.ToolTip(this.components);
			this.m_btTrocarCor = new System.Windows.Forms.Button();
			this.m_btExcluir = new System.Windows.Forms.Button();
			this.m_btEditar = new System.Windows.Forms.Button();
			this.m_btNovo = new System.Windows.Forms.Button();
			this.m_tmContas = new System.Windows.Forms.Timer(this.components);
			this.m_gbFrame = new System.Windows.Forms.GroupBox();
			this.m_lvContas = new mdlComponentesGraficos.ListView();
			this.m_pbBanner = new mdlComponentesGraficos.AnimatedPictureBox();
			this.m_gbFrame.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_ilContas
			// 
			this.m_ilContas.ImageSize = new System.Drawing.Size(34, 32);
			this.m_ilContas.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("m_ilContas.ImageStream")));
			this.m_ilContas.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// m_ttContas
			// 
			this.m_ttContas.AutomaticDelay = 100;
			this.m_ttContas.AutoPopDelay = 5000;
			this.m_ttContas.InitialDelay = 100;
			this.m_ttContas.ReshowDelay = 20;
			// 
			// m_btTrocarCor
			// 
			this.m_btTrocarCor.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(64)), ((System.Byte)(0)));
			this.m_btTrocarCor.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btTrocarCor.Location = new System.Drawing.Point(3, 12);
			this.m_btTrocarCor.Name = "m_btTrocarCor";
			this.m_btTrocarCor.Size = new System.Drawing.Size(4, 4);
			this.m_btTrocarCor.TabIndex = 18;
			this.m_ttContas.SetToolTip(this.m_btTrocarCor, "Cor");
			this.m_btTrocarCor.Click += new System.EventHandler(this.m_btTrocarCor_Click);
			// 
			// m_btExcluir
			// 
			this.m_btExcluir.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.m_btExcluir.BackColor = System.Drawing.SystemColors.Control;
			this.m_btExcluir.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btExcluir.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btExcluir.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btExcluir.Image = ((System.Drawing.Image)(resources.GetObject("m_btExcluir.Image")));
			this.m_btExcluir.Location = new System.Drawing.Point(494, 16);
			this.m_btExcluir.Name = "m_btExcluir";
			this.m_btExcluir.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btExcluir.Size = new System.Drawing.Size(25, 25);
			this.m_btExcluir.TabIndex = 17;
			this.m_btExcluir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.m_ttContas.SetToolTip(this.m_btExcluir, "Excluir");
			this.m_btExcluir.Click += new System.EventHandler(this.m_btExcluir_Click);
			// 
			// m_btEditar
			// 
			this.m_btEditar.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.m_btEditar.BackColor = System.Drawing.SystemColors.Control;
			this.m_btEditar.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btEditar.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btEditar.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btEditar.Image = ((System.Drawing.Image)(resources.GetObject("m_btEditar.Image")));
			this.m_btEditar.Location = new System.Drawing.Point(462, 16);
			this.m_btEditar.Name = "m_btEditar";
			this.m_btEditar.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btEditar.Size = new System.Drawing.Size(25, 25);
			this.m_btEditar.TabIndex = 16;
			this.m_btEditar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.m_ttContas.SetToolTip(this.m_btEditar, "Editar");
			this.m_btEditar.Click += new System.EventHandler(this.m_btEditar_Click);
			// 
			// m_btNovo
			// 
			this.m_btNovo.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.m_btNovo.BackColor = System.Drawing.SystemColors.Control;
			this.m_btNovo.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btNovo.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btNovo.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btNovo.Image = ((System.Drawing.Image)(resources.GetObject("m_btNovo.Image")));
			this.m_btNovo.Location = new System.Drawing.Point(430, 16);
			this.m_btNovo.Name = "m_btNovo";
			this.m_btNovo.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btNovo.Size = new System.Drawing.Size(25, 25);
			this.m_btNovo.TabIndex = 15;
			this.m_btNovo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.m_ttContas.SetToolTip(this.m_btNovo, "Novo");
			this.m_btNovo.Click += new System.EventHandler(this.m_btNovo_Click);
			// 
			// m_tmContas
			// 
			this.m_tmContas.Enabled = true;
			this.m_tmContas.Interval = 4000;
			this.m_tmContas.Tick += new System.EventHandler(this.m_tmContas_Tick);
			// 
			// m_gbFrame
			// 
			this.m_gbFrame.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_gbFrame.Controls.Add(this.m_btTrocarCor);
			this.m_gbFrame.Controls.Add(this.m_btExcluir);
			this.m_gbFrame.Controls.Add(this.m_btEditar);
			this.m_gbFrame.Controls.Add(this.m_btNovo);
			this.m_gbFrame.Controls.Add(this.m_lvContas);
			this.m_gbFrame.Controls.Add(this.m_pbBanner);
			this.m_gbFrame.Font = new System.Drawing.Font("Arial", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_gbFrame.Location = new System.Drawing.Point(73, -1);
			this.m_gbFrame.Name = "m_gbFrame";
			this.m_gbFrame.Size = new System.Drawing.Size(949, 567);
			this.m_gbFrame.TabIndex = 0;
			this.m_gbFrame.TabStop = false;
			this.m_gbFrame.Text = "Exportadores";
			// 
			// m_lvContas
			// 
			this.m_lvContas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_lvContas.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.m_lvContas.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lvContas.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
			this.m_lvContas.HideSelection = false;
			this.m_lvContas.LargeImageList = this.m_ilContas;
			this.m_lvContas.Location = new System.Drawing.Point(8, 54);
			this.m_lvContas.Name = "m_lvContas";
			this.m_lvContas.Size = new System.Drawing.Size(933, 431);
			this.m_lvContas.TabIndex = 14;
			this.m_lvContas.ItemActivate += new System.EventHandler(this.m_lvContas_ItemActivate);
			this.m_lvContas.Click += new System.EventHandler(this.m_lvContas_Click);
			this.m_lvContas.KeyUp += new System.Windows.Forms.KeyEventHandler(this.m_lvContas_KeyUp);
			// 
			// m_pbBanner
			// 
			this.m_pbBanner.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.m_pbBanner.AnimationLoops = 1;
			this.m_pbBanner.Image = ((System.Drawing.Image)(resources.GetObject("m_pbBanner.Image")));
			this.m_pbBanner.Location = new System.Drawing.Point(191, 492);
			this.m_pbBanner.Name = "m_pbBanner";
			this.m_pbBanner.Size = new System.Drawing.Size(567, 66);
			this.m_pbBanner.TabIndex = 19;
			this.m_pbBanner.TabStop = false;
			this.m_pbBanner.Click += new System.EventHandler(this.m_pbBanner_Click);
			this.m_pbBanner.MouseEnter += new System.EventHandler(this.m_pbBanner_MouseEnter);
			this.m_pbBanner.MouseLeave += new System.EventHandler(this.m_pbBanner_MouseLeave);
			// 
			// frmFContas
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(1024, 568);
			this.Controls.Add(this.m_gbFrame);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmFContas";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Contas";
			this.Closing += new System.ComponentModel.CancelEventHandler(this.frmFContas_Closing);
			this.Load += new System.EventHandler(this.frmFContas_Load);
			this.m_gbFrame.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Procedimentos Para Troca de Cor
		#region Trocar Cor
		/// <summary>
		/// Troca a cor do Formulario Controlado
		/// </summary>
		public void trocaCor()
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
		#endregion
		#region Mostrar Cor
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
					if ((this.Controls[cont].GetType().ToString() != 
						"mdlComponentesGraficos.ListView") &&
						(this.Controls[cont].GetType().ToString() != 
						"mdlComponentes.compTextBox") &&
						(this.Controls[cont].GetType().ToString() != 
						"mdlComponentesGraficos.TextBox"))
					{
						this.Controls[cont].BackColor = this.BackColor;
					}
					for (int cont2 = 0; cont2 < this.Controls[cont].Controls.Count; cont2++)
					{
						if ((this.Controls[cont].Controls[cont2].GetType().ToString() != 
							"mdlComponentesGraficos.ListView") &&
							(this.Controls[cont].Controls[cont2].GetType().ToString() != 
							"mdlComponentes.compTextBox") &&
							(this.Controls[cont].Controls[cont2].GetType().ToString() != 
							"mdlComponentesGraficos.TextBox"))
						{
							this.Controls[cont].Controls[cont2].BackColor = this.BackColor;
						}
						for (int cont3 = 0; cont3 < this.Controls[cont].Controls[cont2].Controls.Count; cont3++)
						{
							if ((this.Controls[cont].Controls[cont2].Controls[cont3].GetType().ToString() != 
								"mdlComponentesGraficos.ListView") &&
								(this.Controls[cont].Controls[cont2].Controls[cont3].GetType().ToString() != 
								"mdlComponentes.compTextBox") &&
								(this.Controls[cont].Controls[cont2].Controls[cont3].GetType().ToString() != 
								"mdlComponentesGraficos.TextBox"))
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
		#endregion

		#region Refresh
		public void refreshAll()
		{
			try
			{
				OnCallCarregaDadosInterface();
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion

		#region Get & Set
		public void setToolTipBanner(string strToolTip)
		{
			try
			{
				m_ttContas.SetToolTip(m_pbBanner, strToolTip);
			}
			catch (Exception err)
			{
				m_cls_ter_tratadorErro.trataErro(ref err);
			}
		}
		#endregion

		#region Eventos
		#region Key Up
		private void m_lvContas_KeyUp(object sender, KeyEventArgs e)
		{
			try
			{
				if (e.KeyData == System.Windows.Forms.Keys.Delete)
				{
					m_btExcluir_Click(sender, new System.EventArgs());
				}
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#region Load
		private void frmFContas_Load(object sender, System.EventArgs e)
		{
			try
			{
				//resizing();
				this.mostraCor();
				this.m_tmContas.Enabled = true;
				this.m_tmContas.Start();
				OnCallAlteraBanner();
				OnCallCarregaDadosInterface();
				this.SetBounds(this.MdiParent.Bounds.X,this.MdiParent.Bounds.Y,this.MdiParent.Bounds.Width - 13,this.MdiParent.Bounds.Height - 40);
				//resizing();
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#region Cor
		private void m_btTrocarCor_Click(object sender, System.EventArgs e)
		{
			try
			{
				this.trocaCor();
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#region Tick
		private void m_tmContas_Tick(object sender, System.EventArgs e)
		{
			try
			{
				m_tmContas.Enabled = false;
				if (m_pbBanner.SetAnimationLoopsFromImage())
				{
					m_pbBanner.AnimationLoops = 1;
					m_pbBanner.Start();
				}
				//OnCallAlteraBanner();
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#region Excluir
		private void m_btExcluir_Click(object sender, System.EventArgs e)
		{
			try
			{
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				if (this.m_lvContas.SelectedItems.Count > 0)
				{
					OnCallRemoveConta();
					OnCallCarregaDadosInterface();
				}
				this.Cursor = System.Windows.Forms.Cursors.Default;
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#region Novo
		private void m_btNovo_Click(object sender, System.EventArgs e)
		{
			try
			{
				OnCallCadastraConta();
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
			try
			{
				if (this.m_lvContas.SelectedItems.Count > 0)
				{
					this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
					OnCallEditaConta();
					this.Cursor = System.Windows.Forms.Cursors.Default;
				}
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#region Closing
		private void frmFContas_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			try
			{
//				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
//				OnCallSalvaDadosInterface();
//				OnCallSalvaDadosBD();
//				this.Cursor = System.Windows.Forms.Cursors.Default;
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#region List View Click
		private void m_lvContas_Click(object sender, System.EventArgs e)
		{
			try
			{
				if (m_lvContas.SelectedItems.Count > 0)
                    OnCallCarregaDadosBDContas();
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#region Banner Mouse Enter
		private void m_pbBanner_MouseEnter(object sender, System.EventArgs e)
		{
			try
			{
				this.Cursor = System.Windows.Forms.Cursors.Hand;
				if ((m_tmContas != null) && (m_tmContas.Enabled))
					this.m_tmContas.Stop();
				//this.m_tmContas.Enabled = false;
			}
			catch
			{
			}
		}
		#endregion
		#region Banner Mouse Leave
		private void m_pbBanner_MouseLeave(object sender, System.EventArgs e)
		{
			try
			{
				this.Cursor = System.Windows.Forms.Cursors.Default;
				if (m_tmContas != null)
					this.m_tmContas.Start();
				//this.m_tmContas.Enabled = true;
			}
			catch
			{
			}
		}
		#endregion
		#region Double Click
		private void m_lvContas_ItemActivate(object sender, System.EventArgs e)
		{
			try
			{
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				if (m_lvContas.SelectedItems.Count > 0)
                    OnCallDuploClique();
				this.Cursor = System.Windows.Forms.Cursors.Default;
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#region Banner Click
		private void m_pbBanner_Click(object sender, System.EventArgs e)
		{
			this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
			OnCallClickBanner();
			this.Cursor = System.Windows.Forms.Cursors.Default;
		}
		#endregion
		#endregion

		#region Banners
			private void vInitializeBanners()
			{
				mdlManipuladorArquivo.clsManipuladorArquivoIni objIni = new mdlManipuladorArquivo.clsManipuladorArquivoIni(m_strEnderecoExecutavel + mdlConstantes.clsConstantes.DEFAULT_CONFIG_FILENAME);
				if (!objIni.retornaValor("Siscobras","Banners",true))
				{
					m_tmContas.Enabled = false;
					m_pbBanner.Visible = false;
					m_lvContas.Height = (m_gbFrame.Height - m_lvContas.Top) - 10;
				}
			}
		#endregion
	}
}