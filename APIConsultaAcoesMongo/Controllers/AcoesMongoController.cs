using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using APIConsultaAcoesMongo.Documents;
using APIConsultaAcoesMongo.Data;

namespace APIConsultaAcoesMongo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AcoesMongoController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<AcaoDocument> Get(
            [FromServices]ILogger<AcoesMongoController> logger,
            [FromServices]AcoesRepository repository)
        {
            logger.LogInformation("Processando requisição HTTP GET em AcoesMongoController...");
            return repository.ListAll();
        }
    }
}