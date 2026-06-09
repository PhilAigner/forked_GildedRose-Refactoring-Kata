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

    // Test 4: Aged Brie increases in quality by 1 before sell-by date
    [Test]
    public void AgedBrie_QualityIncreasesBy1_BeforeSellIn()
    {
        var items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 5, Quality = 10 } };
        var app = new GildedRose(items);
        app.UpdateQuality();
        Assert.That(items[0].Quality, Is.EqualTo(11));
    }

    // Test 5: Aged Brie increases in quality by 2 after sell-by date
    [Test]
    public void AgedBrie_QualityIncreasesBy2_AfterSellIn()
    {
        var items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 0, Quality = 10 } };
        var app = new GildedRose(items);
        app.UpdateQuality();
        Assert.That(items[0].Quality, Is.EqualTo(12));
    }

    // Test 6: Aged Brie quality never exceeds 50
    [Test]
    public void AgedBrie_QualityNeverExceeds50()
    {
        var items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 5, Quality = 50 } };
        var app = new GildedRose(items);
        app.UpdateQuality();
        Assert.That(items[0].Quality, Is.EqualTo(50));
    }

    // Test 7: Sulfuras never changes in quality
    [Test]
    public void Sulfuras_QualityNeverChanges()
    {
        var items = new List<Item> { new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 5, Quality = 80 } };
        var app = new GildedRose(items);
        app.UpdateQuality();
        Assert.That(items[0].Quality, Is.EqualTo(80));
    }

    // Test 8: Sulfuras SellIn never decreases
    [Test]
    public void Sulfuras_SellInNeverChanges()
    {
        var items = new List<Item> { new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 5, Quality = 80 } };
        var app = new GildedRose(items);
        app.UpdateQuality();
        Assert.That(items[0].SellIn, Is.EqualTo(5));
    }
}
