using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AHMSApplicationDemo.ViewModels.AccountViewModels
{
    public class EditUserViewModel
    {
        public EditUserViewModel()
        {
            Roles = new List<string>();
            Claims = new List<string>();
        }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public List<string> Roles { get; set; }
        public List<string> Claims { get; set; }

    }
}
