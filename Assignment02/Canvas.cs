/*
A lot of my code doesn't have any comments, this is due to me working on one shape, and then copy and pasting for the rest of shapes, apart from minor adjustments
*/
using System;
using System.Collections.Generic;
using System.IO;
namespace Assignment2
{
    //main program class
    //going to have my menu/have my option methods(delete/update/swap)
    class Canvas
    {
        public static void Main(string[] args)
        {
            //my list of commands
            //explaining to the user how to use my code
            Console.WriteLine("\nWelcome to Lauren's Shape Generator!\n");
            Console.WriteLine("The menu is designed to walk you through the process step by step \nJust follow the instructions on screen and you'll be good to go!");
            Console.WriteLine("\nPlease enter a shape to start! \n 'Rect' -> Rectangle \n 'Circ' -> Circle \n 'Elli' -> Ellipse \n 'Line' -> Line \n 'PolyL' -> Polyline \n 'PolyG' -> Polygon \n 'Path' -> Path");
            
            //for lists
            //https://www.geeksforgeeks.org/linked-list-implementation-in-c-sharp/#:~:text=In%20C%23%2C%20LinkedList%20is%20the,backward%20to%20the%20Previous%20node.
            LinkedList<Shape> shapes = new LinkedList<Shape>();
            string ans = "";
            //storing the z index
            int pos = 1;
            string svg = "";
            //if true -> keep loop user is not done yet
            bool cont = true;
            //loop that keeps going through asking the user if they want to add shapes
            //stop when the user is done
            while (cont)
            {
                Shape tempShape = new Shape();
                string inp = Console.ReadLine();
                //stop loop when user is finished
                if(String.IsNullOrEmpty(inp))
                { 
                    cont = false;
                }
                else
                {
                    inp = inp.ToLower();
                    inp = inp.Substring(0, 1).ToUpper() + inp.Substring(1);

                    //rectangle
                    if(inp.Equals("Rect"))
                    {
                        Console.WriteLine("Set Boundaries for Rectangle: ");
                        Console.WriteLine("Please insert digit for 'X' coords");
                        int x = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Please insert digit for 'Y' coords");
                        int y = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Please insert digit for the 'Width'");
                        int w = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Please insert digit for the 'Height'");
                        int h = Convert.ToInt32(Console.ReadLine());
                        //adding the shape with the parameters to the list
                        tempShape.rectangle(inp, x, y, w, h, pos++);
                        shapes.AddFirst(tempShape);
                    }
                    //circle
                    else if(inp.Equals("Circ"))
                    {
                        Console.WriteLine("Set Boundaries for Circle: ");
                        Console.WriteLine("Please insert digit for the 'Radius'");
                        int r = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Please insert digit for 'X' coords");
                        int x = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Please insert digit for 'Y'");
                        int y = Convert.ToInt32(Console.ReadLine());
                        //adding the shape with the parameters to the list
                        tempShape.circle(inp, r, x, y, pos++);
                        shapes.AddFirst(tempShape);
                    }
                    //ellipse
                    else if(inp.Equals("Elli"))
                    {
                        Console.WriteLine("Set boundaries for Ellipse: ");
                        Console.WriteLine("Please insert digit for 'X Radius'");
                        int rx = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Please insert digit for 'Y Radius'");
                        int ry = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Please insert digit for the 'X of the Ellipse Center'");
                        int cx = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Please insert digit for the 'Y of the Ellipse Center'");
                        int cy = Convert.ToInt32(Console.ReadLine());
                        //adding the shape with the parameters to the list
                        tempShape.ellipse(inp, rx, ry, cx, cy, pos++);
                        shapes.AddFirst(tempShape);
                    }
                    //line
                    else if(inp.Equals("Line"))
                    {
                        Console.WriteLine("Set boundaries for Line: ");                 
                        Console.WriteLine("Please insert the digit for the 'X coord for Point 1'");
                        int x1 = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Please insert the digit for the 'Y coord for Point 1'");
                        int y1 = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Please insert the digit for the 'X coord for Point 2'");
                        int x2 = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Please insert the digit for the 'Y coord for Point 2'");
                        int y2 = Convert.ToInt32(Console.ReadLine());
                        //adding the shape with the parameters to the list
                        tempShape.line(inp, x1, y1, x2, y2, pos++);
                        shapes.AddFirst(tempShape);
                    }
                    //polyline
                    else if(inp.Equals("PolyL"))
                    {
                        Console.WriteLine("Set boundaries for PolyLine: ");
                        Console.WriteLine("Please insert the digits for the coords of the PolyLine");
                        //read in the different digits for the polyline
                        string coord = Console.ReadLine();
                        //adding the shape with the parameters to the list
                        tempShape.poly(inp, coord, pos++);
                        shapes.AddFirst(tempShape);
                    }
                    //polygon
                    else if(inp.Equals("PolyG"))
                    {
                        Console.WriteLine("Set boundaries for PolyGon: ");
                        Console.WriteLine("Please insert the digits for the coords of the PolyGon");
                        //read in the different digits for the polygon
                        string coord = Console.ReadLine();
                        //adding the shape with the parameters to the list
                        tempShape.poly(inp, coord, pos++);
                        shapes.AddFirst(tempShape);
                    }
                    //path
                    else if(inp.Equals("Path"))
                    {
                        Console.WriteLine("Set boundaries for Path: ");
                        Console.WriteLine("Commands: ");
                        Console.WriteLine("'M' -> Move to -> M 30 40 \n'L' -> Line to -> L 120 140 \n'V' -> Vertical Line to -> V 30 50 \n'H' -> Horizontal Line to -> H 20 60 \n'C' Curve to -> 50 100 \n'Q' Quadratic curve -> Q 20 120 \n'E' -> Elliptical arc -> E 30 10 \n'F' Finish path");
                        //read in the different digits for the polygon
                        string coord = Console.ReadLine();
                        //adding the shape with the parameters to the list
                        tempShape.poly(inp, coord, pos++);
                        shapes.AddFirst(tempShape);
                    }
                    //if the user doesnt input a correct value
                    else
                    {
                        Console.WriteLine("Invalid Input \nTry Again"); 
                    }

                    Console.WriteLine("Press Enter When Finished");
                }
                inp = "";
            }

//--------------------------------------------------------------------------------------------------------------------------------------------------------
            //this section focuses on the menu for swapping shape positions
//--------------------------------------------------------------------------------------------------------------------------------------------------------
            
            //swapping positions of shapes based on their z index
            Console.Clear();
            cont = true;
            Console.WriteLine("List of created shapes: ");
            foreach(Shape s in shapes) 
            { 
                s.getShape(); 
            }

            Console.WriteLine("Would you like to swap the position");
            Console.WriteLine("Enter the letter 'Y' to update shapes position \nEnter the letter 'N' to not update shape position");
            ans = Console.ReadLine().ToUpper();
            if(ans.Equals("Y"))
            {
                //loop that keeps going through asking the user if they want to update or delete shapes
                //stop when the user is done
                while (cont)
                {
                    Console.WriteLine("Please select the index of the shapes you'd like to swap");
                    Console.WriteLine("Enter the index of the first shape");
                    int indOne = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter the index of the second shape");
                    int indTwo = Convert.ToInt32(Console.ReadLine());
                    swapPositions(shapes, indOne, indTwo);
                    Console.WriteLine("Updated shape list:");
                    foreach(Shape s in shapes) 
                    { 
                        s.getShape(); 
                    }

                    Console.WriteLine("Would you like to update the position of two shapes? \nTo continue press '1' then press the 'Enter' key");
                    Console.WriteLine("If you are done updating the position please press the 'Enter' key");
                    if(String.IsNullOrEmpty(Console.ReadLine())) 
                    { 
                        cont = false; 
                    }
                }
            }

//--------------------------------------------------------------------------------------------------------------------------------------------------------
            //this section focuses on the menu for updating and deleting created shapes
//--------------------------------------------------------------------------------------------------------------------------------------------------------            

            //if the user wants to update or delete any of the created shapes
            Console.Clear();
            cont = true;
            //ask user if they would like to update or delete shapes in list
            Console.WriteLine("Would you like to delete or update any shapes? \nPlease type 'Y' for yes and 'N' for no");
            ans = "";
            ans = Console.ReadLine().ToUpper();
            if(ans.Equals("Y"))
            {
                //loop that keeps going through asking the user if they want to update or delete shapes
                //stop when the user is done
                while (cont)
                {
                    Console.WriteLine("Please select the index of the shape you'd like to delete or update");
                    foreach(Shape s in shapes) 
                    { 
                        s.getShape(); 
                    }

                    int index = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Use 'D' for Delete \nUse 'U' for Update");
                    string res = Console.ReadLine();
                    if(res.Equals("D") || res.Equals("d")) 
                    { 
                        deleteShape(shapes, index); 
                    }
                    else
                    { 
                        updateList(shapes, index); 
                    }
                    svg = createSVG(shapes);

                    Console.WriteLine("Would you like to delete or update another shape? \n Press '1' then 'Enter' to continue");
                    Console.WriteLine("If you are done deleting or updating please press the 'Enter' key");
                    if(String.IsNullOrEmpty(Console.ReadLine())) 
                    { 
                        cont = false; 
                    }
                }
            }
            else
            {
                svg = createSVG(shapes);
            }

            Console.Clear();
            //print out the SVG
            File.WriteAllText("Shape.svg", svg);
            Console.WriteLine("Your SVG File: " + "\n" + svg + "\nYour SVG file is saved as Shape.svg");
        }

//--------------------------------------------------------------------------------------------------------------------------------------------------------
            //this section focuses on the methods for creating an svg file
//--------------------------------------------------------------------------------------------------------------------------------------------------------

