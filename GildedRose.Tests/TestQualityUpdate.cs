using Xunit;
using System.Collections.Generic;

using GildedRose.Console;

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
                    new Item {Name = "Generic Item", SellIn = 10, Quality = 20},
                    new Item {Name = "Aged Brie", SellIn = 2, Quality = 0},
                    new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
                    new Item {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 15, Quality = 20}
                }
            };
        }

        [Fact]
        public void Sulfuras_quality_does_not_decrement()
        {
            // Arrange
            var expected = _testSet.Items[2].Quality;

            // Act
            _testSet.UpdateQuality();
            var actual = _testSet.Items[2].Quality;

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Brie_UpdateQuality_Increments()
        {
            // Arrange
            var expected = 1;
            
            // Act
            _testSet.UpdateQuality();
            var actual = _testSet.Items[1];

            // Assert
            Assert.Equal(expected, actual.SellIn);
            Assert.Equal(expected, actual.Quality);
        }

        [Fact]
        public void BackStage_UpdateQuality_Increments()
        {
        // Arrange

        // Actual

        // Assert
        
        }

        [Fact]
        public void Generic_UpdateQuality_Decrement()
        {
        //Given
        
        //When
        
        //Then
        }
    }
}