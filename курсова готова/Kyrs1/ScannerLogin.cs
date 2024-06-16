using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kyrs1
{
    internal class ScannerLogin
    {
        public static bool Validation(string login)
        {
            var input = login;

            if (string.IsNullOrWhiteSpace(input))
            {
                MessageBox.Show("Порожнє поле неможливе.", "Помилка");
                return false;
            }

            var hasMiniMaxChars = new Regex(@".{5,12}");
            var hasLowerChar = new Regex(@"[a-z]+");

            if (!hasLowerChar.IsMatch(input))
            {
                MessageBox.Show("Логін повинен містити хоча б одну малу літеру.", "Помилка");
                return false;
            }
            else if (!hasMiniMaxChars.IsMatch(input))
            {
                MessageBox.Show("Логін повинен мати не менше 5 символів.", "Помилка");
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}