        //create SVG file method
        public static string createSVG(LinkedList<Shape> shape)
        {
            //got the info for this line here
            //https://www.w3.org/TR/SVG2/shapes.html
            string start = "<svg width=\"300\" height=\"300\" version=\"1.1\" xmlns=\"http://www.w3.org/2000/svg\">";
            string middle = "";
            string end = "</svg>";
            foreach (Shape s in shape)
            {
                if (s.getName().Equals("Rect")) 
                { 
                    middle += "\n" + s.getRectangle();
                }
                else if (s.getName().Equals("Circ")) 
                { 
                    middle += "\n" + s.getCircle(); 
                }
                else if (s.getName().Equals("Elli")) 
                { 
                    middle += "\n" + s.getEllipse(); 
                }
                else if (s.getName().Equals("Line")) 
                { 
                    middle += "\n" + s.getLine(); 
                }
                else if (s.getName().Equals("PolyL")) 
                { 
                    middle += "\n" + s.getPolyline(); 
                }
                else if (s.getName().Equals("PolyG")) 
                { 
                    middle += "\n" + s.getPolygon(); 
                }
                else if (s.getName().Equals("Path")) 
                { 
                    middle += "\n" + s.getPath(); 
                }
            }
            return start + middle + "\n" + end;
        }

//--------------------------------------------------------------------------------------------------------------------------------------------------------
            //this section focuses on the methods for swapping shapes positions
//--------------------------------------------------------------------------------------------------------------------------------------------------------

