using Mono.Cecil;

namespace EmployeeManagement.Tests.ArchitecturalTest;
public class Controller_Should_Have_Only_One_Method_HandleAsync : ICustomRule
{
    public bool MeetsRule(TypeDefinition type)
    {
        Console.WriteLine(type.Methods.Count(x => x.Name.Equals("HandleAsync")));
        return type.Methods.Count(x => x.Name.Equals("HandleAsync")).Equals(1);
    }
}