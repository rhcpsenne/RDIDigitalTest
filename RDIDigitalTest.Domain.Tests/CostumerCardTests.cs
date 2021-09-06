using RDIDigitalTest.Domain.Entities.CostumerCard;
using System;
using Xunit;

namespace RDIDigitalTest.Domain.Tests
{
    public class CostumerCardTests
    {
        private readonly CostumerCard costumerCard;

        public CostumerCardTests()
        {
            costumerCard = new CostumerCard(1, 1234567891234567, 3, DateTime.UtcNow);
        }

        [Fact]
        public void GetCostumerCardToken()
        {
            //Act
            var token = costumerCard.GetCostumerCardToken();

            //Assert
            Assert.Equal(5674, token);
        }
    }
}
