using BankReport.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankReport.Models
{
    public class AccountTotal
    {
        public string AccNo { get; set; }

        public double TotalDebits { get; set; }

        public double TotalCredits { get; set; }

        public double TotalBalance { get; set; }

    }
}
