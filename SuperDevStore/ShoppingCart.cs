using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuperDevStore
{
    public class ShoppingCart
    {
        #region Singloton
        private static ShoppingCart instance;

        public static ShoppingCart Instance
        {
            get
            {
                if (instance == null) instance = new ShoppingCart();

                return instance;
            }
        }
        #endregion                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                         

        private List<Product> products = new List<Product>();
        public List<Product> Products { get { return products; } }

        public void AddProduct(Product product)
        {
            products.Add(product);
        }
    }
}