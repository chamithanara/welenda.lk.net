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

        public List<string> result { get; set; }
        
        public Dictionary<string, List<string>> hotProducts { get; set; }

        public Dictionary<string, string> productsInfo { get; set; }

        public Dictionary<string, List<string>> ElectornicsProducts { get; set; }

        public Dictionary<string, List<string>> ToyProducts { get; set; }        
    }
}
