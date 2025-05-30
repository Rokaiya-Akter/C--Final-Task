public static Dictionary<string, int> CountWords(string content)
{
    var wordCounts = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);

    // Split content into words using common separators
    var words = content.Split(new[] { ' ', '\n', '\r', '\t', '.', ',', ';', '!', '?', ':', '-', '_', '\"', '\'', '(', ')' }, 
                              StringSplitOptions.RemoveEmptyEntries);
//starting foreach sec
    foreach (var word in words)
    {
        var cleanWord = word.Trim().ToLower();
        if (!string.IsNullOrWhiteSpace(cleanWord))
        {
            if (!wordCounts.ContainsKey(cleanWord))
                wordCounts[cleanWord] = 0;

            wordCounts[cleanWord]++;
        }
    }

    return wordCounts;
}
