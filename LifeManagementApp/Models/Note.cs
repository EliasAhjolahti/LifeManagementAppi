using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeManagementApp.Models
{
    public class Note
    {
        public string Title { get; set; } = string.Empty;  
        public string Text { get; set; } = string.Empty;   
        public DateTime CreatedAt { get; set; } = DateTime.Now;

    }
}
