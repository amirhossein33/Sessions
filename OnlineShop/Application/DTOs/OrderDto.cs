namespace OnlineShop.Application.DTOs
{
    public record OrderDto(Guid Id, Guid CustomerId, decimal TotalAmount);

}
