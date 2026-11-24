using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace CompanyService
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的类名“CompanyService”。
    public class CompanyService : ICompanyPublicService, ICompanyConfidentialService
    {
        public string GetConfidentialInformation()
        {
            return "This is public information and available over HTTP to all general public outside the Firewall.";
        }

        string ICompanyPublicService.GetPublicInformation()
        {
            return "This is confidential information and only available over TCP behind the compnay Firewall.";
        }
    }
}
