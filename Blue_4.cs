namespace Lab_8{

public class Blue_4 : Blue
{
    private int _output;
    public int Output => _output;
    public Blue_4(string input) : base(input){
        _output = 0;
    }
    public override void Review(){
        if (string.IsNullOrEmpty(_input)) return;
        int neg;
        string[] t = _input.Split(new[] { ' ', ',', '/' }, StringSplitOptions.RemoveEmptyEntries);
        foreach (string w in t){
            if (string.IsNullOrWhiteSpace(w) || string.IsNullOrEmpty(w)) continue;
            if(char.IsDigit(w[0]) || w.Length >= 2 && char.IsDigit(w[1]) && w[0]=='-'){
                if (w[0] == '-'){
                    neg = -1;
                }
                else{
                    neg = 1;
                }
                int s =0;
                foreach (char l in w){
                    if (char.IsDigit(l)){
                        s = s * 10 +(l-'0');
                    }
                }
                s*=neg;
                _output += s;
            }
        }
    }
    public override string ToString()
    {
        return $"{_output}";
    }
}
}
