using CodingSoldier.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Net;
using System.Threading.Tasks;

namespace CodingSoldier.Controllers
{
    public class CertificationsController : Controller
    {
        private readonly IConfiguration _configuration;
        public CertificationsController(IConfiguration configuration) => _configuration = configuration;

        public async Task<IActionResult> Index(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                ViewBag.Certifications = Certification.GetCertifications();
                return View();
            }
            else
            {
                var uri = $"{_configuration["CertificatesBlobUrl"]}{fileName}";
                if (!uri.EndsWith(".pdf"))
                    uri += ".pdf";
                HttpWebRequest httpWebRequest = WebRequest.Create(uri) as HttpWebRequest;
                var response = await httpWebRequest.GetResponseAsync();
                var stream = response.GetResponseStream();
                FileStreamResult result = new FileStreamResult(stream, "application/pdf");
                return result;
            }
        }
    }
}
