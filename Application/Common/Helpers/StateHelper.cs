using Application.Common.Models.GeneralModel;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Helpers
{
    public class StateHelper
    {
        public static StateModel GetStates()
        {
            IConfigurationBuilder builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("state.json");

            var configuration = builder.Build();
            var stateDetail = new StateModel();
            configuration.Bind(stateDetail);
            return stateDetail;
        }
    }
}
