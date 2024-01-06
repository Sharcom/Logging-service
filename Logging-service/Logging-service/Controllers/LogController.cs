using Microsoft.AspNetCore.Mvc;
using Logging_service.Types;
using System.Security;
using DAL;
using AL;
using FL;

namespace Logging_service.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LogController : ControllerBase
    {
        private readonly ILogCollection logCollection;

        public LogController(LogContext _logContext, ILogCollection? _logCollection = null)
        {
            logCollection = _logCollection ?? ILogCollectionFactory.Get(_logContext);
        }

        [HttpGet]
        [Route("Logs")]
        [ProducesDefaultResponseType(typeof(List<Log>))]
        public IActionResult GetLogs() { 
            return Ok(logCollection.GetLogs(1));
        }
    }
}