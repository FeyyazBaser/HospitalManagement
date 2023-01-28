using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Core.UnitOfWorks
{
    public interface IUnitOfWork
    {
        Task ICommitAsync();

        void Commit();
    }
}
