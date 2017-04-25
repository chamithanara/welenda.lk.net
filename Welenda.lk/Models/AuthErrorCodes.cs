using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Welenda.lk.Models
{
    class AuthErrorCodes
    {
        public enum ErrorCodes
        {
            exception,
            emailExist,
            nouserinfo,
            success,
            error,
            itemexists
        };
    }
}
