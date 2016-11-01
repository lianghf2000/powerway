using System.Text.RegularExpressions;


public class RemoveHTML
{
    public static string Remove(string str)
    {
        string pattn = @"<.+?>";
        return Regex.Replace(str, pattn, "");
    }
}

