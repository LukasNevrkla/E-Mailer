using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Mailer
{
    public class SideMenuButtonModel
    {
        public string ImageUri { get; set; }

        public RelayCommand Command { get; set; }


        public SideMenuButtonModel(string imageUri, RelayCommand command)
        {
            ImageUri = imageUri;
            Command = command;
        }
    }
}
