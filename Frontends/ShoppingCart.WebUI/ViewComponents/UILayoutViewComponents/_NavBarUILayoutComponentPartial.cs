﻿using Microsoft.AspNetCore.Mvc;

namespace ShoppingCart.WebUI.ViewComponents.UILayoutViewComponents
{
    public class _NavBarUILayoutComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
