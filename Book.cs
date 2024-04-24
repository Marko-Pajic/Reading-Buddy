using VersOne.Epub;

namespace Reading_Buddy
{
    public class Book
    {
		private string _title;

		public string Title
		{
			get { return _title; }
			set { _title = value; }
		}

		private string _author;

		public string Author
		{
			get { return _author; }
			set { _author = value; }
		}

		private string _isbn;

		public string ISBN
		{
			get { return _isbn; }
			set { _isbn = value; }
		}

		private int _currentPage;

		public int CurrentPage
		{
			get { return _currentPage; }
			set { _currentPage = value; }
		}

		private int _lastReadWord;

		public int LastReadWord
		{
			get { return _lastReadWord; }
			set { _lastReadWord = value; }
		}

		private List<EpubNavigationItem> _navigation;

		public List<EpubNavigationItem> Navigation
        {
			get { return _navigation; }
			set { _navigation = value; }
		}


	}
}
