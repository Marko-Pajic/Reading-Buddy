using VersOne.Epub;

namespace Reading_Buddy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            UI.ShowIntro();

            string[] bookFiles = Directory.GetFiles(Constant.DIRECTORY_FOLDER, Constant.FILE_TYPE);

            string selectedFile = UI.GetSelectedFileName(bookFiles);

            EpubBook book = EpubReader.ReadBook(selectedFile);

        }
    }
}