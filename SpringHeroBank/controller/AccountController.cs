using System;
using SpringHeroBank.entity;
using SpringHeroBank.model;
using SpringHeroBank.utility;
using SpringHeroBank.view;

namespace SpringHeroBank.controller
{
    public class AccountController
    {
        private AccountModel model = new AccountModel();

        public void Register()
        {
            Console.WriteLine("Please enter account information");
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("Username: ");
            var username = Console.ReadLine();
            Console.WriteLine("Password: ");
            var password = Console.ReadLine();
            Console.WriteLine("Confirm Password: ");
            var cpassword = Console.ReadLine();
            Console.WriteLine("Identity Card: ");
            var identityCard = Console.ReadLine();
            Console.WriteLine("Full Name: ");
            var fullName = Console.ReadLine();
            Console.WriteLine("Email: ");
            var email = Console.ReadLine();
            Console.WriteLine("Phone: ");
            var phone = Console.ReadLine();
            var account = new Account(username, password, cpassword, identityCard, phone, email, fullName);
            var errors = account.CheckValid();
            if (errors.Count == 0)
            {
                model.Save(account);
                Console.WriteLine("Register success!");
                Console.ReadLine();
            }
            else
            {
                Console.Error.WriteLine("Please fix following errors and try again.");
                foreach (var messagErrorsValue in errors.Values)
                {
                    Console.Error.WriteLine(messagErrorsValue);
                }

                Console.ReadLine();
            }
        }

        public Boolean DoLogin()
        {
            // Lấy thông tin đăng nhập phía người dùng.
            Console.WriteLine("Please enter account information");
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("Username: ");
            var username = Console.ReadLine();
            Console.WriteLine("Password: ");
            var password = Console.ReadLine();
            var account = new Account(username, password);
            // Tiến hành validate thông tin đăng nhập. Kiểm tra username, password khác null và length lớn hơn 0.
            var errors = account.ValidLoginInformation();
            if (errors.Count > 0)
            {
                Console.WriteLine("Invalid login information. Please fix errors below.");
                foreach (var messagErrorsValue in errors.Values)
                {
                    Console.Error.WriteLine(messagErrorsValue);
                }

                Console.ReadLine();
                return false;
            }

            account = model.GetAccountByUserName(username);
            if (account == null)
            {
                // Sai thông tin username, trả về thông báo lỗi không cụ thể.
                Console.WriteLine("Invalid login information. Please try again.");
                return false;
            }

            // Băm password người dùng nhập vào kèm muối và so sánh với password đã mã hoá ở trong database.
            if (account.Password != Hash.GenerateSaltedSHA1(password, account.Salt))
            {
                // Sai thông tin password, trả về thông báo lỗi không cụ thể.
                Console.WriteLine("Invalid login information. Please try again.");
                return false;
            }

            // Login thành công. Lưu thông tin đăng nhập ra biến static trong lớp Program.
            Program.currentLoggedIn = account;
            return true;
        }

        public void Withdraw()
        {
            Console.WriteLine("Withdraw.");
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Nhap so tien can rut: ");
            var amount = Utility.GetUnsignDecimalNumber();
            if (!(Program.currentLoggedIn.Balance >= amount))
            {
                Console.WriteLine("Khong du tien trong tai khoan");
                Console.ReadLine();
            }
            else
            {
                var historyTransaction = new Transaction
                {
                    Id = Guid.NewGuid().ToString(),
                    Type = Transaction.TransactionType.WITHDRAW,
                    Amount = amount,
                    Content = "Rut Tien",
                    SenderAccountNumber = Program.currentLoggedIn.AccountNumber,
                    ReceiverAccountNumber = Program.currentLoggedIn.AccountNumber,
                    CreatedAt = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                    Status = Transaction.ActiveStatus.DONE
                };
                if (model.UpdateBalance(Program.currentLoggedIn, historyTransaction))
                {
                    Console.WriteLine("Giao Dich Thanh Cong");
                }
                else
                {
                    Console.WriteLine("Giao dich loi, vui long thu lai!");
                }
                Program.currentLoggedIn = model.GetAccountByUserName(Program.currentLoggedIn.Username);
                Console.WriteLine("Current balance: " + Program.currentLoggedIn.Balance);
                Console.WriteLine("Press enter to continue!");
                Console.ReadLine();
            }
        }

