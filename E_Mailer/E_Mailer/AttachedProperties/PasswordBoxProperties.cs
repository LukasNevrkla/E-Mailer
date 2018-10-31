using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace E_Mailer.AttachedProperties
{
    class PasswordBoxProperties
    {
        public static readonly DependencyProperty HasTextProperty = 
            DependencyProperty.RegisterAttached("HasText",typeof(bool), typeof(PasswordBoxProperties), new PropertyMetadata());
    }
}
