using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class CardService : ICardService
    {
        protected IUnitOfWork _unitOfWork;
        public CardService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Card>> GetAll(List<Dictionary<string, string>>? filters = null)
        {
            return await _unitOfWork.Cards.List();
        }
    }
}
