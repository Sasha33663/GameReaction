namespace Domain
{
    public class User
    {
        public string UserName { get; set; }
        public Guid UserId { get; set; }
        public decimal MoneyAmount { get; set; }
        public List<Game> Games { get; set; }
    }
}