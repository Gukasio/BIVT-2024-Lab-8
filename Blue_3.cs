using System.ComponentModel;

namespace Lab_8{

public class Blue_3 : Blue
{
    private (char, double)[] _output;
    public (char, double)[] Output{
        get{
            if (_output == null) return null;
            (char,double)[] c = new (char,double)[_output.Length];
            Array.Copy(_output, c,_output.Length);
            return c;
        }
    }
    public Blue_3(string input) : base(input){
        _output = null;
    }
    public override void Review(){
        if (string.IsNullOrEmpty(_input)){
            _output = null;
            return;
        }
        var t = _input.Split(new[] { ' ', '.', '!', '?', ',', ':', '\"', ';', '–', '(', ')', '[', ']', '{', '}', '/' }, StringSplitOptions.RemoveEmptyEntries);
        string bukv = "";
        foreach(string w in t){
            if (string.IsNullOrEmpty(w)) continue;
            char perv = char.ToLower(w[0]);
            if (!bukv.Contains(perv) && char.IsLetter(perv)){
                bukv+=perv;
            }
        }

        (char l, int k)[] ks = new (char l, int k)[bukv.Length];
        for(int j=0;j<bukv.Length;j++){
            ks[j].l = bukv[j];
            ks[j].k = 0;
        }
        foreach (string w in t){
            if (string.IsNullOrEmpty(w)) continue;
            char fb = char.ToLower(w[0]);
            for (int i=0;i<bukv.Length;i++){
                if (ks[i].l == fb){
                    ks[i].k++;
                    break;
                }
            }
        }
        double total = 0.0;
        double r = 0.0;
        foreach (string item in t){
            if (char.IsLetter(item[0]) || (item.Length>1 && char.IsLetter(item[1]))){
                total++;
            }
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
            r = ks[i].k / total;
            ans[i] = (ks[i].l, (double)r * 100);
        }
        _output = ans;
    }
        public override string ToString()
        {
            if (_output == null) return null;
            string ans = "";
            int p = _output.Length -1;
            for(int k = 0; k<_output.Length;k++)
            {
                ans += $"{_output[k].Item1} - {_output[k].Item2:f4}";
                if (k < p){
                    ans+=Environment.NewLine;
                }
            }
            ans = ans.TrimEnd('\n');
            return ans;
        }

    }
}
