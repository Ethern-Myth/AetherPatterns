using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    internal class RandomNumber<T>
    {
        protected T R_Number(int minValue = 1, int maxValue = 11)
        {
            dynamic num = 0;
            num = new Random().Next(minValue, maxValue);
            return num;
        }
    }
}
