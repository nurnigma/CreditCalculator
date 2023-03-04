using System.ComponentModel.DataAnnotations;

namespace CreditCalculator.Models
{
    public class CreditTerms
    {
        [Required(ErrorMessage = "Не указан сумма")]
        public decimal Sum { get; set; }

        [Required(ErrorMessage = "Не указан срок")]
        public int Term { get; set; }

        [Required(ErrorMessage = "Не указан процент")]
        public decimal Rate { get; set; }

        [Required(ErrorMessage = "Не указан шаг платежа")]
        public int Step { get; set; } = 1;
        public CalculateType CalculateType { get; set; } = CalculateType.ByMonth;
    }
}
