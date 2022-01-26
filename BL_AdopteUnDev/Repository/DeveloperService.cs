using AdopteUnDev_Common.IRepositories;
using BLL_AdopteUnDev.Handlers;
using BLL_AdopteUnDev.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Repository
{
    public class DeveloperService : IDeveloperRepository<BLL_AdopteUnDev.Models.Developer>
    {
        private readonly IDeveloperRepository<DAL_AdopteUnDev.DTO.Developer> _repository;
        public DeveloperService(IDeveloperRepository<DAL_AdopteUnDev.DTO.Developer> repository)
        {
            _repository = repository;
        }
        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public Developer Get(int id)
        {
            return _repository.Get(id).ToBLL();
        }

        public IEnumerable<Developer> Get()
        {
            return _repository.Get().Select(d => d.ToBLL());
        }

        public int Insert(Developer entity)
        {
            return _repository.Insert(entity.ToDAL());
        }

        public void Update(int id, Developer entity)
        {
            _repository.Update(id, entity.ToDAL());
        }
    }
}
