using AutoMapper;
using RDIDigitalTest.Application.Interfaces;
using RDIDigitalTest.Application.TransferObjects.CostumerCard;
using RDIDigitalTest.Application.TransferObjects.Token;
using RDIDigitalTest.Domain.Core.Interfaces.Service;
using RDIDigitalTest.Domain.DTOs;
using RDIDigitalTest.Domain.Entities.CostumerCard;
using RDIDigitalTest.Domain.Services.Validators;
using System;
using System.Collections.Generic;
using System.Text;

namespace RDIDigitalTest.Application.ApplicationServices
{
    public class CostumerCardApplicationService : ICostumerCardApplicationService
    {
        private readonly ICostumerCardService costumerCardService;
        private readonly IMapper mapper;

        public CostumerCardApplicationService(ICostumerCardService costumerCardService, IMapper mapper)
        {
            this.costumerCardService = costumerCardService;
            this.mapper = mapper;
        }

        public ResponseCostumerCardTO Add(CostumerCardTO costumerCardTO)
        {
            var costumerCard = mapper.Map<CostumerCard>(costumerCardTO);

            costumerCardService.Add<CostumerCardValidator>(costumerCard);

            var costumerCardResponse = mapper.Map<ResponseCostumerCardTO>(costumerCard);

            return costumerCardResponse;
        }

        public IEnumerable<ResponseCostumerCardTO> GetAll()
        {
            return mapper.Map<List<ResponseCostumerCardTO>>(costumerCardService.GetAll());
        }

        public ResponseCostumerCardTO GetById(int id)
        {
            return mapper.Map<ResponseCostumerCardTO>(costumerCardService.GetById(id));
        }

        public void Remove(CostumerCardTO costumerCardTO)
        {
            throw new NotImplementedException();
        }

        public void Update(CostumerCardTO costumerCardTO)
        {
            throw new NotImplementedException();
        }

        public ResponseTokenTO isValidToken(TokenTO tokenTO)
        {
            bool isValid = costumerCardService.isValidToken(tokenTO.CostumerId, tokenTO.CardId, tokenTO.Token, tokenTO.CVV);

            if (isValid)
            {
                return new ResponseTokenTO(true);
            }

            return new ResponseTokenTO(false);
        }
    }
}
