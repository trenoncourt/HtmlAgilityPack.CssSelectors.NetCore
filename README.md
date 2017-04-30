# HtmlAgilityPack.CssSelectors.NetCore
.Net Core version of [HtmlAgilityPack.CssSelector](https://github.com/hcesar/HtmlAgilityPack.CssSelector/blob/master/README.md)
which use the [.Net Core version of HtmlAgilityPack](https://github.com/zulfahmi93/HtmlAgilityPack.NetCore)

Install with [NuGet](https://www.nuget.org/packages/HtmlAgilityPack.CssSelectors.NetCore/1.0.0):
```powershell
Install-Package HtmlAgilityPack.CssSelectors.NetCore
```

Usage:
```c#
var doc = new HtmlAgilityPack.HtmlDocument();
doc.Load(new FileStream("test.html", FileMode.Open));

IList<HtmlNode> nodes = doc.QuerySelectorAll("div .my-class[data-attr=123] > ul li");
HtmlNode node = nodes[0].QuerySelector("p.with-this-class span[data-myattr]");
```
