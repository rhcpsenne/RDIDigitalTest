using RDIDigitalTest.Domain.Core.Interfaces.Repository;
using RDIDigitalTest.Domain.Entities.CostumerCard;
using RDIDigitalTest.Infrastructure.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace RDIDigitalTest.Infrastructure.Data.Repository
{
    public class CostumerCardRepository : BaseRepository<CostumerCard>, ICostumerCardRepository
    {
        private readonly LocalDbContext localDbContext;

        public CostumerCardRepository(LocalDbContext localDbContext) : base(localDbContext)
        {
            this.localDbContext = localDbContext;
        }
    }
}