        public static void swapPositions(LinkedList<Shape> shape, int x, int y)
        {
            //kinda just messed around with the maths for this part until i got it right
            int pos = 0;
            Shape[] temp = new Shape[shape.Count];
            foreach(Shape s in shape) 
            { 
                temp[pos++] = s; 
            }
            Shape tempShape = temp[temp.Length - x];
            temp[temp.Length - x] = temp[temp.Length - y];
            temp[temp.Length - y] = tempShape;
            temp[temp.Length - x].setIndex(x);
            temp[temp.Length - y].setIndex(y);
            shape.Clear();
            for(int i = 0; i < temp.Length; i++) 
            {
                shape.AddLast(temp[i]);
            }    
        }

//--------------------------------------------------------------------------------------------------------------------------------------------------------
            //this section focuses on the methods for deleting shapes
//--------------------------------------------------------------------------------------------------------------------------------------------------------

        public static void deleteShape(LinkedList<Shape> shape, int index)
        {
            Shape temp = new Shape();
            foreach(Shape s in shape)
            {
                if(index == s.getIndex()) 
                { 
                    temp = s; 
                }
            }
            shape.Remove(temp);
        }

//--------------------------------------------------------------------------------------------------------------------------------------------------------
            //this section focuses on the methods for updating shapes
//--------------------------------------------------------------------------------------------------------------------------------------------------------

