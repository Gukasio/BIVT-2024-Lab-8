using System.Xml;

namespace Lab_8{

public class Blue_2 : Blue
{
    private string _output;
    private string _posl;
    public string Output => _output;
    public Blue_2(string input, string posl) : base(input){
        _posl = posl;
        _output = null;
    }
    public override void Review()
    {
        if (string.IsNullOrEmpty(_posl)|| string.IsNullOrEmpty(_input))
            {
                _output = string.Empty;
                return;
            }
        string[] t = _input.Split(' ');
        string ans= "";
        string probel = "";
        foreach (string w in t){
            if (string.IsNullOrWhiteSpace(w) || string.IsNullOrEmpty(w)) continue;
            if(!w.ToLower().Contains(_posl.ToLower())){
                    ans += probel + w;
                    probel = " ";
                }
            else if (w.Length > 0 && !(char.IsLetter(w[0]))){
                ans += " " + w[0] + w[0];
                probel = " ";
            }
            if (w.Length >0 && w.ToLower().Contains(_posl.ToLower()) && !(char.IsLetter(w[w.Length -1]))){
                ans+=w[w.Length -1];
                probel = " ";
            }
    }
        _output = ans;
    }
    
    public override string ToString()
    {
        if (string.IsNullOrEmpty(_output)|| _output.Length == 0) return string.Empty;
        return _output;
    }
}
}
