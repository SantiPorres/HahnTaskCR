using Domain.Entities;

namespace Domain.Interfaces;

public interface IUnitOfWork: IDisposable
{
    IBaseRepository<Card> Cards { get; set; }
}