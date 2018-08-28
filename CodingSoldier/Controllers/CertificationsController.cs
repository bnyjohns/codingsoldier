using Amazon.Lambda.APIGatewayEvents;
using CodingSoldier.Core.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;

namespace CodingSoldier.Controllers
{
    public class CertificationsController : Controller
    {
        string webRootPath;
        public CertificationsController(IHostingEnvironment env) => webRootPath = env.WebRootPath;

        public async Task<IActionResult> Index(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                ViewBag.Certifications = Certification.GetCertifications();
                return View();
            }
            else
            {
                var uri = $"http://www.codingsoldier.com/certifications/{fileName}";
                HttpWebRequest httpWebRequest = WebRequest.Create(uri) as HttpWebRequest;
                var response = await httpWebRequest.GetResponseAsync();
                var stream = response.GetResponseStream();
                FileStreamResult result = new FileStreamResult(stream, "application/pdf");
                return result;
            }
        }
    }
}
