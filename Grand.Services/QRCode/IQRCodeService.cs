using Grand.Domain.Orders;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Grand.Services.QRCode
{
    public interface IQRCodeService
    {
        public Task<string> GenerateOrder(IList<Order> orders);
    }
}
