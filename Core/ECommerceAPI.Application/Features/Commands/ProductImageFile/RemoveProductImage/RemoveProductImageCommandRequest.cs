using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceAPI.Application.Features.Commands.ProductImageFile.RemoveProductImage
{
    public class RemoveProductImageCommandRequest : IRequest<RemoveProductImageCommandResponse>
    {
        public string Id { get; set; }
        [FromQuery]
        public string? ImageId { get; set; }
    }
}
