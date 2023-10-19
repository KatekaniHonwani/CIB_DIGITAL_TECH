using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABSAAutomation.Support.Utilities
{
   

    // Define C# classes to deserialize the JSON response
    class BreedResponse
    {
        public string[] Message { get; set; }
        public string Status { get; set; }
    }

}
