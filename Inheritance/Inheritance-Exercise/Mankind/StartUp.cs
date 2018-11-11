using System;

namespace Mankind
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string[] studentInfo = Console.ReadLine().Split(' ');
            string[] workerInfo = Console.ReadLine().Split(' ');

            try
            {
                string firstName = studentInfo[0];
                string lastName = studentInfo[1];
                string facultyNumber = studentInfo[2];

                string workeFirstName = workerInfo[0];
                string workerLastName = workerInfo[1];
                decimal weekSalary = decimal.Parse(workerInfo[2]);
                double hoursPerDay = double.Parse(workerInfo[3]);

                Student student = new Student(firstName, lastName, facultyNumber);

                Worker worker = new Worker(workeFirstName, workerLastName, weekSalary, hoursPerDay);
                Console.WriteLine(student.ToString());
                Console.WriteLine();
                Console.WriteLine(worker.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
