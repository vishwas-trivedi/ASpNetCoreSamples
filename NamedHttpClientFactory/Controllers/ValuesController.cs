using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace NamedHttpClientFactory.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        #region Private members
        /// <summary>
        /// HttpClientFactory
        /// </summary>
        private readonly IHttpClientFactory m_httpClient;
        #endregion

        #region Constructor
        /// <summary>
        /// Parameterized constructor for DI
        /// </summary>
        /// <param name="httpClient"></param>
        public ValuesController(IHttpClientFactory httpClient)
        {
            m_httpClient = httpClient;
        }
        #endregion

        /// <summary>
        /// Allows to make HTTP GET request to google.com
        /// </summary>
        /// <returns>HTML response</returns>
        [HttpGet]
        public async Task<ActionResult> GetAsync()
        {
            var client = m_httpClient.CreateClient("google");
            var response = await client.GetStringAsync("/");
            return Ok(response);
        }
    }
}
