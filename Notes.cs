namespace note;

public class Notes
{
    public string Name;
    public string Text;
    public DateTime Data;
    public Notes (string Name, string Text, DateTime Data)
    {
        this.Name = Name;
        this.Text = Text;
        this.Data = Data;
    }
}