using VersOne.Epub;
using System.Text;
using HtmlAgilityPack;

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

            Book book = Mapper.ConvertToCustomClass(selectedBook);

            //Book book = new Book(selectedBook);

            //Console.WriteLine(book.Title);
            //// Print the title and the author of the book
            //Console.WriteLine($"Title: {book.Title}");
            //Console.WriteLine($"Author: {book.Author}");
            //Console.WriteLine();

            // Print the table of contents
            //Console.WriteLine("TABLE OF CONTENT:");
            //PrintTableOfContents();
            //Console.WriteLine();

            // Print the text content of all chapters in the book
            //Console.WriteLine("CHAPTERS:");
            //PrintChapters();

            for (int i = 0; i < book.Navigation.Count; i++)
            {
                EpubNavigationItem navigationItem = book.Navigation[i];

                HtmlDocument htmlDocument = new();
                htmlDocument.LoadHtml(navigationItem.HtmlContentFile.Content);
                StringBuilder stringBuilder = new();
                foreach (HtmlNode node in htmlDocument.DocumentNode.SelectNodes("//text()"))
                {
                    string trimmedText = String.Join(" ", node.InnerText.Split(new char[0], StringSplitOptions.RemoveEmptyEntries));
                    stringBuilder.AppendLine(trimmedText);
                }
                string contentText = stringBuilder.ToString();
                Console.WriteLine(contentText);
                Console.WriteLine();
            }


            //for (int i = 0; i < selectedBook.Navigation.Count; i++)
            //{
            //    EpubNavigationItem navigationItem = selectedBook.Navigation[i];

            //    HtmlDocument htmlDocument = new();
            //    htmlDocument.LoadHtml(navigationItem.HtmlContentFile.Content);

            //    HtmlNode firstSentenceNode = htmlDocument.DocumentNode.SelectSingleNode("//p[1]"); // Assuming the first sentence is in a <p> tag

            //    if (firstSentenceNode != null)
            //    {
            //        string firstSentence = firstSentenceNode.InnerText.Trim();
            //        Console.WriteLine(firstSentence);
            //    }

            //    //StringBuilder stringBuilder = new();
            //    //foreach (HtmlNode node in htmlDocument.DocumentNode.SelectNodes("//text()"))
            //    //{
            //    //    string trimmedText = String.Join(" ", node.InnerText.Split(new char[0], StringSplitOptions.RemoveEmptyEntries));
            //    //    stringBuilder.AppendLine(trimmedText);
            //    //}
            //    //string contentText = stringBuilder.ToString();
            //    //Console.WriteLine(contentText);
            //    //Console.WriteLine();
            //}

            //void PrintTableOfContents()
            //{
            //    foreach (EpubNavigationItem navigationItem in selectedBook.Navigation)
            //    {
            //        PrintNavigationItem(navigationItem, 0);
            //    }
            //}

            //void PrintNavigationItem(EpubNavigationItem navigationItem, int identLevel)
            //{
            //    Console.Write(new string(' ', identLevel * 2));
            //    Console.WriteLine(navigationItem.Title);
            //    foreach (EpubNavigationItem nestedNavigationItem in navigationItem.NestedItems)
            //    {
            //        PrintNavigationItem(nestedNavigationItem, identLevel + 1);
            //    }
            //}

            //void PrintChapters()
            //{
            //    foreach (EpubLocalTextContentFile textContentFile in selectedBook.ReadingOrder)
            //    {
            //        PrintTextContentFile(textContentFile);
            //    }
            //}

            //void PrintTextContentFile(EpubLocalTextContentFile textContentFile)
            //{
            //    HtmlDocument htmlDocument = new();
            //    htmlDocument.LoadHtml(textContentFile.Content);
            //    StringBuilder sb = new();
            //    foreach (HtmlNode node in htmlDocument.DocumentNode.SelectNodes("//text()"))
            //    {
            //        sb.AppendLine(node.InnerText.Trim());
            //    }
            //    string contentText = sb.ToString();
            //    Console.WriteLine(contentText);
            //    Console.WriteLine();



        }
    }
}