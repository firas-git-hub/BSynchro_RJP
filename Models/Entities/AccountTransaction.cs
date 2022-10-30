using System.ComponentModel.DataAnnotations;

namespace BSynchro_RJP.Models.Entities
{
    //I have decided to make a transactions model because I would like to save them (as requested in the requirements) as structured controllable data instead of numbers
    //and they might get more complicated along the way.
    public class AccountTransaction
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public double Amount { get; set; }
        public int AccountId { get; set; }
    }
}
