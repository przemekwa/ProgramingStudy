using System;

namespace ProgramingStudy.Exercism
{
    public static class Year
    {
        public static bool IsLeap(short year)
        {
            if (CheckDivisionRest(year, 4) && !CheckDivisionRest(year, 100) )
            {
                return true;
            }
            else if (CheckDivisionRest(year, 400))
            {
                return true;
            }

            return false;
        }

        public static bool CheckDivisionRest(int number, int dividend)
        {
            return number % dividend == 0;
        }
    }
}
