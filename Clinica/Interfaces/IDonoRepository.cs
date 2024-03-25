using Clinica.Models;
using System.Collections.Generic;

namespace Clinica.Interfaces
{
    public interface IDonoRepository
    {
        // READ
        ICollection<Dono> GetAll();
        Dono GetById(int id);
        // CREATE
        Dono Insert (Dono dono);
        // UPDATE
        Dono Update(int id,Dono dono);
        // DELETE
        bool Delete(int id);
    }
}
