﻿using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace AdvantageTool.TagHelpers
{
    /// <inheritdoc />
    /// <summary>
    /// Displays the Description from the <see cref="T:System.ComponentModel.DataAnnotations.DisplayAttribute" /> as a tooltip.
    /// </summary>
    [HtmlTargetElement("tooltip", Attributes = ForAttributeName)]
    public class TooltipTagHelper : TagHelper
    {
        private const string ForAttributeName = "asp-for";

        /// <inheritdoc />
        public override int Order => -1000;

        [HtmlAttributeNotBound]
        [ViewContext]
        public ViewContext ViewContext { get; set; }

        /// <summary>
        /// An expression to be evaluated against the current model.
        /// </summary>
        [HtmlAttributeName(ForAttributeName)]
        public ModelExpression For { get; set; }

        /// <inheritdoc />
        /// <remarks>Does nothing if <see cref="For"/> is <c>null</c>.</remarks>
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (output == null)
            {
                throw new ArgumentNullException(nameof(output));
            }

            output.TagName = "a";
            output.Attributes.SetAttribute("href", "#");
            output.Attributes.SetAttribute("data-toggle", "tooltip");
            output.Attributes.SetAttribute("title", For.Metadata.Description);
            output.Content.SetHtmlContent("<i class=\"fas fa-info-circle text-info\"></i>");
        }
    }
}
