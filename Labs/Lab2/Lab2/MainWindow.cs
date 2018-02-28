using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace Lab2
{
	public partial class MainWindow : Form, IOleClientSite, IOleInPlaceSite
	{
		private tagRECT NewRect = new tagRECT(100, 100, 100, 100);
		private tagRECT New = new tagRECT(0, 0, 1250, 920);

		public MainWindow()
		{
			OLE.CoInitializeEx(IntPtr.Zero, 2);
			InitializeComponent();

			axShockwaveFlash1.Movie = Application.StartupPath + @"\tuma.swf";
		}

		[return: MarshalAs(UnmanagedType.I4)]
		public int SaveObject()
		{
			return HRESULT.S_OK;
		}

		[return: MarshalAs(UnmanagedType.I4)]
		public int GetMoniker([In, MarshalAs(UnmanagedType.U4)] uint dwAssign, [In, MarshalAs(UnmanagedType.U4)] uint dwWhichMoniker, [MarshalAs(UnmanagedType.Interface), Out] out IMoniker ppmk)
		{
			ppmk = null;
			return HRESULT.E_FAIL;
		}

		[return: MarshalAs(UnmanagedType.I4)]
		public int GetContainer([MarshalAs(UnmanagedType.Interface), Out] out IOleContainer ppContainer)
		{
			ppContainer = null;
			return HRESULT.E_NOINTERFACE;
		}

		[return: MarshalAs(UnmanagedType.I4)]
		public int ShowObject()
		{
			return HRESULT.S_OK;
		}

		[return: MarshalAs(UnmanagedType.I4)]
		public int OnShowWindow([In, MarshalAs(UnmanagedType.Bool)] bool fShow)
		{
			return HRESULT.S_OK;
		}

		[return: MarshalAs(UnmanagedType.I4)]
		public int RequestNewObjectLayout()
		{
			return HRESULT.S_OK;
		}

		[return: MarshalAs(UnmanagedType.I4)]
		public int GetWindow([In, Out] ref IntPtr phwnd)
		{
			phwnd = groupBox1.Handle;
			return HRESULT.S_OK;
		}

		[return: MarshalAs(UnmanagedType.I4)]
		public int ContextSensitiveHelp([In, MarshalAs(UnmanagedType.Bool)] bool fEnterMode)
		{
			return HRESULT.S_OK;
		}

		[return: MarshalAs(UnmanagedType.I4)]
		public int CanInPlaceActivate()
		{
			return HRESULT.S_OK;
		}

		[return: MarshalAs(UnmanagedType.I4)]
		public int OnInPlaceActivate()
		{
			return HRESULT.S_OK;
		}

		[return: MarshalAs(UnmanagedType.I4)]
		public int OnUIActivate()
		{
			return HRESULT.S_OK;
		}
		[return: MarshalAs(UnmanagedType.I4)]
		public int GetWindowContext([MarshalAs(UnmanagedType.Interface), Out] out IOleInPlaceFrame ppFrame, [MarshalAs(UnmanagedType.Interface), Out] out IOleInPlaceUIWindow ppDoc, [In, MarshalAs(UnmanagedType.Struct), Out] ref tagRECT lprcPosRect, [In, MarshalAs(UnmanagedType.Struct), Out] ref tagRECT lprcClipRect, [In, MarshalAs(UnmanagedType.Struct), Out] ref tagOIFI lpFrameInfo)
		{
			ppFrame = null;
			ppDoc = null;
			lprcPosRect = New;
			lprcClipRect = New;

			return HRESULT.S_OK;
		}

		int IOleInPlaceSite.Scroll(ref tagSIZE scrollExtent)
		{
			return HRESULT.S_OK;
		}

		[return: MarshalAs(UnmanagedType.I4)]
		public int OnUIDeactivate([In, MarshalAs(UnmanagedType.Bool)] bool fUndoable)
		{
			return HRESULT.S_OK;
		}

		[return: MarshalAs(UnmanagedType.I4)]
		public int OnInPlaceDeactivate()
		{
			return HRESULT.S_OK;
		}

		[return: MarshalAs(UnmanagedType.I4)]
		public int DiscardUndoState()
		{
			return HRESULT.S_OK;
		}

		[return: MarshalAs(UnmanagedType.I4)]
		public int DeactivateAndUndo()
		{
			return HRESULT.S_OK;
		}

		[return: MarshalAs(UnmanagedType.I4)]
		public int OnPosRectChange([In, MarshalAs(UnmanagedType.Struct)] ref tagRECT lprcPosRect)
		{
			lprcPosRect = New;
			return HRESULT.S_OK;
		}

		private void MainWindow_Load(object sender, EventArgs e)
		{
			var instance = OLE.CoCreateInstance(OLE.CLASS_WEBBROWSER, null, OLE.CLSCTX.CLSCTX_INPROC_SERVER, OLE.IID_IWebBrowser2);

			var obj = instance as IOleObject;

			obj.SetClientSite(this);

			var rect = new tagRECT();
			obj.DoVerb((int)OLEDOVERB.OLEIVERB_INPLACEACTIVATE, IntPtr.Zero, this, 0, Handle, ref rect);

			var browser = instance as IWebBrowser2;
			browser.Navigate("http://google.com", null, null, null, null);
		}
	}
}
