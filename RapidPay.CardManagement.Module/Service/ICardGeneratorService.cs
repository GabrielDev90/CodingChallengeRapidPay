namespace RapidPay.CardManagement.Module.Service
{
    public interface ICardGeneratorService
    {
        Task<long> GenreateCardNumber();
    }
}