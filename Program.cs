using HtmlAgilityPack;
using System.Text;
using VersOne.Epub;

namespace Reading_Buddy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string filePath = @"C:\Users\pajic\Downloads\pg2701-images-3.epub";
            EpubBook book = EpubReader.ReadBook(filePath);
            foreach (EpubLocalTextContentFile textContentFile in book.ReadingOrder)
            {
                PrintTextContentFile(textContentFile);
            }
        }

        private static void PrintTextContentFile(EpubLocalTextContentFile textContentFile)
        {
            HtmlDocument htmlDocument = new();
            htmlDocument.LoadHtml(textContentFile.Content);
            StringBuilder sb = new();
            foreach (HtmlNode node in htmlDocument.DocumentNode.SelectNodes("//text()"))
            {
                sb.AppendLine(node.InnerText.Trim());
            }
            string contentText = sb.ToString();
            Console.WriteLine(contentText);
            Console.WriteLine();
        }
    }
}
