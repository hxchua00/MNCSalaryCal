using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace MNCSalaryCal
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter salary here: ");
            double salary = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine();

            Salary.InitThread(salary);

            Thread s1 = new Thread(() => { totalSalaryLeft(salary); });
            s1.Priority = ThreadPriority.Lowest;
            s1.Start();

            Console.ReadLine();
        }

        public static void totalSalaryLeft(double amount)
        {
            Console.WriteLine();
            Console.WriteLine("The total amount of salary after a year is {0}", Salary.FinalSalary(amount));
        }
    }
}
