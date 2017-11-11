using System;

namespace mdlComponentesGraficos
{
	/// <summary>
	/// Summary description for Painter.
	/// </summary>
	public class Painter
	{
		#region Atributes
		#endregion
		#region Properties
		#endregion
		#region Constructors
			public Painter()
			{
			}
		#endregion

		#region First Color
			public static System.Drawing.Color GetFirstColor(System.Drawing.Image image)
			{
				if (image == null)
					return(System.Drawing.Color.White);
				System.Drawing.Color clrReturn = System.Drawing.Color.White;
				System.Drawing.Bitmap bmp;
				System.Drawing.Imaging.BitmapData bmData;
				System.IntPtr ptr;
				int nOffSet,x,y,red,blue,green;
				bmp = (System.Drawing.Bitmap)image.Clone();
				bmData = bmp.LockBits(new System.Drawing.Rectangle(0, 0, bmp.Width, bmp.Height), System.Drawing.Imaging.ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
				ptr = bmData.Scan0;
				nOffSet = bmp.Height;
				for (y = 0; y < 1;y++)
				{
					for (x = 0; x < 1;x++)
					{
						blue = System.Runtime.InteropServices.Marshal.ReadByte(ptr, 0);
						green = System.Runtime.InteropServices.Marshal.ReadByte(ptr, 1);
						red = System.Runtime.InteropServices.Marshal.ReadByte(ptr, 2);
						clrReturn = System.Drawing.Color.FromArgb(red,green,blue);
						ptr = new System.IntPtr(ptr.ToInt32() + 3);
					}
					ptr = bmData.Scan0;
					ptr = new System.IntPtr(ptr.ToInt32() + (bmData.Stride * y));
				}
				ptr = new System.IntPtr(ptr.ToInt32() + nOffSet);
				bmp.UnlockBits(bmData);
				return(clrReturn);
			}
		#endregion
		#region First Color Hits
			public static System.Drawing.Color GetFirstColorHits(System.Drawing.Image image)
			{
				//TODO: Work over here - Not Ready
				System.Drawing.Color clrReturn = System.Drawing.Color.White;
				System.Collections.ArrayList arlColors = new System.Collections.ArrayList();
				System.Collections.ArrayList arlColorsHits = new System.Collections.ArrayList();
				System.Drawing.Bitmap bmp;
				System.Drawing.Imaging.BitmapData bmData;
				System.IntPtr ptr;
				int nOffSet,x,y,red,blue,green;
				bmp = (System.Drawing.Bitmap)image.Clone();
				bmData = bmp.LockBits(new System.Drawing.Rectangle(0, 0, bmp.Width, bmp.Height), System.Drawing.Imaging.ImageLockMode.ReadWrite, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
				ptr = bmData.Scan0;
				nOffSet = bmp.Height;
				for (y = 0; y < bmp.Height;y++)
				{
					for (x = 0; x < bmData.Width + 1;x++)
					{
						blue = System.Runtime.InteropServices.Marshal.ReadByte(ptr, 0);
						green = System.Runtime.InteropServices.Marshal.ReadByte(ptr, 1);
						red = System.Runtime.InteropServices.Marshal.ReadByte(ptr, 2);
						System.Drawing.Color clrCurrent = System.Drawing.Color.FromArgb(red,green,blue);
						IncreaseColorHits(ref arlColors,ref arlColorsHits,clrCurrent);
						ptr = new System.IntPtr(ptr.ToInt32() + 3);
					}
					ptr = bmData.Scan0;
					ptr = new System.IntPtr(ptr.ToInt32() + (bmData.Stride * y));
				}
				ptr = new System.IntPtr(ptr.ToInt32() + nOffSet);
				bmp.UnlockBits(bmData);
				clrReturn = GetHigherColorHits(ref arlColors,ref arlColorsHits);
				return(clrReturn);
			}

			private static void IncreaseColorHits(ref System.Collections.ArrayList arlColors,ref System.Collections.ArrayList arlColorsHits,System.Drawing.Color clrColor)
			{
				bool Exists = false;
				for(int i = 0; i < arlColors.Count;i++)
				{
					if (((System.Drawing.Color)(arlColors[i])).Equals(clrColor))
					{
						Exists = true;
						arlColorsHits[i] = ((int)arlColorsHits[i]) + 1;
						break;
					} 
				}
				if (!Exists)
				{
					arlColors.Add(clrColor);
					arlColorsHits.Add(1);
				}
			}

			private static System.Drawing.Color GetHigherColorHits(ref System.Collections.ArrayList arlColors,ref System.Collections.ArrayList arlColorsHits)
			{
				System.Drawing.Color clrReturn = System.Drawing.Color.White;
				int index = -1;
				int hits = 0;
				for(int i = 0; i < arlColorsHits.Count;i++)
				{
					if (((int)arlColorsHits[i]) > hits)
						index= i;
				}
				if (index != -1)
					clrReturn = (System.Drawing.Color)arlColors[index];
				return(clrReturn);
			}
		#endregion
	}
}
