using RapidPay.CardManagement.Module.Models;
using RapidPay.CardManagement.Module.Models.Dto;
using RapidPay.CardManagement.Module.Repository;
using RapidPay.CardManagement.Module.Service;
using RapidPay.Fee.Module;

namespace RapidPay.CardManagement.Module.Facade
{
    public class FacadeCard : IFacadeCard
    {
        private readonly ICardRepository _cardRepository;
        private readonly IUniversalFeeExchange _universalFeeExchange;
        private readonly ICardGeneratorService _cardGeneratorService;
        ResponseDto _responseDto;

        public FacadeCard(ICardRepository cardRepository, IUniversalFeeExchange universalFeeExchange, ICardGeneratorService cardGeneratorService)
        {
            _cardRepository = cardRepository;
            _universalFeeExchange = universalFeeExchange;
            _responseDto = new ResponseDto();
            _cardGeneratorService = cardGeneratorService;
        }

        public async Task<ResponseDto> CreateCard(Card card)
        {
            while (card.Number == 0)
            {
                card.Number = await _cardGeneratorService.GenreateCardNumber();
            }

            await _cardRepository.CreateCard(card);

            return new ResponseDto { Result = card, StatusCode = 200, IsSuccess = true };
        }
        public async Task<ResponseDto> GetBalance(long cardNumber)
        {
            var result = await _cardRepository.GetBalance(cardNumber);

            if (result is not null)
            {
                return new ResponseDto() { Result = result, StatusCode = 200, IsSuccess = true };
            }

            return new ResponseDto() { Result = null, StatusCode = 200, IsSuccess = true, DisplayMessage = "Card does not exists." };
        }

        public async Task<ResponseDto> MakePayment(float paymentValue, long cardNumber)
        {
            var currentFee = _universalFeeExchange.CurrentFee();

            var result = await _cardRepository.GetBalance(cardNumber);

            if (result is not null)
            {
                if (result.Balance > paymentValue)
                {
                    result.Balance = Math.Round(result.Balance - paymentValue - currentFee, 2);

                    await _cardRepository.UpdateBalance(result);

                    _responseDto.Result = result;
                    _responseDto.StatusCode = 200;
                    _responseDto.IsSuccess = true;
                }
                else
                {
                    _responseDto.DisplayMessage = "You do not have balance to make this payment";
                }
            }
            else
            {
                _responseDto.DisplayMessage = "Card number does not exist";
            }

            return _responseDto;
        }

    }
}
