using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Nop.Web.Framework.Components;

namespace Nop.Plugin.Widgets.HelloWorld3.Components;
public  class HelloWorld3Component : NopViewComponent
{
    #region Methods
    public async Task<IViewComponentResult> InVokeAsync(string widgetZone, object additionalData)
    {


        return View("~/Plugins/Widgets.HelloWorld3/Views/PublicInfo.cshtml");
    }
    #endregion
}
