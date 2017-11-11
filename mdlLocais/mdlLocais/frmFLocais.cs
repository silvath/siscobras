using System;
using System.Collections;
using System.Windows.Forms;

namespace mdlLocais
{
	/// <summary>
	/// Summary description for frmFLocais.
	/// </summary>
	internal class frmFLocais : mdlComponentesGraficos.FormFlutuante
	{
		#region Delegates
			public delegate void delCallCarregaDadosBD();
			public delegate void delCallCarregaDadosInterface(ref mdlComponentesGraficos.TextBox tbLocalColeta, ref mdlComponentesGraficos.TextBox tbLocalDespacho, ref mdlComponentesGraficos.TextBox tbLocalDestino, ref mdlComponentesGraficos.TextBox tbLocalEmbarque, ref mdlComponentesGraficos.TextBox tbLocalEntrega, ref System.Windows.Forms.Button btIncoterm, ref System.Windows.Forms.GroupBox gbPaisOrigem, ref System.Windows.Forms.GroupBox gbPaisDestino, ref System.Windows.Forms.Label lLocalColeta, ref System.Windows.Forms.Label lLocalDespacho, ref System.Windows.Forms.Label lLocalDestino, ref System.Windows.Forms.Label lLocalEmbarque, ref System.Windows.Forms.Label lLocalEntrega);
			public delegate void delCallSalvaDadosInterface(ref mdlComponentesGraficos.TextBox tbLocalColeta, ref mdlComponentesGraficos.TextBox tbLocalDespacho, ref mdlComponentesGraficos.TextBox tbLocalDestino, ref mdlComponentesGraficos.TextBox tbLocalEmbarque, ref mdlComponentesGraficos.TextBox tbLocalEntrega);
			public delegate void delCallSalvaDadosBD(bool bModificado);
			// Local Embarque, Local Despacho
			public delegate void delCallLocalEmbarqueTextChanged(ref mdlComponentesGraficos.TextBox tbLocalEmbarque, ref mdlComponentesGraficos.TextBox tbLocalDespacho);
			public delegate void delCallLocalDespachoTextChanged(ref mdlComponentesGraficos.TextBox tbLocalDespacho, ref mdlComponentesGraficos.TextBox tbLocalEmbarque);
			// Incoterm
			public delegate void delCallAlteraIncoterm();
		#endregion
		#region Events
			public event delCallCarregaDadosBD eCallCarregaDadosBD;
			public event delCallCarregaDadosInterface eCallCarregaDadosInterface;
			public event delCallSalvaDadosInterface eCallSalvaDadosInterface;
			public event delCallSalvaDadosBD eCallSalvaDadosBD;
			// Local Embarque, Local Despacho
			public event delCallLocalEmbarqueTextChanged eCallLocalEmbarqueTextChanged;
			public event delCallLocalDespachoTextChanged eCallLocalDespachoTextChanged;
			// Incoterm
			public event delCallAlteraIncoterm eCallAlteraIncoterm;
			#endregion
		#region Events Methods
			protected virtual void OnCallCarregaDadosBD()
			{
				if (eCallCarregaDadosBD != null)
					eCallCarregaDadosBD();
			}
			protected virtual void OnCallCarregaDadosInterface()
			{
				if (eCallCarregaDadosInterface != null)
					eCallCarregaDadosInterface(ref m_txtLocalColeta, ref m_txtLocalDespacho, ref m_txtLocalDestino, ref m_txtLocalEmbarque, ref m_txtLocalEntrega, ref m_btIncoterm, ref m_gbBrasil, ref m_gbPaisDestino, ref m_lbLocalColeta, ref m_lbLocalDespacho, ref m_lbLocalDestino, ref m_lbLocalEmbarque, ref m_lbLocalEntrega);
			}
			protected virtual void OnCallSalvaDadosInterface()
			{
				if (eCallSalvaDadosInterface != null)
					eCallSalvaDadosInterface(ref m_txtLocalColeta, ref m_txtLocalDespacho, ref m_txtLocalDestino, ref m_txtLocalEmbarque, ref m_txtLocalEntrega);
			}

