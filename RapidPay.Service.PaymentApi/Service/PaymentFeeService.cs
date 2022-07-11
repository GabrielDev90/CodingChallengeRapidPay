using RapidPay.Fee.Module;

namespace RapidPay.Service.PaymentApi.Service
{
    public class PaymentFeeService : BackgroundService
    {
        private readonly IUniversalFeeExchange _universalFeeExchange;
        private readonly ILogger<PaymentFeeService> _logger;

        public PaymentFeeService(IUniversalFeeExchange universalFeeExchange, ILogger<PaymentFeeService> logger)
        {
            _universalFeeExchange = universalFeeExchange;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var timer = new PeriodicTimer(TimeSpan.FromSeconds(30));

            while (await timer.WaitForNextTickAsync(stoppingToken))
            {
                _logger.LogInformation("Fee is being updated!");
                _universalFeeExchange.UpdateFee();
                _logger.LogInformation(_universalFeeExchange.CurrentFee().ToString());
            }
        }
    }
}
