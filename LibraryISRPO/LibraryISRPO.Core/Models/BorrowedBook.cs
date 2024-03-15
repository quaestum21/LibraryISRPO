namespace LibraryISRPO.Core.Models
{
    public class BorrowedBook
    {
        public Guid BookId { get; }
        public Book Book { get;}
        public Guid VisitorId { get; }
        public Visitor Visitor { get;  }
        public DateTime BorrowedDate { get; }
        public DateTime? ReturnedDate { get;}

        private BorrowedBook(Guid bookId, Guid visitorId, DateTime borrowedDate)
        {
            BookId = bookId;
            VisitorId = visitorId;
            BorrowedDate = borrowedDate;
        }

        public static (BorrowedBook BorrowedBook, string Error) Create(Guid bookId, Guid visitorId, DateTime borrowedDate)
        {
            var error = string.Empty;
            if (bookId == Guid.Empty)
            {
                error = "BookId can not be empty.";
            }
            if (visitorId == Guid.Empty)
            {
                error = "VisitorId can not be empty.";
            }
            var borrowedBook = new BorrowedBook(bookId, visitorId, borrowedDate);
            return (borrowedBook, error);
        }
    }
}