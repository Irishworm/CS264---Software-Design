namespace Assignment03Single
{
    //Mainly copied and pasted from previous assignment
    //learned from mistakes of last assignment
    //main changes were to make solution more object oriented
    //parent class called shape

    /*
    HI DEM
    unfortunately i was unable to split the shapes into different files,
    this was as much splitting as i could do, any further splitting up files cause my code to break
    so apologies, i tried to make it as easy to read as possible
    */
public abstract class Shape
    {
        //shape class variables
        public string name { get; set; }
        public int strokeWidth { get; set; }
        public string stroke { get; set; }
        public string fill { get; set; }
        //getCode() returns the svg for each shape
        public virtual string getCode() { return ""; }
    }
//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
    //inheriting from shape
    class Rectangle : Shape
    {
        public int x { get; set; }
        public int y { get; set; }
        public int w { get; set; }
        public int h { get; set; }

        public Rectangle()
        {
            var rd = new Random();
            //convert to in int
            Func<int> RdIntString = () => rd.Next(100);
            x = RdIntString();
            y = RdIntString();
            w = RdIntString();
            h = RdIntString();
        }

        public Rectangle(int x, int y, int w, int h)
        {
            this.name = "Rectangle";
            this.x = x;
            this.y = y;
            this.w = w;
            this.h = h;
            this.strokeWidth = 1;
            this.stroke = "black";
            this.fill = "pink";
        }
        public override string getCode()
        {
            return "    <rect x=\"" + this.x + "\" y=\"" + this.y + "\" width=\"" + this.w + "\" height=\"" + this.h + "\" fill=\"" + this.fill + "\" stroke=\"" + this.stroke + "\" stroke-width=\"" + this.strokeWidth + "\"/>";
        }
    }
//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
    class Circle : Shape
    {
        public int cx { get; set; }
        public int cy { get; set; }
        public int rad { get; set; }
        public Circle()
        {
            var rd = new Random();
            //convert to in int
            Func<int> RdIntString = () => rd.Next(100);
            cx = RdIntString();
            cy = RdIntString();
            rad = RdIntString();
        }
        public Circle (int x, int y, int r)
        {
            this.name = "Circle";
            this.cx = x;
            this.cy = y;
            this.rad = r;
            this.strokeWidth = 1;
            this.stroke = "black";
            this.fill = "pink";
        }
        public override string getCode()
        {
            return "    <circle cx=\"" + this.cx + "\" cy=\"" + this.cy + "\" r=\"" + this.rad + "\" fill=\"" + this.fill + "\" stroke=\"" + this.stroke + "\" stroke-width=\"" + this.strokeWidth + "\"/>";
        }
    }
//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
    class Ellipse : Shape
    {
        public int cx { get; set; }
        public int cy { get; set; }
        public int rx { get; set; }
        public int ry { get; set; }
        public Ellipse()
        {
            var rd = new Random();
            //convert to in int
            Func<int> RdIntString = () => rd.Next(100);
            cx = RdIntString();
            cy = RdIntString();
            rx = RdIntString();
            ry = RdIntString();
        }
        public Ellipse(int x, int y, int r1, int r2)
        {
            this.name = "Ellipse";
            this.cx = x;
            this.cy = y;
            this.rx = r1;
            this.ry = 250;
            this.strokeWidth = 1;
            this.stroke = "black";
            this.fill = "pink";
        }
        public override string getCode()
        {
            return "    <ellipse cx=\"" + this.cx + "\" cy=\"" + this.cy + "\" rx=\"" + this.rx + "\" ry=\"" + this.ry + "\" fill=\"" + this.fill + "\" stroke=\"" + this.stroke + "\" stroke-width=\"" + this.strokeWidth + "\"/>";
        }
    }
//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
    class Line : Shape
    {
        public int x1 { get; set; }
        public int y1 { get; set; }
        public int x2 { get; set; }
        public int y2 { get; set; }
        public Line()
        {
            var rd = new Random();
            //convert to in int
            Func<int> RdIntString = () => rd.Next(100);
            x1 = RdIntString();
            y1 = RdIntString();
            x2 = RdIntString();
            y2 = RdIntString();
        }
        public Line(int x, int y, int a, int b)
        {
            this.name = "Line";
            this.x1 = x;
            this.y1 = y;
            this.x2 = a;
            this.y2 = b;
            this.strokeWidth = 1;
            this.stroke = "black";
            this.fill = "pink";
        }
        public override string getCode()
        {
            return "    <line x1=\"" + this.x1 + "\" y1=\"" + this.y1 + "\" x2=\"" + this.x2 + "\" y2=\"" + this.y2 + "\" fill=\"" + this.fill + "\" stroke=\"" + this.stroke + "\" stroke-width=\"" + this.strokeWidth + "\"/>";
        }
    }
//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
    class Polyline : Shape
    {
        public string coord { get; set; }
        public Polyline()
        {
            var rd = new Random();
            //convert to in int
            Func<int> RdIntString = () => rd.Next(100);
            //coord = RdIntString();
        }
        public Polyline(string coord)
        {
            this.name = "Polyline";
            this.coord = coord;
            this.strokeWidth = 1;
            this.stroke = "black";
            this.fill = "pink";
        }
        public override string getCode()
        {
            return "    <polyline fill=\"" + this.fill + "\" stroke=\"" + this.stroke + "\" stroke-width=\"" + this.strokeWidth + "\" points=\"" + this.coord + "\"/>";
        }
    }
//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
    class Polygon : Shape
    {
        public string coord { get; set; }
        public Polygon()
        {
            var rd = new Random();
            //convert to in int
            Func<int> RdIntString = () => rd.Next(100);
            //coord = RdIntString();
        }
        public Polygon(string coord)
        {
            this.name = "Polygon";
            this.coord = coord;
            this.strokeWidth = 1;
            this.stroke = "black";
            this.fill = "pink";
        }
        public override string getCode()
        {
            return "    <polygon fill=\"" + this.fill + "\" stroke=\"" + this.stroke + "\" stroke-width=\"" + this.strokeWidth + "\" points=\"" + this.coord + "\"/>";
        }
    }
//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
    class Path : Shape
    {
        public string coord { get; set; }
        public Path()
        {
            var rd = new Random();
            //convert to in int
            Func<int> RdIntString = () => rd.Next(100);
            //coord = RdIntString();
        }
        public Path(string coord)
        {
            this.name = "Path";
            this.coord = coord;
            this.strokeWidth = 1;
            this.stroke = "black";
            this.fill = "pink";
        }
        public override string getCode()
        {
            return "    <path fill=\"" + this.fill + "\" stroke=\"" + this.stroke + "\" stroke-width=\"" + this.strokeWidth + "\" d=\"" + this.coord + "\"/>";
        }
    }
//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
    //```````` EXTRA CREDIT ````````
    class Text : Shape
    {
        public string font { get; set; }
        public string text { get; set; }
        public string className { get; set; }
        public int x { get; set; }
        public int y { get; set; }
        public Text()
        {
            
        }
        public Text(string s, string c)
        {
            this.name = "Text";
            this.text = s;
            this.className = c;
            this.x = 65;
            this.y = 55;
            this.font = "italic 15px serif";
            this.fill = "cadetblue";
            this.stroke = "grey";
            this.strokeWidth = 1;
        }
        public override string getCode()
        {
            string s1 = "";
            s1 = "    <style>";
            s1 += "\n      ." + this.className + " { font: " + this.font + "; fill: " + this.fill + "; stroke: " + this.stroke + "; stroke-width: " + this.strokeWidth + "; }";
            s1 += "\n    </style>";
            s1 += "\n    <text x=\"" + this.x + "\" y=\"" + this.y + "\" class=\"" + this.className + "\">" + this.text + "</text>";
            return s1;
        }
    }
    //```````` EXTRA CREDIT ````````
}