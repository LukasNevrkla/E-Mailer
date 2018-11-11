using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Mailer.Helpers
{
    public static class CommandHelper
    {
        public static void RunAsyncCommand(ref bool flag, Action action)
        {
            if (flag)
                return;
            try
            {
                flag = true;

                action();
            }
            catch { }
            finally { flag = false; }
        }
    }
}
