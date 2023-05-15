using System;
using System.Text.RegularExpressions;

namespace GradingSystemCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            //Variable declaration
            int InputCount;
            string? CourseCode;
            int CourseUnit;
            string Grade;
            int GradeUnit;
            int WeightPt;
            int Score;
            string Remark;
            string result = "";
            double totalWeightPt = 0;
            double totalCoursePassed = 0;
            double totalCourseUnit = 0;
            double gpa = 0;

            Console.WriteLine("GRADE POINT AVERAGE (GPA) CALCULATOR");
            
            //Prompting user to input courses offered
            Console.WriteLine("KINDLY INPUT YOUR COURSE DETAILS AND FOLLOW THE PROMPT");
            Console.WriteLine("How many courses do you offer: ");
            InputCount = Convert.ToInt32(Console.ReadLine());

            //looping through the variables
            for (int i = 1; i <= InputCount; i++)
            {

                Console.WriteLine("What is your course title & code: Format: MAT101, CHM101.");
                CourseCode = Console.ReadLine();
                while (!Regex.IsMatch(CourseCode, @"^[A-z]{3}\d{3}$"))
                {
                    Console.WriteLine("Please Input Valid Format: Format: MAT101, CHM101.");
                    CourseCode = Console.ReadLine();
                }

                Console.WriteLine("Input course Unit: ");
                string? UnitInput = Console.ReadLine();
                int unit;
                while(!int.TryParse(UnitInput, out unit) || unit < 0 || unit > 5)
                {
                    Console.WriteLine("Input valid course Unit: Format 0 - 5");
                    UnitInput = Console.ReadLine();
                }
                CourseUnit = unit;

                Console.WriteLine("Input Score: ");
                string? GainInput = Console.ReadLine();
                int gain;
                while(!int.TryParse(GainInput, out gain) || gain < 0 || gain >= 100)
                {
                    Console.WriteLine("Input valid score: Format 0 - 100");
                    GainInput = Console.ReadLine();
                }
                Score = gain;

                //if statement that determines the grade, gradeunit and remark  
                Grade = Score >= 70 ? "A" : Score >= 60 ? "B" : Score >= 50 ? "C" : Score >= 45 ? "D" : Score >= 40 ? "E" : "F";
                GradeUnit = Score >= 70 ? 5 : Score >= 60 ? 4 : Score >= 50 ? 3 : Score >= 45 ? 2 : Score >= 40 ? 1 : 0;
                Remark = GradeUnit == 5 ? "Excellent" : GradeUnit == 4 ? "Very Good" : GradeUnit == 3 ? "Good" : GradeUnit == 2 ? "Fair" : GradeUnit == 1 ? "Pass" : "Fail";
                

                //Calculating weight point
                WeightPt = (CourseUnit) * (GradeUnit);
                totalWeightPt += WeightPt;
                totalCourseUnit += CourseUnit;
  

                //if statement to exclude failed courses
                if (GradeUnit != 0)
                {
                    totalCoursePassed += CourseUnit;
                }
         
                //Arranging results on the table
                result = result + $" | {CourseCode,-13} |{CourseUnit,-12} |{Grade,-7}| {GradeUnit,-11}| {WeightPt,-10} |{Remark,-15}|\n";

            }
            PrintTable display = new PrintTable(result, totalCourseUnit, totalCoursePassed, totalWeightPt, gpa);
            Console.WriteLine(); Console.WriteLine(); Console.WriteLine();
            display.DisplayTable();

        }
    }
}