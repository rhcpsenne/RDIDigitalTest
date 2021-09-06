using System;
using System.Collections.Generic;
using System.Text;

namespace RDIDigitalTest.Application.TransferObjects.Token
{
    /// <summary>
    /// Response object of Token data
    /// </summary>
    public class ResponseTokenTO
    {
        public ResponseTokenTO(bool validated)
        {
            Validated = validated;
        }

        public bool Validated { get; set; }
    }
}
