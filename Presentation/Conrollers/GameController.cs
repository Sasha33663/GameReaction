using Application;
using Microsoft.AspNetCore.Mvc;
using Presentation.Dto;

namespace Presentation.Conrollers;

[ApiController]
[Route("api/games")]
public class GameController : Controller
{
    private readonly IUserService _userService;

    public GameController(IUserService gameService)
    {
        _userService = gameService;
    }

    [HttpPost("create")]
    public async Task<IActionResult> Create([FromBody] GameDto gameDto)
    {
        byte[] previewBytes;

        using (var ms = new MemoryStream())
        {
            await ms.WriteAsync(gameDto.gamePreview, 0, gameDto.gamePreview.Length);
            previewBytes = ms.ToArray();
        }
        return Json(await _userService.GameCreateServiceAsync(gameDto.name, gameDto.description, gameDto.price, gameDto.gamesAmount, gameDto.gamePreview, gameDto.userId));
    }
}