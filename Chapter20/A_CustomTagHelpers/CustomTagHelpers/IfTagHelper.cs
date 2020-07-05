using Microsoft.AspNetCore.Razor.TagHelpers;

namespace CustomTagHelpers
{
    [HtmlTargetElement(Attributes = "if")]
    public class IfTagHelper : TagHelper
    {
        public override int Order => int.MinValue;

        [HtmlAttributeName("if")]
        public bool RenderContent { get; set; } = true;

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (RenderContent == false)
            {
                output.TagName = null;
                output.SuppressOutput();
            }
            output.Attributes.RemoveAll("if");
        }
    }
}
