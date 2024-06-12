using HtmlAgilityPack;
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
        public static Book ConvertToCustomClass(string selectedFile)
        {
            Book b = new();

            EpubBook selectedBook = EpubReader.ReadBook(selectedFile);

            b.Title = selectedBook.Title;
            b.Author = selectedBook.Author;

            //List<Page> pages = new List<Page>();
            //List<string> pageText = new List<string>();
            //int pageNumber = 1;

            //HtmlDocument doc = new HtmlDocument();

            //foreach (EpubLocalTextContentFile textContentFile in selectedBook.ReadingOrder)
            //{
            //    doc.LoadHtml(textContentFile.Content);
            //    string contentWithoutTags = doc.DocumentNode.InnerText;

            //    string[] sentences = contentWithoutTags.Split(new char[] { '.', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);
            //    foreach (string sentence in sentences)
            //    {
            //        if (pageText.Count == 30)
            //        {
            //            pages.Add(new Page { Number = pageNumber.ToString(), Text = string.Join(" ", pageText) });
            //            pageText = new List<string>();
            //            pageNumber++;
            //        }
            //        pageText.Add(sentence.Trim());
            //    }
            //}

            //if (pageText.Count > 0)
            //{
            //    pages.Add(new Page { Number = pageNumber.ToString(), Text = string.Join(" ", pageText) });
            //}

            //b.Pages = pages;

            //return b;



            foreach (var n in selectedBook.Navigation)
            {
                Chapter chapter = new();
                chapter.Title = n.Title;
                EpubLocalTextContentFile contentFile = (EpubLocalTextContentFile)selectedBook.Content.AllFiles.Local.First(i => i.ContentLocation == n.HtmlContentFile.ContentLocation);

                chapter.HTML = contentFile.Content;
                //TODO Parse HTML

                b.Chapters.Add(chapter);


            }


            return b;
        }
    }
}
