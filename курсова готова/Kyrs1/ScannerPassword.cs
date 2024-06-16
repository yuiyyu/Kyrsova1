using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kyrs1
{
    public class ScannerPassword
    {
        public static bool Validation(string password)
        {
            var input = password;

            if (string.IsNullOrWhiteSpace(input))
            {
                MessageBox.Show("Порожнє поле неможливе.", "Помилка");
                return false;
            }

            var hasMiniMaxChars = new Regex(@".{4,15}");
            var hasLowerChar = new Regex(@"[a-z]+");

            if (!hasLowerChar.IsMatch(input))
            {
                MessageBox.Show("Пароль повинен містити хоча б одну малу літеру.", "Помилка");
                return false;
            }
            else if (!hasMiniMaxChars.IsMatch(input))
            {
                MessageBox.Show("Пароль повинен мати щонайменше 4 символи.", "Помилка");
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
