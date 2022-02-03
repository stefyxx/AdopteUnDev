using AdopteUnDev_Common.IRepositories;
using BLL_AdopteUnDev01.Handlers;
using BLL_AdopteUnDev01.Models;
using System.Collections.Generic;
using System.Linq;

namespace BLL_AdopteUnDev01.Repository
{
    public class ClientService : IDeveloperRepository<BLL_AdopteUnDev01.Models.Client>
    {
        private readonly IDeveloperRepository<DAL_AdopteUnDev.DTO.Client> _repository;
        public ClientService(IDeveloperRepository<DAL_AdopteUnDev.DTO.Client> repository)
        {
            _repository = repository;
        }
        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public Client Get(int id)
        {
            return _repository.Get(id).ToBLL();
        }

        public IEnumerable<Client> Get()
        {
            return _repository.Get().Select(d => d.ToBLL());
        }

        public int Insert(Client entity)
        {
            return _repository.Insert(entity.ToDAL());
        }

        public void Update(int id, Client entity)
        {
            _repository.Update(id, entity.ToDAL());
        }
    }
}
