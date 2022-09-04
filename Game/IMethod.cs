using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    internal interface IMethod<T>
    {
        (List<double>,List<double>) FindNext(int limit);
        T Base();
        T Layer_1();
        T Layer_2();
    }
}
