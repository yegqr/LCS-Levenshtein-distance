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
            var counter = 0;
            foreach (var fileWord in CreateDict(path , new HashSet<string>()))
            {
                var number = LD(word, fileWord) ;
                result[word].Enqueue(Tuple.Create(fileWord , number) , number);
            }
        }

        foreach (var pair in result)
        {
            var temp = new List<string>();
            while ( temp.Count != 5 )
            {
                temp.Add(pair.Value.Dequeue().Item1);
            }
            Console.WriteLine($"{pair.Key} -> {string.Join(" || " , temp)}");
        }
   }
}

// var w = "lolsd";
// var w2 = "sllsx";
// Console.WriteLine(LD(w , w2));