using System.Collections.Generic;
using System.Web.Mvc;

namespace BetterSelectList
{
    // ReSharper disable MemberCanBePrivate.Global
    public class BetterSelectListItem : SelectListItem
    {

		public string Group = null;

        public BetterSelectListItem() { }

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

        public BetterSelectListItem(string value, string text, bool selected = false, object htmlAttributes = null)
            : this(value, text, selected, HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes)) { }

        public IDictionary<string, object> HtmlAttributes { get; set; }
    }

    // ReSharper restore MemberCanBePrivate.Global
}