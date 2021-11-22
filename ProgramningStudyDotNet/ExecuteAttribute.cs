

using System.Globalization;

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
