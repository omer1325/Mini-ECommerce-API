﻿using EcommerceAPI.SignalR.Hubs;
using Microsoft.AspNetCore.Builder;

namespace EcommerceAPI.SignalR
{
    public static class HubRegistration
    {
        public static void MapHubs(this WebApplication webApplication)
        {
            webApplication.MapHub<ProductHub>("/product-hubs");
        }
    }
}
