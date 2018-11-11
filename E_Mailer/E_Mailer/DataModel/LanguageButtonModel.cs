using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Mailer
{
    public class LanguageButtonModel
    {
        public string Content { get; set; }

        public AppLanguage Parameter { get; set; }

        public LanguageButtonModel(string content, AppLanguage parameter)
        {
            Content = content;
            Parameter = parameter;
        }
    }
}
