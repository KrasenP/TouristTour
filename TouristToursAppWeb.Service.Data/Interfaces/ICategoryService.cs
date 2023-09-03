using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TouristToursAppWeb.Data.Models;
using TouristToursAppWeb.Web.ViewModel;

namespace TouristToursAppWeb.Service.Data.Interfaces
{
    public interface ICategoryService
    {
        Task<List<CategoryFromViewModel>> GetAllCategory();

        Task<List<string>> AllCategoryNameAsync();
     
    }
}
