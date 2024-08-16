namespace WebApi1.Models
{
    public class User
    {
        public long Id { get; set; }
        public string? Surname { get; set; }
        public string? Firstname { get; set; }
        public string? Lastname { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Phone { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
