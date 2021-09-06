using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Moq;
using RDIDigitalTest.Domain.Core.Interfaces.Repository;
using RDIDigitalTest.Domain.Core.Interfaces.Service;
using RDIDigitalTest.Domain.Entities.CostumerCard;
using RDIDigitalTest.Infrastructure.Data.Context;
using System;
using Xunit;

namespace RDIDigitalTest.Domain.Services.Tests
{
    public class CostumerCardServiceTests
    {
        private readonly CostumerCardService costumerCardService;
        private readonly CostumerCard costumerCard;

        public CostumerCardServiceTests()
        {
            string dir = AppDomain.CurrentDomain.BaseDirectory;

            costumerCard = new CostumerCard(1, 1, 1234567891234567, 3, DateTime.UtcNow);
            costumerCardService = new CostumerCardService(new Mock<ICostumerCardRepository>().Object);

            var builder = new DbContextOptionsBuilder<LocalDbContext>();
            builder.UseSqlite($"Data Source=C:\\Users\\Lucas\\source\\repos\\RDIDigitalTest.Database\\Database\\RDIDigitalTest.db");
        }

        [Fact]
        public void ValidatedToken()
        {
            //Act
            var isValid = costumerCardService.isValidToken(costumerCard.CostumerId, costumerCard.Id, costumerCard.GetCostumerCardToken(), costumerCard.CVV);

            //Assert
            Assert.True(isValid);
        }
    }
}
