using System;

namespace mdlComponentesGraficos
{
	/// <summary>
	/// Summary description for FormFlutuante.
	/// </summary>
	public class FormFlutuante : System.Windows.Forms.Form
	{
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(FormFlutuante));
			// 
			// FormFlutuante
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(464, 266);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
			this.HelpButton = true;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FormFlutuante";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;

		}
	
		public FormFlutuante()
		{
			//
			// TODO: Add constructor logic here
			//
		}
	}
}
