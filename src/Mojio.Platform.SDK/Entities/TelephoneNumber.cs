using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mojio.Platform.SDK.Contracts.Entities;

namespace Mojio.Platform.SDK.Entities
{
    public class TelephoneNumber : ITelephoneNumber
    {
        public string PhoneNumber { get; set; }
        public bool Verified { get; set; }
    }
}
