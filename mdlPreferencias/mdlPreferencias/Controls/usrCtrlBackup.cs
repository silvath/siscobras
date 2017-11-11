using System;
using System.Collections;
using System.Data;
using System.Windows.Forms;

namespace mdlPreferencias.Backup
{
	/// <summary>
	/// Summary description for usrCtrlBackup.
	/// </summary>
	internal class usrCtrlBackup : System.Windows.Forms.UserControl
	{
		#region Atributos
		private bool m_bOnLoad = true;
		private System.Windows.Forms.GroupBox m_gbDiretorio;
		private mdlComponentesGraficos.TextBox m_tbDiretorio;
		public System.Windows.Forms.Button m_btPasta;
		private System.Windows.Forms.GroupBox m_gbFrequencia;
		private System.Windows.Forms.RadioButton m_rbNunca;
		private System.Windows.Forms.RadioButton m_rbDiariamente;
		private System.Windows.Forms.RadioButton m_rbSemanalmente;
		private System.Windows.Forms.RadioButton m_rbMensalmente;
		private System.Windows.Forms.Label m_lManter;
		private mdlComponentesGraficos.TextBox m_tbManter;
		private System.Windows.Forms.Label m_lBackups;
		private System.Windows.Forms.CheckBox m_ckbxPerguntar;
		private System.Windows.Forms.FolderBrowserDialog m_flBrDlgPastas;
		private System.Windows.Forms.GroupBox m_gbListaArquivos;
		private mdlComponentesGraficos.ListView m_lvListaArquivos;
		private System.Windows.Forms.Button m_btRealizaBackup;
		private System.Windows.Forms.Button m_btRealizaRestore;
		private System.Windows.Forms.ToolTip m_ttBackup;
		private System.Windows.Forms.ImageList m_ilIcones;
		private System.Windows.Forms.SaveFileDialog m_svFlDlgSalvarBackup;
		private System.Windows.Forms.ColumnHeader m_chFirst;
		private System.Windows.Forms.ColumnHeader m_chSecond;
		private System.ComponentModel.IContainer components;
		#endregion

