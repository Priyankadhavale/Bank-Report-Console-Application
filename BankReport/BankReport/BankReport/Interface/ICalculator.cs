using BankReport.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankReport.Interface
{
    public interface ICalculator
    {
        double CalculateTotalDebits(string accNo,List<Account> lstAccounts);
        double CalculateTotalCredits(string accNo, List<Account> lstAccounts);

        double CalculateTotalBalance(string accNo, List<Account> lstAccounts);
    }
}
