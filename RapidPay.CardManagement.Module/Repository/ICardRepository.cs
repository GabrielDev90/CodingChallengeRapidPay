using RapidPay.CardManagement.Module.Models;

namespace RapidPay.CardManagement.Module.Repository
{
    public interface ICardRepository
    {
        Task<Card> CreateCard(Card card);
        Task<Card> GetBalance(long cardNumber);
        Task<int> UpdateBalance(Card card);
        Task<bool> GetCardByNumber(long cardNumber);
    }
}