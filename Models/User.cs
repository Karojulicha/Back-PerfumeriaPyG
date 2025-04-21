namespace Perfumeria.Models
{
    public enum UserRole
    {
        Admin, Customer,
    };
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public UserRole Role {get; set;} = UserRole.Customer;
    }

}