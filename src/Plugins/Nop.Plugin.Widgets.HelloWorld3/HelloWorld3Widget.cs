using Nop.Core.Domain.Cms;
using Nop.Services.Cms;
using Nop.Services.Configuration;
using Nop.Services.Plugins;

namespace Nop.Plugin.Widgets.HelloWorld3;

public class HelloWorld3Widget : BasePlugin, IWidgetPlugin
{
    #region Fields
    private readonly ISettingService _settingService;
    private readonly WidgetSettings _widgetSettings;


    #endregion

    #region Ctor
    public HelloWorld3Widget(ISettingService settingService, WidgetSettings widgetSettings)
    {
        _settingService = settingService;
        _widgetSettings = widgetSettings;
    }

    #endregion

    #region Methods
    public bool HideInWidgetList => throw new NotImplementedException();

    public Type GetWidgetViewComponent(string widgetZone)
    {
        return typeof();
    }

    public Task<IList<string>> GetWidgetZonesAsync()
    {
        throw new NotImplementedException();
    }
    public override async Task InstallAsync()
    {
        await base.InstallAsync();
    }
    public override async Task UninstallAsync()
    {
        await  base.UninstallAsync();
    }
    #endregion

    #region Properties
    public bool HidenInWidgetList => throw new NotImplementedException();
    #endregion
}
