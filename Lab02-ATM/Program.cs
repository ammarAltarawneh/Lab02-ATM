namespace Lab02_ATM
{
    public class Program
    {
        public static decimal Balance = 0;
        public static List<string> Transactions = new List<string>();

        public static void Main()
        {
            try
            {
                UserInterface();
            }

            catch (Exception ex)
            {
                Console.WriteLine($"Something error: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("Everything is done, have a nice day!");
            }
        }

        public static void UserInterface()
        {
            while (true)
            {
                Console.WriteLine("Menu:\n");
                Console.WriteLine($"Your Balance now is {ViewBalance()}\n");
                Console.WriteLine("Please choose an option:\n");
                Console.WriteLine("1. Withdraw\n");
                Console.WriteLine("2. Deposit\n");
                Console.WriteLine("3. Exit\n");

                string x = Console.ReadLine();


                switch (x)
                {
                    case "1":

                        if (Balance == 0)
                        {
                            throw new Exception("Your Balance is 0 you cannot make a withdraw transactions!\n");
                        }
                        Console.WriteLine("Enter money amount to withdraw:");
                        decimal withdrawAmount;
                        if (decimal.TryParse(Console.ReadLine(), out withdrawAmount))
                        {
                            Balance = Withdraw(withdrawAmount);

                        }
                        else
                        {
                            Console.WriteLine("Invalid amount. Please try again.\n");
                        }
                        break;
                    case "2":
                        Console.WriteLine("Enter money amount to deposit:");
                        decimal depositAmount;
                        if (decimal.TryParse(Console.ReadLine(), out depositAmount))
                        {
                            Balance = Deposit(depositAmount);

                        }
                        else
                        {
                            Console.WriteLine("Invalid amount. Please try again.");
                        }
                        break;
                    case "3":
                        Console.WriteLine("Thank you for using our services! Do you want a receipt? Enter Y or N:\n");
                        while (true)
                        {
                            string option2 = Console.ReadLine().ToLower();


                            switch (option2)
                            {
                                case "y":
                                    GenerateReceipt();
                                    return;

                                case "n":
                                    return;

                                default:
                                    Console.WriteLine("Invalid option. Please try again.");
                                    break;
                            }

                        }

                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }

        public static decimal ViewBalance()
        {
            return Balance;
        }

        public static decimal Withdraw(decimal amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Invalid amount. Please enter a positive value.");
                return Balance;
            }
            else if (amount > Balance)
            {
                Console.WriteLine("you cannot withdraw amount bigger than your Balance!");
                return Balance;
            }
            else
            {
                Balance -= amount;
                RecordTransaction($"Withdraw -> {amount}");
                return Balance;
            }
        }

        public static decimal Deposit(decimal amount)
        {
            if (amount < 0)
            {
                Console.WriteLine("Invalid amount. Please enter a positive value.");
                return Balance;
            }
            else
            {
                Balance += amount;
                RecordTransaction($"Deposit -> {amount}");
                return Balance;
            }
        }

        public static void RecordTransaction(string transaction)
        {
            Transactions.Add(transaction);
        }

        public static void GenerateReceipt()
        {
            Console.WriteLine("******** RECEIPT ********");
            Console.WriteLine($"Current Balance: {ViewBalance()}");
            Console.WriteLine("All Transactions:\t");
            foreach (string transaction in Transactions)
            {
                Console.WriteLine(transaction);
            }
            Console.WriteLine("\n************************\n");
        }


    }
}