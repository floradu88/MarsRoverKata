using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRoverKata
{
    public class ObstacleFound : Exception
    {
        public ObstacleFound(string errorMessage, Location location, char command)
            : base(string.Format(errorMessage, location, command))
        {
        }
    }
}
