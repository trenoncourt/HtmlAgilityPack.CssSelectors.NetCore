# HtmlAgilityPack.CssSelectors.NetCore
NetStandard version of [HtmlAgilityPack.CssSelector](https://github.com/hcesar/HtmlAgilityPack.CssSelector/blob/master/README.md)
which use [HtmlAgilityPack](https://github.com/zzzprojects/html-agility-pack)

Nuget: [![Nuget Downloads](https://img.shields.io/nuget/dt/HtmlAgilityPack.CssSelectors.NetCore.svg)](https://www.nuget.org/packages/HtmlAgilityPack.CssSelectors.NetCore)
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
## Buy me a beer
[![Donate](https://img.shields.io/badge/Donate-PayPal-green.svg)](https://www.paypal.me/trenoncourt/5)
