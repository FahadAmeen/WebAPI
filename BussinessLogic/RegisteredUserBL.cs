using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;
using BussinessObjects;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using Remotion.Linq.Clauses;


namespace BussinessLogic
{
    
    public class RegisteredUserBL
    {
        private readonly DBContext _context;
        public RegisteredUserBL(DBContext context)
        {
            _context = context;
        }


        //api/RegisteredUsers/GetAll?pageIndex=1&sortOrder=name&col=password&val=password7&pageSize=16
        public IEnumerable<RegisteredUser> Indexx(int pageIndex = 1, string sortOrder = "no", string col = "", string val = "",
            int pageSize = 5)
        {
            pageIndex = pageIndex - 1;
            sortOrder = sortOrder.ToLower();
            var user = from s in _context.RegisteredUsers
                       select s;
            switch (sortOrder)
            {
                case "id":
                    user = _context.RegisteredUsers.OrderBy(RegisteredUser => RegisteredUser.Id);
                    break;
                case "name":
                    user = _context.RegisteredUsers.OrderBy(RegisteredUser => RegisteredUser.Name);
                    break;
                case "email_address":
                    user = _context.RegisteredUsers.OrderBy(RegisteredUser => RegisteredUser.Email_address);
                    break;
                case "file_name":
                    user = _context.RegisteredUsers.OrderBy(RegisteredUser => RegisteredUser.FileName);
                    break;
                case "job_type":
                    user = _context.RegisteredUsers.OrderBy(RegisteredUser => RegisteredUser.Job_type);
                    break;
                case "phone_number":
                    user = _context.RegisteredUsers.OrderBy(RegisteredUser => RegisteredUser.Phone_number);
                    break;
                case "password":
                    user = _context.RegisteredUsers.OrderBy(RegisteredUser => RegisteredUser.Password);
                    break;
                default:
                    user = _context.RegisteredUsers.OrderBy(RegisteredUser => RegisteredUser.Name);
                    break;
                    //return user.Skip(pageIndex * pageSize).Take(pageSize);
            }

            if (!String.IsNullOrEmpty(val))
            {
                col = col.ToLower();
                switch (col)
                {
                    case "id":
                        user = user.Where(s => s.Id == Int32.Parse(val));
                        break;
                    case "name":
                        user = _context.RegisteredUsers.Where(p =>
                            string.Equals(p.Name, val, StringComparison.OrdinalIgnoreCase));
                        break;
                    case "email_address":
                        user = _context.RegisteredUsers.Where(p =>
                            string.Equals(p.Email_address, val, StringComparison.OrdinalIgnoreCase));
                        break;
                    case "file_name":
                        user = _context.RegisteredUsers.Where(p =>
                            string.Equals(p.FileName, val, StringComparison.OrdinalIgnoreCase));
                        break;
                    case "job_type":
                        user = _context.RegisteredUsers.Where(p =>
                            string.Equals(p.Job_type, val, StringComparison.OrdinalIgnoreCase));
                        break;
                    case "phone_number":
                        user = _context.RegisteredUsers.Where(p =>
                            string.Equals(p.Phone_number, val, StringComparison.OrdinalIgnoreCase));
                        break;
                    case "password":
                        user = _context.RegisteredUsers.Where(p =>
                            string.Equals(p.Password, val, StringComparison.OrdinalIgnoreCase));
                        break;
                    default:
                        break;
                }

            }
            return user.Skip(pageIndex * pageSize).Take(pageSize);
        }

        // GET: api/RegisteredUsers
        
        public IEnumerable<RegisteredUser> GetRegisteredUsers()
        {
            return _context.RegisteredUsers;
        }

        // GET: api/RegisteredUsers
        
        public int GetCount()
        {
            return _context.RegisteredUsers.Count();
        }
        // GET: api/RegisteredUsers/5
        
        public async Task<RegisteredUser> GetRegisteredUser( int id)
        {
            var registeredUser = await _context.RegisteredUsers.FindAsync(id);
            return registeredUser;
        }

        // PUT: api/RegisteredUsers/5
        public async Task<string> PutRegisteredUser( int id, RegisteredUser registeredUser)
        {
          

            if (id != registeredUser.Id)
            {
                return "fail";
            }

            _context.Entry(registeredUser).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RegisteredUserExists(id))
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

        // POST: api/RegisteredUsers
        
        public async Task<string> PostRegisteredUser( RegisteredUser registeredUser)
        {

            try
            {
                _context.RegisteredUsers.Add(registeredUser);
                await _context.SaveChangesAsync();

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return "fail";
                throw;
            }
            return "success";
        }

        // DELETE: api/RegisteredUsers/5
        
        public async Task<string> DeleteRegisteredUser( int id)
        {
         
            var registeredUser = await _context.RegisteredUsers.FindAsync(id);
            if (registeredUser == null)
            {
                return "fail";
            }

            try
            {
                _context.RegisteredUsers.Remove(registeredUser);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                return "fail";
            }

            return "success";
        }

        private bool RegisteredUserExists(int id)
        {
            return _context.RegisteredUsers.Any(e => e.Id == id);
        }
    }
}