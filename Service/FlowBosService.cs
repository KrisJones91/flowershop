using flowershop.Models;
using flowershop.Repositories;

namespace flowershop.Service
{
    public class FlowBosService
    {
        private readonly FlowBosRepository _repo;

        public FlowBosService(FlowBosRepository repo)
        {
            _repo = repo;
        }

        public FlowBo Create(FlowBo newFb)
        {
            int id = _repo.Create(newFb);
            newFb.Id = id;
            return newFb;
        }

        internal string Delete(int id)
        {
            _repo.Delete(id);
            return "Successfully Deleted";
        }
    }
}