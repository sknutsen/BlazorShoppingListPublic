using BlazorShoppingList.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorShoppingList.Data
{
    public class AuthenticationService
    {
        public Task<Guid> AuthenticateAsync(string username, string pw)
        {
            using var db = new ShoppingdbContext();
            bool valid = db.user_.Any<user_>(u => u.uname == username && u.passw == pw);
            if (valid) {
                int uid = db.user_.Where(u => u.uname == username).First().uid;

                return Task.FromResult(db.auth_token.Where(t => t.user == uid).First().token);
            }

            return null;
        }

        public Task<bool> ValidateAsync(Guid token)
        {
            using var db = new ShoppingdbContext();
            return Task.FromResult(db.auth_token.Any(t => t.token == token));
        }
    }
}
