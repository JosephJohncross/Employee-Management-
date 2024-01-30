using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagement.Application;
using EmployeeManagement.Domain.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace EmployeeManagement.Tests.ArchitecturalTest
{
    public class ArchitecturalTest
    {
        public const string DomainNamespace = "EmployeeManagement.Domain";
        public const string ApplicationNamespace = "EmployeeManagement.Application";
        public const string InfrastructureNamespace = "EmployeeManagement.Infrastructure";
        public const string ApiNamespace = "EmployeeManagement.API";

        [Fact]
        public void Domain_Should_NotHaveDependencyOnOtherProject()
        {
            //Arrange
            var assembly = typeof(AuditableEntity).Assembly;
            string[] otherProject = new[]{
                DomainNamespace,
                ApplicationNamespace,
                InfrastructureNamespace,
                ApiNamespace
            };

            //Act
            var testResult = Types
                .InAssembly(assembly)
                .ShouldNot()
                .HaveDependencyOnAll(otherProject)
                .GetResult();

            //Assert
            Assert.True(testResult.IsSuccessful);
        }

        [Fact]
        public void Application_Should_NotHaveDependencyOnOtherProjectAsideDomain()
        {
            // Arrange
            var assembly = typeof(ApplicationServiceRegisteration).Assembly;
            string[] otherProjects = new[] {
                InfrastructureNamespace,
                ApiNamespace
            };

            //Act
            var testResult = Types
                .InAssembly(assembly)
                .ShouldNot()
                .HaveDependencyOnAll(otherProjects)
                .GetResult();

            //Assert
            Assert.True(testResult.IsSuccessful);
        }

        [Fact]
        public void Controller_Should_Have_Only_One_Method()
        {
            //Arrange
            var assembly = typeof(Program).Assembly;

            //Act
            var testResult = Types
                .InAssembly(assembly)
                .That()
                .AreClasses()
                .And()
                .Inherit(typeof(ControllerBase))
                .Should()
                .MeetCustomRule(new Controller_Should_Have_Only_One_Method_HandleAsync())
                .GetResult();

            //Assert
            Assert.True(testResult.IsSuccessful);
        }

        // [Fact]
        // public void Test_Method()
        // {
        //     Assert.True(false);
        // }
    }
}