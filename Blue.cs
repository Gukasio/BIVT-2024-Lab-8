namespace Lab_8{

public abstract class Blue
{
    protected string _input;
    public string Input => _input;
    public Blue(string input){
        _input = input;
    }
    public abstract void Review();
}
}
