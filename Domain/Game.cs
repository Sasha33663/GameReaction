namespace Domain;

public class Game
{
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public int GamesAmount { get; set; }
    public Guid GameId { get; set; }
    public byte GamePreview { get; set; }
    public int Likes { get; set; }
    public int Dislikes { get; set; }
}