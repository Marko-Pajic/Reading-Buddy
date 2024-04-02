using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reading_Buddy
{
    public class SessionReader
    {
		private DateTime _sessionStartTime;

		public DateTime SessionStartTime
		{
			get { return _sessionStartTime; }
			set { _sessionStartTime = value; }
		}

		private DateTime _sessionEndTime;

		public DateTime SessionEndTime
		{
			get { return _sessionEndTime; }
			set { _sessionEndTime = value; }
		}

		private Book _selectedBook;

		public Book SelectedBook
		{
			get { return _selectedBook; }
			set { _selectedBook = value; }
		}

		private int _pagesRead;

		public int PagesRead
		{
			get { return _pagesRead; }
			set { _pagesRead = value; }
		}


	}
}
