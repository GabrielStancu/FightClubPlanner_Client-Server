using Core.Helpers;

namespace Infrastructure.DTOs
{
    public class FighterDTO : UserDTO
    {
        public UserType UserType { get; set; } = UserType.Fighter;
        public int Age { get; set; }
        public int Weight { get; set; }
        public int Height { get; set; }
        public bool IsEligible { get; set; }
    }
}
