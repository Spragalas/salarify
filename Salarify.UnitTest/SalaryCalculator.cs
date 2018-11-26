using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Salarify.BusinessLogic;
using Salarify.DataLayer.Models;

namespace Salarify.UnitTest
    {
    [TestClass]
    public class SalaryCalculatorTests
        {
        [TestMethod]
        public void BaseSalary_Null ()
            {
            var employee = new Employee();
            Assert.ThrowsException<ArgumentNullException>(() => SalaryCalculator.Calculate(employee, null));
            }

        [TestMethod]
        public void Employee_Null ()
            {
            var baseSalary = new BaseSalary();
            Assert.ThrowsException<ArgumentNullException>(() => SalaryCalculator.Calculate(null, baseSalary));
            }

        [TestMethod]
        public void PositionDoesNotMatch ()
            {
            var employee = new Employee() { ExperienceYears = 1, Position = "NotTech", SatisfactionScore = SatisfactionScore.AboveAverage };
            var baseSalary = new BaseSalary() { ExperienceFrom = 0, ExperienceTo = 1, Position = "Tech", Salary = 1000 };
            Assert.ThrowsException<ArgumentException>(() => SalaryCalculator.Calculate(employee, baseSalary));
            }
        [TestMethod]
        public void ExpirienceDoesNotMatch ()
            {
            var employee = new Employee() { ExperienceYears = 100, Position = "NotTech", SatisfactionScore = SatisfactionScore.AboveAverage };
            var baseSalary = new BaseSalary() { ExperienceFrom = 0, ExperienceTo = 1, Position = "Tech", Salary = 1000 };
            Assert.ThrowsException<ArgumentException>(() => SalaryCalculator.Calculate(employee, baseSalary));
            }
        [TestMethod]
        public void AboveAverage ()
            {
            var employee = new Employee() { ExperienceYears = 1, Position = "Tech", SatisfactionScore = SatisfactionScore.AboveAverage };
            var baseSalary = new BaseSalary() { ExperienceFrom = 0, ExperienceTo = 1, Position = "Tech", Salary = 1000 };
            Assert.AreEqual(1870, SalaryCalculator.Calculate(employee, baseSalary).Salary);
            }
        [TestMethod]
        public void BelowAverage ()
            {
            var employee = new Employee() { ExperienceYears = 1, Position = "Tech", SatisfactionScore = SatisfactionScore.BelowAverage };
            var baseSalary = new BaseSalary() { ExperienceFrom = 0, ExperienceTo = 1, Position = "Tech", Salary = 1000 };
            Assert.AreEqual(1820, SalaryCalculator.Calculate(employee, baseSalary).Salary);
            }
        [TestMethod]
        public void Satisfied ()
            {
            var employee = new Employee() { ExperienceYears = 1, Position = "Tech", SatisfactionScore = SatisfactionScore.Satisfied };
            var baseSalary = new BaseSalary() { ExperienceFrom = 0, ExperienceTo = 1, Position = "Tech", Salary = 1000 };
            Assert.AreEqual(1950, SalaryCalculator.Calculate(employee, baseSalary).Salary);
            }
        [TestMethod]
        public void VerySatisfied ()
            {
            var employee = new Employee() { ExperienceYears = 1, Position = "Tech", SatisfactionScore = SatisfactionScore.VerySatisfied };
            var baseSalary = new BaseSalary() { ExperienceFrom = 0, ExperienceTo = 1, Position = "Tech", Salary = 1000 };
            Assert.AreEqual(2000, SalaryCalculator.Calculate(employee, baseSalary).Salary);
            }
        [TestMethod]
        public void Unsatisfied ()
            {
            var employee = new Employee() { ExperienceYears = 1, Position = "Tech", SatisfactionScore = SatisfactionScore.Unsatisfied };
            var baseSalary = new BaseSalary() { ExperienceFrom = 0, ExperienceTo = 1, Position = "Tech", Salary = 1000 };
            Assert.AreEqual(1800, SalaryCalculator.Calculate(employee, baseSalary).Salary);
            }
        [TestMethod]
        public void VeryUnsatisfied ()
            {
            var employee = new Employee() { ExperienceYears = 1, Position = "Tech", SatisfactionScore = SatisfactionScore.VeryUnsatisfied };
            var baseSalary = new BaseSalary() { ExperienceFrom = 0, ExperienceTo = 1, Position = "Tech", Salary = 1000 };
            Assert.AreEqual(1800, SalaryCalculator.Calculate(employee, baseSalary).Salary);
            }
        }
    }
