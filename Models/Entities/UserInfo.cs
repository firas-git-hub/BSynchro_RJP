namespace BSynchro_RJP.Models.Entities
{
    public class UserInfo
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public List<UserAccount> AccountList { get; set; }
        public double TotalBalance { get; set; }
    }
}
