using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.Queries;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests.Queries
{
    [TestClass]
    public class StudentQueriesTests
    {
        private List<Student> _students;
 
        public StudentQueriesTests()
        {
            _students = new List<Student>();

            for (int i = 0; i < 10; i++)
            {
                var name = new Name("Aluno"+i,"AA");
                var document = new Document("1111111111", EDocumentType.CPF);
                var email = new Email(i+"@mail.com");
                var student = new Student(name, document, email);

                _students.Add(student);
            }
        }
        
        [TestMethod]
        public void ShouldReturnNullWhenDocumentNotExists()
        {
            var exp = StudentQueries.GetStudentInfo("123213");
            var student = _students.AsQueryable().Where(exp).FirstOrDefault();

            Assert.AreEqual(null, student);
        }

        [TestMethod]
        public void ShouldReturnStudentWhenDocumentNotExists()
        {
            var exp = StudentQueries.GetStudentInfo("11111111111");
            var student = _students.AsQueryable().Where(exp).FirstOrDefault();

            Assert.AreEqual(null, student);
        }
    }
}