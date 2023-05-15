using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace GradingSystemCalculator
{
    class PrintTable
    {
        // Field
        string result;
        double totalCourseUnit, totalCoursePassed, totalWeightPt, gpa;

        // Constructor
        public  PrintTable(string result, double totalCourseUnit, double totalCoursePassed, double totalWeightPt, double gpa) 
        {
            this.result = result;
            this.totalCoursePassed = totalCoursePassed;
            this.totalCourseUnit = totalCourseUnit;
            this.totalWeightPt = totalWeightPt;
            this.gpa = totalWeightPt / totalCourseUnit;
        }

        
        public void DisplayTable()
        {   //Table showing results
            Console.WriteLine(" TABLE SHOWING STUDENT RESULTS ");
            Console.WriteLine(" |---------------|-------------|-------|------------|------------|---------------|");
            Console.WriteLine(" | COURSE & CODE | COURSE UNIT | GRADE | GRADE-UNIT | WEIGHT Pt. | REMARK        |");
            Console.WriteLine(" |---------------|-------------|-------|------------|------------|---------------|");
            Console.Write(result); 
            Console.WriteLine(" |_______________|_____________|_______|____________|____________|_______________|");
            Console.WriteLine();Console.WriteLine();
            Console.WriteLine("Total Course Unit Registered is: " + totalCourseUnit);
            Console.WriteLine("Total Course Unit Passed is: " + totalCoursePassed);
            Console.WriteLine("Total Weight Point is: " + totalWeightPt);
            Console.WriteLine($"Your GPA is:  {gpa:F2}");
        }
    }
}
