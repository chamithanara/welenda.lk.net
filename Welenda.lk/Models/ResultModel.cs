using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Welenda.lk.Models.AuthErrorCodes;

namespace Welenda.lk.Models
{
    class ResultModel
    {
        public ErrorCodes errorCode { get; set; }

        public string categoryTitle { get; set; }

        public int basketItemCount { get; set; }

        public List<string> result { get; set; }

        public List<ProductToQuantity> cartProductList { get; set; }

        public List<user> userResult { get; set; }

        public product productResult { get; set; }

        public productdetail productDetailResult { get; set; }

        public List<productinfo> productInfoResult { get; set; }

        public Dictionary<string, List<string>> hotProducts { get; set; }

        public Dictionary<string, string> productsInfo { get; set; }

        public Dictionary<string, List<string>> ElectornicsProducts { get; set; }

        public Dictionary<string, List<string>> ToyProducts { get; set; }        
    }
}
