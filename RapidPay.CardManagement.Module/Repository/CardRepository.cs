
using Microsoft.EntityFrameworkCore;
using RapidPay.CardManagement.Module.DbContexts;
using RapidPay.CardManagement.Module.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RapidPay.CardManagement.Module.Repository
{
    public class CardRepository : ICardRepository
    {
        private readonly ApplicationDbContext _db;

        public CardRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<Card> CreateCard(Card card)
        {
            _db.Cards.Add(card);
            await _db.SaveChangesAsync();
            return card;
        }

        public async Task<bool> GetCardByNumber(long cardNumber)
        {
            var result = await _db.Cards.FirstOrDefaultAsync(x => x.Number == cardNumber);

            if (result is not null) 
            {
                return true;
            }

            return false;
        }

        public async Task<Card> GetBalance(long cardNumber)
        {
            return await _db.Cards.AsNoTracking().FirstOrDefaultAsync(x => x.Number == cardNumber);
        }

        public async Task<Card> UpdateBalance(Card card)
        {
            _db.Cards.Update(card);
            await _db.SaveChangesAsync();
            return new Card();
        }
    }
}
