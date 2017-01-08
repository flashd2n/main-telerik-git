using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Init
{
    public static class IListExtentions
    {
        public static void IncreaseWith(this IList<int> listInput, int incremention)
        {
            for (int i = 0; i < listInput.Count; i++)
            {
                listInput[i] += incremention;
            }
        }
    }
}
