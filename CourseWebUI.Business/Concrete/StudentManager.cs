using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using AutoMapper;
using CourseWebUI.Business.Abstract;
using CourseWebUI.Business.ValidationRules.FluentValidation;
using CourseWebUI.Core.Aspects.Postsharp.Caching;
using CourseWebUI.Core.Aspects.Postsharp.Performance;
using CourseWebUI.Core.Aspects.Postsharp.Transaction;
using CourseWebUI.Core.Aspects.Postsharp.Validation;
using CourseWebUI.Core.CrossCuttingCorners.Caching.Microsoft;
using CourseWebUI.DataAccess.Abstract;
using CourseWebUI.Entities.ComplexTypes;
using CourseWebUI.Entities.Concrete;

namespace CourseWebUI.Business.Concrete
{
    public class StudentManager:IStudentService
    {
        private IStudentDal _studentDal;
        private IMapper _mapper;

        public StudentManager(IStudentDal studentDal,IMapper mapper)
        {
            _studentDal = studentDal;
            _mapper = mapper;
        }
        [FluentValidationAspect(typeof(StudentValidator))]
        public void Add(Student student)
        {
            _studentDal.Add(student);
        }

        public void Delete(Student student)
        {
            _studentDal.Delete(student);
        }
        [TransactionAspect]
        public void Update(Student student)
        {
            _studentDal.Update(student);
        }

        public Student Get(Expression<Func<Student, bool>> filter)
        {
            return _studentDal.Get(filter);
        }

        [CacheAspect(typeof(MemoryCacheManager))]
        [PerformanceCounterAspect(1)]
        public List<Student> GetAll()
        {
            var students = _mapper.Map<List<Student>>(_studentDal.GetAll());
            return students;
        }

        public List<Student> GetListByStudentFullName(string FullName)
        {
            return _studentDal.GetAll(x => x.FullName.Contains(FullName));
        }

        public Student GetListByStudentID(int Id)
        {
            return _studentDal.Get(v => v.Id == Id);
        }

        public List<Student> GetListByStudentPhoneNumber(string PhoneNumber)
        {
            return _studentDal.GetAll(c => c.PhoneNumber.Contains(PhoneNumber));
        }

        public List<Student> GetListByStudentEmail(string Email)
        {
            return _studentDal.GetAll(c => c.MailAddress.Contains(Email));
        }

        public List<Student> GetListByStudentGender(bool is_male)
        {
            return is_male == false
                ? _studentDal.GetAll(m => m.Gender == 0)
                : _studentDal.GetAll(x => x.Gender == 1);
        }

        public Student GetByEmailAndPassword(string Email, string Password)
        {
            return _studentDal.Get(z => z.MailAddress == Email && z.Password == Password);
        }

        public List<StudentRoleItem> GetStudentRoles(Student student)
        {
            return _studentDal.GetStudentRoles(student);
        }
    }
}
