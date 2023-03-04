using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CreditCalculator.Models
{
    public class Payment
    {

        public int Id { get; set; }
        public DateTime DateTime { get; set; }

        public decimal PaymentOfTelo { get; set; }
        public decimal PaymentPercentage { get; set; }
        public decimal BalanceOwed { get; set; }
    }
}
