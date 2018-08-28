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

        public static List<Certification> GetCertifications()
        {
            var list = new List<Certification>();
            list.Add(new Certification { Name = "Developing ASP.NET MVC 4 Web Applications", UrlPath = "developing-asp-net-mvc-4-web-applications" });
            list.Add(new Certification { Name = "AWS Certified Developer - Associate", UrlPath = "aws-certified-developer-associate" });
            return list;
        }
    }
}
