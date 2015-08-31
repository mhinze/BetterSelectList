BetterSelectList
================

Addressing a small limitation with ASP.NET MVC rendering HTML `select` elements.

`BetterSelectListItem : SelectListItem` defines an `HtmlAttributes` property.

If you use `@Html.BetterSelectListFor` or variants and pass in some `BetterSelectListItem`s those attributes are rendered in HTML for the `option`s of the list.

Example:
```
@{
    var items = new[]
   {
        new
        {
            Text = "One",
            Value = "1",
            Group = "Odd",
            Selected = false
        },
        new
        {
            Text = "Two",
            Value = "2",
            Group = "Even",
            Selected = true
        },
        new
        {
            Text = "Three",
            Value = "3",
            Group = "Odd",
            Selected = false
        },
        new
        {
            Text = "Four",
            Value = "4",
            Group = "Even",
            Selected = false
        },
        new
        {
            Text = "Five",
            Value = "5",
            Group = "Odd",
            Selected = false
        },
        new
        {
            Text = "Six",
            Value = "6",
            Group = "Even",
            Selected = false
        }
    };
    var withGroups = items.Select(item => new BetterSelectListItem(item.Value, item.Text, item.Selected, new { data_val = item.Value }, item.Group));
}
@Html.BetterDropDownList("demo-optgroup", withGroups)
```

emits

```
<select id="demo-optgroup" name="demo-optgroup">
<optgroup label="Odd">
	<option data-val="1" value="1">One</option>
	<option data-val="3" value="3">Three</option>
	<option data-val="5" value="5">Five</option>
</optgroup>
<optgroup label="Even">
	<option data-val="2" selected="selected" value="2">Two</option>
	<option data-val="4" value="4">Four</option>
	<option data-val="6" value="6">Six</option>
</optgroup>
</select>
```