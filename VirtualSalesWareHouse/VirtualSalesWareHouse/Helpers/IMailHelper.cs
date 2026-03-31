using VirtualSalesWareHouse.Common;

namespace VirtualSalesWareHouse.Helpers;

public interface IMailHelper
{
    Response SendMail(string toName, string toEmail, string subject, string boyd);
}
