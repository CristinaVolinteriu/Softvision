using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class MinesService
    {
        private UserRepository userRepository;
        public MinesService()
        {
            userRepository = new UserRepository();
        }
        public City UpdteResources(string userId)
        {
            City city = userRepository.GetUser(userId).Cities.First();
            var start = DateTime.Now;
            foreach (var res in city.Resources)
            {
                foreach (var mine in city.Mines)
                {
                    if (mine.Type == res.Type)
                    {
                        res.Level += mine.GetProductionPerHour() * (start - res.LastUpdate).TotalHours;
                    }
                }
                res.LastUpdate = start;
            }
            userRepository.Save();
            return city;
        }
    }
}
