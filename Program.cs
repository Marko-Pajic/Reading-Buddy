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

            // Book bookNavigation = Mapper.ConvertToCustomClass1(selectedBook);

            //SpeechSynthesizer synthesizer = new SpeechSynthesizer();

            //// Increase the rate of speech
            //synthesizer.Rate = 2; // Adjust the rate as needed

            //for (int i = 0; i < book.Navigation.Count; i++)
            //{
            //    EpubNavigationItem navigationItem = book.Navigation[i];

            //    HtmlDocument htmlDocument = new();
            //    htmlDocument.LoadHtml(navigationItem.HtmlContentFile.Content);
            //    StringBuilder stringBuilder = new();
            //    foreach (HtmlNode node in htmlDocument.DocumentNode.SelectNodes("//text()"))
            //    {
            //        string trimmedText = String.Join(" ", node.InnerText.Split(new char[0], StringSplitOptions.RemoveEmptyEntries));
            //        stringBuilder.AppendLine(trimmedText);
            //    }
            //    string contentText = stringBuilder.ToString();

            //    // Split the text into words
            //    string[] words = contentText.Split(' ');

            //    foreach (string word in words)
            //    {
            //        // Trim the word to remove any leading/trailing white spaces
            //        string trimmedWord = word.Trim();

            //        // Speak the word
            //        synthesizer.Speak(trimmedWord);

            //        // Display the word on the screen
            //        Console.Write(trimmedWord + " ");

            //        // Add a delay after each word to match the speech rate
            //        Thread.Sleep(1000); // Adjust the delay as needed
            //    }

            //    Console.WriteLine();
            //}


            for (int i = 0; i < selectedBook.Navigation.Count; i++)
            {
                EpubNavigationItem navigationItem = selectedBook.Navigation[i];

                HtmlDocument htmlDocument = new();
                htmlDocument.LoadHtml(navigationItem.HtmlContentFile.Content);

                bool start = false;
                List<string> texts = new List<string>();

                foreach (HtmlNode node in htmlDocument.DocumentNode.SelectNodes("//p[@class='calibre1']"))
                {
                    if (node.InnerHtml.Contains("id=\"p11\""))
                    {
                        start = true;
                    }
                    else if (node.InnerHtml.Contains("id=\"p12\""))
                    {
                        break;
                    }

                    if (start)
                    {
                        texts.Add(node.InnerText);
                    }
                }

                foreach (string text in texts)
                {
                    Console.WriteLine(text);
                }





                //for (int i = 0; i < selectedBook.Navigation.Count; i++)
                //{
                //    EpubNavigationItem navigationItem = selectedBook.Navigation[i];

                //    HtmlDocument htmlDocument = new();
                //    htmlDocument.LoadHtml(navigationItem.HtmlContentFile.Content);

                //    HtmlNode firstSentenceNode = htmlDocument.DocumentNode.SelectSingleNode("//p/anchor"); // Assuming the first sentence is in a <p> tag

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
                //foreach (EpubNavigationItem textContentFile in selectedBook.Navigation)
                //{
                //    Console.WriteLine(textContentFile.Title);
                //}
            }


            
        }
    }
}