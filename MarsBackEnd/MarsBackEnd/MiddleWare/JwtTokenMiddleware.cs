using Microsoft.AspNetCore.Http;

public class JwtTokenMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<JwtTokenMiddleware> _logger;
    private readonly string[] _pathsToSkip;

    public JwtTokenMiddleware(RequestDelegate next, ILogger<JwtTokenMiddleware> logger, string[] pathsToSkip)
    {
        _next = next;
        _logger = logger;
        _pathsToSkip = pathsToSkip;
    }

    public async Task Invoke(HttpContext context)
    {
        if (!IsPathToSkip(context.Request.Path))
        {
            if (!context.Request.Headers.ContainsKey("Authorization"))
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("Authorization header is missing");
                return;
            }

            var authHeader = context.Request.Headers["Authorization"].ToString();
            var token = authHeader.Split(' ')[1]; // Отримуємо токен з заголовка

            // Тут ви можете додати код для перевірки та верифікації токену JWT
        }

        await _next(context);
    }

    private bool IsPathToSkip(string path)
    {
        var pathString = PathString.FromUriComponent(path);
        return _pathsToSkip.Any(p => pathString.StartsWithSegments(p));
    }

}
