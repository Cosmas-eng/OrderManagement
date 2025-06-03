using OrderManagement.Core.CustomerAggregate;

namespace OrderManagement.UnitTests.Core.CustomerAggregate;
public class CustomerConstructor
{
  private readonly string _testName = "John Doe";
  private Customer? _testCustomer;

  private Customer CreateCustomer()
  {
    return new Customer(_testName);
  }

  [Fact]
  public void InitializesCustomer()
  {
    _testCustomer = CreateCustomer();
    Assert.Equal(CustomerSegment.Regular, _testCustomer.Segment);
    Assert.Equal(_testName, _testCustomer.Name);
  }
}
