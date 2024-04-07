namespace Reading_Buddy
{
    public class UI
    {
        public static void ShowIntro()
        {
            Console.WriteLine("Welcome to game of Reading Buddy...");
            Console.WriteLine("Your welcome to start using program\n");
            Console.WriteLine("Which book would you like to read:\n");
        }

        public static string GetSelectedFileName(string[] fileEntries)
        {
            string fileEntry;
            int numOfChosenCategory;

            while (true)
            {
                for (int i = 0; i < fileEntries.Length; i++)
                {
                    fileEntry = fileEntries[i];
                    Console.WriteLine($"{i + 1}.{Path.GetFileNameWithoutExtension(fileEntry)}");
                }

                if (int.TryParse(Console.ReadLine(), out numOfChosenCategory))
                {
                    if (numOfChosenCategory >= 1 && numOfChosenCategory <= fileEntries.Length)
                    {
                        string fileToPlay = fileEntries[numOfChosenCategory - 1];
                        return fileToPlay;
                    }
                }
                Console.WriteLine("\nIncorrect input.\nPlease try again!\n");
            }
        }
    }
}
