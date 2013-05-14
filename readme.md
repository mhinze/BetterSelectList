BetterSelectList
================

Addressing a small limitation with ASP.NET MVC rendering HTML `select` elements.

`BetterSelectListItem : SelectListItem` defines an `HtmlAttributes` property.

If you use `@Html.BetterSelectListFor` or variants and pass in some `BetterSelectListItem`s those attributes are rendered in HTML for the `option`s of the list.

Example:

    @{
        var selectItems = Enumerable.Range(0, 10)
            .Select(x => new BetterSelectListItem(x.ToString(), x.ToString(), false, new {data_val=x}));
    }

    @Html.BetterDropDownList("test", selectItems)
