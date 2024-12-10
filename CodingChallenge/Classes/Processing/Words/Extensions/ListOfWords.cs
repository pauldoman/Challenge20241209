namespace CodingChallenge.Classes.Processing.Words.Extensions;

public static class ListOfWords
{

    public static List<WordInSequence> SplitIntoWords(this string source)
    {
        char[] splitDelimiters = [' ', '\n'];
        
        var words = source
            .Split(splitDelimiters)
            .Select((x,index) => new WordInSequence(index,x))
            .ToList();
        
        return words;
    }
    
    public static string RebuildIntoString(this IEnumerable<WordInSequence> words, string delimiter = " ")
    {
        var orderedWords = words
            .Where(x => x.Ignore == false)
            .OrderBy(x => x.Index)
            .Select(x => x.Original).ToList();
        
        return string.Join(delimiter, orderedWords);
    } 
    
    
}