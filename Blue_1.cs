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
        int k=0;
        string[] t = _input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        string[] res = new string[t.Length];
        string l = "";
        foreach(string w in t){
            if (string.IsNullOrWhiteSpace(w) || string.IsNullOrEmpty(w)) continue;
            if (l.Length==0) {
                l = w;
            }
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
            int p = _output.Length - 1;
            for (int j =0;j < _output.Length; j++){
                r += $"{_output[j]}";
                if (j < p)
                {
                    r += Environment.NewLine;
                }
            }
            if (string.IsNullOrEmpty(r)) return null;
            r = r.TrimEnd();
            return r;
        }


}
}
