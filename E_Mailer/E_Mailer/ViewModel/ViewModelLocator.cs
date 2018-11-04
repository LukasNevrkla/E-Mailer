using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Mailer
{
    public class ViewModelLocator
    {
        public static ViewModelLocator Instance { get; private set; } = new ViewModelLocator();

        public static AppViewModel AppViewModel => IoC.Get<AppViewModel>();
    }
}
