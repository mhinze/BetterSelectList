using System.Collections.Generic;
using System.Web.Mvc;

namespace BetterSelectList
{
    // ReSharper disable MemberCanBePrivate.Global
    public class BetterSelectListItem : SelectListItem
    {
        public BetterSelectListItem()
        {
        }

        public BetterSelectListItem(string value,
            string text,
            bool selected = false,
            IDictionary<string, object> htmlAttributes = null,
            string group = null)
        {
            Value = value;
            Text = text;
            Selected = selected;
            HtmlAttributes = htmlAttributes;
            Group = group;
        }

        public BetterSelectListItem(string value,
            string text,
            bool selected = false,
            object htmlAttributes = null,
            string group = null)
            : this(value, text, selected, HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes), group)
        {
        }

        public string Group { get; set; }

        public IDictionary<string, object> HtmlAttributes { get; set; }
    }

    // ReSharper restore MemberCanBePrivate.Global
}