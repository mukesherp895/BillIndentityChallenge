using System;
using System.Collections.Generic;
using System.Text;

namespace BillIndentityChallenge.SuperMarket_Kata
{
    public interface ICheckout
    {
        Items Scan(string item);
        int GetTotalPrice(List<Items> scanItems);
    }
}
