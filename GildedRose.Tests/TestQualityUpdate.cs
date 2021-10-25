using Xunit;
using Items;
using System.Collections.Generic;

using GildedRose;

namespace GildedRose.Tests
{
    public class TestQualityUpdate
    {
        Program _testSet;
        public TestQualityUpdate()
        {
            _testSet = new Program()
            {
                Items = new List<Item>
                {
                    new Item {Name = "Generic Item", SellIn = 5, Quality = 20},
                    new Brie {Name = "Aged Brie", SellIn = 2, Quality = 0},
                    new Sulfuras {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
                    new BackstagePass {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 11, Quality = 5}
                }
            };
        }

        [Fact]
        public void Sulfuras_does_not_decrement()
        {
            // Arrange
            var item = _testSet.Items[2];
            var oldQuality = item.Quality;
            var oldSellIn = item.SellIn;

            // Act
            Program.UpdateInventory(_testSet.Items);
            var expectedQuality = oldQuality; 
            var expectedSellIn = oldSellIn;

            // Assert
            Assert.Equal(expectedQuality, item.Quality);
            Assert.Equal(expectedSellIn, item.SellIn);
        }

        [Fact]
        public void Brie_quality_increments_one_when_not_expired()
        {
            // Arrange
            var item = _testSet.Items[1];
            var oldQuality = item.Quality;
            var oldSellIn = item.SellIn;

            // Act
            Program.UpdateInventory(_testSet.Items);
            var expectedQuality = oldQuality + 1;
            var expectedSellIn = oldSellIn - 1;

            // Assert
            Assert.Equal(expectedQuality, item.Quality);
            Assert.Equal(expectedSellIn, item.SellIn);
        }

        [Fact]
        public void BackStage_quality_increments_one_when_Sellin_is_over_ten()
        {
            // Arrange
            var item = _testSet.Items[3];
            var OldQuality = item.Quality;
            var oldSellIn = item.SellIn;

            // Actual
            Program.UpdateInventory(_testSet.Items);
            var expectedQuality = OldQuality + 1;
            var expectedSellIn = oldSellIn - 1;

            // Assert
            Assert.Equal(expectedQuality, item.Quality);
            Assert.Equal(expectedSellIn, item.SellIn);
        }

        [Fact]
        public void BackStage_quality_increments_two_when_Sellin_is_less_than_10()
        {
            // Arrange
            var item = _testSet.Items[3];
            while (item.SellIn > 10)
            {
                Program.UpdateInventory(_testSet.Items);
            }
            var OldQuality = item.Quality;
            var oldSellIn = item.SellIn;

            // Actual
            Program.UpdateInventory(_testSet.Items);
            var expectedQuality = OldQuality + 2;
            var expectedSellIn = oldSellIn - 1;

            // Assert
            Assert.Equal(expectedQuality, item.Quality);
            Assert.Equal(expectedSellIn, item.SellIn);
        }

        [Fact]
        public void BackStage_quality_increments_three_when_Sellin_is_less_than_5()
        {
            // Arrange
            var item = _testSet.Items[3];
            while (item.SellIn > 5)
            {
                Program.UpdateInventory(_testSet.Items);
            }
            var OldQuality = item.Quality;
            var OldSellIn = item.SellIn;

            // Actual
            Program.UpdateInventory(_testSet.Items);
            var expectedQuality = OldQuality + 3;
            var expectedSellIn = OldSellIn - 1;

            // Assert
            Assert.Equal(expectedQuality, item.Quality);
            Assert.Equal(expectedSellIn, item.SellIn);
        }

        [Fact]
        public void BackStage_quality_sets_to_zero_when_sellin_is_negative()
        {
            // Arrange
            var item = _testSet.Items[3];
            while (item.SellIn > 0)
            {
                Program.UpdateInventory(_testSet.Items);
            }
            var OldQuality = item.Quality;
            var oldSellIn = item.SellIn;

            // Actual
            Program.UpdateInventory(_testSet.Items);
            var expectedQuality = 0;
            var expectedSellIn = oldSellIn - 1;

            // Assert
            Assert.Equal(expectedQuality, item.Quality);
            Assert.Equal(expectedSellIn, item.SellIn);
        }

        [Fact]
        public void Generic_quality_decrements_one_when_sellin_is_positive()
        {
            //Given
            var item = _testSet.Items[0];
            var oldQuality = item.Quality;
            var oldSellIn = item.SellIn;

            //When
            Program.UpdateInventory(_testSet.Items);
            var expectedQuality = oldQuality - 1;
            var expectedSellIn = oldSellIn - 1; 

            //Then
            Assert.Equal(expectedQuality, item.Quality);
            Assert.Equal(expectedSellIn, item.SellIn);
        }


        [Fact]
        public void Generic_quality_decrements_two_when_sellin_is_negative()
        {
            // Arrange
            var item = _testSet.Items[0];
            while (item.SellIn > -1)
            {
                Program.UpdateInventory(_testSet.Items);
            }
            var OldQuality = item.Quality;
            var oldSellIn = item.SellIn;

            // Actual
            Program.UpdateInventory(_testSet.Items);
            var expectedQuality = OldQuality - 2;
            var expectedSellIn = oldSellIn - 1;

            // Assert
            Assert.Equal(expectedQuality, item.Quality);
            Assert.Equal(expectedSellIn, item.SellIn);
        }

        [Fact]
        public void Quality_can_never_increase_above_50()
        {
            // Arrange
            var item = _testSet.Items[1];
            while (item.Quality != 50)
            {
                Program.UpdateInventory(_testSet.Items);
            }
            var OldQuality = item.Quality;
            var oldSellIn = item.SellIn;

            // Actual
            Program.UpdateInventory(_testSet.Items);
            var expectedQuality = OldQuality;
            var expectedSellIn = oldSellIn - 1;

            // Assert
            Assert.Equal(expectedQuality, item.Quality);
            Assert.Equal(expectedSellIn, item.SellIn);
        }

        [Fact]
        public void Quality_can_never_decrease_below_0()
        {
            // Arrange
            var item = _testSet.Items[0];
            while (item.Quality != 0)
            {
                Program.UpdateInventory(_testSet.Items);
            }
            var OldQuality = item.Quality;
            var oldSellIn = item.SellIn;

            // Actual
            Program.UpdateInventory(_testSet.Items);
            var expectedQuality = OldQuality;
            var expectedSellIn = oldSellIn - 1;

            // Assert
            Assert.Equal(expectedQuality, item.Quality);
            Assert.Equal(expectedSellIn, item.SellIn);
        }
    }
}