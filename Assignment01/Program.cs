/*
Assignemnt 01 -> 73%
*/

using System;
using System.IO;
using System.Text;
namespace Assingment1
{
    class Program
    {
        static void Main(string[] args)
        {
//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~            
            //this part is dealing with the 'UI functionality' from the marking scheme

            //copied the assignment details for this part
            //just a prompt for the user when running the program
            Console.WriteLine("-v, -verbose               Verbose mode");
            Console.WriteLine("-o <file> -output=<file>   Output file specified by <file>");
            Console.WriteLine("-l, -list-formats          List formats");
            Console.WriteLine("-h, -help                  Show usage message");
            Console.WriteLine("-i, -info                  Show version information");

            //got this from w3schools on how to read in user input
            //https://www.w3schools.com/cs/cs_user_input.php
            string Input = Console.ReadLine();
            //splitting everything by a space so you can do multiple commands at once
            //so like '-i', '-h'
            //https://learn.microsoft.com/en-us/dotnet/csharp/how-to/parse-strings-using-split
            string[] DashOption = Input.Split(' ');
            //for using the o command
            string inputFile;
            string outputFile;
            //public string[][] array_table;

            //for loop to run through each flag
            for(int a = 0; a < DashOption.Length; a++)
            {
                //switch to run through and handle each flag
                switch(DashOption[a])
                {
                    //handle -v flag
                    case "-v" :
                    Console.WriteLine("Showing Debug");
                    break;
                    
                    //handle -o flag -> will work when reading/opening file works
                    case "-o" :
                    Console.WriteLine("Reading from file");
                    break;

                    //handle -l flag -> working
                    case "-l" :
                    Console.WriteLine("'.CSV',   '.JSON',   '.HTML',   '.MD'");
                    break;

                    //handle -h flag -> working
                    case "-h" :
                    Console.WriteLine("-v, -verbose               Verbose mode");
                    Console.WriteLine("-o <file> -output=<file>   Output file specified by <file>");
                    Console.WriteLine("-l, -list-formats          List formats");
                    Console.WriteLine("-h, -help                  Show usage message");
                    Console.WriteLine("-i, -info                  Show version information");
                    break;

                    //handle -i flag -> working
                    case "-i" :
                    Console.WriteLine("Version: 1.123456789");
                    break;

                    //default case -> working
                    /*
                    default :
                    Console.WriteLine("Not a recognized flag, please try again!");
                    break;*/
                }
            }

//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ 
            //this is my attempt at trying to read in files

            //gonna use a string builder
            //i wanna to be whaterver length it needs to be
            StringBuilder Builder = new StringBuilder();
            //i was originally not gonna use this
            //i had the full path but that started getting messy
            string FilePath = @"./test.ext";
            //empty string so we an add in the information
            string Line = "";

            //this just checks if there is no file then make one
            if(!File.Exists(FilePath))
            {
                //https://learn.microsoft.com/en-us/dotnet/api/system.io.file.create?view=net-7.0
                //https://learn.microsoft.com/en-us/dotnet/api/system.io.streamwriter?view=net-7.0
                using(StreamWriter Writer = new StreamWriter(FilePath))
                {
                    //making a new file and adding this to it
                    Console.WriteLine("Blah blah blah");
                }
            }

            //open the file you called and read from that file
            //https://learn.microsoft.com/en-us/dotnet/api/system.io.streamwriter?view=net-7.0
            using(StreamReader Reader = new StreamReader(FilePath))
            {
                while((Line = Reader.ReadLine()) != null)
                {
                    //calling the empty string
                    Console.WriteLine(Line);
                }
            }

            //picking which file you are writing to
            //once the file gets read into the string builder turn the contents into a string
            string FileType = Builder.ToString();
            //seperate by the full stop -> after full stop is the file type
            Line = Line.Substring(Line.LastIndexOf('.'));

            //switch to run through the different file types
            switch(Line)
            {
                case ".csv" :
                break;

                case ".html" :
                break;

                case ".json" :
                break;

                case ".md" :
                break;
            }

        }//end of main method
    }//end of program class 
//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
    //i got the blueprint for this code from the second tutorial
    //creating a new class -> this part is dealing with the 'Internal OOP rep of tables' from the marking scheme
    class Table
    {
        //going to be using for my to 2d array method
        //going to be converting to a 2d array and then into the file type i want
        public string inputFile{ get; }
        public string  outputFile{ get; }
        public string[][] array_table;

