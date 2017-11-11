using System;
using System.ComponentModel;

namespace mdlComponentesGraficos
{
	/// <summary>
	/// Summary description for PictureBox.
	/// </summary>
	public class PictureBox : System.Windows.Forms.PictureBox
	{
		#region Enum
			public enum Effects
			{
				None,
                Negative,
				BlackAndWhite
			}

			public enum Directions
			{
				None,
				Horizontal,
				Vertical,
				FromOutsideToInside
			}
		#endregion
		#region Atributes
			private bool m_bEffects = false;
			private System.Drawing.Image m_imgOriginalImage;
			private int m_nPercentage = 0;
			private PictureBox.Effects m_enumEffect;
			private PictureBox.Directions m_enumEffectDirection;
		#endregion
		#region Properties
			[DefaultValue(false)]
			public bool WithEffects
			{
				get
				{
					return(m_bEffects);
				}
				set
				{
					m_bEffects = value;
					ApplyEffects();
				}
			}

			[DefaultValue(null)]
			public System.Drawing.Image OriginalImage
			{
				get
				{
					return(m_imgOriginalImage);
				}
				set
				{
					m_imgOriginalImage = value;
				}
			}

			[DefaultValue(mdlComponentesGraficos.PictureBox.Effects.None)]
			public PictureBox.Effects Effect
			{
				get
				{
					return(m_enumEffect);
				}
				set
				{
					m_enumEffect = value;
					ApplyEffects();
				}
			}  

			[DefaultValue(mdlComponentesGraficos.PictureBox.Directions.None)]
			public PictureBox.Directions EffectDirection
			{
				get
				{
					return(m_enumEffectDirection);
				}
				set
				{
					m_enumEffectDirection = value;
					ApplyEffects();
				}
			}

			[DefaultValue(100)]
			public int Percentage
			{
				get
				{
					return(m_nPercentage);
				}
				set
				{
					if ((value >= 0) && (value <= 100))
					{
						m_nPercentage = value;
						ApplyEffects();
					}
				}
			}
		#endregion

		#region Effects
			public void ApplyEffects()
			{
				if ((m_bEffects) && (m_imgOriginalImage != null)) 
				{
					switch(m_enumEffect)
					{
						case PictureBox.Effects.BlackAndWhite:
							ApplyEffectsBlackAndWhite();
							break;
						case PictureBox.Effects.Negative:
							ApplyEffectsNegative();
							break;
						case PictureBox.Effects.None:
							ApplyEffectsNone();
							break;
					}
				}
			}   

