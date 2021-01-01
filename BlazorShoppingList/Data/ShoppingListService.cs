using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorShoppingList.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlazorShoppingList.Data
{
    public class ShoppingListService
    {
        private AuthenticationService AuthenticationService = new AuthenticationService();

        public Task<List<shopping_list>> GetShoppingListsAsync(Guid token)
        {
            using var db = new ShoppingdbContext();
            if (AuthenticationService.ValidateAsync(token).Result)
            {
                return Task.FromResult(db.shopping_list.ToList());
            }

            return null;
        }

        public Task<shopping_list> AddAsync(Guid token, shopping_list sl)
        {
            using var db = new ShoppingdbContext();
            if (AuthenticationService.ValidateAsync(token).Result)
            {
                var newSl = new shopping_list { 
                    gid = sl.gid,
                    slname = sl.slname
                };
                var result = db.shopping_list.Add(newSl).Entity;
                db.SaveChanges();

                var soldOut = db.item.Where(i => i.sold_out).ToList();
                foreach (var i in soldOut)
                {
                    db.item.Remove(i);
                    db.SaveChanges();
                    i.sold_out = false;
                    i.slid = result.slid;
                    db.item.Add(i);
                }

                db.SaveChanges();

                return Task.FromResult(result);
            }

            return null;
        }

        public Task<shopping_list> DeleteAsync(Guid token, shopping_list sl)
        {
            using var db = new ShoppingdbContext();
            if (AuthenticationService.ValidateAsync(token).Result)
            {
                if (db.item.Any(i => i.slid == sl.slid))
                {
                    foreach (var i in db.item.Where(i => i.slid == sl.slid).ToList())
                    {
                        db.item.Remove(i);
                    }
                }

                var result = db.shopping_list.Remove(sl).Entity;
                db.SaveChanges();

                return Task.FromResult(result);
            }

            return null;
        }
    }
}
