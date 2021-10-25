

namespace Items
{
    public class Item
    {
        public bool Conjured { get; set; }

        public string Name { get; set; }

        public int SellIn { get; set; }

        public int Quality { get; set; }

        public virtual void Update()
        {
            if (SellIn < 0)
                Quality -= 2;
            else
                Quality--;

            SellIn--;
        }
    }

    public class Brie : Item
    {
        public override void Update()
        {
            if (SellIn < 0 && Quality < 49)
                Quality += 2;
            else if (Quality < 50)
                Quality++;

            SellIn--;
        }
    }

    public class Sulfuras : Item
    {
        public override void Update()
        {
            // dis does nutting;
        }
    }

    public class BackstagePass : Item
    {
        public override void Update()
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

            SellIn--;
        }
    }
}