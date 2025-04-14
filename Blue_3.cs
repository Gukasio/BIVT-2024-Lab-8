using System.ComponentModel;

namespace Lab_8{

public class Blue_3 : Blue
{
    private (char, double)[] _output;
    public (char, double)[] Output{
        get{
            if (_output == null) return null;
            (char,double)[] copy = new (char,double)[_output.Length];
            Array.Copy(_output, copy,_output.Length);
            return copy;
        }
    }
    public Blue_3(string input) : base(input){
        _output = new (char,double)[0];
    }
    public override void Review(){
        if (string.IsNullOrEmpty(_input)) return;
        var t = _input.Split(new[] { ' ', '.', '!', '?', ',', ':', '\"', ';', '–', '(', ')', '[', ']', '{', '}', '/' }, StringSplitOptions.RemoveEmptyEntries);
        if (t.Length == 0) return;
        string bukv = "";
        foreach(string w in t){
            if (w.Length == 0) continue;
            char perv = char.ToLower(w[0]);
            if (!bukv.Contains(perv) && char.IsLetter(perv)) bukv += perv;
        }
        (char l, int k)[] ks = new (char l, int k)[bukv.Length];
        for(int i=0;i<bukv.Length;i++){
            ks[i].l = bukv[i];
            ks[i].k = 0;
        }
        foreach (string w in t){
            char fb = char.ToLower(w[0]);
            for (int i=0;i<bukv.Length;i++){
                if (ks[i].l == fb && char.IsLetter(fb)){
                    ks[i].k++;
                    break;
                }
            }
        }
        int totalVal = 0;
        foreach (var item in ks){
            totalVal += item.k;
        }   
        if (totalVal == 0){
            _output = new (char,double)[0];
            return;
        }
        for (int i=0;i<ks.Length;i++){
            for(int j=0;j<ks.Length - i - 1;j++){
                if ((ks[j].k == ks[j+1].k && ks[j].l > ks[j+1].l) || ks[j].k < ks[j+1].k){
                    (ks[j],ks[j+1])=(ks[j+1],ks[j]);
                }
            }
        }
        (char, double)[] ans = new (char, double)[ks.Length];
        for(int i =0;i<ks.Length;i++){
            ans[i] = (ks[i].l, ks[i].k / (double)totalVal * 100);
        }
        _output = ans;
    }
        public override string ToString()
        {
            string ans = "";
            foreach(var el in _output)
            {
                ans += $"{el.Item1} - {el.Item2:f4}\n";
            }
            return ans.TrimEnd('\n');
        }

    }
}