        public static void updateList(LinkedList<Shape> shape, int index)
        {
            foreach(Shape s in shape)
            {
                if (index == s.getIndex())
                {
                    Console.WriteLine("Current Value: ");
                    if(s.getName().Equals("Rect"))
                    {
                        Console.WriteLine("'X' Value: " + s.getX1() + "\n'Y' Value: " + s.getY1() + "\n'Width' Value: " + s.getX2() + "\n'Height' Value: " + s.getY2() + "\n'Stroke Width Value: " + s.getStokeWidth() + "\nFill Colour Value: " + s.getFill() + "\nstroke value: " + s.getStroke() + "\n");
                        Console.WriteLine("Enter new 'X' value: ");
                        s.setX1(Convert.ToInt32(Console.ReadLine()));
                        Console.WriteLine("Enter new 'Y' value:");
                        s.setY1(Convert.ToInt32(Console.ReadLine()));
                        Console.WriteLine("Enter new 'Width' value:");
                        s.setX2(Convert.ToInt32(Console.ReadLine()));
                        Console.WriteLine("Enter new 'Height' value: ");
                        s.setY2(Convert.ToInt32(Console.ReadLine()));
                        Console.WriteLine("Enter new 'Stroke Width' value: ");
                        s.setStrokeWidth(Convert.ToInt32(Console.ReadLine()));
                        Console.WriteLine("Enter new 'Colour Fill': ");
                        s.setFill(Console.ReadLine());
                        Console.WriteLine("Enter new 'Stroke Colour'");
                        s.setStroke(Console.ReadLine());
                    }
                    else if(s.getName().Equals("Circ"))
                    {
                        Console.WriteLine("'X' Value: " + s.getX1() + "\n'Y' Value: " + s.getY1() + "\n'Radius' Value: " + s.getRad() + "\n'Stroke Width Value: " + s.getStokeWidth() + "\nFill Colour Value: " + s.getFill() + "\nstroke value: " + s.getStroke());
                        Console.WriteLine("Enter new 'X' value: ");
                        s.setX1(Convert.ToInt32(Console.ReadLine()));
                        Console.WriteLine("Enter new 'Y' value: ");
                        s.setY1(Convert.ToInt32(Console.ReadLine()));
                        Console.WriteLine("Enter new 'Radius' value: ");
                        s.setRad(Convert.ToInt32(Console.ReadLine()));
                        Console.WriteLine("Enter new 'Stroke Width' value: ");
                        s.setStrokeWidth(Convert.ToInt32(Console.ReadLine()));
                        Console.WriteLine("Enter new 'Fill Colour': ");
                        s.setFill(Console.ReadLine());
                        Console.WriteLine("Enter new 'Stroke Colour'");
                        s.setStroke(Console.ReadLine());
                    }
                    else if (s.getName().Equals("Elli"))
                    {
                        Console.WriteLine("'X' Value: " + s.getX1() + "\n'Y' Value: " + s.getY1() + "\n'Center X' Value: " + s.getX2() + "\n'Center Y' Value: " + s.getY2() + "\n'Stroke Width Value: " + s.getStokeWidth() + "\nFill Colour Value: " + s.getFill() + "\nstroke value: " + s.getStroke());
                        Console.WriteLine("Enter new 'X' value: ");
                        s.setX1(Convert.ToInt32(Console.ReadLine()));
                        Console.WriteLine("Enter new 'Y' value: ");
                        s.setY1(Convert.ToInt32(Console.ReadLine()));
                        Console.WriteLine("Enter 'Second X' value: ");
                        s.setX2(Convert.ToInt32(Console.ReadLine()));
                        Console.WriteLine("Enter 'Second Y' value: ");
                        s.setY2(Convert.ToInt32(Console.ReadLine()));
                        Console.WriteLine("Enter new 'Stroke Width' value: ");
                        s.setStrokeWidth(Convert.ToInt32(Console.ReadLine()));
                        Console.WriteLine("Enter new 'Fill Colour': ");
                        s.setFill(Console.ReadLine());
                        Console.WriteLine("Enter new 'Stroke Colour'");
                        s.setStroke(Console.ReadLine());
                    }
                    else if (s.getName().Equals("Line"))
                    {
                        Console.WriteLine("'X' Value: " + s.getX1() + "\n'Y' Value: " + s.getY1() + "\n'Second X' Value: " + s.getX2() + "\n'Second Y' Value: " + s.getY2() + "\n'Stroke Width Value: " + s.getStokeWidth() + "\nFill Colour Value: " + s.getFill() + "\nstroke value: " + s.getStroke());
                        Console.WriteLine("Enter new 'X' value: ");
                        s.setX1(Convert.ToInt32(Console.ReadLine()));
                        Console.WriteLine("Enter new 'Y' value: ");
                        s.setY1(Convert.ToInt32(Console.ReadLine()));
                        Console.WriteLine("Enter 'Second X' value: ");
                        s.setX2(Convert.ToInt32(Console.ReadLine()));
                        Console.WriteLine("Enter 'Second Y' value: ");
                        s.setY2(Convert.ToInt32(Console.ReadLine()));
                        Console.WriteLine("nter new 'Stroke Width' value: ");
                        s.setStrokeWidth(Convert.ToInt32(Console.ReadLine()));
                        Console.WriteLine("Enter new 'Fill Colour': ");
                        s.setFill(Console.ReadLine());
                        Console.WriteLine("Enter new 'Stroke Colour'");
                        s.setStroke(Console.ReadLine());
                    }    
                    else if (s.getName().Equals("PolyL"))
                    {
                        Console.WriteLine("Points: " + s.getCoord() + "\nStroke Width Value: " + s.getStokeWidth() + "\nFill Colour Value: " + s.getFill() + "\nStroke Value: " + s.getStroke());
                        Console.WriteLine("Enter new 'Point' value: ");
                        s.setCoord(Console.ReadLine());
                        Console.WriteLine("Enter new 'Stroke Width' value: ");
                        s.setStrokeWidth(Convert.ToInt32(Console.ReadLine()));
                        Console.WriteLine("Enter new 'Fill Colour': ");
                        s.setFill(Console.ReadLine());
                        Console.WriteLine("Enter new 'Stroke Colour'");
                        s.setStroke(Console.ReadLine());
                    }
                    else if (s.getName().Equals("PolyGon"))
                    {
                        Console.WriteLine("Points: " + s.getCoord() + "\nStroke Width Value: " + s.getStokeWidth() + "\nFill Colour Value: " + s.getFill() + "\nStroke Value: " + s.getStroke());
                        Console.WriteLine("Enter new 'Point' value: ");
                        s.setCoord(Console.ReadLine());
                        Console.WriteLine("Enter new 'Stroke Width' value: ");
                        s.setStrokeWidth(Convert.ToInt32(Console.ReadLine()));
                        Console.WriteLine("Enter new 'Fill Colour': ");
                        s.setFill(Console.ReadLine());
                        Console.WriteLine("Enter new 'Stroke Colour'");
                        s.setStroke(Console.ReadLine());
                    }
                    else if (s.getName().Equals("Path"))
                    {
                        Console.WriteLine("'D' Value': " + s.getCoord() + "\nStroke Width Value: " + s.getStokeWidth() + "\nFill Colour Value: " + s.getFill() + "\nStroke Value: " + s.getStroke());
                        Console.WriteLine("Enter new 'Point' value: ");
                        s.setCoord(Console.ReadLine());
                        Console.WriteLine("Stroke Width' value: ");
                        s.setStrokeWidth(Convert.ToInt32(Console.ReadLine()));
                        Console.WriteLine("Enter new 'Fill Colour': ");
                        s.setFill(Console.ReadLine());
                        Console.WriteLine("Enter new 'Stroke Colour'");
                        s.setStroke(Console.ReadLine());
                    }
                }
            }
        }
    }

//--------------------------------------------------------------------------------------------------------------------------------------------------------
            //this section focuses on the Shape class
//--------------------------------------------------------------------------------------------------------------------------------------------------------    

