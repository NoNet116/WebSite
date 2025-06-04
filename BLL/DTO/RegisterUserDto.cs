namespace BLL.DTO
{
    public class RegisterUserDto
    {
        public required string LastName { get; set; }
        public required string FirstName { get; set; }
        public string? FatherName { get; set; }
        public required string EmailReg { get; set; }
        public DateTime BirthDate { get; set; }
        public required string UserName { get; set; }
        public required string Password { get; set; }
    }
}
