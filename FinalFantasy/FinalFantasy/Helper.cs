using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalFantasy
{
    public static class Helper
    {
        public static int VerificaInput(int max)
        {
            var conversione = int.TryParse(Console.ReadLine(), out int result);
            while (conversione == false || result < 1 || result > max)
            {
                conversione = int.TryParse(Console.ReadLine(), out result);
            }
            return result;
        }

    }
}
