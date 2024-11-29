namespace Application.Helpers;

public enum From
{
    Left,
    Right
}

public static class StringHelpers
{
    private static string GetToken(string text, int at, string[] tokens) => (from token in tokens
        where at + token.Length <= text.Length
        where text.Substring(at, token.Length) == token
        select token).FirstOrDefault() ?? string.Empty;

    public static string GetFirstTokenInString(string text, From position, string[] tokens) => text
        .Select((_, index) => position == From.Left ? index : text.Length - 1 - index)
        .Select(at => GetToken(text, at, tokens))
        .FirstOrDefault(result => result != string.Empty) ?? string.Empty;
}