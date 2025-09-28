using Library3.Contracts.IServices;
using Library3.Enums;
using Library3.Extensions;
using Library3.ntts;
using Library3.Servises;

IUserServise userServise = new UserServise();
ICategoryService categoryService = new CategoryService();
IBookService bookService = new BookService();
IBorrowedBookService borrowedBookService = new BorrowedBookService();
IReviewService reviewService = new ReviewService();
IWishListService wishService = new WishListService();
User user = null;
bool a = true;
while (a)
{
    do
    {
        Console.Clear();
        Console.WriteLine("0.exit");
        Console.WriteLine("1.login");
        Console.WriteLine("2.Register");
        Console.Write("which one?");
        int number = int.Parse(Console.ReadLine());
        switch (number)
        {
            case 0:
                Environment.Exit(0);
                break;
            case 1:
                Console.Clear();
                Console.WriteLine("enter username");
                string username = Console.ReadLine();
                Console.WriteLine("enter password");
                string password = Console.ReadLine();
                try
                {
                    user = userServise.Login(username, password);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                Console.ReadKey();
                break;
            case 2:
                Console.Clear();
                Console.WriteLine("enter username");
                username = Console.ReadLine();
                Console.WriteLine("enter password");
                password = Console.ReadLine();
                Console.WriteLine("enter name");
                string name = Console.ReadLine();
                Console.WriteLine("enter lastname");
                string lastname = Console.ReadLine();
                Console.WriteLine("enter email");
                string email = Console.ReadLine();
                Console.WriteLine("Role: 0.admin 1.user");
                int role = int.Parse(Console.ReadLine());
                RoleEnum roleEnum = (RoleEnum)role;
                try
                {
                    userServise.Register(username, password, name, lastname, email, roleEnum);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                Console.ReadKey();
                break;
            default:
                Console.Clear();
                Console.WriteLine("please enter true number");
                Console.ReadKey();
                break;
        }
    }
    while (user == null);
    int number1 = 0;
    do
    {
        if (user.Role == RoleEnum.user)
        {
            Console.Clear();
            Console.WriteLine("0.exit");
            Console.WriteLine("1.see the list of category and books");
            Console.WriteLine("2.borrowing books");
            Console.WriteLine("3.view the list of books you have borrowed");
            Console.WriteLine("4.write review for book");
            Console.WriteLine("5.edit comment");
            Console.WriteLine("6.delete comment");
            Console.WriteLine("7.add book to your wishlist");
            Console.WriteLine("8.show wishlist");
            Console.WriteLine("9.delete wishlist");
            Console.WriteLine("10.Return book");
            Console.WriteLine("11.show profile");
            Console.Write("which one?");
            number1 = int.Parse(Console.ReadLine());
            switch (number1)
            {
                case 0:
                    number1 = 0;
                    Console.WriteLine("exit");
                    Console.ReadKey();
                    break;
                case 1:
                    Console.Clear();
                    var categories = categoryService.GetCategories();
                    ConsolePainter.WriteTable(categories);
                    Console.Write("which category name?");
                    string categoryname = Console.ReadLine().ToLower();
                    try
                    {
                        var books = bookService.GetAllBooks(categoryname);
                        foreach (var book in books)
                        {
                            if (book.comment.Count > 0)
                            {
                                foreach (var com in book.comment)
                                {
                                    Console.WriteLine($"bookName:{book.Name} - CategoryName:{book.CategoryName} - Author:{book.Author} - Year Of Publication:{book.YearOfPublication}" +
                                        $" - cemment:{com} - Rating:{book.Rating} - count wishlist:{book.counWishList}");
                                }
                            }
                            if (book.comment.Count == 0)
                            {
                                Console.WriteLine($"bookName:{book.Name} - CategoryName:{book.CategoryName} - Author:{book.Author} - Year Of Publication:{book.YearOfPublication}" +
                                    $" - comment:null - Rating:{book.Rating} - count wishlist:{book.counWishList}");
                            }
                        }

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    Console.ReadKey();
                    break;
                case 2:
                    Console.Clear();
                    Console.WriteLine("enter book id");
                    int bookid = int.Parse(Console.ReadLine());
                    try
                    {
                        borrowedBookService.CreateBorrowed(bookid, user);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    Console.ReadKey();
                    break;
                case 3:
                    Console.Clear();
                    try
                    {
                        var borrowed1 = borrowedBookService.GetAllBorrowedBooksUser(user);
                        ConsolePainter.WriteTable(borrowed1);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    Console.ReadKey();
                    break;
                case 4:
                    Console.Clear();
                    Console.WriteLine("enter book id");
                    int newbookid = int.Parse(Console.ReadLine());
                    Console.WriteLine("enter the rating");
                    int rating = int.Parse(Console.ReadLine());
                    Console.WriteLine("enter comment");
                    string comment = Console.ReadLine();
                    try
                    {
                        reviewService.CreateReview(user.Id, newbookid, rating, comment);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    Console.ReadKey();
                    break;
                case 5:
                    Console.Clear();
                    try
                    {
                        var listreview = reviewService.GetReviewsuser(user);
                        ConsolePainter.WriteTable(listreview);
                        Console.WriteLine("enter review id for edit");
                        int reviewid = int.Parse(Console.ReadLine());
                        Console.WriteLine("enter new comment");
                        string newcomment = Console.ReadLine();
                        reviewService.EditComments(user.Id, reviewid, newcomment);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    Console.ReadKey();
                    break;
                case 6:
                    Console.Clear();
                    try
                    {
                        var listreview = reviewService.GetReviewsuser(user);
                        ConsolePainter.WriteTable(listreview);
                        Console.WriteLine("enter review id for delete");
                        int reviewid1 = int.Parse(Console.ReadLine());
                        reviewService.DeleteComment(user.Id, reviewid1);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    Console.ReadKey();
                    break;
                    case 7:
                    Console.Clear();
                    Console.WriteLine("enter book id");
                    bookid=int.Parse(Console.ReadLine());
                    try
                    {
                        wishService.CreateWishlist(user, bookid);
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    Console.ReadKey();
                    break;
                    case 8:
                        Console.Clear();
                    try
                    {
                        var whishlist = wishService.ShowAllWishListUser(user);
                        ConsolePainter.WriteTable(whishlist);
                    }
                    catch( Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    Console.ReadKey();
                    break;
                    case 9:
                        Console.Clear();
                    Console.WriteLine("enter wishlist id for delete:");
                    int whishlistid=int.Parse(Console.ReadLine());
                    try
                    {
                        wishService.DeleteWishlist(whishlistid, user.Id);
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    Console.ReadKey();
                    break;
                    case 10:
                    Console.Clear();
                    Console.WriteLine("enter bookid");
                    int borrowed=int.Parse(Console.ReadLine());
                    try
                    {
                        borrowedBookService.ReturnBook(borrowed, user.Id);
                    }
                   catch(Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    Console.ReadKey();
                    break;
                    case 11:
                        Console.Clear();
                    var userp=userServise.ShowProfile(user);
                    Console.WriteLine($"UserID:{userp.Id} - FirstName:{userp.FirstName} - LastName:{userp.LastName} - PenaltyAmount:{userp.PenaltyAmount}");
                    Console.ReadKey();
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("please enter true number");
                    Console.ReadKey();
                    break;
            }

        }
        if (user.Role == RoleEnum.admin)
        {
            Console.Clear();
            Console.WriteLine("0.exit");
            Console.WriteLine("1.create category");
            Console.WriteLine("2.create book");
            Console.WriteLine("3.see the list of category and books");
            Console.WriteLine("4.edite Confirmation");
            Console.WriteLine("5.show all wishlist");
            Console.WriteLine("6.show all user");
            Console.Write("wich one?");
            number1 = int.Parse(Console.ReadLine());
            switch (number1)
            {
                case 0:
                  number1 = 0;
            Console.WriteLine("exit");
            Console.ReadKey();
            break;
                case 1:
                    Console.Clear();
                    Console.WriteLine("enter name");
                    string name = Console.ReadLine();
                    try
                    {
                        categoryService.CreateCategory(name);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    Console.ReadKey();
                    break;
                case 2:
                    Console.Clear();
                    Console.WriteLine("enter name");
                    name = Console.ReadLine();
                    Console.WriteLine("enter authore");
                    string author = Console.ReadLine();

                    try
                    {
                        Console.WriteLine("enter year of publication");
                        int year = int.Parse(Console.ReadLine());
                        Console.WriteLine("enter category Id");
                        int categoryid = int.Parse(Console.ReadLine());
                        bookService.CreateBook(name, author, year, categoryid);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    Console.ReadKey();
                    break;
                case 3:
                    Console.Clear();
                    var categories = categoryService.GetCategories();
                    ConsolePainter.WriteTable(categories);
                    Console.Write("which category name?");
                    string categoryname = Console.ReadLine().ToLower();
                    try
                    {
                        var books = bookService.GetAllBooks(categoryname);
                        foreach (var book in books)
                        {
                            if (book.comment.Count > 0)
                            {
                                foreach (var com in book.comment)
                                {
                                    Console.WriteLine($"bookName:{book.Name} - CategoryName:{book.CategoryName} - Author:{book.Author} - Year Of Publication:{book.YearOfPublication}" +
                                        $" - cemment:{com} - Rating:{book.Rating} - count wishlist:{book.counWishList}");
                                }
                            }
                            if (book.comment.Count == 0)
                            {
                                Console.WriteLine($"bookName:{book.Name} - CategoryName:{book.CategoryName} - Author:{book.Author} - Year Of Publication:{book.YearOfPublication}" +
                                    $" - comment:null - Rating:{book.Rating} - count wishlist:{book.counWishList}");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    Console.ReadKey();
                    break;
                case 4:
                    Console.Clear();
                    try
                    {
                        var listreview = reviewService.GetReviewsConfirmation();
                        ConsolePainter.WriteTable(listreview);
                        Console.WriteLine("which comment do you want to confirm?");
                        int which = int.Parse(Console.ReadLine());
                        reviewService.EditConfirmation(which);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    Console.ReadKey();
                    break;
                    case 5:
                        Console.Clear();
                    try
                    {
                        var whishlist = wishService.ShowAllWishList();
                        ConsolePainter.WriteTable(whishlist);
                    }
                  catch(Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    Console.ReadKey();
                    break;
                    case 6:
                        Console.Clear();
                    var alluser=userServise.ShowAllUser();
                    ConsolePainter.WriteTable(alluser);
                    Console.ReadKey();
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("please enter true number");
                    Console.ReadKey();
                    break;

            }
        }
    }
    while (number1 > 0);
}