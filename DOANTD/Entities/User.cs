namespace DOANTD.Entities
{
    public class User : EntityBase<int>
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        // Thêm loại tài khoản
        public AccountType AccountType { get; set; } // Đảm bảo sử dụng enum đúng
    }

    // Enum để định nghĩa các loại tài khoản
    public enum AccountType
    {
        Admin,
        User,
        Business
    }
}