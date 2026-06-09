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

    // Test 9: Backstage pass quality increases by 1 when SellIn > 10
    [Test]
    public void BackstagePass_QualityIncreasesBy1_WhenSellInAbove10()
    {
        var items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 15, Quality = 10 } };
        var app = new GildedRose(items);
        app.UpdateQuality();
        Assert.That(items[0].Quality, Is.EqualTo(11));
    }

    // Test 10: Backstage pass quality increases by 2 when SellIn is 10 or less
    [Test]
    public void BackstagePass_QualityIncreasesBy2_WhenSellIn10OrLess()
    {
        var items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 10, Quality = 10 } };
        var app = new GildedRose(items);
        app.UpdateQuality();
        Assert.That(items[0].Quality, Is.EqualTo(12));
    }

    // Test 11: Backstage pass quality increases by 3 when SellIn is 5 or less
    [Test]
    public void BackstagePass_QualityIncreasesBy3_WhenSellIn5OrLess()
    {
        var items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 10 } };
        var app = new GildedRose(items);
        app.UpdateQuality();
        Assert.That(items[0].Quality, Is.EqualTo(13));
    }

    // Test 12: Backstage pass quality drops to 0 after the concert
    [Test]
    public void BackstagePass_QualityDropsTo0_AfterConcert()
    {
        var items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 0, Quality = 40 } };
        var app = new GildedRose(items);
        app.UpdateQuality();
        Assert.That(items[0].Quality, Is.EqualTo(0));
    }

    // Test 13: Backstage pass quality never exceeds 50
    [Test]
    public void BackstagePass_QualityNeverExceeds50()
    {
        var items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 49 } };
        var app = new GildedRose(items);
        app.UpdateQuality();
        Assert.That(items[0].Quality, Is.EqualTo(50));
    }
}
