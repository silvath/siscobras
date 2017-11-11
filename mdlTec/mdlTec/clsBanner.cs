using System;

namespace mdlTec
{
	/// <summary>
	/// Summary description for clsBanner.
	/// </summary>
	internal class clsBanner
	{
		#region Atributes

		#endregion
		#region Properties

		#endregion
		#region Constructor
			public clsBanner()
			{
			}
		#endregion

		#region GetBanner
			internal static System.Drawing.Image GetBanner()
			{
				System.Collections.ArrayList arlImages = new System.Collections.ArrayList();
				System.Reflection.Assembly assCurrent = System.Reflection.Assembly.GetExecutingAssembly();
				string[] arrStrAssembly = assCurrent.GetManifestResourceNames();
				for(int i = 0; i < arrStrAssembly.Length;i++)
				{
					if (arrStrAssembly[i].StartsWith("mdlTec.Banners."))
					{
						System.IO.Stream stmResource = assCurrent.GetManifestResourceStream(arrStrAssembly[i]);
						arlImages.Add(System.Drawing.Image.FromStream(stmResource));
					}
				}
				if (arlImages.Count == 0)
					return(null);
				System.Random objRdm = new System.Random(System.Environment.TickCount);

				int index = objRdm.Next(0,arlImages.Count);
				return((System.Drawing.Image)arlImages[index]);
			}
		#endregion
	}
}
