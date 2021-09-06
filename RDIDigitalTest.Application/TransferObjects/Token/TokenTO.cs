using System;
using System.Collections.Generic;
using System.Text;

namespace RDIDigitalTest.Application.TransferObjects.Token
{
    /// <summary>
    /// Received transfer object for Token validation
    /// </summary>
    public class TokenTO
    {
        public int CostumerId { get; set; }
        public int CardId { get; set; }
        public long Token { get; set; }
        public int CVV { get; set; }
    }
}
