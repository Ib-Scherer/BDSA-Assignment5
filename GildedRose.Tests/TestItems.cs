using Xunit;
using System.Collections.Generic;
using Items;
using GildedRose;

namespace GildedRose.Tests
{
    public class TestItems
    {
        [Fact]
        public void Test_Item_Getters()
        {
            //Given
            Item testItem = new GenericItem { Name = "item", SellIn = 2, Quality = 10 };

            //Then
            Assert.Equal("item", testItem.Name);
            Assert.Equal(2, testItem.SellIn);
            Assert.Equal(10, testItem.Quality);
        }

        [Fact]
        public void Test_Item_Setters()
        {
            //Given
            Item testItem = new GenericItem { Name = "item", SellIn = 2, Quality = 10 };

            //When
            testItem.Name = "new";
            testItem.SellIn = 5;
            testItem.Quality = 0;

            //Then
            Assert.Equal("new", testItem.Name);
            Assert.Equal(5, testItem.SellIn);
            Assert.Equal(0, testItem.Quality);
        }

        [Fact]
        public void Test_Generic_Item_update_Quality_decreses_1_when_SellIn_gte_0()
        {
            //Given
            Item testItem = new GenericItem { Name = "item", SellIn = 5, Quality = 1 };
            var expectedQuality = testItem.Quality - 1;
            var expectedSellIn = testItem.SellIn - 1;

            //When
            testItem.Update();

            //Then
            Assert.Equal(expectedQuality, testItem.Quality);
            Assert.Equal(expectedSellIn, testItem.SellIn);
        }

        [Fact]
        public void Test_Generic_Item_update_Quality_decrese_2_when_SellIn_lt_0()
        {
            //Given
            Item testItem = new GenericItem { Name = "item", SellIn = -1, Quality = 2 };
            var expectedQuality = testItem.Quality - 2;
            var expectedSellIn = testItem.SellIn - 1;

            //When
            testItem.Update();

            //Then
            Assert.Equal(expectedQuality, testItem.Quality);
            Assert.Equal(expectedSellIn, testItem.SellIn);
        }

        [Fact]
        public void Test_Brie_Update_where_SellsIn_gte_0_increases_1()
        {
            //Given
            Item testItem = new Brie { Name = "item", SellIn = 5, Quality = 0 };
            var expectedQuality = testItem.Quality + 1;
            var expectedSellIn = testItem.SellIn - 1;

            //When
            testItem.Update();

            //Then
            Assert.Equal(expectedQuality, testItem.Quality);
            Assert.Equal(expectedSellIn, testItem.SellIn);
        }

        [Fact]
        public void Test_Brie_Update_where_SellsIn_lt_0_increases_2()
        {
            //Given
            Item testItem = new Brie { Name = "item", SellIn = -1, Quality = 0 };
            var expectedQuality = testItem.Quality + 2;
            var expectedSellIn = testItem.SellIn - 1;

            //When
            testItem.Update();

            //Then
            Assert.Equal(expectedQuality, testItem.Quality);
            Assert.Equal(expectedSellIn, testItem.SellIn);
        }

        [Fact]
        public void Sulfuras_never_changes()
        {
            //Given
            Item testItem = new Sulfuras { Name = "item", SellIn = 5, Quality = 25 };
            var expectedQuality = testItem.Quality;
            var expectedSellIn = testItem.SellIn;

            //When
            testItem.Update();

            //Then
            Assert.Equal(expectedQuality, testItem.Quality);
            Assert.Equal(expectedSellIn, testItem.SellIn);
        }

        [Fact]
        public void BackstagePass_Update_Increases_1_when_Sellin_gt_10()
        {
            //Given
            Item testItem = new BackstagePass { Name = "item", SellIn = 15, Quality = 10 };
            var expectedQuality = testItem.Quality + 1;
            var expectedSellIn = testItem.SellIn - 1;

            //When
            testItem.Update();

            //Then
            Assert.Equal(expectedQuality, testItem.Quality);
            Assert.Equal(expectedSellIn, testItem.SellIn);
        }

        [Fact]
        public void BackstagePass_Update_Increases_2_when_Sellin_gt_5_and_lte_10()
        {
            //Given
            Item testItem = new BackstagePass { Name = "item", SellIn = 7, Quality = 10 };
            var expectedQuality = testItem.Quality + 2;
            var expectedSellIn = testItem.SellIn - 1;

            //When
            testItem.Update();

            //Then
            Assert.Equal(expectedQuality, testItem.Quality);
            Assert.Equal(expectedSellIn, testItem.SellIn);
        }

