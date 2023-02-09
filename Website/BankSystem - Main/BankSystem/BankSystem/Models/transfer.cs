namespace BankSystem.Models
{
    public class transfer
    {
        public string AccountNumber { get; set; }
        public string CUSIP { get; set; }
        public string AccountHolder { get; set; }
        public float Amount { get; set; }
    }
}