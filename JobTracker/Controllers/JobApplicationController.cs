using Microsoft.AspNetCore.Mvc;

namespace JobTracker.Controllers
{
    [ApiController]
    public class JobApplicationController
    {
        private readonly ILogger _logger;

        public JobApplicationController(ILogger logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
    }
}
