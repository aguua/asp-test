
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Threading.Tasks;

namespace WebApplicationxD.TagHelpers
{
    [HtmlTargetElement("my-email")]
    public class EmailTagHelper : TagHelper
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.Content.SetContent("aguua@gmail.com");
            output.TagName = "my-email";

        }
    }
}