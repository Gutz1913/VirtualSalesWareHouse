using Microsoft.AspNetCore.Mvc.Rendering;
using VirtualSalesWareHouse.Data.Entities;

namespace VirtualSalesWareHouse.Helpers;

public interface ICombosHelper
{
    Task<IEnumerable<SelectListItem>> GetComboCategoriesAsync();
    Task<IEnumerable<SelectListItem>> GetComboCategoriesAsync(IEnumerable<Category> filter);
    Task<IEnumerable<SelectListItem>> GetComboCountriesAsync();
     Task<IEnumerable<SelectListItem>> GetComboStatesAsync(int countryId);
     Task<IEnumerable<SelectListItem>> GetComboCitiesAsync(int stateId);
}
