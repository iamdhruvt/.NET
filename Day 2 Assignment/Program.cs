using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee o1 = new Employee("Dhruv", 123456, 10);
            Employee o2 = new Employee("Dhruv", 123456);
            Employee o3 = new Employee("Dhruv");
            Employee o4 = new Employee();
            Employee[] o = { o1, o2, o3, o4 };

            /*Test CASES
            for(int y = 0; y < 3; y++)
            {
                Console.WriteLine(o[y].EMPNO);
            }
            */
            for(int i=0;i<4;i++ ) 
            {
                Console.WriteLine(".........For Object"+i+" Name: "+o[i].NAME+" Basic: "+o[i].BASIC+" DeptNo.: "+o[i].DEPTNO+" EmpNo: "+o[i].EMPNO+" Net Salary: "+o[i].GetNetSalary());
                
            }
            Console.ReadLine();
        }
    }



    class Employee
    {
        #region Properties
        private string Name;
        public string NAME
        {
            get { return Name; }
            set
            {
                if (value == "")
                    Console.WriteLine("Name can not be empty.");
                else
                    Name = value;
            }
        }


        private decimal Basic;
        public decimal BASIC
        {
            get { return Basic; }
            set
            {
                if (value < 149999 && value > 49999)
                    Basic = value;
                else
                {
     
                    Console.WriteLine("Basic Amount out of Range. Value set to 0");
                }
            }
        }


        private short DeptNo;
        public short DEPTNO
        {
            get
            {
                return DeptNo;
            }
            set
            {
                if (value > 0)
                    DeptNo = value;
                else
                    Console.WriteLine("Department Number can't be negative.");
            }
        }

        private static int EmpNo;
        public int EMPNO
        {
            get;
        }
        #endregion

        #region Method
        public decimal GetNetSalary()
        {
            return (Basic + 5000); 
        }

        #endregion

        #region Constructors
        public Employee(string Name,decimal Basic,short Deptno)
        {
            EmpNo++;
            EMPNO = EmpNo;
            BASIC = Basic;
            NAME = Name;
            DEPTNO = Deptno;
        }
        public Employee(string Name, decimal Basic)
        {
            EmpNo++;
            EMPNO = EmpNo;
            NAME = Name;
            BASIC = Basic;
        }
        public Employee(String Name)
        {
            EmpNo++;
            EMPNO = EmpNo;
            NAME = Name;
        }

        public Employee()
        {
            EmpNo++;
            EMPNO = EmpNo;
        }
        #endregion
    }
}
