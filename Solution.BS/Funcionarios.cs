using System;
using System.Collections.Generic;
using System.Text;
using data = Solution.DO.Objects;
using Solution.DO.Interfaces;
using Solution.DAL.EF;
using Solution.DAL;

namespace Solution.BS
{
    public class Funcionarios : ICRUD<data.Funcionarios>
    {
        private SolutionDBContext _solutionDBContext = null;
        public Funcionarios(SolutionDBContext solutionDBContext)
        {
            _solutionDBContext = solutionDBContext;
        }
        public void Delete(data.Funcionarios t)
        {
            new Solution.DAL.Funcionarios(_solutionDBContext).Delete(t);
        }

        public IEnumerable<data.Funcionarios> GetAll()
        {
            return new Solution.DAL.Funcionarios(_solutionDBContext).GetAll();
        }

        public data.Funcionarios GetOneById(int id)
        {
            return new Solution.DAL.Funcionarios(_solutionDBContext).GetOneById(id);
        }

        public data.Funcionarios GetOneById(string id)
        {
            return new Solution.DAL.Funcionarios(_solutionDBContext).GetOneById(id);
        }

        public void Insert(data.Funcionarios t)
        {
            t.IdFuncionario = 0; // TODO: Find how to put as null a int
            new Solution.DAL.Funcionarios(_solutionDBContext).Insert(t);
        }

        public void Updated(data.Funcionarios t)
        {
            new Solution.DAL.Funcionarios(_solutionDBContext).Updated(t);
        }
    }
}
