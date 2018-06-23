using System;
using System.IO;
using SpringHeroBank.controller;
using SpringHeroBank.entity;
using SpringHeroBank.utility;

namespace SpringHeroBank.view
{
    public class MainView
    {
        private static AccountController controller = new AccountController();
        

        public static void GenerateMenu()
        {
            while (true)
            {
                if (Program.currentLoggedIn == null)
                {
                    GenerateGeneralMenu();
                }
                else
                {
                    GenerateCustomerMenu();
                }
            }
        }
        
        private static void SearchHistory()
        {
            TransactionController transactionController = new TransactionController();
            while (true)
            {
                Console.WriteLine("Lich su giao dich");
                Console.WriteLine("-------------------");
                Console.WriteLine("1, Lich su 3 giao dich gan nhat");
                Console.WriteLine("2, Quay lai Menu");
                var choice = Utility.GetInt32Number();
                switch (choice)
                {
                    case 1:  
                        var listAccountNum = transactionController.GetTransactionsHistoryByAccountNum();
                        if (listAccountNum != null)
                        {
                            
                            foreach (var trans in listAccountNum)
                            {
                                trans.PrintTransactions();
                            }
                            Console.ReadLine();
                        }
                        else
                        {
                            Console.WriteLine("Khong thanh cong, vui long thu lai.");
                            Console.ReadLine();
                        }
                        break;
                    case 2:
                        GenerateCustomerMenu();
                        break;
                    default:
                        Console.WriteLine("Xin nhap lai lua chon: ");
                        break;
                }
            }
        }

        

        private static void GenerateCustomerMenu()
        {
            while (true)
            {
                Console.WriteLine("---------SPRING HERO BANK---------");
                Console.WriteLine("Welcome back: " + Program.currentLoggedIn.FullName);
                Console.WriteLine("1. Balance.");
                Console.WriteLine("2. Withdraw.");
                Console.WriteLine("3. Deposit.");
                Console.WriteLine("4. Transfer.");
                Console.WriteLine("5. Transaction History.");
                Console.WriteLine("6. Exit.");
                Console.WriteLine("---------------------------------------------");
                Console.WriteLine("Please enter your choice (1|2|3|4|5|6): ");
                var choice = Utility.GetInt32Number();
                switch (choice)
                {
                    case 1:
                        controller.CheckBalance();
                        break;
                    case 2:
                        controller.Withdraw();
                        break;
                    case 3:
                        controller.Deposit();
                        break;
                    case 4:
                        controller.Transfer();
                        break;
                    case 5:
                        SearchHistory();
                        break;
                    case 6:
                        Console.WriteLine("See you later.");
                        Environment.Exit(1);
                        break;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
        }

        private static void GenerateGeneralMenu()
        {
            while (true)
            {
                Console.WriteLine("---------WELCOME TO SPRING HERO BANK---------");
                Console.WriteLine("1. Register for free.");
                Console.WriteLine("2. Login.");
                Console.WriteLine("3. Exit.");
                Console.WriteLine("---------------------------------------------");
                Console.WriteLine("Please enter your choice (1|2|3): ");                
                var choice = Utility.GetInt32Number();
                switch (choice)
                {
                    case 1:
                        controller.Register();
                        break;
                    case 2:
                        if (controller.DoLogin())
                        {
                            Console.WriteLine("Login success.");
                        }

                        break;
                    case 3:
                        Console.WriteLine("See you later.");
                        Environment.Exit(1);
                        break;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }

                if (Program.currentLoggedIn != null)
                {
                    break;
                }
            }
        }
        
    }
}