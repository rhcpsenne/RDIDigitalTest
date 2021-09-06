using RDIDigitalTest.Domain.Core.Interfaces.Repository;
using RDIDigitalTest.Domain.Core.Interfaces.Service;
using RDIDigitalTest.Domain.Entities.CostumerCard;
using System;
using System.Collections.Generic;
using System.Text;

namespace RDIDigitalTest.Domain.Services
{
    public class CostumerCardService : BaseService<CostumerCard>, ICostumerCardService
    {
        private readonly ICostumerCardRepository costumerCardRepository;

        public CostumerCardService(ICostumerCardRepository costumerCardRepository) : base(costumerCardRepository)
        {
            this.costumerCardRepository = costumerCardRepository;
        }

        public bool isValidToken(int costumerId, int cardId, long token, int cvv)
        {
            var cardObj = costumerCardRepository.GetById(cardId);

            if(cardObj != null)
            {
                if(cardObj.CostumerId == costumerId && cardObj.GetCostumerCardToken() == token  && (DateTime.UtcNow - cardObj.RegistrationDate).TotalMinutes <= 30)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
