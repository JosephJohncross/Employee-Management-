// using EmployeeManagement.Application.DTOs.Employee;

// namespace EmployeeManagement.Application.Features.Employee.Commands.UpdateEmployeeCommand
// {
//     public class UpdateEmployeeCommandValidator : AbstractValidator<UpdateEmployeeDTO>
//     {
//         public UpdateEmployeeCommandValidator()
//         {
//             RuleFor(e => e.Email).EmailAddress().WithMessage("Invalid email address");
//             RuleFor(e => e.Address.PostalCode).Must(LengthofPostalCode)
//                     .WithMessage("Length of postal code must be 6");
//         }

//         private bool LengthofPostalCode(int postalCode)
//         {
//             int postalCodeLength = 6;
//             return postalCodeLength.ToString().Length == postalCodeLength;
//         }
//     }
// }