using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace mdlNumero.CO.Frame
{
	/// <summary>
	/// Summary description for frmFTodosCOs.
	/// </summary>
	internal class frmFTodosCOs : mdlComponentesGraficos.FormFlutuante
	{
		#region Atributos
		private mdlTratamentoErro.clsTratamentoErro m_cls_ter_tratadorErro = null;
		private string m_strEnderecoExecutavel = "";

		private bool m_bModificado = false;

		private System.Windows.Forms.GroupBox m_gbFrame;
		private System.Windows.Forms.GroupBox m_gbFields;
		private System.Windows.Forms.Button m_btOk;
		private System.Windows.Forms.Button m_btCancelar;
		private System.Windows.Forms.Button m_btTrocarCor;
		private System.Windows.Forms.Label m_lAladiAce39;
		private mdlComponentesGraficos.TextBox m_tbAladiAce39;
		private mdlComponentesGraficos.TextBox m_tbAladiAptr04;
		private System.Windows.Forms.Label m_lAladiAptr04;
		private mdlComponentesGraficos.TextBox m_tbAnexo3;
		private System.Windows.Forms.Label m_lAnexo3;
		private mdlComponentesGraficos.TextBox m_tbComum;
		private System.Windows.Forms.Label m_lComum;
		private mdlComponentesGraficos.TextBox m_tbFormA;
		private System.Windows.Forms.Label m_lFormA;
		private mdlComponentesGraficos.TextBox m_tbMercosul;
		private System.Windows.Forms.Label m_lMercosul;
		private mdlComponentesGraficos.TextBox m_tbBolivia;
		private System.Windows.Forms.Label m_lBolivia;
		private mdlComponentesGraficos.TextBox m_tbChile;
		private System.Windows.Forms.Label m_lChile;
		private System.Windows.Forms.ToolTip m_ttCOs;
		private mdlComponentesGraficos.TextBox m_tbAladiAce59;
		private System.Windows.Forms.Label m_lAladiAce59;
		private System.ComponentModel.IContainer components;
		#endregion

		#region Construtores & Destrutores
		public frmFTodosCOs(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, string enderecoExecutavel)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			m_cls_ter_tratadorErro = tratadorErro;
			m_strEnderecoExecutavel = enderecoExecutavel;
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
		public delegate void delCallCarregaDadosInterface(ref Label lAladiAce39, ref mdlComponentesGraficos.TextBox tbAladiAce39,ref Label lAladiAce59, ref mdlComponentesGraficos.TextBox tbAladiAce59, ref Label lAladiAptr04, ref mdlComponentesGraficos.TextBox tbAladiAptr04, ref Label lAnexo3, ref mdlComponentesGraficos.TextBox tbAnexo3, ref Label lComum, ref mdlComponentesGraficos.TextBox tbComum, ref Label lFormA, ref mdlComponentesGraficos.TextBox tbFormA, ref Label lMercosul, ref mdlComponentesGraficos.TextBox tbMercosul, ref Label lBolivia, ref mdlComponentesGraficos.TextBox tbBolivia, ref Label lChile, ref mdlComponentesGraficos.TextBox tbChile);
		public delegate void delCallSalvaDadosInterface(ref Label lAladiAce39, ref mdlComponentesGraficos.TextBox tbAladiAce39,ref Label lAladiAce59, ref mdlComponentesGraficos.TextBox tbAladiAce59, ref Label lAladiAptr04, ref mdlComponentesGraficos.TextBox tbAladiAptr04, ref Label lAnexo3, ref mdlComponentesGraficos.TextBox tbAnexo3, ref Label lComum, ref mdlComponentesGraficos.TextBox tbComum, ref Label lFormA, ref mdlComponentesGraficos.TextBox tbFormA, ref Label lMercosul, ref mdlComponentesGraficos.TextBox tbMercosul, ref Label lBolivia, ref mdlComponentesGraficos.TextBox tbBolivia, ref Label lChile, ref mdlComponentesGraficos.TextBox tbChile);
		public delegate void delCallSalvaDadosBD(bool bModificado);
		#endregion
		#region Events
		public event delCallCarregaDadosInterface eCallCarregaDadosInterface;
		public event delCallSalvaDadosInterface eCallSalvaDadosInterface;
		public event delCallSalvaDadosBD eCallSalvaDadosBD;
		#endregion
		#region Events Methods
		protected virtual void OnCallCarregaDadosInterface()
		{
			if (eCallCarregaDadosInterface != null)
				eCallCarregaDadosInterface(ref m_lAladiAce39, ref m_tbAladiAce39,ref m_lAladiAce59, ref m_tbAladiAce59, ref m_lAladiAptr04, ref m_tbAladiAptr04, ref m_lAnexo3, ref m_tbAnexo3, ref m_lComum, ref m_tbComum, ref m_lFormA, ref m_tbFormA, ref m_lMercosul, ref m_tbMercosul, ref m_lBolivia, ref m_tbBolivia, ref m_lChile, ref m_tbChile);
		}
		protected virtual void OnCallSalvaDadosInterface()
		{
			if (eCallSalvaDadosInterface != null)
				eCallSalvaDadosInterface(ref m_lAladiAce39, ref m_tbAladiAce39,ref m_lAladiAce59, ref m_tbAladiAce59, ref m_lAladiAptr04, ref m_tbAladiAptr04, ref m_lAnexo3, ref m_tbAnexo3, ref m_lComum, ref m_tbComum, ref m_lFormA, ref m_tbFormA, ref m_lMercosul, ref m_tbMercosul, ref m_lBolivia, ref m_tbBolivia, ref m_lChile, ref m_tbChile);
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmFTodosCOs));
			this.m_gbFrame = new System.Windows.Forms.GroupBox();
			this.m_btTrocarCor = new System.Windows.Forms.Button();
			this.m_btOk = new System.Windows.Forms.Button();
			this.m_btCancelar = new System.Windows.Forms.Button();
			this.m_gbFields = new System.Windows.Forms.GroupBox();
			this.m_tbChile = new mdlComponentesGraficos.TextBox();
			this.m_lChile = new System.Windows.Forms.Label();
			this.m_tbBolivia = new mdlComponentesGraficos.TextBox();
			this.m_lBolivia = new System.Windows.Forms.Label();
			this.m_tbMercosul = new mdlComponentesGraficos.TextBox();
			this.m_lMercosul = new System.Windows.Forms.Label();
			this.m_tbFormA = new mdlComponentesGraficos.TextBox();
			this.m_lFormA = new System.Windows.Forms.Label();
			this.m_tbComum = new mdlComponentesGraficos.TextBox();
			this.m_lComum = new System.Windows.Forms.Label();
			this.m_tbAnexo3 = new mdlComponentesGraficos.TextBox();
			this.m_lAnexo3 = new System.Windows.Forms.Label();
			this.m_tbAladiAptr04 = new mdlComponentesGraficos.TextBox();
			this.m_lAladiAptr04 = new System.Windows.Forms.Label();
			this.m_tbAladiAce39 = new mdlComponentesGraficos.TextBox();
			this.m_lAladiAce39 = new System.Windows.Forms.Label();
			this.m_ttCOs = new System.Windows.Forms.ToolTip(this.components);
			this.m_tbAladiAce59 = new mdlComponentesGraficos.TextBox();
			this.m_lAladiAce59 = new System.Windows.Forms.Label();
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
			this.m_gbFrame.Size = new System.Drawing.Size(278, 302);
			this.m_gbFrame.TabIndex = 0;
			this.m_gbFrame.TabStop = false;
			// 
			// m_btTrocarCor
			// 
			this.m_btTrocarCor.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(64)), ((System.Byte)(0)));
			this.m_btTrocarCor.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btTrocarCor.Location = new System.Drawing.Point(4, 9);
			this.m_btTrocarCor.Name = "m_btTrocarCor";
			this.m_btTrocarCor.Size = new System.Drawing.Size(4, 4);
			this.m_btTrocarCor.TabIndex = 3;
			this.m_ttCOs.SetToolTip(this.m_btTrocarCor, "Cor");
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
			this.m_btOk.Location = new System.Drawing.Point(79, 270);
			this.m_btOk.Name = "m_btOk";
			this.m_btOk.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btOk.Size = new System.Drawing.Size(57, 27);
			this.m_btOk.TabIndex = 1;
			this.m_ttCOs.SetToolTip(this.m_btOk, "Confirmar");
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
			this.m_btCancelar.Location = new System.Drawing.Point(143, 270);
			this.m_btCancelar.Name = "m_btCancelar";
			this.m_btCancelar.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btCancelar.Size = new System.Drawing.Size(57, 27);
			this.m_btCancelar.TabIndex = 2;
			this.m_ttCOs.SetToolTip(this.m_btCancelar, "Cancelar");
			this.m_btCancelar.Click += new System.EventHandler(this.m_btCancelar_Click);
			// 
			// m_gbFields
			// 
			this.m_gbFields.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_gbFields.Controls.Add(this.m_tbAladiAce59);
			this.m_gbFields.Controls.Add(this.m_lAladiAce59);
			this.m_gbFields.Controls.Add(this.m_tbChile);
			this.m_gbFields.Controls.Add(this.m_lChile);
			this.m_gbFields.Controls.Add(this.m_tbBolivia);
			this.m_gbFields.Controls.Add(this.m_lBolivia);
			this.m_gbFields.Controls.Add(this.m_tbMercosul);
			this.m_gbFields.Controls.Add(this.m_lMercosul);
			this.m_gbFields.Controls.Add(this.m_tbFormA);
			this.m_gbFields.Controls.Add(this.m_lFormA);
			this.m_gbFields.Controls.Add(this.m_tbComum);
			this.m_gbFields.Controls.Add(this.m_lComum);
			this.m_gbFields.Controls.Add(this.m_tbAnexo3);
			this.m_gbFields.Controls.Add(this.m_lAnexo3);
			this.m_gbFields.Controls.Add(this.m_tbAladiAptr04);
			this.m_gbFields.Controls.Add(this.m_lAladiAptr04);
			this.m_gbFields.Controls.Add(this.m_tbAladiAce39);
			this.m_gbFields.Controls.Add(this.m_lAladiAce39);
			this.m_gbFields.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_gbFields.Location = new System.Drawing.Point(8, 8);
			this.m_gbFields.Name = "m_gbFields";
			this.m_gbFields.Size = new System.Drawing.Size(262, 258);
			this.m_gbFields.TabIndex = 0;
			this.m_gbFields.TabStop = false;
			this.m_gbFields.Text = "Certificados de Origem";
			// 
			// m_tbChile
			// 
			this.m_tbChile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.m_tbChile.Enabled = false;
			this.m_tbChile.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_tbChile.Location = new System.Drawing.Point(104, 224);
			this.m_tbChile.Name = "m_tbChile";
			this.m_tbChile.Size = new System.Drawing.Size(150, 20);
			this.m_tbChile.TabIndex = 8;
			this.m_tbChile.Text = "";
			this.m_tbChile.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// m_lChile
			// 
			this.m_lChile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_lChile.Enabled = false;
			this.m_lChile.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lChile.Location = new System.Drawing.Point(8, 224);
			this.m_lChile.Name = "m_lChile";
			this.m_lChile.Size = new System.Drawing.Size(96, 18);
			this.m_lChile.TabIndex = 0;
			this.m_lChile.Text = "Mercosul Chile:";
			this.m_lChile.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// m_tbBolivia
			// 
			this.m_tbBolivia.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.m_tbBolivia.Enabled = false;
			this.m_tbBolivia.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_tbBolivia.Location = new System.Drawing.Point(104, 200);
			this.m_tbBolivia.Name = "m_tbBolivia";
			this.m_tbBolivia.Size = new System.Drawing.Size(150, 20);
			this.m_tbBolivia.TabIndex = 7;
			this.m_tbBolivia.Text = "";
			this.m_tbBolivia.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// m_lBolivia
			// 
			this.m_lBolivia.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_lBolivia.Enabled = false;
			this.m_lBolivia.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lBolivia.Location = new System.Drawing.Point(8, 200);
			this.m_lBolivia.Name = "m_lBolivia";
			this.m_lBolivia.Size = new System.Drawing.Size(120, 18);
			this.m_lBolivia.TabIndex = 0;
			this.m_lBolivia.Text = "Mercosul Bolívia:";
			this.m_lBolivia.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// m_tbMercosul
			// 
			this.m_tbMercosul.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.m_tbMercosul.Enabled = false;
			this.m_tbMercosul.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_tbMercosul.Location = new System.Drawing.Point(104, 176);
			this.m_tbMercosul.Name = "m_tbMercosul";
			this.m_tbMercosul.Size = new System.Drawing.Size(150, 20);
			this.m_tbMercosul.TabIndex = 6;
			this.m_tbMercosul.Text = "";
			this.m_tbMercosul.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// m_lMercosul
			// 
			this.m_lMercosul.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_lMercosul.Enabled = false;
			this.m_lMercosul.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lMercosul.Location = new System.Drawing.Point(8, 176);
			this.m_lMercosul.Name = "m_lMercosul";
			this.m_lMercosul.Size = new System.Drawing.Size(83, 18);
			this.m_lMercosul.TabIndex = 0;
			this.m_lMercosul.Text = "Mercosul:";
			this.m_lMercosul.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// m_tbFormA
			// 
			this.m_tbFormA.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.m_tbFormA.Enabled = false;
			this.m_tbFormA.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_tbFormA.Location = new System.Drawing.Point(104, 152);
			this.m_tbFormA.Name = "m_tbFormA";
			this.m_tbFormA.Size = new System.Drawing.Size(150, 20);
			this.m_tbFormA.TabIndex = 5;
			this.m_tbFormA.Text = "";
			this.m_tbFormA.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// m_lFormA
			// 
			this.m_lFormA.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_lFormA.Enabled = false;
			this.m_lFormA.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lFormA.Location = new System.Drawing.Point(8, 152);
			this.m_lFormA.Name = "m_lFormA";
			this.m_lFormA.Size = new System.Drawing.Size(83, 18);
			this.m_lFormA.TabIndex = 0;
			this.m_lFormA.Text = "Form A:";
			this.m_lFormA.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// m_tbComum
			// 
			this.m_tbComum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.m_tbComum.Enabled = false;
			this.m_tbComum.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_tbComum.Location = new System.Drawing.Point(104, 128);
			this.m_tbComum.Name = "m_tbComum";
			this.m_tbComum.Size = new System.Drawing.Size(150, 20);
			this.m_tbComum.TabIndex = 4;
			this.m_tbComum.Text = "";
			this.m_tbComum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// m_lComum
			// 
			this.m_lComum.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_lComum.Enabled = false;
			this.m_lComum.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lComum.Location = new System.Drawing.Point(8, 128);
			this.m_lComum.Name = "m_lComum";
			this.m_lComum.Size = new System.Drawing.Size(83, 18);
			this.m_lComum.TabIndex = 0;
			this.m_lComum.Text = "Comum:";
			this.m_lComum.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// m_tbAnexo3
			// 
			this.m_tbAnexo3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.m_tbAnexo3.Enabled = false;
			this.m_tbAnexo3.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_tbAnexo3.Location = new System.Drawing.Point(104, 104);
			this.m_tbAnexo3.Name = "m_tbAnexo3";
			this.m_tbAnexo3.Size = new System.Drawing.Size(150, 20);
			this.m_tbAnexo3.TabIndex = 3;
			this.m_tbAnexo3.Text = "";
			this.m_tbAnexo3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// m_lAnexo3
			// 
			this.m_lAnexo3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_lAnexo3.Enabled = false;
			this.m_lAnexo3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lAnexo3.Location = new System.Drawing.Point(8, 104);
			this.m_lAnexo3.Name = "m_lAnexo3";
			this.m_lAnexo3.Size = new System.Drawing.Size(83, 18);
			this.m_lAnexo3.TabIndex = 0;
			this.m_lAnexo3.Text = "Anexo III:";
			this.m_lAnexo3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// m_tbAladiAptr04
			// 
			this.m_tbAladiAptr04.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.m_tbAladiAptr04.Enabled = false;
			this.m_tbAladiAptr04.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_tbAladiAptr04.Location = new System.Drawing.Point(104, 80);
			this.m_tbAladiAptr04.Name = "m_tbAladiAptr04";
			this.m_tbAladiAptr04.Size = new System.Drawing.Size(150, 20);
			this.m_tbAladiAptr04.TabIndex = 2;
			this.m_tbAladiAptr04.Text = "";
			this.m_tbAladiAptr04.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// m_lAladiAptr04
			// 
			this.m_lAladiAptr04.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_lAladiAptr04.Enabled = false;
			this.m_lAladiAptr04.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lAladiAptr04.Location = new System.Drawing.Point(8, 80);
			this.m_lAladiAptr04.Name = "m_lAladiAptr04";
			this.m_lAladiAptr04.Size = new System.Drawing.Size(83, 18);
			this.m_lAladiAptr04.TabIndex = 0;
			this.m_lAladiAptr04.Text = "Aladi Aptr 04:";
			this.m_lAladiAptr04.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// m_tbAladiAce39
			// 
			this.m_tbAladiAce39.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.m_tbAladiAce39.Enabled = false;
			this.m_tbAladiAce39.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_tbAladiAce39.Location = new System.Drawing.Point(104, 27);
			this.m_tbAladiAce39.Name = "m_tbAladiAce39";
			this.m_tbAladiAce39.Size = new System.Drawing.Size(150, 20);
			this.m_tbAladiAce39.TabIndex = 1;
			this.m_tbAladiAce39.Text = "";
			this.m_tbAladiAce39.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// m_lAladiAce39
			// 
			this.m_lAladiAce39.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_lAladiAce39.Enabled = false;
			this.m_lAladiAce39.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lAladiAce39.Location = new System.Drawing.Point(8, 27);
			this.m_lAladiAce39.Name = "m_lAladiAce39";
			this.m_lAladiAce39.Size = new System.Drawing.Size(83, 18);
			this.m_lAladiAce39.TabIndex = 0;
			this.m_lAladiAce39.Text = "Aladi Ace 39:";
			this.m_lAladiAce39.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// m_ttCOs
			// 
			this.m_ttCOs.AutomaticDelay = 100;
			this.m_ttCOs.AutoPopDelay = 5000;
			this.m_ttCOs.InitialDelay = 100;
			this.m_ttCOs.ReshowDelay = 20;
			// 
			// m_tbAladiAce59
			// 
			this.m_tbAladiAce59.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.m_tbAladiAce59.Enabled = false;
			this.m_tbAladiAce59.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_tbAladiAce59.Location = new System.Drawing.Point(104, 52);
			this.m_tbAladiAce59.Name = "m_tbAladiAce59";
			this.m_tbAladiAce59.Size = new System.Drawing.Size(150, 20);
			this.m_tbAladiAce59.TabIndex = 10;
			this.m_tbAladiAce59.Text = "";
			this.m_tbAladiAce59.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// m_lAladiAce59
			// 
			this.m_lAladiAce59.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_lAladiAce59.Enabled = false;
			this.m_lAladiAce59.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lAladiAce59.Location = new System.Drawing.Point(8, 53);
			this.m_lAladiAce59.Name = "m_lAladiAce59";
			this.m_lAladiAce59.Size = new System.Drawing.Size(83, 18);
			this.m_lAladiAce59.TabIndex = 9;
			this.m_lAladiAce59.Text = "Aladi Ace 59:";
			this.m_lAladiAce59.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// frmFTodosCOs
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(282, 304);
			this.Controls.Add(this.m_gbFrame);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmFTodosCOs";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Siscobras";
			this.Load += new System.EventHandler(this.frmFTodosCOs_Load);
			this.m_gbFrame.ResumeLayout(false);
			this.m_gbFields.ResumeLayout(false);
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
						if ((this.Controls[cont].Controls[cont2].GetType().ToString() != "mdlComponentesGraficos.TextBox") && (this.Controls[cont].Controls[cont2].GetType().ToString() != "mdlComponentes.compTextNumber"))
						{
							this.Controls[cont].Controls[cont2].BackColor = this.BackColor;
						}
						for (int cont3 = 0; cont3 < this.Controls[cont].Controls[cont2].Controls.Count; cont3++)
						{
							if ((this.Controls[cont].Controls[cont2].Controls[cont3].GetType().ToString() != 
								"System.Windows.Forms.TextBox") &&
								(this.Controls[cont].Controls[cont2].Controls[cont3].GetType().ToString() != 
								"mdlComponentesGraficos.TextBox") &&
								(this.Controls[cont].Controls[cont2].Controls[cont3].GetType().ToString() != 
								"mdlComponentesGraficos.ComboBox"))
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

		#region Eventos
		#region Load
		private void frmFTodosCOs_Load(object sender, System.EventArgs e)
		{
			try
			{
				this.mostraCor();
				OnCallCarregaDadosInterface();
			}
			catch (Exception err)
			{
				m_cls_ter_tratadorErro.trataErro(ref err);
			}
		}
		#endregion
		#region Cor
		private void m_btTrocarCor_Click(object sender, System.EventArgs e)
		{
			this.trocaCor();
		}
		#endregion
		#region Cancelar
		private void m_btCancelar_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}
		#endregion
		#region Ok
		private void m_btOk_Click(object sender, System.EventArgs e)
		{
			try
			{
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				m_bModificado = true;
				OnCallSalvaDadosInterface();
				OnCallSalvaDadosBD();
				this.Close();
				this.Cursor = System.Windows.Forms.Cursors.Default;
			}
			catch (Exception err)
			{
				m_cls_ter_tratadorErro.trataErro(ref err);
			}
		}
		#endregion
		#endregion
	}
}
