using FluentAssertions;
using WebApp.Domain;
using Xunit;

namespace Domain.Tests;

public class CarTests
{

    [Fact]
    public void Should_not_update_properties_with_null_value()
    {
        var sut = Car.Create("Audi", "R8", 2018, 2, "Red", 79995);

        sut.Update(string.Empty, string.Empty, 0, 0, string.Empty, 0);

        sut.Should().BeEquivalentTo(Car.Create("Audi", "R8", 2018, 2, "Red", 79995));
    }

}