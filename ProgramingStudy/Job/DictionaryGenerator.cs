using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramingStudy.Job
{
    public class DictionaryGenerator : IStudyTest
    {
        public void Study()
        {
            string ala = null;

            var d = sss();

            var f = ala.Length;

            var lines = File.ReadAllLines("in_dictionaryEntrys.txt");

            var dictionaryEntrys = new List<string>();
            var translationEntrys = new List<string>();

            foreach (var line in lines)
            {
                var values = line.Split(new[] { "|" }, StringSplitOptions.RemoveEmptyEntries);
    
               dictionaryEntrys.Add(MakeFullEntry(values[0], values[1], values[2], values[3]));
                translationEntrys.Add(GetTranslations(values[0], values[1], values[2], values[3]));
            }

            File.WriteAllLines("out_dictionaryEntrys.txt", dictionaryEntrys);
         
            File.WriteAllLines("out_translationEntrys.txt", translationEntrys);

            string sss()
            {
                return "Działa";
            }
        }

        public string MakeFullEntry(string accountNumber, string accoutDesc, string textOnInvose, string code)
        {
            var food = accountNumber.Substring(3, 1) == "1" ? "F" : "NF";

            var accoutNameWithDash = accountNumber.Replace("-", "_");
            var accoutNameWithDot = accountNumber.Replace("-", ".");

            var sb = new StringBuilder();
            sb.AppendLine("-- START New Additional Settlements Account Dictionaries Entry");
            sb.AppendLine();
            sb.AppendLine($"--  Additional Settlements Food Account {accountNumber}");
            sb.AppendLine();
            sb.AppendLine($"EXEC [BCC_PG].[AddDictionaryDefinition]");

            var accoutId = Guid.NewGuid();

            sb.AppendLine($"'{{{accoutId}}}',");

            sb.AppendLine($"N'Additional_Settlements_Account_{food}_{accoutNameWithDash}',");

            sb.AppendLine($"N'Dictionary.Additional.Settlements.Account.{food}.{accoutNameWithDot}',");


            if (food == "F")
            {
                sb.AppendLine("'{6AD11ACC-492F-4693-B181-D299AC2259DB}' -- Additional Settlements For Food Account");

            }
            else
            {
                sb.AppendLine("'{6530E779-C097-492E-BB7E-4AE8943B039C}' -- Additional Settlements For Non Food Account");
            }



            sb.AppendLine();
            sb.AppendLine($"EXEC[BCC_PG].[AddDictionaryEntry]");

            sb.AppendLine($"'{{{Guid.NewGuid()}}}',");
            sb.AppendLine($"'{{{accoutId}}}',");
            sb.AppendLine($"N'Dictionary.Additional.Settlements.Account.{food}.{accoutNameWithDot}',");
            sb.AppendLine($" N'{accountNumber}'");


            sb.AppendLine($"");
            sb.AppendLine($"--  Additional Settlements Food Account {accountNumber} TextOnInvoice");
            sb.AppendLine($"");
            sb.AppendLine($"EXEC [BCC_PG].[AddDictionaryDefinition]");
            var texyOnInvoiceId = Guid.NewGuid();
            sb.AppendLine($"'{{{texyOnInvoiceId}}}',");
            sb.AppendLine($"N'Additional_Settlements_TextOnInvoice_{food}_{accoutNameWithDash}',");
            sb.AppendLine($"N'Dictionary.Additional.Settlements.TextOnInvoice.{food}.{accoutNameWithDot}',");
            sb.AppendLine($"'{{{accoutId}}}'  -- Account {accountNumber}");
            sb.AppendLine($""); 
            sb.AppendLine($" EXEC [BCC_PG].[AddDictionaryEntry] ");
            sb.AppendLine($"'{{{Guid.NewGuid()}}}',");
            sb.AppendLine($"'{{{texyOnInvoiceId}}}',");
            sb.AppendLine($"N'Dictionary.Additional.Settlements.TextOnInvoice.{food}.{accoutNameWithDot}.1',");
            sb.AppendLine($"N'1'");

            sb.AppendLine($"");

            sb.AppendLine($"--  Additional Settlements Food Account {accountNumber} Code");
            sb.AppendLine($"");
            sb.AppendLine($"EXEC[BCC_PG].[AddDictionaryDefinition]");
            var codeId = Guid.NewGuid();
            sb.AppendLine($"'{{{codeId}}}',");
            sb.AppendLine($"N'Additional_Settlements_Account_{food}_{accoutNameWithDash}_Code',");
            sb.AppendLine($"N'Dictionary.Additional.Settlements.Account.{food}.{accoutNameWithDot}',");
            sb.AppendLine($"null");
            sb.AppendLine($"");
            sb.AppendLine($"EXEC [BCC_PG].[AddDictionaryEntry] ");
            sb.AppendLine($"'{{{Guid.NewGuid()}}}',");
            sb.AppendLine($"'{{{codeId}}}',");
            sb.AppendLine($"N'Dictionary.Additional.Settlements.Account.{food}.{accoutNameWithDot}',");
            sb.AppendLine($"N'{code}'");
            sb.AppendLine("-- STOP New Additional Settlements Account Dictionaries Entry");


            

            return sb.ToString();
        }

        public string GetTranslations(string accountNumber, string accoutDesc, string textOnInvose, string code)
        {
            var food = accountNumber.Substring(3, 1) == "1" ? "F" : "NF";

            var accoutNameWithDash = accountNumber.Replace("-", "_");
            var accoutNameWithDot = accountNumber.Replace("-", ".");

             var sb = new StringBuilder();

            sb.AppendLine($"Dictionary.Additional.Settlements.Account.{food}.{accoutNameWithDot}\t{accoutDesc}\t{accoutDesc}\t{accoutDesc}\t{accoutDesc}\t{accoutDesc}");
            sb.AppendLine($"Dictionary.Additional.Settlements.TextOnInvoice.{food}.{accoutNameWithDot}.1\t{textOnInvose}\t{textOnInvose}\t{textOnInvose}\t{textOnInvose}\t{textOnInvose}");

            return sb.ToString();
        }
    }
}


       
 