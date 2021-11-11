using Core.Helpers;

namespace Infrastructure.DTOs
{
    public class LoginResultDTO
    {
        public int UserId { get; set; }
        public bool LoginSuccess { get; set; }
        public UserType UserType { get; set; }
    }
}
