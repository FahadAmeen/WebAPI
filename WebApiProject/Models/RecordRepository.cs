using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiProject.Models
{
    public class RecordRepository : IRecordRepository
    {
        private static List<Record> _records = new List<Record>();
        private int _nextId = 1;

        public RecordRepository()
        {
            Add(new Record { Name = "Rida", Salary = 30000 });
            Add(new Record { Name = "Tayyaba", Salary = 30000 });
            Add(new Record { Name = "Adan", Salary = 30000 });
        }

        public IEnumerable<Record> GetAll()
        {
            return _records;
        }

        public Record Get(int id)
        {
            return _records.Find(p => p.Id == id);
        }

        public Record Add(Record item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            item.Id = _nextId++;
            _records.Add(item);
            return item;
        }

        public void Remove(int id )
        {
            _records.RemoveAll(p => p.Id == id);
       
        }

        public bool Update(Record item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            int index = _records.FindIndex(p => p.Id == item.Id);
            if (index == -1)
            {
                return false;
            }
            _records.RemoveAt(index);
            _records.Add(item);
            return true;
        }

        public Task SaveChangesAsync()
        {
            throw new NotImplementedException();
        }
    }
}
