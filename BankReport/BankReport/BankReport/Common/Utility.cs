using BankReport.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankReport.Common
{
    public static class Utility
    {
        static int tableWidth = 73;
        public static void PrintLine()
        {
            Console.WriteLine(new string('-', tableWidth));
        }

        public static void PrintRow(params string[] columns)
        {
            int width = (tableWidth - columns.Length) / columns.Length;
            string row = "|";

            foreach (string column in columns)
            {
                row += AlignCentre(column, width) + "|";
            }

            Console.WriteLine(row);
        }

        public static string AlignCentre(string text, int width)
        {
            text = text.Length > width ? text.Substring(0, width - 3) + "..." : text;

            if (string.IsNullOrEmpty(text))
            {
                return new string(' ', width);
            }
            else
            {
                return text.PadRight(width - (width - text.Length) / 2).PadLeft(width);
            }
        }

        /// <summary>
        /// Print data in tabular format for account total list on console
        /// </summary>
        /// <param name="accountTotals"></param>
        public static void PrintTable(List<AccountTotal> accountTotals)
        {
            Console.Clear();
            PrintLine();
            PrintRow("AccountNo", "Total Credits", "Total Debits", "Balance");
            PrintLine();
            foreach (var accTotal in accountTotals)
            {
                PrintRow(accTotal.AccNo, accTotal.TotalCredits.ToString(), 
                    accTotal.TotalDebits.ToString(), accTotal.TotalBalance.ToString());
            }

            PrintLine();
        }
    }
}
