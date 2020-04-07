using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodingSoldier.Core.Entities
{
    public class Certification
    {
        public string Name { get; set; }
        public string UrlPath { get; set; }
        public string ExternalUrl { get; set; }

        public static List<Certification> GetCertifications()
        {
            var list = new List<Certification>();
            list.Add(new Certification { Name = "Developing ASP.NET MVC 4 Web Applications", UrlPath = "developing-asp-net-mvc-4-web-applications" });
            list.Add(new Certification { Name = "AWS Certified Developer - Associate", UrlPath = "aws-certified-developer-associate" });
            list.Add(new Certification { Name = "AWS Certified Solution Architect - Associate", UrlPath = "aws-certified-solutions-architect-associate" });
            list.Add(new Certification { Name = "AZ-301 Microsoft Azure Architect Design", ExternalUrl= "https://www.youracclaim.com/badges/103b8c83-6c94-49ed-9e29-c5304cfedf87" });
            return list;
        }
    }
}
