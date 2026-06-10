using System.Collections.Generic;

namespace GildedRoseKata;

public class GildedRose(IList<Item> items)
{
    private bool IsAgedBrie(Item item) => item.Name == "Aged Brie";
    private bool IsBackstagePass(Item item) => item.Name == "Backstage passes to a TAFKAL80ETC concert";
    private bool IsSulfuras(Item item) => item.Name == "Sulfuras, Hand of Ragnaros";

    public void UpdateQuality()
    {
        foreach (var item in items)
        {
            UpdateItem(item);
        }
    }

    private void UpdateItem(Item item)
    {
        if (IsSulfuras(item)) return;

        if (IsAgedBrie(item))
            UpdateAgedBrie(item);
        else if (IsBackstagePass(item))
            UpdateBackstagePass(item);
        else
            UpdateNormalItem(item);

        item.SellIn--;

        // post-sell-in adjustments
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
        if (IsAgedBrie(item))
        {
            if (item.Quality < 50)
                item.Quality++;
        }
        else if (IsBackstagePass(item))
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