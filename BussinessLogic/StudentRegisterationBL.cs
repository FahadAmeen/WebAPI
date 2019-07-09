using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BussinessObjects;
using DataAccess;


namespace BussinessLogic
{
    public class StudentRegisterationBL 
    {
        private readonly DBContext _context;

        public StudentRegisterationBL(DBContext context)
        {
            _context = context;

        }
        public int GetCount()
        {
            return _context.StudentRegisterations.Count();
        }

        public async Task<IEnumerable<StudentRegisteration>> GetStudentRegisterationsAsync(int pageNo = 1, string searchWith = "Id", string searchData = "", string sortData = "Id", int pageSize = 5)
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


        public async Task<StudentRegisteration> GetStudentRegisteration( int id)
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

        
        public async Task<string> PutStudentRegisteration( int id, StudentRegisteration studentRegisteration)
        {
           

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
                if (!StudentRegisterationExists(id))
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

      
        public async Task<string> PostStudentRegisteration( StudentRegisteration studentRegisteration)
        {
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

        public async Task<string> DeleteStudentRegisteration( int id)
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

        public bool StudentRegisterationExists(int id)
        {
            return _context.StudentRegisterations.Any(e => e.Id == id);
        }
    }
}