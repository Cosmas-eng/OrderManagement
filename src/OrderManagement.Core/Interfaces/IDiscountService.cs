using OrderManagement.Core.CustomerAggregate;
using OrderManagement.Core.OrderAggregate;

namespace OrderManagement.Core.Interfaces;
/// <summary>
/// Defines a service for calculating discounts based on an order and customer information.
/// </summary>
/// <remarks>Implementations of this interface should provide logic to determine the appropriate discount for a
/// given order and customer. The discount calculation may depend on factors such as customer loyalty, order size, or
/// promotional rules.</remarks>
public interface IDiscountService
{
  decimal CalculateDiscount(Order order, Customer customer);
}
