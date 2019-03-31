using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Kwic.Controllers;

namespace Kwic.Controllers
{
    [Route("api/[controller]")]
    public class KwicController : Controller
    {
        // POST api/<controller>
        [HttpPost]
        public IActionResult Post([FromBody]JObject value)
        {
            //Get the Agents from repository
            List<string> agentsStatus = value["input"].ToString().Split('\n').ToList();

            String architechtureType = value["architechture_type"].ToString();

            //Construct the Pipeline object
            KwicPipeLine agentStatusPipeline = new KwicPipeLine();

            //Register the filters to be executed
            agentStatusPipeline.Register(new CircularShift())
               .Register(new Alphabetizer());

            //Start pipeline processing
            var watch = new System.Diagnostics.Stopwatch();
            watch.Start();
            var agentsStatus_1 = agentStatusPipeline.Process(agentsStatus);
            watch.Stop();
            Console.Out.WriteLine(watch.ElapsedMilliseconds);
            return new ObjectResult(agentsStatus_1);
        }

    }
}