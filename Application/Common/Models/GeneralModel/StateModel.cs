using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Models.GeneralModel
{
    public class StateModel
    {
        public List<StateInfo>? StateDetail { get; set; }
    }
    public class StateInfo
    {
        public string? State { get; set; }
        public string? Alias { get; set; }
        public List<string>? Lgas { get; set; }
    }
}
