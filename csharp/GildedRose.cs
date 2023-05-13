using System.Collections.Generic;

namespace csharp
{
    public class GildedRose
    {
        private const int MAX_QUALITY = 50;
        private const int MIN_QUALITY = 0;
        private const string SULFURAS_ITEM_NAME = "Sulfuras, Hand of Ragnaros";
        private const string AGED_BRIE_ITEM_NAME = "Aged Brie";
        private const string BACKSTAGE_PASSES_ITEM_NAME = "Backstage passes to a TAFKAL80ETC concert";
        private const int BACKSTAGE_PASSES_1ST_THRESHOLD = 10;
        private const int BACKSTAGE_PASSES_2ND_THRESHOLD = 5;

        private IList<Item> Items;
        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }

        public void UpdateQuality()
        {
            foreach (var item in Items)
            {
                UpdateItemQuality(item);
                UpdateItemSellIn(item);
            }
        }

        private void UpdateItemQuality(Item item)
        {
            if (item.Name == SULFURAS_ITEM_NAME)
            {
                return;
            }

            if (item.Name == AGED_BRIE_ITEM_NAME)
            {
                IncreaseQuality(item);
                if (item.SellIn < 0)
                {
                    IncreaseQuality(item);
                }
            }
            else if (item.Name == BACKSTAGE_PASSES_ITEM_NAME)
            {
                IncreaseQuality(item);
                if (item.SellIn <= BACKSTAGE_PASSES_1ST_THRESHOLD)
                {
                    IncreaseQuality(item);
                }
                if (item.SellIn <= BACKSTAGE_PASSES_2ND_THRESHOLD)
                {
                    IncreaseQuality(item);
                }
                if (item.SellIn < 0)
                {
                    item.Quality = MIN_QUALITY;
                }
            }
            else
            {
                DecreaseQuality(item);
                if (item.SellIn < 0)
                {
                    DecreaseQuality(item);
                }
            }
        }

        private void UpdateItemSellIn(Item item)
        {
            if (item.Name != SULFURAS_ITEM_NAME)
            {
                item.SellIn -= 1;
            }
        }

        private void IncreaseQuality(Item item)
        {
            if (item.Quality < MAX_QUALITY)
            {
                item.Quality += 1;
            }
        }

        private void DecreaseQuality(Item item)
        {
            if (item.Quality > MIN_QUALITY)
            {
                item.Quality -= 1;
            }
        }
    }


}
