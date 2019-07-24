using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BussinessObjects;
using DataAccess;
using Microsoft.EntityFrameworkCore;

namespace BussinessLogic
{
    
    public class UserModelBL :IUserModelBL
    {
        private readonly DBContext _context;

        public UserModelBL(DBContext context)
        {
            _context = context;
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
            { var users = _context.UserModels.Where(p => p.Id.ToString().Contains(search) || p.Name.Contains(search) || p.Email.Contains(search) || p.Comments.Contains(search) || p.Choice.Contains(search)).OrderBy(p => EF.Property<object>(p, sort)); //True version

                return await users.Skip(skip).Take(limit).ToArrayAsync();
            }

        }
        public async Task<IList<object>> GetUsers(string searchWith = "Id", string searchData = "", string sortData = "Id", int pageNo = 1, int pageSize = 5)
        {

            pageNo = pageNo - 1;
            var user = from s in _context.StudentRegisterations select s;
            user = _context.StudentRegisterations.OrderBy(s => EF.Property<object>(s, sortData));
            if (!String.IsNullOrEmpty(searchData))
            {
                if (searchWith == "Id")
                {
                    user = user.Where(s => s.Id == Int32.Parse(searchData));
                }
                else
                {
                    user = user.Where(s => EF.Property<string>(s, searchWith).Contains(searchData));
                }
            }
            return await user.Skip(pageNo * pageSize).Take(pageSize).ToArrayAsync();
        }

        public UserModelInfoWrapper CountAndData()
        {
            //int count = _context.UserModels.Count();
            UserModelInfoWrapper users = new UserModelInfoWrapper();
            users.count = _context.UserModels.Count();
            users.data = _context.UserModels.ToList();
            return users;
        }
        public int TotalRecords()
        {
            
            return _context.UserModels.Count();
        }


        // GET: api/UserModels/5
       
        public async Task<object> Get( int id)
        {
            var userModel=new UserModel();

            try
            {
                 userModel = await _context.UserModels.FindAsync(id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            
            return userModel;
        }

        // PUT: api/UserModels/5
        public async Task<string> Put( int id, object user)
        {
           UserModel userModel = (UserModel)user;
            
            if (id != userModel.Id)
            {
                return"fail";
            }

            _context.Entry(userModel).State = EntityState.Modified;

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

        // POST: api/UserModels
        public async Task<string> Post(object user)
        {
            UserModel userModel = (UserModel)user;
            try
            {
                _context.UserModels.Add(userModel);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                return "fail";
            }

            return "success";
        }

        // DELETE: api/UserModels/5
        
        public async Task<string> Delete(int id)
        {

            var userModel = await _context.UserModels.FindAsync(id);
            if (userModel == null)
            {
                return "fail";
            }

            try
            {
                _context.UserModels.Remove(userModel);
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
            return _context.UserModels.Any(e => e.Id == id);
        }

        public IList<object> GetAllUsers(string sortOrder = "no", string col = "", string val = "", int pageIndex = 1, int pageSize = 5)
        {
            throw new NotImplementedException();
        }
    }
}