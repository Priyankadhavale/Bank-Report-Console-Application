using BankReport.Common;
using BankReport.Interface;
using BankReport.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankReport
{
    class Program
    {
        static void Main(string[] args)
        {
            Calculator calc = new Calculator();

            ReportGenerator rg = new ReportGenerator(calc);

            List<AccountTotal> accountTotals = rg.CalculateTotalForAccount();

            Utility.PrintTable(accountTotals);

            Console.ReadLine();
        }
    }

}
                