using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BussinessObjects;
using DataAccess;
using Microsoft.EntityFrameworkCore;

namespace BussinessLogic
{
    
    public class UserBL 
    {
        private readonly DBContext _context;

        public UserBL(DBContext context)
        {
            _context = context;
          
        }
       
        // GET: api/Users
        public IEnumerable<User> GetUsers()
        {
            return _context.Users;
        }

        // GET: api/Users
       
        public int GetCount()
        {
            return _context.Users.Count();
        }

      
        public async Task<IList<User>> Search(string inColumn = "", string forWord = "", string sortBy = "Id", int pageNo = 0, int pageSize = 5)
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



        
        public async Task<User> GetUser( int id)
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


        
        public async Task<string> PutUser( int id, User user)
        {
            

            if (id != user.Id)
            {
                return "fail";
            }

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
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
       
        public async Task<string> PostUser( User user)
        {


            try
            {
                _context.Users.Add(user);
                await _context.SaveChangesAsync();

            }
            catch (Exception e)
            {
                return "fail";
            }
            return "success";
        }

        // DELETE: api/Users/5
        
        public async Task<string> DeleteUser( int id)
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

        public bool UserExists(int id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
    }
}