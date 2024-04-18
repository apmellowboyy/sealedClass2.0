// See ht﻿using System;
using System.Security.Cryptography.X509Certificates;
namespace Employees
{
    interface IEmployee
    {
        //Properties
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        //Methods
        public string Fullname();
        public double Pay();
    }
    class Employee : IEmployee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Employee()
        {
            Id = 0;
            FirstName = string.Empty;
            LastName = string.Empty;
        }
        public Employee(int id, string firstName, string lastName)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
        }
        public string Fullname()
        {
            return FirstName + " " + LastName;
        }
        public virtual double Pay()
        {
            double salary;
            Console.WriteLine($"What is {this.Fullname()}'s weekly salary?");
            salary = double.Parse(Console.ReadLine());
            return salary;
        }
    }
    sealed class Executive : Employee
    {
        public string title { get; set; }
        public int salary { get; set; }

        public Executive() :base()
        {
            title = string.Empty;
            salary = 0;
        }
        public Executive(int id, string firstName, string lastName, string title, int salary)
            :base(id, firstName, lastName)
        {
            this.title = title;
            this.salary = salary;
        }
        public sealed override double Pay()
        {
            return base.Pay();
        }
        public string technicallyNotOverride()
        {
            return "Tucker is an " + title + " and brings home " + salary;
        }
        public string againNotAnOverride()
        {
            return "Johnny is an " + title + " and brings home " + salary;
        }
    }
        class Program
        {

 

                static void Main(string[] args)
                {
                    Employee Harold = new Employee(12, "Harold", "Clarkson");
                    Console.WriteLine(Harold.Fullname());
                    Console.WriteLine(Harold.Pay());
                    Console.WriteLine("Hopefully that suits your bills.");

                    Console.WriteLine();

                    Employee Ethan = new Employee(29, "Ethan", "Barnes");
                    Console.WriteLine(Ethan.Fullname());
                    Console.WriteLine(Ethan.Pay());
                    Console.WriteLine("Hopefully you can live with that wage.");

                    Console.WriteLine();

                    Executive Tucker = new Executive();
                    Tucker.title = "Executive";
                    Tucker.salary = 1000;
                    Console.WriteLine(Tucker.technicallyNotOverride());

                    Console.WriteLine();
                    Executive Johnny = new Executive();
                    Johnny.title = "Executive";
                    Johnny.salary = 950;
                    Console.WriteLine(Johnny.againNotAnOverride());
                }
            }
        }