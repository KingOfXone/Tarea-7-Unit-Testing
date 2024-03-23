using Xunit;
using System;
using System.Linq;

namespace Tarea_7_MABB
{
    public class UnitTest1
    {
        [Fact]
        public void IsPasswordSecure_returns_false_if_password_has_less_than_8_characters()
        {
            var registerViewModel = new RegisterViewModel();

            bool result = registerViewModel.IsPasswordSecure("1234567");

            Assert.False(result);
        }

        [Fact]
        public void IsPasswordSecure_returns_false_if_password_does_not_contain_uppercase_character()
        {
            var registerViewModel = new RegisterViewModel();

            bool result = registerViewModel.IsPasswordSecure("12345678a");

            Assert.False(result);
        }
    }

    internal class RegisterViewModel
    {
        internal bool IsPasswordSecure(string password)
        {
            if (password.Length < 8)
            {
                return false;
            }

            if (!ContainsUppercase(password))
            {
                return false;
            }

            if (!ContainsSymbol(password))
            {
                return false;
            }

            return true;
        }

        private bool ContainsUppercase(string password)
        {
            return password.Any(c => Char.IsLetter(c) && Char.IsUpper(c));
        }

        private bool ContainsSymbol(string password)
        {
            return password.Any(c => Char.IsSymbol(c) || Char.IsPunctuation(c));
        }
    }
}