        [Fact]
        public void BackstagePass_Update_Increases_3_when_Sellin_lt_5_and_gt_0()
        {
            //Given
            Item testItem = new BackstagePass { Name = "item", SellIn = 2, Quality = 10 };
            var expectedQuality = testItem.Quality + 3;
            var expectedSellIn = testItem.SellIn - 1;

            //When
            testItem.Update();

            //Then
            Assert.Equal(expectedQuality, testItem.Quality);
            Assert.Equal(expectedSellIn, testItem.SellIn);
        }

        [Fact]
        public void BackstagePass_Update_set_quality_to_0_when_SellIn_lte_0()
        {
            //Given
            Item testItem = new BackstagePass { Name = "item", SellIn = 0, Quality = 10 };
            var expectedQuality = 0;
            var expectedSellIn = testItem.SellIn - 1;

            //When
            testItem.Update();

            //Then
            Assert.Equal(expectedQuality, testItem.Quality);
            Assert.Equal(expectedSellIn, testItem.SellIn);
        }

        [Fact]
        public void Generic_Items_Never_Decrement_past_0()
        {
            //Given
            var TestItems = new List<Item>
            {
                new GenericItem { Name = "item 1", SellIn = 1, Quality = -1},
                new GenericItem { Name = "item 2", SellIn = 1, Quality = 0},
                new GenericItem { Name = "item 3", SellIn = -1, Quality = 1},
                new GenericItem { Name = "item 4", SellIn = -1, Quality = 2}
            };

            //When
            Program.UpdateInventory(TestItems);

            //Then
            Assert.Equal(-1, TestItems[0].Quality);
            Assert.Equal(0, TestItems[1].Quality);
            Assert.Equal(0, TestItems[2].Quality);
            Assert.Equal(0, TestItems[3].Quality);
        }

        [Fact]
        public void Brie_Never_Increments_past_50()
        {
            //Given
            var TestItems = new List<Item>
            {
                new Brie { Name = "item 1", SellIn = 1, Quality = 51},
                new Brie { Name = "item 2", SellIn = 1, Quality = 50},
                new Brie { Name = "item 3", SellIn = -1, Quality = 49},
                new Brie { Name = "item 4", SellIn = -1, Quality = 48}
            };

            //When
            Program.UpdateInventory(TestItems);

            //Then
            Assert.Equal(51, TestItems[0].Quality);
            Assert.Equal(50, TestItems[1].Quality);
            Assert.Equal(50, TestItems[2].Quality);
            Assert.Equal(50, TestItems[3].Quality);
        }

        [Fact]
        public void Backstage_Never_Increments_past_50()
        {
            //Given
            var TestItems = new List<Item>
            {
                new BackstagePass { Name = "item 1", SellIn = 15, Quality = 51},
                new BackstagePass { Name = "item 2", SellIn = 15, Quality = 50},
                new BackstagePass { Name = "item 3", SellIn = 9, Quality = 49},
                new BackstagePass { Name = "item 4", SellIn = 3, Quality = 48}
            };

            //When
            Program.UpdateInventory(TestItems);

            //Then
            Assert.Equal(51, TestItems[0].Quality);
            Assert.Equal(50, TestItems[1].Quality);
            Assert.Equal(50, TestItems[2].Quality);
            Assert.Equal(50, TestItems[3].Quality);
        }

        [Fact]
        public void Test_Conjured_Items()
        {
            //Given
            var TestItems = new List<Item>
            {
                new GenericItem { Name = "item 1", SellIn = 15, Quality = 20, Conjured = true},
                new GenericItem { Name = "item 1", SellIn = -1, Quality = 20, Conjured = true},

                new Brie { Name = "item 2", SellIn = 15, Quality = 20, Conjured = true},
                new Brie { Name = "item 2", SellIn = -1, Quality = 20, Conjured = true},

                new Sulfuras { Name = "item 3", SellIn = 9, Quality = 20, Conjured = true},

                new BackstagePass { Name = "item 4", SellIn = 15, Quality = 20, Conjured = true},
                new BackstagePass { Name = "item 4", SellIn = 9, Quality = 20, Conjured = true},
                new BackstagePass { Name = "item 4", SellIn = 3, Quality = 20, Conjured = true}
            };

            //When
            Program.UpdateInventory(TestItems);

            //Then
            Assert.Equal(18, TestItems[0].Quality);
            Assert.Equal(16, TestItems[1].Quality);

            Assert.Equal(22, TestItems[2].Quality);
            Assert.Equal(24, TestItems[3].Quality);

            Assert.Equal(20, TestItems[4].Quality);
            
            Assert.Equal(22, TestItems[5].Quality);
            Assert.Equal(24, TestItems[6].Quality);
            Assert.Equal(26, TestItems[7].Quality);
        }
    }
}