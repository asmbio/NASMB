using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace asmbapi.net
{
    public class AUtils
    {
        public void Startwalletrpc()
        {
            System.Diagnostics.Process.Start(new ProcessStartInfo("wallet", "rpc") { WorkingDirectory ="./lcdb"});
        }
    }
}