        public void Deposit()//chưa xịn
        {

            Console.WriteLine("Deposit.");
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Please enter amount to deposit: ");
            var amount = Utility.GetUnsignDecimalNumber();
            Console.WriteLine("Please enter message content: ");
            var content = Console.ReadLine();
            var historyTransaction = new Transaction
            {
                Id = Guid.NewGuid().ToString(),
                Type = Transaction.TransactionType.DEPOSIT,
                Amount = amount,
                Content = content,
                SenderAccountNumber = Program.currentLoggedIn.AccountNumber,
                ReceiverAccountNumber = Program.currentLoggedIn.AccountNumber,
                CreatedAt = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                Status = Transaction.ActiveStatus.DONE
            };
            if (model.UpdateBalance(Program.currentLoggedIn, historyTransaction))
            {
                Console.WriteLine("Transaction success!");
            }
            else
            {
                Console.WriteLine("Transaction fails, please try again!");
            }
            Program.currentLoggedIn = model.GetAccountByUserName(Program.currentLoggedIn.Username);
            Console.WriteLine("Current balance: " + Program.currentLoggedIn.Balance);
            Console.WriteLine("Press enter to continue!");
            Console.ReadLine();
        }

        public void Transfer()
        {
            
            Account account = new Account();
            Console.WriteLine("Transfer.");
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Nhap thong tin so tai khoan duoc huong!");
            Console.WriteLine("1, So tai khoan duoc huong");
            var stk_nguoinhan = Console.ReadLine();
            account = model.GetAccountByAccountNum(stk_nguoinhan);
            Console.WriteLine("Thong tin tai khoan: {0}",account.AccountNumber);
            Console.WriteLine("Ho va Ten: {0}", account.FullName);
            
            Console.WriteLine("2, So tien can gui: ");
            var soTien = Utility.GetUnsignDecimalNumber();
            if(!(Program.currentLoggedIn.Balance >= soTien))
            {
                Console.WriteLine("Tai khoan ban khong du");
            }
            else
            {
                Console.WriteLine("3, Loi nhan: ");
                var loiNhan = Console.ReadLine();
                //Transaction
                var transaction = new Transaction()
                {
                    Id = Guid.NewGuid().ToString(),
                    Type = Transaction.TransactionType.TRANSFER,
                    Amount = soTien,
                    Content = loiNhan,
                    SenderAccountNumber = Program.currentLoggedIn.AccountNumber,
                    ReceiverAccountNumber = account.AccountNumber,
                    CreatedAt = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                    Status = Transaction.ActiveStatus.DONE
                };
                var choice = 0;
                Console.WriteLine("Ban co chac chan thuc hien giao dich nay ???");
                Console.WriteLine("1, Co");
                Console.WriteLine("2, Khong");
                Console.WriteLine("Lua chon cua ban: ");
                int.TryParse(Console.ReadLine(), out choice);
                if (choice == 1)
                {
                    if (model.UpdateBalanceTransfer(Program.currentLoggedIn, account, transaction))
                    {
                        Console.WriteLine("Chuyen tien thanh cong.");
                    }
                    else
                    {
                        Console.WriteLine("Chuyen tien that bai. Xin hay thu lai!");
                    }
                    Program.currentLoggedIn = model.GetAccountByUserName(Program.currentLoggedIn.Username);
                    Console.WriteLine("Tai khoan hien tai: " + Program.currentLoggedIn.Balance);
                    Console.WriteLine("Press enter to continue!");
                    
                }
                else
                {
                    Program.currentLoggedIn = model.GetAccountByUserName(Program.currentLoggedIn.Username);
                    Console.WriteLine("Tai khoan hien tai: " + Program.currentLoggedIn.Balance);
                    Console.WriteLine("Press enter to continue!");
                    
                } 
            }
            Console.ReadLine();
            
            
        }

        public void CheckBalance() // Dịch bởi Phúc.
        {
            Program.currentLoggedIn = model.GetAccountByUserName(Program.currentLoggedIn.Username);
            Console.WriteLine("Account Information");
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Full name: " + Program.currentLoggedIn.FullName);
            Console.WriteLine("Account number: " + Program.currentLoggedIn.AccountNumber);
            Console.WriteLine("Balance: " + Program.currentLoggedIn.Balance);
            Console.WriteLine("Press enter to continue!");
            Console.ReadLine();
        }
    }
}