namespace Presentation.Dto;
public record GameDto(string name, string description, int price, int gamesAmount, byte gamePreview, int likes, int disLikes, Guid userId);