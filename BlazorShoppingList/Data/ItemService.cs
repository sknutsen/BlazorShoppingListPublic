using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorShoppingList.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlazorShoppingList.Data
{
    public class ItemService
    {
        private AuthenticationService AuthenticationService = new AuthenticationService();

        public Task<List<item>> GetItemsAsync(Guid token, int slid)
        {
            using var db = new ShoppingdbContext();
            if (AuthenticationService.ValidateAsync(token).Result)
            {
                return Task.FromResult(db.item.Where(i => i.slid == slid).ToList());
            }

            return null;
        }

        public Task<item> AddAsync(Guid token, item item)
        {
            using var db = new ShoppingdbContext();
            if (AuthenticationService.ValidateAsync(token).Result)
            {
                var newItem = new item
                {
                    slid = item.slid,
                    iname = item.iname,
                    ammount = item.ammount,
                    added_by = item.added_by,
                    sold_out = item.sold_out
                };
                var result = db.item.Add(newItem).Entity;
                db.SaveChanges();

                return Task.FromResult(result);
            }

            return null;
        }

        public Task<item> UpdateAsync(Guid token, item item)
        {
            using var db = new ShoppingdbContext();
            if (AuthenticationService.ValidateAsync(token).Result)
            {
                db.Entry(item).State = EntityState.Modified;
                db.SaveChanges();

                return Task.FromResult(item);
            }

            return null;
        }

        public Task<item> DeleteAsync(Guid token, item item)
        {
            using var db = new ShoppingdbContext();
            if (AuthenticationService.ValidateAsync(token).Result)
            {
                var result = db.item.Remove(item).Entity;
                db.SaveChanges();

                return Task.FromResult(result);
            }

            return null;
        }
    }
}
