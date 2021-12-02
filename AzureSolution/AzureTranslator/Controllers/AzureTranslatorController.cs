using Infrastructure.AzureTranslator;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AzureTranslator.Controllers
{
    [ApiController]
    [Route("api/translator")]
    public class AzureTranslatorController: ControllerBase
    {
        private IAzureTranslatorService _azureTranslatorService;
        public AzureTranslatorController(IAzureTranslatorService azureTranslatorService)
        {
            _azureTranslatorService = azureTranslatorService;
        }

        [HttpPost("text")]
        public async Task<IActionResult> TranslatorText([FromBody] List<AzureTranslatorRequestBody> body)
        {
            var result = await _azureTranslatorService.Execute(body);
            return Ok(result);
        }
    }
}
