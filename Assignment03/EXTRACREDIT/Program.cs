/*
Hi Demonstrator!
--------------------------------------------
I am using:                                |
Windows 10                                 |
.NET version 6.0                           |
Visual Studio Code                         |
Used the VSCode Extension 'CSharp to PUML' |
Used PlantUML Preview Current Diagram      |
--------------------------------------------
All the 'PlantUML' diagrams are located in the folder named 'PlantUML'
My UML stuff is a bit temperamental -> Make sure the .puml is open in main and in the command palate view
For saving and quitting the program two svg files, the one created from saving will be named 'saving' 
and the one created from quitting will be called 'quitting'

Hi Demonstrator!
This file contains all the extra credit -> the rest of the work is copied and pasted apart from the marked sections
(i)	include commands specifying parameters to create specific shapes
(ii) include commands for applying basic styles for	generated shapes
(iv) include commands to add styled	and	formatted text to the canvas
*/
using System;
using static System.Console;
using System.Collections.Generic;
using System.IO;

namespace Assignment03Single
{
    class Program2
    {
        //main method
        static void Main(string[] args)
        {
            //set of variables
            bool running = true;
            string input = "";
            string svgFile = "";

            //List to store inputted shapes
            List<Shape> Canvas = new List<Shape>();
            //CareTaker variable -> controls undo and redo stuff
            //https://www.dofactory.com/net/memento-design-pattern
            Caretaker CareUndoRedo = new Caretaker();

            //main menu -> order of commands from assignment sheet
            Console.Clear();
            Console.WriteLine("Welcome to Lauren's Canvas! \nCanvas has been created! \nBelow is a list of all commands!");
            //```````` EXTRA CREDIT ````````
            Console.WriteLine("-> 'A' <Shape name>  - Add Shape to Canvas \n~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine("-> 'B' <Shape name>  - Add Shape with Custom Boundaries to Canvas");
            Console.WriteLine("-> 'E'               - Update/Edit the Style of Existing Shapes (Stroke width/Stroke colour/Fill colour");
            Console.WriteLine("-> 'T'               - Add Custom Text to Canvas \n~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            //```````` EXTRA CREDIT ````````
            Console.WriteLine("-> 'C'     - Clear all Shapes from Canvas (Warning! Clear will prevent undoing functions before the Clear)");
            Console.WriteLine("-> 'D'     - Display the current Canvas");
            Console.WriteLine("-> 'S'     - Save and Export the Canvas to an SVG File");
            Console.WriteLine("-> 'U'     - Undo the Previous Function");
            Console.WriteLine("-> 'R'     - Redo the Previous Undo");
            Console.WriteLine("-> 'Q'     - Exit & Save the Canvas");
            Console.WriteLine("-> 'H'     - Reprints list of Commands \n~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
//-----------------------------------------------------------------------------------------------------------------------
            while (running)
            {
                input = Console.ReadLine()!;
                string shape = "";
                //if user inputted a wrong shape/no shape them display this message
                if(input.Equals("A") || input.Equals("a")) 
                { 
                    Console.WriteLine("You silly goose you never inputted a valid shape");
                    //working shape inputs
                    Console.WriteLine("Valid Shapes: \n ->'Rect' -> Rectangle \n ->'Circ' -> Circle \n ->'Elli' ->Ellispe \n ->'Line' -> Line \n ->'Polyl' -> Polyline \n ->'Polyg' -> Polygon \n ->'Path' -> Path");
                    input = "";
                }
                //```````` EXTRA CREDIT ````````
                else if(input.Equals("B") || input.Equals("b")) 
                { 
                    Console.WriteLine("You silly goose you never inputted a valid shape");
                    //working shape inputs
                    Console.WriteLine("Valid Shapes: \n ->'Rect' -> Rectangle \n ->'Circ' -> Circle \n ->'Elli' ->Ellispe \n ->'Line' -> Line \n ->'Polyl' -> Polyline \n ->'Polyg' -> Polygon \n ->'Path' -> Path");
                    input = "";
                }
                //```````` EXTRA CREDIT ````````
                //splits after the a letter -> allows the user to add a shape
                //https://www.c-sharpcorner.com/UploadFile/mahesh/substring-in-C-Sharp/#:~:text=A%20Substring%20in%20C%23%20is,C%23%20substring%20with%20code%20examples.
                else if(input.Contains("A") || input.Contains("a"))
                {
                    shape = input.Substring(2);
                    input = input.Substring(0, 1).ToUpper();
                    shape = shape.Substring(0, 1).ToUpper() + shape.Substring(1).ToLower();
                } 
                //```````` EXTRA CREDIT ````````
                else if(input.Contains("B") || input.Contains("b"))
                {
                    shape = input.Substring(2);
                    input = input.Substring(0, 1).ToUpper();
                    shape = shape.Substring(0, 1).ToUpper() + shape.Substring(1).ToLower();
                } 
                //```````` EXTRA CREDIT ````````
                //makes it so user and input capital and non capital letters
                else 
                { 
                    input = input.ToUpper(); 
                }
                //use switch statement to run through appropriate lines
                //-------------------------------------------------------------------------------------------------------
                switch (input)
                {
                    //Add shapes to the canvas
                    case "A":
                    {
                        addShape(shape, Canvas);
                        break;
                    }
                //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
                //```````` EXTRA CREDIT ````````
                    //Add shapes with boundaires to the canvas
                    case "B":
                    {
                        addShape(shape, Canvas, input);
                        break;
                    }
                //```````` EXTRA CREDIT ````````
                //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
                    //```````` EXTRA CREDIT ````````
                    //Edit Shape style
                    case "E":
                    {
                        Console.WriteLine("Please select the index of the shape you wish to edit");
                        int zIndex = 1;
                        //foreach prints out all the shapes currently in canvas
                        foreach(Shape s in Canvas)
                        {
                            //increment z index
                            Console.WriteLine("Index " + zIndex++ + ": " + s.name);
                        }
                        //allows user to pick which shape the want to edit based on index
                        int userSelection = Convert.ToInt32(Console.ReadLine());
                        //call the update shape method
                        updateShape(Canvas, userSelection);
                        break;
                    }
                    //```````` EXTRA CREDIT ````````
                //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
                    //```````` EXTRA CREDIT ````````
                    case "T":
                    {
                        //call addText method and add to canvas
                        addText(Canvas);
                        break;
                    }
                    //```````` EXTRA CREDIT ````````
                //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
                    //Clear the Canvas
                    case "C":
                    {
                        Canvas.Clear();
                        //makes sure to clear the caretaker -> make sure theres no mis-redo
                        CareUndoRedo = new Caretaker();
                        Console.WriteLine("Canvas cleared!");
                        break;
                    }
                //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
                    //Display the Canvas
                    case "D":
                    {
                        Console.WriteLine("Canvas:");
                        printCurrentSVG(Canvas);
                        break;
                    }
                //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
                    //Save the SVG File
                    case "S":
                    {
                        svgFile = createSVG(Canvas);
                        Console.WriteLine("File saving.svg has been succesfully saved!");
                        File.WriteAllText("saving.svg", svgFile);
                        break;
                    }
                //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
                    //Undo previous functions
                    case "U":
                    {
                        //if theres no more functions to undo
                        if(Canvas.Count == 0) 
                        { 
                            Console.WriteLine("There are no more shapes in the canvas"); 
                        }
                        //if there is more functions to undo
                        else 
                        { 
                            undoShapeCanvas(Canvas, CareUndoRedo); 
                            Console.WriteLine("Undo");
                        }
                        break;
                    }
                //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
                    //Redo previous Undo functions
                    case "R":
                    {
                        //inform user theres no more shapes to add into canvas
                        if(CareUndoRedo.getSize() == 0) 
                        { 
                            Console.WriteLine("There are no more shapes to redo"); 
                        }
                        else 
                        { 
                            redoShapeCanvas(Canvas, CareUndoRedo); 
                            Console.WriteLine("Redo");
                        }
                        break;
                    }
                //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
                    //Quit the program and save the SVG File
                    case "Q":
                    {
                        //used save case for this
                        svgFile = createSVG(Canvas);
                        Console.WriteLine("File quitting.svg has been succesfully saved!");
                        File.WriteAllText("quitting.svg", svgFile);
                        //break loop and exit program
                        Console.WriteLine("Goodbye! Come back anytime!");
                        running = false;
                        break;
                    }
                //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
                    //Reprint the commands lists
                    case "H":
                    {
                        Console.WriteLine("All Commands:");
                        Console.WriteLine("-> 'A' <Shape name>  - Add Shape to Canvas \n~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                        Console.WriteLine("-> 'B' <Shape name>  - Add Shape with Custom Boundaries to Canvas");
                        Console.WriteLine("-> 'E'               - Update/Edit the Style of Existing Shapes (Stroke width/Stroke colour/Fill colour");
                        Console.WriteLine("-> 'T'               - Add Custom Text to Canvas \n~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                        Console.WriteLine("-> 'C'     - Clear all Shapes from Canvas (Warning! Clear will prevent undoing functions before the Clear)");
                        Console.WriteLine("-> 'D'     - Display the current Canvas");
                        Console.WriteLine("-> 'S'     - Save and Export the Canvas to an SVG File");
                        Console.WriteLine("-> 'U'     - Undo the Previous Function");
                        Console.WriteLine("-> 'R'     - Redo the Previous Undo");
                        Console.WriteLine("-> 'Q'     - Exit & Save the Canvas");
                        Console.WriteLine("-> 'H'     - Reprints list of Commands \n~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                        break;
                    }
                //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
                    //default case if user inputs invalid command
                    default:
                    {
                        Console.WriteLine("Invalid Input, please try a different input");
                        break;
                    }
                }
                input = "";
            }
        }
//-----------------------------------------------------------------------------------------------------------------------
        //methods for methods called during the cases -> each method will be separated for easy reading
//-----------------------------------------------------------------------------------------------------------------------
        //```````` EXTRA CREDIT ````````
        //method to help find the int for the custom boundaries
        static int findPoint(string str)
        {
            for(int a = 0; a < str.Length; a++)
            {
                //take input after the '=' symbol
                if(str[a].Equals('=')) 
                { 
                    str = str.Substring(a + 1); 
                }
            }
            return Int32.Parse(str);
        }
        //```````` EXTRA CREDIT ````````

        //method to add shapes to canvas -> 'A' command
        //mainly took inspo from my previous assignment
        public static void addShape(string str, List<Shape> Canvas)
        {
            //switch to add each shape when inputted shape command
            switch (str)
            {
                case "Rect":
                {
                    Rectangle rect = new Rectangle(100, 100, 200, 200);
                    Canvas.Add(rect);
                    Console.WriteLine(rect.name + " (X=" + rect.x + ",Y=" + rect.y + ",W=" + rect.w + ",H=" + rect.h + ") has been added to canvas.");
                    break;
                }
            //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
                case "Circ":
                {
                    Circle circ = new Circle(100, 200, 200);
                    Canvas.Add(circ);
                    Console.WriteLine(circ.name + " (X=" + circ.cx + ",Y=" + circ.cy + ",R=" + circ.rad + ") has been added to canvas.");
                    break;
                }
            //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
                case "Elli":
                {
                    Ellipse elli = new Ellipse(100, 110, 200, 200);
                    Canvas.Add(elli);
                    Console.WriteLine(elli.name + " (RX=" + elli.rx + ",RY=" + elli.rx + ",CX=" + elli.cy + ",CY= " + elli.cy + ") has been added to canvas.");
                    break;
                }
            //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
                case "Line":
                {
                    Line line = new Line(100, 100, 200, 200);
                    Canvas.Add(line);
                    Console.WriteLine(line.name + " (X1=" + line.x1 + ",Y1=" + line.y1 + ",X2=" + line.x2+ ",Y2=" + line.x2 + ") has been added to canvas.");
                    break;
                }
            //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
                case "Polyl":
                {
                    Polyline polyl = new Polyline("0, 100 200, 20 50, 200 300, 0");
                    Canvas.Add(polyl);
                    Console.WriteLine(polyl.name + " (Co-Ordinates=" + polyl.coord + ") has been added to canvas.");
                    break;
                }
            //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
                case "Polyg":
                {
                    Polygon polyg = new Polygon("100, 100 200, 20 100, 200 300, 0");
                    Canvas.Add(polyg);
                    Console.WriteLine(polyg.name + " (Co-Ordinates=" + polyg.coord + ") has been added to canvas.");
                    break;
                }
            //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
                case "Path":
                {
                    Path path = new Path("M 10 20 C 100 200 150 50 10 200 L 150 200");
                    Canvas.Add(path);
                    Console.WriteLine(path.name + " (Co-Ordinates=" + path.coord + ") has been added to canvas.");
                    break;
                }
            //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
                default:
                {
                    Console.WriteLine("Invalid shape input");
                    Console.WriteLine("Valid Shapes: \n ->'Rect' -> Rectangle \n ->'Circ' -> Circle \n ->'Elli' ->Ellispe \n ->'Line' -> Line \n ->'Polyl' -> Polyline \n ->'Polyg' -> Polygon \n ->'Path' -> Path");
                    break;
                }
            }
        }
//---------------------------------------------------------------------------------------------------------------
//---------------------------------------------------------------------------------------------------------------
        //```````` EXTRA CREDIT ````````
        //copy and pasted the previous addShape -> this handles the extra credit of custom boundaries
        public static void addShape(string str, List<Shape> Canvas, string point)
        {
            int custom;
            //string scustom;
            //switch to add each shape when inputted shape command
            switch (str)
            {
                case "Rect":
                {
                    //```````` EXTRA CREDIT ````````
                    Console.WriteLine("Set Boundaries for Rectangle: ");
                    Console.WriteLine("Please insert digit for 'X' coords");
                    int x = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Please insert digit for 'Y' coords");
                    int y = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Please insert digit for the 'Width'");
                    int w = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Please insert digit for the 'Height'");
                    int h = Convert.ToInt32(Console.ReadLine());
                    //```````` EXTRA CREDIT ````````
                    Rectangle rect = new Rectangle(x, y, w, h);
                    Canvas.Add(rect);
                    Console.WriteLine(rect.name + " (X=" + rect.x + ",Y=" + rect.y + ",W=" + rect.w + ",H=" + rect.h + ") has been added to canvas.");
                    break;
                }
            //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
                case "Circ":
                {
                    //```````` EXTRA CREDIT ````````
                    Console.WriteLine("Set Boundaries for Circle: ");
                    Console.WriteLine("Please insert digit for 'X' coords");
                    int cx = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Please insert digit for 'Y' coords");
                    int cy = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Please insert digit for the 'Radius'");
                    int rad = Convert.ToInt32(Console.ReadLine());
                    //```````` EXTRA CREDIT ````````
                    Circle circ = new Circle(cx, cy, rad);
                    Canvas.Add(circ);
                    Console.WriteLine(circ.name + " (X=" + circ.cx + ",Y=" + circ.cy + ",R=" + circ.rad + ") has been added to canvas.");
                    break;
                }
            //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
                case "Elli":
                {
                    //```````` EXTRA CREDIT ````````
                    Console.WriteLine("Set Boundaries for Ellipse: ");
                    Console.WriteLine("Please insert digit for 'X' coords");
                    int rx = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Please insert digit for 'Y' coords");
                    int ry = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Please insert digit for second 'X' coords");
                    int cx = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Please insert digit for second 'Y' coords");
                    int cy = Convert.ToInt32(Console.ReadLine());
                    //```````` EXTRA CREDIT ````````
                    Ellipse elli = new Ellipse(rx, ry, cx, cy);
                    Canvas.Add(elli);
                    Console.WriteLine(elli.name + " (RX=" + elli.rx + ",RY=" + elli.rx + ",CX=" + elli.cy + ",CY= " + elli.cy + ") has been added to canvas.");
                    break;
                }
            //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
                case "Line":
                {
                    //```````` EXTRA CREDIT ````````
                    Console.WriteLine("Set Boundaries for Line: ");
                    Console.WriteLine("Please insert digit for 'X' coords");
                    int x1 = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Please insert digit for 'Y' coords");
                    int y1 = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Please insert digit for second 'X' coords");
                    int x2 = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Please insert digit for second 'Y' coords");
                    int y2 = Convert.ToInt32(Console.ReadLine());
                    //```````` EXTRA CREDIT ````````
                    Line line = new Line(x1, y1, x2, y2);
                    Canvas.Add(line);
                    Console.WriteLine(line.name + " (X1=" + line.x1 + ",Y1=" + line.y1 + ",X2=" + line.x2+ ",Y2=" + line.y2 + ") has been added to canvas.");
                    break;
                }
            //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
                case "Polyl":
                {
                    //```````` EXTRA CREDIT ````````
                    Console.WriteLine("Set Boundaries for Polyline: ");
                    Console.WriteLine("Please insert digit for the coords");
                    string coord = Console.ReadLine();
                    //```````` EXTRA CREDIT ````````
                    Polyline polyl = new Polyline(coord);
                    Canvas.Add(polyl);
                    Console.WriteLine(polyl.name + " (Co-Ordinates=" + polyl.coord + ") has been added to canvas.");
                    break;
                }
            //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
                case "Polyg":
                {
                    //```````` EXTRA CREDIT ````````
                    Console.WriteLine("Set Boundaries for Polygon: ");
                    Console.WriteLine("Please insert digit for the coords");
                    string coord = Console.ReadLine();
                    //```````` EXTRA CREDIT ````````
                    Polygon polyg = new Polygon(coord);
                    Canvas.Add(polyg);
                    Console.WriteLine(polyg.name + " (Co-Ordinates=" + polyg.coord + ") has been added to canvas.");
                    break;
                }
            //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
                case "Path":
                {
                    //```````` EXTRA CREDIT ````````
                    Console.WriteLine("Set Boundaries for Path: ");
                    Console.WriteLine("Please insert digit for the coords");
                    string coord = Console.ReadLine();
                    //```````` EXTRA CREDIT ````````
                    Path path = new Path(coord);
                    Canvas.Add(path);
                    Console.WriteLine(path.name + " (Co-Ordinates=" + path.coord + ") has been added to canvas.");
                    break;
                }
            //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
                default:
                {
                    Console.WriteLine("Invalid shape input");
                    Console.WriteLine("Valid Shapes: \n ->'Rect' -> Rectangle(x,y,w,h) \n ->'Circ' -> Circle(x,y,r) \n ->'Elli' ->Ellispe(rx,ry,cx,cy) \n ->'Line' -> Line(x1,y1,x2,y2) \n ->'Polyl' -> Polyline(points) \n ->'Polyg' -> Polygon(points) \n ->'Path' -> Path(points");
                    break;
                }
            }
        }
    //---------------------------------------------------------------------------------------------------------------
    //---------------------------------------------------------------------------------------------------------------
        //method to display the svg file -> 'D' command
        static void printCurrentSVG(List<Shape> Canvas)
        {
            String SVG = createSVG(Canvas);
            Console.WriteLine(SVG);
        }
    //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        //method to save the svg file -> 'S' command
        //uses the shapes in the canvas to create the svg file
        //mainly copied and pasted from previous assignment
        public static string createSVG(List<Shape> Shape)
        {
            string start = "<svg width=\"1000\" height=\"1000\" version=\"1.1\" xmlns=\"http://www.w3.org/2000/svg\">";
            string middle = "";
            string end = "</svg>";
            foreach (Shape s in Shape)
            {
                if (s.name.Equals("Rectangle")) { middle += "\n" + s.getCode(); }
                else if (s.name.Equals("Circle")) { middle += "\n" + s.getCode(); }
                else if (s.name.Equals("Ellipse")) { middle += "\n" + s.getCode(); }
                else if (s.name.Equals("Line")) { middle += "\n" + s.getCode(); }
                else if (s.name.Equals("Polyline")) { middle += "\n" + s.getCode(); }
                else if (s.name.Equals("Polygon")) { middle += "\n" + s.getCode(); }
                else if (s.name.Equals("Path")) { middle += "\n" + s.getCode(); }
                else if (s.name.Equals("Text")) { middle += "\n" + s.getCode(); }
            }
            return start + middle + "\n" + end;
        }
    //---------------------------------------------------------------------------------------------------------------
        //took this mainly from the tutorial -> thank you Mark
        //method to undo previous action -> 'U' command
        static void undoShapeCanvas(List<Shape> Canvas, Caretaker CareUndoRedo)
        {
            //create memento state
            Memento state = new Memento();
            //create shape variable and store last shape in canvas
            Shape shape = Canvas[Canvas.Count - 1];
            //set the state to the last shape
            state.setShape(shape);
            //remove shape in cavas
            Canvas.Remove(shape);
            //then add that state to the caretaker
            CareUndoRedo.addState(state);
            Console.WriteLine(shape.name + " has been removed from canvas");
        }
    //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        //took this mainly from the tutorial -> thank you Mark
        //method to redo previous undo action -> 'R' command
        static void redoShapeCanvas(List<Shape> Canvas, Caretaker CareUndoRedo)
        {
            //create memento variable and get last state in caretaker
            Memento state = CareUndoRedo.getState();
            //create shape variable and store the state
            Shape shape = state.getShape();
            //add shape in the canvas
            Canvas.Add(shape);
            Console.WriteLine(shape.name + " has been added back to the canvas");
        }
    //---------------------------------------------------------------------------------------------------------------
    //---------------------------------------------------------------------------------------------------------------
        //```````` EXTRA CREDIT ````````
        //find user inputs for the custom boundaries
        static string getPoints(string str)
        {
            //make a substring before the first bracket opening
            string shape = "";
            for(int a = 0; a < str.Length; a++) 
            { 
                if(str[a].Equals('(')) 
                { 
                    shape = str.Substring(a + 1); 
                } 
            }
            //finish once the second bracket it done
            shape = shape.Substring(0, shape.Length - 1);
            return shape;
        }
    //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        //edit the style method
        static void updateShape(List<Shape> Canvas, int select)
        {
            //get shape and z index from canvas
            Shape shape = Canvas[select - 1];
            //prompts for each update
            Console.WriteLine("Edit the design of: " + shape.name);
            Console.WriteLine("Current stroke width of shape: " + shape.strokeWidth + "\nPlease input your new stroke width: ");
            //read user input
            shape.strokeWidth = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Current stroke colour of shape: " + shape.stroke + "\nPlease input your new stroke colour: ");
            shape.stroke = Console.ReadLine();
            Console.WriteLine("Current fill colour of shape: " + shape.fill + "\nPlease input your new fill colour: ");
            shape.fill = Console.ReadLine();
            Canvas[select - 1] = shape;
            Console.WriteLine("New style for " + shape.name + ": (Stroke Width=" + shape.strokeWidth + ", Stroke=" + shape.stroke + ", Fill=" + shape.fill + ")");
        }
    //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        //Add text to canvas method
        static void addText(List<Shape> Canvas)
        {
            //let user type whatever they want
            Console.WriteLine("Please enter the text you want: ");
            string text = Console.ReadLine();
            //class name -> will be used to identify which text string users want to edit
            Console.WriteLine("Enter class name for your text (Will be used to identify it if more strings are added): ");
            string name = Console.ReadLine();
            Text xt = new Text(text, name);

            //allow the user to update the style of text
            Console.WriteLine("Would you like to edit your text?(Font/coord/stroke width/stroke colour/fill colour)\nFor Yes: Y \nFor No: N");
            string ans = Console.ReadLine();
            //user is able to upadte the font, x & y coordinate, fill, stroke-width & stroke
            if (ans.Equals("Y") || ans.Equals("y"))
            {
                Shape tempTxt = xt;
                Console.WriteLine("Current font: " + xt.font + "\nPlease input new font: ");
                xt.font = Console.ReadLine();
                Console.WriteLine("Current x co-ordinate: " + xt.x + "\nPlease input new x co-ordinate");
                xt.x = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Current y co-ordinate: " + xt.y + "\nPlease input new y co-ordinate");
                xt.y = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Current stroke width: " + tempTxt.strokeWidth + "\nPlease input new stroke width: ");
                tempTxt.strokeWidth = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Current stroke colour: " + tempTxt.stroke + "\nPlease input new stroke colour: ");
                tempTxt.stroke = Console.ReadLine();
                Console.WriteLine("Current fill colour: " + tempTxt.fill + "\nPlease input new fill colour: ");
                tempTxt.fill = Console.ReadLine();
            }
            //add text inside canvas
            Canvas.Add(xt);
            Console.WriteLine("Text: " + xt.text + ", is added to canvas");
        }
        //```````` EXTRA CREDIT ````````
    }
}        