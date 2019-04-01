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
            IEnumerable<string> result = null;  //will later be added to json response
            String input = value["input"].ToString();
            char [] charInput = input.ToCharArray();
            

            //Check which architecture to use 
            int architechtureType = Convert.ToInt32(value["architechture_type"].ToString());

            if (architechtureType == 1)
            {
                //get input
                List<string> agentsStatus = input.Split('\n').ToList();

                //Pipe - Filter architecture
                //Construct the Pipeline object
                KwicPipeLine agentStatusPipeline = new KwicPipeLine();

                //Register the filters to be executed
                agentStatusPipeline.Register(new CircularShift())
                   .Register(new Alphabetizer());

                //Start pipeline processing
                var watch = new System.Diagnostics.Stopwatch();
                watch.Start();
                result = agentStatusPipeline.Process(agentsStatus);
                watch.Stop();
                Console.Out.WriteLine(watch.ElapsedMilliseconds);
            }
            else if (architechtureType == 2)
            {
                //Shared Data Architecture

                OutputProcessor op = new OutputProcessor();
                op.SetInput(charInput);

                CircularShift_shared_data circularShift_Shared_Data = new CircularShift_shared_data();
                Alphabetizer_shared_data alphabetizer_Shared_Data = new Alphabetizer_shared_data();
                FilterNoise filterNoise = new FilterNoise();

                List<Pair> pairs = circularShift_Shared_Data.shift(charInput);
                pairs = alphabetizer_Shared_Data.alphabetize(pairs, charInput);
                
                result = filterNoise.filter(op.GetStringListFromIndices(pairs));
            }

            return new ObjectResult(result);
        }

    }
}