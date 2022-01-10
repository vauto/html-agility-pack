---
layout: default
title: From File
permalink: from-file
---

{% include template-h1.html %}

## Load Html From File

HtmlDocument.Load method loads an HTML document from a file.

### Example

The following example loads Html from file.

{% highlight csharp %}

var path = @"test.html";
		
var doc = new HtmlDocument();
doc.Load(path);

var node = doc.DocumentNode.SelectSingleNode("//body");

Console.WriteLine(node.OuterHtml);	

{% endhighlight %}

Click [here](https://dotnetfiddle.net/EsvZyg) to run this example.
