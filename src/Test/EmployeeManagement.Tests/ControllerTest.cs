using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NetArchTest.Rules;
using Microsoft.AspNetCore.Mvc;
using EmployeeManagement.API.EndpointClasses.Articles;
using System.Diagnostics.CodeAnalysis;

namespace EmployeeManagement.Tests
{

    // public class ControllerTest
    // {
    //     [Fact]
    //     public void Should_Have_Only_One_Handler_Inside_Them()
    //     {
    //         var result =
    //             Types.InAssembly(typeof(Publish).Assembly)
    //                 .That()
    //                 .AreClasses()
    //                 .And()
    //                 .Inherit(typeof(ControllerBase))
    //                 .Should()
    //                 .MeetCustomRule(new OnlyOneHandleRule())
    //                 .GetResult();

    //         Assert.True(result.IsSuccessful);
    //     }

    //     [Fact]
    //     public void Should_Have_Only_One_ActionResult_Inside_Them()
    //     {
    //         var result =
    //             Types.InAssembly(typeof(Publish).Assembly)
    //                 .That()
    //                 .AreClasses()
    //                 .And()
    //                 .Inherit(typeof(ControllerBase))
    //                 .Should()
    //                 .MeetCustomRule(new OnlyOneActionResultRule())
    //                 .GetResult();

    //         Assert.True(result.IsSuccessful);
    //     }
    // }

    // public class OnlyOneHandleRule : ICustomRule
    // {
    //     public bool MeetsRule(TypeDefinition type)
    //     {
    //         return type.Methods.Count(x => x.Name.Equals("HandleAsync")).Equals(1);
    //     }
    // }

    // public class OnlyOneActionResultRule : ICustomRule
    // {
    //     public bool MeetsRule(TypeDefinition type)
    //     {
    //         return type.Methods.Count(x => x.IsPublic && !x.IsConstructor).Equals(1);
    //     }
    // }
}