        //constructor
        public Table(string inputFile, string outputFile)
        {
            this.inputFile = inputFile;
            this.outputFile = outputFile;
        }

        //my to 2d array
        //this will convert different formats into a 2d array -> this is the middle ground
        //use switch to convert formats into a 2d array
        public void To2DArray(string inputPath)
        {
            //string used to separate at the '.' 
            string[] TXT = inputPath.Split(".");
            switch(TXT[1])
            {
                case "csv" :
                array_table = ConvertfromCSV(inputPath);
                break;

                /*      couldnt really get these working so scarped the idea for now
                case "html" :
                array_table = fromHTML(inputPath);
                break;

                case "json" :
                array_table = fromJSON(inputPath);
                break;

                case "md" :
                array_table = fromMD(inputPath);
                break;
                */

                default:
                break;
            }
        }

        //after my file has being converted into a 2d array it will go here next
        //will take the 2d array and convert into the file typed
        //use switch to convert 2d into the different formats
        public void ToFileOutput(string outputPath)
        {
            //string used to separate at the '.' 
            string[] TXT = outputPath.Split(".");
            switch(TXT[1])
            {
                case "csv" :
                toCSV(outputPath);
                break;

                case "html" :
                toHTML(outputPath);
                break;

                case "json" :
                toJSON(outputPath);
                break;

                case "md" :
                toMD(outputPath);
                break;

                default:
                break;
            }
        }

//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        //a method to help convert a csv to a 2d array
        //parse CSV
        public string[][] ConvertfromCSV(string inputFile)
        {
            StreamReader Reader = new StreamReader(inputFile);
            //https://stackoverflow.com/questions/4438169/how-can-i-initialize-a-c-sharp-list-in-the-same-line-i-declare-it-ienumerable
            //initalising the list in the same line i delcare it
            var lists = new List<string[]>();
            //https://learn.microsoft.com/en-us/dotnet/api/system.io.streamreader.endofstream?view=net-7.0
            while(!Reader.EndOfStream)
            {
                //split on the ','
                string[] list = Reader.ReadLine().Split(",");
                //was going to use somelist but it started to get too complicated
                //https://stackoverflow.com/questions/225937/foreach-vs-somelist-foreach
                //https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/statements/iteration-statements
                foreach(string l in list)
                {
                    l.Replace("\"", "");
                }
                lists.Add(list);
            }
            return lists.ToArray();
        }

//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        //methods to go from 2d array to each format
        //converting into a CSV
        public void toCSV(string output)
        {
            //https://learn.microsoft.com/en-us/dotnet/api/system.io.file.create?view=net-7.0
            //https://learn.microsoft.com/en-us/dotnet/api/system.io.streamwriter?view=net-7.0
            //https://learn.microsoft.com/en-us/dotnet/api/system.io.file.createtext?view=net-7.0
            using(StreamWriter Writer = File.CreateText(@"test/" + output))
            {
                for(int a = 0; a < array_table.Length; a++)
                {
                    string Text = "";
                    for(int b = 0; b < array_table[a].Length; b++)
                    {
                        //seperate by comma
                        Text += array_table[a][b] +","; 
                    }

                    Writer.WriteLine(Text);
                }
            }
        }

