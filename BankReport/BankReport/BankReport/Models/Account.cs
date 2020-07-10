using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankReport.Models
{
    public class Account
    {
        public string AccNo { get; set; }
        public double CreditAmt { get; set; }
        public double DebitAmt { get; set; }

        public double ClosureAmt { get; set; }

        public DateTime TransactionDate { get; set; }
    }


}
