using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Welenda.lk.Models
{
    class ProductModel
    {
        public enum category
        {
            electronics = 0,
            toys = 1
        };

        public enum subcategory
        {
            smartwatches = 0,
            Fitnesstrackers = 1,
        };

        public enum subsubcategory
        {
            apple = 0,
            xiaomi = 1,
            samsung = 2,
            hotwheels = 3,
            carmodels = 4
        };
    }
}
