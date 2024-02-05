using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//namespace Presentation.Middlewares;

//    public class LikesDislikesMiddleware
//    {
//        private readonly RequestDelegate _next;

//        public LikesDislikesMiddleware(RequestDelegate next)
//        {
//            _next = next ?? throw new ArgumentNullException(nameof(next));
//        }

//        public async Task InvokeAsync(HttpContext context)
//        {
//            if (context.Request.Method.Equals("POST") && context.Request.Path.StartsWithSegments("/api"))
//            {
//                var likes = context.Request.Form["likes"];
//                var dislikes = context.Request.Form["dislikes"];

//                if (!IsValidValue(likes) || !IsValidValue(dislikes) || (likes == "1" && dislikes == "1"))
//                {
//                    context.Response.StatusCode = 400; // Bad Request
//                    await context.Response.WriteAsync("Invalid values for likes and dislikes");
//                    return ;
//                }
//            }

//            await _next(context);
//        }

//        private bool IsValidValue(string value)
//        {
//            return value == "0" || value == "1";
//        }
//    }

//    public static class LikesDislikesMiddlewareExtensions
//    {
//        public static IApplicationBuilder UseLikesDislikesMiddleware(this IApplicationBuilder builder)
//        {
//            return builder.UseMiddleware<LikesDislikesMiddleware>();
//        }
//    }


