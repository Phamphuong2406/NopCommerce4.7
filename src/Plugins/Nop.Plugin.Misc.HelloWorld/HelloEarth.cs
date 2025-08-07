using Nop.Services.Common;
using Nop.Services.Plugins;

namespace Nop.Plugin.Misc.HelloWorld;

public class HelloEarth: BasePlugin, IMiscPlugin
{
    #region Fields
    #endregion

    #region Ctor
    #endregion

    #region Methods
    public override async Task InstallAsync()
    {
        await base.InstallAsync();
    }

    public override async Task UninstallAsync()
    {
        await base.UninstallAsync();
    }
    #endregion
}
