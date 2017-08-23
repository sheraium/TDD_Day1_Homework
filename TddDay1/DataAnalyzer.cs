using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TddDay1
{
    public class DataAnalyzer<T>
    {
        private List<T> sourceData;

        public DataAnalyzer(IEnumerable<T> SourceData)
        {
            this.sourceData = SourceData.ToList();
        }

        public IEnumerable<int> SelectSum(int GroupBy, string Column)
        {
            this.ValidateGroupRange(GroupBy);

            this.ValidateColumn(Column);

            if (GroupBy == 0) return new[] { 0 };

            List<int> sumList= new List<int>();
            for (int groupIndex = 0; groupIndex < this.sourceData.Count; groupIndex += GroupBy)
            {
                int sum = 0;
                for (int itemIndex = 0; itemIndex < GroupBy; itemIndex++)
                {
                    int index = groupIndex + itemIndex;
                    if (index < this.sourceData.Count)
                    {
                        try
                        {
                            int value = Convert.ToInt32(typeof(T).GetProperty(Column).GetValue(this.sourceData[index], null));
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

        private void ValidateGroupRange(int Number)
        {
            if (Number < 0 || Number > this.sourceData.Count()) throw new ArgumentException("SelectNumber Out of range!!");
        }

        private void ValidateColumn(string Column)
        {
            var properties = typeof(T).GetProperties();
            var columnProperty = properties.ToList().Find((p) => p.Name == Column);
            if (columnProperty == null)
                throw new ArgumentException("SelectNumber Out of range!!");
        }
    }
}
