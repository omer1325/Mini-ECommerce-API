using MediatR;

namespace ECommerceAPI.Application.Features.Queries.Order.GetAllOrder
{
    public class GetAllOrdersQueryRequest : IRequest<GetAllOrdersQueryRespond>
    {
        public int Page { get; set; } = 0;
        public int Size { get; set; } = 5;
    }
}
