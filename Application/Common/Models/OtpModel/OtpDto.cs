using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Models.OtpModel
{
    public class OTPResponse
    {
        public string VerificationReference { get; set; }
        public string RetrievalCode { get; set; }
    }
}
