using System.ComponentModel.DataAnnotations;

namespace BSynchro_RJP.Models.Entities
{
    public class UserAccount
    {
        //this class is created for account related information because I think that the user and the account have too much information (in the future) to be in one class
        //The transactions will be related to the account instead of the user since it makes sence that the transactions are not shared between accounts and each account has his
        //own transactions
        //The relations between models can be configured by EF automatically by adding certain properties OR by using data annotations OR
        //by defining them manually
        [Key]
        public int Id { get; set; }
        public List<AccountTransaction>? Transactions { get; set; }
        public int UserId { get; set; }
        public double Balance { get; set; }
    }
}
