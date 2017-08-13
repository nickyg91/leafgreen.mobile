using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeafGreen.App.Models;

namespace LeafGreen.App.ViewModels
{
    public class AddGardenPageViewModel : BaseViewModel
    {
        public AddGardenPageViewModel()
        {
        }

        public Garden Garden { get; set; }
    }
}
