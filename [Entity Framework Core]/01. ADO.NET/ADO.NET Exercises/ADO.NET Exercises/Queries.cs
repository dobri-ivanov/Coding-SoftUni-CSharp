using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.NET_Exercises
{
    internal static class Queries
    {
        public const string Problem2 =
            @"SELECT v.Name, COUNT(mv.VillainId) AS MinionsCount  
              FROM Villains AS v 
                 JOIN MinionsVillains AS mv ON v.Id = mv.VillainId 
              GROUP BY v.Id, v.Name 
                HAVING COUNT(mv.VillainId) > 3 
              ORDER BY COUNT(mv.VillainId)";
        public const string Problem3 =
            @"SELECT Name FROM Villains WHERE Id = @Id";
    }
}
