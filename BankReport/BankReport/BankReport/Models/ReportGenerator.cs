using BankReport.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankReport.Models
{
    public class ReportGenerator
    {
        ICalculator _calculator;
        public ReportGenerator(ICalculator calculator)
        {
            _calculator = calculator;
        }

        /// <summary>
        /// Main function which calculates the total of debits,credits for current date and balance of the user 
        /// </summary>
        /// <returns></returns>
        public List<AccountTotal> CalculateTotalForAccount()
        {
            List<AccountTotal> accountTotals = new List<AccountTotal>();

            try
            {
                List<Account> accountList = FileParser.ConvertCSVToList(@"D:\assignment\BankReport\BankDetails.csv");

                var accountNos = accountList.Select(a => a.AccNo).Distinct();

                if (accountNos != null && accountNos.Count() > 0)
                {
                    accountTotals = BindAccountTotal(accountNos.ToArray(), accountList);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("Exception occurred while calculating Total: ", ex.Message);
            }

            return accountTotals;

        }

        /// <summary>
        /// Bind the Account total object list
        /// </summary>
        /// <param name="accNos"></param>
        /// <param name="accounts"></param>
        /// <returns></returns>
        public List<AccountTotal> BindAccountTotal(string[] accNos, List<Account> accounts)
        {
            List<AccountTotal> lstAccTotal = new List<AccountTotal>();

            foreach (var accountNo in accNos)
            {
                AccountTotal accountTotal = new AccountTotal();

                accountTotal.AccNo = accountNo;
                accountTotal.TotalCredits = _calculator.CalculateTotalCredits(accountNo, accounts);
                accountTotal.TotalDebits = _calculator.CalculateTotalDebits(accountNo, accounts);
                accountTotal.TotalBalance = _calculator.CalculateTotalBalance(accountNo, accounts);

                lstAccTotal.Add(accountTotal);
            }

            return lstAccTotal;
        }
    }
}
