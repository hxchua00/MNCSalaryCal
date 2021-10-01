using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace MNCSalaryCal
{
    class Salary
    {
        static double tax = 0.12;
        static double providentFund = 0.08;
        static double healthIns = 0.05;
        static double mutualFund = 0.07;
        static double probation;

        public static double GetProbationSalary(double salary)
        {
            probation = salary * 0.8;
            return probation;
        }
        public static double ProbationSalaryLeft(double salary)
        {
            Console.WriteLine();
            Console.WriteLine("Probation Salary: {0}", GetProbationSalary(salary));
            
            double ProbationTaxAmt = GetProbationSalary(salary) - (GetProbationSalary(salary) * tax);
            Console.WriteLine("Probation Salary after tax: {0}", ProbationTaxAmt);

            double ProbationPF = ProbationTaxAmt - (ProbationTaxAmt * providentFund);
            Console.WriteLine("Probation Salary after Provident Fund: {0}", ProbationPF);

            double ProbationHI = ProbationPF - (ProbationPF * healthIns);
            Console.WriteLine("Probation Salary after Health Insurance: {0}", ProbationHI);

            double ProbationMF = ProbationHI - (ProbationHI * mutualFund);
            Console.WriteLine("Probation Salary after Mutual Fund: {0}", ProbationMF);

            double totalPSalary = ProbationMF * 6;
            Console.WriteLine("Probation Final Salary: {0}", totalPSalary);

            return totalPSalary;

        }
        public static double NormalSalaryLeft(double salary)
        {
            Console.WriteLine();
            Console.WriteLine("Salary: {0}", salary);

            double AfterProbationTaxAmt = salary - (salary * tax);
            Console.WriteLine("Salary after tax: {0}", AfterProbationTaxAmt);

            double AfterProbationPF = AfterProbationTaxAmt - (AfterProbationTaxAmt * providentFund);
            Console.WriteLine("Salary after Provident Fund: {0}", AfterProbationPF);

            double AfterProbationHI = AfterProbationPF - (AfterProbationPF * healthIns);
            Console.WriteLine("Salary after Health Insurance: {0}", AfterProbationHI);

            double AfterProbationMF = AfterProbationHI - (AfterProbationHI * mutualFund);
            Console.WriteLine("Salary after Mutual Fund: {0}", AfterProbationMF);

            double totalSalary = AfterProbationMF * 6;
            Console.WriteLine("Total Salary After probation: {0}", totalSalary);

            return totalSalary;
        }

        public static double FinalSalary(double salary) 
        {
            double finalSalary = NormalSalaryLeft(salary) + ProbationSalaryLeft(salary);
            return finalSalary;
        }

        public static void InitThread(double salary)
        {
            Thread t1 = new Thread(() => { NormalSalaryLeft(salary); });
            Thread t2 = new Thread(() => { ProbationSalaryLeft(salary); });

            t1.Priority = ThreadPriority.Highest;
            t2.Priority = ThreadPriority.Highest;

            t1.Start();
            t2.Start();
        }
    }
}