        //converting into a html
         public void toHTML(string output)
        {
            //https://learn.microsoft.com/en-us/dotnet/api/system.io.file.create?view=net-7.0
            //https://learn.microsoft.com/en-us/dotnet/api/system.io.streamwriter?view=net-7.0
            //https://learn.microsoft.com/en-us/dotnet/api/system.io.file.createtext?view=net-7.0
            using(StreamWriter Writer = File.CreateText(@"test/" + output))
            {                    
                for(int a = 0; a < array_table.Length; a++)
                {
                    //seperate by <tr>
                    Writer.WriteLine("<tr>");

                    for(int b = 0; b < array_table[a].Length; b++)
                    {
                        //put between th
                        if(a == 0)
                        {
                            Writer.WriteLine("  <th>" + array_table[a][b].Trim('"') + "</th>");
                        } 
                        //put between td
                        else 
                        {
                            Writer.WriteLine("  <td>" + array_table[a][b].Trim('"') + "</td>");
                        }                            
                    }

                    Writer.WriteLine("</tr>");
                }   
            }
        }

        //converting into json
        public void toJSON(string output)
        {
            //https://learn.microsoft.com/en-us/dotnet/api/system.io.file.create?view=net-7.0
            //https://learn.microsoft.com/en-us/dotnet/api/system.io.streamwriter?view=net-7.0
            //https://learn.microsoft.com/en-us/dotnet/api/system.io.file.createtext?view=net-7.0
            using(StreamWriter sw = File.CreateText(@"test/" + output))
            {
                //seperate by '[]'
                sw.WriteLine("[");
                 
                for(int a = 1; a < array_table.Length; a++)
                {
                    //seperate by the '{}'
                    sw.WriteLine("  {");
                    for(int b = 0; b < array_table[a].Length; b++)
                    {
                        //spacing after the ':' and the ',' -> has this in the assingment pdf
                        sw.WriteLine("      " + array_table[0][b] + ":" + array_table[a][b] + ",");
                    }

                    sw.WriteLine("  },");
                }

                sw.WriteLine("]");
            }
        } 

        //converting into md
        public void toMD(string output)
        {
            //https://learn.microsoft.com/en-us/dotnet/api/system.io.file.create?view=net-7.0
            //https://learn.microsoft.com/en-us/dotnet/api/system.io.streamwriter?view=net-7.0
            //https://learn.microsoft.com/en-us/dotnet/api/system.io.file.createtext?view=net-7.0
            using(StreamWriter sw = File.CreateText(@"test/" + output))
            {
                for(int a = 0; a < array_table.Length; a++)
                {
                    string line = "|";
                    for(int b = 0; b < array_table[a].Length; b++)
                    {     
                        line += array_table[a][b].Trim('"') + "|";   
                    }

                    sw.WriteLine(line);
                    if(a == 0)
                    {
                        string headline = "|";
                        for(int b = 0; b < array_table[a].Length; b++)
                        {
                        
                            headline +="------|";  
                        }
                        sw.WriteLine(headline);
                    }
                }
            }
        }
    

//-----------------------------------------------------------------------------------------------------------------------
//was orginally going to use this but i hit a wall
        /*
        //number of rows in table
        public int NumRows { get; }
        //number of columns in table 
        public int NumCols { get; } 
        //when i put into my consturctor it repres the info that parsed from the start file 
        //and will use to print into the end file 
        private string TableStartToEnd { get; }  
        //holds data
        //using a 2d array
        public string[][] MyTable;

        //again this method is heavily relying on the tutorial
        //method that holds the info you want to use throughout your method
        //just for storing
        public Table(int NumRows, int NumCols, string TableStartToEnd)
        {
            this.NumCols = NumCols;
            this.NumRows = NumRows;
            this.TableStartToEnd = TableStartToEnd;

            //Fill the table with details
            for(int i = 0; i < NumRows; i++)
            {
                for(int j = 0; i < NumCols; j++)
                {
                    //Parsing data from the file and filling it into MyTable.
                    MyTable[i][j] = TableStartToEnd; 
                }
            }
        }//end of table method
        */
        //again this method is heavily relying on the tutorial
        /*
        public void PrintingTable()
        {
            for(int i = 0; i < NumRows; i++)
            {
                for(int j = 0; j < NumCols; j++)
                {
                    Console.WriteLine(MyTable[i][j]);
                }
            }
        }
        */
    }//end of table class
}//end namespace
