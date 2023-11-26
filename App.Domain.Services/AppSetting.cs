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
            GoldWage = configuration.GetValue<int>("GoldWage");

            SilverWage = configuration.GetValue<int>("SilverWage");

            CopperWage = configuration.GetValue<int>("CopperWage");
        }

        public int GoldWage { get; private set; }

        public int SilverWage { get; private set; }

        public int CopperWage { get; private set; }
    }
}
