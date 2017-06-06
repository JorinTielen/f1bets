using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Linq;
using System.Collections.Generic;
using Models;
using System.Text.Encodings.Web;

namespace f1bets.Helpers
{
    public static class MyHTMLHelpers
    {
        public static string ReactionDiv(this IHtmlHelper htmlHelper, IEnumerable<Reaction> reactions, int competition_id)
        {
            string html = String.Empty;

            if (reactions != null && reactions.Count() > 0)
            {
                foreach (var reaction in reactions)
                {
                    html += "<div class=\"panel panel-default\"> <div class=\"panel-body\">";
                    html += "<p class=\"label label-info\">" + reaction.User.Username + "</p> <p>" + reaction.Text + "</p>";
                    html += TypeReaction(htmlHelper, reaction, competition_id);
                    html += ReactionDiv(htmlHelper, reaction.Replies, competition_id);
                    html += "</div> </div>";
                }
            }
            return html;
        }

        public static string TypeReaction(this IHtmlHelper htmlHelper, Reaction reaction, int competition_id)
        {
            string html = String.Empty;

            html += "<form action=\"/Competition/AddReply\" method=\"post\">";
            html += GetString(htmlHelper.Hidden("Competition_id", (int)competition_id));
            html += GetString(htmlHelper.Hidden("Replyto_id", (int)reaction.ID));
            html += "<div class=\"input-group\" style=\"margin-bottom: 10px\"><span class=\"input-group-addon\" id=\"text-addon\">Type your reply:</span>";
            html += "<input class=\"form-control\" type=\"text\" name=\"Text\" aria-describedby=\"text-addon\" />";
            html += "<span class=\"input-group-btn pull-left\"><button type=\"submit\" class=\"btn btn-default\">Post Reaction</button></span>";  
            html += "</div>";
            html += "</form>";

            return html;
        }

        public static string GetString(IHtmlContent content)
        {
            var writer = new System.IO.StringWriter();
            content.WriteTo(writer, HtmlEncoder.Default);
            return writer.ToString();
        }
    }
}
