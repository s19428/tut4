using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstWebApp.DAL
{
    public interface IDbService
    {
        public IEnumerable<Student> GetStudents();
    }
}
