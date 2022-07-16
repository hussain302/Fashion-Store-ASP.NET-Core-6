using FashionStore.Data.Products;
using FashionStore.Model.Models;


namespace FashionStore.Mappers.OrderMappers
{
    public static class OrderStatusMapper
    {
        public static OrderStatusModel ConvertToWebModel(this OrderStatus source)
        {
            return new OrderStatusModel
            {
                Id = source.Id,
                Name = source.Name,
            };
        }
        public static OrderStatus ConvertToDomainModel(this OrderStatusModel source)
        {
            return new OrderStatus
            {
                Id = source.Id,
                Name = source.Name,
            };
        }

    }
}