		#region Construtores & Destrutores
		public usrCtrlBackup()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			// TODO: Add any initialization after the InitializeComponent call

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
		public delegate void delCallCarregaDadosInterface(ref mdlComponentesGraficos.TextBox tbPastas, ref System.Windows.Forms.FolderBrowserDialog flBrDlgPastas, ref System.Windows.Forms.RadioButton rbNunca, ref System.Windows.Forms.RadioButton rbDiariamente, ref System.Windows.Forms.RadioButton rbSemanalmente, ref System.Windows.Forms.RadioButton rbMensalmente, ref mdlComponentesGraficos.TextBox tbNumeroBackups, ref System.Windows.Forms.CheckBox ckbxPerguntar, ref System.Windows.Forms.Label lManter, ref System.Windows.Forms.Label lPermitir, ref mdlComponentesGraficos.ListView lvBackups);
		public delegate void delCallTrocaDiretorioBackup(ref System.Windows.Forms.FolderBrowserDialog flBrDlgPastas, ref mdlComponentesGraficos.TextBox tbPastas, ref mdlComponentesGraficos.ListView lvBackups);
		public delegate void delCallHabilitaCamposBackup(FREQUENCIABACKUP enumFrequencia, ref System.Windows.Forms.Label lManter, ref mdlComponentesGraficos.TextBox tbQuantidade, ref System.Windows.Forms.Label lBackup, ref System.Windows.Forms.CheckBox ckbxPermitir);
		public delegate bool delCallCriaBackup(ref System.Windows.Forms.SaveFileDialog svFlDlgBackup);
		public delegate void delCallSalvaBackupCriado(ref mdlComponentesGraficos.ListView lvBackups, ref System.Windows.Forms.SaveFileDialog svFlDlgBackup, ref mdlComponentesGraficos.TextBox tbPastas);
		public delegate void delCallRestauraBackup(ref mdlComponentesGraficos.ListView lvBackup);
		public delegate void delCallSalvaDadosInterface(ref mdlComponentesGraficos.TextBox tbPastas, ref System.Windows.Forms.FolderBrowserDialog flBrDlgPastas, ref System.Windows.Forms.RadioButton rbNunca, ref System.Windows.Forms.RadioButton rbDiariamente, ref System.Windows.Forms.RadioButton rbSemanalmente, ref System.Windows.Forms.RadioButton rbMensalmente, ref mdlComponentesGraficos.TextBox tbNumeroBackups, ref System.Windows.Forms.CheckBox ckbxPerguntar);
		#endregion
		#region Events
		public event delCallCarregaDadosInterface eCallCarregaDadosInterface;
		public event delCallTrocaDiretorioBackup eCallTrocaDiretorioBackup;
		public event delCallHabilitaCamposBackup eCallHabilitaCamposBackup;
		public event delCallCriaBackup eCallCriaBackup;
		public event delCallSalvaBackupCriado eCallSalvaBackupCriado;
		public event delCallRestauraBackup eCallRestauraBackup;
		public event delCallSalvaDadosInterface eCallSalvaDadosInterface;
		#endregion
		#region Events Methods
		protected virtual void OnCallCarregaDadosInterface()
		{
			if (eCallCarregaDadosInterface != null)
				eCallCarregaDadosInterface(ref m_tbDiretorio, ref m_flBrDlgPastas, ref m_rbNunca, ref m_rbDiariamente, ref m_rbSemanalmente, ref m_rbMensalmente, ref m_tbManter, ref m_ckbxPerguntar, ref m_lManter, ref m_lBackups, ref m_lvListaArquivos);
		}
		protected virtual void OnCallTrocaDiretorioBackup()
		{
			if (eCallTrocaDiretorioBackup != null)
				eCallTrocaDiretorioBackup(ref m_flBrDlgPastas, ref m_tbDiretorio, ref m_lvListaArquivos);
		}
		protected virtual void OnCallHabilitaCamposBackup(FREQUENCIABACKUP enumFrequencia)
		{
			if (eCallHabilitaCamposBackup != null)
				eCallHabilitaCamposBackup(enumFrequencia, ref m_lManter, ref m_tbManter, ref m_lBackups, ref m_ckbxPerguntar);
		}
		protected virtual bool OnCallCriaBackup()
		{
			if (eCallCriaBackup != null)
				return eCallCriaBackup(ref m_svFlDlgSalvarBackup);
			return false;
		}
		protected virtual void OnCallSalvaBackupCriado()
		{
			if (eCallSalvaBackupCriado != null)
				eCallSalvaBackupCriado(ref m_lvListaArquivos, ref m_svFlDlgSalvarBackup, ref m_tbDiretorio);
		}
		protected virtual void OnCallRestauraBackup()
		{
			if (eCallRestauraBackup != null)
				eCallRestauraBackup(ref m_lvListaArquivos);
		}
		internal virtual void OnCallSalvaDadosInterface()
		{
			if (eCallSalvaDadosInterface != null)
				eCallSalvaDadosInterface(ref m_tbDiretorio, ref m_flBrDlgPastas, ref m_rbNunca, ref m_rbDiariamente, ref m_rbSemanalmente, ref m_rbMensalmente, ref m_tbManter, ref m_ckbxPerguntar);
		}
		#endregion

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(usrCtrlBackup));
			this.m_gbDiretorio = new System.Windows.Forms.GroupBox();
			this.m_btPasta = new System.Windows.Forms.Button();
			this.m_tbDiretorio = new mdlComponentesGraficos.TextBox();
			this.m_gbFrequencia = new System.Windows.Forms.GroupBox();
			this.m_ckbxPerguntar = new System.Windows.Forms.CheckBox();
			this.m_lBackups = new System.Windows.Forms.Label();
			this.m_tbManter = new mdlComponentesGraficos.TextBox();
			this.m_lManter = new System.Windows.Forms.Label();
			this.m_rbMensalmente = new System.Windows.Forms.RadioButton();
			this.m_rbSemanalmente = new System.Windows.Forms.RadioButton();
			this.m_rbDiariamente = new System.Windows.Forms.RadioButton();
			this.m_rbNunca = new System.Windows.Forms.RadioButton();
			this.m_flBrDlgPastas = new System.Windows.Forms.FolderBrowserDialog();
			this.m_gbListaArquivos = new System.Windows.Forms.GroupBox();
			this.m_btRealizaBackup = new System.Windows.Forms.Button();
			this.m_btRealizaRestore = new System.Windows.Forms.Button();
			this.m_lvListaArquivos = new mdlComponentesGraficos.ListView();
			this.m_chFirst = new System.Windows.Forms.ColumnHeader();
			this.m_chSecond = new System.Windows.Forms.ColumnHeader();
			this.m_ilIcones = new System.Windows.Forms.ImageList(this.components);
			this.m_ttBackup = new System.Windows.Forms.ToolTip(this.components);
			this.m_svFlDlgSalvarBackup = new System.Windows.Forms.SaveFileDialog();
			this.m_gbDiretorio.SuspendLayout();
			this.m_gbFrequencia.SuspendLayout();
			this.m_gbListaArquivos.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_gbDiretorio
			// 
			this.m_gbDiretorio.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_gbDiretorio.Controls.Add(this.m_btPasta);
			this.m_gbDiretorio.Controls.Add(this.m_tbDiretorio);
			this.m_gbDiretorio.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_gbDiretorio.Location = new System.Drawing.Point(7, 2);
			this.m_gbDiretorio.Name = "m_gbDiretorio";
			this.m_gbDiretorio.Size = new System.Drawing.Size(379, 47);
			this.m_gbDiretorio.TabIndex = 0;
			this.m_gbDiretorio.TabStop = false;
			this.m_gbDiretorio.Text = "Pasta para Becapes";
			// 
			// m_btPasta
			// 
			this.m_btPasta.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_btPasta.BackColor = System.Drawing.SystemColors.Control;
			this.m_btPasta.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btPasta.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btPasta.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btPasta.Image = ((System.Drawing.Image)(resources.GetObject("m_btPasta.Image")));
			this.m_btPasta.Location = new System.Drawing.Point(345, 13);
			this.m_btPasta.Name = "m_btPasta";
			this.m_btPasta.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btPasta.Size = new System.Drawing.Size(25, 25);
			this.m_btPasta.TabIndex = 16;
			this.m_btPasta.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.m_ttBackup.SetToolTip(this.m_btPasta, "Definir diretório de Becapes");
			this.m_btPasta.Click += new System.EventHandler(this.m_btPasta_Click);
			// 
			// m_tbDiretorio
			// 
			this.m_tbDiretorio.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_tbDiretorio.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_tbDiretorio.Location = new System.Drawing.Point(7, 17);
			this.m_tbDiretorio.Name = "m_tbDiretorio";
			this.m_tbDiretorio.Size = new System.Drawing.Size(329, 20);
			this.m_tbDiretorio.TabIndex = 0;
			this.m_tbDiretorio.Text = "C:\\";
			// 
			// m_gbFrequencia
			// 
			this.m_gbFrequencia.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_gbFrequencia.Controls.Add(this.m_ckbxPerguntar);
			this.m_gbFrequencia.Controls.Add(this.m_lBackups);
			this.m_gbFrequencia.Controls.Add(this.m_tbManter);
			this.m_gbFrequencia.Controls.Add(this.m_lManter);
			this.m_gbFrequencia.Controls.Add(this.m_rbMensalmente);
			this.m_gbFrequencia.Controls.Add(this.m_rbSemanalmente);
			this.m_gbFrequencia.Controls.Add(this.m_rbDiariamente);
			this.m_gbFrequencia.Controls.Add(this.m_rbNunca);
			this.m_gbFrequencia.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_gbFrequencia.Location = new System.Drawing.Point(7, 53);
			this.m_gbFrequencia.Name = "m_gbFrequencia";
			this.m_gbFrequencia.Size = new System.Drawing.Size(379, 105);
			this.m_gbFrequencia.TabIndex = 1;
			this.m_gbFrequencia.TabStop = false;
			this.m_gbFrequencia.Text = "Realizar Becapes Automáticos";
			// 
			// m_ckbxPerguntar
			// 
			this.m_ckbxPerguntar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_ckbxPerguntar.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_ckbxPerguntar.Location = new System.Drawing.Point(195, 62);
			this.m_ckbxPerguntar.Name = "m_ckbxPerguntar";
			this.m_ckbxPerguntar.Size = new System.Drawing.Size(176, 18);
			this.m_ckbxPerguntar.TabIndex = 7;
			this.m_ckbxPerguntar.Text = "Perguntar antes de realizar.";
			this.m_ckbxPerguntar.CheckedChanged += new System.EventHandler(this.m_ckbxPerguntar_CheckedChanged);
			// 
			// m_lBackups
			// 
			this.m_lBackups.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lBackups.Location = new System.Drawing.Point(315, 36);
			this.m_lBackups.Name = "m_lBackups";
			this.m_lBackups.Size = new System.Drawing.Size(49, 16);
			this.m_lBackups.TabIndex = 6;
			this.m_lBackups.Text = "becapes.";
			this.m_lBackups.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// m_tbManter
			// 
			this.m_tbManter.Location = new System.Drawing.Point(287, 32);
			this.m_tbManter.Name = "m_tbManter";
			this.m_tbManter.OnlyNumbers = true;
			this.m_tbManter.Size = new System.Drawing.Size(21, 21);
			this.m_tbManter.TabIndex = 5;
			this.m_tbManter.Text = "10";
			this.m_ttBackup.SetToolTip(this.m_tbManter, "Quantidade de becapes a serem mantidos pelo Siscobras");
			this.m_tbManter.TextChanged += new System.EventHandler(this.m_tbManter_TextChanged);
			// 
			// m_lManter
			// 
			this.m_lManter.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lManter.Location = new System.Drawing.Point(194, 36);
			this.m_lManter.Name = "m_lManter";
			this.m_lManter.Size = new System.Drawing.Size(91, 16);
			this.m_lManter.TabIndex = 4;
			this.m_lManter.Text = "Manter os últimos";
			this.m_lManter.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// m_rbMensalmente
			// 
			this.m_rbMensalmente.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_rbMensalmente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.m_rbMensalmente.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_rbMensalmente.Location = new System.Drawing.Point(10, 78);
			this.m_rbMensalmente.Name = "m_rbMensalmente";
			this.m_rbMensalmente.Size = new System.Drawing.Size(89, 16);
			this.m_rbMensalmente.TabIndex = 3;
			this.m_rbMensalmente.Tag = mdlPreferencias.FREQUENCIABACKUP.MENSALMENTE;
			this.m_rbMensalmente.Text = "Mensalmente";
			this.m_ttBackup.SetToolTip(this.m_rbMensalmente, "Selecionar opção de Becape automático");
			this.m_rbMensalmente.CheckedChanged += new System.EventHandler(this.m_rbMensalmente_CheckedChanged);
			// 
			// m_rbSemanalmente
			// 
			this.m_rbSemanalmente.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_rbSemanalmente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.m_rbSemanalmente.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_rbSemanalmente.Location = new System.Drawing.Point(10, 60);
			this.m_rbSemanalmente.Name = "m_rbSemanalmente";
			this.m_rbSemanalmente.Size = new System.Drawing.Size(97, 16);
			this.m_rbSemanalmente.TabIndex = 2;
			this.m_rbSemanalmente.Tag = mdlPreferencias.FREQUENCIABACKUP.SEMANALMENTE;
			this.m_rbSemanalmente.Text = "Semanalmente";
			this.m_ttBackup.SetToolTip(this.m_rbSemanalmente, "Selecionar opção de Becape automático");
			this.m_rbSemanalmente.CheckedChanged += new System.EventHandler(this.m_rbSemanalmente_CheckedChanged);
			// 
			// m_rbDiariamente
			// 
			this.m_rbDiariamente.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_rbDiariamente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.m_rbDiariamente.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_rbDiariamente.Location = new System.Drawing.Point(10, 42);
			this.m_rbDiariamente.Name = "m_rbDiariamente";
			this.m_rbDiariamente.Size = new System.Drawing.Size(82, 16);
			this.m_rbDiariamente.TabIndex = 1;
			this.m_rbDiariamente.Tag = mdlPreferencias.FREQUENCIABACKUP.DIARIAMENTE;
			this.m_rbDiariamente.Text = "Diariamente";
			this.m_ttBackup.SetToolTip(this.m_rbDiariamente, "Selecionar opção de Becape automático");
			this.m_rbDiariamente.CheckedChanged += new System.EventHandler(this.m_rbDiariamente_CheckedChanged);
			// 
			// m_rbNunca
			// 
			this.m_rbNunca.Checked = true;
			this.m_rbNunca.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_rbNunca.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.m_rbNunca.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_rbNunca.Location = new System.Drawing.Point(10, 24);
			this.m_rbNunca.Name = "m_rbNunca";
			this.m_rbNunca.Size = new System.Drawing.Size(54, 16);
			this.m_rbNunca.TabIndex = 0;
			this.m_rbNunca.TabStop = true;
			this.m_rbNunca.Tag = mdlPreferencias.FREQUENCIABACKUP.NUNCA;
			this.m_rbNunca.Text = "Nunca";
			this.m_ttBackup.SetToolTip(this.m_rbNunca, "Selecionar opção de Becape automático");
			this.m_rbNunca.CheckedChanged += new System.EventHandler(this.m_rbNunca_CheckedChanged);
			// 
			// m_flBrDlgPastas
			// 
			this.m_flBrDlgPastas.SelectedPath = "C:\\";
			// 
			// m_gbListaArquivos
			// 
			this.m_gbListaArquivos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_gbListaArquivos.Controls.Add(this.m_btRealizaBackup);
			this.m_gbListaArquivos.Controls.Add(this.m_btRealizaRestore);
			this.m_gbListaArquivos.Controls.Add(this.m_lvListaArquivos);
			this.m_gbListaArquivos.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_gbListaArquivos.Location = new System.Drawing.Point(7, 162);
			this.m_gbListaArquivos.Name = "m_gbListaArquivos";
			this.m_gbListaArquivos.Size = new System.Drawing.Size(379, 199);
			this.m_gbListaArquivos.TabIndex = 2;
			this.m_gbListaArquivos.TabStop = false;
			this.m_gbListaArquivos.Text = "Lista de Becapes";
			// 
			// m_btRealizaBackup
			// 
			this.m_btRealizaBackup.BackColor = System.Drawing.SystemColors.Control;
			this.m_btRealizaBackup.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btRealizaBackup.Font = new System.Drawing.Font("Arial", 8F);
			this.m_btRealizaBackup.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btRealizaBackup.Image = ((System.Drawing.Image)(resources.GetObject("m_btRealizaBackup.Image")));
			this.m_btRealizaBackup.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.m_btRealizaBackup.Location = new System.Drawing.Point(161, 15);
			this.m_btRealizaBackup.Name = "m_btRealizaBackup";
			this.m_btRealizaBackup.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btRealizaBackup.Size = new System.Drawing.Size(25, 25);
			this.m_btRealizaBackup.TabIndex = 35;
			this.m_btRealizaBackup.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.m_ttBackup.SetToolTip(this.m_btRealizaBackup, "Realiza Becape");
			this.m_btRealizaBackup.Click += new System.EventHandler(this.m_btRealizaBackup_Click);
			// 
			// m_btRealizaRestore
			// 
			this.m_btRealizaRestore.BackColor = System.Drawing.SystemColors.Control;
			this.m_btRealizaRestore.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btRealizaRestore.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btRealizaRestore.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btRealizaRestore.Image = ((System.Drawing.Image)(resources.GetObject("m_btRealizaRestore.Image")));
			this.m_btRealizaRestore.Location = new System.Drawing.Point(193, 15);
			this.m_btRealizaRestore.Name = "m_btRealizaRestore";
			this.m_btRealizaRestore.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btRealizaRestore.Size = new System.Drawing.Size(25, 25);
			this.m_btRealizaRestore.TabIndex = 34;
			this.m_ttBackup.SetToolTip(this.m_btRealizaRestore, "Restaurar Becape");
			this.m_btRealizaRestore.Click += new System.EventHandler(this.m_btRealizaRestore_Click);
			// 
			// m_lvListaArquivos
			// 
			this.m_lvListaArquivos.Activation = System.Windows.Forms.ItemActivation.OneClick;
			this.m_lvListaArquivos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_lvListaArquivos.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																								this.m_chFirst,
																								this.m_chSecond});
			this.m_lvListaArquivos.FullRowSelect = true;
			this.m_lvListaArquivos.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
			this.m_lvListaArquivos.HideSelection = false;
			this.m_lvListaArquivos.LargeImageList = this.m_ilIcones;
			this.m_lvListaArquivos.Location = new System.Drawing.Point(8, 45);
			this.m_lvListaArquivos.MultiSelect = false;
			this.m_lvListaArquivos.Name = "m_lvListaArquivos";
			this.m_lvListaArquivos.Size = new System.Drawing.Size(363, 146);
			this.m_lvListaArquivos.SmallImageList = this.m_ilIcones;
			this.m_lvListaArquivos.TabIndex = 0;
			this.m_ttBackup.SetToolTip(this.m_lvListaArquivos, "Duplo clique para realizar restauração do becape selecionado");
			this.m_lvListaArquivos.View = System.Windows.Forms.View.Details;
			this.m_lvListaArquivos.DoubleClick += new System.EventHandler(this.m_lvListaArquivos_DoubleClick);
			// 
			// m_chFirst
			// 
			this.m_chFirst.Width = 208;
			// 
			// m_chSecond
			// 
			this.m_chSecond.Width = 132;
			// 
			// m_ilIcones
			// 
			this.m_ilIcones.ImageSize = new System.Drawing.Size(16, 16);
			this.m_ilIcones.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("m_ilIcones.ImageStream")));
			this.m_ilIcones.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// m_ttBackup
			// 
			this.m_ttBackup.AutomaticDelay = 100;
			this.m_ttBackup.AutoPopDelay = 5000;
			this.m_ttBackup.InitialDelay = 100;
			this.m_ttBackup.ReshowDelay = 20;
			// 
			// m_svFlDlgSalvarBackup
			// 
			this.m_svFlDlgSalvarBackup.AddExtension = false;
			this.m_svFlDlgSalvarBackup.Filter = "Becape | *.bkp";
			this.m_svFlDlgSalvarBackup.Title = "Siscobras";
			// 
			// usrCtrlBackup
			// 
			this.Controls.Add(this.m_gbListaArquivos);
			this.Controls.Add(this.m_gbFrequencia);
			this.Controls.Add(this.m_gbDiretorio);
			this.Name = "usrCtrlBackup";
			this.Size = new System.Drawing.Size(394, 368);
			this.Load += new System.EventHandler(this.usrCtrlBackup_Load);
			this.m_gbDiretorio.ResumeLayout(false);
			this.m_gbFrequencia.ResumeLayout(false);
			this.m_gbListaArquivos.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Eventos
		#region Trocar Pasta
		private void m_btPasta_Click(object sender, System.EventArgs e)
		{
			OnCallTrocaDiretorioBackup();
			OnCallSalvaDadosInterface();
		}
		#endregion
		#region Checked Changed
		private void m_rbNunca_CheckedChanged(object sender, System.EventArgs e)
		{
			if ((m_rbNunca.Checked) && (!m_bOnLoad))
			{
				OnCallHabilitaCamposBackup(FREQUENCIABACKUP.NUNCA);
				OnCallSalvaDadosInterface();
			}
		}
		private void m_rbDiariamente_CheckedChanged(object sender, System.EventArgs e)
		{
			if ((m_rbDiariamente.Checked) && (!m_bOnLoad))
			{
				OnCallHabilitaCamposBackup(FREQUENCIABACKUP.DIARIAMENTE);
				OnCallSalvaDadosInterface();
			}
		}
		private void m_rbSemanalmente_CheckedChanged(object sender, System.EventArgs e)
		{
			if ((m_rbSemanalmente.Checked) && (!m_bOnLoad))
			{
				OnCallHabilitaCamposBackup(FREQUENCIABACKUP.SEMANALMENTE);
				OnCallSalvaDadosInterface();
			}
		}
		private void m_rbMensalmente_CheckedChanged(object sender, System.EventArgs e)
		{
			if ((m_rbMensalmente.Checked) && (!m_bOnLoad))
			{
				OnCallHabilitaCamposBackup(FREQUENCIABACKUP.MENSALMENTE);
				OnCallSalvaDadosInterface();
			}
		}
		#endregion
		#region Load
		private void usrCtrlBackup_Load(object sender, System.EventArgs e)
		{
			OnCallCarregaDadosInterface();
			m_bOnLoad = false;
		}
		#endregion
		#region Text Changed
		private void m_tbManter_TextChanged(object sender, System.EventArgs e)
		{
			if (!m_bOnLoad)
				OnCallSalvaDadosInterface();
		}
		#endregion
		#region Checked Changed
		private void m_ckbxPerguntar_CheckedChanged(object sender, System.EventArgs e)
		{
			if  (!m_bOnLoad)
				OnCallSalvaDadosInterface();
		}
		#endregion
		#region Criar Backup
		private void m_btRealizaBackup_Click(object sender, System.EventArgs e)
		{
			this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
			if (OnCallCriaBackup())
			{
				this.Refresh();
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				OnCallSalvaBackupCriado();
				mdlMensagens.clsMensagens.ShowInformation("Siscobras", mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.mdlPreferencias_usrCtrlBackup_BackupTerminou));
				this.Refresh();
			}
			this.Cursor = System.Windows.Forms.Cursors.Default;
		}
		#endregion
		#region Restaura Backup
		private void m_btRealizaRestore_Click(object sender, System.EventArgs e)
		{
			this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
			if (m_lvListaArquivos.SelectedItems.Count == 1)
			{
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				this.Refresh();
				mdlMensagens.clsMensagens.ShowInformation("Siscobras", mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.mdlPreferencias_usrCtrlBackup_AguardarRestauracao));
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				this.Refresh();
				OnCallRestauraBackup();
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				this.Refresh();
				mdlMensagens.clsMensagens.ShowInformation("Siscobras", mdlMensagens.clsRepositorioMensagens.GetMensagem(mdlMensagens.Mensagem.mdlPreferencias_usrCtrlBackup_RestauracaoTerminou));
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				this.Refresh();
			}
			this.Cursor = System.Windows.Forms.Cursors.Default;
		}
		#endregion
		#region Duplo Clique
		private void m_lvListaArquivos_DoubleClick(object sender, System.EventArgs e)
		{
			m_btRealizaRestore_Click(sender, e);
		}
		#endregion
		#endregion
	}
}
