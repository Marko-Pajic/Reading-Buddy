namespace Reading_Buddy
{
    public class User
    {
		private int _id;

		public int ID
		{
			get { return _id; }
			set { _id = value; }
		}

		private DateTime _age;

		public DateTime Age
		{
			get { return _age; }
			set { _age = value; }
		}

		private List<Book> _books;

		public List<Book> Books
		{
			get { return _books; }
			set { _books = value; }
		}

		private string _nativeLanguage;

		public string NativeLanguage
		{
			get { return _nativeLanguage; }
			set { _nativeLanguage = value; }
		}

	}

}
