using Cinema.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Domain.Business
{
    public static class PriceFormer
    {
        public static List<Price> Prices(string str)
        {          
            List<int> nums;
            if ( str.Contains("-"))
                nums = TariffAnalizator.Numbers(str);
            else
            {
                nums = PriceParser.Parse(str);
                
                if(nums != null)
                    nums.Sort();
            }
                

            if(nums != null)
            {

                var prices = new List<Price>();
                for (int i = 0; i < nums.Count; i++)
                {
                    var price = new Price(i + 1, nums[i]);
                    prices.Add(price);
                }

                return prices;
            }
            return null;
        }
    }
}
