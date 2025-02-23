﻿namespace ShoppingCart.Basket.LoginService
{
    public class LoginService : ILoginService
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public LoginService(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        public string GetUserId => _contextAccessor.HttpContext?.User?.FindFirst("sub")?.Value ?? throw new UnauthorizedAccessException("User is not authenticated");

    }
}
