using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Security;

namespace Lab2
{
	static class OLE
	{
		public static Guid CLASS_WEBBROWSER = Guid.Parse("8856F961-340A-11D0-A96B-00C04FD705A2");
		public static Guid IID_IWebBrowserApp = Guid.Parse("0002DF05-0000-0000-C000-000000000046");
		public static Guid IID_IWebBrowser2 = Guid.Parse("D30C1661-CDAF-11D0-8A3E-00C04FC9E26E");
		public static Guid IID_IOleWindow = Guid.Parse("00000114-0000-0000-C000-000000000046");
		public static Guid IID_IOleClientSite = Guid.Parse("00000118-0000-0000-C000-000000000046");
		public static Guid IID_IOleInPlaceSite = Guid.Parse("00000119-0000-0000-C000-000000000046");

		public const int OLEIVERB_INPLACEACTIVATE = unchecked((int)-5L);

		[DllImport("ole32.dll", CharSet = CharSet.Auto, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
		public static extern int CoInitializeEx(
				[In, Optional] IntPtr pvReserved,
				[In]  UInt32 dwCoInit //DWORD
				);
		[DllImport("ole32.dll", ExactSpelling = true, PreserveSig = false)]
		[return: MarshalAs(UnmanagedType.Interface)]
		public static extern object CoCreateInstance(
				[In, MarshalAs(UnmanagedType.LPStruct)] Guid rclsid,
				[MarshalAs(UnmanagedType.IUnknown)] object pUnkOuter,
				CLSCTX dwClsContext,
				[In, MarshalAs(UnmanagedType.LPStruct)] Guid riid
				);
		[Flags]
		public enum CLSCTX : uint
		{
			CLSCTX_INPROC_SERVER = 0x1,
			CLSCTX_INPROC_HANDLER = 0x2,
			CLSCTX_LOCAL_SERVER = 0x4,
			CLSCTX_INPROC_SERVER16 = 0x8,
			CLSCTX_REMOTE_SERVER = 0x10,
			CLSCTX_INPROC_HANDLER16 = 0x20,
			CLSCTX_RESERVED1 = 0x40,
			CLSCTX_RESERVED2 = 0x80,
			CLSCTX_RESERVED3 = 0x100,
			CLSCTX_RESERVED4 = 0x200,
			CLSCTX_NO_CODE_DOWNLOAD = 0x400,
			CLSCTX_RESERVED5 = 0x800,
			CLSCTX_NO_CUSTOM_MARSHAL = 0x1000,
			CLSCTX_ENABLE_CODE_DOWNLOAD = 0x2000,
			CLSCTX_NO_FAILURE_LOG = 0x4000,
			CLSCTX_DISABLE_AAA = 0x8000,
			CLSCTX_ENABLE_AAA = 0x10000,
			CLSCTX_FROM_DEFAULT_CONTEXT = 0x20000,
			CLSCTX_ACTIVATE_32_BIT_SERVER = 0x40000,
			CLSCTX_ACTIVATE_64_BIT_SERVER = 0x80000,
			CLSCTX_INPROC = CLSCTX_INPROC_SERVER | CLSCTX_INPROC_HANDLER,
			CLSCTX_SERVER = CLSCTX_INPROC_SERVER | CLSCTX_LOCAL_SERVER | CLSCTX_REMOTE_SERVER,
			CLSCTX_ALL = CLSCTX_SERVER | CLSCTX_INPROC_HANDLER
		}
	}

	[ComImport,
	Guid("D30C1661-CDAF-11D0-8A3E-00C04FC9E26E"),
	InterfaceType(ComInterfaceType.InterfaceIsIDispatch),
	SuppressUnmanagedCodeSecurity]
	public interface IWebBrowser2
	{
		[DispId(100)]
		void GoBack();
		[DispId(0x65)]
		void GoForward();
		[DispId(0x66)]
		void GoHome();
		[DispId(0x67)]
		void GoSearch();
		[DispId(0x68)]
		void Navigate([MarshalAs(UnmanagedType.BStr)] string URL, [In] ref object Flags, [In] ref object TargetFrameName, [In] ref object PostData, [In] ref object Headers);
		[DispId(-550)]
		void Refresh();
		[DispId(0x69)]
		void Refresh2([In] ref object Level);
		[DispId(0x6a)]
		void Stop();
		[DispId(300)]
		void Quit();
		[DispId(0x12d)]
		void ClientToWindow([In, Out] ref int pcx, [In, Out] ref int pcy);
		[DispId(0x12e)]
		void PutProperty([MarshalAs(UnmanagedType.BStr)] string Property, object vtValue);
		[DispId(0x12f)]
		object GetProperty([MarshalAs(UnmanagedType.BStr)] string Property);
		[DispId(500)]
		void Navigate2([In] ref object URL, [In] ref object Flags, [In] ref object TargetFrameName, [In] ref object PostData, [In] ref object Headers);
		[DispId(0x1f5)]
		OLECMDF QueryStatusWB(OLECMDID cmdID);
		[DispId(0x1f6)]
		void ExecWB(OLECMDID cmdID, OLECMDEXECOPT cmdexecopt, [In] ref object pvaIn, [In, Out] ref object pvaOut);
		[DispId(0x1f7)]
		void ShowBrowserBar([In] ref object pvaClsid, [In] ref object pvarShow, [In] ref object pvarSize);
		bool AddressBar { [return: MarshalAs(UnmanagedType.VariantBool)] [DispId(0x22b)] get; [DispId(0x22b)] set; }
		object Application { [return: MarshalAs(UnmanagedType.IDispatch)] [DispId(200)] get; }
		bool Busy { [return: MarshalAs(UnmanagedType.VariantBool)] [DispId(0xd4)] get; }
		object Container { [return: MarshalAs(UnmanagedType.IDispatch)] [DispId(0xca)] get; }
		object Document { [return: MarshalAs(UnmanagedType.IDispatch)] [DispId(0xcb)] get; }
		string FullName { [return: MarshalAs(UnmanagedType.BStr)] [DispId(400)] get; }
		bool FullScreen { [return: MarshalAs(UnmanagedType.VariantBool)] [DispId(0x197)] get; [DispId(0x197)] set; }
		int Height { [DispId(0xd1)] get; [DispId(0xd1)] set; }
		int HWND { [DispId(-515)] get; }
		int Left { [DispId(0xce)] get; [DispId(0xce)] set; }
		string LocationName { [return: MarshalAs(UnmanagedType.BStr)] [DispId(210)] get; }
		string LocationURL { [return: MarshalAs(UnmanagedType.BStr)] [DispId(0xd3)] get; }
		bool MenuBar { [return: MarshalAs(UnmanagedType.VariantBool)] [DispId(0x196)] get; [DispId(0x196)] set; }
		string Name { [return: MarshalAs(UnmanagedType.BStr)] [DispId(0)] get; }
		bool Offline { [return: MarshalAs(UnmanagedType.VariantBool)] [DispId(550)] get; [DispId(550)] set; }
		object Parent { [return: MarshalAs(UnmanagedType.IDispatch)] [DispId(0xc9)] get; }
		string Path { [return: MarshalAs(UnmanagedType.BStr)] [DispId(0x191)] get; }
		tagREADYSTATE ReadyState { [DispId(-525)] get; }
		bool RegisterAsBrowser { [return: MarshalAs(UnmanagedType.VariantBool)] [DispId(0x228)] get; [DispId(0x228)] set; }
		bool RegisterAsDropTarget { [return: MarshalAs(UnmanagedType.VariantBool)] [DispId(0x229)] get; [DispId(0x229)] set; }
		bool Resizable { [return: MarshalAs(UnmanagedType.VariantBool)] [DispId(0x22c)] get; [DispId(0x22c)] set; }
		bool Silent { [return: MarshalAs(UnmanagedType.VariantBool)] [DispId(0x227)] get; [DispId(0x227)] set; }
		bool StatusBar { [return: MarshalAs(UnmanagedType.VariantBool)] [DispId(0x193)] get; [DispId(0x193)] set; }
		string StatusText { [return: MarshalAs(UnmanagedType.BStr)] [DispId(0x194)] get; [DispId(0x194)] set; }
		bool TheaterMode { [return: MarshalAs(UnmanagedType.VariantBool)] [DispId(0x22a)] get; [DispId(0x22a)] set; }
		int ToolBar { [DispId(0x195)] get; [DispId(0x195)] set; }
		int Top { [DispId(0xcf)] get; [DispId(0xcf)] set; }
		bool TopLevelContainer { [return: MarshalAs(UnmanagedType.VariantBool)] [DispId(0xcc)] get; }
		string Type { [return: MarshalAs(UnmanagedType.BStr)] [DispId(0xcd)] get; }
		bool Visible { [return: MarshalAs(UnmanagedType.VariantBool)] [DispId(0x192)] get; [DispId(0x192)] set; }
		int Width { [DispId(0xd0)] get; [DispId(0xd0)] set; }
	}

	[ComImport(), ComVisible(true),
	Guid("0000011B-0000-0000-C000-000000000046"),
	InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IOleContainer
	{
		//IParseDisplayName
		[return: MarshalAs(UnmanagedType.I4)]
		[PreserveSig]
		int ParseDisplayName(
				[In, MarshalAs(UnmanagedType.Interface)] object pbc,
				[In, MarshalAs(UnmanagedType.BStr)]      string pszDisplayName,
				[Out, MarshalAs(UnmanagedType.LPArray)] int[] pchEaten,
				[Out, MarshalAs(UnmanagedType.LPArray)] object[] ppmkOut);

		//IOleContainer
		[return: MarshalAs(UnmanagedType.I4)]
		[PreserveSig]
		int EnumObjects(
				[In, MarshalAs(UnmanagedType.U4)] tagOLECONTF grfFlags,
				out IEnumUnknown ppenum);

		[return: MarshalAs(UnmanagedType.I4)]
		[PreserveSig]
		int LockContainer(
				[In, MarshalAs(UnmanagedType.Bool)] Boolean fLock);
	}

	[ComImport, ComVisible(true)]
	[Guid("00000112-0000-0000-C000-000000000046")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IOleObject
	{
		[return: MarshalAs(UnmanagedType.I4)]
		[PreserveSig]
		int SetClientSite(
				[In, MarshalAs(UnmanagedType.Interface)] IOleClientSite pClientSite);

		[return: MarshalAs(UnmanagedType.I4)]
		[PreserveSig]
		int GetClientSite(
				[Out, MarshalAs(UnmanagedType.Interface)] out IOleClientSite site);

		[return: MarshalAs(UnmanagedType.I4)]
		[PreserveSig]
		int SetHostNames(
				[In, MarshalAs(UnmanagedType.LPWStr)] string szContainerApp,
				[In, MarshalAs(UnmanagedType.LPWStr)] string szContainerObj);

		[return: MarshalAs(UnmanagedType.I4)]
		[PreserveSig]
		int Close([In, MarshalAs(UnmanagedType.U4)] uint dwSaveOption);

		[return: MarshalAs(UnmanagedType.I4)]
		[PreserveSig]
		int SetMoniker(
				[In, MarshalAs(UnmanagedType.U4)] int dwWhichMoniker,
				[In, MarshalAs(UnmanagedType.Interface)] IMoniker pmk);

		[return: MarshalAs(UnmanagedType.I4)]
		[PreserveSig]
		int GetMoniker(
				[In, MarshalAs(UnmanagedType.U4)] uint dwAssign,
				[In, MarshalAs(UnmanagedType.U4)] uint dwWhichMoniker,
				[Out, MarshalAs(UnmanagedType.Interface)] out IMoniker moniker);

		[return: MarshalAs(UnmanagedType.I4)]
		[PreserveSig]
		int InitFromData(
				[In, MarshalAs(UnmanagedType.Interface)] System.Runtime.InteropServices.ComTypes.IDataObject pDataObject,
				[In, MarshalAs(UnmanagedType.Bool)] bool fCreation,
				[In, MarshalAs(UnmanagedType.U4)] uint dwReserved);

		int GetClipboardData(
				[In, MarshalAs(UnmanagedType.U4)] uint dwReserved,
				[Out, MarshalAs(UnmanagedType.Interface)] out System.Runtime.InteropServices.ComTypes.IDataObject data);

		[return: MarshalAs(UnmanagedType.I4)]
		[PreserveSig]
		int DoVerb(
				[In, MarshalAs(UnmanagedType.I4)] int iVerb,
				//            [In, MarshalAs(UnmanagedType.Struct)] ref tagMSG lpmsg,
				[In] IntPtr lpmsg,
				[In, MarshalAs(UnmanagedType.Interface)] IOleClientSite pActiveSite,
				[In, MarshalAs(UnmanagedType.I4)] int lindex,
				[In] IntPtr hwndParent,
				[In, MarshalAs(UnmanagedType.Struct)] ref tagRECT lprcPosRect);

		[return: MarshalAs(UnmanagedType.I4)]
		[PreserveSig]
		int EnumVerbs([Out, MarshalAs(UnmanagedType.Interface)] out Object e);
		//int EnumVerbs(out IEnumOLEVERB e);

		[return: MarshalAs(UnmanagedType.I4)]
		[PreserveSig]
		int OleUpdate();

		[return: MarshalAs(UnmanagedType.I4)]
		[PreserveSig]
		int IsUpToDate();

		[return: MarshalAs(UnmanagedType.I4)]
		[PreserveSig]
		int GetUserClassID([In, Out] ref Guid pClsid);

		[return: MarshalAs(UnmanagedType.I4)]
		[PreserveSig]
		int GetUserType(
				[In, MarshalAs(UnmanagedType.U4)] uint dwFormOfType,
				[Out, MarshalAs(UnmanagedType.LPWStr)] out string userType);

		[return: MarshalAs(UnmanagedType.I4)]
		[PreserveSig]
		int SetExtent(
				[In, MarshalAs(UnmanagedType.U4)] uint dwDrawAspect,
				[In, MarshalAs(UnmanagedType.Struct)] ref tagSIZEL pSizel);

		[return: MarshalAs(UnmanagedType.I4)]
		[PreserveSig]
		int GetExtent(
				[In, MarshalAs(UnmanagedType.U4)] uint dwDrawAspect,
				[In, Out, MarshalAs(UnmanagedType.Struct)] ref tagSIZEL pSizel);

		[return: MarshalAs(UnmanagedType.I4)]
		[PreserveSig]
		int Advise(
				[In, MarshalAs(UnmanagedType.Interface)] IAdviseSink pAdvSink,
				out int cookie);

		[return: MarshalAs(UnmanagedType.I4)]
		[PreserveSig]
		int Unadvise(
				[In, MarshalAs(UnmanagedType.U4)] uint dwConnection);

		[return: MarshalAs(UnmanagedType.I4)]
		[PreserveSig]
		int EnumAdvise(out IEnumSTATDATA e);

		[return: MarshalAs(UnmanagedType.I4)]
		[PreserveSig]
		int GetMiscStatus(
				[In, MarshalAs(UnmanagedType.U4)] uint dwAspect,
				out int misc);

		[return: MarshalAs(UnmanagedType.I4)]
		[PreserveSig]
		int SetColorScheme([In, MarshalAs(UnmanagedType.Struct)] ref object pLogpal);
	}

	[ComImport, ComVisible(true)]
	[Guid("00000118-0000-0000-C000-000000000046")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IOleClientSite
	{
		[return: MarshalAs(UnmanagedType.I4)]
		[PreserveSig]
		int SaveObject();

		[return: MarshalAs(UnmanagedType.I4)]
		[PreserveSig]
		int GetMoniker(
				[In, MarshalAs(UnmanagedType.U4)]         uint dwAssign,
				[In, MarshalAs(UnmanagedType.U4)]         uint dwWhichMoniker,
				[Out, MarshalAs(UnmanagedType.Interface)] out IMoniker ppmk);

		[return: MarshalAs(UnmanagedType.I4)]
		[PreserveSig]
		int GetContainer(
				[Out, MarshalAs(UnmanagedType.Interface)] out IOleContainer ppContainer);

		[return: MarshalAs(UnmanagedType.I4)]
		[PreserveSig]
		int ShowObject();

		[return: MarshalAs(UnmanagedType.I4)]
		[PreserveSig]
		int OnShowWindow([In, MarshalAs(UnmanagedType.Bool)] bool fShow);

		[return: MarshalAs(UnmanagedType.I4)]
		[PreserveSig]
		int RequestNewObjectLayout();
	}

	[ComVisible(true), ComImport(), Guid("00000116-0000-0000-C000-000000000046"),
	InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IOleInPlaceFrame
	{
		//IOleWindow
		[return: MarshalAs(UnmanagedType.I4)]
		[PreserveSig]
		int GetWindow([In, Out] ref IntPtr phwnd);

		[return: MarshalAs(UnmanagedType.I4)]
		[PreserveSig]
		int ContextSensitiveHelp([In, MarshalAs(UnmanagedType.Bool)] bool fEnterMode);

		//IOleInPlaceUIWindow
		[return: MarshalAs(UnmanagedType.I4)]
		[PreserveSig]
		int GetBorder(
				[Out, MarshalAs(UnmanagedType.LPStruct)] tagRECT lprectBorder);

		[return: MarshalAs(UnmanagedType.I4)]
		[PreserveSig]
		int RequestBorderSpace([In, MarshalAs(UnmanagedType.Struct)] ref tagRECT pborderwidths);

		[return: MarshalAs(UnmanagedType.I4)]
		[PreserveSig]
		int SetBorderSpace([In, MarshalAs(UnmanagedType.Struct)] ref tagRECT pborderwidths);

		[return: MarshalAs(UnmanagedType.I4)]
		[PreserveSig]
		int SetActiveObject(
				[In, MarshalAs(UnmanagedType.Interface)] ref IOleInPlaceActiveObject pActiveObject,
				[In, MarshalAs(UnmanagedType.LPWStr)] string pszObjName);

		//IOleInPlaceFrame 
		[return: MarshalAs(UnmanagedType.I4)]
		[PreserveSig]
		int InsertMenus([In] IntPtr hmenuShared,
			 [In, Out, MarshalAs(UnmanagedType.Struct)] ref object lpMenuWidths);

		[return: MarshalAs(UnmanagedType.I4)]
		[PreserveSig]
		int SetMenu(
				[In] IntPtr hmenuShared,
				[In] IntPtr holemenu,
				[In] IntPtr hwndActiveObject);

		[return: MarshalAs(UnmanagedType.I4)]
		[PreserveSig]
		int RemoveMenus([In] IntPtr hmenuShared);

		[return: MarshalAs(UnmanagedType.I4)]
		[PreserveSig]
		int SetStatusText([In, MarshalAs(UnmanagedType.LPWStr)] string pszStatusText);

		[return: MarshalAs(UnmanagedType.I4)]
		[PreserveSig]
		int EnableModeless([In, MarshalAs(UnmanagedType.Bool)] bool fEnable);

		[return: MarshalAs(UnmanagedType.I4)]
		[PreserveSig]
		int TranslateAccelerator(
				[In, MarshalAs(UnmanagedType.Struct)] ref tagMSG lpmsg,
				[In, MarshalAs(UnmanagedType.U2)] short wID);
	}

	[ComImport, ComVisible(true)]
	[Guid("00000114-0000-0000-C000-000000000046")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IOleWindow
	{
		//IOleWindow
		[return: MarshalAs(UnmanagedType.I4)]
		[PreserveSig]
		int GetWindow([In, Out] ref IntPtr phwnd);

		[return: MarshalAs(UnmanagedType.I4)]
		[PreserveSig]
		int ContextSensitiveHelp([In, MarshalAs(UnmanagedType.Bool)] bool
				fEnterMode);
	}

	[ComVisible(true), ComImport(), Guid("00000115-0000-0000-C000-000000000046"),
	InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IOleInPlaceUIWindow
	{
		//IOleWindow
		[return: MarshalAs(UnmanagedType.I4)]
		[PreserveSig]
		int GetWindow([In, Out] ref IntPtr phwnd);

		[return: MarshalAs(UnmanagedType.I4)]
		[PreserveSig]
		int ContextSensitiveHelp([In, MarshalAs(UnmanagedType.Bool)] bool fEnterMode);

		//IOleInPlaceUIWindow
		[return: MarshalAs(UnmanagedType.I4)]
		[PreserveSig]
		int GetBorder([In, Out, MarshalAs(UnmanagedType.Struct)] ref tagRECT lprectBorder);

		[return: MarshalAs(UnmanagedType.I4)]
		[PreserveSig]
		int RequestBorderSpace([In, MarshalAs(UnmanagedType.Struct)] ref tagRECT pborderwidths);

		[return: MarshalAs(UnmanagedType.I4)]
		[PreserveSig]
		int SetBorderSpace([In, MarshalAs(UnmanagedType.Struct)] ref tagRECT pborderwidths);

		[return: MarshalAs(UnmanagedType.I4)]
		[PreserveSig]
		int SetActiveObject(
				[In, MarshalAs(UnmanagedType.Interface)]
								ref IOleInPlaceActiveObject pActiveObject,
				[In, MarshalAs(UnmanagedType.LPWStr)]
								string pszObjName);
	}

	[ComVisible(true), ComImport(), Guid("00000117-0000-0000-C000-000000000046"),
InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IOleInPlaceActiveObject
	{
		//IOleWindow
		[return: MarshalAs(UnmanagedType.I4)]
		[PreserveSig]
		int GetWindow([In, Out] ref IntPtr phwnd);

		[return: MarshalAs(UnmanagedType.I4)]
		[PreserveSig]
		int ContextSensitiveHelp([In, MarshalAs(UnmanagedType.Bool)] bool
				fEnterMode);

		//IOleInPlaceActiveObject
		[return: MarshalAs(UnmanagedType.I4)]
		[PreserveSig]
		int TranslateAccelerator(
				[In, MarshalAs(UnmanagedType.Struct)] ref tagMSG lpmsg);

		[return: MarshalAs(UnmanagedType.I4)]
		[PreserveSig]
		int OnFrameWindowActivate(
				[In, MarshalAs(UnmanagedType.Bool)] bool fActivate);

		[return: MarshalAs(UnmanagedType.I4)]
		[PreserveSig]
		int OnDocWindowActivate(
				[In, MarshalAs(UnmanagedType.Bool)] bool fActivate);

		[return: MarshalAs(UnmanagedType.I4)]
		[PreserveSig]
		int ResizeBorder(
				[In, MarshalAs(UnmanagedType.Struct)] ref tagRECT prcBorder,
				[In, MarshalAs(UnmanagedType.Interface)] ref IOleInPlaceUIWindow pUIWindow,
				[In, MarshalAs(UnmanagedType.Bool)] bool fFrameWindow);

		[return: MarshalAs(UnmanagedType.I4)]
		[PreserveSig]
		int EnableModeless(
				[In, MarshalAs(UnmanagedType.Bool)] bool fEnable);
	}

	[ComVisible(true), ComImport(), Guid("00000119-0000-0000-C000-000000000046"),
	InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IOleInPlaceSite
	{
		//IOleWindow
		[return: MarshalAs(UnmanagedType.I4)]
		[PreserveSig]
		int GetWindow([In, Out] ref IntPtr phwnd);

		[return: MarshalAs(UnmanagedType.I4)]
		[PreserveSig]
		int ContextSensitiveHelp([In, MarshalAs(UnmanagedType.Bool)] bool
				fEnterMode);

		//IOleInPlaceSite
		[return: MarshalAs(UnmanagedType.I4)]
		[PreserveSig]
		int CanInPlaceActivate();

		[return: MarshalAs(UnmanagedType.I4)]
		[PreserveSig]
		int OnInPlaceActivate();

		[return: MarshalAs(UnmanagedType.I4)]
		[PreserveSig]
		int OnUIActivate();

		[return: MarshalAs(UnmanagedType.I4)]
		[PreserveSig]
		int GetWindowContext(
			 [Out, MarshalAs(UnmanagedType.Interface)]
								out IOleInPlaceFrame ppFrame,
			 [Out, MarshalAs(UnmanagedType.Interface)]
								out IOleInPlaceUIWindow ppDoc,
			//[Out, MarshalAs(UnmanagedType.LPStruct)]
			//     object lprcPosRect,
			//[Out, MarshalAs(UnmanagedType.LPStruct)]
			//     object lprcClipRect,
			//[Out, MarshalAs(UnmanagedType.LPStruct)]
			//     object lpFrameInfo);
			[In, Out, MarshalAs(UnmanagedType.Struct)] ref tagRECT lprcPosRect,
			[In, Out, MarshalAs(UnmanagedType.Struct)] ref tagRECT lprcClipRect,
			[In, Out, MarshalAs(UnmanagedType.Struct)] ref tagOIFI lpFrameInfo);

		[return: MarshalAs(UnmanagedType.I4)]
		[PreserveSig]
		int Scroll([In, MarshalAs(UnmanagedType.Struct)] ref tagSIZE scrollExtent);
		//int Scroll([In, MarshalAs(UnmanagedType.U4)] Object scrollExtent);

		[return: MarshalAs(UnmanagedType.I4)]
		[PreserveSig]
		int OnUIDeactivate([In, MarshalAs(UnmanagedType.Bool)] bool fUndoable);

		[return: MarshalAs(UnmanagedType.I4)]
		[PreserveSig]
		int OnInPlaceDeactivate();

		[return: MarshalAs(UnmanagedType.I4)]
		[PreserveSig]
		int DiscardUndoState();

		[return: MarshalAs(UnmanagedType.I4)]
		[PreserveSig]
		int DeactivateAndUndo();

		[return: MarshalAs(UnmanagedType.I4)]
		[PreserveSig]
		int OnPosRectChange(
				[In, MarshalAs(UnmanagedType.Struct)] ref tagRECT lprcPosRect);
	}

	[ComImport, ComVisible(true)]
	[Guid("00000100-0000-0000-C000-000000000046")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IEnumUnknown
	{
		[PreserveSig]
		int Next(
				[In, MarshalAs(UnmanagedType.U4)] int celt,
				[Out, MarshalAs(UnmanagedType.IUnknown)] out object rgelt,
				[Out, MarshalAs(UnmanagedType.U4)] out int pceltFetched);
		[PreserveSig]
		int Skip([In, MarshalAs(UnmanagedType.U4)] int celt);
		void Reset();
		void Clone(out IEnumUnknown ppenum);
	}

	[ComVisible(true), StructLayout(LayoutKind.Sequential)]
	public struct tagRECT
	{
		[MarshalAs(UnmanagedType.I4)]
		public int Left;
		[MarshalAs(UnmanagedType.I4)]
		public int Top;
		[MarshalAs(UnmanagedType.I4)]
		public int Right;
		[MarshalAs(UnmanagedType.I4)]
		public int Bottom;

		public tagRECT(int left_, int top_, int right_, int bottom_)
		{
			Left = left_;
			Top = top_;
			Right = right_;
			Bottom = bottom_;
		}

		//public int Height { get { return Bottom - Top + 1; } }
		//public int Width { get { return Right - Left + 1; } }
		//public tagSIZE Size { get { return new tagSIZE(Width, Height); } }
		//public tagPOINT Location { get { return new tagPOINT(Left, Top); } }

		//// Handy method for converting to a System.Drawing.Rectangle
		//public System.Drawing.Rectangle ToRectangle()
		//{ return System.Drawing.Rectangle.FromLTRB(Left, Top, Right, Bottom); }

		//public static tagRECT FromRectangle(System.Drawing.Rectangle rectangle)
		//{
		//    return new tagRECT(rectangle.Left, rectangle.Top, rectangle.Right, rectangle.Bottom);
		//}

		//public override int GetHashCode()
		//{
		//    return Left ^ ((Top << 13) | (Top >> 0x13))
		//      ^ ((Width << 0x1a) | (Width >> 6))
		//      ^ ((Height << 7) | (Height >> 0x19));
		//}

		//#region Operator overloads

		//public static implicit operator System.Drawing.Rectangle(tagRECT rect)
		//{
		//    return System.Drawing.Rectangle.FromLTRB(rect.Left, rect.Top, rect.Right, rect.Bottom);
		//}

		//public static implicit operator tagRECT(System.Drawing.Rectangle rect)
		//{
		//    return new tagRECT(rect.Left, rect.Top, rect.Right, rect.Bottom);
		//}

		//#endregion
	}

	[ComVisible(true), StructLayout(LayoutKind.Sequential)]
	public struct tagSIZE
	{
		[MarshalAs(UnmanagedType.I4)]
		public int cx;
		[MarshalAs(UnmanagedType.I4)]
		public int cy;
		//public tagSIZE(int cx, int cy)
		//{
		//    this.cx = cx;
		//    this.cy = cy;
		//}
	}

	[ComVisible(true), StructLayout(LayoutKind.Sequential)]
	public struct tagSIZEL
	{
		[MarshalAs(UnmanagedType.I4)]
		public int cx;
		[MarshalAs(UnmanagedType.I4)]
		public int cy;
	}

	[ComVisible(true), StructLayout(LayoutKind.Sequential)]
	public struct tagMSG
	{
		public IntPtr hwnd;
		[MarshalAs(UnmanagedType.I4)]
		public int message;
		public IntPtr wParam;
		public IntPtr lParam;
		[MarshalAs(UnmanagedType.I4)]
		public int time;
		// pt was a by-value POINT structure
		[MarshalAs(UnmanagedType.I4)]
		public int pt_x;
		[MarshalAs(UnmanagedType.I4)]
		public int pt_y;
		//public tagPOINT pt;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct tagOIFI
	{
		[MarshalAs(UnmanagedType.U4)]
		public uint cb;
		[MarshalAs(UnmanagedType.Bool)]
		public bool fMDIApp;
		public IntPtr hwndFrame;
		public IntPtr hAccel;
		[MarshalAs(UnmanagedType.U4)]
		public uint cAccelEntries;

	}

	public enum tagREADYSTATE
	{
		READYSTATE_UNINITIALIZED = 0,
		READYSTATE_LOADING = 1,
		READYSTATE_LOADED = 2,
		READYSTATE_INTERACTIVE = 3,
		READYSTATE_COMPLETE = 4
	}

	public enum OLEDOVERB
	{
		OLEIVERB_DISCARDUNDOSTATE = -6,
		OLEIVERB_HIDE = -3,
		OLEIVERB_INPLACEACTIVATE = -5,
		OLECLOSE_NOSAVE = 1,
		OLEIVERB_OPEN = -2,
		OLEIVERB_PRIMARY = 0,
		OLEIVERB_PROPERTIES = -7,
		OLEIVERB_SHOW = -1,
		OLEIVERB_UIACTIVATE = -4
	}

	public enum OLECMDID
	{
		OLECMDID_OPEN = 1,
		OLECMDID_NEW = 2,
		OLECMDID_SAVE = 3,
		OLECMDID_SAVEAS = 4,
		OLECMDID_SAVECOPYAS = 5,
		OLECMDID_PRINT = 6,
		OLECMDID_PRINTPREVIEW = 7,
		OLECMDID_PAGESETUP = 8,
		OLECMDID_SPELL = 9,
		OLECMDID_PROPERTIES = 10,
		OLECMDID_CUT = 11,
		OLECMDID_COPY = 12,
		OLECMDID_PASTE = 13,
		OLECMDID_PASTESPECIAL = 14,
		OLECMDID_UNDO = 15,
		OLECMDID_REDO = 16,
		OLECMDID_SELECTALL = 17,
		OLECMDID_CLEARSELECTION = 18,
		OLECMDID_ZOOM = 19,
		OLECMDID_GETZOOMRANGE = 20,
		OLECMDID_UPDATECOMMANDS = 21,
		OLECMDID_REFRESH = 22,
		OLECMDID_STOP = 23,
		OLECMDID_HIDETOOLBARS = 24,
		OLECMDID_SETPROGRESSMAX = 25,
		OLECMDID_SETPROGRESSPOS = 26,
		OLECMDID_SETPROGRESSTEXT = 27,
		OLECMDID_SETTITLE = 28,
		OLECMDID_SETDOWNLOADSTATE = 29,
		OLECMDID_STOPDOWNLOAD = 30,
		OLECMDID_ONTOOLBARACTIVATED = 31,
		OLECMDID_FIND = 32,
		OLECMDID_DELETE = 33,
		OLECMDID_HTTPEQUIV = 34,
		OLECMDID_HTTPEQUIV_DONE = 35,
		OLECMDID_ENABLE_INTERACTION = 36,
		OLECMDID_ONUNLOAD = 37,
		OLECMDID_PROPERTYBAG2 = 38,
		OLECMDID_PREREFRESH = 39,
		OLECMDID_SHOWSCRIPTERROR = 40,
		OLECMDID_SHOWMESSAGE = 41,
		OLECMDID_SHOWFIND = 42,
		OLECMDID_SHOWPAGESETUP = 43,
		OLECMDID_SHOWPRINT = 44,
		OLECMDID_CLOSE = 45,
		OLECMDID_ALLOWUILESSSAVEAS = 46,
		OLECMDID_DONTDOWNLOADCSS = 47,
		OLECMDID_UPDATEPAGESTATUS = 48,
		OLECMDID_PRINT2 = 49,
		OLECMDID_PRINTPREVIEW2 = 50,
		OLECMDID_SETPRINTTEMPLATE = 51,
		OLECMDID_GETPRINTTEMPLATE = 52,
		OLECMDID_PAGEACTIONBLOCKED = 55,
		OLECMDID_PAGEACTIONUIQUERY = 56,
		OLECMDID_FOCUSVIEWCONTROLS = 57,
		OLECMDID_FOCUSVIEWCONTROLSQUERY = 58,
		OLECMDID_SHOWPAGEACTIONMENU = 59,
		OLECMDID_ADDTRAVELENTRY = 60,
		OLECMDID_UPDATETRAVELENTRY = 61,
		OLECMDID_UPDATEBACKFORWARDSTATE = 62,
		OLECMDID_OPTICAL_ZOOM = 63,
		OLECMDID_OPTICAL_GETZOOMRANGE = 64,
		OLECMDID_WINDOWSTATECHANGED = 65

	}

	public enum OLECMDEXECOPT
	{
		OLECMDEXECOPT_DODEFAULT = 0,
		OLECMDEXECOPT_PROMPTUSER = 1,
		OLECMDEXECOPT_DONTPROMPTUSER = 2,
		OLECMDEXECOPT_SHOWHELP = 3
	}

	public enum OLECMDF
	{
		OLECMDF_SUPPORTED = 1,
		OLECMDF_ENABLED = 2,
		OLECMDF_LATCHED = 4,
		OLECMDF_NINCHED = 8,
		OLECMDF_INVISIBLE = 16,
		OLECMDF_DEFHIDEONCTXTMENU = 32
	}

	public enum tagOLECONTF
	{
		OLECONTF_EMBEDDINGS = 1,
		OLECONTF_LINKS = 2,
		OLECONTF_OTHERS = 4,
		OLECONTF_ONLYUSER = 8,
		OLECONTF_ONLYIFRUNNING = 16
	}

	public sealed class HRESULT
	{
		public const int NOERROR = 0;
		public const int S_OK = 0;
		public const int S_FALSE = 1;
		public const int E_PENDING = unchecked((int)0x8000000A);
		public const int E_HANDLE = unchecked((int)0x80070006);
		public const int E_NOTIMPL = unchecked((int)0x80004001);
		public const int E_NOINTERFACE = unchecked((int)0x80004002);
		//ArgumentNullException. NullReferenceException uses COR_E_NULLREFERENCE
		public const int E_POINTER = unchecked((int)0x80004003);
		public const int E_ABORT = unchecked((int)0x80004004);
		public const int E_FAIL = unchecked((int)0x80004005);
		public const int E_OUTOFMEMORY = unchecked((int)0x8007000E);
		public const int E_ACCESSDENIED = unchecked((int)0x80070005);
		public const int E_UNEXPECTED = unchecked((int)0x8000FFFF);
		public const int E_FLAGS = unchecked((int)0x1000);
		public const int E_INVALIDARG = unchecked((int)0x80070057);

		//Wininet
		public const int ERROR_SUCCESS = 0;
		public const int ERROR_FILE_NOT_FOUND = 2;
		public const int ERROR_ACCESS_DENIED = 5;
		public const int ERROR_INSUFFICIENT_BUFFER = 122;
		public const int ERROR_NO_MORE_ITEMS = 259;

		//Ole Errors
		public const int OLE_E_FIRST = unchecked((int)0x80040000);
		public const int OLE_E_LAST = unchecked((int)0x800400FF);
		public const int OLE_S_FIRST = unchecked((int)0x00040000);
		public const int OLE_S_LAST = unchecked((int)0x000400FF);
		//OLECMDERR_E_FIRST = 0x80040100
		public const int OLECMDERR_E_FIRST = unchecked((int)(OLE_E_LAST + 1));
		public const int OLECMDERR_E_NOTSUPPORTED = unchecked((int)(OLECMDERR_E_FIRST));
		public const int OLECMDERR_E_DISABLED = unchecked((int)(OLECMDERR_E_FIRST + 1));
		public const int OLECMDERR_E_NOHELP = unchecked((int)(OLECMDERR_E_FIRST + 2));
		public const int OLECMDERR_E_CANCELED = unchecked((int)(OLECMDERR_E_FIRST + 3));
		public const int OLECMDERR_E_UNKNOWNGROUP = unchecked((int)(OLECMDERR_E_FIRST + 4));

		public const int OLEOBJ_E_NOVERBS = unchecked((int)0x80040180);
		public const int OLEOBJ_S_INVALIDVERB = unchecked((int)0x00040180);
		public const int OLEOBJ_S_CANNOT_DOVERB_NOW = unchecked((int)0x00040181);
		public const int OLEOBJ_S_INVALIDHWND = unchecked((int)0x00040182);

		public const int DV_E_LINDEX = unchecked((int)0x80040068);
		public const int OLE_E_OLEVERB = unchecked((int)0x80040000);
		public const int OLE_E_ADVF = unchecked((int)0x80040001);
		public const int OLE_E_ENUM_NOMORE = unchecked((int)0x80040002);
		public const int OLE_E_ADVISENOTSUPPORTED = unchecked((int)0x80040003);
		public const int OLE_E_NOCONNECTION = unchecked((int)0x80040004);
		public const int OLE_E_NOTRUNNING = unchecked((int)0x80040005);
		public const int OLE_E_NOCACHE = unchecked((int)0x80040006);
		public const int OLE_E_BLANK = unchecked((int)0x80040007);
		public const int OLE_E_CLASSDIFF = unchecked((int)0x80040008);
		public const int OLE_E_CANT_GETMONIKER = unchecked((int)0x80040009);
		public const int OLE_E_CANT_BINDTOSOURCE = unchecked((int)0x8004000A);
		public const int OLE_E_STATIC = unchecked((int)0x8004000B);
		public const int OLE_E_PROMPTSAVECANCELLED = unchecked((int)0x8004000C);
		public const int OLE_E_INVALIDRECT = unchecked((int)0x8004000D);
		public const int OLE_E_WRONGCOMPOBJ = unchecked((int)0x8004000E);
		public const int OLE_E_INVALIDHWND = unchecked((int)0x8004000F);
		public const int OLE_E_NOT_INPLACEACTIVE = unchecked((int)0x80040010);
		public const int OLE_E_CANTCONVERT = unchecked((int)0x80040011);
		public const int OLE_E_NOSTORAGE = unchecked((int)0x80040012);
		public const int RPC_E_RETRY = unchecked((int)0x80010109);
	}
}
