namespace Assignment03Single
{
    //Memento Design Pattern
    //took this mainly from the tutorial -> thank you Mark
    public class Memento
    {
        Shape shape;
        public Shape getShape()
        {
            return this.shape;
        }
        public void setShape(Shape s)
        {
            this.shape = s;
        }
    }
}