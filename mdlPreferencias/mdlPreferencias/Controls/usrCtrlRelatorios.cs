using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace mdlPreferencias
{
	/// <summary>
	/// Summary description for usrCtrlRelatorios.
	/// </summary>
	internal class usrCtrlRelatorios : System.Windows.Forms.UserControl
	{
		#region Delegates
			public delegate void delCallCarregaDadosInterface(out int nFaturaComercialPrecisaoPesoLiquidoTotal,out int nFaturaComercialPrecisaoPesoBrutoTotal,out bool bFaturaComercialPrecisaoPesoLiquidoTotalArredondar,out bool bFaturaComercialPrecisaoPesoBrutoTotalArredondar,out int nRomaneioPrecisaoPesoLiquidoItens,out int nRomaneioPrecisaoPesoLiquidoTotal,out int nRomaneioPrecisaoPesoBrutoItens,out int nRomaneioPrecisaoPesoBrutoTotal,out bool bRomaneioPrecisaoPesoLiquidoItensArredondar,out bool bRomaneioPrecisaoPesoLiquidoTotalArredondar,out bool bRomaneioPrecisaoPesoBrutoItensArredondar,out bool bRomaneioPrecisaoPesoBrutoTotalArredondar,out bool bCanEditProducts);
			public delegate void delCallSalvaDadosInterface(int nFaturaComercialPrecisaoPesoLiquidoTotal,int nFaturaComercialPrecisaoPesoBrutoTotal,bool bFaturaComercialPrecisaoPesoLiquidoTotalArredondar,bool bFaturaComercialPrecisaoPesoBrutoTotalArredondar,int nRomaneioPrecisaoPesoLiquidoItens,int nRomaneioPrecisaoPesoLiquidoTotal,int nRomaneioPrecisaoPesoBrutoItens,int nRomaneioPrecisaoPesoBrutoTotal,bool bRomaneioPrecisaoPesoLiquidoItensArredondar,bool bRomaneioPrecisaoPesoLiquidoTotalArredondar,bool bRomaneioPrecisaoPesoBrutoItensArredondar,bool bRomaneioPrecisaoPesoBrutoTotalArredondar,bool bCanEditProducts);
		#endregion
		#region Events
			public event delCallCarregaDadosInterface eCallCarregaDadosInterface;
			public event delCallSalvaDadosInterface eCallSalvaDadosInterface;
		#endregion
		#region Events Methods
			protected virtual void OnCallCarregaDadosInterface()
			{
				if (eCallCarregaDadosInterface != null)
				{
					int nFaturaComercialPrecisaoPesoLiquidoTotal,nFaturaComercialPrecisaoPesoBrutoTotal,nRomaneioPrecisaoPesoLiquidoItens,nRomaneioPrecisaoPesoLiquidoTotal,nRomaneioPrecisaoPesoBrutoItens,nRomaneioPrecisaoPesoBrutoTotal;
					bool bFaturaComercialPrecisaoPesoLiquidoTotalArredondar,bFaturaComercialPrecisaoPesoBrutoTotalArredondar,bRomaneioPrecisaoPesoLiquidoItensArredondar,bRomaneioPrecisaoPesoLiquidoTotalArredondar,bRomaneioPrecisaoPesoBrutoItensArredondar,bRomaneioPrecisaoPesoBrutoTotalArredondar,bCanEditProducts;
					eCallCarregaDadosInterface(out nFaturaComercialPrecisaoPesoLiquidoTotal,out nFaturaComercialPrecisaoPesoBrutoTotal,out bFaturaComercialPrecisaoPesoLiquidoTotalArredondar,out bFaturaComercialPrecisaoPesoBrutoTotalArredondar,out nRomaneioPrecisaoPesoLiquidoItens,out nRomaneioPrecisaoPesoLiquidoTotal,out nRomaneioPrecisaoPesoBrutoItens,out nRomaneioPrecisaoPesoBrutoTotal,out bRomaneioPrecisaoPesoLiquidoItensArredondar,out bRomaneioPrecisaoPesoLiquidoTotalArredondar,out bRomaneioPrecisaoPesoBrutoItensArredondar,out bRomaneioPrecisaoPesoBrutoTotalArredondar,out bCanEditProducts);
					m_tbFaturaComercialPrecisaoPesoLiquidoTotal.Value = nFaturaComercialPrecisaoPesoLiquidoTotal;
					m_tbFaturaComercialPrecisaoPesoBrutoTotal.Value = nFaturaComercialPrecisaoPesoBrutoTotal;
					m_tbPrecisaoPesoLiquidoItens.Value = nRomaneioPrecisaoPesoLiquidoItens;
					m_tbRomaneioPrecisaoPesoLiquidoTotal.Value = nRomaneioPrecisaoPesoLiquidoTotal;
					m_tbPrecisaoPesoBrutoItens.Value = nRomaneioPrecisaoPesoBrutoItens;
					m_tbRomaneioPrecisaoPesoBrutoTotal.Value = nRomaneioPrecisaoPesoBrutoTotal;
					m_ckFaturaComercialPrecisaoPesoLiquidoTotalArredondar.Checked = bFaturaComercialPrecisaoPesoLiquidoTotalArredondar;
					m_ckFaturaComercialPrecisaoPesoBrutoTotalArredondar.Checked = bFaturaComercialPrecisaoPesoBrutoTotalArredondar;
					m_ckRomaneioPrecisaoPesoLiquidoItemArredondar.Checked = bRomaneioPrecisaoPesoLiquidoItensArredondar;
					m_ckRomaneioPrecisaoPesoLiquidoTotalArredondar.Checked = bRomaneioPrecisaoPesoLiquidoTotalArredondar;
					m_ckRomaneioPrecisaoPesoBrutoItemArredondar.Checked = bRomaneioPrecisaoPesoBrutoItensArredondar;
					m_ckRomaneioPrecisaoPesoBrutoTotalArredondar.Checked = bRomaneioPrecisaoPesoBrutoTotalArredondar;
					m_ckCanEditProducts.Checked = bCanEditProducts;
				}
			}
			public virtual void OnCallSalvaDadosInterface()
			{
				if (eCallSalvaDadosInterface != null)
					eCallSalvaDadosInterface(m_tbFaturaComercialPrecisaoPesoLiquidoTotal.Value,m_tbFaturaComercialPrecisaoPesoBrutoTotal.Value,m_ckFaturaComercialPrecisaoPesoLiquidoTotalArredondar.Checked,m_ckFaturaComercialPrecisaoPesoBrutoTotalArredondar.Checked, m_tbPrecisaoPesoLiquidoItens.Value,m_tbRomaneioPrecisaoPesoLiquidoTotal.Value,m_tbPrecisaoPesoBrutoItens.Value,m_tbRomaneioPrecisaoPesoBrutoTotal.Value,m_ckRomaneioPrecisaoPesoLiquidoItemArredondar.Checked,m_ckRomaneioPrecisaoPesoLiquidoTotalArredondar.Checked,m_ckRomaneioPrecisaoPesoBrutoItemArredondar.Checked,m_ckRomaneioPrecisaoPesoBrutoTotalArredondar.Checked,m_ckCanEditProducts.Checked);
			}
		#endregion

		#region Atributes
			private bool m_bAtivado = true;

			private System.Windows.Forms.TabControl m_tcRelatorios;
			private System.Windows.Forms.TabPage m_tpRomaneio;
			private System.Windows.Forms.TrackBar m_tbPrecisaoPesoLiquidoItens;
			private System.Windows.Forms.Label m_lbPrecisaoPesoBrutoItens;
			private System.Windows.Forms.TrackBar m_tbPrecisaoPesoBrutoItens;
			private System.Windows.Forms.TextBox m_txtPrecisaoPesoLiquidoItens;
			private System.Windows.Forms.TextBox m_txtPrecisaoPesoBrutoItens;
			private System.Windows.Forms.CheckBox m_ckRomaneioPrecisaoPesoLiquidoItemArredondar;
			private System.Windows.Forms.CheckBox m_ckRomaneioPrecisaoPesoLiquidoTotalArredondar;
			private System.Windows.Forms.CheckBox m_ckRomaneioPrecisaoPesoBrutoItemArredondar;
			private System.Windows.Forms.CheckBox m_ckRomaneioPrecisaoPesoBrutoTotalArredondar;
			private System.Windows.Forms.TabPage m_tpFaturasComerciais;
			private System.Windows.Forms.GroupBox m_gbRomaneiosPrecisao;
			private System.Windows.Forms.GroupBox m_gbFaturasComerciaisPrecisao;
			private System.Windows.Forms.GroupBox m_gbRomaneioPrecisaoPesoLiquido;
			private System.Windows.Forms.GroupBox m_gbFaturasComerciaisPrecisaoPesoLiquido;
			private System.Windows.Forms.GroupBox m_gbRomaneioPrecisaoPesoBruto;
			private System.Windows.Forms.GroupBox m_gbFaturaComercialPrecisaoPesoBruto;
			private System.Windows.Forms.Label m_lbRomaneioPrecisaoPesoBrutoTotal;
			private System.Windows.Forms.TextBox m_txtRomaneioPrecisaoPesoLiquidoTotal;
			private System.Windows.Forms.Label m_lbRomaneioPrecisaoPesoLiquidoTotal;
			private System.Windows.Forms.Label m_lbRomaneioPrecisaoPesoLiquidoItens;
			private System.Windows.Forms.TrackBar m_tbRomaneioPrecisaoPesoLiquidoTotal;
			private System.Windows.Forms.Label m_lbFaturaComercialPrecisaoPesoBrutoTotal;
			private System.Windows.Forms.CheckBox m_ckFaturaComercialPrecisaoPesoLiquidoTotalArredondar;
			private System.Windows.Forms.TextBox m_txtFaturaComercialPrecisaoPesoLiquidoTotal;
			private System.Windows.Forms.Label m_lbFaturaComercialPrecisaoPesoLiquidoTotal;
			private System.Windows.Forms.TrackBar m_tbFaturaComercialPrecisaoPesoLiquidoTotal;
			private System.Windows.Forms.TextBox m_txtRomaneioPrecisaoPesoBrutoTotal;
			private System.Windows.Forms.TrackBar m_tbRomaneioPrecisaoPesoBrutoTotal;
			private System.Windows.Forms.CheckBox m_ckFaturaComercialPrecisaoPesoBrutoTotalArredondar;
			private System.Windows.Forms.TextBox m_txtFaturaComercialPrecisaoPesoBrutoTotal;
			private System.Windows.Forms.TrackBar m_tbFaturaComercialPrecisaoPesoBrutoTotal;
			private System.Windows.Forms.GroupBox m_gbProdutos;
		private System.Windows.Forms.CheckBox m_ckCanEditProducts;
			private System.ComponentModel.Container components = null;
		#endregion
		#region Constructors and Destructors
			public usrCtrlRelatorios()
			{
				InitializeComponent();
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
		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.m_tcRelatorios = new System.Windows.Forms.TabControl();
			this.m_tpFaturasComerciais = new System.Windows.Forms.TabPage();
			this.m_gbProdutos = new System.Windows.Forms.GroupBox();
			this.m_ckCanEditProducts = new System.Windows.Forms.CheckBox();
			this.m_gbFaturasComerciaisPrecisao = new System.Windows.Forms.GroupBox();
			this.m_gbFaturaComercialPrecisaoPesoBruto = new System.Windows.Forms.GroupBox();
			this.m_ckFaturaComercialPrecisaoPesoBrutoTotalArredondar = new System.Windows.Forms.CheckBox();
			this.m_txtFaturaComercialPrecisaoPesoBrutoTotal = new System.Windows.Forms.TextBox();
			this.m_lbFaturaComercialPrecisaoPesoBrutoTotal = new System.Windows.Forms.Label();
			this.m_tbFaturaComercialPrecisaoPesoBrutoTotal = new System.Windows.Forms.TrackBar();
			this.m_gbFaturasComerciaisPrecisaoPesoLiquido = new System.Windows.Forms.GroupBox();
			this.m_ckFaturaComercialPrecisaoPesoLiquidoTotalArredondar = new System.Windows.Forms.CheckBox();
			this.m_txtFaturaComercialPrecisaoPesoLiquidoTotal = new System.Windows.Forms.TextBox();
			this.m_lbFaturaComercialPrecisaoPesoLiquidoTotal = new System.Windows.Forms.Label();
			this.m_tbFaturaComercialPrecisaoPesoLiquidoTotal = new System.Windows.Forms.TrackBar();
			this.m_tpRomaneio = new System.Windows.Forms.TabPage();
			this.m_gbRomaneiosPrecisao = new System.Windows.Forms.GroupBox();
			this.m_gbRomaneioPrecisaoPesoBruto = new System.Windows.Forms.GroupBox();
			this.m_ckRomaneioPrecisaoPesoBrutoTotalArredondar = new System.Windows.Forms.CheckBox();
			this.m_ckRomaneioPrecisaoPesoBrutoItemArredondar = new System.Windows.Forms.CheckBox();
			this.m_txtRomaneioPrecisaoPesoBrutoTotal = new System.Windows.Forms.TextBox();
			this.m_lbRomaneioPrecisaoPesoBrutoTotal = new System.Windows.Forms.Label();
			this.m_lbPrecisaoPesoBrutoItens = new System.Windows.Forms.Label();
			this.m_tbPrecisaoPesoBrutoItens = new System.Windows.Forms.TrackBar();
			this.m_tbRomaneioPrecisaoPesoBrutoTotal = new System.Windows.Forms.TrackBar();
			this.m_txtPrecisaoPesoBrutoItens = new System.Windows.Forms.TextBox();
			this.m_gbRomaneioPrecisaoPesoLiquido = new System.Windows.Forms.GroupBox();
			this.m_ckRomaneioPrecisaoPesoLiquidoTotalArredondar = new System.Windows.Forms.CheckBox();
			this.m_txtRomaneioPrecisaoPesoLiquidoTotal = new System.Windows.Forms.TextBox();
			this.m_txtPrecisaoPesoLiquidoItens = new System.Windows.Forms.TextBox();
			this.m_lbRomaneioPrecisaoPesoLiquidoTotal = new System.Windows.Forms.Label();
			this.m_lbRomaneioPrecisaoPesoLiquidoItens = new System.Windows.Forms.Label();
			this.m_tbPrecisaoPesoLiquidoItens = new System.Windows.Forms.TrackBar();
			this.m_tbRomaneioPrecisaoPesoLiquidoTotal = new System.Windows.Forms.TrackBar();
			this.m_ckRomaneioPrecisaoPesoLiquidoItemArredondar = new System.Windows.Forms.CheckBox();
			this.m_tcRelatorios.SuspendLayout();
			this.m_tpFaturasComerciais.SuspendLayout();
			this.m_gbProdutos.SuspendLayout();
			this.m_gbFaturasComerciaisPrecisao.SuspendLayout();
			this.m_gbFaturaComercialPrecisaoPesoBruto.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.m_tbFaturaComercialPrecisaoPesoBrutoTotal)).BeginInit();
			this.m_gbFaturasComerciaisPrecisaoPesoLiquido.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.m_tbFaturaComercialPrecisaoPesoLiquidoTotal)).BeginInit();
			this.m_tpRomaneio.SuspendLayout();
			this.m_gbRomaneiosPrecisao.SuspendLayout();
			this.m_gbRomaneioPrecisaoPesoBruto.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.m_tbPrecisaoPesoBrutoItens)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.m_tbRomaneioPrecisaoPesoBrutoTotal)).BeginInit();
			this.m_gbRomaneioPrecisaoPesoLiquido.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.m_tbPrecisaoPesoLiquidoItens)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.m_tbRomaneioPrecisaoPesoLiquidoTotal)).BeginInit();
			this.SuspendLayout();
			// 
			// m_tcRelatorios
			// 
			this.m_tcRelatorios.Controls.Add(this.m_tpFaturasComerciais);
			this.m_tcRelatorios.Controls.Add(this.m_tpRomaneio);
			this.m_tcRelatorios.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_tcRelatorios.Location = new System.Drawing.Point(8, 8);
			this.m_tcRelatorios.Name = "m_tcRelatorios";
			this.m_tcRelatorios.SelectedIndex = 0;
			this.m_tcRelatorios.Size = new System.Drawing.Size(376, 352);
			this.m_tcRelatorios.TabIndex = 0;
			// 
			// m_tpFaturasComerciais
			// 
			this.m_tpFaturasComerciais.Controls.Add(this.m_gbProdutos);
			this.m_tpFaturasComerciais.Controls.Add(this.m_gbFaturasComerciaisPrecisao);
			this.m_tpFaturasComerciais.Location = new System.Drawing.Point(4, 23);
			this.m_tpFaturasComerciais.Name = "m_tpFaturasComerciais";
			this.m_tpFaturasComerciais.Size = new System.Drawing.Size(368, 325);
			this.m_tpFaturasComerciais.TabIndex = 1;
			this.m_tpFaturasComerciais.Text = "Faturas Comerciais";
			// 
			// m_gbProdutos
			// 
			this.m_gbProdutos.Controls.Add(this.m_ckCanEditProducts);
			this.m_gbProdutos.Location = new System.Drawing.Point(8, 161);
			this.m_gbProdutos.Name = "m_gbProdutos";
			this.m_gbProdutos.Size = new System.Drawing.Size(298, 47);
			this.m_gbProdutos.TabIndex = 3;
			this.m_gbProdutos.TabStop = false;
			this.m_gbProdutos.Text = "Lançamento de Produtos";
			// 
			// m_ckCanEditProducts
			// 
			this.m_ckCanEditProducts.Location = new System.Drawing.Point(6, 14);
			this.m_ckCanEditProducts.Name = "m_ckCanEditProducts";
			this.m_ckCanEditProducts.Size = new System.Drawing.Size(288, 24);
			this.m_ckCanEditProducts.TabIndex = 0;
			this.m_ckCanEditProducts.Text = "Permitir editar código e descrição dos produtos. ";
			// 
			// m_gbFaturasComerciaisPrecisao
			// 
			this.m_gbFaturasComerciaisPrecisao.Controls.Add(this.m_gbFaturaComercialPrecisaoPesoBruto);
			this.m_gbFaturasComerciaisPrecisao.Controls.Add(this.m_gbFaturasComerciaisPrecisaoPesoLiquido);
			this.m_gbFaturasComerciaisPrecisao.Location = new System.Drawing.Point(8, 8);
			this.m_gbFaturasComerciaisPrecisao.Name = "m_gbFaturasComerciaisPrecisao";
			this.m_gbFaturasComerciaisPrecisao.Size = new System.Drawing.Size(298, 152);
			this.m_gbFaturasComerciaisPrecisao.TabIndex = 2;
			this.m_gbFaturasComerciaisPrecisao.TabStop = false;
			this.m_gbFaturasComerciaisPrecisao.Text = "Visualização de casas decimais";
			// 
			// m_gbFaturaComercialPrecisaoPesoBruto
			// 
			this.m_gbFaturaComercialPrecisaoPesoBruto.Controls.Add(this.m_ckFaturaComercialPrecisaoPesoBrutoTotalArredondar);
			this.m_gbFaturaComercialPrecisaoPesoBruto.Controls.Add(this.m_txtFaturaComercialPrecisaoPesoBrutoTotal);
			this.m_gbFaturaComercialPrecisaoPesoBruto.Controls.Add(this.m_lbFaturaComercialPrecisaoPesoBrutoTotal);
			this.m_gbFaturaComercialPrecisaoPesoBruto.Controls.Add(this.m_tbFaturaComercialPrecisaoPesoBrutoTotal);
			this.m_gbFaturaComercialPrecisaoPesoBruto.Location = new System.Drawing.Point(9, 80);
			this.m_gbFaturaComercialPrecisaoPesoBruto.Name = "m_gbFaturaComercialPrecisaoPesoBruto";
			this.m_gbFaturaComercialPrecisaoPesoBruto.Size = new System.Drawing.Size(279, 64);
			this.m_gbFaturaComercialPrecisaoPesoBruto.TabIndex = 1;
			this.m_gbFaturaComercialPrecisaoPesoBruto.TabStop = false;
			this.m_gbFaturaComercialPrecisaoPesoBruto.Text = "Peso Bruto";
			// 
			// m_ckFaturaComercialPrecisaoPesoBrutoTotalArredondar
			// 
			this.m_ckFaturaComercialPrecisaoPesoBrutoTotalArredondar.Checked = true;
			this.m_ckFaturaComercialPrecisaoPesoBrutoTotalArredondar.CheckState = System.Windows.Forms.CheckState.Checked;
			this.m_ckFaturaComercialPrecisaoPesoBrutoTotalArredondar.Location = new System.Drawing.Point(183, 16);
			this.m_ckFaturaComercialPrecisaoPesoBrutoTotalArredondar.Name = "m_ckFaturaComercialPrecisaoPesoBrutoTotalArredondar";
			this.m_ckFaturaComercialPrecisaoPesoBrutoTotalArredondar.Size = new System.Drawing.Size(88, 16);
			this.m_ckFaturaComercialPrecisaoPesoBrutoTotalArredondar.TabIndex = 8;
			this.m_ckFaturaComercialPrecisaoPesoBrutoTotalArredondar.Text = "Arredondar";
			this.m_ckFaturaComercialPrecisaoPesoBrutoTotalArredondar.CheckedChanged += new System.EventHandler(this.m_ckFaturaComercialPrecisaoPesoBrutoTotalArredondar_CheckedChanged);
			// 
			// m_txtFaturaComercialPrecisaoPesoBrutoTotal
			// 
			this.m_txtFaturaComercialPrecisaoPesoBrutoTotal.Location = new System.Drawing.Point(53, 24);
			this.m_txtFaturaComercialPrecisaoPesoBrutoTotal.Name = "m_txtFaturaComercialPrecisaoPesoBrutoTotal";
			this.m_txtFaturaComercialPrecisaoPesoBrutoTotal.ReadOnly = true;
			this.m_txtFaturaComercialPrecisaoPesoBrutoTotal.Size = new System.Drawing.Size(16, 20);
			this.m_txtFaturaComercialPrecisaoPesoBrutoTotal.TabIndex = 6;
			this.m_txtFaturaComercialPrecisaoPesoBrutoTotal.Text = "2";
			// 
			// m_lbFaturaComercialPrecisaoPesoBrutoTotal
			// 
			this.m_lbFaturaComercialPrecisaoPesoBrutoTotal.Location = new System.Drawing.Point(8, 24);
			this.m_lbFaturaComercialPrecisaoPesoBrutoTotal.Name = "m_lbFaturaComercialPrecisaoPesoBrutoTotal";
			this.m_lbFaturaComercialPrecisaoPesoBrutoTotal.Size = new System.Drawing.Size(38, 16);
			this.m_lbFaturaComercialPrecisaoPesoBrutoTotal.TabIndex = 2;
			this.m_lbFaturaComercialPrecisaoPesoBrutoTotal.Text = "Total:";
			// 
			// m_tbFaturaComercialPrecisaoPesoBrutoTotal
			// 
			this.m_tbFaturaComercialPrecisaoPesoBrutoTotal.Location = new System.Drawing.Point(77, 16);
			this.m_tbFaturaComercialPrecisaoPesoBrutoTotal.Maximum = 8;
			this.m_tbFaturaComercialPrecisaoPesoBrutoTotal.Name = "m_tbFaturaComercialPrecisaoPesoBrutoTotal";
			this.m_tbFaturaComercialPrecisaoPesoBrutoTotal.Size = new System.Drawing.Size(100, 45);
			this.m_tbFaturaComercialPrecisaoPesoBrutoTotal.TabIndex = 1;
			this.m_tbFaturaComercialPrecisaoPesoBrutoTotal.Value = 2;
			this.m_tbFaturaComercialPrecisaoPesoBrutoTotal.ValueChanged += new System.EventHandler(this.m_tbFaturaComercialPrecisaoPesoBrutoTotal_ValueChanged);
			// 
			// m_gbFaturasComerciaisPrecisaoPesoLiquido
			// 
			this.m_gbFaturasComerciaisPrecisaoPesoLiquido.Controls.Add(this.m_ckFaturaComercialPrecisaoPesoLiquidoTotalArredondar);
			this.m_gbFaturasComerciaisPrecisaoPesoLiquido.Controls.Add(this.m_txtFaturaComercialPrecisaoPesoLiquidoTotal);
			this.m_gbFaturasComerciaisPrecisaoPesoLiquido.Controls.Add(this.m_lbFaturaComercialPrecisaoPesoLiquidoTotal);
			this.m_gbFaturasComerciaisPrecisaoPesoLiquido.Controls.Add(this.m_tbFaturaComercialPrecisaoPesoLiquidoTotal);
			this.m_gbFaturasComerciaisPrecisaoPesoLiquido.Location = new System.Drawing.Point(8, 16);
			this.m_gbFaturasComerciaisPrecisaoPesoLiquido.Name = "m_gbFaturasComerciaisPrecisaoPesoLiquido";
			this.m_gbFaturasComerciaisPrecisaoPesoLiquido.Size = new System.Drawing.Size(280, 64);
			this.m_gbFaturasComerciaisPrecisaoPesoLiquido.TabIndex = 0;
			this.m_gbFaturasComerciaisPrecisaoPesoLiquido.TabStop = false;
			this.m_gbFaturasComerciaisPrecisaoPesoLiquido.Text = "Peso Líquido";
			// 
			// m_ckFaturaComercialPrecisaoPesoLiquidoTotalArredondar
			// 
			this.m_ckFaturaComercialPrecisaoPesoLiquidoTotalArredondar.Checked = true;
			this.m_ckFaturaComercialPrecisaoPesoLiquidoTotalArredondar.CheckState = System.Windows.Forms.CheckState.Checked;
			this.m_ckFaturaComercialPrecisaoPesoLiquidoTotalArredondar.Location = new System.Drawing.Point(183, 24);
			this.m_ckFaturaComercialPrecisaoPesoLiquidoTotalArredondar.Name = "m_ckFaturaComercialPrecisaoPesoLiquidoTotalArredondar";
			this.m_ckFaturaComercialPrecisaoPesoLiquidoTotalArredondar.Size = new System.Drawing.Size(88, 16);
			this.m_ckFaturaComercialPrecisaoPesoLiquidoTotalArredondar.TabIndex = 5;
			this.m_ckFaturaComercialPrecisaoPesoLiquidoTotalArredondar.Text = "Arredondar";
			this.m_ckFaturaComercialPrecisaoPesoLiquidoTotalArredondar.CheckedChanged += new System.EventHandler(this.m_ckFaturaComercialPrecisaoPesoLiquidoTotalArredondar_CheckedChanged);
			// 
			// m_txtFaturaComercialPrecisaoPesoLiquidoTotal
			// 
			this.m_txtFaturaComercialPrecisaoPesoLiquidoTotal.Location = new System.Drawing.Point(54, 24);
			this.m_txtFaturaComercialPrecisaoPesoLiquidoTotal.Name = "m_txtFaturaComercialPrecisaoPesoLiquidoTotal";
			this.m_txtFaturaComercialPrecisaoPesoLiquidoTotal.ReadOnly = true;
			this.m_txtFaturaComercialPrecisaoPesoLiquidoTotal.Size = new System.Drawing.Size(16, 20);
			this.m_txtFaturaComercialPrecisaoPesoLiquidoTotal.TabIndex = 4;
			this.m_txtFaturaComercialPrecisaoPesoLiquidoTotal.Text = "2";
			// 
			// m_lbFaturaComercialPrecisaoPesoLiquidoTotal
			// 
			this.m_lbFaturaComercialPrecisaoPesoLiquidoTotal.Location = new System.Drawing.Point(8, 24);
			this.m_lbFaturaComercialPrecisaoPesoLiquidoTotal.Name = "m_lbFaturaComercialPrecisaoPesoLiquidoTotal";
			this.m_lbFaturaComercialPrecisaoPesoLiquidoTotal.Size = new System.Drawing.Size(38, 16);
			this.m_lbFaturaComercialPrecisaoPesoLiquidoTotal.TabIndex = 2;
			this.m_lbFaturaComercialPrecisaoPesoLiquidoTotal.Text = "Total:";
			// 
			// m_tbFaturaComercialPrecisaoPesoLiquidoTotal
			// 
			this.m_tbFaturaComercialPrecisaoPesoLiquidoTotal.Location = new System.Drawing.Point(78, 16);
			this.m_tbFaturaComercialPrecisaoPesoLiquidoTotal.Maximum = 8;
			this.m_tbFaturaComercialPrecisaoPesoLiquidoTotal.Name = "m_tbFaturaComercialPrecisaoPesoLiquidoTotal";
			this.m_tbFaturaComercialPrecisaoPesoLiquidoTotal.Size = new System.Drawing.Size(100, 45);
			this.m_tbFaturaComercialPrecisaoPesoLiquidoTotal.TabIndex = 1;
			this.m_tbFaturaComercialPrecisaoPesoLiquidoTotal.Value = 2;
			this.m_tbFaturaComercialPrecisaoPesoLiquidoTotal.ValueChanged += new System.EventHandler(this.m_tbFaturaComercialPrecisaoPesoLiquidoTotal_ValueChanged);
			// 
			// m_tpRomaneio
			// 
			this.m_tpRomaneio.Controls.Add(this.m_gbRomaneiosPrecisao);
			this.m_tpRomaneio.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_tpRomaneio.Location = new System.Drawing.Point(4, 23);
			this.m_tpRomaneio.Name = "m_tpRomaneio";
			this.m_tpRomaneio.Size = new System.Drawing.Size(368, 325);
			this.m_tpRomaneio.TabIndex = 0;
			this.m_tpRomaneio.Text = "Romaneios";
			// 
			// m_gbRomaneiosPrecisao
			// 
			this.m_gbRomaneiosPrecisao.Controls.Add(this.m_gbRomaneioPrecisaoPesoBruto);
			this.m_gbRomaneiosPrecisao.Controls.Add(this.m_gbRomaneioPrecisaoPesoLiquido);
			this.m_gbRomaneiosPrecisao.Location = new System.Drawing.Point(8, 8);
			this.m_gbRomaneiosPrecisao.Name = "m_gbRomaneiosPrecisao";
			this.m_gbRomaneiosPrecisao.Size = new System.Drawing.Size(298, 232);
			this.m_gbRomaneiosPrecisao.TabIndex = 1;
			this.m_gbRomaneiosPrecisao.TabStop = false;
			this.m_gbRomaneiosPrecisao.Text = "Visualização de casas decimais";
			// 
			// m_gbRomaneioPrecisaoPesoBruto
			// 
			this.m_gbRomaneioPrecisaoPesoBruto.Controls.Add(this.m_ckRomaneioPrecisaoPesoBrutoTotalArredondar);
			this.m_gbRomaneioPrecisaoPesoBruto.Controls.Add(this.m_ckRomaneioPrecisaoPesoBrutoItemArredondar);
			this.m_gbRomaneioPrecisaoPesoBruto.Controls.Add(this.m_txtRomaneioPrecisaoPesoBrutoTotal);
			this.m_gbRomaneioPrecisaoPesoBruto.Controls.Add(this.m_lbRomaneioPrecisaoPesoBrutoTotal);
			this.m_gbRomaneioPrecisaoPesoBruto.Controls.Add(this.m_lbPrecisaoPesoBrutoItens);
			this.m_gbRomaneioPrecisaoPesoBruto.Controls.Add(this.m_tbPrecisaoPesoBrutoItens);
			this.m_gbRomaneioPrecisaoPesoBruto.Controls.Add(this.m_tbRomaneioPrecisaoPesoBrutoTotal);
			this.m_gbRomaneioPrecisaoPesoBruto.Controls.Add(this.m_txtPrecisaoPesoBrutoItens);
			this.m_gbRomaneioPrecisaoPesoBruto.Location = new System.Drawing.Point(9, 120);
			this.m_gbRomaneioPrecisaoPesoBruto.Name = "m_gbRomaneioPrecisaoPesoBruto";
			this.m_gbRomaneioPrecisaoPesoBruto.Size = new System.Drawing.Size(279, 104);
			this.m_gbRomaneioPrecisaoPesoBruto.TabIndex = 1;
			this.m_gbRomaneioPrecisaoPesoBruto.TabStop = false;
			this.m_gbRomaneioPrecisaoPesoBruto.Text = "Peso Bruto";
			// 
			// m_ckRomaneioPrecisaoPesoBrutoTotalArredondar
			// 
			this.m_ckRomaneioPrecisaoPesoBrutoTotalArredondar.Checked = true;
			this.m_ckRomaneioPrecisaoPesoBrutoTotalArredondar.CheckState = System.Windows.Forms.CheckState.Checked;
			this.m_ckRomaneioPrecisaoPesoBrutoTotalArredondar.Location = new System.Drawing.Point(183, 60);
			this.m_ckRomaneioPrecisaoPesoBrutoTotalArredondar.Name = "m_ckRomaneioPrecisaoPesoBrutoTotalArredondar";
			this.m_ckRomaneioPrecisaoPesoBrutoTotalArredondar.Size = new System.Drawing.Size(88, 16);
			this.m_ckRomaneioPrecisaoPesoBrutoTotalArredondar.TabIndex = 8;
			this.m_ckRomaneioPrecisaoPesoBrutoTotalArredondar.Text = "Arredondar";
			this.m_ckRomaneioPrecisaoPesoBrutoTotalArredondar.CheckedChanged += new System.EventHandler(this.m_ckRomaneioPrecisaoPesoBrutoTotalArredondar_CheckedChanged);
			// 
			// m_ckRomaneioPrecisaoPesoBrutoItemArredondar
			// 
			this.m_ckRomaneioPrecisaoPesoBrutoItemArredondar.Checked = true;
			this.m_ckRomaneioPrecisaoPesoBrutoItemArredondar.CheckState = System.Windows.Forms.CheckState.Checked;
			this.m_ckRomaneioPrecisaoPesoBrutoItemArredondar.Location = new System.Drawing.Point(182, 15);
			this.m_ckRomaneioPrecisaoPesoBrutoItemArredondar.Name = "m_ckRomaneioPrecisaoPesoBrutoItemArredondar";
			this.m_ckRomaneioPrecisaoPesoBrutoItemArredondar.Size = new System.Drawing.Size(88, 16);
			this.m_ckRomaneioPrecisaoPesoBrutoItemArredondar.TabIndex = 7;
			this.m_ckRomaneioPrecisaoPesoBrutoItemArredondar.Text = "Arredondar";
			// 
			// m_txtRomaneioPrecisaoPesoBrutoTotal
			// 
			this.m_txtRomaneioPrecisaoPesoBrutoTotal.Location = new System.Drawing.Point(53, 62);
			this.m_txtRomaneioPrecisaoPesoBrutoTotal.Name = "m_txtRomaneioPrecisaoPesoBrutoTotal";
			this.m_txtRomaneioPrecisaoPesoBrutoTotal.ReadOnly = true;
			this.m_txtRomaneioPrecisaoPesoBrutoTotal.Size = new System.Drawing.Size(16, 20);
			this.m_txtRomaneioPrecisaoPesoBrutoTotal.TabIndex = 6;
			this.m_txtRomaneioPrecisaoPesoBrutoTotal.Text = "2";
			// 
			// m_lbRomaneioPrecisaoPesoBrutoTotal
			// 
			this.m_lbRomaneioPrecisaoPesoBrutoTotal.Location = new System.Drawing.Point(8, 65);
			this.m_lbRomaneioPrecisaoPesoBrutoTotal.Name = "m_lbRomaneioPrecisaoPesoBrutoTotal";
			this.m_lbRomaneioPrecisaoPesoBrutoTotal.Size = new System.Drawing.Size(38, 16);
			this.m_lbRomaneioPrecisaoPesoBrutoTotal.TabIndex = 2;
			this.m_lbRomaneioPrecisaoPesoBrutoTotal.Text = "Total:";
			// 
			// m_lbPrecisaoPesoBrutoItens
			// 
			this.m_lbPrecisaoPesoBrutoItens.Location = new System.Drawing.Point(8, 20);
			this.m_lbPrecisaoPesoBrutoItens.Name = "m_lbPrecisaoPesoBrutoItens";
			this.m_lbPrecisaoPesoBrutoItens.Size = new System.Drawing.Size(40, 16);
			this.m_lbPrecisaoPesoBrutoItens.TabIndex = 0;
			this.m_lbPrecisaoPesoBrutoItens.Text = "Itens:";
			// 
			// m_tbPrecisaoPesoBrutoItens
			// 
			this.m_tbPrecisaoPesoBrutoItens.Location = new System.Drawing.Point(77, 11);
			this.m_tbPrecisaoPesoBrutoItens.Maximum = 8;
			this.m_tbPrecisaoPesoBrutoItens.Name = "m_tbPrecisaoPesoBrutoItens";
			this.m_tbPrecisaoPesoBrutoItens.Size = new System.Drawing.Size(100, 45);
			this.m_tbPrecisaoPesoBrutoItens.TabIndex = 0;
			this.m_tbPrecisaoPesoBrutoItens.Value = 2;
			this.m_tbPrecisaoPesoBrutoItens.ValueChanged += new System.EventHandler(this.m_tbPrecisaoPesoBrutoItens_ValueChanged);
			// 
			// m_tbRomaneioPrecisaoPesoBrutoTotal
			// 
			this.m_tbRomaneioPrecisaoPesoBrutoTotal.Location = new System.Drawing.Point(77, 57);
			this.m_tbRomaneioPrecisaoPesoBrutoTotal.Maximum = 8;
			this.m_tbRomaneioPrecisaoPesoBrutoTotal.Name = "m_tbRomaneioPrecisaoPesoBrutoTotal";
			this.m_tbRomaneioPrecisaoPesoBrutoTotal.Size = new System.Drawing.Size(100, 45);
			this.m_tbRomaneioPrecisaoPesoBrutoTotal.TabIndex = 1;
			this.m_tbRomaneioPrecisaoPesoBrutoTotal.Value = 2;
			this.m_tbRomaneioPrecisaoPesoBrutoTotal.ValueChanged += new System.EventHandler(this.m_tbPrecisaoPesoBrutoTotal_ValueChanged);
			// 
			// m_txtPrecisaoPesoBrutoItens
			// 
			this.m_txtPrecisaoPesoBrutoItens.Location = new System.Drawing.Point(53, 17);
			this.m_txtPrecisaoPesoBrutoItens.Name = "m_txtPrecisaoPesoBrutoItens";
			this.m_txtPrecisaoPesoBrutoItens.ReadOnly = true;
			this.m_txtPrecisaoPesoBrutoItens.Size = new System.Drawing.Size(16, 20);
			this.m_txtPrecisaoPesoBrutoItens.TabIndex = 5;
			this.m_txtPrecisaoPesoBrutoItens.Text = "2";
			// 
			// m_gbRomaneioPrecisaoPesoLiquido
			// 
			this.m_gbRomaneioPrecisaoPesoLiquido.Controls.Add(this.m_ckRomaneioPrecisaoPesoLiquidoTotalArredondar);
			this.m_gbRomaneioPrecisaoPesoLiquido.Controls.Add(this.m_txtRomaneioPrecisaoPesoLiquidoTotal);
			this.m_gbRomaneioPrecisaoPesoLiquido.Controls.Add(this.m_txtPrecisaoPesoLiquidoItens);
			this.m_gbRomaneioPrecisaoPesoLiquido.Controls.Add(this.m_lbRomaneioPrecisaoPesoLiquidoTotal);
			this.m_gbRomaneioPrecisaoPesoLiquido.Controls.Add(this.m_lbRomaneioPrecisaoPesoLiquidoItens);
			this.m_gbRomaneioPrecisaoPesoLiquido.Controls.Add(this.m_tbPrecisaoPesoLiquidoItens);
			this.m_gbRomaneioPrecisaoPesoLiquido.Controls.Add(this.m_tbRomaneioPrecisaoPesoLiquidoTotal);
			this.m_gbRomaneioPrecisaoPesoLiquido.Controls.Add(this.m_ckRomaneioPrecisaoPesoLiquidoItemArredondar);
			this.m_gbRomaneioPrecisaoPesoLiquido.Location = new System.Drawing.Point(8, 16);
			this.m_gbRomaneioPrecisaoPesoLiquido.Name = "m_gbRomaneioPrecisaoPesoLiquido";
			this.m_gbRomaneioPrecisaoPesoLiquido.Size = new System.Drawing.Size(280, 104);
			this.m_gbRomaneioPrecisaoPesoLiquido.TabIndex = 0;
			this.m_gbRomaneioPrecisaoPesoLiquido.TabStop = false;
			this.m_gbRomaneioPrecisaoPesoLiquido.Text = "Peso Líquido";
			// 
			// m_ckRomaneioPrecisaoPesoLiquidoTotalArredondar
			// 
			this.m_ckRomaneioPrecisaoPesoLiquidoTotalArredondar.Checked = true;
			this.m_ckRomaneioPrecisaoPesoLiquidoTotalArredondar.CheckState = System.Windows.Forms.CheckState.Checked;
			this.m_ckRomaneioPrecisaoPesoLiquidoTotalArredondar.Location = new System.Drawing.Point(183, 62);
			this.m_ckRomaneioPrecisaoPesoLiquidoTotalArredondar.Name = "m_ckRomaneioPrecisaoPesoLiquidoTotalArredondar";
			this.m_ckRomaneioPrecisaoPesoLiquidoTotalArredondar.Size = new System.Drawing.Size(88, 16);
			this.m_ckRomaneioPrecisaoPesoLiquidoTotalArredondar.TabIndex = 5;
			this.m_ckRomaneioPrecisaoPesoLiquidoTotalArredondar.Text = "Arredondar";
			this.m_ckRomaneioPrecisaoPesoLiquidoTotalArredondar.CheckedChanged += new System.EventHandler(this.m_ckRomaneioPrecisaoPesoLiquidoTotalArredondar_CheckedChanged);
			// 
			// m_txtRomaneioPrecisaoPesoLiquidoTotal
			// 
			this.m_txtRomaneioPrecisaoPesoLiquidoTotal.Location = new System.Drawing.Point(54, 64);
			this.m_txtRomaneioPrecisaoPesoLiquidoTotal.Name = "m_txtRomaneioPrecisaoPesoLiquidoTotal";
			this.m_txtRomaneioPrecisaoPesoLiquidoTotal.ReadOnly = true;
			this.m_txtRomaneioPrecisaoPesoLiquidoTotal.Size = new System.Drawing.Size(16, 20);
			this.m_txtRomaneioPrecisaoPesoLiquidoTotal.TabIndex = 4;
			this.m_txtRomaneioPrecisaoPesoLiquidoTotal.Text = "2";
			// 
			// m_txtPrecisaoPesoLiquidoItens
			// 
			this.m_txtPrecisaoPesoLiquidoItens.Location = new System.Drawing.Point(54, 18);
			this.m_txtPrecisaoPesoLiquidoItens.Name = "m_txtPrecisaoPesoLiquidoItens";
			this.m_txtPrecisaoPesoLiquidoItens.ReadOnly = true;
			this.m_txtPrecisaoPesoLiquidoItens.Size = new System.Drawing.Size(16, 20);
			this.m_txtPrecisaoPesoLiquidoItens.TabIndex = 3;
			this.m_txtPrecisaoPesoLiquidoItens.Text = "2";
			// 
			// m_lbRomaneioPrecisaoPesoLiquidoTotal
			// 
			this.m_lbRomaneioPrecisaoPesoLiquidoTotal.Location = new System.Drawing.Point(8, 65);
			this.m_lbRomaneioPrecisaoPesoLiquidoTotal.Name = "m_lbRomaneioPrecisaoPesoLiquidoTotal";
			this.m_lbRomaneioPrecisaoPesoLiquidoTotal.Size = new System.Drawing.Size(38, 16);
			this.m_lbRomaneioPrecisaoPesoLiquidoTotal.TabIndex = 2;
			this.m_lbRomaneioPrecisaoPesoLiquidoTotal.Text = "Total:";
			// 
			// m_lbRomaneioPrecisaoPesoLiquidoItens
			// 
			this.m_lbRomaneioPrecisaoPesoLiquidoItens.Location = new System.Drawing.Point(8, 20);
			this.m_lbRomaneioPrecisaoPesoLiquidoItens.Name = "m_lbRomaneioPrecisaoPesoLiquidoItens";
			this.m_lbRomaneioPrecisaoPesoLiquidoItens.Size = new System.Drawing.Size(40, 16);
			this.m_lbRomaneioPrecisaoPesoLiquidoItens.TabIndex = 0;
			this.m_lbRomaneioPrecisaoPesoLiquidoItens.Text = "Itens:";
			// 
			// m_tbPrecisaoPesoLiquidoItens
			// 
			this.m_tbPrecisaoPesoLiquidoItens.Location = new System.Drawing.Point(78, 12);
			this.m_tbPrecisaoPesoLiquidoItens.Maximum = 8;
			this.m_tbPrecisaoPesoLiquidoItens.Name = "m_tbPrecisaoPesoLiquidoItens";
			this.m_tbPrecisaoPesoLiquidoItens.Size = new System.Drawing.Size(100, 45);
			this.m_tbPrecisaoPesoLiquidoItens.TabIndex = 0;
			this.m_tbPrecisaoPesoLiquidoItens.Value = 2;
			this.m_tbPrecisaoPesoLiquidoItens.ValueChanged += new System.EventHandler(this.m_tbPrecisaoPesoLiquidoItens_ValueChanged);
			// 
			// m_tbRomaneioPrecisaoPesoLiquidoTotal
			// 
			this.m_tbRomaneioPrecisaoPesoLiquidoTotal.Location = new System.Drawing.Point(78, 56);
			this.m_tbRomaneioPrecisaoPesoLiquidoTotal.Maximum = 8;
			this.m_tbRomaneioPrecisaoPesoLiquidoTotal.Name = "m_tbRomaneioPrecisaoPesoLiquidoTotal";
			this.m_tbRomaneioPrecisaoPesoLiquidoTotal.Size = new System.Drawing.Size(100, 45);
			this.m_tbRomaneioPrecisaoPesoLiquidoTotal.TabIndex = 1;
			this.m_tbRomaneioPrecisaoPesoLiquidoTotal.Value = 2;
			this.m_tbRomaneioPrecisaoPesoLiquidoTotal.ValueChanged += new System.EventHandler(this.m_tbPrecisaoPesoLiquidoTotal_ValueChanged);
			// 
			// m_ckRomaneioPrecisaoPesoLiquidoItemArredondar
			// 
			this.m_ckRomaneioPrecisaoPesoLiquidoItemArredondar.Checked = true;
			this.m_ckRomaneioPrecisaoPesoLiquidoItemArredondar.CheckState = System.Windows.Forms.CheckState.Checked;
			this.m_ckRomaneioPrecisaoPesoLiquidoItemArredondar.Location = new System.Drawing.Point(184, 16);
			this.m_ckRomaneioPrecisaoPesoLiquidoItemArredondar.Name = "m_ckRomaneioPrecisaoPesoLiquidoItemArredondar";
			this.m_ckRomaneioPrecisaoPesoLiquidoItemArredondar.Size = new System.Drawing.Size(88, 16);
			this.m_ckRomaneioPrecisaoPesoLiquidoItemArredondar.TabIndex = 2;
			this.m_ckRomaneioPrecisaoPesoLiquidoItemArredondar.Text = "Arredondar";
			// 
			// usrCtrlRelatorios
			// 
			this.Controls.Add(this.m_tcRelatorios);
			this.Name = "usrCtrlRelatorios";
			this.Size = new System.Drawing.Size(394, 368);
			this.Load += new System.EventHandler(this.usrCtrlRelatorios_Load);
			this.m_tcRelatorios.ResumeLayout(false);
			this.m_tpFaturasComerciais.ResumeLayout(false);
			this.m_gbProdutos.ResumeLayout(false);
			this.m_gbFaturasComerciaisPrecisao.ResumeLayout(false);
			this.m_gbFaturaComercialPrecisaoPesoBruto.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.m_tbFaturaComercialPrecisaoPesoBrutoTotal)).EndInit();
			this.m_gbFaturasComerciaisPrecisaoPesoLiquido.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.m_tbFaturaComercialPrecisaoPesoLiquidoTotal)).EndInit();
			this.m_tpRomaneio.ResumeLayout(false);
			this.m_gbRomaneiosPrecisao.ResumeLayout(false);
			this.m_gbRomaneioPrecisaoPesoBruto.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.m_tbPrecisaoPesoBrutoItens)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.m_tbRomaneioPrecisaoPesoBrutoTotal)).EndInit();
			this.m_gbRomaneioPrecisaoPesoLiquido.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.m_tbPrecisaoPesoLiquidoItens)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.m_tbRomaneioPrecisaoPesoLiquidoTotal)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		#region Eventos
			#region Formulario
				private void usrCtrlRelatorios_Load(object sender, System.EventArgs e)
				{
					OnCallCarregaDadosInterface();
				}
			#endregion
			#region TrackBars	
				private void m_tbPrecisaoPesoLiquidoItens_ValueChanged(object sender, System.EventArgs e)
				{
                    m_txtPrecisaoPesoLiquidoItens.Text = m_tbPrecisaoPesoLiquidoItens.Value.ToString();
				}

				private void m_tbPrecisaoPesoLiquidoTotal_ValueChanged(object sender, System.EventArgs e)
				{
					m_txtRomaneioPrecisaoPesoLiquidoTotal.Text = m_tbRomaneioPrecisaoPesoLiquidoTotal.Value.ToString();
				}

				private void m_tbFaturaComercialPrecisaoPesoLiquidoTotal_ValueChanged(object sender, System.EventArgs e)
				{
					m_txtFaturaComercialPrecisaoPesoLiquidoTotal.Text = m_tbFaturaComercialPrecisaoPesoLiquidoTotal.Value.ToString();
				}

				private void m_tbPrecisaoPesoBrutoItens_ValueChanged(object sender, System.EventArgs e)
				{
					m_txtPrecisaoPesoBrutoItens.Text = m_tbPrecisaoPesoBrutoItens.Value.ToString();
				}

				private void m_tbPrecisaoPesoBrutoTotal_ValueChanged(object sender, System.EventArgs e)
				{
						m_txtRomaneioPrecisaoPesoBrutoTotal.Text = m_tbRomaneioPrecisaoPesoBrutoTotal.Value.ToString();
				}

				private void m_tbFaturaComercialPrecisaoPesoBrutoTotal_ValueChanged(object sender, System.EventArgs e)
				{
						m_txtFaturaComercialPrecisaoPesoBrutoTotal.Text = m_tbFaturaComercialPrecisaoPesoBrutoTotal.Value.ToString();
				}
			#endregion
			#region CheckBoxes
				private void m_ckFaturaComercialPrecisaoPesoLiquidoTotalArredondar_CheckedChanged(object sender, System.EventArgs e)
				{
					if (m_bAtivado)
					{
						m_bAtivado = false;
						m_ckRomaneioPrecisaoPesoLiquidoTotalArredondar.Checked = m_ckFaturaComercialPrecisaoPesoLiquidoTotalArredondar.Checked;
						m_bAtivado = true;
					}
				}

				private void m_ckFaturaComercialPrecisaoPesoBrutoTotalArredondar_CheckedChanged(object sender, System.EventArgs e)
				{				
					if (m_bAtivado)
					{
						m_bAtivado = false;
						m_ckRomaneioPrecisaoPesoBrutoTotalArredondar.Checked = m_ckFaturaComercialPrecisaoPesoBrutoTotalArredondar.Checked;
						m_bAtivado = true;
					}
				}

				private void m_ckRomaneioPrecisaoPesoLiquidoTotalArredondar_CheckedChanged(object sender, System.EventArgs e)
				{				
					if (m_bAtivado)
					{
						m_bAtivado = false;
						m_ckFaturaComercialPrecisaoPesoLiquidoTotalArredondar.Checked = m_ckRomaneioPrecisaoPesoLiquidoTotalArredondar.Checked;
						m_bAtivado = true;
					}
				}

				private void m_ckRomaneioPrecisaoPesoBrutoTotalArredondar_CheckedChanged(object sender, System.EventArgs e)
				{				
					if (m_bAtivado)
					{
						m_bAtivado = false;
						m_ckFaturaComercialPrecisaoPesoBrutoTotalArredondar.Checked = m_ckRomaneioPrecisaoPesoBrutoTotalArredondar.Checked;
						m_bAtivado = true;
					}
				}
			#endregion
		#endregion
	}
}
