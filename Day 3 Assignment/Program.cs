using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day3Assignment
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee e = new Manager("Manager", "mngr", 40000, 1);
            Console.WriteLine("Empid: " + e.EMPNO + ", Name: " + e.NAME + ", Basic salary: " + e.BASIC + ", Dept No: " + e.DEPTNO);
            Console.ReadLine();
            Manager m = new GeneralManager("Gmngr", "","", 234,12);
            Console.WriteLine("Empid: " + m.EMPNO + ", Name: " + m.NAME + ", Basic salary: " + m.BASIC);
            Console.ReadLine();
            Employee ceo = new CEO("", 200000);
            Console.WriteLine("Empid: " + ceo.EMPNO + ", Name: " + ceo.NAME + ", Basic salary: " + ceo.BASIC + ", Net salary: " + ceo.CalcNetSalary());
            Console.ReadLine();

            Employee ceo1 = new CEO("CEO", 1000);
            Console.WriteLine("Empid: " + ceo1.EMPNO + ", Name: " + ceo1.NAME + ", Basic salary: " + ceo1.BASIC + ", Net salary: " + ceo1.CalcNetSalary());
            Console.ReadLine();

           


        }
    }
    #region Employee
    public abstract class Employee
    {
        private string Name;
        private static int EmpNo;
        protected decimal Basic;
        private short DeptNo;

        public Employee(string Name = "Dhruv", decimal Basic = 1000, short DeptNo = 99)
        {
            EmpNo++;
            this.EMPNO += EmpNo;
            this.NAME = Name;
            this.BASIC = Basic;
            this.DEPTNO = DeptNo;
        }

        #region Validations
        public string NAME
        {
            set
            {
                if (value == "")
                    Console.WriteLine("Name can not be empty");
                else
                    Name = value;

            }
            get { return Name; }
        }

        public int EMPNO
        {
            get;
        }
        public abstract decimal BASIC
        {
            set;
            get;
        }

        public short DEPTNO
        {
            set
            {
                if (value > 0)
                    DeptNo = value;
                else
                    Console.WriteLine("Enter valid Dept no");
            }
            get { return DeptNo; }
        }
        #endregion

        public abstract decimal CalcNetSalary();
    }
    #endregion

    #region Manager
    public class Manager : Employee
    {
        private
            string Designation;

        public Manager(string Designation = "mgr", string Name = "Dhruv", decimal Basic = 1500, short DeptNo = 99) : base(Name, Basic, DeptNo)
        {
            this.DESIGNATION = Designation;
        }
        public override decimal BASIC
        {
            get
            {
                return Basic;
            }
            set
            {
                if (value >= 50000 && value <= 150000)
                    Basic = value;
                else
                    Console.WriteLine("Enter valid basic");
            }
        }

        public override decimal CalcNetSalary()
        {
            if (BASIC >= 50000 && BASIC <= 150000)
            {
                decimal netSal = BASIC + 5000;
                return netSal;
            }
            return BASIC;
        }

        public string DESIGNATION
        {
            set
            {
                if (value == "")
                    Console.WriteLine("Name should not be empty");
                else
                    Designation = value;

            }
            get { return Designation; }
        }

    }
    #endregion  

    #region GM
    public class GeneralManager : Manager
    {
        string Perks;
        public GeneralManager(string Perks, string Designation = "Gmg", string Name = "Dhruv", decimal Basic = 2000, short DeptNo = 99) : base(Designation, Name, Basic, DeptNo)
        {
            this.Perks = Perks;
        }
        public override decimal BASIC
        {
            get
            {
                return Basic;
            }
            set
            {
                if (value >= 100000 && value <= 250000)
                    Basic = value;
                else
                    Console.WriteLine("Enter valid basic");
            }
        }
        public override sealed decimal CalcNetSalary()
        {
            if (BASIC >= 150000 && BASIC <= 350000)
            {
                decimal netSal = BASIC + 15000;
                return netSal;
            }
            return BASIC;
        }
    }

    #endregion

    #region CEO
    public class CEO : Employee
    {
        public CEO(string Name = "Dhruv", decimal Basic = 3000, short DeptNo = 99) : base(Name, Basic, DeptNo)
        {
        }
        public override decimal BASIC
        {
            get
            {
                return Basic;
            }
            set
            {
                if (value >= 150000 && value <= 350000)
                    Basic = value;
                else
                    Console.WriteLine("Enter valid basic");
            }
        }

        public override sealed decimal CalcNetSalary()
        {
            if (BASIC >= 150000 && BASIC <= 350000)
            {
                decimal netSal = BASIC + 15000;
                return netSal;
            }
            return BASIC;
        }
    }
    #endregion
}
