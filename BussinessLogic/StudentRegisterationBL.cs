using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BussinessObjects;
using DataAccess;


namespace BussinessLogic
{
    public class StudentRegisterationBL :IUserModelBL
    {
        private readonly DBContext _context;

        public StudentRegisterationBL(DBContext context)
        {
            _context = context;

        }
        public int TotalRecords()
        {
            return _context.StudentRegisterations.Count();
        }

        public async Task<IList<object>> GetUsers(string searchWith = "Id", string searchData = "", string sortData = "Id",int pageNo = 1, int pageSize = 5)
        {

            pageNo = pageNo - 1;
            var user = from s in _context.StudentRegisterations select s;
            user = _context.StudentRegisterations.OrderBy(s=>EF.Property<object>(s, sortData));
            if (!String.IsNullOrEmpty(searchData))
            {
                if (searchWith == "Id" )
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
            var studentRegisteration=new StudentRegisteration();

            try
            {
                studentRegisteration = await _context.StudentRegisterations.FindAsync(id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return studentRegisteration;
        }

        
        public async Task<string> Put( int id, object user)
        {
            StudentRegisteration studentRegisteration = (StudentRegisteration) user;

            if (id != studentRegisteration.Id)
            {
                return "fail";
            }

            _context.Entry(studentRegisteration).State = EntityState.Modified;

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
                    return "fail";
                }
            }

            return "success";
        }

      
        public async Task<string> Post( object user)
        {
            StudentRegisteration studentRegisteration = (StudentRegisteration)user;
            try
            {
                _context.StudentRegisterations.Add(studentRegisteration);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                return "fail";
            }

            return "pass";
        }

        public async Task<string> Delete( int id)
        {
            var studentRegisteration = await _context.StudentRegisterations.FindAsync(id);
            if (studentRegisteration == null)
            {
                return "fail";
            }

            try
            {
                _context.StudentRegisterations.Remove(studentRegisteration);
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
            return _context.StudentRegisterations.Any(e => e.Id == id);
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