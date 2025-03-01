public class Utils {
    public static string GetEscapedString(string s)
    {
        List<char> chars = new List<char>();

        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] == '"')
            {
                continue;
            }

            if (s[i] == '\\')
            {
                // Check if we're at the end of the string
                if (i == s.Length - 1)
                {
                    throw new Exception("Cannot escape the last char of a string literal");
                }
                // Peek the following character to determine which escape sequence to form
                char new_char = s[i + 1] switch
                {
                    '\\' => '\\',
                    'n' => '\n',
                    '"' => '"',
                    _ => throw new Exception($"Unsupported escape sequence {s[i]}{s[i + 1]}")
                };
                chars.Add(new_char);
                i++;
            }
            else
            {
                chars.Add(s[i]);
            }
        }

        // Finally return out the final string
        return new string(chars.ToArray());
    }

    public static string PrettyComment(char a, char b, char c)
    {
        string a_s = a == '\n' ? "\\n" : a.ToString();
        string b_s = b == '\n' ? "\\n" : b.ToString();
        string c_s = c == '\n' ? "\\n" : c.ToString();
        return $"\"{a_s}{b_s}{c_s}\"";
    }

    private static char[] _lineDelimiters = { ' ', '\t' };

    private enum TokenizerState
    {
        Normal,
        InsideString,
    }

    public static string[] TokenizeString(string s)
    {
        TokenizerState ts = TokenizerState.Normal;
        List<string> tokens = new List<string>();
        List<char> buffer = new List<char>();

        foreach (char c in s)
        {
            switch (ts)
            {
                case TokenizerState.Normal:
                    if (c == '"')
                    {
                        if (buffer.Count != 0)
                        {
                            tokens.Add(new string(buffer.ToArray()));
                            buffer.Clear();
                        }

                        ts = TokenizerState.InsideString;
                    }
                    else if (_lineDelimiters.Contains(c))
                    {
                        if (buffer.Count != 0)
                        {
                            tokens.Add(new string(buffer.ToArray()));
                            buffer.Clear();
                        }
                    }
                    else
                    {
                        buffer.Add(c);
                    }
                    break;
                case TokenizerState.InsideString:
                    if (c == '"')
                    {
                        if (buffer.Count != 0)
                        {
                            tokens.Add(Utils.GetEscapedString(new string(buffer.ToArray())));
                            buffer.Clear();
                        }

                        ts = TokenizerState.Normal;
                    }
                    else
                    {
                        buffer.Add(c);
                    }
                    break;
            }
        }

        if (ts == TokenizerState.Normal && buffer.Count != 0)
        {
            tokens.Add(new string(buffer.ToArray()));
        }

        return tokens.ToArray();
    }


}
