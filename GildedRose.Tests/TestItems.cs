using Xunit;
using System.Collections.Generic;
using Items;
using GildedRose.Console;

namespace GildedRose.Tests
{
    public class TestItems
    {
        Program _TestProgram;

        public TestItems()
        {
            _TestProgram = new Program();
        }

        [Fact]
        public void Test_Item_Getters()
        {
            //Given
            Item testItem = new Item { Name = "item", SellIn = 2, Quality = 10 };

            //Then
            Assert.Equal("item", testItem.Name);
            Assert.Equal(2, testItem.SellIn);
            Assert.Equal(10, testItem.Quality);
        }

        [Fact]
        public void Test_Item_Setters()
        {
            //Given
            Item testItem = new Item { Name = "item", SellIn = 2, Quality = 10 };

            //When
            testItem.Name = "new";
            testItem.SellIn = 5;
            testItem.Quality = 0;

            //Then
            Assert.Equal("new", testItem.Name);
            Assert.Equal(5, testItem.SellIn);
            Assert.Equal(0, testItem.Quality);
        }
    }
}