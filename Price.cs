using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zad3
{
    class Price
    {
        public double price_before_discount { set; get; }
        public double price_after_discount { set; get; }
        private double format_price;
        public double FormatPrice 
        {
            set
            {
                format_price = Math.Round(value,2);
            }
            get
            {
                return format_price;
            }
        }
        private int amount;
        public int Amount 
        {
            set
            {
                amount = value;
                discount = amount / 100;
            }
            get
            {
                return amount;
            }
        }
        public int discount { set; get; }
        public bool color_paper { set; get; }
        public double grammage { set; get; }
        public bool color_ink { set; get; }
        public bool two_sided { set; get; }
        public bool uv { set; get; }
        public bool standard { set; get; }

        public Price()
        {
            price_after_discount = 0;
            price_before_discount = 0;
            format_price = 0.2;
            amount = 0;
            discount = 0;
            color_paper = false;
            grammage = 1;
            color_ink = false;
            two_sided = false;
            uv = false;
            standard = true;
        }

        public void Count()
        {
            double price = format_price;

            if (color_paper)
                price += format_price * 0.5;
            price *= grammage;
            if (color_ink)
                price += price * 0.3;
            if (two_sided)
                price += price * 0.5;
            if (uv)
                price += price * 0.2;
            

            price_before_discount = Math.Round(price * amount,2);
            if (!standard)
                price_before_discount += 15;
            price_after_discount = Math.Round(price_before_discount * (1 - 0.01 * discount),2);

        }

    }
}
