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

            foreach (EpubLocalTextContentFile textContentFile in selectedBook.ReadingOrder)
            {
                HtmlDocument htmlDocument = new();
                htmlDocument.LoadHtml(textContentFile.Content);

                var nodes = htmlDocument.DocumentNode.SelectNodes("//p[@class='calibre1']");

                if (nodes != null)
                {
                    Page page = null;
                    StringBuilder sb = new StringBuilder();

                    foreach (HtmlNode node in nodes)
                    {
                        var anchorNode = node.SelectSingleNode("a[@id]");

                        if (anchorNode != null)
                        {
                            // If a page has already been started, add it to the book
                            if (page != null)
                            {
                                page.Text = sb.ToString().Trim();
                                b.Pages.Add(page);
                                sb.Clear();
                            }

                            // Start a new page
                            page = new Page
                            {
                                Number = anchorNode.GetAttributeValue("id", "")
                            };
                        }

                        // Add the text of the current node to the current page
                        sb.AppendLine(node.InnerText);
                    }

                    // Add the last page to the book
                    if (page != null)
                    {
                        page.Text = sb.ToString().Trim();
                        b.Pages.Add(page);
                    }
                }
            }


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
