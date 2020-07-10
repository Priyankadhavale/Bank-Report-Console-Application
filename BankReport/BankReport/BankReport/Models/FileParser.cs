using BankReport.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;

namespace BankReport.Models
{
    public class FileParser
    {
        /// <summary>
        /// Binding CSV file data to list collection
        /// </summary>
        /// <param name="strFilePath">File path</param>
        /// <returns></returns>
        public static List<Account> ConvertCSVToList(string strFilePath)
        {
            List<Account> accounts = new List<Account>();
            try
            {
                using (StreamReader sr = new StreamReader(strFilePath))
                {
                    string[] headers = sr.ReadLine().Split(',');


                    while (!sr.EndOfStream)
                    {
                        string[] rows = sr.ReadLine().Split(',');

                        Account account = new Account();

                        account.TransactionDate = rows[0].ToString().ToDateTime("dd/MM/yyyy HH:mm", new System.Globalization.CultureInfo("en-US"));
                        account.AccNo = rows[1];
                        account.CreditAmt = Convert.ToDouble(rows[2] == "-" ? "0" : rows[2]);
                        account.DebitAmt = Convert.ToDouble(rows[3] == "-" ? "0" : rows[3]);
                        account.ClosureAmt = Convert.ToDouble(rows[4]);

                        accounts.Add(account);
                    }
                }
            }
            catch(FileNotFoundException fex)
            {
                Console.WriteLine("File not found: ", fex.Message);
            }
            catch(Exception ex)
            {
                Console.WriteLine("Exception occurred in ConvertCSVToList(): ", ex.Message);
            }

            return accounts;
        }

    }
}
