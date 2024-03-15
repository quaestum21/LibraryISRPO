namespace LibraryISRPO.Core.Models
{
    public class Visitor
    {
        public Guid Id { get; }
        public string Name { get; }
        public string Email { get; }
        public ICollection<BorrowedBook> BorrowedBooks { get;}
        private Visitor(Guid id, string name, string email)
        {
            Id = id;
            Name = name;
            Email = email;
        }

        public static (Visitor Visitor, string Error) Create(Guid id, string name, string email)
        {
            var error = string.Empty;
            if (string.IsNullOrEmpty(name))
            {
                error = "Name can not be empty.";
            }
            if (string.IsNullOrEmpty(email))
            {
                error = "Email can not be empty.";
            }
            var visitor = new Visitor(id, name, email);
            return (visitor, error);
        }
    }
}