using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeManagementApp.Models
{
    public class Joke
    {
        public string Text { get; set; } = string.Empty;    

        public override string ToString() => Text;  

    }
}
