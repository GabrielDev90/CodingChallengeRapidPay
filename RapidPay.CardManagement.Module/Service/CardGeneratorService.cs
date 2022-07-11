using RapidPay.CardManagement.Module.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RapidPay.CardManagement.Module.Service
{
    public class CardGeneratorService : ICardGeneratorService
    {
        private readonly ICardRepository _cardRepository;

        public CardGeneratorService(ICardRepository cardRepository)
        {
            _cardRepository = cardRepository;
        }

        public async Task<long> GenreateCardNumber()
        {
            Random x = new Random();
            var number1 = x.Next(10000, 99999);
            var number2 = x.Next(10000, 99999);
            var number3 = x.Next(10000, 99999);

            var cardNumber = long.Parse(number1.ToString() + number2.ToString() + number3.ToString());

            var result = await _cardRepository.GetCardByNumber(cardNumber);

            if (result)
            {
                return 0;
            }

            return long.Parse(number1.ToString() + number2.ToString() + number3.ToString());
        }
    }
}
