using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Talabat.BLL.Interfaces;
using Talabat.DAL.Entities;

namespace Talabat.BLL.Repositories
{
    public class BasketRepository : IBasketRepository
    {
        private readonly IDatabase database;

        public BasketRepository(IConnectionMultiplexer connectionMultiplexer)
        {
            database = connectionMultiplexer.GetDatabase();
        }
        public async Task<CustomerBasket> GetCustomerBasket(string basketId)
        {
            var basket = await database.StringGetAsync(basketId);
            return basket.IsNullOrEmpty ? null : JsonSerializer.Deserialize<CustomerBasket>(basket);
        }

        public async Task<CustomerBasket> UpdateCustomerBasket(CustomerBasket basket)
        {
            var created = await database.StringSetAsync(basket.Id, JsonSerializer.Serialize(basket),TimeSpan.FromDays(30));
            if (!created) return null;
            else return await GetCustomerBasket(basket.Id);
        }

        public async Task<bool> DeleteCustomerBasket(string basketId)
        {
            return await database.KeyDeleteAsync(basketId);
        }


    }
}
