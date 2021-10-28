using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

//This program will take an input file containing employee information, split the lines of information, check for valid values, and display
//any errors found in each line, and calculate the salary of each department from each employee.
namespace Project_3
{
    class Program
    {
        //Declared Constant
        const int departmentSIZE = 7;
        //Main Method
        static void Main(string[] args)
        {
            //Array for the number of departments
            double[] departments = new double[departmentSIZE];

            //Program Modules(will explain these above each method)
            employeePAY(ref departments);
            displayGROSSPAY(departments);
        }
        //This method will calculate each line for the employee's pay and add them to the total salary to which department they belong
        static void employeePAY(ref double[] departments)
        {
            //Reading in the text file and declaring variables needed
            FileStream fStream = new FileStream("test.txt", FileMode.Open, FileAccess.Read);
            StreamReader inFile = new StreamReader(fStream);

            string inputFile = "";
            string[] textfields;
            inputFile = inFile.ReadLine();
            textfields = inputFile.Split(',');
            int i = 0;
            int lineCounter = 1;
            double employeeSAL = 0;
            
            //This while loop will loop through each line and split the line by each comma.
            while (inputFile != null)
            {
                textfields = inputFile.Split(',');

                string employeeID = textfields[0].Trim();
                int departmentNUM = 0;
                double hourlySAL = 0.0;
                double hourWORK = 0.0;
                
                //This if statement will check for the valid values in the split line, calculate the employees salary and add them to the department
                //that they belong to, if the values are correct. If there is an error it will display the line that has the error and the error itself.
                if (int.TryParse(textfields[1].Trim(), out departmentNUM))
                {
                    if (double.TryParse(textfields[2].Trim(), out hourlySAL))
                    {
                        if (double.TryParse(textfields[3].Trim(), out hourWORK))
                        {
                            if (employeeID != "")
                            {
                                if (departmentNUM > 0 && departmentNUM < 8)
                                {
                                    if (hourlySAL >= 10.00)
                                    {
                                        if (hourWORK > 0)
                                        {
                                            if (departmentNUM == 1)
                                            {
                                                employeeSAL = hourlySAL * hourWORK;
                                                departments[0] = departments[0] + employeeSAL;
                                            }
                                            else if (departmentNUM == 2)
                                            {
                                                employeeSAL = hourlySAL * hourWORK;
                                                departments[1] = departments[1] + employeeSAL;
                                            }
                                            else if (departmentNUM == 3)
                                            {
                                                employeeSAL = hourlySAL * hourWORK;
                                                departments[2] = departments[2] + employeeSAL;
                                            }
                                            else if (departmentNUM == 4)
                                            {
                                                employeeSAL = hourlySAL * hourWORK;
                                                departments[3] = departments[3] + employeeSAL;
                                            }
                                            else if (departmentNUM == 5)
                                            {
                                                employeeSAL = hourlySAL * hourWORK;
                                                departments[4] = departments[4] + employeeSAL;
                                            }
                                            else if (departmentNUM == 6)
                                            {
                                                employeeSAL = hourlySAL * hourWORK;
                                                departments[5] = departments[5] + employeeSAL;
                                            }
                                            else if (departmentNUM == 7)
                                            {
                                                employeeSAL = hourlySAL * hourWORK;
                                                departments[6] = departments[6] + employeeSAL;
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("Line " + lineCounter + " in the textfile has the error: " + textfields[3]);
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Line " + lineCounter + " in the textfile has the error: " + textfields[2]);
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Line " + lineCounter + " in the textfile has the error: " + textfields[1]);
                                }

                            }
                            else
                            {
                                Console.WriteLine("Line " + lineCounter + " in the textfile has the error: " + textfields[0]);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Line " + lineCounter + " in the textfile has the error: " + textfields[3]);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Line " + lineCounter + " in the textfile has the error: " + textfields[2]);
                    }
                }
                else
                {
                    Console.WriteLine("Line " + lineCounter + " in the textfile has the error: " + textfields[1]);
                }
                i++;
                lineCounter++;
                inputFile = inFile.ReadLine();
            }
        }

        //This method will display the values of the department array to each corresponding department total. 
        static void displayGROSSPAY(double[] departments)
        {
            Console.WriteLine("Total Gross Pay of Department 1: ${0}", departments[0]);
            Console.WriteLine("Total Gross Pay of Department 2: ${0}", departments[1]);
            Console.WriteLine("Total Gross Pay of Department 3: ${0}", departments[2]);
            Console.WriteLine("Total Gross Pay of Department 4: ${0}", departments[3]);
            Console.WriteLine("Total Gross Pay of Department 5: ${0}", departments[4]);
            Console.WriteLine("Total Gross Pay of Department 6: ${0}", departments[5]);
            Console.WriteLine("Total Gross Pay of Department 7: ${0}", departments[6]);
        }
    }
}
