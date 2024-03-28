using System.Text;

namespace HW5;

public class WorkingWithInput
{
    public static HashSet<string> CreateDict(string path , HashSet<string> result)
    {
        foreach (var text in File.ReadAllLines(path))
        {
            result.Add(text.ToLower());
        }
        return result;
    }

    public static List<string> FindWrongs(string input, HashSet<string> checker )
    {
        var result = new List<string>();
        var temporary = new StringBuilder();
            
        foreach (var character in input)
        {
            var x = Convert.ToInt32(character) ;
            if (x is > 64 and < 91 or > 96 and < 123 )
            {
                temporary.Append(character);
            }
            else if (!checker.TryGetValue(temporary.ToString() , out input))
            {
                if (temporary.Length == 0)
                {
                    continue;
                }
                result.Add(temporary.ToString());
                temporary.Clear();
            }
            else
            {
                temporary.Clear();
            }
        }
        return result ;
    }

    public static int LCS(string word1, string word2)
    {
        var LCS =  new int[word1.Length + 1 , word2.Length + 1 ];

        LCS[0, 0] = 0;
        for (int i = 0; i <= word1.Length; i++)
            LCS[i, 0] = 0;
        for (int j = 0; j <= word2.Length; j++)
            LCS[0, j] = 0;
        
        for (int i = 1; i < word1.Length +1 ; i++)
        {
            for (int j = 1; j < word2.Length +1 ; j++)
            {
                if (word1[i - 1] == word2[j - 1])
                {
                    LCS[i, j] = LCS[i - 1, j - 1] + 1; 
                }
                else
                {
                    LCS[i , j] = Math.Max(LCS[i - 1 ,j], LCS[i ,j - 1]);
                }
            }
        }

        return LCS[word1.Length, word2.Length];
    }
}