using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace IdeasGenerator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivityController : ControllerBase
    {
        [HttpPost("GenerateAction")]
        [AllowAnonymous]
        //[Authorize(Roles = "admin")]
        public async Task<IActionResult> GenerateAction()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new System.Uri("https://www.boredapi.com/");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = new HttpResponseMessage();

                response = await client.GetAsync("api/activity");

                if (response.IsSuccessStatusCode)
                {
                    string result = await response.Content.ReadAsStringAsync();
                    return Ok(result);
                }

                return NotFound();
            }
        }
    }
}
