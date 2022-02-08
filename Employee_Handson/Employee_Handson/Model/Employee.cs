using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Employee_Handson.Model
{
    public class Employee

    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Salary { get; set; }

        public bool Permanent { get; set; }

        public Department Department { get; set; }

        public List<Skill> Skills { get; set; }

        public DateTime DateOfBirth { get; set; }


        public static List<Employee> GetStandardEmployeesList()
        {
            List<Employee> lis = EmpData.GetStandardEmployeeLists();
            return lis;
        }
        public static string UpdateEmp(int id,Employee empUpdated)
        {
            Employee e = EmpData.UpdateEmp(id, empUpdated);
            if(e!=null)
            {
                return "Updated";
            }
            return "Invalid employee id";
        }
    }

    public class Department
    {
        public int DepId { get; set; }
        public string DepName { get; set; }
    }

    public class Skill
    {
        public int SkillId { get; set; }
        public string SkillName { get; set; }
    }

    


}
