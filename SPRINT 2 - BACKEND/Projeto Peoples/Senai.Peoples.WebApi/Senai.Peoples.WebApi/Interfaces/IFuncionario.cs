using Senai.Peoples.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Peoples.WebApi.Interfaces
{
    public interface IFuncionario
    {
        IEnumerable<Funcionario> Listar();
        Funcionario Insert(Funcionario funcionario);
        Funcionario Update(int id, Funcionario funcionario);
        void Delete(int id);
        Funcionario GetById(int id);
        IEnumerable<Funcionario> GetByNome(string filtro);
    }
}
