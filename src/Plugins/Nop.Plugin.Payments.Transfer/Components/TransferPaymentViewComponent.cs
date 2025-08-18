using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Nop.Services.Configuration;

namespace Nop.Plugin.Payments.Transfer.Components;
public class TransferPaymentViewComponent : ViewComponent
{
    private readonly BankTransferPaymentSettings _settings;

    public TransferPaymentViewComponent(ISettingService settingService)
    {
        _settings = settingService.LoadSettingAsync<BankTransferPaymentSettings>().Result;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        // Truyền settings ra view
        return View("~/Plugins/Payments.Transfer/Views/PaymentInfo.cshtml", _settings);
    }
}
