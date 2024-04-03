using System.Text;
using static HW5.WorkingWithInput;

class Program
{
    private static void Main()
    {
        var path = "C:\\Users\\iskos\\RiderProjects\\Longest-common-subsequence-Levenshtein-distance\\HW5\\words_list.txt";
        var wordsToWorkWith = FindWrongs(Console.ReadLine().ToLower() , CreateDict(path , new HashSet<string>()));
        Console.WriteLine($"Looks like you have typos in next words: \"{string.Join("\" \"" , wordsToWorkWith)}\"");
        
        var result = CreatePQwithLDforeachPair(wordsToWorkWith , new Dictionary<string, PriorityQueue<Tuple<string , int> , int >>() , path)  ;
        Console.WriteLine(find5BestWords(result));
   }
}

// var w = "lolsd";
// var w2 = "sllsx";
// Console.WriteLine(LD(w , w2));