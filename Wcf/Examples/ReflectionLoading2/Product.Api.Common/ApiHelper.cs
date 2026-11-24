using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Globalization;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Linq;

namespace Product.Api.Common
{
    public static class ApiHelper
    {
        public static string Validate(object obj)
        {
            List<ValidationResult> list = new List<ValidationResult>();
            Validator.TryValidateObject(obj, new ValidationContext(obj, null, null), list, true);
            List<string> sb = new List<string>();
            if (list.Count == 0)
            {
                return string.Empty;
            }
            else
            {
                foreach (var result in list)
                {
                    sb.Add(result.ErrorMessage);
                }

                return string.Join(",", sb.ToArray());
            }
        }

        public static List<string> SeperateWithoutEmpty(string input)
        {
            return input.Split(ApiConsts.Seperator).Where(s => !string.IsNullOrEmpty(s)).ToList();
        }

        public static List<string> Seperate(string input)
        {
            if (input.Last() == ApiConsts.Seperator)
            {
                input = input.Remove(input.Length - 1);
            }
            return input.Split(ApiConsts.Seperator).ToList();
        }
    }
}
