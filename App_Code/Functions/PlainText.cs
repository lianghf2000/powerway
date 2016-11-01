
public class PlainText
{
    public static string Plain(string str)
    {            
        CuteEditor.Editor ee = new CuteEditor.Editor();
        ee.Text = str;            
        return ee.PlainText;
    }
}

