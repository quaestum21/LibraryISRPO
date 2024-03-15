namespace LibraryISRPO.DataAccess.Entities
{
    public class VisitorEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public ICollection<BorrowedBookEntity> BorrowedBook { get; set; } 
    }
}
