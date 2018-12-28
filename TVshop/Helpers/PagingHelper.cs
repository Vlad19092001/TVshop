using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using TVshop.Models;

namespace TVshop.Helpers
{
    public static class  PagingHelper
    {
        public static MvcHtmlString PageLinks(this HtmlHelper html, PagingInfo pagingInfo, Func<int, string> PageUrl)
        {
            StringBuilder result = new StringBuilder();

            for (int i = 1; i <= pagingInfo.TotalPages; i++)
            {
                TagBuilder tag = new TagBuilder("a");
                tag.MergeAttribute("href", PageUrl(i));
                tag.InnerHtml = i.ToString();
                tag.MergeAttribute("class", "nubex");
               
                result.Append(tag.ToString());
                result.Append(" ");
            }
            return MvcHtmlString.Create(result.ToString());
        }
    }
}