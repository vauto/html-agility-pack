﻿using System;
using System.IO;
using System.Linq;
using NUnit.Framework;

namespace HtmlAgilityPack.Tests
{
    [TestFixture]
    public class HtmlNode2
    {
        [Test(Description =
            "Attributes should maintain their original character casing if OptionOutputOriginalCase is true")]
        public void EnsureAttributeOriginalCaseIsPreserved()
        {
            var html = "<html><body><div AttributeIsThis=\"val\"></div></body></html>";
            var doc = new HtmlDocument
            {
                OptionOutputOriginalCase = true
            };
            doc.LoadHtml(html);
            var div = doc.DocumentNode.Descendants("div").FirstOrDefault();
            var writer = new StringWriter();
            div.WriteAttributes(writer, false);
            var result = writer.GetStringBuilder().ToString();
            Assert.AreEqual(" AttributeIsThis=\"val\"", result);
        }

        [Test]
        public void ReadNotCloseTag()
        {
            var document = new HtmlDocument();
            document.LoadHtml("<ul><li>item<span></li></ul>");
            var span = document.DocumentNode.SelectSingleNode("//span");
            if (span == null) throw new Exception("Failed to find span element");
            var OuterHtml = span.OuterHtml;
            var InnerHtml = span.InnerHtml;
            var InnerText = span.InnerText;
            
            Assert.IsNotNull(OuterHtml);
            Assert.IsNotNull(InnerHtml);
            Assert.IsNotNull(InnerText);
        }
    }
}