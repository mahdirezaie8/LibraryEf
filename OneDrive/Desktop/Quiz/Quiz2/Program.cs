using Quiz2.Contact.IService;
using Quiz2.entity;
using Quiz2.Extensions;
using Quiz2.Services;
ICardService cardService=new CardService();
ITrandsactionService trandsactionService=new TrandsactionService();
Card card = null;
do
{
    Console.Clear();
    Console.WriteLine("enter cardnumber");
    string cardnumber = Console.ReadLine();
    Console.WriteLine("enter password");
    string password= Console.ReadLine();
    try
    {
        card = cardService.login(cardnumber,password);
    }
    catch(Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
    Console.ReadKey();
}
while (card == null);
int number = 0;
do
{
    Console.Clear();
    Console.WriteLine("1.trasfer");
    Console.WriteLine("2.show list tract");
    Console.Write("which one");
    number=int.Parse(Console.ReadLine());
    switch(number)
    {
        case 0:
            Console.Clear();
            Console.WriteLine("exit");
                Console.ReadKey();
            break;
            case 1:
            Console.Clear();
            Console.WriteLine("enter DestinationCardNumber:");
            string CardNumber= Console.ReadLine();
            Console.WriteLine("enter amount");
            float amount=float.Parse(Console.ReadLine());
            try
            {
                trandsactionService.Transfer(card.CardNumber, CardNumber, amount);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadKey();
            break;
            case 2:
            Console.Clear();
            try
            {
                var transaction = trandsactionService.GetAllTransactionUser(card.CardNumber);
                ConsolePainter.WriteTable(transaction);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadKey ();
            break;
    }
    
}
while (number>0);