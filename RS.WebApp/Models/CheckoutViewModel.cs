using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RS.ViewModels.Sales;

namespace RS.WebApp.Models
{
    public class CheckoutViewModel
    {
        public List<CartItemViewModel> CartItems { get; set; }

        public CheckoutRequest CheckoutModel { get; set; }
    }
}
