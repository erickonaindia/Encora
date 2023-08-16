using ConsoleApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public static class SortingOperationsHelper
    {
        /// <summary>
        /// SortingOperations
        /// </summary>
        /// <param name="values">StringRequest</param>
        /// <returns>List of strings</returns>
        public static List<string> SortingOperations(Request values)
        {
            ValidateInput(values);

            return values.Strings
                .Select(ProcessString)
                .ToList();
        }

        /// <summary>
        /// Input Validation
        /// </summary>
        /// <param name="values">StringRequest</param>
        /// <exception cref="ArgumentException"></exception>
        private static void ValidateInput(Request values)
        {
            if (values.N != values.Strings.Count)
            {
                throw new ArgumentException(ErrorMessages.Ndifferent);
            }

            if (values.Strings.Count == 0)
            {
                throw new ArgumentException(ErrorMessages.LinesNotFound);
            }

            if (values.Strings.Any(value => !IsValidString(value)))
            {
                throw new ArgumentException(ErrorMessages.DifferentOfLetters);
            }
        }

        /// <summary>
        /// String Validation
        /// </summary>
        /// <param name="value">string value</param>
        /// <returns>bool</returns>
        private static bool IsValidString(string value)
        {
            return !string.IsNullOrEmpty(value) && value.All(char.IsLetter);
        }

        /// <summary>
        /// Process String
        /// </summary>
        /// <param name="value">string value</param>
        /// <returns>string</returns>
        private static string ProcessString(string value)
        {
            var charFrequency = value.Trim()
                .GroupBy(c => c)
                .OrderBy(group => group.Key)
                .Select(group => new string(group.Key, group.Count()))
                .OrderByDescending(s => s.Length);

            return string.Concat(charFrequency);
        }
    }
}
