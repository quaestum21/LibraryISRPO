using LibraryISRPO.Core.Models;

namespace LibraryISRPO.DataAccess.Entities
{
    public class BookEntity
    {
        public Guid Id { get; set;  }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public ICollection<BorrowedBookEntity> BorrowedBook { get; set; }//для связи многие ко многим

    }
}
