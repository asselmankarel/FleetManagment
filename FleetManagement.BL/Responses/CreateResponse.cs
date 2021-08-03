using System.Collections.Generic;
using System.Text;

namespace FleetManagement.BL.Responses
{
    public class CreateResponse : ICreateResponse
    {
        public bool Successful { get; init; }
        public List<string> ErrorMessages { get; init; } = new ();

        public override string ToString()
        {
            StringBuilder messages = new StringBuilder();

            foreach(var msg in ErrorMessages)
            {                
                messages.AppendLine(msg);
            }
            
            return messages.ToString();
        }
    }
}
