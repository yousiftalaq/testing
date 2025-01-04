using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testing.models
{

   public class Data
    {
        public Vote vote { get; set; }
    }

    public class MessageController
    {
        public string DeviceName{ get; set; }
        // public string type { get; set; }
        public TimeSpan Sendtime { get; set; }

        public string Button { get; set; }

      //  public Data Vote { get; set; }
    }

    public class MasterCommend
    {
        public string Commendtype { get; set; }
    }
    public class KeepConnection
    {
        public string Battray { get; set; }
        
        public string Powerconnection { get; set; }
        public string DeviceName { get; set; }

        public TimeSpan Time { get; set; }

    }

    public class Vote
    {
        public string fighter { get; set; }
        public string strike { get; set; }
    }


}
