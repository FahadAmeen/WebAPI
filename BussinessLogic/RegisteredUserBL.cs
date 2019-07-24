using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BussinessObjects;
using DataAccess;
using Microsoft.EntityFrameworkCore;


namespace BussinessLogic
{

    public class RegisteredUserBL : IUserModelBL
    {
        private readonly DBContext _context;
        public RegisteredUserBL(DBContext context)
        {
            _context = context;
        }


        //api/RegisteredUsers/GetAll?pageIndex=1&sortOrder=name&col=password&val=password7&pageSize=16
        public IList<object> GetAllUsers( string sortOrder = "no", string col = "", string val = "",
            int pageIndex = 1,int pageSize = 5)
        {
            pageIndex = pageIndex - 1;
            sortOrder = sortOrder.ToLower();
            var skipCount = pageIndex * pageSize;
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
                        user = _context.RegisteredUsers.Where(p =>(p.Name.Contains(val)));
                        break;
                    case "email_address":
                        user = _context.RegisteredUsers.Where(p =>
                            (p.Email_address.Contains(val)));
                        break;
                    case "file_name":
                        user = _context.RegisteredUsers.Where(p =>
                            (p.FileName.Contains(val)));
                        break;
                    case "job_type":
                        user = _context.RegisteredUsers.Where(p =>
                            (p.Job_type.Contains(val)));
                        break;
                    case "phone_number":
                        user = _context.RegisteredUsers.Where(p =>
                            (p.Phone_number.Contains(val)));
                        break;
                    default:
                        break;
                }

            }
            var obj =  user.Skip(skipCount).Take(pageSize).ToArray();
            return obj;

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


        // GET: api/RegisteredUsers

        public int TotalRecords()
        {
            return _context.RegisteredUsers.Count();
        }
        // GET: api/RegisteredUsers/5
        
        public async Task<object> Get( int id)
        {
            var registeredUser = await _context.RegisteredUsers.FindAsync(id);
            return registeredUser;
        }

        // PUT: api/RegisteredUsers/5
        public async Task<string> Put( int id, object user)
        {
            RegisteredUser registeredUser = (RegisteredUser) user;

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

        // POST: api/RegisteredUsers
        
        public async Task<string> Post( object user)
        {
            RegisteredUser registeredUser = (RegisteredUser)user;
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
        
        public async Task<string> Delete( int id)
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

        public bool Exists(int id)
        {
            return _context.RegisteredUsers.Any(e => e.Id == id);
        }

        public Task<IList<object>> GetUsers(string inColumn = "", string forWord = "", string sortBy = "Id", int pageNo = 0, int pageSize = 5)
        {
            throw new NotImplementedException();
        }
    }
}