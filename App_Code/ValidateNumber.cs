using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Web.UI;
using System.Drawing.Drawing2D;
using System.IO;

public class ValidateNumber
{
    public ValidateNumber()
    {
    }
    /// <summary>
    /// ��֤�����󳤶�
    /// </summary>
    public int MaxLength
    {
        get { return 10; }
    }
    /// <summary>
    /// ��֤�����С����
    /// </summary>
    public int MinLength
    {
        get { return 1; }
    }
    /// <summary>
    /// ������֤��
    /// </summary>
    /// <param name="length">ָ����֤��ĳ���</param>
    /// <returns></returns>
    public string CreateValidateNumber(int length)
    {
        int[] randMembers = new int[length];
        int[] validateNums = new int[length];
        string validateNumberStr = "";
        //������ʼ����ֵ
        int seekSeek = unchecked((int)DateTime.Now.Ticks);
        Random seekRand = new Random(seekSeek);
        int beginSeek = (int)seekRand.Next(0, Int32.MaxValue - length * 10000);
        int[] seeks = new int[length];
        for (int i = 0; i < length; i++)
        {
            beginSeek += 10000;
            seeks[i] = beginSeek;
        }
        //�����������
        for (int i = 0; i < length; i++)
        {
            Random rand = new Random(seeks[i]);
            int pownum = 1 * (int)Math.Pow(10, length);
            randMembers[i] = rand.Next(pownum, Int32.MaxValue);
        }
        //��ȡ�������
        for (int i = 0; i < length; i++)
        {
            string numStr = randMembers[i].ToString();
            int numLength = numStr.Length;
            Random rand = new Random();
            int numPosition = rand.Next(0, numLength - 1);
            validateNums[i] = Int32.Parse(numStr.Substring(numPosition, 1));
        }
        //������֤��
        for (int i = 0; i < length; i++)
        {
            validateNumberStr += validateNums[i].ToString();
        }
        return validateNumberStr;
    }
    /// <summary>
    /// ������֤���ͼƬ
    /// </summary>
    /// <param name="containsPage">Ҫ�������page����</param>
    /// <param name="validateNum">��֤��</param>
    public void CreateValidateGraphic(Page containsPage, string validateNum)
    {
        Bitmap image = new Bitmap((int)Math.Ceiling(validateNum.Length * 12.5), 22);
        Graphics g = Graphics.FromImage(image);
        try
        {
            //�������������
            Random random = new Random();
            //���ͼƬ����ɫ
            g.Clear(Color.White);
            //��ͼƬ�ĸ�����
            for (int i = 0; i < 25; i++)
            {
                int x1 = random.Next(image.Width);
                int x2 = random.Next(image.Width);
                int y1 = random.Next(image.Height);
                int y2 = random.Next(image.Height);
                g.DrawLine(new Pen(Color.Silver), x1, y1, x2, y2);
            }
            Font font = new Font("Arial", 12, (FontStyle.Bold | FontStyle.Italic));
            LinearGradientBrush brush = new LinearGradientBrush(new Rectangle(0, 0, image.Width, image.Height),
             Color.Blue, Color.DarkRed, 1.2f, true);
            g.DrawString(validateNum, font, brush, 3, 2);
            //��ͼƬ��ǰ�����ŵ�
            for (int i = 0; i < 100; i++)
            {
                int x = random.Next(image.Width);
                int y = random.Next(image.Height);
                image.SetPixel(x, y, Color.FromArgb(random.Next()));
            }
            //��ͼƬ�ı߿���
            g.DrawRectangle(new Pen(Color.Silver), 0, 0, image.Width - 1, image.Height - 1);
            //����ͼƬ����
            MemoryStream stream = new MemoryStream();
            image.Save(stream, ImageFormat.Jpeg);
            //���ͼƬ
            containsPage.Response.Clear();
            containsPage.Response.ContentType = "image/jpeg";
            containsPage.Response.BinaryWrite(stream.ToArray());
        }
        finally
        {
            g.Dispose();
            image.Dispose();
        }
    }
    /// <summary>
    /// �õ���֤��ͼƬ�ĳ���
    /// </summary>
    /// <param name="validateNumLength">��֤��ĳ���</param>
    /// <returns></returns>
    public static int GetImageWidth(int validateNumLength)
    {
        return (int)(validateNumLength * 12.5);
    }
    /// <summary>
    /// �õ���֤��ĸ߶�
    /// </summary>
    /// <returns></returns>
    public static double GetImageHeight()
    {
        return 22.5;
    }
}