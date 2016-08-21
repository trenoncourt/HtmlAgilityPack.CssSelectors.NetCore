# HtmlAgilityPack.CssSelectors.NetCore
.Net Core version of [HtmlAgilityPack.CssSelector](https://github.com/hcesar/HtmlAgilityPack.CssSelector/blob/master/README.md)
which use the [.Net Core version of HtmlAgilityPack](https://github.com/zulfahmi93/HtmlAgilityPack.NetCore)

Usage:
```c#
var doc = new HtmlAgilityPack.HtmlDocument();
doc.Load("test.html");
  
IList<HtmlNode> nodes = doc.QuerySelectorAll("div .my-class[data-attr=123] > ul li");
HtmlNode node = nodes.QuerySelector("p.with-this-class span[data-myattr]");
```
