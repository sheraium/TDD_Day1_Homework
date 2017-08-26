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
        private DataAnalyzer<Product> CreateSUT()
        {
            return new DataAnalyzer<Product>(this.CreateTestData());
        }

        private IEnumerable<Product> CreateTestData()
        {
            return new List<Product>()
                       {
                           new Product() { Id = 1, Cost = 1, Revenue = 11, SellPrice = 21 },
                           new Product() { Id = 2, Cost = 2, Revenue = 12, SellPrice = 22 },
                           new Product() { Id = 3, Cost = 3, Revenue = 13, SellPrice = 23 },
                           new Product() { Id = 4, Cost = 4, Revenue = 14, SellPrice = 24 },
                           new Product() { Id = 5, Cost = 5, Revenue = 15, SellPrice = 25 },
                           new Product() { Id = 6, Cost = 6, Revenue = 16, SellPrice = 26 },
                           new Product() { Id = 7, Cost = 7, Revenue = 17, SellPrice = 27 },
                           new Product() { Id = 8, Cost = 8, Revenue = 18, SellPrice = 28 },
                           new Product() { Id = 9, Cost = 9, Revenue = 19, SellPrice = 29 },
                           new Product() { Id = 10, Cost = 10, Revenue = 20, SellPrice = 30 },
                           new Product() { Id = 11, Cost = 11, Revenue = 21, SellPrice = 31 }
                       };
        }

        [TestMethod()]
        public void SelectSumTest_select_3_Column_Cost_return_6_15_24_21()
        {
            var sut = this.CreateSUT();
            
            var actualSum = sut.SelectSum(3, "Cost");

            actualSum.Should().Equal(6, 15, 24, 21);
        }

        [TestMethod()]
        public void SelectSumTest_select_4_Column_Revenue_return_50_66_60()
        {
            var sut = this.CreateSUT();

            var actualSum = sut.SelectSum(4, "Revenue");

            actualSum.Should().Equal(50, 66, 60);
        }
        
        [TestMethod()]
        public void SelectSumTest_select_MinusNumber_throw_ArgumentException()
        {
            var sut = this.CreateSUT();

            Action act = () => sut.SelectSum(-1, "Cost");

            act.ShouldThrow<ArgumentException>();
        }

        [TestMethod()]
        public void SelectSumTest_select_NotExistColumn_throw_ArgumentException()
        {
            var sut = this.CreateSUT();

            Action act = () => sut.SelectSum(3, "NotExist");

            act.ShouldThrow<ArgumentException>();
        }

        [TestMethod()]
        public void SelectSumTest_select_0_return_0()
        {
            var sut = this.CreateSUT();

            var actualSum = sut.SelectSum(0, "Cost");

            actualSum.Should().Equal(0);
        }
    }
}