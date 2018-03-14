using Cinema.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Cinema.Domain.Business
{
    public static class PriceParser
    {
        public static List<int> Parse(string priceStr)
        {
            string[] strings = Regex.Split(priceStr, @"(-)|( )|(,)|(, )");

            List<Price> prices = new List<Price>();
            List<int> nums = new List<int>();

            foreach (var item in strings)
            {
                
                try
                {
                    var num = Int32.Parse(item);
                    nums.Add(num);
                }
                catch (Exception)
                {

                }

            }


            if (nums.Count > 0)
                return nums;
            else
                return null;
        }
    }
}
