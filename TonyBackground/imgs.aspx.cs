using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Drawing.Drawing2D;

namespace myhome.users
{
	/// <summary>
	/// imgs ��ժҪ˵����
	/// </summary>
	public partial class imgs : System.Web.UI.Page
	{
		private void Page_Load(object sender, System.EventArgs e)
		{
			// �ڴ˴������û������Գ�ʼ��ҳ��
			char[] NUMBER = new char[36]{'A','B','C','D','E','F',
											'G','H','I','J','K','L',
											'M','N','O','P','Q','R',
											'S','T','U','V','W','X','Y','Z','0','1','2','3','4','5','6','7','8','9'};

			Random dd = new Random( Environment.TickCount );
			string number1 = NUMBER[dd.Next(36)].ToString();
			string number2 = NUMBER[dd.Next(36)].ToString();
			string number3 = NUMBER[dd.Next(36)].ToString();
			string number4 = NUMBER[dd.Next(36)].ToString();
			string number = number1+number2+number3+number4;

			Session["ValidateID"] = number;

			using ( Bitmap map = new Bitmap( 80, 30 ) )
			{
				using ( Graphics image = Graphics.FromImage( map ) )
				{
					image.Clear( Color.Black );

					using ( Bitmap tmpMap = new Bitmap( 20, 30 ) )
					{
						using (Graphics g = Graphics.FromImage( tmpMap ))
						{
							g.DrawString( number1, new Font( "������", 18 ), Brushes.LightYellow,0, 0 );
							TextureBrush tb = new TextureBrush( tmpMap, WrapMode.Tile );
							tb.RotateTransform( dd.Next(14) - 7 );
							image.FillRectangle( tb, 0, 0, 20, 30 );
						}
					}
					using ( Bitmap tmpMap = new Bitmap( 20, 30 ) )
					{
						using (Graphics g = Graphics.FromImage( tmpMap ))
						{
							g.DrawString( number2, new Font( "������", 18 ), Brushes.LightYellow, 0, 0 );
							TextureBrush tb = new TextureBrush( tmpMap, WrapMode.Tile );
							tb.RotateTransform( dd.Next(14) - 7 );
							tb.TranslateTransform( 0.00f, 1.00f );
							image.FillRectangle( tb, 20, 0, 20, 30 );
						}
					}
					using ( Bitmap tmpMap = new Bitmap( 20, 30 ) )
					{
						using (Graphics g = Graphics.FromImage( tmpMap ))
						{
							g.DrawString( number3, new Font( "������", 18 ), Brushes.LightYellow, 0, 0 );
							TextureBrush tb = new TextureBrush( tmpMap, WrapMode.Tile );
							tb.RotateTransform( dd.Next(14) - 7 );
							tb.TranslateTransform( 0.00f, 2.00f );
							image.FillRectangle( tb, 40, 0, 20, 30 );
						}
					}

					using ( Bitmap tmpMap = new Bitmap( 20, 30 ) )
					{
						using (Graphics g = Graphics.FromImage( tmpMap ))
						{
							g.DrawString( number4, new Font( "������", 18 ), Brushes.LightYellow, 0, 0 );
							TextureBrush tb = new TextureBrush( tmpMap, WrapMode.Tile );
							tb.RotateTransform( dd.Next(14) - 7 );
							tb.TranslateTransform( 0.00f, 3.00f );
							image.FillRectangle( tb, 60, 0, 20, 30 );
						}
					}

					for ( int i = 0; i < 30; i++ )
					{
						map.SetPixel( dd.Next( 80 ), dd.Next( 30 ),System.Drawing.Color.White );
					}

					map.Save( this.Response.OutputStream, System.Drawing.Imaging.ImageFormat.Jpeg );
				}
			}
			}

		#region Web ������������ɵĴ���
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: �õ����� ASP.NET Web ���������������ġ�
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// �����֧������ķ��� - ��Ҫʹ�ô���༭���޸�
		/// �˷��������ݡ�
		/// </summary>
		private void InitializeComponent()
		{    
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
	}
}
