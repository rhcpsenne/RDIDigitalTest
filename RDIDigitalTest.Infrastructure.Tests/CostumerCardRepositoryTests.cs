using Microsoft.EntityFrameworkCore;
using RDIDigitalTest.Domain.Core.Interfaces.Repository;
using RDIDigitalTest.Domain.Entities.CostumerCard;
using RDIDigitalTest.Infrastructure.Data.Context;
using RDIDigitalTest.Infrastructure.Data.Repository;
using System;
using Xunit;

namespace RDIDigitalTest.Infrastructure.Tests
{
    public class CostumerCardRepositoryTests
    {
        private readonly CostumerCardRepository costumerCardRepository;
        private readonly CostumerCard costumerCard;

        public CostumerCardRepositoryTests()
        {
            var localDb = new LocalDbContext();

            costumerCard = new CostumerCard(2, 1234567891234567, 1, DateTime.UtcNow);
            costumerCardRepository = new CostumerCardRepository(localDb);
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
