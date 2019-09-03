using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramingStudy.Study
{
    [AttributeUsage(AttributeTargets.Class)]
    public class ExecuteAttribute : Attribute
    {
        public string DateTime {get;set;}

        public DateTime ExecuteDateTime
        {
            get
            {
                if (string.IsNullOrEmpty(DateTime) == false)
                {
                    return System.DateTime.ParseExact(this.DateTime, "dd-MM-yyyy HH:mm" , CultureInfo.InvariantCulture);
                }

                return System.DateTime.Now.AddYears(-2);
            }
        }
    }
}
