using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace executavel
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{

		#region MAIN
			/// <summary>
			/// The main entry point for the application.
			/// </summary>
			[STAThread]
			static void Main() 
			{
				Application.Run(new Form1());
			}
		#endregion

		#region Atributos
			private System.Windows.Forms.GroupBox m_gbGeral;
			private System.Windows.Forms.GroupBox groupBox1;
			private System.Windows.Forms.GroupBox m_gbOutput;
			private System.Windows.Forms.Button m_btIComparerNumeroTexto;
			private System.Windows.Forms.ListView m_lvOutput;
			private System.Windows.Forms.GroupBox m_gbFormat;
			private System.Windows.Forms.Button m_btIFormatProvider;
			/// <summary>
			/// Required designer variable.
			/// </summary>
			private System.ComponentModel.Container components = null;
		#endregion
		#region Constructor e Destructor
			public Form1()
			{
				InitializeComponent();
			}

			/// <summary>
			/// Clean up any resources being used.
			/// </summary>
			protected override void Dispose( bool disposing )
			{
				if( disposing )
				{
					if (components != null) 
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
			this.m_gbGeral = new System.Windows.Forms.GroupBox();
			this.m_gbOutput = new System.Windows.Forms.GroupBox();
			this.m_lvOutput = new System.Windows.Forms.ListView();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.m_btIComparerNumeroTexto = new System.Windows.Forms.Button();
			this.m_gbFormat = new System.Windows.Forms.GroupBox();
			this.m_btIFormatProvider = new System.Windows.Forms.Button();
			this.m_gbGeral.SuspendLayout();
			this.m_gbOutput.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.m_gbFormat.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_gbGeral
			// 
			this.m_gbGeral.Controls.AddRange(new System.Windows.Forms.Control[] {
																					this.m_gbFormat,
																					this.m_gbOutput,
																					this.groupBox1});
			this.m_gbGeral.Location = new System.Drawing.Point(8, 8);
			this.m_gbGeral.Name = "m_gbGeral";
			this.m_gbGeral.Size = new System.Drawing.Size(504, 472);
			this.m_gbGeral.TabIndex = 0;
			this.m_gbGeral.TabStop = false;
			// 
			// m_gbOutput
			// 
			this.m_gbOutput.Controls.AddRange(new System.Windows.Forms.Control[] {
																					 this.m_lvOutput});
			this.m_gbOutput.Location = new System.Drawing.Point(8, 160);
			this.m_gbOutput.Name = "m_gbOutput";
			this.m_gbOutput.Size = new System.Drawing.Size(488, 304);
			this.m_gbOutput.TabIndex = 1;
			this.m_gbOutput.TabStop = false;
			this.m_gbOutput.Text = "Output";
			// 
			// m_lvOutput
			// 
			this.m_lvOutput.Location = new System.Drawing.Point(8, 16);
			this.m_lvOutput.Name = "m_lvOutput";
			this.m_lvOutput.Size = new System.Drawing.Size(472, 280);
			this.m_lvOutput.TabIndex = 0;
			this.m_lvOutput.View = System.Windows.Forms.View.List;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.AddRange(new System.Windows.Forms.Control[] {
																					this.m_btIComparerNumeroTexto});
			this.groupBox1.Location = new System.Drawing.Point(8, 16);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(208, 48);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "IComparer - Numero com Texto";
			// 
			// m_btIComparerNumeroTexto
			// 
			this.m_btIComparerNumeroTexto.Location = new System.Drawing.Point(8, 16);
			this.m_btIComparerNumeroTexto.Name = "m_btIComparerNumeroTexto";
			this.m_btIComparerNumeroTexto.Size = new System.Drawing.Size(184, 24);
			this.m_btIComparerNumeroTexto.TabIndex = 0;
			this.m_btIComparerNumeroTexto.Text = "Testar";
			this.m_btIComparerNumeroTexto.Click += new System.EventHandler(this.m_btIComparerNumeroTexto_Click);
			// 
			// m_gbFormat
			// 
			this.m_gbFormat.Controls.AddRange(new System.Windows.Forms.Control[] {
																					 this.m_btIFormatProvider});
			this.m_gbFormat.Location = new System.Drawing.Point(224, 16);
			this.m_gbFormat.Name = "m_gbFormat";
			this.m_gbFormat.Size = new System.Drawing.Size(144, 48);
			this.m_gbFormat.TabIndex = 2;
			this.m_gbFormat.TabStop = false;
			this.m_gbFormat.Text = "IFormatProvider";
			// 
			// m_btIFormatProvider
			// 
			this.m_btIFormatProvider.Location = new System.Drawing.Point(8, 17);
			this.m_btIFormatProvider.Name = "m_btIFormatProvider";
			this.m_btIFormatProvider.Size = new System.Drawing.Size(124, 24);
			this.m_btIFormatProvider.TabIndex = 1;
			this.m_btIFormatProvider.Text = "Testar";
			this.m_btIFormatProvider.Click += new System.EventHandler(this.m_btIFormatProvider_Click);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(520, 486);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.m_gbGeral});
			this.Name = "Form1";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Componentes Coleções";
			this.m_gbGeral.ResumeLayout(false);
			this.m_gbOutput.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.m_gbFormat.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Eventos
			private void m_btIComparerNumeroTexto_Click(object sender, System.EventArgs e)
			{
				System.Collections.SortedList sortListTest = new System.Collections.SortedList(new mdlComponentesColecoes.clsComparerNumbersTexts());

				// Inserindo os Items 
				sortListTest.Add("1","1");
				sortListTest.Add("2","2");
				sortListTest.Add("5","5");
				sortListTest.Add("10","10");
				sortListTest.Add("11","11");
                sortListTest.Add("Thiago","Thiago");
				sortListTest.Add("22","22");
				sortListTest.Add("","");
				sortListTest.Add("Silvio","Silvio");
				sortListTest.Add("Paulo","Paulo");
				sortListTest.Add("32","32");
				sortListTest.Add("Robson","Robson");
				sortListTest.Add("27","27");

				for(int nCont = 300;nCont < 400;nCont++)
					sortListTest.Add(nCont.ToString(),nCont.ToString());

				m_lvOutput.Items.Clear();
				for (int nCont = 0; nCont < sortListTest.Count ; nCont++)
				{
					m_lvOutput.Items.Add((string)sortListTest.GetByIndex(nCont));
				}
			}

			private void m_btIFormatProvider_Click(object sender, System.EventArgs e)
			{
				string strNumeroInserir = "15,45";
				m_lvOutput.Items.Clear();
				m_lvOutput.Items.Add(System.String.Format(new mdlComponentesColecoes.clsFormatTextsNumbers(),"3",strNumeroInserir));
			}
		#endregion

	}
}
