using System;
using PdfTypes;
using Report;

namespace mdlPDF
{
	internal class ContentsElement
	{
		PdfDictionary FData;
		SDItem FTarget;
		string FTitle;

		public PdfDictionary Data
		{
			get
			{
				return FData;
			}
			set
			{
				FData=value;
			}
		}

		public SDItem Target
		{
			get
			{
				return FTarget;
			}
			set
			{
				FTarget=value;
			}
		}

		public string Title
		{
			get
			{
				return FTitle;
			}
			set
			{
				FTitle=value;
			}
		}
	}
}
