using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Domain.Business
{
    public static class TariffAnalizator
    {
        public static List<int> Numbers(string str)
        {
            var nums = PriceParser.Parse(str);
            switch (str)
            {
                case "70-90":                   
                    nums.AddRange(new List<int>() { 75, 85 });
                    nums.Sort();
                    return nums;

                case "55-75":                    
                    nums.AddRange(new List<int>() { 60, 65 });
                    nums.Sort();
                    return nums;

                case "60-85":                   
                    nums.AddRange(new List<int>() { 70, 75 });
                    nums.Sort();
                    return nums;

                case "50-70":                  
                    nums.AddRange(new List<int>() { 75, 60 });
                    nums.Sort();
                    return nums;

                case "65-85":                   
                    nums.AddRange(new List<int>() { 70, 75 });
                    nums.Sort();
                    return nums;

                case "70-85":
                    nums.AddRange(new List<int>() { 75 });
                    nums.Sort();
                    return nums;

                case "60-75":
                    nums.AddRange(new List<int>() { 70 });
                    nums.Sort();
                    return nums;

                case "45-45":
                    nums.Remove(nums.Last());
                    return nums;

                case "50-50":
                    nums.Remove(nums.Last());
                    return nums;

                case "55-65":
                    nums.AddRange(new List<int>() { 60 });
                    nums.Sort();
                    return nums;

                default: return null;
            }
        }
    }
}
