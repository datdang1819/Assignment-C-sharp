using System;
using System.Collections.Generic;
using System.Text;
using ConsoleApp3.model;
using SpringHeroBank.entity;
using MySql.Data.MySqlClient;
using SpringHeroBank.utility;

namespace SpringHeroBank.controller
{
    
    public class TransactionController
    {
        private List<Transaction> listTransactions = null;

        public List<Transaction> GetTransactionsHistoryByAccountNum()
        {
            
            listTransactions = new List<Transaction>();
            DbConnection.Instance().OpenConnection();
            var sqlQuery = "select * from transactions where receiverAccountNumber = @accountNumber or senderAccountNumber = @accountNumber ORDER BY createdAt DESC LIMIT 3";
            var cmdQuery = new MySqlCommand(sqlQuery, DbConnection.Instance().Connection);
            cmdQuery.Parameters.AddWithValue("@accountNumber", Program.currentLoggedIn.AccountNumber);
            var reader = cmdQuery.ExecuteReader();
            while (reader.Read())
            {
                var id = reader.GetString("id");
                var type = reader.GetInt32("type");
                var amount = reader.GetDecimal("amount");
                var content = reader.GetString("content");
                var senderAccountNumber = reader.GetString("senderAccountNumber");
                var receiverAccountNumber = reader.GetString("receiverAccountNumber");
                var createdAt = reader.GetDateTime("createdAt").ToString();
                var status = reader.GetInt32("status");
                Transaction transaction = new Transaction(id, createdAt, (Transaction.TransactionType) type, amount,
                    content, senderAccountNumber, receiverAccountNumber, (Transaction.ActiveStatus) status);
                
                listTransactions.Add(transaction);
            }
            DbConnection.Instance().CloseConnection();
            //Console.ReadLine();
            return listTransactions;
        }
    }
}