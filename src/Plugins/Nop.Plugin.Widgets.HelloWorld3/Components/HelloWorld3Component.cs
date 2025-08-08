using Microsoft.AspNetCore.Mvc;
using Nop.Web.Framework.Components;

namespace Nop.Plugin.Widgets.HelloWorld3.Components;
public class HelloWorld3Component : NopViewComponent
{
    #region Methods

    public async Task<IViewComponentResult> InvokeAsync(string widgetZone, object additionalData)
    {
        // Ví dụ: kiểm tra widgetZone để quyết định view nào được trả về
        // if (widgetZone.Equals(PublicWidgetZones.LeftSideColumnBlogBefore))
        //     return View("XYZ");

        return await Task.FromResult(View("~/Plugins/Widgets.HelloWorld3/Views/PublicInfo.cshtml"));
    }

    #endregion
}

