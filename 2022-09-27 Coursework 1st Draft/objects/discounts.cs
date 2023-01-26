using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2022_09_27_Coursework_1st_Draft.objects
{
    class discounts
    {
        int discountCode, discountValue;
        public discounts()
        {

        }
        public discounts(int discountCode, int discountValue)
        {
            discountCode = DiscountCode;
            discountValue = DiscountValue;
        
        }
        public int DiscountCode
        {
            get { return discountCode; }
            set { discountCode = value; }

        }
        public int DiscountValue
        {
            get { return discountValue; }
            set { discountValue = value; }

        }
    }
}
