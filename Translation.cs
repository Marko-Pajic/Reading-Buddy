namespace Reading_Buddy
{
    public class Translation
    {
		private Word _unkownWord;

		public Word UnkownWord
		{
			get { return _unkownWord; }
			set { _unkownWord = value; }
		}

		private string _swedish;

		public string Swedish
		{
			get { return _swedish; }
			set { _swedish = value; }
		}

		private string _english;

		public string English
		{
			get { return _english; }
			set { _english = value; }
		}


	}
}
