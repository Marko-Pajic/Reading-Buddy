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

		private List<EpubNavigationItem> _navigation;

		public List<EpubNavigationItem> Navigation
		{
			get { return _navigation; }
			set { _navigation = value; }
		}

		private string _chapter;

		public string Chapter
		{
			get { return _chapter; }
			set { _chapter = value; }

		}

		public List<Chapter> Chapters = new();

        private string _page;

        public string Page
        {
            get { return _page; }
            set { _page = value; }

        }

        public List<Page> Pages = new();
    }
}
