using RapidPay.CardManagement.Module.Models;
using RapidPay.CardManagement.Module.Models.Dto;

namespace RapidPay.CardManagement.Module.Facade
{
    public interface IFacadeCard
    {
        Task<ResponseDto> CreateCard(Card card);
        Task<ResponseDto> GetBalance(long cardNumber);
        Task<ResponseDto> MakePayment(float paymentValue, long cardNumber);
    }
}