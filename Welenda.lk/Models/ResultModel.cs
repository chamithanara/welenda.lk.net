using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using static Welenda.lk.Models.AuthErrorCodes;

namespace Welenda.lk.Models
{
    public class ResultModel
    {
        public virtual ErrorCodes errorCode { get; set; }

        public virtual string categoryTitle { get; set; }

        public virtual int basketItemCount { get; set; }
        
        public virtual ICollection<string> result { get; set; }
        
        public virtual ICollection<ProductModel> productsList { get; set; }
        
        public virtual ICollection<ProductToQuantity> cartProductList { get; set; }
        
        public virtual ICollection<user> userResult { get; set; }
        
        public virtual product productResult { get; set; }

        public virtual productdetail productDetailResult { get; set; }
        
        public virtual ICollection<productinfo> productInfoResult { get; set; }

        public virtual Dictionary<string, List<string>> hotProducts { get; set; }

        public virtual Dictionary<string, string> productsInfo { get; set; }

        public virtual Dictionary<string, List<string>> ElectornicsProducts { get; set; }

        public virtual Dictionary<string, List<string>> ToyProducts { get; set; }        
    }
}
