using System;
using System.ComponentModel;

namespace mdlComponentesGraficos
{
	/// <summary>
	/// Summary description for DateTimePicker.
	/// </summary>
	public class DateTimePicker : System.Windows.Forms.DateTimePicker
	{ 
		#region Atributes
			private bool m_bEnterGotoNexSector = true;
			private bool m_bSpaceGotoNexSector = true;
		#endregion
		#region Properties
			[DefaultValue(true)]
			public bool EnterGotoNexSector
			{
				set
				{
					m_bEnterGotoNexSector = value;
				}
				get
				{
					return(m_bEnterGotoNexSector);
				}
			}

			[DefaultValue(true)]
			public bool SpaceGotoNexSector
			{
				set
				{
					m_bSpaceGotoNexSector = value;
				}
				get
				{
					return(m_bSpaceGotoNexSector);
				}
			}
		#endregion

		#region Events
			protected override void OnKeyPress(System.Windows.Forms.KeyPressEventArgs e)
			{
				if (this.Format == System.Windows.Forms.DateTimePickerFormat.Custom)
				{
					switch((int)e.KeyChar)
					{
						case 13: // Enter
							if (m_bEnterGotoNexSector)
							{
								e.Handled = true;
								vFocusNextSector();
							}
								
							break;
						case 32: // Space
							if (m_bSpaceGotoNexSector)
							{
								e.Handled = true;
								vFocusNextSector();
							}
   							break;
					}
				}
				base.OnKeyPress (e);
			}
		#endregion

		#region Focus
			private void vFocusNextSector()
			{
				System.Windows.Forms.SendKeys.Send("{RIGHT}");
			}
		#endregion
	}
}
