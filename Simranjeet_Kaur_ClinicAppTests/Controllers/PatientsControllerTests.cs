using Microsoft.VisualStudio.TestTools.UnitTesting;
using Simranjeet_Kaur_ClinicApp.Controllers;
using Simranjeet_Kaur_ClinicApp.Models;
using Simranjeet_Kaur_ClinicApp.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Simranjeet_Kaur_ClinicApp.Tests.Controllers
{
    [TestClass]
    public class PatientsControllerTests
    {
        private ClinicDBContext _context;
        private PatientsController _controller;

        [TestInitialize]
        public void Setup()
        {
            // Setting up in-memory DB
            var options = new DbContextOptionsBuilder<ClinicDBContext>()
                .UseInMemoryDatabase(databaseName: "TestClinicDB")
                .Options;

            _context = new ClinicDBContext(options);

            // Adding a test patient
            _context.Patients.Add(new Patient
            {
                Id = 1,
                FirstName = "Simran",
                LastName = "Kaur",
                City = "Brampton",
                DoctorAssigned = "Dr. Smith",
           
            });
            _context.SaveChanges();

            var repo = new PatientRepository(_context);
            _controller = new PatientsController(repo);
        }

        [TestMethod]
        public async Task Details_ReturnsCorrectPatient_WhenIdIsValid()
        {
            // Act
            var result = await _controller.Details(1) as ViewResult;
            var model = result?.Model as Patient;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(model);
            Assert.AreEqual("Simran", model.FirstName);
            Assert.AreEqual("Dr. Smith", model.DoctorAssigned);
        }

        [TestMethod]
        public async Task Details_ReturnsNotFound_WhenIdIsInvalid()
        {
            // Act
            var result = await _controller.Details(999);

            // Assert
            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }

        [TestMethod]
        public async Task Edit_ReturnsNotFound_WhenIdIsNull()
        {
            // Act
            var result = await _controller.Edit(null);

            // Assert
            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }

        [TestMethod]
        public async Task Edit_ReturnsViewResult_WhenIdIsValid()
        {
            // Act
            var result = await _controller.Edit(1);

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod]
        public async Task Delete_ReturnsNotFound_WhenIdIsNull()
        {
            // Act
            var result = await _controller.Delete(null);

            // Assert
            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }

        [TestMethod]
        public async Task DeleteConfirmed_RemovesPatient()
        {
            // Act
            await _controller.DeleteConfirmed(1);
            var deleted = _context.Patients.Find(1);

            // Assert
            Assert.IsNull(deleted);
        }

       
    }
}
