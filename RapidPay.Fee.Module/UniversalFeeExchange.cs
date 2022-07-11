namespace RapidPay.Fee.Module
{
    public class UniversalFeeExchange : IUniversalFeeExchange
    {
        public double Fee { get; set; } = 1;

        public void UpdateFee()
        {
            Random rand = new Random();

            double newFee = rand.NextInt64(3);
            
            if (newFee < 2)
            {
                newFee = Math.Round(newFee) + Math.Round(rand.NextDouble(), 2);
            }

            Fee = Math.Round(Fee,2) * newFee;
        }

        public double CurrentFee()
        {
            return Math.Round(Fee, 2);
        }

    }
}