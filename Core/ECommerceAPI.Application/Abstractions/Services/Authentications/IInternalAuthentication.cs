﻿namespace ECommerceAPI.Application.Abstractions.Services.Authentications
{
    public interface IInternalAuthentication
    {
        Task<DTOs.Token> LoginAsync(string userNameOrEmail, string password, int accessTokenLifeTime);
    }
}
