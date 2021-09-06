using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace RDIDigitalTest.Domain.Entities.CostumerCard
{
    /// <summary>
    /// CostumerCard model
    /// </summary>
    [Table("CostumerCard")]
    public class CostumerCard : Base
    {
        public CostumerCard(int costumerId, long cardNumber, int cVV, DateTime registrationDate)
        {
            CostumerId = costumerId;
            CardNumber = cardNumber;
            CVV = cVV;
            RegistrationDate = registrationDate;
        }

        public int CostumerId { get; set; }
        public long CardNumber { get; set; }
        public int CVV { get; set; }
        public DateTime RegistrationDate { get; set; }

        /// <summary>
        /// Method to generate token
        /// </summary>
        /// <returns>Token</returns>
        public long GetCostumerCardToken()
        {
            string cardNumberString = CardNumber.ToString();

            int[] array = Array.ConvertAll((cardNumberString.Substring(cardNumberString.Length - 4).ToCharArray()), c => (int)Char.GetNumericValue(c)); 

            return RotateCircularArray(array, this.CVV);
        }

        /// <summary>
        /// Perform the array rotation
        /// </summary>
        /// <param name="array"></param>
        /// <param name="cvv"></param>
        /// <returns>Token</returns>
        private long RotateCircularArray(int[] array, int cvv)
        {
            StringBuilder finalArray = new StringBuilder();
            int temp;

            for (int i = 0; i < cvv; i++)
            {
                for (int j = 0; j < array.Length - 1; j++)
                {
                    temp = array[0];
                    array[0] = array[j + 1];
                    array[j + 1] = temp;
                }
            }

            finalArray.Append(string.Join(string.Empty, array));

            return Convert.ToInt64(finalArray.ToString());
        }
    }
}
