using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BussinessObjects;

namespace BussinessLogic
{
    public interface IUserModelBL
    {
        Task<IList<object>> GetUsers(int page = 1, int limit = 5, string sort = "Id", string search = "");

        Task<IList<object>> GetUsers(string inColumn = "", string forWord = "", string sortBy = "Id", int pageNo = 0,
            int pageSize = 5);
        int TotalRecords();
        Task<object> Get(int id);
        Task<string> Put(int id, object user);
        Task<string> Post(object user);
        Task<string> Delete(int id);
        bool Exists(int id);
        IEnumerable<Object> GetPermissions();

        IList<object> GetAllUsers(string sortOrder = "no", string col = "", string val = "",
            int pageIndex = 1, int pageSize = 5);
    }
}