using System;
using System.Windows.Forms;

using static Lab2.OLE;
using static Lab2.OLEDOVERB;
using static Lab2.OLE.CLSCTX;

namespace Lab2
{
	public partial class MainWindow : Form
	{
		private readonly tagRECT tagRect = new tagRECT();

		public MainWindow()
		{
			CoInitializeEx(IntPtr.Zero, 2);
			InitializeComponent();

			var obj = CoCreateInstance(
				rclsid: CLASS_WEBBROWSER, 
				pUnkOuter: null, 
				dwClsContext: CLSCTX_INPROC_SERVER, 
				riid: IID_IWebBrowser2
			) as IOleObject;

			var site = new ClientSite(groupBox1.Handle, 0, 0, 1250, 920);
			obj.SetClientSite(site);

			obj.DoVerb((int)OLEDOVERB_INPLACEACTIVATE, IntPtr.Zero, site, 0, Handle, ref tagRect);

			(obj as IWebBrowser2).Navigate("http://google.com", null, null, null, null);

			axShockwaveFlash1.Movie = Application.StartupPath + @"\tuma.swf";
		}
	}
}
