using System;
using System.IO;

namespace SpringHeroBank.entity
{
    public class Transaction
    {
        public enum ActiveStatus
        {
            PROCESSING = 1,
            DONE = 2,
            REJECT = 0,
            DELETED = -1,
        }

        public enum TransactionType
        {
            DEPOSIT = 1,
            WITHDRAW = 2,
            TRANSFER = 3
        }

        private string _id;
        private string _createdAt;
        private string _updatedAt;
        private TransactionType _type;
        private decimal _amount;
        private string _content;
        private string _senderAccountNumber;
        private string _receiverAccountNumber;
        private ActiveStatus _status;

        public string Id
        {
            get => _id;
            set => _id = value;
        }

        public string CreatedAt
        {
            get => _createdAt;
            set => _createdAt = value;
        }

        public string UpdatedAt
        {
            get => _updatedAt;
            set => _updatedAt = value;
        }

        public TransactionType Type
        {
            get => _type;
            set => _type = value;
        }

        public decimal Amount
        {
            get => _amount;
            set => _amount = value;
        }

        public string Content
        {
            get => _content;
            set => _content = value;
        }

        public string SenderAccountNumber
        {
            get => _senderAccountNumber;
            set => _senderAccountNumber = value;
        }

        public string ReceiverAccountNumber
        {
            get => _receiverAccountNumber;
            set => _receiverAccountNumber = value;
        }

        public ActiveStatus Status
        {
            get => _status;
            set => _status = value;
        }

        public Transaction()
        {
        }

        public Transaction(string id, string createdAt, TransactionType type, decimal amount, string content,
            string senderAccountNumber, string receiverAccountNumber, ActiveStatus status)
        {
            _id = id;
            _createdAt = createdAt;
            _type = type;
            _amount = amount;
            _content = content;
            _senderAccountNumber = senderAccountNumber;
            _receiverAccountNumber = receiverAccountNumber;
            _status = status;
        }

        public void PrintTransactions()
        {
            Console.WriteLine("{0,-40} {1,-20} {2,-15} {3,-25} {4,-45} {5,-40}", "Transaction ID",
                "Transaction Type",
                "Amount", "Content", "Sender Account Number", "Receiver Account Number");
            Console.WriteLine("{0,-45} {1,-15} {2,-13} {3,-25} {4,-45} {5,-40}", _id, _type, _amount, _content,
                _senderAccountNumber, _receiverAccountNumber);
            Console.WriteLine("{0,-28}{1}", "Date", "Status");
            Console.WriteLine("{0,-28}{1}", _createdAt, _status);
            Console.WriteLine();
            
            Console.WriteLine("Ban co muon in file ?(Y = CO/N = Khong)");
            var choice = Console.ReadLine();
            if (choice == "y" || choice == "Y")
            {
                StreamWriter sw = File.AppendText("Lich su giao dich.txt");
                sw.WriteLine("{0,-50}{1,-25}{2,-20}{3,-20}{4,-50}{5,-45}{6,-25}{7}", "Transaction ID", "Transaction Type",
                    "Amount", "Content", "Sender Account Number", "Receiver Account Number", "Date", "Status");
                sw.WriteLine("{0,-55}{1,-20}{2,-18}{3,-18}{4,-50}{5,-45}{6,-30}{7}", _id, _type, _amount, _content,
                    _senderAccountNumber, _receiverAccountNumber, _createdAt, _status);
                sw.Flush();
                sw.Close();
                Console.WriteLine("In thanh cong");
            }
            else if (choice == "N" || choice == "n")
            {
                Console.WriteLine("Ban chon khong");
            }
            else Console.WriteLine("Sai lua chon, moi ban nhap lai");
        }
    }
}