using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BillIndentityChallenge.SuperMarket_Kata
{
    public class SuperMarketKata : ICheckout
    {
        public Items Scan(string item)
        {
            try
            {
                List<Items> items = new List<Items>();
                items.Add(new Items() { SKU = "A", UnitPrice = 50, SpecialPrice = "3 for 130" });
                items.Add(new Items() { SKU = "B", UnitPrice = 30, SpecialPrice = "2 for 45" });
                items.Add(new Items() { SKU = "C", UnitPrice = 20, SpecialPrice = "" });
                items.Add(new Items() { SKU = "D", UnitPrice = 15, SpecialPrice = "" });

                if (items.Where(w => w.SKU == item).Any())
                {
                    return items.Where(w => w.SKU == item).FirstOrDefault();
                }
            }
            catch
            {
            }
            return new Items();

        }
        public int GetTotalPrice(List<Items> scanItems)
        {
            try
            {
                var grpScanItem = scanItems.GroupBy(g => new { g.SKU }).Select(s => new { s.Key.SKU, Cnt = s.Count() }).ToList();
                int totalPrice = 0;
                foreach (var item in grpScanItem)
                {
                    if (item.Cnt == 1)
                    {
                        totalPrice += scanItems.Where(w => w.SKU == item.SKU).FirstOrDefault().UnitPrice;
                    }
                    else
                    {
                        string[] specialPrice = scanItems.Where(w => w.SKU == item.SKU).FirstOrDefault().SpecialPrice.Split(" ");
                        if (specialPrice.Length > 0)
                        {
                            if (item.Cnt == int.Parse(specialPrice[0]))
                            {
                                totalPrice += int.Parse(specialPrice[2]);
                            }
                            else
                            {
                                var reminder = item.Cnt % int.Parse(specialPrice[0]);
                                if (reminder > 0)
                                {
                                    totalPrice += ((item.Cnt - reminder) * int.Parse(specialPrice[0])) + reminder * scanItems.Where(w => w.SKU == item.SKU).FirstOrDefault().UnitPrice;
                                }
                            }
                        }
                        else
                        {
                            totalPrice += scanItems.Where(w => w.SKU == item.SKU).FirstOrDefault().UnitPrice * item.Cnt;
                        }
                    }
                }
                return totalPrice;
            }
            catch
            {
            }
            return 0;
        }
    }
}
