using Microsoft.VisualStudio.TestTools.UnitTesting;
using TddDay1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;

namespace TddDay1.Tests
{
    [TestClass()]
    public class DataAnalyzerTests
    {
        private DataAnalyzer<Entity> CreateHomework()
        {
            return new DataAnalyzer<Entity>(this.CreateData());
        }

        private IEnumerable<Entity> CreateData()
        {
            var rows = new List<Entity>();
            rows.Add(new Entity() { Id = 1, Cost = 1, Revenue = 11, SellPrice = 21 });
            rows.Add(new Entity() { Id = 2, Cost = 2, Revenue = 12, SellPrice = 22 });
            rows.Add(new Entity() { Id = 3, Cost = 3, Revenue = 13, SellPrice = 23 });
            rows.Add(new Entity() { Id = 4, Cost = 4, Revenue = 14, SellPrice = 24 });
            rows.Add(new Entity() { Id = 5, Cost = 5, Revenue = 15, SellPrice = 25 });
            rows.Add(new Entity() { Id = 6, Cost = 6, Revenue = 16, SellPrice = 26 });
            rows.Add(new Entity() { Id = 7, Cost = 7, Revenue = 17, SellPrice = 27 });
            rows.Add(new Entity() { Id = 8, Cost = 8, Revenue = 18, SellPrice = 28 });
            rows.Add(new Entity() { Id = 9, Cost = 9, Revenue = 19, SellPrice = 29 });
            rows.Add(new Entity() { Id = 10, Cost = 10, Revenue = 20, SellPrice = 30 });
            rows.Add(new Entity() { Id = 11, Cost = 11, Revenue = 21, SellPrice = 31 });
            return rows;
        }

        [TestMethod()]
        public void SelectSumTest_select_3_Column_Cost_return_6_15_24_21()
        {
            var sut = this.CreateHomework();
            
            var actualSum = sut.SelectSum(3, "Cost");

            actualSum.Should().Equal(6, 15, 24, 21);
        }

        [TestMethod()]
        public void SelectSumTest_select_4_Column_Revenue_return_50_66_60()
        {
            var sut = this.CreateHomework();

            var actualSum = sut.SelectSum(4, "Revenue");

            actualSum.Should().Equal(50, 66, 60);
        }
        
        [TestMethod()]
        public void SelectSumTest_select_MinusNumber_throw_ArgumentException()
        {
            var sut = this.CreateHomework();

            Action act = () => sut.SelectSum(-1, "Cost");

            act.ShouldThrow<ArgumentException>();
        }

        [TestMethod()]
        public void SelectSumTest_select_NotExistColumn_throw_ArgumentException()
        {
            var sut = this.CreateHomework();

            Action act = () => sut.SelectSum(3, "NotExist");

            act.ShouldThrow<ArgumentException>();
        }

        [TestMethod()]
        public void SelectSumTest_select_0_return_0()
        {
            var sut = this.CreateHomework();

            var actualSum = sut.SelectSum(0, "Cost");

            actualSum.Should().Equal(0);
        }
    }
}