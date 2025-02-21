using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.book
{
    class EBook : Book
    {
        private double fileSize;
        private string format;

        public double FileSize
        {
            get { return fileSize; }
            set { fileSize = value; }
        }

        public string Format
        {
            get { return format; }
            set { format = value; }
        }


        public EBook(string title, string author, string isbn, double fileSize, string format)
            : base(title, author, isbn)
        {
            this.fileSize = fileSize;
            this.format = format;
        }

        
        public new void DisplayDetails()
        {
            base.DisplayDetails();
            Console.WriteLine($"File Size: {fileSize}MB, Format: {format}");
        }
    }    
}
