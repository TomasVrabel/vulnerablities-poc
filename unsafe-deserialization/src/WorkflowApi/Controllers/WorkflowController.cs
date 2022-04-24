using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Principal;

namespace WorkflowApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WorkflowController
    {
        private readonly ILogger<WorkflowController> _logger;

        public WorkflowController(ILogger<WorkflowController> logger)
        {
            _logger = logger;
        }

        [HttpPost(Name = "CreateWorkflow")]
        public bool CreateWorkflow([FromBody] Workflow workflow)
        {
            // we are using Newtonsoft.JSON with TypeNameHandling.Auto, see Program.cs

            _logger.LogInformation("CreateWorkflow, worflow name: {name}", workflow.Name);
            _logger.LogInformation("CreateWorkflow, worflow properties count: {actions}", workflow.Properties?.Count());
            _logger.LogInformation("CreateWorkflow, worflow action count: {actions}", workflow.Actions?.Count());

            return true;
        }
    }

    public class Workflow {
        public string Name { get; set; }
        public Dictionary<string, object> Properties { get; set; }
        public WorkflowAction[] Actions { get; set; }
    }
    
    public interface WorkflowAction
    {
    }

    public class WaitAction : WorkflowAction
    {
        public int DurationMs { get; set; }
    }

    public class PrintAction : WorkflowAction
    {
        public string Message { get; set; }
    }
}
