using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Lab2.OLE;
using static Lab2.OLE.CLSCTX;

namespace Lab2
{
	public partial class MainWindow : Form
	{
		public MainWindow()
		{
			CoInitializeEx(IntPtr.Zero, 2);
			InitializeComponent();

			var browser = CoCreateInstance(CLASS_WEBBROWSER, null, CLSCTX_INPROC_SERVER, IID_IWebBrowser2) as IOleObject;

			var site = new ClientSite(Handle);

			browser.SetClientSite(site);

			tagRECT rectangle = new tagRECT
			{
				Top = 10,
				Bottom = 10,
				Right = 10,
				Left = 10
			};

			browser.DoVerb((int)OLEDOVERB.OLEIVERB_INPLACEACTIVATE, IntPtr.Zero, site, 0, Handle, ref rectangle);
		}
	}

	public class ClientSite : IOleClientSite, IOleInPlaceSite
	{
		private IntPtr handle;

		public ClientSite(IntPtr handle)
		{
			this.handle = handle;
		}

		//IOLEInPlaceSite
		[return: MarshalAs(UnmanagedType.I4)]
		public int OnPosRectChange([In, MarshalAs(UnmanagedType.Struct)] ref tagRECT lprcPosRect)
		{
			lprcPosRect = new tagRECT
			{
				Top = 10,
				Bottom = 10,
				Right = 10,
				Left = 10
			};

			return HRESULT.S_OK;
		}

		[return: MarshalAs(UnmanagedType.I4)]
		public int GetWindow([In, Out] ref IntPtr phwnd)
		{
			phwnd = handle;

			return HRESULT.S_OK;
		}

		[return: MarshalAs(UnmanagedType.I4)]
		public int GetWindowContext([MarshalAs(UnmanagedType.Interface), Out] out IOleInPlaceFrame ppFrame, [MarshalAs(UnmanagedType.Interface), Out] out IOleInPlaceUIWindow ppDoc, [In, MarshalAs(UnmanagedType.Struct), Out] ref tagRECT lprcPosRect, [In, MarshalAs(UnmanagedType.Struct), Out] ref tagRECT lprcClipRect, [In, MarshalAs(UnmanagedType.Struct), Out] ref tagOIFI lpFrameInfo)
		{
			throw new NotImplementedException();
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
			return HRESULT.ERROR_ACCESS_DENIED;
		}

		[return: MarshalAs(UnmanagedType.I4)]
		public int GetContainer([MarshalAs(UnmanagedType.Interface), Out] out IOleContainer ppContainer)
		{
			ppContainer = null;
			return HRESULT.ERROR_ACCESS_DENIED;
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
		public int Scroll([In, MarshalAs(UnmanagedType.Struct)] ref tagSIZE scrollExtent)
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
	}
}
