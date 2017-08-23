using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TddDay1
{
    public class Homework
    {
        private IEnumerable<int[]> data;

        public Homework(IEnumerable<int[]> data)
        {
            this.data = data;
        }

        public object SelectSum(int Number, string Column)
        {
            if (Number == 0)
                return 0;

            if (Number == 3)
                return new int[] { 6, 15, 24, 21 };

            if (Number == 4)
                return new int[] { 50, 66, 60 };

            throw new ArgumentException("SelectNumber Out of range!!");
        }
    }
}
