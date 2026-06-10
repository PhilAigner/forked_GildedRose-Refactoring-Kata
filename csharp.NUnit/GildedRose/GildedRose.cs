using System.Collections.Generic;

namespace GildedRoseKata;

public class GildedRose(IList<Item> items)
{
    public void UpdateQuality()
    {
        foreach (var item in items)
        {
            UpdateItem(item);
        }
    }

    private void UpdateItem(Item item)
    {
        if (item.Name == "Sulfuras, Hand of Ragnaros") return;

        if (item.Name == "Aged Brie")
            UpdateAgedBrie(item);
        else if (item.Name == "Backstage passes to a TAFKAL80ETC concert")
            UpdateBackstagePass(item);
        else
            UpdateNormalItem(item);

        item.SellIn--;

        if (item.SellIn < 0)
            ApplyExpiredEffect(item);
    }

    private void UpdateNormalItem(Item item)
    {
        if (item.Quality > 0)
            item.Quality--;
    }

    private void UpdateAgedBrie(Item item)
    {
        if (item.Quality < 50)
            item.Quality++;
    }

    private void UpdateBackstagePass(Item item)
    {
        if (item.Quality >= 50) return;

        item.Quality++;

        if (item.SellIn <= 10 && item.Quality < 50)
            item.Quality++;

        if (item.SellIn <= 5 && item.Quality < 50)
            item.Quality++;
    }

    private void ApplyExpiredEffect(Item item)
    {
        if (item.Name == "Aged Brie")
        {
            if (item.Quality < 50)
                item.Quality++;
        }
        else if (item.Name == "Backstage passes to a TAFKAL80ETC concert")
        {
            item.Quality = 0;
        }
        else
        {
            if (item.Quality > 0)
                item.Quality--;
        }
    }
}