﻿using Application;
using Microsoft.AspNetCore.Mvc;
using Presentation.Dto;
using System.IO;
using System.Security.Cryptography.X509Certificates;

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

    public async Task<IActionResult> Create([FromForm] GameDto gameDto)
    {
       
        byte[] previewBytes = null;

       
        if (gameDto.gamePreview != null)
        {
           

            using (MemoryStream ms = new MemoryStream())
            {
                await gameDto.gamePreview.CopyToAsync(ms);
                previewBytes = ms.ToArray();
            }
        }

        return Json(await _userService.GameCreateServiceAsync(gameDto.name, gameDto.description, gameDto.price, gameDto.gamesAmount, previewBytes, gameDto.userId));

    }
    [HttpPost("like")]
    public async Task <IActionResult> Like([FromForm]LikeDto likeDto)
    {
        return Json(await _userService.CreateLike(likeDto.likes, likeDto.userId, likeDto.gameId));
    }
}