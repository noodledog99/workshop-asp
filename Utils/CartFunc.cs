using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using workshop_asp.Models;

namespace workshop_asp.Utils
{
    public class CartFunc
    {
        public static List<CartDetail> CartDetail;

        public CartFunc()
        {

        }

        public IEnumerable<CartDetail> GetCartDetail()
        {
            return CartDetail;
        }

        public void AddItem(int ProductId, Product product, int Qty, string UnitPrice)
        {
            CartDetail.Add(new CartDetail
            {
                ProductId = ProductId,
                product = product,
                Quantity = Qty,
                UnitPrice = Convert.ToDecimal(UnitPrice),
                SubTotal = Convert.ToDecimal(UnitPrice) * Qty,
            });
        }

        public void ClearCart()
        {
            CartDetail.Clear();
        }
        
        public string CountItemCart()
        {
            if (CartDetail == null)
            {
                CartDetail = new List<CartDetail>();
            }
            return CartDetail.Count().ToString();
        }
    }
}