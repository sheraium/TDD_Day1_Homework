using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TddDay1
{
    public class Homework<T>
    {
        private List<T> data;

        public Homework(IEnumerable<T> data)
        {
            this.data = data.ToList();
        }

        public IEnumerable<int> SelectSum(int Number, string Column)
        {
            if(Number < 0 || Number > this.data.Count())
                throw new ArgumentException("SelectNumber Out of range!!");

            if (Number == 0)
                return new [] { 0 };

            var dataType = typeof(T);
            var properties = dataType.GetProperties();
            var columnProperty = properties.ToList().Find((p) => p.Name == Column);
            if (columnProperty == null)
                throw new ArgumentException("SelectNumber Out of range!!");
            
            List<int> sumList= new List<int>();
            for (int i = 0; i < this.data.Count; i+=Number)
            {
                int sum = 0;
                for (int j = 0; j < Number; j++)
                {
                    int index = i + j;
                    if (index < this.data.Count)
                    {
                        try
                        {
                            int value = Convert.ToInt32(dataType.GetProperty(Column).GetValue(this.data[index], null));
                            sum += value;
                        }
                        catch (Exception e)
                        {
                            //Console.WriteLine(e);
                            //throw;
                        }
                    }
                    else break;
                }
                sumList.Add(sum);
            }

            return sumList;
        }
    }
}
