using System.Xml;

namespace Lab_8{

public class Blue_2 : Blue
{
    public string Output {get; private set;}
    public string Posled {get; private set;}
    public Blue_2(string input, string posled) : base(input){
        Posled = posled;
        Output = null;
    }
    public override void Review()
    {
        if (string.IsNullOrEmpty(Posled)|| string.IsNullOrEmpty(_input)||string.IsNullOrWhiteSpace(_input))
            {
                Output = null;
                return;
            }
        string[] t = _input.Split(' ');
        string ans= "";
        string probel = "";
        foreach (string w in t){
            if (string.IsNullOrWhiteSpace(w) || string.IsNullOrEmpty(w)) continue;
            if(!w.ToLower().Contains(Posled.ToLower())){
                    ans += probel + w;
                    probel = " ";
                }
            else if(w.Length >0 && char.IsPunctuation(w[w.Length -1])){
                ans+=w[w.Length -1];
                probel = " ";
            }
    }
        Output = ans;
    }
    
    public override string ToString()
    {
        return Output;
    }
}
}
