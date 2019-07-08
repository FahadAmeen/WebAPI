using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BussinessObjects;
using DataAccess;
using Microsoft.EntityFrameworkCore;

namespace BussinessLogic
{
    
    public class UserModelBL
    {
        private readonly DBContext _context;

        public UserModelBL(DBContext context)
        {
            _context = context;
        }

        
        public async Task<IList<UserModel>> GetUsers(int page = 1, int limit = int.MaxValue, string sort = "Id", string search = "")
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
       
        public async Task<UserModel> GetUserModel( int id)
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
        public async Task<string> PutUserModel( int id, UserModel userModel)
        {
            

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
                if (!UserModelExists(id))
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
        public async Task<string> PostUserModel( UserModel userModel)
        {
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
        
        public async Task<string> DeleteUserModel(int id)
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

        private bool UserModelExists(int id)
        {
            return _context.UserModels.Any(e => e.Id == id);
        }
    }
}