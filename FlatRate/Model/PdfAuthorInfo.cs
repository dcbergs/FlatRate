using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlatRate.Model
{
    class PdfAuthorInfo
    {
        public String Title { get; }
        public String Author { get; }
        public String ImageFilePath { get; }

        public PdfAuthorInfo(String title, String author, String filepath)
        {
            Title = title;
            Author = author;
            ImageFilePath = filepath;
        }
    }
}
