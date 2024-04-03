using System.Text;

namespace HW5;

public class WorkingWithInput
{
    public static HashSet<string> CreateDict(string path, HashSet<string> result)
    {
        foreach (var text in File.ReadAllLines(path))
        {
            result.Add(text.ToLower());
        }

        return result;
    }

    public static List<string> FindWrongs(string input, HashSet<string> checker)
    {
        var result = new List<string>();
        var temporary = new StringBuilder();

        foreach (var character in input)
        {
            var x = Convert.ToInt32(character);
            if (x is > 64 and < 91 or > 96 and < 123)
            {
                temporary.Append(character);
            }
            else if (!checker.TryGetValue(temporary.ToString(), out input))
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

        return result;
    }

    public static int LD(string word1, string word2)
    {
        var LD = new int[word1.Length + 1, word2.Length + 1];

        for (int i = 0; i <= word1.Length; i++)
            LD[i, 0] = i;
        for (int i = 0; i <= word2.Length; i++)
            LD[0, i] = i;

        for (int i = 1; i < word1.Length + 1; i++)
        {
            for (int j = 1; j <= word2.Length; j++)
            {
                int cost = word1[i - 1] == word2[j - 1] ? 0 : 1;

                LD[i, j] = Math.Min(
                    Math.Min(LD[i - 1, j] + 1, LD[i, j - 1] + 1),
                    LD[i - 1, j - 1] + cost);
                
                if (i > 1 && j > 1 && word1[i - 1] == word2[j - 2] && word1[i - 2] == word2[j - 1])
                {
                    LD[i, j] = Math.Min(LD[i, j], LD[i - 2, j - 2] + cost);
                }
            }
        }
        return LD[word1.Length, word2.Length];
    }

    public static Dictionary<string, PriorityQueue<Tuple<string, int>, int>> CreatePQwithLDforeachPair(List<string> input , Dictionary<string, PriorityQueue<Tuple<string , int> , int >> result , string path)
    {
        foreach (var word in input)
        {
            result[word] = new PriorityQueue<Tuple<string , int>, int>();
            foreach (var fileWord in CreateDict(path , new HashSet<string>()))
            {
                var number = LD(word, fileWord) ;
                result[word].Enqueue(Tuple.Create(fileWord , number) , number);
            }
        }

        return result;
    }

    public static string find5BestWords(Dictionary<string, PriorityQueue<Tuple<string , int> , int >> input)
    {
        var result = new StringBuilder();
        foreach (var pair in input)
        {
            var temp = new List<string>();
            while ( temp.Count != 5 )
            {
                temp.Add(pair.Value.Dequeue().Item1);
            }
            result.Append($"{pair.Key} -> {string.Join(" || " , temp)}\n");
        }

        return result.ToString();
    }
}