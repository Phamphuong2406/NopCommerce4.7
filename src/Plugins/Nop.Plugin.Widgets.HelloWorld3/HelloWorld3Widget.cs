using Nop.Core.Domain.Cms;
using Nop.Plugin.Widgets.HelloWorld3.Components;
using Nop.Services.Cms;
using Nop.Services.Configuration;
using Nop.Services.Plugins;
using Nop.Web.Framework.Infrastructure;

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
    //public bool HideInWidgetList => throw new NotImplementedException();

    public Type GetWidgetViewComponent(string widgetZone)
    {
        return typeof(HelloWorld3Component);
    }

    public Task<IList<string>> GetWidgetZonesAsync()
    {
        return Task.FromResult<IList<string>>(new List<string>
        {
            PublicWidgetZones.HomepageBeforeProducts
        });
    }
    public override async Task InstallAsync()
    {
        if (!_widgetSettings.ActiveWidgetSystemNames.Contains(HelloWorld3Default.HELLO_WORLD_VIEW_COMPONENT_NAME))
        {
            _widgetSettings.ActiveWidgetSystemNames.Add(HelloWorld3Default.HELLO_WORLD_VIEW_COMPONENT_NAME);
            await _settingService.SaveSettingAsync(_widgetSettings);
        }
        await base.InstallAsync();
    }
    public override async Task UninstallAsync()
    {
        if (!_widgetSettings.ActiveWidgetSystemNames.Contains(HelloWorld3Default.HELLO_WORLD_VIEW_COMPONENT_NAME))
        {
            _widgetSettings.ActiveWidgetSystemNames.Remove(HelloWorld3Default.HELLO_WORLD_VIEW_COMPONENT_NAME);
            await _settingService.SaveSettingAsync(_widgetSettings);
        }
        await  base.UninstallAsync();
    }
    #endregion

    #region Properties

    public bool HideInWidgetList => false;
    #endregion
}
