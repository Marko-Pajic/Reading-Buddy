namespace Reading_Buddy
{
    public class Word
    {
		private string _text;

		public string Text
		{
			get { return _text; }
			set { _text = value; }
		}

		private string _explanation;

		public string Explanation
		{
			get { return _explanation; }
			set { _explanation = value; }
		}

		private string _imageReference;

		public string ImageReference
		{
			get { return _imageReference; }
			set { _imageReference = value; }
		}

		private List<string> _synonyms;

		public List<string> Synonyms
		{
			get { return _synonyms; }
			set { _synonyms = value; }
		}

		private byte[] _pronunciation;

		public byte[] Pronunciation
        {
			get { return _pronunciation; }
			set { _pronunciation = value; }
		}

		private Translation _wordTranslation;

		public Translation WordTranslation
		{
			get { return _wordTranslation; }
			set { _wordTranslation = value; }
		}

        private int _lastReadWord;

        public int LastReadWord
        {
            get { return _lastReadWord; }
            set { _lastReadWord = value; }
        }

    }
}
