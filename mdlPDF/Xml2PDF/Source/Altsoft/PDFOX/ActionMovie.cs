namespace Altsoft.PDFO
{
    using System;

    public class ActionMovie : Action
    {
        // Methods
        public ActionMovie(PDFDirect direct) : base(direct)
        {
        }

        public static ActionMovie Create()
        {
            PDFDict dict1 = Library.CreateDict();
            dict1["S"] = Library.CreateName("Movie");
            ActionMovie movie1 = (Resources.Get(dict1, typeof(ActionMovie)) as ActionMovie);
            Library.CreateIndirect(dict1);
            return movie1;
        }

        public static ActionMovie Create(AnnotationMovie movie)
        {
            ActionMovie movie1 = ActionMovie.Create(true);
            movie1.Movie = movie;
            return movie1;
        }

        public static ActionMovie Create(bool indirect)
        {
            PDFDict dict1 = Library.CreateDict();
            dict1["S"] = Library.CreateName("Movie");
            ActionMovie movie1 = (Resources.Get(dict1, typeof(ActionMovie)) as ActionMovie);
            if (indirect)
            {
                Library.CreateIndirect(dict1);
            }
            return movie1;
        }

        public static ActionMovie Create(bool indirect, AnnotationMovie movie)
        {
            ActionMovie movie1 = ActionMovie.Create(indirect);
            movie1.Movie = movie;
            return movie1;
        }

        public static ActionMovie Create(AnnotationMovie movie, string title, EMovieOperation op)
        {
            ActionMovie movie1 = ActionMovie.Create(true);
            movie1.Movie = movie;
            movie1.Title = title;
            movie1.operation = op;
            return movie1;
        }

        public static ActionMovie Create(bool indirect, AnnotationMovie movie, string title, EMovieOperation op)
        {
            ActionMovie movie1 = ActionMovie.Create(indirect);
            movie1.Movie = movie;
            movie1.Title = title;
            movie1.operation = op;
            return movie1;
        }


        // Properties
        public AnnotationMovie Movie
        {
            get
            {
                PDFDict dict1 = (this.Dict["Annotation"] as PDFDict);
                if (dict1 == null)
                {
                    return null;
                }
                return (Resources.Get(dict1, typeof(AnnotationMovie)) as AnnotationMovie);
            }
            set
            {
                this.Dict["Annotation"] = value.Direct;
            }
        }

        public EMovieOperation operation
        {
            get
            {
                PDFName name1 = (this.Dict["Operation"] as PDFName);
                if (name1 == null)
                {
                    return EMovieOperation.Play;
                }
                string text1 = name1.Value;
                if (text1 == null)
                {
                    goto Label_004E;
                }
                text1 = string.IsInterned(text1);
                if (text1 != "Play")
                {
                    if (text1 == "Stop")
                    {
                        goto Label_004C;
                    }
                    goto Label_004E;
                }
                return EMovieOperation.Play;
            Label_004C:
                return EMovieOperation.Stop;
            Label_004E:
                throw new Exception("Illegal movie operation");
            }
            set
            {
                string text1 = "Play";
                if (value == EMovieOperation.Stop)
                {
                    text1 = "Stop";
                }
                this.Dict["Operation"] = Library.CreateName(text1);
            }
        }

        public string Title
        {
            get
            {
                PDFString text1 = (this.Dict["T"] as PDFString);
                if (text1 == null)
                {
                    return null;
                }
                return text1.Value;
            }
            set
            {
                this.Dict["T"] = Library.CreateString(value);
            }
        }


        // Fields
        public const string Type = "Movie";
    }
}

