using System;
using System.Collections.Generic;
using System.Text;

namespace RDIDigitalTest.Application.TransferObjects.CostumerCard
{
    /// <summary>
    /// Response object of CostumerCard data
    /// </summary>
    public class ResponseCostumerCardTO
    {
        public int CardId { get; set; }
        public long Token { get; set; }
        public DateTime RegisteringDate { get; set; }
    }
}
