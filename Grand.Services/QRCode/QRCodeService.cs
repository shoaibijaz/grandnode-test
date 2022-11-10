using Grand.Domain.Orders;
using Grand.Services.Catalog;
using QRCoder;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Grand.Services.QRCode
{
    public class QRCodeService : IQRCodeService
    {
        private readonly IProductService _productService;

        public QRCodeService(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<string> GenerateOrder(IList<Order> orders)
        {
            var sb = new StringBuilder();

            foreach (var item in orders)
            {
                sb.AppendLine($"Order# - {item.OrderNumber}");

                foreach (var orderItem in item.OrderItems)
                {
                    var product = await _productService.GetProductByIdIncludeArch(orderItem.ProductId);

                    sb.AppendLine($"{product.Name} (x{orderItem.Quantity}) - {orderItem.PriceInclTax} {item.CustomerCurrencyCode}");
                }

                sb.AppendLine(" ----------------------------------- ");

                sb.AppendLine($"Order Total - {item.OrderTotal} {item.CustomerCurrencyCode} ");
            }

            

            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(sb.ToString(), QRCodeGenerator.ECCLevel.Q);

            Base64QRCode qrCode = new Base64QRCode(qrCodeData);
            return qrCode.GetGraphic(20);
        }
    }
}