			protected virtual void OnCallSalvaDadosBD()
			{
				if (eCallSalvaDadosBD != null)
					eCallSalvaDadosBD(m_bModificado);
			}

			protected virtual void OnCallLocalEmbarqueTextChanged()
			{
				if (eCallLocalEmbarqueTextChanged != null)
					eCallLocalEmbarqueTextChanged(ref m_txtLocalEmbarque, ref m_txtLocalDespacho);
			}

			protected virtual void OnCallLocalDespachoTextChanged()
			{
				if (eCallLocalDespachoTextChanged != null)
					eCallLocalDespachoTextChanged(ref m_txtLocalDespacho, ref m_txtLocalEmbarque);
			}
			protected virtual void OnCallAlteraIncoterm()
			{
				if (eCallAlteraIncoterm != null)
					eCallAlteraIncoterm();
			}
		#endregion

		#region Atributos
		private mdlTratamentoErro.clsTratamentoErro m_cls_ter_tratadorErro = null;
		private string m_strEnderecoExecutavel = "";

		private bool m_bHabilitaBotaoIncoterm = true;

		private bool m_bModificado = false;

		internal System.Windows.Forms.GroupBox m_gbGeral;
		private System.Windows.Forms.Button m_btIncoterm;
		private System.Windows.Forms.Button m_btOk;
		private System.Windows.Forms.Button m_btCancelar;
		internal System.Windows.Forms.GroupBox m_gbPaisDestino;
		private mdlComponentesGraficos.TextBox m_txtLocalEntrega;
		internal System.Windows.Forms.Label m_lbLocalEntrega;
		private mdlComponentesGraficos.TextBox m_txtLocalDestino;
		internal System.Windows.Forms.Label m_lbLocalDestino;
		internal System.Windows.Forms.GroupBox m_gbBrasil;
		private mdlComponentesGraficos.TextBox m_txtLocalEmbarque;
		internal System.Windows.Forms.Label m_lbLocalEmbarque;
		private mdlComponentesGraficos.TextBox m_txtLocalDespacho;
		internal System.Windows.Forms.Label m_lbLocalDespacho;
		internal System.Windows.Forms.Label m_lbLocalColeta;
		private mdlComponentesGraficos.TextBox m_txtLocalColeta;
		private System.Windows.Forms.Button btTrocarCor;
		private System.Windows.Forms.ToolTip m_ttLocais;
		private System.ComponentModel.IContainer components;
		#endregion
		#region Constructor and Destructors
		public frmFLocais(ref mdlTratamentoErro.clsTratamentoErro clstratadorErro, string strEnderecoExecutavel)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			m_cls_ter_tratadorErro = clstratadorErro;
			m_strEnderecoExecutavel = strEnderecoExecutavel;
		}
		public frmFLocais(ref mdlTratamentoErro.clsTratamentoErro clstratadorErro, string strEnderecoExecutavel, bool bHabilitaIncoterm)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			m_cls_ter_tratadorErro = clstratadorErro;
			m_strEnderecoExecutavel = strEnderecoExecutavel;
			m_bHabilitaBotaoIncoterm = bHabilitaIncoterm;
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmFLocais));
			this.m_gbGeral = new System.Windows.Forms.GroupBox();
			this.btTrocarCor = new System.Windows.Forms.Button();
			this.m_btIncoterm = new System.Windows.Forms.Button();
			this.m_btOk = new System.Windows.Forms.Button();
			this.m_btCancelar = new System.Windows.Forms.Button();
			this.m_gbBrasil = new System.Windows.Forms.GroupBox();
			this.m_txtLocalEmbarque = new mdlComponentesGraficos.TextBox();
			this.m_lbLocalEmbarque = new System.Windows.Forms.Label();
			this.m_txtLocalDespacho = new mdlComponentesGraficos.TextBox();
			this.m_lbLocalDespacho = new System.Windows.Forms.Label();
			this.m_txtLocalColeta = new mdlComponentesGraficos.TextBox();
			this.m_lbLocalColeta = new System.Windows.Forms.Label();
			this.m_gbPaisDestino = new System.Windows.Forms.GroupBox();
			this.m_txtLocalEntrega = new mdlComponentesGraficos.TextBox();
			this.m_lbLocalEntrega = new System.Windows.Forms.Label();
			this.m_txtLocalDestino = new mdlComponentesGraficos.TextBox();
			this.m_lbLocalDestino = new System.Windows.Forms.Label();
			this.m_ttLocais = new System.Windows.Forms.ToolTip(this.components);
			this.m_gbGeral.SuspendLayout();
			this.m_gbBrasil.SuspendLayout();
			this.m_gbPaisDestino.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_gbGeral
			// 
			this.m_gbGeral.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_gbGeral.Controls.Add(this.btTrocarCor);
			this.m_gbGeral.Controls.Add(this.m_btIncoterm);
			this.m_gbGeral.Controls.Add(this.m_btOk);
			this.m_gbGeral.Controls.Add(this.m_btCancelar);
			this.m_gbGeral.Controls.Add(this.m_gbBrasil);
			this.m_gbGeral.Controls.Add(this.m_gbPaisDestino);
			this.m_gbGeral.Location = new System.Drawing.Point(2, 0);
			this.m_gbGeral.Name = "m_gbGeral";
			this.m_gbGeral.Size = new System.Drawing.Size(246, 279);
			this.m_gbGeral.TabIndex = 0;
			this.m_gbGeral.TabStop = false;
			// 
			// btTrocarCor
			// 
			this.btTrocarCor.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(64)), ((System.Byte)(0)));
			this.btTrocarCor.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btTrocarCor.Location = new System.Drawing.Point(4, 9);
			this.btTrocarCor.Name = "btTrocarCor";
			this.btTrocarCor.Size = new System.Drawing.Size(4, 4);
			this.btTrocarCor.TabIndex = 3;
			this.m_ttLocais.SetToolTip(this.btTrocarCor, "Cor");
			this.btTrocarCor.Click += new System.EventHandler(this.m_btTrocarCor_Click);
			// 
			// m_btIncoterm
			// 
			this.m_btIncoterm.BackColor = System.Drawing.SystemColors.Control;
			this.m_btIncoterm.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btIncoterm.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btIncoterm.ForeColor = System.Drawing.Color.Black;
			this.m_btIncoterm.Location = new System.Drawing.Point(103, 116);
			this.m_btIncoterm.Name = "m_btIncoterm";
			this.m_btIncoterm.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btIncoterm.Size = new System.Drawing.Size(41, 24);
			this.m_btIncoterm.TabIndex = 4;
			this.m_btIncoterm.Text = "EXW";
			this.m_ttLocais.SetToolTip(this.m_btIncoterm, "Alterar Incoterm");
			this.m_btIncoterm.Click += new System.EventHandler(this.m_btIncoterm_Click);
			// 
			// m_btOk
			// 
			this.m_btOk.BackColor = System.Drawing.SystemColors.Control;
			this.m_btOk.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btOk.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btOk.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btOk.Image = ((System.Drawing.Image)(resources.GetObject("m_btOk.Image")));
			this.m_btOk.Location = new System.Drawing.Point(63, 247);
			this.m_btOk.Name = "m_btOk";
			this.m_btOk.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btOk.Size = new System.Drawing.Size(57, 25);
			this.m_btOk.TabIndex = 1;
			this.m_ttLocais.SetToolTip(this.m_btOk, "Confirmar");
			this.m_btOk.Click += new System.EventHandler(this.m_btOk_Click);
			// 
			// m_btCancelar
			// 
			this.m_btCancelar.BackColor = System.Drawing.SystemColors.Control;
			this.m_btCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btCancelar.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btCancelar.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btCancelar.Image = ((System.Drawing.Image)(resources.GetObject("m_btCancelar.Image")));
			this.m_btCancelar.Location = new System.Drawing.Point(127, 247);
			this.m_btCancelar.Name = "m_btCancelar";
			this.m_btCancelar.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btCancelar.Size = new System.Drawing.Size(57, 25);
			this.m_btCancelar.TabIndex = 2;
			this.m_ttLocais.SetToolTip(this.m_btCancelar, "Cancelar");
			this.m_btCancelar.Click += new System.EventHandler(this.m_btCancelar_Click);
			// 
			// m_gbBrasil
			// 
			this.m_gbBrasil.Controls.Add(this.m_txtLocalEmbarque);
			this.m_gbBrasil.Controls.Add(this.m_lbLocalEmbarque);
			this.m_gbBrasil.Controls.Add(this.m_txtLocalDespacho);
			this.m_gbBrasil.Controls.Add(this.m_lbLocalDespacho);
			this.m_gbBrasil.Controls.Add(this.m_txtLocalColeta);
			this.m_gbBrasil.Controls.Add(this.m_lbLocalColeta);
			this.m_gbBrasil.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_gbBrasil.Location = new System.Drawing.Point(8, 8);
			this.m_gbBrasil.Name = "m_gbBrasil";
			this.m_gbBrasil.Size = new System.Drawing.Size(229, 102);
			this.m_gbBrasil.TabIndex = 0;
			this.m_gbBrasil.TabStop = false;
			this.m_gbBrasil.Text = "Brasil";
			this.m_ttLocais.SetToolTip(this.m_gbBrasil, "País de origem");
			// 
			// m_txtLocalEmbarque
			// 
			this.m_txtLocalEmbarque.Font = new System.Drawing.Font("Arial", 8F);
			this.m_txtLocalEmbarque.Location = new System.Drawing.Point(75, 71);
			this.m_txtLocalEmbarque.Name = "m_txtLocalEmbarque";
			this.m_txtLocalEmbarque.Size = new System.Drawing.Size(146, 20);
			this.m_txtLocalEmbarque.TabIndex = 3;
			this.m_txtLocalEmbarque.Text = "";
			this.m_ttLocais.SetToolTip(this.m_txtLocalEmbarque, "Embarque");
			this.m_txtLocalEmbarque.TextChanged += new System.EventHandler(this.m_txtLocalEmbarque_TextChanged);
			// 
			// m_lbLocalEmbarque
			// 
			this.m_lbLocalEmbarque.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lbLocalEmbarque.Location = new System.Drawing.Point(7, 71);
			this.m_lbLocalEmbarque.Name = "m_lbLocalEmbarque";
			this.m_lbLocalEmbarque.Size = new System.Drawing.Size(60, 16);
			this.m_lbLocalEmbarque.TabIndex = 0;
			this.m_lbLocalEmbarque.Text = "Embarque:";
			// 
			// m_txtLocalDespacho
			// 
			this.m_txtLocalDespacho.Font = new System.Drawing.Font("Arial", 8F);
			this.m_txtLocalDespacho.Location = new System.Drawing.Point(75, 47);
			this.m_txtLocalDespacho.Name = "m_txtLocalDespacho";
			this.m_txtLocalDespacho.Size = new System.Drawing.Size(146, 20);
			this.m_txtLocalDespacho.TabIndex = 2;
			this.m_txtLocalDespacho.Text = "";
			this.m_ttLocais.SetToolTip(this.m_txtLocalDespacho, "Despacho");
			this.m_txtLocalDespacho.TextChanged += new System.EventHandler(this.m_txtLocalDespacho_TextChanged);
			// 
			// m_lbLocalDespacho
			// 
			this.m_lbLocalDespacho.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lbLocalDespacho.Location = new System.Drawing.Point(7, 47);
			this.m_lbLocalDespacho.Name = "m_lbLocalDespacho";
			this.m_lbLocalDespacho.Size = new System.Drawing.Size(58, 16);
			this.m_lbLocalDespacho.TabIndex = 0;
			this.m_lbLocalDespacho.Text = "Despacho:";
			// 
			// m_txtLocalColeta
			// 
			this.m_txtLocalColeta.Font = new System.Drawing.Font("Arial", 8F);
			this.m_txtLocalColeta.Location = new System.Drawing.Point(75, 22);
			this.m_txtLocalColeta.Name = "m_txtLocalColeta";
			this.m_txtLocalColeta.Size = new System.Drawing.Size(146, 20);
			this.m_txtLocalColeta.TabIndex = 1;
			this.m_txtLocalColeta.Text = "";
			this.m_ttLocais.SetToolTip(this.m_txtLocalColeta, "Coleta");
			// 
			// m_lbLocalColeta
			// 
			this.m_lbLocalColeta.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lbLocalColeta.Location = new System.Drawing.Point(7, 23);
			this.m_lbLocalColeta.Name = "m_lbLocalColeta";
			this.m_lbLocalColeta.Size = new System.Drawing.Size(40, 16);
			this.m_lbLocalColeta.TabIndex = 0;
			this.m_lbLocalColeta.Text = "Coleta:";
			// 
			// m_gbPaisDestino
			// 
			this.m_gbPaisDestino.Controls.Add(this.m_txtLocalEntrega);
			this.m_gbPaisDestino.Controls.Add(this.m_lbLocalEntrega);
			this.m_gbPaisDestino.Controls.Add(this.m_txtLocalDestino);
			this.m_gbPaisDestino.Controls.Add(this.m_lbLocalDestino);
			this.m_gbPaisDestino.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_gbPaisDestino.Location = new System.Drawing.Point(8, 140);
			this.m_gbPaisDestino.Name = "m_gbPaisDestino";
			this.m_gbPaisDestino.Size = new System.Drawing.Size(229, 102);
			this.m_gbPaisDestino.TabIndex = 0;
			this.m_gbPaisDestino.TabStop = false;
			this.m_gbPaisDestino.Text = "Argentina";
			this.m_ttLocais.SetToolTip(this.m_gbPaisDestino, "País de destino");
			// 
			// m_txtLocalEntrega
			// 
			this.m_txtLocalEntrega.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_txtLocalEntrega.Location = new System.Drawing.Point(75, 59);
			this.m_txtLocalEntrega.Name = "m_txtLocalEntrega";
			this.m_txtLocalEntrega.Size = new System.Drawing.Size(146, 20);
			this.m_txtLocalEntrega.TabIndex = 2;
			this.m_txtLocalEntrega.Text = "";
			this.m_ttLocais.SetToolTip(this.m_txtLocalEntrega, "Entrega");
			// 
			// m_lbLocalEntrega
			// 
			this.m_lbLocalEntrega.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lbLocalEntrega.Location = new System.Drawing.Point(7, 61);
			this.m_lbLocalEntrega.Name = "m_lbLocalEntrega";
			this.m_lbLocalEntrega.Size = new System.Drawing.Size(47, 16);
			this.m_lbLocalEntrega.TabIndex = 0;
			this.m_lbLocalEntrega.Text = "Entrega:";
			// 
			// m_txtLocalDestino
			// 
			this.m_txtLocalDestino.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_txtLocalDestino.Location = new System.Drawing.Point(75, 35);
			this.m_txtLocalDestino.Name = "m_txtLocalDestino";
			this.m_txtLocalDestino.Size = new System.Drawing.Size(146, 20);
			this.m_txtLocalDestino.TabIndex = 1;
			this.m_txtLocalDestino.Text = "";
			this.m_ttLocais.SetToolTip(this.m_txtLocalDestino, "Destino");
			// 
			// m_lbLocalDestino
			// 
			this.m_lbLocalDestino.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lbLocalDestino.Location = new System.Drawing.Point(7, 37);
			this.m_lbLocalDestino.Name = "m_lbLocalDestino";
			this.m_lbLocalDestino.Size = new System.Drawing.Size(46, 16);
			this.m_lbLocalDestino.TabIndex = 0;
			this.m_lbLocalDestino.Text = "Destino:";
			// 
			// m_ttLocais
			// 
			this.m_ttLocais.AutomaticDelay = 100;
			this.m_ttLocais.AutoPopDelay = 5000;
			this.m_ttLocais.InitialDelay = 100;
			this.m_ttLocais.ReshowDelay = 20;
			// 
			// frmFLocais
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(250, 281);
			this.Controls.Add(this.m_gbGeral);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmFLocais";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Locais";
			this.Load += new System.EventHandler(this.frmFLocais_Load);
			this.Activated += new System.EventHandler(this.frmFLocais_Activated);
			this.m_gbGeral.ResumeLayout(false);
			this.m_gbBrasil.ResumeLayout(false);
			this.m_gbPaisDestino.ResumeLayout(false);
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
					this.Controls[cont].BackColor = this.BackColor;
					for (int cont2 = 0; cont2 < this.Controls[cont].Controls.Count; cont2++)
					{
						if ((this.Controls[cont].Controls[cont2].GetType().ToString() != "mdlComponentes.compTextBox") && (this.Controls[cont].Controls[cont2].GetType().ToString() != "mdlComponentes.compTextNumber"))
						{
							this.Controls[cont].Controls[cont2].BackColor = this.BackColor;
						}
						for (int cont3 = 0; cont3 < this.Controls[cont].Controls[cont2].Controls.Count; cont3++)
						{
							if ((this.Controls[cont].Controls[cont2].Controls[cont3].GetType().ToString() != 
								"mdlComponentesGraficos.ListView") &&
								(this.Controls[cont].Controls[cont2].Controls[cont3].GetType().ToString() != 
								"mdlComponentesGraficos.ComboBox") &&
								(this.Controls[cont].Controls[cont2].Controls[cont3].GetType().ToString() != 
								"mdlComponentesGraficos.TextBox"))
							{
								this.Controls[cont].Controls[cont2].Controls[cont3].BackColor = this.BackColor;
							}
						}
					}
				}
				//m_btIncoterm.BackColor = System.Drawing.Color.Green;
			} 
			catch (Exception erro) 
			{ 
				Object err = (Object)erro;
				m_cls_ter_tratadorErro.trataErro(ref err);
			}
		}
		#endregion
		#endregion

		#region Eventos
		#region Cor
		private void m_btTrocarCor_Click(object sender, System.EventArgs e)
		{
			try
			{
				this.trocaCor();
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				this.mostraCor();
				this.Cursor = System.Windows.Forms.Cursors.Default;
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#region Load
		private void frmFLocais_Load(object sender, System.EventArgs e)
		{
			try
			{
				m_btIncoterm.Enabled = m_bHabilitaBotaoIncoterm;
				if (m_btIncoterm.Enabled == false)
					m_btIncoterm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
				this.mostraCor();
				OnCallCarregaDadosInterface();
			}
			catch (Exception err)
			{
				Object erro = err;
			}
		}
		#endregion
		#region Incoterm Click
		private void m_btIncoterm_Click(object sender, System.EventArgs e)
		{
			try
			{
				OnCallSalvaDadosInterface();
				OnCallAlteraIncoterm();
				OnCallCarregaDadosInterface();
				this.mostraCor();
			}
			catch (Exception err)
			{
				Object erro = err;
			}
		}
		#endregion
		#region Ok
		private void m_btOk_Click(object sender, System.EventArgs e)
		{
			try
			{
				m_bModificado = true;
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				OnCallSalvaDadosInterface();
				OnCallSalvaDadosBD();
				this.Close();
				this.Cursor = System.Windows.Forms.Cursors.Default;
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
			try
			{
				this.Close();
			}
			catch (Exception err)
			{
				Object erro = err;
			}
		}
		#endregion
		#region TextChanged
		private void m_txtLocalDespacho_TextChanged(object sender, System.EventArgs e)
		{
			try
			{
				// Sílvio pediu para comentar a linha abaixo, em 18/09 às 10:54
				// Sílvio pediu pra copiar o valor da Despacho pra entrega porém liberar edição, em 13/10 às 08:30
				OnCallLocalDespachoTextChanged();
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		private void m_txtLocalEmbarque_TextChanged(object sender, System.EventArgs e)
		{
			try
			{
				// Sílvio pediu para comentar a linha abaixo, em 11/09 às 13:46
				//OnCallLocalEmbarqueTextChanged();
			}
			catch (Exception err)
			{
				Object erro = err;
				m_cls_ter_tratadorErro.trataErro(ref erro);
			}
		}
		#endregion
		#region Frame Activated
		private void frmFLocais_Activated(object sender, System.EventArgs e)
		{
			m_txtLocalColeta.Focus();
		}
		#endregion
		#endregion
	}
}
