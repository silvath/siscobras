namespace Altsoft.PDFO
{
    using Altsoft.Common;
    using System;

    public class AnnotationMovie : Annotation
    {
        // Methods
        public AnnotationMovie(PDFDict dict) : base(dict)
        {
        }

        public static AnnotationMovie Create(Rect rect, Movie movie)
        {
            PDFDict dict1 = Library.CreateDict();
            dict1["Subtype"] = Library.CreateName("Movie");
            dict1["Movie"] = movie.Dict;
            AnnotationMovie movie1 = (Resources.Get(dict1, typeof(AnnotationMovie)) as AnnotationMovie);
            movie1.Rect = rect;
            Library.CreateIndirect(dict1);
            return movie1;
        }


        // Properties
        public Movie movie
        {
            get
            {
                PDFDict dict1 = (this.Dict["Movie"] as PDFDict);
                if (dict1 == null)
                {
                    return null;
                }
                return (Resources.Get(dict1, typeof(Movie)) as Movie);
            }
            set
            {
                this.Dict["Movie"] = value.Direct;
            }
        }

        public MoviePlayInfo PlayInfo
        {
            get
            {
                PDFObject obj1 = this.Dict["A"];
                if (obj1 == null)
                {
                    return MoviePlayInfo.playDefault;
                }
                if (obj1.PDFType == PDFObjectType.tPDFDict)
                {
                    return MoviePlayInfo.play;
                }
                if ((obj1 as PDFBoolean).Value)
                {
                    return MoviePlayInfo.play;
                }
                return MoviePlayInfo.notPlay;
            }
            set
            {
                MoviePlayInfo info1 = value;
                switch (info1)
                {
                    case MoviePlayInfo.playDefault:
                    {
                        this.Dict["A"] = Library.CreateBoolean(true);
                    }
                    case MoviePlayInfo.notPlay:
                    {
                        this.Dict["A"] = Library.CreateBoolean(false);
                    }
                }
            }
        }

        public MovieActivation PlayMovie
        {
            get
            {
                PDFDict dict1 = (this.Dict["A"] as PDFDict);
                if (dict1 == null)
                {
                    return null;
                }
                return (Resources.Get(dict1, typeof(MovieActivation)) as MovieActivation);
            }
            set
            {
                this.Dict["A"] = value.Direct;
            }
        }


        // Fields
        public const string SubType = "Movie";
    }
}

