namespace Lab_8{

public class Blue_1 : Blue
{
    private string[] _output;
    public string[] Output => _output;
    public Blue_1(string input) : base(input){
        _output = null;
    }
    public override void Review(){
        if (_input == null) return;
        string[] t = _input.Split(' ');
        string[] res = new string[t.Length];
        int k=0;
        string l = "";
        foreach(string w in t){
            if (string.IsNullOrWhiteSpace(w)) continue;
            if (l.Length==0) l = w;
            else if (l.Length + w.Length + 1 <=50){
                l += " " + w;
            }
            else{
                res[k++] = l;
                l= w;
            }
        }
        if (!string.IsNullOrEmpty(l)){
            res[k++]= l;
        }
        _output = new string[k];
        Array.Copy(res,_output,k);
    }
        public override string ToString()
        {
            if (_output == null) return null;
            string r = "";
            foreach (string ri in _output){
                r += $"{ri}\n";
            }
            if (string.IsNullOrEmpty(r)) return null;
            r = r.Remove(r.Length-1, 1);
            return r;
        }


}
}
