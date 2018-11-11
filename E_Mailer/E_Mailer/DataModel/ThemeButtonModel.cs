using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace E_Mailer
{
    public class ThemeButtonModel
    {

        #region Private properties

        public string Content { get; set; }

        public SolidColorBrush Background { get; set; }

        public AppTheme Parameter { get; set; }

        #endregion

        public ThemeButtonModel(string content, SolidColorBrush background, AppTheme parameter)
        {
            Content = content;
            Background = background;
            Parameter = parameter;
        }
    }
}
