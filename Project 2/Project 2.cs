using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

//This program will take an input text file and count how many people there are in
//each age group and also how many there are in each separate district. It will
//also display an error if there is an datatype error in the text file and skip that line.
namespace Project_2
{
    class Program
    {
	//These are the declared constants for each array in the program.
        const int ageCounter = 5;
        const int ageSIZE = 9999;
        const int districtSIZE = 9999;
        const int districtCOUNTER = 23;
        const int genderSIZE = 9999;
        const int marriageSIZE = 9999;
		//Main method where the program's arrays are declared and where methods are called to be utilized.
        static void Main(string[] args)
        {
		//Main Arrays where each section of the text filed is stored.
            int[] ageGroup = new int[ageCounter];
            int[] ageList = new int[ageSIZE];
            int[] districtList = new int[districtSIZE];
            int[] counter = new int[districtCOUNTER];
            string[] genderList = new string[genderSIZE];
            string[] marriageList = new string[marriageSIZE];
			
			//Main methods(Will be explained above each method)
            countPopulation(ref ageGroup, ref ageList, ref districtList, ref counter, ref genderList, ref marriageList);
            displayAGETOTALS(ageGroup);
        }
		//This method will read into the test.txt file and store them in the appropriate array to be utilized. It will go through each line in the text file
        //and check if each datatype is correct, if not it will skip the line and display the line that has the error. Once each line is checked it will 
        //separate each line into their appropriate agegroup, and district. It will check if the datatypes for Marriage and Gender lines are correct.
        //Once all of this is done it will display the information to the user.
        static void countPopulation(ref int[] ageGroup, ref int[] ageList, ref int[] districtList, ref int[] counter, ref string[] genderList, ref string[] marriageList)
        {
            //Read File into the program.
            FileStream fStream = new FileStream("test.txt", FileMode.Open, FileAccess.Read);
            StreamReader inFile = new StreamReader(fStream);

            //Declared Variables.
            string inputFile = "";
            string[] textfields;
            inputFile = inFile.ReadLine();
            textfields = inputFile.Split(',');
            int i = 0;
            int lineCounter = 1;
			
            //As stated above this while statement will go through each line of the text file.
            while (inputFile != null)
            {
                //Splitting each line of the text file by a comma.
                textfields = inputFile.Split(',');

                //Trimming the spaces off the ends both ends of gender and marriage locations, and saving them into their arrays.
                genderList[i] = textfields[1].Trim();
                marriageList[i] = textfields[2].Trim();

                //This if statement, will make sure that each line is the correct datatype, if not it will display and error, and then save them into their
                //appropriate arrays to be utilized later.
                if (int.TryParse(textfields[0].Trim(), out ageList[i]) && int.TryParse(textfields[3].Trim(), out districtList[i]) && ageList[i] > 0 && districtList[i] >= 1 && districtList[i] <= 22)
                {
                    if (genderList[i] == "m" || genderList[i] == "M" || genderList[i] == "f" || genderList[i] == "F")
                    {
                        if (marriageList[i] == "m" || marriageList[i] == "M" || marriageList[i] == "s" || marriageList[i] == "S")
                        {
                            if (ageList[i] > 0 && ageList[i] <= 17)
                            {
                                ageGroup[0] = ageGroup[0] + 1;
                            }
                            else if (ageList[i] <= 30)
                            {
                                ageGroup[1] = ageGroup[1] + 1;
                            }
                            else if (ageList[i] >= 31 && ageList[i] <= 45)
                            {
                                ageGroup[2] = ageGroup[2] + 1;
                            }
                            else if (ageList[i] >= 46 && ageList[i] <= 64)
                            {
                                ageGroup[3] = ageGroup[3] + 1;
                            }
                            else if (ageList[i] > 65)
                            {
                                ageGroup[4] = ageGroup[4] + 1;
                            }
                            else
                            {
                                Console.WriteLine("Line " + lineCounter + " in the textfile has an error!");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Line " + lineCounter + " in the textfile has an error!");
                        }

                    }
                    else
                    {
                        Console.WriteLine("Line " + lineCounter + " in the textfile has an error!");
                    }

                }
                else
                {
                    Console.WriteLine("Line " + lineCounter + " in the textfile has an error!");
                }
                i++;
                lineCounter++;
                inputFile = inFile.ReadLine();
            }

            //This For Loop will count how many people are in each district.
            for (int a = 1; a < 23; a++)
            {
                for (int y = 0; y < districtList.Length; y++)
                {
                    if (districtList[y] == a)
                    counter[a]++;
                }
            }
            //This For Loop will separate each 22 Districts and display how many people are in each.
            Console.WriteLine("");
            for (int x = 1; x < 23; x++)
                Console.WriteLine("District: " + x + " Population: " + counter[x]);

        }
        //This Method will display how many there are in each declared age group, from earlier, to the user.
        static void displayAGETOTALS(int[] ageGroup)
        {
            Console.WriteLine("\nUnder 18 = {0}", ageGroup[0]);
            Console.WriteLine("18-30 = {0}", ageGroup[1]);
            Console.WriteLine("31-45 = {0}", ageGroup[2]);
            Console.WriteLine("46-64 = {0}", ageGroup[3]);
            Console.WriteLine("65 & over = {0}", ageGroup[4]);
        }
    }
}
