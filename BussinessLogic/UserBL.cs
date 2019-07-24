using BussinessObjects;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BussinessLogic
{

    public class UserBL :IUserModelBL
    {
        private readonly DBContext _context;

        public UserBL(DBContext context)
        {
            _context = context;
          
        }
       
        // GET: api/Users
        public IEnumerable<object> Get()
        {
            return _context.Users;
        }

        // GET: api/Users
       
        public int TotalRecords()
        {
            return _context.Users.Count();
        }

      
        public async Task<IList<object>> GetUsers(string inColumn = "", string forWord = "", string sortBy = "Id", int pageNo = 0, int pageSize = 5)
        {   //IMP : Be very careful abt the sortBy property. It should be exactly as the name of the property i.e. very case sensitive
            pageNo = pageNo - 1;

            var users = _context.Users.OrderBy(p => EF.Property<object>(p, sortBy));

            var selectUsers = from s in users select s;

            if (!String.IsNullOrEmpty(forWord))
            {
                switch (inColumn)
                {
                    case "Id":
                        selectUsers = selectUsers.Where(s => s.Id == Int32.Parse(forWord));
                        break;

                    default:
                        selectUsers = selectUsers.Where(s => EF.Property<string>(s, inColumn).Contains(forWord));
                        break;
                }
            }

            if (pageNo > -1)
            {
                return await selectUsers.Skip(pageNo * pageSize).Take(pageSize).ToArrayAsync();
            }
            else
            {
                return await selectUsers.ToArrayAsync();
            }

        }

        public async Task<IList<object>> GetUsers(int page = 1, int limit = 5, string sort = "Id", string search = "")
        {
            var skip = (page - 1) * limit;
            if (search == "")
            {
                var users = _context.UserModels.OrderBy(p => EF.Property<object>(p, sort));

                return await users.Skip(skip).Take(limit).ToArrayAsync();
            }
            else
            {
                var users = _context.UserModels.Where(p => p.Id.ToString().Contains(search) || p.Name.Contains(search) || p.Email.Contains(search) || p.Comments.Contains(search) || p.Choice.Contains(search)).OrderBy(p => EF.Property<object>(p, sort)); //True version

                return await users.Skip(skip).Take(limit).ToArrayAsync();
            }

        }


        public async Task<object> Get( int id)
        {

            var user=new User();
            try
            {
                user = await _context.Users.FindAsync(id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            

            return user;
        }


        
        public async Task<string> Put( int id, object user)
        {
            User nUser = (User) user;

            if (id != nUser.Id)
            {
                return "fail";
            }

            _context.Entry(nUser).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Exists(id))
                {
                    return "fail";
                }
                else
                {
                    throw;
                }
            }

            return "success";
        }

        // POST: api/Users
       
        public async Task<string> Post( object user)
        {
            User nUser = (User)user;

            try
            {
                _context.Users.Add(nUser);
                await _context.SaveChangesAsync();

            }
            catch (Exception e)
            {
                return "fail";
            }
            return "success";
        }

        // DELETE: api/Users/5
        
        public async Task<string> Delete( int id)
        {

            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return "fail";
            }

            try
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                return "fail";
            }

            return "success";
        }

        public bool Exists(int id)
        {
            return _context.Users.Any(e => e.Id == id);
        }

        public IList<object> GetAllUsers(string sortOrder = "no", string col = "", string val = "", int pageIndex = 1, int pageSize = 5)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<object> GetPermissions()
        {
            throw new NotImplementedException();
        }
    }
}