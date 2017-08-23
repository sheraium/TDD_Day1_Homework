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
    public class HomeworkTests
    {
        private Homework CreateHomework()
        {
            return new Homework(this.CreateData());
        }

        private IEnumerable<int[]> CreateData()
        {
            List<int[]> rows = new List<int[]>();
            rows.Add(new[] { 1, 1, 11, 21 });
            rows.Add(new[] { 2, 2, 12, 22 });
            rows.Add(new[] { 3, 3, 13, 23 });
            rows.Add(new[] { 4, 4, 14, 24 });
            rows.Add(new[] { 5, 5, 15, 25 });
            rows.Add(new[] { 6, 6, 16, 26 });
            rows.Add(new[] { 7, 7, 17, 27 });
            rows.Add(new[] { 8, 8, 18, 28 });
            rows.Add(new[] { 9, 9, 19, 29 });
            rows.Add(new[] { 10, 10, 20, 30 });
            rows.Add(new[] { 11, 11, 21, 31 });
            return rows;
        }

        [TestMethod()]
        public void SelectSumTest_select_3_Column_Cost_return_6_15_24_21()
        {
            var sut = this.CreateHomework();
            
            var actualSum = sut.SelectSum(3, "Cost") as IEnumerable<int>;

            actualSum.Should().Equal(6, 15, 24, 21);
        }

        [TestMethod()]
        public void SelectSumTest_select_4_Column_Revenue_return_50_66_60()
        {
            var sut = this.CreateHomework();

            var actualSum = sut.SelectSum(4, "Revenue") as IEnumerable<int>;

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

            int actualSum = (int)sut.SelectSum(0, "Cost");
            
            Assert.AreEqual(0, actualSum);
        }
    }
}