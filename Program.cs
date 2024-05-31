using VersOne.Epub;
using System.Text;
using HtmlAgilityPack;
using System.Speech.Synthesis;

namespace Reading_Buddy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            UI.ShowIntro();

            string[] bookFiles = Directory.GetFiles(Constant.DIRECTORY_FOLDER, Constant.FILE_TYPE);

            string selectedFile = UI.GetSelectedFileName(bookFiles);

            EpubBook selectedBook = EpubReader.ReadBook(selectedFile);

            Book book = Mapper.ConvertToCustomClass(selectedFile);


            foreach (Page page in book.Pages)
            {
                Console.WriteLine("Page number: " + page.Number);
                Console.WriteLine("Page start:");
                Console.WriteLine(page.Text);
                Console.WriteLine("Page end:\n");
            }



        }
    }
}