    //my shape class -> this will handle all the shape parameters
    class Shape
    {
        private string name;
        private int index;
        //used in circle, ellipse and line
        private int x1;
        //used in circle, ellipse and line
        private int y1;
        //used in ellipse and line
        private int x2;
        //used in ellipse and line
        private int y2;
        private int rad;
        private string coord;
        private int strokeWidth;
        private string stroke;
        private string fill;

        //each shape method
        public void rectangle(string name, int x, int y, int w, int h, int i)
        {
            this.name = name;
            this.index = i;
            this.x1 = x;
            this.y1 = y;
            this.x2 = w;
            this.y2 = h;
            this.strokeWidth = 1;
            this.stroke = "black";
            this.fill = "black";
        }
        public void circle(string name, int r, int x, int y, int i)
        {
            this.name = name;
            this.index = i;
            this.x1 = x;
            this.y1 = y;
            this.rad = r;
            this.strokeWidth = 1;
            this.stroke = "black";
            this.fill = "black";
        }
        public void ellipse(string name, int radX, int radY, int x, int y, int i)
        {
            this.name = name;
            this.index = i;
            this.x1 = radX;
            this.y1 = radY;
            this.x2 = x;
            this.y2 = y;
            this.strokeWidth = 1;
            this.stroke = "black";
            this.fill = "black";
        }
        public void line(string name, int a, int b, int c, int d, int i)
        {
            this.name = name;
            this.index = i;
            this.x1 = a;
            this.y1 = b;
            this.x2 = c;
            this.y2 = d;
            this.strokeWidth = 1;
            this.stroke = "black";
            this.fill = "black";
        }
        public void poly(string name, string s, int i)
        {
            this.name = name;
            this.index = i;
            this.coord = s;
            this.strokeWidth = 1;
            this.stroke = "black";
            this.fill = "black";
        }
        //print out z index and shape
        public void getShape()
        {
            Console.WriteLine("Index: " + this.index + ", Name: " + this.name);
        }

