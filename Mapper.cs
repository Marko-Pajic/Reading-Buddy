using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VersOne.Epub;

namespace Reading_Buddy
{
    public class Mapper
    {
        public static Book ConvertToCustomClass(EpubBook selectedBook)
        {
            return new Book
            {
                Title = selectedBook.Title,
                Author = selectedBook.Author,
                Navigation = selectedBook.Navigation,
            };
        }
    }
}
