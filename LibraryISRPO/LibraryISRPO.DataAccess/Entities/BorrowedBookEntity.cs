using LibraryISRPO.Core.Models;

namespace LibraryISRPO.DataAccess.Entities
{
    public class BorrowedBookEntity
    {
        public Guid BookId { get; set; }
        public BookEntity Book { get; set; }
        public Guid VisitorId { get; set; }
        public VisitorEntity Visitor { get; set; }
        public DateTime BorrowedDate { get; set; }
        public DateTime? ReturnedDate { get; set; }
    }
}
