using System.ComponentModel.DataAnnotations;

namespace BSynchro_RJP.Models.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        public List<UserAccount> Accounts { get; set; }
    }
}
