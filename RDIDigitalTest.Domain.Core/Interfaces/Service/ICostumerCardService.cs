using RDIDigitalTest.Domain.Entities.CostumerCard;
using System;
using System.Collections.Generic;
using System.Text;

namespace RDIDigitalTest.Domain.Core.Interfaces.Service
{
    public interface ICostumerCardService : IBaseService<CostumerCard>
    {
        bool isValidToken(int costumerId, int cardId, long token, int cvv);
    }
}
