using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace Lab2
{
	public class ClientSite : IOleClientSite, IOleInPlaceSite
	{
		private readonly tagRECT rectForm;
		private readonly IntPtr groupBoxHandle;

		public ClientSite(IntPtr handle, int l, int t, int r, int b)
		{
			groupBoxHandle = handle;
			rectForm = new tagRECT(l, t, r, b);
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
			phwnd = groupBoxHandle;
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
			lprcPosRect = rectForm;
			lprcClipRect = rectForm;

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
			lprcPosRect = rectForm;
			return HRESULT.S_OK;
		}
	}
}
