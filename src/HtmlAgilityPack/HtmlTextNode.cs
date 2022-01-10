// HtmlAgilityPack V1.0 - Simon Mourier <simon underscore mourier at hotmail dot com>

using System;
using System.IO;

namespace HtmlAgilityPack
{
    /// <summary>
    /// Represents an HTML text node.
    /// </summary>
    public class HtmlTextNode : HtmlNode
    {
        #region Fields

        private string _text;

        #endregion

        #region Constructors

        internal HtmlTextNode(HtmlDocument ownerdocument, int index)
            :
                base(HtmlNodeType.Text, ownerdocument, index)
        {
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or Sets the HTML between the start and end tags of the object. In the case of a text node, it is equals to OuterHtml.
        /// </summary>
        public override string InnerHtml
        {
            get { return OuterHtml; }
            set { _text = value; }
        }

        /// <summary>
        /// Gets or Sets the object and its content in HTML.
        /// </summary>
        public override string OuterHtml
        {
            get
            {
                if (_text == null)
                {
                    return base.OuterHtml;
                }
                return HtmlDocument.HtmlEncode(_text);
            }
        }

        /// <summary>
        /// Gets or Sets the text of the node.
        /// </summary>
        public string Text
        {
            get
            {
                if (_text == null)
                {
                    return HtmlEntity.DeEntitize(base.OuterHtml);
                }
                return _text;
            }
            set { _text = value; }
        }

        public override void WriteTo(TextWriter outText, int level=0)
        {
            if (outText == null)
                throw new ArgumentNullException("outText");
            outText.Write(OuterHtml);
        }
        
        #endregion
    }
}