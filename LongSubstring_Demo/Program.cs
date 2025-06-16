//// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

class Program
{
    static void Main()
    {
        string s = "abcabcbb";
        int result = LengthOfLongestSubstring1(s);
        Console.WriteLine("Output: " + result);
    }

    static int LengthOfLongestSubstring1(string s)
    {
        int maxLength = 0;
        int start = 0;
        var seen = new Dictionary<char, int>();

        for (int end = 0; end < s.Length; end++)
        {
            if (seen.ContainsKey(s[end]) && seen[s[end]] >= start)
            {
                start = seen[s[end]] + 1;
            }

            seen[s[end]] = end;
            maxLength = Math.Max(maxLength, end - start + 1);
        }
        
        return maxLength;
    }

    static int LengthOfLongestSubstring2(string s)
    {
        int maxLength = 0;
        int start = 0;

        for (int end = 0; end < s.Length; end++)
        {
            string currentSubstring = s.Substring(start, end - start + 1);

            // If character at 'end' already exists in the current substring, move 'start'
            if (currentSubstring.Contains(s[end]))
            {
                // Move start index to one past the first occurrence of the duplicate character
                while (s[start] != s[end])
                {
                    start++;
                }
                start++; // skip the duplicate character
            }

            // Update max length
            maxLength = Math.Max(maxLength, end - start + 1);
        }

        return maxLength;
    }
}

