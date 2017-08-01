using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Welenda.lk.Models
{
    public class ProductModel
    {
        public virtual int id { get; set; }

        public virtual string title { get; set; }

        public virtual string imgUrl { get; set; }

        public virtual string newprice { get; set; }
    }
}
