using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace mdlComponentesGraficos
{
	public enum AnimationState 
	{
		None,
		Animating
	}

	public enum AnimationMode 
	{
		None,
		ImageAnimation,
		ManualAnimation
	}

	public class AnimatedPictureBox : System.Windows.Forms.PictureBox 
	{
		#region Atributes
			private AnimationMode animationMode = AnimationMode.ImageAnimation;
			private AnimationState animationState = AnimationState.None;
			private int animationLoops = 0; // Unlimited
	    
			private Image internalImage = null;
			private AnimationInfo animationInfo = null;
		#endregion
		#region Properties
			public AnimationMode AnimationMode 
			{
				get 
				{
					return this.animationMode;
				}
			}
	    
			public int AnimationLoops 
			{
				get 
				{
					return this.animationLoops;
				}
				set 
				{
					this.animationMode = AnimationMode.ManualAnimation;
					this.animationLoops = value;
				}
			}

			public new Image Image 
			{
				get 
				{
					return this.internalImage;
				}
				set 
				{
					this.internalImage = value;
				}
			}
		#endregion
		#region Constructors
			public AnimatedPictureBox() 
			{
			}
		#endregion

		#region Animate
    	public void Start() 
		{
			if ( animationState == AnimationState.None && ImageAnimator.CanAnimate(this.internalImage) ) 
			{
				this.animationInfo = new AnimationInfo(this.internalImage);
				this.animationState = AnimationState.Animating;

				ImageAnimator.Animate(this.internalImage, new EventHandler(this.ImageAnimator_FrameChanged));
			}
		}
    
		public void Stop() 
		{
			if ( animationState == AnimationState.Animating ) 
			{
				ImageAnimator.StopAnimate(this.internalImage, new EventHandler(this.ImageAnimator_FrameChanged));
			}
        
			animationState = AnimationState.None;
			animationInfo = null;
		}

		public bool SetAnimationLoopsFromImage() 
		{
			Console.WriteLine(this.internalImage.RawFormat);
			Console.WriteLine(ImageFormat.Gif);
			if ( this.internalImage.RawFormat.Equals(ImageFormat.Gif) ) 
			{
				int loops = 0; // 0 will be infinite

				PropertyItem propLoop = this.internalImage.GetPropertyItem(20737);
				if ( propLoop == null ) 
				{
					loops = 1; // Some packages will remove the prop when loop should be only 1
				} 
				else 
				{
					loops = propLoop.Value[0];
					loops += propLoop.Value[1] << 8;

					if ( loops != 0 ) 
					{
						loops++; // Don't ask me, I guess it is part of the spec
					}
				}
        
				this.animationMode = AnimationMode.ImageAnimation;
				this.animationLoops = loops;
				return true;
			}
        
			return false;
		}
		#endregion
		#region Paint
    		protected override void OnPaint(PaintEventArgs pe) 
			{
				if (this.internalImage != null)
				{
					if ( animationState == AnimationState.Animating ) 
					{
						//if ( animationLoops == 0 || this.animationInfo.CurrentLoop < animationLoops ) 
						if ((animationLoops == 0) || (((this.animationInfo.CurrentLoop) + 1 < animationLoops) || (((this.animationInfo.CurrentLoop) + 1 == animationLoops) && ((this.animationInfo.CurrentFrame + 1) < this.animationInfo.TotalFrames)))) 
						{
							this.animationInfo.UpdateFrames();
							try
							{
								ImageAnimator.UpdateFrames(this.internalImage);
							}catch
							{
								//Error: Cant Draw Image
							}
						} 
						else 
						{
							Stop();
						}
					}
					GraphicsUnit gu = GraphicsUnit.Pixel;
					pe.Graphics.DrawImage(this.internalImage,this.internalImage.GetBounds(ref gu));
				}
				base.OnPaint(pe);
			}

			private void ImageAnimator_FrameChanged(object sender, EventArgs e) 
			{
				this.Invalidate();
			}
		#endregion
   
		#region AnimationInfo
		private class AnimationInfo 
		{
			private int currentLoop = 0;
			private int currentFrame = 0;
			private int totalFrames = 0;
    
			public AnimationInfo(Image image) 
			{
				this.currentLoop = 0;
				this.currentFrame = 0;
				this.totalFrames = image.GetFrameCount(new FrameDimension(image.FrameDimensionsList[0]));
			}
        
			public AnimationInfo(int currentLoop, int currentFrame, int totalFrames) 
			{
				this.currentLoop = currentLoop;
				this.currentFrame = currentFrame;
				this.totalFrames = totalFrames;
			}
        
			public void UpdateFrames() 
			{
				currentFrame++;
				if ( currentFrame >= totalFrames ) 
				{
					currentFrame = 0;
					currentLoop++;
				}
			}
        
			public int CurrentLoop { get { return this.currentLoop; } }
			public int CurrentFrame 
			{
				get
				{ 
					return(this.currentFrame);
				} 
			}
			public int TotalFrames { get { return this.totalFrames; } }
		}
		#endregion
	}
}
