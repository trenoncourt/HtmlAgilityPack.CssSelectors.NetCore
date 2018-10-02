# HtmlAgilityPack.CssSelectors.NetCore &middot; [![NuGet](https://img.shields.io/nuget/dt/HtmlAgilityPack.CssSelectors.NetCore.svg?style=flat-square)](https://www.nuget.org/packages/HtmlAgilityPack.CssSelectors.NetCore) [![PRs Welcome](https://img.shields.io/badge/PRs-welcome-brightgreen.svg?style=flat-square)](http://makeapullrequest.com) [![GitHub license](https://img.shields.io/badge/license-MIT-blue.svg?style=flat-square)](https://github.com/trenoncourt/HtmlAgilityPack.CssSelectors.NetCore/blob/master/LICENSE)
NetStandard version of [HtmlAgilityPack.CssSelector](https://github.com/hcesar/HtmlAgilityPack.CssSelector/blob/master/README.md)
which use [HtmlAgilityPack](https://github.com/zzzprojects/html-agility-pack)

### Installation

```powershell
Install-Package HtmlAgilityPack.CssSelectors.NetCore
```

### Usage

```c#
var doc = new HtmlAgilityPack.HtmlDocument();
doc.Load(new FileStream("test.html", FileMode.Open));

IList<HtmlNode> nodes = doc.QuerySelectorAll("div .my-class[data-attr=123] > ul li");
HtmlNode node = nodes[0].QuerySelector("p.with-this-class span[data-myattr]");
```

## Buy me a beer
[![Donate](https://img.shields.io/badge/Donate-PayPal-green.svg)](https://www.paypal.me/trenoncourt/5)
