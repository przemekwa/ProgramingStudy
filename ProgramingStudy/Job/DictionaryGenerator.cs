using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramingStudy.Job
{
    public class DictionaryGenerator : IStudyTest
    {
        public void Study()
        {

            var result = MakeFullEntry("1741-011", "F");

        }

        public string MakeFullEntry(string accountNumber, string food)
        {
            var accoutNameWithDash = accountNumber.Replace("-", "_");
            var accoutNameWithDot = accountNumber.Replace("-", ".");

            var sb = new StringBuilder();

            sb.AppendLine($"--  Additional Settlements Food Account {accountNumber}");
            sb.AppendLine();
            sb.AppendLine($"EXEC [BCC_PG].[AddDictionaryDefinition]");

            var accoutId = Guid.NewGuid();

            sb.AppendLine($"'{{{accoutId}}}',");

            sb.AppendLine($"N'Additional_Settlements_Account_{food}_{accoutNameWithDash}',");

            sb.AppendLine($"N'Dictionary.Additional.Settlements.Account.{food}.{accoutNameWithDot}',");
            sb.AppendLine("'{6AD11ACC-492F-4693-B181-D299AC2259DB}' -- Additional Settlements For Food Account");
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
            sb.AppendLine($"'{{{accoutId}}}',  -- Account {accountNumber}");
            sb.AppendLine($"");
            sb.AppendLine($" EXEC [BCC_PG].[AddDictionaryEntry] ");
            sb.AppendLine($"'{{{Guid.NewGuid()}}}',");
            sb.AppendLine($"'{{{texyOnInvoiceId}}}',");
            sb.AppendLine($"N'Dictionary.Additional.Settlements.TextOnInvoice.{food}.{accoutNameWithDot}.1',");
            sb.AppendLine($"N'1");

            return sb.ToString();
        }
    }
}
