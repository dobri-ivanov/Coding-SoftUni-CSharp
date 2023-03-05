namespace SoftUni;

using System.Globalization;
using System.Text;

using Microsoft.EntityFrameworkCore;

using Data;
using Models;

public class StartUp
{
    static void Main(string[] args)
    {
        SoftUniContext dbContext = new SoftUniContext();

        Console.WriteLine(GetEmployeesFromResearchAndDevelopment(dbContext));
    }

    // Problem 03
    public static string GetEmployeesFullInformation(SoftUniContext context)
    {
        StringBuilder sb = new StringBuilder();

        var employees = context.Employees
            .OrderBy(e => e.EmployeeId)
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

    // Problem 04
    public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
    {
        int salaryLimit = 50_000;
        StringBuilder sb = new StringBuilder();
        var employees = context.Employees
            .Where(e => e.Salary > salaryLimit)
            .OrderBy(e => e.FirstName)
            .Select(e => new
            {
                e.FirstName,
                e.Salary
            })
            .ToArray();

        foreach (var employee in employees)
        {
            sb.AppendLine($"{employee.FirstName} - {employee.Salary:f2}");
        }

        return sb.ToString().TrimEnd();
    }
    // Problem 05
    public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
    {
        //Research and Development department
        StringBuilder sb = new StringBuilder();

        var employees = context.Employees
            .Where(e => e.Department.Name == "Research and Development")
            .Select(e => new
            {
                e.FirstName,
                e.LastName,
                DepartmentName = e.Department.Name,
                e.Salary
            })
            .OrderBy(e => e.Salary)
            .ThenByDescending(e => e.FirstName)
            .ToArray();

        foreach (var e in employees)
        {
            sb.AppendLine($"{e.FirstName} {e.LastName} from {e.DepartmentName} - ${e.Salary:f2}");
        }
        return sb.ToString().TrimEnd();
    }

    

}