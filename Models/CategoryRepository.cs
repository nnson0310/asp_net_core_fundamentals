﻿using Microsoft.EntityFrameworkCore;

namespace BethanysPieShop.Models
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly BethanysPieShopDbContext _bethanysPieShopDbContext;

        public CategoryRepository(BethanysPieShopDbContext context)
        {
            _bethanysPieShopDbContext = context;
        }

        public IEnumerable<Category> AllCategories => _bethanysPieShopDbContext.Categories.Include(c => c.Pies).ToList();
    }
}
