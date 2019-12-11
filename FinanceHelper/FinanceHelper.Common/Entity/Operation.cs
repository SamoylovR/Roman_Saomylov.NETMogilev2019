using System.ComponentModel.DataAnnotations;

namespace FinanceHelper.Common.Entity
{
    public class Operation
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public double Sum { get; set; }

        public string Name { get; set; }

        public bool IsOperationIncome { get; set; }
    }
}
