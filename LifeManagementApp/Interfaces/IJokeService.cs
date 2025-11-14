using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LifeManagementApp.Models; 
using System.Collections.Generic;   
using System.Threading.Tasks;   


namespace LifeManagementApp.Interfaces
{
    public interface IJokeService
    {
        Task<List<Joke>> GetJokesAsync(int amount = 1);
    }
}
