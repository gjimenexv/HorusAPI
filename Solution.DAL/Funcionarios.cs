using Solution.DAL.EF;
using Solution.DAL.Repository;
using Solution.DO.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using data = Solution.DO.Objects;

namespace Solution.DAL
{
    public class Funcionarios : ICRUD<data.Funcionarios>
    {
        private Repository<data.Funcionarios> _repository = null;
        public Funcionarios(SolutionDBContext solutionDBContext)
        {
            _repository = new Repository<data.Funcionarios>(solutionDBContext);
        }

        public void Delete(data.Funcionarios t)
        {
            _repository.Delete(t);
            _repository.Commit();
        }

        public IEnumerable<data.Funcionarios> GetAll()
        {
            return _repository.GetAll();
        }

        public data.Funcionarios GetOneById(int id)
        {
            return _repository.GetOnebyId(id);
        }
        public data.Funcionarios GetOneById(string id)
        {
            return _repository.GetOnebyId(id);
        }

        public void Insert(data.Funcionarios t)
        {
            _repository.Insert(t);
            _repository.Commit();
        }

        public void Updated(data.Funcionarios t)
        {
            _repository.Update(t);
            _repository.Commit();
        }
    }
}
