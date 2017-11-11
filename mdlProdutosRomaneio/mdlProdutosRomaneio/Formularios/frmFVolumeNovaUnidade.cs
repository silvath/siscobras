using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace mdlProdutosRomaneio
{
	/// <summary>
	/// Summary description for frmFVolumeNovaUnidade.
	/// </summary>
	internal class frmFVolumeNovaUnidade : System.Windows.Forms.Form
	{
		#region Constants
			private const string TEXTO_NUMEROVOLUME = "Volumes";
			private const string TEXTO_UNIDADEMETRICA = "Unidade";
		#endregion
		#region Atributes
			private mdlTratamentoErro.clsTratamentoErro m_cls_ter_tratadorErro; 
			private string m_strEnderecoExecutavel;

			public bool m_bModificado = false;

			System.Collections.ArrayList m_arlVolumes;
			System.Collections.ArrayList m_arlUnidades;
			string m_strUnidade;
			string m_strUnidadeMetrica;

			internal System.Windows.Forms.GroupBox m_gbGeral;
			internal System.Windows.Forms.Button m_btOk;
			internal System.Windows.Forms.Button m_btCancelar;
			private System.Windows.Forms.DataGrid m_dgUnidade;
			private System.Windows.Forms.GroupBox m_gbUnidade;
			private System.Windows.Forms.ToolTip m_ttDica;
			private System.ComponentModel.IContainer components;
		#endregion
		#region Constructors and Destructors
			public frmFVolumeNovaUnidade(ref mdlTratamentoErro.clsTratamentoErro tratadorErro, string strEnderecoExecutavel,System.Collections.ArrayList arlVolumes,string strUnidade,System.Collections.ArrayList arlUnidades,string strUnidadeMetrica)
			{
				m_cls_ter_tratadorErro = tratadorErro;
				m_strEnderecoExecutavel = strEnderecoExecutavel;
				m_arlVolumes = arlVolumes;
				m_strUnidade = strUnidade;
				m_arlUnidades = arlUnidades;
				m_strUnidadeMetrica = strUnidadeMetrica;

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
		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmFVolumeNovaUnidade));
			this.m_gbGeral = new System.Windows.Forms.GroupBox();
			this.m_btOk = new System.Windows.Forms.Button();
			this.m_btCancelar = new System.Windows.Forms.Button();
			this.m_gbUnidade = new System.Windows.Forms.GroupBox();
			this.m_dgUnidade = new System.Windows.Forms.DataGrid();
			this.m_ttDica = new System.Windows.Forms.ToolTip(this.components);
			this.m_gbGeral.SuspendLayout();
			this.m_gbUnidade.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.m_dgUnidade)).BeginInit();
			this.SuspendLayout();
			// 
			// m_gbGeral
			// 
			this.m_gbGeral.Controls.Add(this.m_btOk);
			this.m_gbGeral.Controls.Add(this.m_btCancelar);
			this.m_gbGeral.Controls.Add(this.m_gbUnidade);
			this.m_gbGeral.Location = new System.Drawing.Point(6, 1);
			this.m_gbGeral.Name = "m_gbGeral";
			this.m_gbGeral.Size = new System.Drawing.Size(252, 383);
			this.m_gbGeral.TabIndex = 2;
			this.m_gbGeral.TabStop = false;
			// 
			// m_btOk
			// 
			this.m_btOk.BackColor = System.Drawing.SystemColors.Control;
			this.m_btOk.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btOk.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btOk.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btOk.Image = ((System.Drawing.Image)(resources.GetObject("m_btOk.Image")));
			this.m_btOk.Location = new System.Drawing.Point(66, 349);
			this.m_btOk.Name = "m_btOk";
			this.m_btOk.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btOk.Size = new System.Drawing.Size(57, 25);
			this.m_btOk.TabIndex = 68;
			this.m_ttDica.SetToolTip(this.m_btOk, "Confirmar");
			this.m_btOk.Click += new System.EventHandler(this.m_btOk_Click);
			// 
			// m_btCancelar
			// 
			this.m_btCancelar.BackColor = System.Drawing.SystemColors.Control;
			this.m_btCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_btCancelar.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_btCancelar.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btCancelar.Image = ((System.Drawing.Image)(resources.GetObject("m_btCancelar.Image")));
			this.m_btCancelar.Location = new System.Drawing.Point(130, 349);
			this.m_btCancelar.Name = "m_btCancelar";
			this.m_btCancelar.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.m_btCancelar.Size = new System.Drawing.Size(57, 25);
			this.m_btCancelar.TabIndex = 69;
			this.m_ttDica.SetToolTip(this.m_btCancelar, "Cancelar");
			this.m_btCancelar.Click += new System.EventHandler(this.m_btCancelar_Click);
			// 
			// m_gbUnidade
			// 
			this.m_gbUnidade.Controls.Add(this.m_dgUnidade);
			this.m_gbUnidade.Location = new System.Drawing.Point(5, 10);
			this.m_gbUnidade.Name = "m_gbUnidade";
			this.m_gbUnidade.Size = new System.Drawing.Size(235, 332);
			this.m_gbUnidade.TabIndex = 3;
			this.m_gbUnidade.TabStop = false;
			// 
			// m_dgUnidade
			// 
			this.m_dgUnidade.AllowNavigation = false;
			this.m_dgUnidade.AllowSorting = false;
			this.m_dgUnidade.BackgroundColor = System.Drawing.Color.White;
			this.m_dgUnidade.CaptionBackColor = System.Drawing.Color.Black;
			this.m_dgUnidade.CaptionVisible = false;
			this.m_dgUnidade.CausesValidation = false;
			this.m_dgUnidade.DataMember = "";
			this.m_dgUnidade.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.m_dgUnidade.Location = new System.Drawing.Point(8, 16);
			this.m_dgUnidade.Name = "m_dgUnidade";
			this.m_dgUnidade.ParentRowsVisible = false;
			this.m_dgUnidade.RowHeadersVisible = false;
			this.m_dgUnidade.Size = new System.Drawing.Size(216, 312);
			this.m_dgUnidade.TabIndex = 70;
			// 
			// m_ttDica
			// 
			this.m_ttDica.AutomaticDelay = 100;
			this.m_ttDica.AutoPopDelay = 5000;
			this.m_ttDica.InitialDelay = 100;
			this.m_ttDica.ReshowDelay = 20;
			// 
			// frmFVolumeNovaUnidade
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(266, 392);
			this.Controls.Add(this.m_gbGeral);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "frmFVolumeNovaUnidade";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Altura";
			this.Load += new System.EventHandler(this.frmFEmbalagemNovaUnidade_Load);
			this.m_gbGeral.ResumeLayout(false);
			this.m_gbUnidade.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.m_dgUnidade)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		#region Eventos
			#region Formulario
				private void frmFEmbalagemNovaUnidade_Load(object sender, System.EventArgs e)
				{
					MostraCor();
					CarregaDadosInterface();
				}
        	#endregion
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
		#region Cores Formulario
			private void MostraCor()
			{
				try
				{
					mdlPaletaDeCores.clsPaletaDeCores clsPaletaCores = new mdlPaletaDeCores.clsPaletaDeCores(m_strEnderecoExecutavel + "sisco.ini","SiscobrasCorSecundaria");
					this.BackColor = clsPaletaCores.retornaCorAtual();
					for (int nCont = 0 ;nCont < this.Controls.Count; nCont++)
					{
						this.Controls[nCont].BackColor = this.BackColor;
						for (int nCont2 = 0 ;nCont2 < this.Controls[nCont].Controls.Count; nCont2++)
						{
							if ((this.Controls[nCont].Controls[nCont2].GetType().ToString() != "mdlComponentes.compTextBox") && (this.Controls[nCont].Controls[nCont2].GetType().ToString() != "mdlComponentesGraficos.TreeView"))
								this.Controls[nCont].Controls[nCont2].BackColor = this.BackColor;

							for (int nCont3 = 0 ;nCont3 < this.Controls[nCont].Controls[nCont2].Controls.Count; nCont3++)
							{
								if ((this.Controls[nCont].Controls[nCont2].Controls[nCont3].GetType().ToString() != "mdlComponentes.compTextBox") && (this.Controls[nCont].Controls[nCont2].Controls[nCont3].GetType().ToString() != "mdlComponentesGraficos.TreeView"))
									this.Controls[nCont].Controls[nCont2].Controls[nCont3].BackColor = this.BackColor;
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

		#region Carregamento dos Dados
			#region Carrega Dados Interface
				private void CarregaDadosInterface()
				{
					// DataTable
					System.Data.DataTable dttbMaster = new System.Data.DataTable("Master");  

					// DataGridTableStyle
					System.Windows.Forms.DataGridTableStyle dgtbstlMaster = new System.Windows.Forms.DataGridTableStyle();
					dgtbstlMaster.MappingName = "Master";
					dgtbstlMaster.AllowSorting = false;
					dgtbstlMaster.AlternatingBackColor = this.BackColor;
					dgtbstlMaster.SelectionForeColor = System.Drawing.Color.White;
					dgtbstlMaster.SelectionBackColor = System.Drawing.Color.Black;
					dgtbstlMaster.RowHeadersVisible = false;

					CarregaDadosInterfaceColunas(ref dttbMaster,ref dgtbstlMaster);
					CarregaDadosInterfaceDados(ref dttbMaster);

					// Ajustando o DataGrid
					m_dgUnidade.TableStyles.Clear();
					m_dgUnidade.TableStyles.Add(dgtbstlMaster);
					m_dgUnidade.DataSource = dttbMaster;
					m_dgUnidade.AllowNavigation = true;
					m_dgUnidade.AllowSorting = false;
					m_dgUnidade.ColumnHeadersVisible = true;
				}

				private void CarregaDadosInterfaceColunas(ref System.Data.DataTable dttbMaster,ref System.Windows.Forms.DataGridTableStyle dgtbstlMaster)
				{
					System.Windows.Forms.DataGridTextBoxColumn dtgdcolstlColuna;
					System.Data.DataColumn dtclColuna;

					// Inserindo as Colunas
					// Coluna Unidade Descricao
					// Estilo
					dtgdcolstlColuna = new System.Windows.Forms.DataGridTextBoxColumn();
					dtgdcolstlColuna.HeaderText = TEXTO_NUMEROVOLUME;
					dtgdcolstlColuna.MappingName = TEXTO_NUMEROVOLUME;
					dtgdcolstlColuna.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
					dtgdcolstlColuna.TextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
					dtgdcolstlColuna.ReadOnly = true;
					dtgdcolstlColuna.Width = 60;
					dtgdcolstlColuna.TextBox.Enter += new System.EventHandler(DataGridTextBoxColumn_Enter);
					dgtbstlMaster.GridColumnStyles.Add(dtgdcolstlColuna);
					//Coluna
					dtclColuna = new System.Data.DataColumn(TEXTO_NUMEROVOLUME);
					dtclColuna.DataType = System.Type.GetType("System.String");
					dtclColuna.DefaultValue = "";
					dtclColuna.ReadOnly = true;
					dttbMaster.Columns.Add(dtclColuna);

					// Coluna Unidade Valor
					// Estilo
					dtgdcolstlColuna = new System.Windows.Forms.DataGridTextBoxColumn();
					dtgdcolstlColuna.HeaderText = m_strUnidade;
					dtgdcolstlColuna.MappingName = m_strUnidade;
					dtgdcolstlColuna.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
					dtgdcolstlColuna.TextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
					dtgdcolstlColuna.ReadOnly = false;
					dtgdcolstlColuna.Width = 90;
					dtgdcolstlColuna.TextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(DataGridTextBoxColumn_KeyPress);
					dgtbstlMaster.GridColumnStyles.Add(dtgdcolstlColuna);
					//Coluna
					dtclColuna = new System.Data.DataColumn(m_strUnidade);
					dtclColuna.DataType = System.Type.GetType("System.String");
					dtclColuna.DefaultValue = "";
					dtclColuna.ReadOnly = false;
					dttbMaster.Columns.Add(dtclColuna);

					// Coluna Unidade Metrica
					// Estilo
					dtgdcolstlColuna = new System.Windows.Forms.DataGridTextBoxColumn();
					dtgdcolstlColuna.HeaderText = TEXTO_UNIDADEMETRICA;
					dtgdcolstlColuna.MappingName = TEXTO_UNIDADEMETRICA;
					dtgdcolstlColuna.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
					dtgdcolstlColuna.TextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
					dtgdcolstlColuna.ReadOnly = true;
					dtgdcolstlColuna.Width = 60;
					dtgdcolstlColuna.TextBox.Enter += new System.EventHandler(DataGridTextBoxColumn_Enter);
					dgtbstlMaster.GridColumnStyles.Add(dtgdcolstlColuna);
					//Coluna
					dtclColuna = new System.Data.DataColumn(TEXTO_UNIDADEMETRICA);
					dtclColuna.DataType = System.Type.GetType("System.String");
					dtclColuna.DefaultValue = "";
					dtclColuna.ReadOnly = true;
					dttbMaster.Columns.Add(dtclColuna);

				}

				private void CarregaDadosInterfaceDados(ref System.Data.DataTable dttbMaster)
				{       
					System.Data.DataRow dtrwVolume;
					for(int nCont = 0 ; nCont < m_arlVolumes.Count;nCont++)
					{
						dtrwVolume = dttbMaster.NewRow();
						// Volume
						dtrwVolume[TEXTO_NUMEROVOLUME] = m_arlVolumes[nCont].ToString();
						// Quantidade
						if ((m_arlUnidades != null) && (m_arlUnidades.Count > nCont) && (m_arlUnidades[nCont] != null))
							dtrwVolume[m_strUnidade] = m_arlUnidades[nCont].ToString();

						// Unidade Metrica
						dtrwVolume[TEXTO_UNIDADEMETRICA] = m_strUnidadeMetrica;
						dttbMaster.Rows.Add(dtrwVolume);
					} 
				}
			#endregion
		#endregion
		#region Salvamento dos Dados
		#endregion

		#region DataGridTextBoxColumn
			private void DataGridTextBoxColumn_Enter(Object Sender,System.EventArgs e)
			{
				this.m_dgUnidade.CurrentCell = new System.Windows.Forms.DataGridCell(this.m_dgUnidade.CurrentCell.RowNumber,1);

			}

			private void DataGridTextBoxColumn_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
			{
				System.Windows.Forms.DataGridTextBox gtbcColumn = (System.Windows.Forms.DataGridTextBox)sender;
				bool bPossuiVirgula = (gtbcColumn.Text.IndexOf(",") != -1);
				bool bNovaVirgula = (e.KeyChar == '.') || (e.KeyChar == ',') ;
				if (e.KeyChar != 8)
				{
					if (((48 <= (int)e.KeyChar) && ((int)e.KeyChar <= 57)) || (bNovaVirgula && !bPossuiVirgula))
					{
						if (e.KeyChar == '.')
						{
							int nPos = gtbcColumn.SelectionStart;
							string strTextoAnterior;
							string strTextoPosterior;
							strTextoAnterior = gtbcColumn.Text.Substring(0,nPos);
							strTextoPosterior = gtbcColumn.Text.Substring(nPos);
							gtbcColumn.Text = strTextoAnterior + "," + strTextoPosterior;
							gtbcColumn.SelectionStart = nPos + 1;
							e.Handled = true;
						}
					}
					else
						e.Handled = true;
				}
			}
		#endregion

		#region Retorno
			public void RetornaValores(out System.Collections.ArrayList arlUnidades)
			{
				System.Data.DataTable dttbMaster = (System.Data.DataTable)this.m_dgUnidade.DataSource; 
				arlUnidades = new System.Collections.ArrayList();
				double dValor = 0;
				for (int nCont = 0;nCont < m_arlVolumes.Count;nCont++)
				{
					try
					{
						dValor = double.Parse(dttbMaster.Rows[nCont][m_strUnidade].ToString());
						arlUnidades.Add(dValor.ToString());
					}catch{
						arlUnidades.Add(null);
					}
				}
			}
		#endregion

	}
}
