using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Web.Mvc.Html.System.Web.Mvc;
using BetterSelectList;

/* Copyright (c) Microsoft Open Technologies, Inc.  All rights reserved.
Microsoft Open Technologies would like to thank its contributors, a list
of whom are at http://aspnetwebstack.codeplex.com/wikipage?title=Contributors.

Licensed under the Apache License, Version 2.0 (the "License"); you
may not use this file except in compliance with the License. You may
obtain a copy of the License at

http://www.apache.org/licenses/LICENSE-2.0

Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or
implied. See the License for the specific language governing permissions
and limitations under the License.*/

// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.txt in the project root for license information.

/* Modified by Matt Hinze to enhance select list item rendering to support html attributes */
/* warning: errors are not localized like they are in the mvc code base, left the orig resource refs in */

// ReSharper disable IntroduceOptionalParameters.Global
// ReSharper disable RedundantEmptyObjectCreationArgumentList
// ReSharper disable RedundantCast
// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable SuggestUseVarKeywordEvident
// ReSharper disable RedundantArgumentName
// ReSharper disable CheckNamespace
namespace System.Web.Mvc.Html
// ReSharper restore CheckNamespace
{
	public static class SelectExtensions {
		// DropDownList

		public static MvcHtmlString BetterDropDownList(this HtmlHelper htmlHelper, string name) {
			return BetterDropDownList(htmlHelper, name, null /* selectList */, null /* optionLabel */, null /* htmlAttributes */);
		}

		public static MvcHtmlString BetterDropDownList(this HtmlHelper htmlHelper, string name, string optionLabel) {
			return BetterDropDownList(htmlHelper, name, null /* selectList */, optionLabel, null /* htmlAttributes */);
		}

		public static MvcHtmlString BetterDropDownList(this HtmlHelper htmlHelper, string name, IEnumerable<BetterSelectListItem> selectList) {
			return BetterDropDownList(htmlHelper, name, selectList, null /* optionLabel */, null /* htmlAttributes */);
		}

		public static MvcHtmlString BetterDropDownList(this HtmlHelper htmlHelper, string name, IEnumerable<BetterSelectListItem> selectList, object htmlAttributes) {
			return BetterDropDownList(htmlHelper, name, selectList, null /* optionLabel */, HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
		}

		public static MvcHtmlString BetterDropDownList(this HtmlHelper htmlHelper, string name, IEnumerable<BetterSelectListItem> selectList, IDictionary<string, object> htmlAttributes) {
			return BetterDropDownList(htmlHelper, name, selectList, null /* optionLabel */, htmlAttributes);
		}

		public static MvcHtmlString BetterDropDownList(this HtmlHelper htmlHelper, string name, IEnumerable<BetterSelectListItem> selectList, string optionLabel) {
			return BetterDropDownList(htmlHelper, name, selectList, optionLabel, null /* htmlAttributes */);
		}

		public static MvcHtmlString BetterDropDownList(this HtmlHelper htmlHelper, string name, IEnumerable<BetterSelectListItem> selectList, string optionLabel, object htmlAttributes) {
			return BetterDropDownList(htmlHelper, name, selectList, optionLabel, HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
		}

		public static MvcHtmlString BetterDropDownList(this HtmlHelper htmlHelper, string name, IEnumerable<BetterSelectListItem> selectList, string optionLabel, IDictionary<string, object> htmlAttributes) {
			return DropDownListHelper(htmlHelper, metadata: null, expression: name, selectList: selectList, optionLabel: optionLabel, htmlAttributes: htmlAttributes);
		}

		public static MvcHtmlString BetterDropDownListFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IEnumerable<BetterSelectListItem> selectList) {
			return BetterDropDownListFor(htmlHelper, expression, selectList, null /* optionLabel */, null /* htmlAttributes */);
		}

		public static MvcHtmlString BetterDropDownListFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IEnumerable<BetterSelectListItem> selectList, object htmlAttributes) {
			return BetterDropDownListFor(htmlHelper, expression, selectList, null /* optionLabel */, HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
		}

		public static MvcHtmlString BetterDropDownListFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IEnumerable<BetterSelectListItem> selectList, IDictionary<string, object> htmlAttributes) {
			return BetterDropDownListFor(htmlHelper, expression, selectList, null /* optionLabel */, htmlAttributes);
		}

		public static MvcHtmlString BetterDropDownListFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IEnumerable<BetterSelectListItem> selectList, string optionLabel) {
			return BetterDropDownListFor(htmlHelper, expression, selectList, optionLabel, null /* htmlAttributes */);
		}

		public static MvcHtmlString BetterDropDownListFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IEnumerable<BetterSelectListItem> selectList, string optionLabel, object htmlAttributes) {
			return BetterDropDownListFor(htmlHelper, expression, selectList, optionLabel, HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
		}

		public static MvcHtmlString BetterDropDownListFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IEnumerable<BetterSelectListItem> selectList, string optionLabel, IDictionary<string, object> htmlAttributes) {
			if (expression == null) {
				throw new ArgumentNullException("expression");
			}

			ModelMetadata metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);

			return DropDownListHelper(htmlHelper, metadata, ExpressionHelper.GetExpressionText(expression), selectList, optionLabel, htmlAttributes);
		}

		private static MvcHtmlString DropDownListHelper(HtmlHelper htmlHelper, ModelMetadata metadata, string expression, IEnumerable<BetterSelectListItem> selectList, string optionLabel, IDictionary<string, object> htmlAttributes) {
			return SelectInternal(htmlHelper, metadata, optionLabel, expression, selectList, allowMultiple: false, htmlAttributes: htmlAttributes);
		}

		// ListBox

		public static MvcHtmlString BetterListBox(this HtmlHelper htmlHelper, string name) {
			return BetterListBox(htmlHelper, name, null /* selectList */, null /* htmlAttributes */);
		}

		public static MvcHtmlString BetterListBox(this HtmlHelper htmlHelper, string name, IEnumerable<BetterSelectListItem> selectList) {
			return BetterListBox(htmlHelper, name, selectList, (IDictionary<string, object>)null);
		}

		public static MvcHtmlString BetterListBox(this HtmlHelper htmlHelper, string name, IEnumerable<BetterSelectListItem> selectList, object htmlAttributes) {
			return BetterListBox(htmlHelper, name, selectList, HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
		}

		public static MvcHtmlString BetterListBox(this HtmlHelper htmlHelper, string name, IEnumerable<BetterSelectListItem> selectList, IDictionary<string, object> htmlAttributes) {
			return ListBoxHelper(htmlHelper, metadata: null, name: name, selectList: selectList, htmlAttributes: htmlAttributes);
		}

		public static MvcHtmlString BetterListBoxFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IEnumerable<BetterSelectListItem> selectList) {
			return BetterListBoxFor(htmlHelper, expression, selectList, null /* htmlAttributes */);
		}

		public static MvcHtmlString BetterListBoxFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IEnumerable<BetterSelectListItem> selectList, object htmlAttributes) {
			return BetterListBoxFor(htmlHelper, expression, selectList, HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
		}

		public static MvcHtmlString BetterListBoxFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IEnumerable<BetterSelectListItem> selectList, IDictionary<string, object> htmlAttributes) {
			if (expression == null) {
				throw new ArgumentNullException("expression");
			}

			ModelMetadata metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);

			return ListBoxHelper(htmlHelper,
									metadata,
									ExpressionHelper.GetExpressionText(expression),
									selectList,
									htmlAttributes);
		}

		private static MvcHtmlString ListBoxHelper(HtmlHelper htmlHelper, ModelMetadata metadata, string name, IEnumerable<BetterSelectListItem> selectList, IDictionary<string, object> htmlAttributes) {
			return SelectInternal(htmlHelper, metadata, optionLabel: null, name: name, selectList: selectList, allowMultiple: true, htmlAttributes: htmlAttributes);
		}

		// Helper methods

		private static IEnumerable<BetterSelectListItem> GetSelectData(this HtmlHelper htmlHelper, string name) {
			object o = null;
			if (htmlHelper.ViewData != null) {
				o = htmlHelper.ViewData.Eval(name);
			}
			if (o == null) {
				throw new InvalidOperationException(
					String.Format(
						CultureInfo.CurrentCulture,
						"There is no ViewData item of type '{1}' that has the key '{0}'.",//MvcResources.HtmlHelper_MissingSelectData,
						name,
						"IEnumerable<BetterSelectListItem>"));
			}
			IEnumerable<BetterSelectListItem> selectList = o as IEnumerable<BetterSelectListItem>;
			if (selectList == null) {
				throw new InvalidOperationException(
					String.Format(
						CultureInfo.CurrentCulture,
						"The ViewData item that has the key '{0}' is of type '{1}' but must be of type '{2}'.", //MvcResources.HtmlHelper_WrongSelectDataType,
						name,
						o.GetType().FullName,
						"IEnumerable<BetterSelectListItem>"));
			}
			return selectList;
		}

		internal static string ListItemToOption(BetterSelectListItem item) {
			TagBuilder builder = new TagBuilder("option") {
				InnerHtml = HttpUtility.HtmlEncode(item.Text)
			};
			if (item.Value != null) {
				builder.Attributes ["value"] = item.Value;
			}
			if (item.Selected) {
				builder.Attributes ["selected"] = "selected";
			}

			builder.MergeAttributes(item.HtmlAttributes);

			return builder.ToString(TagRenderMode.Normal);
		}

		private static IEnumerable<BetterSelectListItem> GetSelectListWithDefaultValue(IEnumerable<BetterSelectListItem> selectList, object defaultValue, bool allowMultiple) {
			IEnumerable defaultValues;

			if (allowMultiple) {
				defaultValues = defaultValue as IEnumerable;
				if (defaultValues == null || defaultValues is string) {
					throw new InvalidOperationException(
						String.Format(
							CultureInfo.CurrentCulture,
							"The parameter '{0}' must evaluate to an IEnumerable when multiple selection is allowed.",//MvcResources.HtmlHelper_SelectExpressionNotEnumerable,
							"expression"));
				}
			} else {
				defaultValues = new [] { defaultValue };
			}

			IEnumerable<string> values = from object value in defaultValues
										 select Convert.ToString(value, CultureInfo.CurrentCulture);
			HashSet<string> selectedValues = new HashSet<string>(values, StringComparer.OrdinalIgnoreCase);
			List<BetterSelectListItem> newSelectList = new List<BetterSelectListItem>();

			foreach (BetterSelectListItem item in selectList) {
				item.Selected = (item.Value != null) ? selectedValues.Contains(item.Value) : selectedValues.Contains(item.Text);
				newSelectList.Add(item);
			}
			return newSelectList;
		}

		private static MvcHtmlString SelectInternal(this HtmlHelper htmlHelper, ModelMetadata metadata, string optionLabel, string name, IEnumerable<BetterSelectListItem> selectList, bool allowMultiple, IDictionary<string, object> htmlAttributes) {
			string fullName = htmlHelper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(name);
			if (String.IsNullOrEmpty(fullName)) {
				throw new ArgumentException(
					"Value cannot be null or empty.", //MvcResources.Common_NullOrEmpty, 
					"name");
			}

			bool usedViewData = false;

			// If we got a null selectList, try to use ViewData to get the list of items.
			if (selectList == null) {
				selectList = htmlHelper.GetSelectData(name);
				usedViewData = true;
			}

			object defaultValue = (allowMultiple) ? htmlHelper.GetModelStateValue(fullName, typeof(string [])) : htmlHelper.GetModelStateValue(fullName, typeof(string));

			// If we haven't already used ViewData to get the entire list of items then we need to
			// use the ViewData-supplied value before using the parameter-supplied value.
			if (!usedViewData && defaultValue == null && !String.IsNullOrEmpty(name)) {
				defaultValue = htmlHelper.ViewData.Eval(name);
			}

			if (defaultValue != null) {
				selectList = GetSelectListWithDefaultValue(selectList, defaultValue, allowMultiple);
			}

			// Convert each ListItem to an <option> tag
			StringBuilder listItemBuilder = new StringBuilder();

			// Make optionLabel the first item that gets rendered.
			if (optionLabel != null) {
				listItemBuilder.AppendLine(ListItemToOption(new BetterSelectListItem() { Text = optionLabel, Value = String.Empty, Selected = false }));
			}



			// Group the list and create optgroups
			var groupedList = selectList.GroupBy(i => i.Group);

			// Iterate through groups
			foreach (var group in groupedList) {

				// Skip the optgroup generation when the group key is null (i.e. no group)
				if (group.Key == null) {

					foreach (BetterSelectListItem item in group)
						listItemBuilder.AppendLine(ListItemToOption(item));

					continue;

				}

				// Create an optgroup element with label
				var optgroup = new TagBuilder("optgroup");
				optgroup.MergeAttribute("label", group.Key);

				// Append the items to the optgroup first
				var children = new StringBuilder();

				foreach (BetterSelectListItem item in group)
					children.AppendLine(ListItemToOption(item));

				optgroup.InnerHtml = children.ToString();

				// Now append the whole optgroup to the list
				listItemBuilder.AppendLine(optgroup.ToString());

			}

			TagBuilder tagBuilder = new TagBuilder("select") {
				InnerHtml = listItemBuilder.ToString()
			};
			tagBuilder.MergeAttributes(htmlAttributes);
			tagBuilder.MergeAttribute("name", fullName, true /* replaceExisting */);
			tagBuilder.GenerateId(fullName);
			if (allowMultiple) {
				tagBuilder.MergeAttribute("multiple", "multiple");
			}

			// If there are any errors for a named field, we add the css attribute.
			ModelState modelState;
			if (htmlHelper.ViewData.ModelState.TryGetValue(fullName, out modelState)) {
				if (modelState.Errors.Count > 0) {
					tagBuilder.AddCssClass(HtmlHelper.ValidationInputCssClassName);
				}
			}

			tagBuilder.MergeAttributes(htmlHelper.GetUnobtrusiveValidationAttributes(name, metadata));

			return tagBuilder.ToMvcHtmlString(TagRenderMode.Normal);
		}

	}

	namespace System.Web.Mvc {
		// direct copy pasta from System.Web.Mvc.TagBuilderExtensions -MH
		static class TagBuilderExtensions {
			internal static MvcHtmlString ToMvcHtmlString(this TagBuilder tagBuilder, TagRenderMode renderMode) {
				Debug.Assert(tagBuilder != null);
				return new MvcHtmlString(tagBuilder.ToString(renderMode));
			}
		}


		// an internal method on HtmlHelper converted to extension method -MH
		static class HtmlHelperExtensions {
			internal static object GetModelStateValue(this HtmlHelper self, string key, Type destinationType) {
				ModelState modelState;
				if (self.ViewData.ModelState.TryGetValue(key, out modelState)) {
					if (modelState.Value != null) {
						return modelState.Value.ConvertTo(destinationType, null /* culture */);
					}
				}
				return null;
			}
		}

	}
}
// ReSharper restore IntroduceOptionalParameters.Global
// ReSharper restore RedundantCast
// ReSharper restore RedundantEmptyObjectCreationArgumentList
// ReSharper restore MemberCanBePrivate.Global
// ReSharper restore SuggestUseVarKeywordEvident
// ReSharper restore RedundantArgumentName