

namespace Items
{
    public class Item
    {
        public bool Conjured { get; set; } = false;

        public string Name { get; set; }

        public int SellIn { get; set; }

        public int Quality { get; set; }

        public void Update()
        {
            UpdateQuality();

            if (Conjured)
                UpdateQuality();
            
            UpdateSellIn();
        }

        public virtual void UpdateQuality()
        {
            if (SellIn < 0 && Quality > 1)
                Quality -= 2;
            else if (Quality > 0)
                Quality--;
        }

        public virtual void UpdateSellIn()
        {
            SellIn--;
        }
    }

    public class Brie : Item
    {
        public override void UpdateQuality()
        {
            if (SellIn < 0 && Quality < 49)
                Quality += 2;
            else if (Quality < 50)
                Quality++;
        }
    }

    public class Sulfuras : Item
    {
        public override void UpdateQuality()
        {
            // dis does nutting;
        }
        
        public override void UpdateSellIn()
        {
            // dis does nutting;
        }
    }

    public class BackstagePass : Item
    {
        public override void UpdateQuality()
        {
            if (SellIn <= 0)
            {
                Quality = 0;
            }
            else if (Quality < 50)
            {
                Quality++;

                if (Quality < 50 && SellIn <= 10)
                {
                    Quality++;

                    if (Quality < 50 && SellIn <= 5)
                        Quality++;
                }
            }
        }
    }
}