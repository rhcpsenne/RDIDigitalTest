using RDIDigitalTest.Domain.Core.Interfaces.Repository;
using RDIDigitalTest.Domain.Entities.CostumerCard;
using System;
using Xunit;

namespace RDIDigitalTest.Infrastructure.Tests
{
    public class CostumerCardRepositoryTests
    {
        private readonly ICostumerCardRepository costumerCardRepository;
        private readonly CostumerCard costumerCard;

        public CostumerCardRepositoryTests()
        {
            costumerCard = new CostumerCard(2, 1234567891234567, 1, DateTime.UtcNow);
        }

        [Fact]
        public void AddNewCostumerCard()
        {
            //Act
            costumerCardRepository.Add(costumerCard);
            var costumerCardFromDb = costumerCardRepository.GetById(costumerCard.Id);

            //Assert
            Assert.NotNull(costumerCardFromDb);
        }
    }
}
