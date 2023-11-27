using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Services
{
    public class AppSetting
    {
        public AppSetting(IConfiguration configuration) 
        {
            Gold = configuration.GetValue<int>("Gold");

            Silver = configuration.GetValue<int>("Silver");

            Copper = configuration.GetValue<int>("Copper");

            Rank2 = configuration.GetValue<string>("Rank2");

            Rank0 = configuration.GetValue<string>("Rank0");

            Rank1 = configuration.GetValue<string>("Rank1");
        }

        public int Gold { get; private set; }

        public int Silver { get; private set; }

        public int Copper { get; private set; }

        public string Rank2 { get; private set;}

        public string Rank0 { get; private set; }

        public string Rank1 { get; private set; }
    }
}
