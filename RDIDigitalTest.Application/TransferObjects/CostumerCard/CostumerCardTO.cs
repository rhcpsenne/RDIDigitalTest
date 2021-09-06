using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RDIDigitalTest.Domain.DTOs
{
    /// <summary>
    /// Received transfer object for CostumerCard db creation
    /// </summary>
    public class CostumerCardTO
    {
        public int CostumerId { get; set; }
        public long CardNumber { get; set; }
        public int CVV { get; set; }
    }
}
