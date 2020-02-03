using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommanBusinessComponent
{
   public class DateFormat
    {
        public string GetDateformat(DateTime dateTime, string dateFormat)
        {
            return dateTime.ToString(dateFormat);
        }
        public DateTime? SetDateformat(string dateTime, string dateFormat)
        {
            DateTime? date=null;
            if (dateTime =="" || dateTime == null)
            {
                date = null;
            }
            else
            {
                DateTime date1=DateTime.Now;
                string[] formats = {"dd-MM-yyyy", "dd.MM.yyyy", "MMMM dd, yyyy", "dd/MMM/yyyy", "dd/MM/yyyy", "d/MM/yyyy", "dd/MM/yy", "dd/MMMM/yyyy", "dd/M/yyyy", };
                string[] formatsStandard = { "M/d/yyyy", "M/dd/yyyy", "MM/d/yyyy", "MM/dd/yyyy", };

                if (dateFormat == "dd-MM-yyyy" || dateFormat == "dd.MM.yyyy" || dateFormat == "MMMM dd, yyyy" || dateFormat == "dd/MM/yyyy" || dateFormat == "dd/M/yyyy"
                    || dateFormat == "d/MM/yyyy" || dateFormat == "dd/MM/yy" || dateFormat == "dd/MMMM/yyyy")
                {
                    if (DateTime.TryParseExact(dateTime, formats, CultureInfo.InvariantCulture, DateTimeStyles.None, out date1))
                    {
                        date1.ToString("MM/dd/yyyy");
                    }
                }
                else if (dateFormat == "M/d/yyyy" || dateFormat == "M/dd/yyyy" || dateFormat == "MM/d/yyyy"
                     || dateFormat == "MM/dd/yyyy")
                {
                    if (DateTime.TryParseExact(dateTime, formatsStandard, CultureInfo.InvariantCulture, DateTimeStyles.None, out date1))
                    {
                        date1.ToString("MM/dd/yyyy");
                    }
                }
                else
                {
                    date1 = Convert.ToDateTime(date1.ToString("MM/dd/yyyy"));
                }

             //   date1 = Convert.ToDateTime(date1.ToString("MM/dd/yyyy"));
                date=date1;
            }

            return date;
        }

        public DateTime? SetDateformatType2(string dateTime, string dateFormat)
        {
            DateTime? date = null;
            if (dateTime == "" || dateTime == null)
            {
                date = null;
            }
            else
            {
                DateTime date1 = DateTime.Now;
                string[] formats = { "dd.MM.yyyy", "MMMM dd, yyyy", "dd/MMM/yyyy", "dd/MM/yyyy", "d/MM/yyyy", "dd/MM/yy", "dd/MMMM/yyyy", "dd/M/yyyy", };
                string[] formatsStandard = { "M/d/yyyy", "M/dd/yyyy", "MM/d/yyyy", "MM/dd/yyyy", "dd/MM/yyyy", "dd-MM-yyyy" };

                if (dateFormat == "dd.MM.yyyy" || dateFormat == "MMMM dd, yyyy" || dateFormat == "dd/MM/yyyy" || dateFormat == "dd/M/yyyy"
                    || dateFormat == "d/MM/yyyy" || dateFormat == "dd/MM/yy" || dateFormat == "dd/MMMM/yyyy")
                {
                    if (DateTime.TryParseExact(dateTime, formats, CultureInfo.InvariantCulture, DateTimeStyles.None, out date1))
                    {
                        date1.ToString("MM/dd/yyyy");
                    }
                }
                else if (dateFormat == "M/d/yyyy" || dateFormat == "M/dd/yyyy" || dateFormat == "MM/d/yyyy"
                     || dateFormat == "MM/dd/yyyy")
                {
                    if (DateTime.TryParseExact(dateTime, formatsStandard, CultureInfo.InvariantCulture, DateTimeStyles.None, out date1))
                    {
                        date1.ToString("MM/dd/yyyy");
                    }
                }
                else
                {
                    date1 = Convert.ToDateTime(date1.ToString("MM/dd/yyyy"));
                }

                date = date1;
            }

            return date;
        }
        
        // Return only converted datetime
        public static DateTime GUDateTime(string dateTime)
        {
            var resultDate = new DateTime();
            DateTime.TryParse(dateTime, out resultDate);
            if (string.IsNullOrEmpty(dateTime) || resultDate.Year < 1900) { DateTime.TryParse("1900/01/01", out resultDate); }
            return resultDate;
        }

        // Return only converted datetime
        public static DateTime GUDateTime(DateTime dateTime)
        {
            var resultDate = new DateTime();
            if (resultDate == null || resultDate.Year < 1900) { DateTime.TryParse("1900/01/01", out resultDate); }
            DateTime.TryParse(dateTime.ToString(), out resultDate);
            return resultDate;
        }

        // Return only converted datetime
        public static DateTime GUDateTime(DateTime? dateTime)
        {
            var resultDate = new DateTime();
            if (resultDate == null || resultDate.Year < 1900) { DateTime.TryParse("1900/01/01", out resultDate); }
            DateTime.TryParse(dateTime.ToString(), out resultDate);
            return resultDate;
        }
    }
}
