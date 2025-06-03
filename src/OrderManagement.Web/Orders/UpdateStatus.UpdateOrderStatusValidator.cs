using FluentValidation;

namespace OrderManagement.Web.Orders;

public class UpdateOrderStatusValidator : Validator<UpdateOrderStatusRequest>
{
  public UpdateOrderStatusValidator()
  {
    RuleFor(x => x.OrderId).NotNull().WithMessage("OrderId is required.");
    RuleFor(x => x.Status)
      .NotEmpty()
      .WithMessage("Status is required.")
      .Must(status => status == "Pending" || status == "Confirmed" || status == "Shipped" || status == "Delivered" || status == "Cancelled")
      .WithMessage("Status must be one of the following: Pending, Confirmed, Shipped, Delivered, Cancelled.");
  }
}
