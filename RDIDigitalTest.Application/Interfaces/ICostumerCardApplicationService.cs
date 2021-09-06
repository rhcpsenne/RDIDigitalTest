using RDIDigitalTest.Application.TransferObjects.CostumerCard;
using RDIDigitalTest.Application.TransferObjects.Token;
using RDIDigitalTest.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace RDIDigitalTest.Application.Interfaces
{
    public interface ICostumerCardApplicationService
    {
        ResponseCostumerCardTO Add(CostumerCardTO costumerCardTO);

        void Update(CostumerCardTO costumerCardTO);

        void Remove(CostumerCardTO costumerCardTO);

        IEnumerable<ResponseCostumerCardTO> GetAll();

        ResponseCostumerCardTO GetById(int id);

        ResponseTokenTO isValidToken(TokenTO tokenTO);
    }
}
