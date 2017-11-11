using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace mdlConstantes
{
	/// <summary>
	/// Summary description for frmFRepositorio.
	/// </summary>
	internal class frmFRepositorio : System.Windows.Forms.Form
	{
		#region Atributes
			public System.Windows.Forms.ImageList m_ilBandeiras;
			private System.ComponentModel.IContainer components;
		#endregion
		#region Properties
			public System.Windows.Forms.ImageList ListaBandeiras
			{
				get
				{
					return(m_ilBandeiras);
				}
			}
		#endregion
		#region Constructors
			public frmFRepositorio()
			{
				//
				// Required for Windows Form Designer support
				//
				InitializeComponent();

				//
				// TODO: Add any constructor code after InitializeComponent call
				//
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
		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmFRepositorio));
			this.m_ilBandeiras = new System.Windows.Forms.ImageList(this.components);
			// 
			// m_ilBandeiras
			// 
			this.m_ilBandeiras.ImageSize = new System.Drawing.Size(16, 16);
			this.m_ilBandeiras.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("m_ilBandeiras.ImageStream")));
			this.m_ilBandeiras.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// frmFRepositorio
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(292, 266);
			this.Name = "frmFRepositorio";
			this.Text = "frmFRepositorio";

		}
		#endregion
	}
}
