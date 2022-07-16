using FashionStore.Data.Products;
using FashionStore.Model.Models;

namespace FashionStore.Mappers.OrderMappers
{
    public static class OrderMapper
    {

        //#region Cart To Order Mapper
        //public static Order ConvertToWebModel(this CartItemModel source)
        //{
        //    return new Order
        //    {
        //        Id = source.ItemId,
        //        Name = source.Title,

        //    };
        //}
        //#endregion

        #region Order Mappers DB and Web
        public static OrderModel ConvertToWebModel(this Order source)
        {
            return new OrderModel
            {
                Id = source.Id,
                Name = source.Name,
                Description = source.Description,
                ExpectedDeliveryDate = source.ExpectedDeliveryDate,
                OrderAssignedDate = source.OrderAssignedDate,
                StatusId = source.StatusId,
            };
        }

        public static Order ConvertToDomainModel(this CartItemModel source)
        {
            return new Order
            {     
                Name = source.Title,
                TotalPrice = source.ItemPrice,
                UserName = source.UserName,
                Phone = source.Phone,
            };
        }

        #endregion
    }
}
