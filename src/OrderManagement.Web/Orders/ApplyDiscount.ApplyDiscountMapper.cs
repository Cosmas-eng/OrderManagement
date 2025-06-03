using OrderManagement.UseCases.Orders;

namespace OrderManagement.Web.Orders;

public class ApplyDiscountMapper : Mapper<ApplyDiscountRequest, DefaultOrderResponse, OrderDTO>
{
  public override DefaultOrderResponse FromEntity(OrderDTO e) => e.MapResponse();
}
