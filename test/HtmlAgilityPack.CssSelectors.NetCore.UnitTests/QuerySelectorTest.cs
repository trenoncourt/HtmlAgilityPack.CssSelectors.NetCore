using System.IO;
using System.Text;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HtmlAgilityPack.CssSelectors.NetCore.UnitTests
{
    [TestClass]
    public class QuerySelectorTest
    {
        private static readonly HtmlDocument Doc = LoadHtml();

        [TestMethod]
        public void IdSelectorMustReturnOnlyFirstElement()
        {
            var elements = Doc.QuerySelectorAll("#myDiv");
            Assert.IsTrue(elements.Count == 1);
            Assert.IsTrue(elements[0].Id == "myDiv");
            Assert.IsTrue(elements[0].Attributes["first"].Value == "1");
        }

        [TestMethod]
        public void GetElementsByAttribute()
        {
            var elements = Doc.QuerySelectorAll("*[id=myDiv]");

            Assert.IsTrue(elements.Distinct().Count() == 2 && elements.Count == 2);
            foreach (HtmlNode node in elements)
                Assert.IsTrue(node.Id == "myDiv");
        }

        [TestMethod]
        public void GetElementsByClassName1()
        {
            var elements1 = Doc.QuerySelectorAll(".cls-a");
            var elements2 = Doc.QuerySelectorAll(".clsb");

            Assert.IsTrue(elements1.Count == 1);
            for (int i = 0; i < elements1.Count; i++)
                Assert.IsTrue(elements1[i] == elements2[i]);
        }

		[TestMethod]
        public void GetElementsByClassName_MultiClasses()
        {
            var elements = Doc.QuerySelectorAll(".cls-a, .cls-b");

            Assert.IsTrue(elements.Count == 2);
            Assert.IsTrue(elements[0].Id == "spanA");
            Assert.IsTrue(elements[1].Id == "spanB");
        }

		[TestMethod]
        public void GetElementsByClassName_WithUnderscore()
        {
            var elements = Doc.QuerySelectorAll(".underscore_class");

            Assert.IsTrue(elements.Count == 1);
            Assert.IsTrue(elements[0].Id == "spanB");
        }

		[TestMethod]
        public void GetElementsWithTwoClasses()
        {
            var elements = Doc.QuerySelectorAll(".active.lv1");

            Assert.IsTrue(elements.Count == 1);
            Assert.IsTrue(elements[0].InnerText == "L12");
        }

		[TestMethod]
        public void GetElementsByClassInsideClass()
        {
            var elements = Doc.QuerySelectorAll(".lv0 .lv1");

            Assert.IsTrue(elements.Count == 3);
            Assert.IsTrue(elements[1].InnerText == "L12");
        }

		[TestMethod]
        public void GetElementsByClassInsideId()
        {
            var elements = Doc.QuerySelectorAll("#ul .lv1");

            Assert.IsTrue(elements.Count == 3);
            Assert.IsTrue(elements[1].InnerText == "L12");
        }

		[TestMethod]
        public void GetElementsWithoutComments()
        {
            var element = Doc.QuerySelector("#with-comments");
            string text = element.ChildNodes
                .Where(d => d.NodeType == HtmlNodeType.Element)
                .SelectMany(d => d.ChildNodes)
                .Where(d => d.NodeType != HtmlNodeType.Comment)
                .Aggregate("", (s, n) => s + n.InnerHtml);
            Assert.IsTrue(text == "Hello World!");
        }



        private static HtmlDocument LoadHtml()
        {
            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(File.ReadAllText("Test1.html", Encoding.UTF8));

            return htmlDocument;
        }

    }
}
