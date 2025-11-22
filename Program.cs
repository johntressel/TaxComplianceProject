using System;
using System.Collections.Generic;

namespace TaxComplianceEngine
{
    public class Taxpayer
    {
        public int Id {get; set;}
        public string? Name {get; set;}
        public double Income {get; set;}
        public double TaxPaid {get; set;} 
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            List<Taxpayer> citizens = new List<Taxpayer>
            {
                new Taxpayer {Id = 1, Name = "John Smith", Income = 50000, TaxPaid = 5000},
                new Taxpayer {Id = 2, Name = "Kelly Smith", Income = 120000, TaxPaid = 8000},
                new Taxpayer {Id = 3, Name = "Bob Smith", Income = 300000, TaxPaid = 90000},
                new Taxpayer {Id = 4, Name = "Joe Smith", Income = 20000, TaxPaid = 500},
                new Taxpayer {Id = 5, Name = "Karen Smith", Income = 5000, TaxPaid = 0}
            };
            Console.WriteLine("COMPLIANCE CHECK STARTING NOW......");

            foreach (var person in citizens)
            {
                double taxOwed = CalculateTax(person.Income);
                double variance = person.TaxPaid - taxOwed;

                if (variance < -1)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"[AUDIT] {person.Name} UNDERPAID BY ${Math.Abs(variance):F2}");
                    Console.ResetColor();
                }
                else if (variance > 1)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"[REFUND] {person.Name} OVERPAID BY ${variance:F2}.");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"[OK] {person.Name} paid the correct amount.");
                    Console.ResetColor();
                }
            }
        }
        static double CalculateTax(double grossIncome)
        {
            double standardDeduction = 15000;
            double taxableIncome = grossIncome - standardDeduction;
            // If income is less than standard deduction, no tax
            if (taxableIncome <= 0)
            {
                return 0;
            }
            double tax = 0;
            // Bracket 1
            if (taxableIncome > 11925)
            {
                tax += 11925 *.1;
            }
            else
            {
                return taxableIncome * 0.1;
            }
            // Bracket 2
            if (taxableIncome > 48475)
            {
                tax += (48475-11925) *.12;
            }
            else
            {
                return tax + ((taxableIncome - 11925) * 0.12);
            }
            // Bracket 3
            if (taxableIncome > 103350)
            {
                tax += (103350-48475) * 0.22;
            }
            else
            {
                return tax + ((taxableIncome - 48475)*0.22);
            }
            // Bracket 4
            if (taxableIncome > 197300)
            {
                tax += (197300 - 103350) * 0.24;
            }
            else
            {
                return tax + ((taxableIncome - 103350)*.24);
            }
            if (taxableIncome > 250525)
            {
                tax += (250525-197300)*0.32;
            }
            else
            {
                return tax + ((taxableIncome - 197300)*0.32);
            }
            if (taxableIncome > 626350)
            {
                tax += (626350-250525)*0.35;
                tax += (taxableIncome - 626350)*0.37;
                return tax;
            }
            else
            {
                return tax + ((taxableIncome - 250525)*0.35);
            }
        }
    }
}