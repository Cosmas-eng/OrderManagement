using OrderManagement.UseCases.Orders;

namespace OrderManagement.Web.Orders;

public class UpdateOrderStatusMapper : Mapper<UpdateOrderStatusRequest, DefaultOrderResponse, OrderDTO>
{
  public override DefaultOrderResponse FromEntity(OrderDTO e) => e.MapResponse();
}
