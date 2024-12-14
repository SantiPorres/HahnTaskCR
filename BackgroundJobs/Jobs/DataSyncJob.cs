using Domain.Entities;
using Domain.Interfaces;
using Microsoft.Extensions.Hosting;

namespace BackgroundJobs.Jobs
{
    public class DataSyncJob : BackgroundService
    {
        private readonly IExternalApiService<Card> _cardApiService;
        private IUnitOfWork _unitOfWork;
        public DataSyncJob(IExternalApiService<Card> cardApiService, IUnitOfWork unitOfWork)
        {
            _cardApiService = cardApiService;
            _unitOfWork = unitOfWork;
        }

        protected override async Task ExecuteAsync(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                Console.WriteLine("Job execution");
                //var cards = await _cardApiService.GetDataAsync();
                //foreach (var card in cards)
                //{
                //    await _unitOfWork.CardRepository.Upsert(card);
                //}
            }
        }
    }
}
