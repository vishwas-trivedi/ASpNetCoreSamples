using System.Net.Http;
using System.Threading.Tasks;

using DefaultHttpClientFactory.Model;

using Microsoft.AspNetCore.Mvc;

namespace DefaultHttpClientFactory.Controllers
{
    /// <summary>
    /// APi is used to demonstrate the use of IHttpClientFactory
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class HttpController : ControllerBase
    {
        #region Private Members
        /// <summary>
        /// Member used for DI
        /// </summary>
        private readonly IHttpClientFactory m_httpClientFactory;
        #endregion

        #region Constructor
        /// <summary>
        /// Parameterized constructor for DI
        /// </summary>
        /// <param name="httpClient">IHttpClientFactory</param>
        public HttpController(IHttpClientFactory httpClient)
        {
            m_httpClientFactory = httpClient;
        }
        #endregion

        #region Get
        /// <summary>
        /// Allows to make HTTP GET request on any URL.
        /// </summary>
        /// <param name="httpData">Data requireds to make a request</param>
        /// <returns>Response from URL</returns>
        [HttpPost("Get")]
        public async Task<ActionResult> Get([FromBody] HttpData httpData)
        {
            // Check for model validation
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            // Create client
            var client = m_httpClientFactory.CreateClient();

            // Make GET request
            var response = await client.GetStringAsync(httpData.Url);

            // REturn response
            return Ok(response);
        }
        #endregion
    }
}