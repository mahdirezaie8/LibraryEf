namespace Quiz2.entity
{
    public class Card
    {
        public int Id { get; set; }
        public string CardNumber { get; set; }
        public string HolderName { get; set; }
        public float Balance { get; set; }
        public bool IsActive { get; set; } = true;
        public string Password { get; set; }
        public int FaildedAttempts { get; set; } = 0;
        public List<Transaction1> FirstTransactions { get; set; } = [];
        public List<Transaction1> lastTransactions { get; set; } = [];

    }
}
