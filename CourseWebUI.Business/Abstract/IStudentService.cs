using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using CourseWebUI.Entities.ComplexTypes;
using CourseWebUI.Entities.Concrete;

namespace CourseWebUI.Business.Abstract
{
    public interface IStudentService
    {
        void Add(Student student);
        void Delete(Student student);
        void Update(Student student);
        Student Get(Expression<Func<Student, bool>> filter);
        List<Student> GetAll();
        List<Student> GetListByStudentFullName(string FullName);
        Student GetListByStudentID(int Id);
        List<Student> GetListByStudentPhoneNumber(string PhoneNumber);
        List<Student> GetListByStudentEmail(string Email);
        List<Student> GetListByStudentGender(bool is_male);
        Student GetByEmailAndPassword(string Email, string Password);
        List<StudentRoleItem> GetStudentRoles(Student student);
    }
}
