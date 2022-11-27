namespace Assignment03Single
{
    //caretaker is used to store memento inside in
    //took this mainly from the tutorial -> thank you Mark
    //https://www.dofactory.com/net/memento-design-pattern
    public class Caretaker
    {
        List<Memento> CareUndoRedo = new List<Memento>();
        Memento state = new Memento();
        public Memento getState()
        {
            this.state = this.CareUndoRedo[CareUndoRedo.Count-1];
            this.CareUndoRedo.RemoveAt(CareUndoRedo.Count - 1);
            return this.state;
        }
        public void addState(Memento m)
        {
            this.state = m;
            this.CareUndoRedo.Add(state);
        }
        public int getSize() 
        { 
            return this.CareUndoRedo.Count; 
        }
    }
}