using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusteriTakip.UI.PagedList
{
    [HtmlTargetElement("pagination")]
    public class PagedListPager : TagHelper
    {
        [HtmlAttributeName("pagination-model")]
        public PagedItemModel PagedModel { get; set; }

        [HtmlAttributeName("link-url")]
        public string LinkUrl { get; set; }

        [HtmlAttributeName("link-query")]
        public string LinkQuery { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {

            output.TagName = "div";
            var sb = new StringBuilder();
            string isActive = "";
            string pagequery = "";
            sb.Append(@$"<nav aria-label=""Page navigation example""><ul class=""pagination ajax-pagination"" data-url=""{LinkUrl}"">");
            for (int i = 1; i <= PagedModel.PageCount; i++)
            {
                if (i == PagedModel.CurrentPage)
                { isActive = "active"; }

                if (!string.IsNullOrEmpty(LinkQuery))
                {
                    pagequery = "&" + LinkQuery;
                }

                sb.Append(@$"<li class=""page-item {isActive}""><a class=""page-link"" data-page=""?page={i}"" data-query=""{pagequery}"">{i}</a></li>");
                isActive = "";
            }
            sb.Append("</ul></nav>");

            output.Content.SetHtmlContent(sb.ToString());
        }

    }
}
