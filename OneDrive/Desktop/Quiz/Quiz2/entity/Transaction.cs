namespace Quiz2.entity
{
    public class Transaction1
    {
        public int TransactionId { get; set; }
        public string SourceCardNumber { get; set; }
        public string DestinationCardNumber { get; set; }
        public float Amount { get; set; }
        public DateTime TransactionDate { get; set; }
        public bool IsSuccessful { get; set; } = true;
        public Card FirstCard { get; set; }
        public int FirstCardId { get; set; }
        public Card LastCard { get; set; }
        public int LastCardId { get; set; }

    }
}
