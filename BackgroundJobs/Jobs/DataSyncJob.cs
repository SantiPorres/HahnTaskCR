using System.Text.Json;
using Application.DTOs;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BackgroundJobs.Jobs;

public class DataSyncJob(IServiceProvider serviceProvider) : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken cancellationToken)
    {
        using (var scope = serviceProvider.CreateScope())
        {
            var unitOfWork = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();
            IExternalApiService<Card> cardService = scope.ServiceProvider.GetRequiredService<IExternalApiService<Card>>();
            string response = await cardService.GetDataAsync();
            var cards = JsonSerializer.Deserialize<CardsResponseDto>(response);
            foreach (var card in cards?.Items ?? [])
            {
                Card entity = new Card
                {
                    Id = card.Id,
                    Name = card.Name,
                    Rarity = card.Rarity,
                    MaxLevel = card.MaxLevel,
                    ElixirCost = card.ElixirCost,
                    MaxEvolutionLevel = card.MaxEvolutionLevel
                };
                await unitOfWork.Cards.Upsert(entity);
            }
        }
    }
}