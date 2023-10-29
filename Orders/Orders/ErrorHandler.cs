using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders
{
    static class ErrorHandler
    {
        public static bool IsNumber(string str)
        {
            // Проверка является ли переданное значение числом. 
            int number;
            try
            {
                number = Convert.ToInt32(str);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static bool IndexInRange(int number, int list_count)
        {
            //Проверка на вхождение индекса в размеры массива. 
            if(number >= 0 && number < list_count)
            {
                return true;
            }
            return false;
        }
        public static bool MonthCorrect(int number)
        {
            // Проверка корректности введенного месяца. 
            if (number > 0 && number <= 12) return true;
            return false;
        }
        public static bool YearCorrect(int year)
        {
            // Проверка корректности введенного года. 
            if (year > 1900 && year <= DateTime.Now.Year) return true;
            return false;
        }
    }
}
