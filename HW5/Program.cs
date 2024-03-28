using System.Text;
using static HW5.WorkingWithInput;

class Program
{
    private static void Main()
    {
        var path = "C:\\Users\\iskos\\RiderProjects\\Longest-common-subsequence-Levenshtein-distance\\HW5\\words_list.txt";
        var wordsToWorkWith = FindWrongs(Console.ReadLine().ToLower() , CreateDict(path , new HashSet<string>()));
        Console.WriteLine($"Looks like you have typos in next words: \"{string.Join("\" \"" , wordsToWorkWith)}\"");


        var result = new Dictionary<string, PriorityQueue<Tuple<string , int> , int >>()  ;
        foreach (var word in wordsToWorkWith)
        {
            result[word] = new PriorityQueue<Tuple<string , int>, int>(); 
            result[word].Enqueue(Tuple.Create("0" , 0), 0 );
            foreach (var fileWord in CreateDict(path , new HashSet<string>()))
            {
                if (fileWord.Length != word.Length )
                {
                    continue ;
                }
                var number = LCS(word, fileWord) ;
                
                if (result[word].Peek().Item2 < number)
                {
                    result[word].Enqueue(Tuple.Create(fileWord , number) , number);
                    if (result[word].Count == 6)
                    {
                        result[word].Dequeue();
                    }
                }
            }
        }
        
        Console.WriteLine(1);

          
    }
}