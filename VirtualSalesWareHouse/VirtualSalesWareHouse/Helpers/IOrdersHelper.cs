using VirtualSalesWareHouse.Common;
using VirtualSalesWareHouse.Models;

namespace VirtualSalesWareHouse.Helpers;

public interface IOrdersHelper
{
    Task<Response> ProcessOrderAsync(ShowCartViewModel model);
}

