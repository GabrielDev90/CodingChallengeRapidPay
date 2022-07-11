namespace RapidPay.Fee.Module
{
    public interface IUniversalFeeExchange
    {
        double CurrentFee();

        void UpdateFee();
    }
}