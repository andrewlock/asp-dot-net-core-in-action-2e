using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Encodings.Web;

namespace CustomTagHelpers
{
    public class SystemInfoTagHelper : TagHelper
    {
        private readonly HtmlEncoder _htmlEncoder;
        public SystemInfoTagHelper(HtmlEncoder htmlEncoder)
        {
            _htmlEncoder = htmlEncoder;
        }

        /// <summary>
        /// Show the current <see cref="Environment.MachineName"/>. true by default
        /// </summary>
        [HtmlAttributeName("add-machine")]
        public bool IncludeMachine { get; set; } = true;

        /// <summary>
        /// Show the current OS
        /// </summary>
        [HtmlAttributeName("add-os")]
        public bool IncludeOS { get; set; } = true;

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";                       // Replaces <system-info> with <div>
            output.TagMode = TagMode.StartTagAndEndTag;  // <div> is not self closing


            var sb = new StringBuilder();
            if (IncludeMachine)
            {
                sb.Append(" <strong>Machine</strong> ");
                sb.Append(_htmlEncoder.Encode(Environment.MachineName));
            }
            if (IncludeOS)
            {
                sb.Append(" <strong>OS</strong> ");
                sb.Append(_htmlEncoder.Encode(RuntimeInformation.OSDescription));
            }
            output.Content.SetHtmlContent(sb.ToString());
        }
    }
}
