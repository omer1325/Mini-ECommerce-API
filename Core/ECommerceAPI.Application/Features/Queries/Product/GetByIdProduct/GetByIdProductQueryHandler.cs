using ECommerceAPI.Application.Repositories;
using ECommerceAPI.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ECommerceAPI.Application.Features.Queries.Product.GetByIdProduct
{
    public class GetByIdProductQueryHandler : IRequestHandler<GetByIdProductQueryRequest, GetByIdProductQueryResponse>
    {
        readonly IProductReadRepository _productReadRepository;

        public GetByIdProductQueryHandler(IProductReadRepository productReadRepository)
        {
            _productReadRepository = productReadRepository;
        }

        public async Task<GetByIdProductQueryResponse> Handle(GetByIdProductQueryRequest request, CancellationToken cancellationToken)
        {
            //var product = await _productReadRepository.GetByIdAsync(request.Id, false);

            var product = _productReadRepository.Table.Include(p => p.ProductImageFiles).Where(p => p.Id == Guid.Parse(request.Id)).Select( p => new 
            {
                p.Name,
                p.Stock,
                p.Price,
                p.ProductImageFiles
            });

            //var photos2 = photos.ToList();
            //product.ProductImageFiles = photos2;
             
            return new( )
            {
                Product = product,
            };
        }
    }
}
