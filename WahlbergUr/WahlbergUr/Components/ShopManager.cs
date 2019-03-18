using Microsoft.AspNetCore.Mvc;
using WahlbergUr.Business.Handlers;
using WahlbergUr.Models;

namespace WahlbergUr.Components
{
    public class ShopManager : ViewComponent
    {
        private IShopHandler shopHandler;

        public ShopManager(IShopHandler shopHandler)
        {
            this.shopHandler = shopHandler;
        }

        public async System.Threading.Tasks.Task<IViewComponentResult> InvokeAsync()
        {
            var shop = new Shop();
            var shopInformation = await shopHandler.GetShopInformation(shop);
            ViewData["Information"] = shopInformation;
            return View("_ShopInformationPartial", shopInformation);
        }
    }
}
