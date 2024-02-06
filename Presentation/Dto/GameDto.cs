using Microsoft.AspNetCore.Http;

namespace Presentation.Dto;
public record GameDto(string name, string description, int price, int gamesAmount, IFormFile gamePreview, Guid userId);