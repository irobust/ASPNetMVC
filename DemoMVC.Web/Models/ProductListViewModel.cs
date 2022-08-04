﻿using DemoMVC.Web.Interfaces;

namespace DemoMVC.Web.Models
{
    public class ProductListViewModel : IViewModel
    {
        public IEnumerable<DemoMVC.Domain.Entities.Product> Products { get; set; }
        
        public PagingInfo PagingInfo { get; set; }

        
        public string CurrentCategory { get; set; }
    }
}
