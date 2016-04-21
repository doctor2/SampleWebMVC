﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace SportsStore.WebUI.HtmlHelpers
{
    public static class PageHelper
    {
        public static MvcHtmlString PageLinks(this HtmlHelper html, int currentPage, int totalPages, Func<int, string> pageUrl)
        {
            StringBuilder builder = new StringBuilder();

            //Prev
            TagBuilder prevBuilder;// = new TagBuilder("a");
            
            if (currentPage == 1)
            {
                prevBuilder = new TagBuilder("span");
                prevBuilder.InnerHtml = "&laquo;";
              //  prevBuilder.MergeAttribute("href", "");//#
                builder.AppendLine("<li class=\"disabled\">" + prevBuilder.ToString() + "</li>");
            }
            else
            {
                prevBuilder = new TagBuilder("a");
                prevBuilder.InnerHtml = "&laquo;";
                prevBuilder.MergeAttribute("href", pageUrl.Invoke(currentPage - 1));
                builder.AppendLine("<li>" + prevBuilder.ToString() + "</li>");
            }
            //По порядку
            for (int i = 1; i <= totalPages; i++)
            {
                //Условие что выводим только необходимые номера
                if (((i <= 3) || (i > (totalPages - 3))) || ((i > (currentPage - 2)) && (i < (currentPage + 2))))
                {
                    var subBuilder = new TagBuilder("a");
                    subBuilder.InnerHtml = i.ToString(CultureInfo.InvariantCulture);
                    if (i == currentPage)
                    {
                        subBuilder.MergeAttribute("href", "#");
                        builder.AppendLine("<li class=\"active\">" + subBuilder.ToString() + "</li>");
                    }
                    else
                    {
                        subBuilder.MergeAttribute("href", pageUrl.Invoke(i));
                        builder.AppendLine("<li>" + subBuilder.ToString() + "</li>");
                    }
                }
                else if ((i == 4) && (currentPage > 5))
                {
                    //Троеточие первое
                    builder.AppendLine("<li class=\"disabled\"> <a href=\"#\">...</a> </li>");
                }
                else if ((i == (totalPages - 3)) && (currentPage < (totalPages - 4)))
                {
                    //Троеточие второе
                    builder.AppendLine("<li class=\"disabled\"> <a href=\"#\">...</a> </li>");
                }
            }
            //Next
            TagBuilder nextBuilder;// = new TagBuilder("a");            
            if (currentPage == totalPages)
            {
                nextBuilder = new TagBuilder("span");
                nextBuilder.InnerHtml = "&raquo;";
                nextBuilder.MergeAttribute("href", "");//#
                builder.AppendLine("<li class=\"disabled\">" + nextBuilder.ToString() + "</li>");
            }
            else
            {
                nextBuilder = new TagBuilder("a");
                nextBuilder.InnerHtml = "&raquo;";
                nextBuilder.MergeAttribute("href", pageUrl.Invoke(currentPage + 1));
                builder.AppendLine("<li>" + nextBuilder.ToString() + "</li>");
            }
            return new MvcHtmlString("<ul class = \"pagination pagination-right\">" + builder.ToString() + "</ul>");
        }
    }
}