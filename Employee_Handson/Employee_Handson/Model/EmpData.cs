using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employee_Handson.Model
{
    public class EmpData
    {
        public static List<Employee> employees = new List<Employee>()
        {
            new Employee()
            {
                Id=1,
                Name="Vamshi",
                Department=new Department(){DepId=1,DepName="cse"},
                DateOfBirth=Convert.ToDateTime("1998-06-21 01:02:01 AM"),
                Permanent=true,
                Salary=10191,
                Skills= new List<Skill>(){
                    new Skill(){SkillId=1,SkillName="PYTHON"},
                    new Skill(){SkillId=2,SkillName="Java"},
                    new Skill(){SkillId=3,SkillName="C#"}
                }
            },

            new Employee()
            {
                Id=2,
                Name="Siri",
                Department=new Department(){DepId=2,DepName="Ece"},
                DateOfBirth=Convert.ToDateTime("1998-06-21 01:02:01 AM"),
                Permanent=false,
                Salary=19911,
                Skills= new List<Skill>(){new Skill(){SkillId=1,SkillName="Vb.net"} }
            }
        };

        public static List<Employee> GetStandardEmployeeLists()
        {
            return employees;
        }

        public static Employee UpdateEmp(int id,Employee empUpdated)
        {
            foreach (Employee e in employees)
            {
                if(e.Id == id)
                {
                    e.Name = empUpdated.Name;
                    e.Permanent = empUpdated.Permanent;
                    e.Salary = empUpdated.Salary;
                    e.Department = empUpdated.Department;
                    e.DateOfBirth = empUpdated.DateOfBirth;

                    return e;

                    
                }
               
            }
            return null;
        }
    }
}