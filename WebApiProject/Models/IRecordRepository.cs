using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiProject.Models
{
    public interface IRecordRepository
    {
        IEnumerable<Record> GetAll();
        Record Get(int id);
        Record Add(Record item);
        void Remove(int id);
        bool Update(Record item);
        Task SaveChangesAsync();
    }
}