			private void ApplyEffectsBlackAndWhite()
			{
				System.Drawing.Bitmap bmp;
	            System.Drawing.Imaging.BitmapData bmData;
				System.IntPtr ptr;
				int nOffSet,x,y,tamanho,red,blue,green;
				byte bVal;
				bmp = (System.Drawing.Bitmap)OriginalImage.Clone();
				bmData = bmp.LockBits(new System.Drawing.Rectangle(0, 0, bmp.Width, bmp.Height), System.Drawing.Imaging.ImageLockMode.ReadWrite, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
				ptr = bmData.Scan0;
				switch (m_enumEffectDirection)
				{
					case PictureBox.Directions.Horizontal:
						nOffSet = bmp.Height;
						tamanho = (int)((bmp.Width * m_nPercentage) / 100);
						for (y = 0; y < bmp.Height;y++)
						{
							for (x = 0; x < bmData.Width + 1;x++)
							{
								if (x >= tamanho)
								{
									blue = System.Runtime.InteropServices.Marshal.ReadByte(ptr, 0);
									green = System.Runtime.InteropServices.Marshal.ReadByte(ptr, 1);
									red = System.Runtime.InteropServices.Marshal.ReadByte(ptr, 2);
									bVal = (byte)(0.299 * red + 0.587 * green + 0.114 * blue);
									System.Runtime.InteropServices.Marshal.WriteByte(ptr, 0, bVal);
									System.Runtime.InteropServices.Marshal.WriteByte(ptr, 1, bVal);
									System.Runtime.InteropServices.Marshal.WriteByte(ptr, 2, bVal);
								}
								ptr = new System.IntPtr(ptr.ToInt32() + 3);
							}
							ptr = bmData.Scan0;
							ptr = new System.IntPtr(ptr.ToInt32() + (bmData.Stride * y));
						}
						ptr = new System.IntPtr(ptr.ToInt32() + nOffSet);
						break;
					case PictureBox.Directions.Vertical:
						nOffSet = bmData.Stride - bmp.Width * 3;
						tamanho = (int)((bmp.Height * m_nPercentage) / 100);
						for (y = tamanho; y < bmp.Height - 1;y++)
						{
							for (x = 0; x < bmp.Width - 1;x++)
							{
								blue = System.Runtime.InteropServices.Marshal.ReadByte(ptr, 0);
								green = System.Runtime.InteropServices.Marshal.ReadByte(ptr, 1);
								red = System.Runtime.InteropServices.Marshal.ReadByte(ptr, 2);
								bVal = (byte)(0.299 * red + 0.587 * green + 0.114 * blue);
								System.Runtime.InteropServices.Marshal.WriteByte(ptr, 0, bVal);
								System.Runtime.InteropServices.Marshal.WriteByte(ptr, 1, bVal);
								System.Runtime.InteropServices.Marshal.WriteByte(ptr, 2, bVal);
								ptr = new System.IntPtr(ptr.ToInt32() + 3);
							}
						}
						ptr = new System.IntPtr(ptr.ToInt32() + nOffSet);
						break;
					case PictureBox.Directions.FromOutsideToInside:
						int nLeft = 0,nTop,nRight,nButton;
						nLeft = 20;
						nTop = nLeft;
						nTop = 20;
						nRight = bmp.Width - 20;
						nButton = bmp.Height - 20;
						nOffSet = (bmp.Width - 1) * 3;
						for (y = 0; y < bmp.Height - 1;y++)
						{
							if ((nTop <= y) && (y <= nButton))
							{
								for (x = 0; x < bmp.Width - 1;x++)
								{
									blue = System.Runtime.InteropServices.Marshal.ReadByte(ptr, 0);
									green = System.Runtime.InteropServices.Marshal.ReadByte(ptr, 1);
									red = System.Runtime.InteropServices.Marshal.ReadByte(ptr, 2);
									bVal = (byte)(0.299 * red + 0.587 * green + 0.114 * blue);
									System.Runtime.InteropServices.Marshal.WriteByte(ptr, 0, bVal);
									System.Runtime.InteropServices.Marshal.WriteByte(ptr, 1, bVal);
									System.Runtime.InteropServices.Marshal.WriteByte(ptr, 2, bVal);
									ptr = new System.IntPtr(ptr.ToInt32() + 3);
								}
								
							}else{
								ptr = new System.IntPtr(ptr.ToInt32() + nOffSet);
							}
						}
						break;
				}
				bmp.UnlockBits(bmData);
				this.Image = bmp;
				this.Refresh();
			}

			private void ApplyEffectsNegative()
			{
				System.Drawing.Bitmap bmp;
				System.Drawing.Imaging.BitmapData bmData;
				System.IntPtr ptr; 
				int nOffSet,x, y, tamanho; 
				bmp = (System.Drawing.Bitmap)OriginalImage.Clone();
				bmData = bmp.LockBits(new System.Drawing.Rectangle(0, 0, bmp.Width, bmp.Height), System.Drawing.Imaging.ImageLockMode.ReadWrite, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
				ptr = bmData.Scan0;
				nOffSet = bmData.Stride - bmp.Width * 3;
				switch (m_enumEffectDirection)
				{
					case PictureBox.Directions.Horizontal:
						break;
					case PictureBox.Directions.Vertical:
							tamanho = (int)((bmp.Height * m_nPercentage) / 100);
							for (y = tamanho ; y < bmp.Height - 1 ; y ++)
							{
								for (x = 0 ; x <(bmp.Width * 3) - 1; x++)
								{
									System.Runtime.InteropServices.Marshal.WriteByte(ptr, 0, (byte)(255 - System.Runtime.InteropServices.Marshal.ReadByte(ptr, 0)));
									ptr = new System.IntPtr(ptr.ToInt32() + 1);
								}
							}
						break;
				}
				bmp.UnlockBits(bmData);
				this.Image = bmp;
				this.Refresh();
			}

			private void ApplyEffectsNone()
			{
                this.Image = this.OriginalImage;
			}
		#endregion
	}
}