        //getters and setters
        public void setName(String n) { this.name = n; }
        public void setIndex(int i) { this.index = i; }
        public void setX1(int x) { this.x1 = x; }
        public void setY1(int y) { this.y1 = y; }
        public void setX2(int x) { this.x2 = x; }
        public void setY2(int y) { this.y2 = y; }
        public void setRad(int r) { this.rad = r; }
        public void setCoord(string s) { this.coord = s; }
        public void setStrokeWidth(int w) { this.strokeWidth = w; }
        public void setFill(string f) { this.fill = f; }
        public void setStroke(string s) { this.stroke = s; }
        public string getName() { return this.name; }
        public int getIndex() { return this.index; }
        public int getX1() { return this.x1; }
        public int getY1() { return this.y1; }
        public int getX2() { return this.x2; }
        public int getY2() { return this.y2; }
        public int getRad() { return this.rad; }
        public string getCoord() { return this.coord; }
        public int getStokeWidth() { return this.strokeWidth; }
        public string getFill() { return this.fill; }
        public string getStroke() { return this.stroke; }

        //method allows to fill in appropriate line for SVG file
        public string getRectangle()
        {
            return "    <rect x=\"" + this.x1 + "\" y=\"" + this.y1 + "\" width=\"" + this.x2 + "\" height=\"" + this.y2 + "\" fill=\"" + this.fill + "\" stroke=\"" + this.stroke + "\" stroke-width=\"" + this.strokeWidth + "\"/>";
        }
        public string getCircle()
        {
            return "    <circle cx=\"" + this.x1 + "\" cy=\"" + this.y1 + "\" r=\"" + this.rad + "\" fill=\"" + this.fill + "\" stroke=\"" + this.stroke + "\" stroke-width=\"" + this.strokeWidth + "\"/>";
        }
        public string getEllipse()
        {
            return "    <ellipse cx=\"" + this.x1 + "\" cy=\"" + this.y1 + "\" rx=\"" + this.x2 + "\" ry=\"" + this.y2 + "\" fill=\"" + this.fill + "\" stroke=\"" + this.stroke + "\" stroke-width=\"" + this.strokeWidth + "\"/>";
        }
        public string getLine()
        {
            return "    <line x1=\"" + this.x1 + "\" y1=\"" + this.y1 + "\" x2=\"" + this.x2 + "\" y2=\"" + this.y2 + "\" fill=\"" + this.fill + "\" stroke=\"" + this.stroke + "\" stroke-width=\"" + this.strokeWidth + "\"/>";
        }
        public string getPolyline()
        {
            return "    <polyline fill=\"" + this.fill + "\" stroke=\"" + this.stroke + "\" stroke-width=\"" + this.strokeWidth + "\" points=\"" + this.coord + "\"/>";
        }
        public string getPolygon()
        {
            return "    <polygon fill=\"" + this.fill + "\" stroke=\"" + this.stroke + "\" stroke-width=\"" + this.strokeWidth + "\" points=\"" + this.coord + "\"/>";
        }
        public string getPath()
        {
            return "    <path d=\"" + this.coord + "\" fill=\"" + this.fill + "\" stroke=\"" + this.stroke + "\" stroke-width=\"" + this.strokeWidth + "\"/>";
        }
    }
}            
