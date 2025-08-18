using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nop.Core.Configuration;

namespace Nop.Plugin.Payments.Transfer;
public class BankTransferPaymentSettings : ISettings
{
    public string BankName { get; set; }
    public string AccountNumber { get; set; }
    public string AccountHolder { get; set; }
    public string Instructions { get; set; }
}
