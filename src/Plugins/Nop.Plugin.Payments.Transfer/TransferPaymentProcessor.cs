using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DocumentFormat.OpenXml.Math;
using Microsoft.AspNetCore.Http;
using Nop.Core;
using Nop.Core.Domain.Orders;
using Nop.Core.Infrastructure;
using Nop.Plugin.Payments.Transfer.Components;
using Nop.Services.Configuration;
using Nop.Services.Payments;
using Nop.Services.Plugins;

namespace Nop.Plugin.Payments.Transfer;

public class TransferPaymentProcessor : BasePlugin, IPaymentMethod
{
    private readonly BankTransferPaymentSettings _bankTransferPaymentSettings;
    private readonly ISettingService _settingService;
    protected readonly IWebHelper _webHelper;

    public TransferPaymentProcessor(
        BankTransferPaymentSettings bankTransferPaymentSettings,
        ISettingService settingService, IWebHelper webHelper)
    {
        _bankTransferPaymentSettings = bankTransferPaymentSettings;
        _settingService = settingService;
        _webHelper = webHelper;
    }

    public Task<ProcessPaymentResult> ProcessPaymentAsync(ProcessPaymentRequest processPaymentRequest)
    {
        // Thanh toán chuyển khoản không xử lý real-time
        return Task.FromResult(new ProcessPaymentResult { NewPaymentStatus = Core.Domain.Payments.PaymentStatus.Pending });
    }

    public override async Task InstallAsync()
    {
        // giá trị mặc định
        var settings = new BankTransferPaymentSettings
        {
            BankName = "Vietcombank",
            AccountNumber = "123456789",
            AccountHolder = "Nguyen Van A",
            Instructions = "Vui lòng chuyển khoản và ghi rõ số đơn hàng."
        };
        await _settingService.SaveSettingAsync(settings);

        await base.InstallAsync();
    }

    public override async Task UninstallAsync()
    {
        await _settingService.DeleteSettingAsync<BankTransferPaymentSettings>();
        await base.UninstallAsync();
    }

    // Cấu hình trong Admin
   
    public override string GetConfigurationPageUrl()
    {
        return $"{_webHelper.GetStoreLocation()}Admin/PaymentTransfer/Configure";
    }
    // Hiển thị cho khách hàng ở checkout
    public Task<string> GetPaymentInfoViewComponentNameAsync()
        => Task.FromResult("PaymentInfo");

    public Task PostProcessPaymentAsync(PostProcessPaymentRequest postProcessPaymentRequest)
    {
        // Không cần redirect, chỉ chờ khách chuyển khoản
        return Task.CompletedTask;
    }


    public Task<bool> HidePaymentMethodAsync(IList<ShoppingCartItem> cart)
    {

        return Task.FromResult(false); // mặc định không ẩn
    }

    public Task<decimal> GetAdditionalHandlingFeeAsync(IList<ShoppingCartItem> cart)
    {
        // Không thu phí thêm
        return Task.FromResult(0m);
    }

    public Task<CapturePaymentResult> CaptureAsync(CapturePaymentRequest capturePaymentRequest)
    {
        return Task.FromResult(new CapturePaymentResult
        {
            Errors = new List<string> { "Capture not supported" }
        });
    }
    public Task<RefundPaymentResult> RefundAsync(RefundPaymentRequest refundPaymentRequest)
    {
        return Task.FromResult(new RefundPaymentResult
        {
            Errors = new List<string> { "Refund not supported" }
        });
    }

    public Task<VoidPaymentResult> VoidAsync(VoidPaymentRequest voidPaymentRequest)
    {
        return Task.FromResult(new VoidPaymentResult
        {
            Errors = new List<string> { "Void not supported" }
        });
    }

    public Task<ProcessPaymentResult> ProcessRecurringPaymentAsync(ProcessPaymentRequest processPaymentRequest)
    {
        return Task.FromResult(new ProcessPaymentResult
        {
            Errors = new List<string> { "Recurring payments not supported" }
        });
    }

    public Task<CancelRecurringPaymentResult> CancelRecurringPaymentAsync(CancelRecurringPaymentRequest cancelPaymentRequest)
    {
        return Task.FromResult(new CancelRecurringPaymentResult
        {
            Errors = new List<string> { "Recurring payments not supported" }
        });
    }

    public Task<bool> CanRePostProcessPaymentAsync(Order order)
    {
        return Task.FromResult(false);
    }

    public Task<IList<string>> ValidatePaymentFormAsync(IFormCollection form)
    {
        // Không cần validate gì đặc biệt
        return Task.FromResult<IList<string>>(new List<string>());
    }

    public Task<ProcessPaymentRequest> GetPaymentInfoAsync(IFormCollection form)
    {
        // Không thu thập thêm thông tin ngoài
        return Task.FromResult(new ProcessPaymentRequest());
    }

    public Type GetPublicViewComponent()
    {
        // View component để hiển thị hướng dẫn thanh toán cho khách
        return typeof(TransferPaymentViewComponent);
    }

    public Task<string> GetPaymentMethodDescriptionAsync()
    {
        return Task.FromResult("Thanh toán chuyển khoản qua ngân hàng");
    }

    #region Các thuộc tính yêu cầu bởi IPaymentMethod
    public bool SupportCapture => false;
    public bool SupportPartiallyRefund => false;
    public bool SupportRefund => false;
    public bool SupportVoid => false;
    public RecurringPaymentType RecurringPaymentType => RecurringPaymentType.NotSupported;
    public PaymentMethodType PaymentMethodType => PaymentMethodType.Standard;
    public bool SkipPaymentInfo => false;
    #endregion
}
