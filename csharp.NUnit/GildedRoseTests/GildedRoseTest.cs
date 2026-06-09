using System.Collections.Generic;
using GildedRoseKata;
using NUnit.Framework;

namespace GildedRoseTests;

public class GildedRoseTest
{
    // Test 1: Test if normal item loses 1 quality per day
    [Test]
    public void NormalItem_QualityDecreasesBy1_BeforeSellIn()
    {
        var items = new List<Item> { new Item { Name = "Normal Item", SellIn = 5, Quality = 10 } };
        var app = new GildedRose(items);
        app.UpdateQuality();
        Assert.That(items[0].Quality, Is.EqualTo(9));
    }

    // Test 2: After sell-by date, quality decreases twice as fast
    [Test]
    public void NormalItem_QualityDecreasesBy2_AfterSellIn()
    {
        var items = new List<Item> { new Item { Name = "Normal Item", SellIn = 0, Quality = 10 } };
        var app = new GildedRose(items);
        app.UpdateQuality();
        Assert.That(items[0].Quality, Is.EqualTo(8));
    }

    // Test 3: Quality never goes below 0
    [Test]
    public void NormalItem_QualityNeverNegative()
    {
        var items = new List<Item> { new Item { Name = "Normal Item", SellIn = 5, Quality = 0 } };
        var app = new GildedRose(items);
        app.UpdateQuality();
        Assert.That(items[0].Quality, Is.EqualTo(0));
    }
}
