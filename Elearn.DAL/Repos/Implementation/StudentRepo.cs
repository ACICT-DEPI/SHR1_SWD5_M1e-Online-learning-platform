using Elearn.DAL.Context;
using Elearn.DAL.Models;
using Elearn.DAL.Repos.Abstract;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Elearn.DAL.Repos.Implementation
{
    public class StudentRepo:GenericRepo<Student>,IStudentRepo 
    {
        private readonly ElearnContext _context;

        public StudentRepo(ElearnContext context):base(context) 
        {
            _context = context;
        }

        public void Delete(string id)
        {
            var student = _context.students.Find(id);
            if (student != null)
            {
                _context.students.Remove(student);
                _context.SaveChanges();
            }
        }

        

        

        public Student GetById(string id)
        {
            return _context.students.Find(id);
        }
    }
}
