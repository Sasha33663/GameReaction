using Microsoft.AspNetCore.Identity;

namespace Domain
{
    public class User : IdentityUser <Guid>
    {
        public string UserName { get; set; }
        public Guid UserId { get; set; }
        public decimal MoneyAmount { get; set; }
        public List<Game> Games { get; set; }
        public User(Guid userId) { UserId = userId; }
    }
}