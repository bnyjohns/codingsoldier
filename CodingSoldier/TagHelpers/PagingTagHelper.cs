using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodingSoldier.TagHelpers
{
    public class PagingTagHelper : TagHelper
    {
        private const int PagingDeviation = 2;
        public int CurrentIndex { get; set; }
        public int TotalPageCount { get; set; }
        public string PagingURL { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            output.Attributes.Add("id", "Paging");
            output.Attributes.Add("style", "text-align:center");

            if (TotalPageCount == 0)
                return;

            var spanTag = new TagBuilder("span");
            var spanContent = $"Page {CurrentIndex} of {TotalPageCount}";
            spanTag.InnerHtml.AppendHtml(spanContent);

            var paginationContainer = new TagBuilder("div");
            paginationContainer.Attributes.Add("class", "pagination-container");

            var ulPagination     = new TagBuilder("ul");
            ulPagination.Attributes.Add("class", "pagination");

            var diff = CurrentIndex - PagingDeviation;
            var startIndex = CurrentIndex > 0 ? (diff < 1 ? 1 : diff) : 1;
            var ulHtml = "";
            if (CurrentIndex > 1)
            {
                ulHtml += "<li><a href='" + PagingURL + "?page=" + (CurrentIndex - 1) + "'>" + "«" + "</a></li>";
            }

            for (var i = startIndex; i <= TotalPageCount; i++)
            {
                var li = "<li><a href='" + PagingURL + "?page=" + i + "'>" + i + "</a></li>";
                if (i == CurrentIndex)
                {
                    li = "<li class='active'><a href='" + PagingURL + "?page=" + i + "'>" + i + "</a></li>";
                }
                ulHtml += li;
                if (i - CurrentIndex >= PagingDeviation)
                    break;
            }
            if (CurrentIndex < TotalPageCount)
            {
                ulHtml += "<li><a href='" + PagingURL + "?page=" + (CurrentIndex + 1) + "'>" + "»" + "</a></li>";
            }

            output.Content.AppendHtml(spanTag);
            ulPagination.InnerHtml.AppendHtml(ulHtml);
            paginationContainer.InnerHtml.AppendHtml(ulPagination);
            output.Content.AppendHtml(paginationContainer);
        }
    }
}
