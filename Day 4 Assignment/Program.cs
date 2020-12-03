using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day3Assignment
{
    class Program
    {
        #region MAIN
        static void Main(string[] args)
        {
            Manager e = new Manager("Manager", "mngr", 53000, 1);
            Console.WriteLine("Empid: " + e.EMPNO + ", Designation: " + e.DESIGNATION + ", Name: " + e.NAME + ", Basic salary: " + e.BASIC + ", Dept No: " + e.DEPTNO);
            e.Insert();
            e.Upadte();
            e.Delete();
            Console.ReadLine();

            GeneralManager m = new GeneralManager("", "General", "GM", 25000);
            Console.WriteLine("Empid: " + m.EMPNO + ",Perks: " + m.Perks + ", Designation: " + m.DESIGNATION + ", Name: " + m.NAME + ", Basic salary: " + m.BASIC);
            m.Insert();
            m.Upadte();
            m.Delete();
            Console.ReadLine();

            CEO ceo = new CEO("", 200000);
            Console.WriteLine("Empid: " + ceo.EMPNO + ", Name: " + ceo.NAME + ", Basic salary: " + ceo.BASIC + ", Net salary: " + ceo.CalcNetSalary());
            ceo.Insert();
            ceo.Upadte();
            ceo.Delete();
            Console.ReadLine();

            CEO ceo1 = new CEO("CEO", 1000);
            Console.WriteLine("Empid: " + ceo1.EMPNO + ", Name: " + ceo1.NAME + ", Basic salary: " + ceo1.BASIC + ", Net salary: " + ceo1.CalcNetSalary());
            ceo1.Insert();
            ceo1.Upadte();
            ceo1.Delete();
            Console.ReadLine();



        }
        #endregion
    }
    #region DbFunctions Interface
    public interface IDbFunctions
    {
        void Insert();
        void Upadte();
        void Delete();

    }
    #endregion

    #region Employee
    public abstract class Employee : IDbFunctions
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
                    Console.WriteLine("Name should not be empty");
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

        #region Implemented methods from IDbFunctions
        public void Insert()
        {
            Console.WriteLine("Employee Insert");
        }

        public void Upadte()
        {
            Console.WriteLine("Employee Upate");
        }

        public void Delete()
        {
            Console.WriteLine("Employee Delete");
        }
        #endregion
    }
    #endregion

    #region Manager
    public class Manager : Employee
    {
        private
            string Designation;

        public Manager(string Designation = "mngr", string Name = "Dhruv", decimal Basic = 1500, short DeptNo = 9) : base(Name, Basic, DeptNo)
        {
            this.DESIGNATION = Designation;
        }
        #region Validations
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
        #endregion

        #region Implemented methods from IDbFunctions
        public new void Insert()
        {
            Console.WriteLine("Manager Insert");
        }

        public new void Upadte()
        {
            Console.WriteLine("Mnagaer Upate");
        }

        public new void Delete()
        {
            Console.WriteLine("Manager Delete");
        }
        #endregion



    }
    #endregion  

    #region GM
    public class GeneralManager : Manager
    {
        public string Perks;
        public GeneralManager(string Perks = "perks", string Designation = "GM", string Name = "GMgr", decimal Basic = 2000, short DeptNo = 9) : base(Designation, Name, Basic, DeptNo)
        {
            this.Perks = Perks;
        }
        #region Validations
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
        #endregion

        #region Implemented methods from IDbFunctions
        public new void Insert()
        {
            Console.WriteLine("General Manager Insert");
        }

        public new void Upadte()
        {
            Console.WriteLine("General Mnagaer Upate");
        }

        public new void Delete()
        {
            Console.WriteLine("General Manager Delete");
        }
        #endregion
    }

    #endregion

    #region CEO
    public class CEO : Employee
    {
        public CEO(string Name = "Dhruv", decimal Basic = 30000, short DeptNo = 99) : base(Name, Basic, DeptNo)
        {
        }
        #region Validations
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
        #endregion

        #region Implemented methods from IDbFunctions
        public new void Insert()
        {
            Console.WriteLine("CEO Insert");
        }

        public new void Upadte()
        {
            Console.WriteLine("CEO Upate");
        }

        public new void Delete()
        {
            Console.WriteLine("CEO Delete");
        }
        #endregion
    }
    #endregion
}