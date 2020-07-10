using BankReport.Common;
using BankReport.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankReport.Common;

namespace BankReport.Models
{
    public class Calculator : ICalculator
    {
        public DateTime startDate = DateTime.Now;
        public DateTime endDate = DateTime.Now;

        public Calculator()
        {
            startDate = startDate.StartOfDay();
            endDate = endDate.EndOfDay();
        }

        /// <summary>
        /// Get total current balance for provided account number
        /// </summary>
        /// <param name="accNo"></param>
        /// <param name="lstAccounts"></param>
        /// <returns></returns>
        public double CalculateTotalBalance(string accNo, List<Account> lstAccounts)
        {
            double totalBalance = 0;
            try
            {
                if (lstAccounts != null && lstAccounts.Count > 0)
                {
                    var lstA = lstAccounts.Where(a => a.AccNo == accNo &&
                                  (startDate <= a.TransactionDate && a.TransactionDate <= endDate)).
                                  OrderByDescending(s => s.TransactionDate).FirstOrDefault();
                    totalBalance = lstA.ClosureAmt;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception in calculation of Total Credits: " + ex.Message);
            }
            return totalBalance;
        }

        /// <summary>
        /// Calculate the total credits happenned in today's transactions
        /// </summary>
        /// <param name="accNo"></param>
        /// <param name="lstAccounts"></param>
        /// <returns></returns>
        public double CalculateTotalCredits(string accNo, List<Account> lstAccounts)
        {
            double totalCredit = 0;

            try
            {
                if (lstAccounts != null && lstAccounts.Count > 0)
                {
                    totalCredit = lstAccounts.Where(a => a.AccNo == accNo && 
                                  (startDate <= a.TransactionDate && a.TransactionDate <= endDate))
                                  .Sum(x => x.CreditAmt);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("Exception in calculation of Total Credits: " + ex.Message);
            }

            return totalCredit;
        }

        /// <summary>
        /// Calculate the total debits happenned in today's transactions for given account number
        /// </summary>
        /// <param name="accNo"></param>
        /// <param name="lstAccounts"></param>
        /// <returns></returns>
        public double CalculateTotalDebits(string accNo, List<Account> lstAccounts)
        {
            double totalDebits = 0;
            try
            {
                if (lstAccounts != null && lstAccounts.Count > 0)
                {
                    totalDebits = lstAccounts.Where(a => a.AccNo == accNo &&
                                  (startDate <= a.TransactionDate && a.TransactionDate <= endDate))
                                  .Sum(x => x.DebitAmt);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception in calculation of Total Credits: " + ex.Message);
            }
            return totalDebits;
        }
    }
}
