namespace OrderManagement.Core.CustomerAggregate;
public class CustomerSegment : SmartEnum<CustomerSegment>
{
  public static readonly CustomerSegment Regular = new(nameof(Regular), 1);
  public static readonly CustomerSegment Silver = new(nameof(Silver), 2);
  public static readonly CustomerSegment Gold = new(nameof(Gold), 3);
  public static readonly CustomerSegment Platinum = new(nameof(Platinum), 4);
  protected CustomerSegment(string name, int value) : base(name, value)
  {
  }
}
