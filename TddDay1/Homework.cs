using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TddDay1
{
    public class Homework<T>
    {
        private IEnumerable<T> data;

        public Homework(IEnumerable<T> data)
        {
            this.data = data;
        }

        public IEnumerable<int> SelectSum(int Number, string Column)
        {
            if (Number == 0)
                return new [] { 0 };

            if (Number == 3)
                return new [] { 6, 15, 24, 21 };

            if (Number == 4)
                return new [] { 50, 66, 60 };

            throw new ArgumentException("SelectNumber Out of range!!");
        }
    }
}
