using SoftUni.Data;
using System.Text;

namespace SoftUni
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            SoftUniContext softUniContext = new SoftUniContext();
            Console.WriteLine("Connection success!");
            Console.WriteLine(GetEmployeesFullInformation(softUniContext));
        }
        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var employees = context.Employees
                .OrderBy(e => e.EmployeeId)
                .Where<e => e.salary>
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.MiddleName,
                    e.JobTitle,
                    e.Salary
                })
                .ToArray(); //ToList() -> Detach from the change tracker, any changes on the data inside will not be saved into db
            foreach (var e in employees)
            {
                sb
                    .AppendLine($"{e.FirstName} {e.LastName} {e.MiddleName} {e.JobTitle} {e.Salary:f2}");
            }

            return sb.ToString().TrimEnd();

        }
    }
}