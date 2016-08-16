
using System;
using System.Runtime.InteropServices;

using BT_ADDR = System.UInt64;
using WCHAR = System.Char;

namespace PND
{
    public enum NFM_PROFILEID
    {
        NPI_UNKNOWN = -1,
        NPI_MODEM = 0,
        NPI_PRINTER,
        NPI_LAN_ACCESS,
        NPI_FILE_TRANS,
        NPI_OBEX,
        NPI_HEADSET,
        NPI_ACTIVESYNC,
        NPI_HID,
        NPI_PAN,
        NPI_HANDSFREE,
        NPI_AUDIOSINK,
        NPI_PBAP,
        NPI_SYNCML,
        NPI_MAX
    };

    public enum NFM_MAJORDEVICEID
    {
        NMJRDI_Miscellaneous = 0, // 0 0 0 0 0
        NMJRDI_Computer = 1, // 0 0 0 0 1
        NMJRDI_Phone = 2, // 0 0 0 1 0
        NMJRDI_LAN = 3, // 0 0 0 1 1
        NMJRDI_Audio_Video = 4, // 0 0 1 0 0
        NMJRDI_Peripheral = 5, // 0 0 1 0 1
        NMJRDI_Imaging = 6, // 0 0 1 1 0
        NMJRDI_Wearable = 7, // 0 0 1 1 1
        NMJRDI_Toy = 8, // 0 1 0 0 0
        NMJRDI_Health = 9, // 0 1 0 0 1
        NMJRDI_Uncategorized = 31 // 1 1 1 1 1
    };

    public enum NFM_MINOR_DEVICEID_COMPUTER
    {
        MMNRDI_Computer_Uncategorized = 0, // 0 0 0 0 0 0
        MMNRDI_Computer_Desktop = 1, // 0 0 0 0 0 1
        MMNRDI_Computer_Server = 2, // 0 0 0 0 1 0
        MMNRDI_Computer_Laptop = 3, // 0 0 0 0 1 1
        MMNRDI_Computer_Handheld = 4, // 0 0 0 1 0 0
        MMNRDI_Computer_Palm = 5, // 0 0 0 1 0 1
        MMNRDI_Computer_Wearable = 6  // 0 0 0 1 1 0
    };

    public enum NFM_MINOR_DEVICEID_PHONE
    {
        MMNRDI_Phone_Uncategorized = 0, // 0 0 0 0 0 0
        MMNRDI_Phone_Cellular = 1, // 0 0 0 0 0 1
        MMNRDI_Phone_Cordless = 2, // 0 0 0 0 1 0
        MMNRDI_Phone_Smartphone = 3, // 0 0 0 0 1 1
        MMNRDI_Phone_WiredModem_VoiceGateway = 4, // 0 0 0 1 0 0
        MMNRDI_Phone_CommonISDNAccess = 5  // 0 0 0 1 0 1
    };

    public enum NFM_MINOR_DEVICEID_LAN
    {
        MMNRDI_LAN_Fully = 0, // 0 0 0
        MMNRDI_LAN_01_17 = 1, // 0 0 1
        MMNRDI_LAN_17_33 = 2, // 0 1 0
        MMNRDI_LAN_33_50 = 3, // 0 1 1
        MMNRDI_LAN_50_67 = 4, // 1 0 0
        MMNRDI_LAN_67_83 = 5, // 1 0 1
        MMNRDI_LAN_83_99 = 6, // 1 1 0
        MMNRDI_LAN_NoService = 7  // 1 1 1
    };

    public enum NFM_MINOR_DEVICEID_AV
    {
        MMNRDI_AV_Uncategorized = 0,  // 0 0 0 0 0 0
        MMNRDI_AV_Wearable = 1,  // 0 0 0 0 0 1
        MMNRDI_AV_Handsfree = 2,  // 0 0 0 0 1 0
        MMNRDI_AV_Reserved1 = 3,  // 0 0 0 0 1 1
        MMNRDI_AV_Microphone = 4,  // 0 0 0 1 0 0
        MMNRDI_AV_Loudspeaker = 5,  // 0 0 0 1 0 1
        MMNRDI_AV_HeadPhones = 6,  // 0 0 0 1 1 0
        MMNRDI_AV_PortableAudio = 7,  // 0 0 0 1 1 1
        MMNRDI_AV_CarAudio = 8,  // 0 0 1 0 0 0
        MMNRDI_AV_SettopBox = 9,  // 0 0 1 0 0 1
        MMNRDI_AV_HiFiAudioBox = 10, // 0 0 1 0 1 0
        MMNRDI_AV_VCR = 11, // 0 0 1 0 1 1
        MMNRDI_AV_VideoCamera = 12, // 0 0 1 1 0 0
        MMNRDI_AV_Camcorder = 13, // 0 0 1 1 0 1
        MMNRDI_AV_VideoMonitor = 14, // 0 0 1 1 1 0
        MMNRDI_AV_VideoDisplay_Loudspeaker = 15, // 0 0 1 1 1 1
        MMNRDI_AV_CideoConferencing = 16, // 0 1 0 0 0 0
        MMNRDI_AV_Reserved2 = 17, // 0 1 0 0 0 1
        MMNRDI_AV_Gaming_Toy = 18  // 0 1 0 0 1 0
    };

    public enum NFM_MINOR_DEVICEID_PERIPHERAL1
    {
        MMNRDI_PERIPHERAL1_Not = 0, // 0 0
        MMNRDI_PERIPHERAL1_Keyboard = 1, // 0 1
        MMNRDI_PERIPHERAL1_PointingDevice = 2, // 1 0
        MMNRDI_PERIPHERAL1_Combo = 3  // 1 1
    };

    public enum NFM_MINOR_DEVICEID_PERIPHERAL2
    {
        MMNRDI_PERIPHERAL2_Uncategorized = 0, // 0 0 0 0
        MMNRDI_PERIPHERAL2_Joystick = 1, // 0 0 0 1
        MMNRDI_PERIPHERAL2_Gamepad = 2, // 0 0 1 0
        MMNRDI_PERIPHERAL2_RemoteControl = 3, // 0 0 1 1
        MMNRDI_PERIPHERAL2_SensingDevice = 4, // 0 1 0 0
        MMNRDI_PERIPHERAL2_DigitizerTablet = 5, // 0 1 0 1
        MMNRDI_PERIPHERAL2_CardReader = 6  // 0 1 1 0
    };

    public struct NFM_MINOR_DEVICEID_PERIPHERAL
    {
        public NFM_MINOR_DEVICEID_PERIPHERAL1 devMinorID1;
        public NFM_MINOR_DEVICEID_PERIPHERAL2 devMinorID2;
    };

    public struct NFM_MINOR_DEVICEID_IMAGING
    {
        public int bDisplay;    // x x x 1
        public int bCamera;     // x x 1 x
        public int bScanner;    // x 1 x x
        public int bPrinter;    // 1 x x x
    };

    public enum NFM_MINOR_DEVICEID_WEARABLE
    {
        MMNRDI_WEARABLE_WristWatch = 1,  // 0 0 0 0 0 1
        MMNRDI_WEARABLE_Pager = 2,  // 0 0 0 0 1 0
        MMNRDI_WEARABLE_Kacket = 3,  // 0 0 0 0 1 1
        MMNRDI_WEARABLE_Helmet = 4,  // 0 0 0 1 0 0
        MMNRDI_WEARABLE_Glasses = 5   // 0 0 0 1 0 1
    };

    public enum NFM_MINOR_DEVICEID_TOY
    {
        MMNRDI_TOY_Robot = 1,  // 0 0 0 0 0 1
        MMNRDI_TOY_Vehicle = 2,  // 0 0 0 0 1 0
        MMNRDI_TOY_Doll_ActionFigure = 3,  // 0 0 0 0 1 1
        MMNRDI_TOY_Controller = 4,  // 0 0 0 1 0 0
        MMNRDI_TOY_Game = 5   // 0 0 0 1 0 1
    };

    public enum NFM_MINOR_DEVICEID_HEALTH
    {
        MMNRDI_HEALTH_Undefined = 0,  // 0 0 0 0 0 0
        MMNRDI_HEALTH_BloodPressureMonitor = 1,  // 0 0 0 0 0 1
        MMNRDI_HEALTH_Thermometer = 2,  // 0 0 0 0 1 0
        MMNRDI_HEALTH_WeighingScale = 3,  // 0 0 0 0 1 1
        MMNRDI_HEALTH_GlucoseMeter = 4,  // 0 0 0 1 0 0
        MMNRDI_HEALTH_PulseOximeter = 5,  // 0 0 0 1 0 1
        MMNRDI_HEALTH_Heart_PulseRateMonitor = 6,  // 0 0 0 1 1 0
        MMNRDI_HEALTH_HealthDataDisplay = 7   // 0 0 0 1 1 1
    };

    [StructLayout(LayoutKind.Explicit)]
    public struct NFM_MINORDEVICEID
    {
        [FieldOffset(0)]
        NFM_MINOR_DEVICEID_COMPUTER computer;
        [FieldOffset(0)]
        NFM_MINOR_DEVICEID_PHONE phone;
        [FieldOffset(0)]
        NFM_MINOR_DEVICEID_LAN lan;
        [FieldOffset(0)]
        NFM_MINOR_DEVICEID_AV av;
        [FieldOffset(0)]
        NFM_MINOR_DEVICEID_PERIPHERAL peripheral;
        [FieldOffset(0)]
        NFM_MINOR_DEVICEID_IMAGING imaging;
        [FieldOffset(0)]
        NFM_MINOR_DEVICEID_WEARABLE wearable;
        [FieldOffset(0)]
        NFM_MINOR_DEVICEID_TOY toy;
        [FieldOffset(0)]
        NFM_MINOR_DEVICEID_HEALTH health;
    };

    public enum NFM_CMD_RET
    {
        NFM_CMD_SUCCESS_FIRST = 0,
        NFM_CMD_SUCCESS,
        NFM_CMD_SUCCESS_IGNORE,
        NFM_CMD_SUCCESS_ALREADY,
        NFM_CMD_SUCCESS_LAST,

        NFM_CMD_FAIL_FIRST = 100,
        NFM_CMD_FAIL,
        NFM_CMD_FAIL_INVALID_HANDLE,
        NFM_CMD_FAIL_NOT_SUPPORT,
        NFM_CMD_FAIL_NOT_READY,
        NFM_CMD_FAIL_MEMORY_NOT_ENOUGH,
        NFM_CMD_FAIL_DEPENDENCY,
        NFM_CMD_FAIL_IO,
        NFM_CMD_FAIL_CUS,
        NFM_CMD_FAIL_PARAMETER,
        NFM_CMD_FAIL_RETRY,
        NFM_CMD_FAIL_LAST,

        NFM_CMD_STATUS_INITIAL = 900
    };

    public enum NFM_CBK_RET
    {
        NFM_CBK_SUCCESS_FIRST = 0,
        NFM_CBK_SUCCESS,
        NFM_CBK_SUCCESS_LAST,

        NFM_CBK_FAIL_FIRST = 100,
        NFM_CBK_FAIL,
        NFM_CBK_FAIL_LAST,

        NFM_CBK_STATUS_INITIAL = 900
    };

    public enum NFM_FIELD_LEN
    {
        NFM_LEN_MINI = 8,
        NFM_LEN_SMALL = 32,
        NFM_LEN_COMMON = 64,
        NFM_LEN_BIG = 256,
        NFM_LEN_LARGE = 512,
        NFM_LEN_HUGE = 1024
    }

    public struct NFM_VER
    {
        public int iVer1;
        public int iVer2;
        public int iVer3;
        public int iVer4;
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = (int)NFM_FIELD_LEN.NFM_LEN_SMALL)]
        public string wzBuild;
    };

    public struct NFM_PAIRED_LIST
    {
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = (int)NFM_FIELD_LEN.NFM_LEN_COMMON)]
        public string wzName;
        public BT_ADDR btAddr;
        public NFM_MAJORDEVICEID devMajorID;
        public NFM_MINORDEVICEID devMinorID;
    };

    public enum NFM_POWER
    {
        NFM_POWERON,
        NFM_POWEROFF,
        NFM_POWERUNKNOWN
    };

    public enum NFM_ANSWERPAIR_STATE
    {
        NFM_ANSWERPAIR_REQUEST,
        NFM_ANSWERPAIR_TIMEOUT
    };

    public enum NFM_INQUIRY_STATE
    {
        NFM_INQ_START = 0,
        NFM_INQ_INQUIRING,
        NFM_INQ_END,
        NFM_INQ_END_RETRY
    };

    public struct NFM_INQUIRY_REMOTEDEVICE
    {
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = (int)NFM_FIELD_LEN.NFM_LEN_COMMON)]
        public string wzName;
        public BT_ADDR btAddr;
        public NFM_MAJORDEVICEID devMajorID;
        public NFM_MINORDEVICEID devMinorID;
    };

    public enum NFM_CONNECTION_STATE
    {
        NFM_CON_CONNECTION = 0,
        NFM_CON_DISCONNECTION,
        NFM_CON_NOT_SUPPORT,
    };

    public enum NFM_DOWNLOAD_TYPE
    {
        NFM_DLT_MAIN = -1,
        NFM_DLT_PBAP = 0,
        NFM_DLT_SYNCML,
        NFM_DLT_AT,
    };

    public enum NFM_DOWNLOAD_STATE
    {
        NFM_DLS_START = 0,
        NFM_DLS_ING,
        NFM_DLS_END,
    };

    public enum NFM_CONTACT_ATTR
    {
        NCA_TEL_BEGIN = 100,
        NCA_TEL_PREF,
        NCA_TEL_HOME,
        NCA_TEL_WORK,
        NCA_TEL_CELL,
        NCA_TEL_END,
    };

    public enum NFM_PB_LEN
    {
        NFM_LEN_FAMILYNAME = 40,
        NFM_LEN_GIVENNAME = 40,
        NFM_LEN_TELNUMBER = 32
    };

    public struct NFM_PHONEBOOK
    {
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = (int)NFM_PB_LEN.NFM_LEN_FAMILYNAME)]
        public string wzFamilyName;
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = (int)NFM_PB_LEN.NFM_LEN_GIVENNAME)]
        public string wzGivenName;
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = (int)NFM_PB_LEN.NFM_LEN_TELNUMBER)]
        public string wzTel;
        public NFM_CONTACT_ATTR nfmCAttr;
    };

    public enum NFM_PB_ACCESS
    {
        NFM_PB_ACCESS_NULL = 0,
        NFM_PB_ACCESS_SIM,
        NFM_PB_ACCESS_PHONE,
        NFM_PB_ACCESS_MISSED,
        NFM_PB_ACCESS_RECEIVED,
        NFM_PB_ACCESS_DIALED
    }

    public enum NFM_HANDSFREE_STATE
    {
        NFM_HFSTATE_INITIALISING,
        NFM_HFSTATE_READY,
        NFM_HFSTATE_SLCCONNECTING,
        NFM_HFSTATE_SLCCONNECTED,
        NFM_HFSTATE_OUTGOINGCALLESTABLISH,
        NFM_HFSTATE_INCOMINGCALLESTABLISH,
        NFM_HFSTATE_ACTIVECALL
    };

    public enum NFM_HANDSFREE_SCO_STATE
    {
        NFM_HFSCOSTATE_OFF,
        NFM_HFSCOSTATE_ON
    };

    public enum NFM_VOICE_RECONG_STATE
    {
        NFM_VOICE_RECONG_STATE_OFF,
        NFM_VOICE_RECONG_STATE_ON,
        NFM_VOICE_RECONG_STATE_ERROR = 0xFF
    };
    
    
    
    public partial class CNForeBridge
    {
        const string _nForeMwDll = "nForeMW.dll";
        private IntPtr m_nfmHandle = IntPtr.Zero;

        public delegate NFM_CBK_RET NFM_CBK_POWERSTATUS(CNForeBridge theBridge, NFM_POWER nfmPower);
        public delegate NFM_CBK_RET NFM_CBK_GETPAIREDLIST(CNForeBridge theBridge, int nNum, IntPtr pPairedList);
        public delegate NFM_CBK_RET NFM_CBK_REMOTEPAIRREQUEST(CNForeBridge theBridge, NFM_ANSWERPAIR_STATE state, BT_ADDR ba);
        public delegate NFM_CBK_RET NFM_CBK_QUERYPAIRSERVICE(CNForeBridge theBridge, BT_ADDR ba, int nCount, IntPtr pProfileID);
        public delegate NFM_CBK_RET NFM_CBK_INQUIRYSTATUS(CNForeBridge theBridge, NFM_INQUIRY_STATE state, IntPtr pInquiryRemoteDevice);
        public delegate NFM_CBK_RET NFM_CBK_CONNECTIONSTATUS(CNForeBridge theBridge, BT_ADDR ba, NFM_PROFILEID ProfileID, NFM_CONNECTION_STATE state);
        public delegate NFM_CBK_RET NFM_CBK_DOWNLOADSTATUS(CNForeBridge theBridge, NFM_DOWNLOAD_TYPE type, NFM_DOWNLOAD_STATE state);
        public delegate NFM_CBK_RET NFM_CBK_CONTACTINFORM(CNForeBridge theBridge, NFM_PB_ACCESS PBAccess, IntPtr pwzFamilyName, IntPtr pwzGivenName, IntPtr pwzTel);
        public delegate NFM_CBK_RET NFM_CBK_HANDSFREESTATUS(CNForeBridge theBridge, BT_ADDR ba, NFM_HANDSFREE_STATE state);
        public delegate NFM_CBK_RET NFM_CBK_INCOMINGCALL(CNForeBridge theBridge, BT_ADDR ba, IntPtr pwzNumber);
        public delegate NFM_CBK_RET NFM_CBK_HANDSFREESCOSTATUS(CNForeBridge theBridge, BT_ADDR ba, NFM_HANDSFREE_SCO_STATE state);
        public delegate NFM_CBK_RET NFM_CBK_VOICERECONGSTATUS(CNForeBridge theBridge, BT_ADDR ba, NFM_VOICE_RECONG_STATE state);
        public delegate NFM_CBK_RET NFM_CBK_HANDSFREECURRENTCALL(CNForeBridge theBridge, BT_ADDR ba, IntPtr pwzNumber);

        private static NFM_CBK_POWERSTATUS m_pfnNfmCbkPowerStatus;
        private static NFM_CBK_GETPAIREDLIST m_pfnNfmCbkGetPairedList;
        private static NFM_CBK_REMOTEPAIRREQUEST m_pfnNfmCbkRemotePairRequest;
        private static NFM_CBK_QUERYPAIRSERVICE m_pfnNfmCbkQueryPairService;
        private static NFM_CBK_INQUIRYSTATUS m_pfnNfmCbkInquiryStatus;
        private static NFM_CBK_CONNECTIONSTATUS m_pfnNfmCbkConnectionStatus;
        private static NFM_CBK_DOWNLOADSTATUS m_pfnNfmCbkDownloadStatus;
        private static NFM_CBK_CONTACTINFORM m_pfnNfmCbkContactInform;
        private static NFM_CBK_HANDSFREESTATUS m_pfnNfmCbkHandsfreeStatus;
        private static NFM_CBK_INCOMINGCALL m_pfnNfmCbkIncomingCall;
        private static NFM_CBK_HANDSFREESCOSTATUS m_pfnNfmCbkHandsfreeSCOStatus;
        private static NFM_CBK_VOICERECONGSTATUS m_pfnNfmCbkVoiceRecongStatus;
        private static NFM_CBK_HANDSFREECURRENTCALL m_pfnNfmCbkHandsfreeCurrentCall;
        
        [DllImport("kernel32", CharSet = CharSet.Auto)]
        static extern IntPtr LoadLibrary(string lpLibFileName);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool FreeLibrary([In] IntPtr hModule);

            

        private static NFM_CBK_RET CBK_PowerStatus(CNForeBridge theBridge, NFM_POWER nfmPower)
        {
            theBridge.UI_UpdatePowerStatus(nfmPower);
            return NFM_CBK_RET.NFM_CBK_SUCCESS;
        }

        private static NFM_CBK_RET CBK_GetPairedList(CNForeBridge theBridge, int nNum, IntPtr pPairedList)
        {
            theBridge.UI_UpdatePairedList(nNum, pPairedList);
            return NFM_CBK_RET.NFM_CBK_SUCCESS;
        }

        private static NFM_CBK_RET CBK_RemotePairRequest(CNForeBridge theBridge, NFM_ANSWERPAIR_STATE state, BT_ADDR ba)
        {
            theBridge.UI_RemotePairRequest(state, ba);
            return NFM_CBK_RET.NFM_CBK_SUCCESS;
        }

        private static NFM_CBK_RET CBK_QueryPairService(CNForeBridge theBridge, BT_ADDR ba, int nCount, IntPtr pProfileID)
        {
            theBridge.UI_QueryPairService(ba, nCount, pProfileID);
            return NFM_CBK_RET.NFM_CBK_SUCCESS;
        }

        private static NFM_CBK_RET CBK_InquiryStatus(CNForeBridge theBridge, NFM_INQUIRY_STATE state, IntPtr pInquiryRemoteDevice)
        {
            theBridge.UI_InquiryStatus(state, pInquiryRemoteDevice);
            return NFM_CBK_RET.NFM_CBK_SUCCESS;
        }

        private static NFM_CBK_RET CBK_ConnectionStatus(CNForeBridge theBridge, BT_ADDR ba, NFM_PROFILEID ProfileID, NFM_CONNECTION_STATE state)
        {
            theBridge.UI_ConnectionStatus(ba, ProfileID, state);
            return NFM_CBK_RET.NFM_CBK_SUCCESS;
        }

        private static NFM_CBK_RET CBK_DownloadStatus(CNForeBridge theBridge, NFM_DOWNLOAD_TYPE type, NFM_DOWNLOAD_STATE state)
        {
            theBridge.UI_DownloadStatus(type, state);
            return NFM_CBK_RET.NFM_CBK_SUCCESS;
        }

        private static NFM_CBK_RET CBK_ContactInform(CNForeBridge theBridge, NFM_PB_ACCESS PBAccess, IntPtr pwzFamilyName, IntPtr pwzGivenName, IntPtr pwzTel)
        {
            theBridge.UI_ContactInform(PBAccess, pwzFamilyName, pwzGivenName, pwzTel);
            return NFM_CBK_RET.NFM_CBK_SUCCESS;
        }

        private static NFM_CBK_RET CBK_HandsfreeStatus(CNForeBridge theBridge, BT_ADDR ba, NFM_HANDSFREE_STATE state)
        {
            theBridge.UI_HandsfreeStatus(ba, state);
            return NFM_CBK_RET.NFM_CBK_SUCCESS;
        }

        private static NFM_CBK_RET CBK_IncomingCall(CNForeBridge theBridge, BT_ADDR ba, IntPtr pwzNumber)
        {
            theBridge.UI_IncomingCall(ba, pwzNumber);
            return NFM_CBK_RET.NFM_CBK_SUCCESS;
        }

        private static NFM_CBK_RET CBK_HandsfreeSCOStatus(CNForeBridge theBridge, BT_ADDR ba, NFM_HANDSFREE_SCO_STATE state)
        {
            theBridge.UI_HandsfreeSCOStatus(ba, state);
            return NFM_CBK_RET.NFM_CBK_SUCCESS;
        }

        private static NFM_CBK_RET CBK_VoiceRecongStatus(CNForeBridge theBridge, BT_ADDR ba, NFM_VOICE_RECONG_STATE state)
        {
            theBridge.UI_VoiceRecongStatus(ba, state);
            return NFM_CBK_RET.NFM_CBK_SUCCESS;
        }

        private static NFM_CBK_RET CBK_HandsfreeCurrentCall(CNForeBridge theBridge, BT_ADDR ba, IntPtr pwzNumber)
        {
            theBridge.UI_HandsfreeCurrentCall(ba, pwzNumber);
            return NFM_CBK_RET.NFM_CBK_SUCCESS;
        }

        static CNForeBridge()
        {
            m_pfnNfmCbkPowerStatus = new NFM_CBK_POWERSTATUS(CBK_PowerStatus);
            m_pfnNfmCbkGetPairedList = new NFM_CBK_GETPAIREDLIST(CBK_GetPairedList);
            m_pfnNfmCbkRemotePairRequest = new NFM_CBK_REMOTEPAIRREQUEST(CBK_RemotePairRequest);
            m_pfnNfmCbkQueryPairService = new NFM_CBK_QUERYPAIRSERVICE(CBK_QueryPairService);
            m_pfnNfmCbkInquiryStatus = new NFM_CBK_INQUIRYSTATUS(CBK_InquiryStatus);
            m_pfnNfmCbkConnectionStatus = new NFM_CBK_CONNECTIONSTATUS(CBK_ConnectionStatus);
            m_pfnNfmCbkDownloadStatus = new NFM_CBK_DOWNLOADSTATUS(CBK_DownloadStatus);
            m_pfnNfmCbkContactInform = new NFM_CBK_CONTACTINFORM(CBK_ContactInform);
            m_pfnNfmCbkHandsfreeStatus = new NFM_CBK_HANDSFREESTATUS(CBK_HandsfreeStatus);
            m_pfnNfmCbkIncomingCall = new NFM_CBK_INCOMINGCALL(CBK_IncomingCall);
            m_pfnNfmCbkHandsfreeSCOStatus = new NFM_CBK_HANDSFREESCOSTATUS(CBK_HandsfreeSCOStatus);
            m_pfnNfmCbkVoiceRecongStatus = new NFM_CBK_VOICERECONGSTATUS(CBK_VoiceRecongStatus);
            m_pfnNfmCbkHandsfreeCurrentCall = new NFM_CBK_HANDSFREECURRENTCALL(CBK_HandsfreeCurrentCall);
        }

        [DllImport(_nForeMwDll)]
        public static extern NFM_CMD_RET nfmCmdSetCbk_PowerStatus(IntPtr nfmHandle, NFM_CBK_POWERSTATUS pfn);
        [DllImport(_nForeMwDll)]
        public static extern NFM_CMD_RET nfmCmdSetCbk_GetPairedList(IntPtr nfmHandle, NFM_CBK_GETPAIREDLIST pfn);
        [DllImport(_nForeMwDll)]
        public static extern NFM_CMD_RET nfmCmdSetCbk_RemotePairRequest(IntPtr nfmHandle, NFM_CBK_REMOTEPAIRREQUEST pfn);
        [DllImport(_nForeMwDll)]
        public static extern NFM_CMD_RET nfmCmdSetCbk_QueryPairService(IntPtr nfmHandle, NFM_CBK_QUERYPAIRSERVICE pfn);
        [DllImport(_nForeMwDll)]
        public static extern NFM_CMD_RET nfmCmdSetCbk_InquiryStatus(IntPtr nfmHandle, NFM_CBK_INQUIRYSTATUS pfn);
        [DllImport(_nForeMwDll)]
        public static extern NFM_CMD_RET nfmCmdSetCbk_ConnectionStatus(IntPtr nfmHandle, NFM_CBK_CONNECTIONSTATUS pfn);
        [DllImport(_nForeMwDll)]
        public static extern NFM_CMD_RET nfmCmdSetCbk_DownloadStatus(IntPtr nfmHandle, NFM_CBK_DOWNLOADSTATUS pfn);
        [DllImport(_nForeMwDll)]
        public static extern NFM_CMD_RET nfmCmdSetCbk_ContactInform(IntPtr nfmHandle, NFM_CBK_CONTACTINFORM pfn);
        [DllImport(_nForeMwDll)]
        public static extern NFM_CMD_RET nfmCmdSetCbk_HandsfreeStatus(IntPtr nfmHandle, NFM_CBK_HANDSFREESTATUS pfn);
        [DllImport(_nForeMwDll)]
        public static extern NFM_CMD_RET nfmCmdSetCbk_IncomingCall(IntPtr nfmHandle, NFM_CBK_INCOMINGCALL pfn);
        [DllImport(_nForeMwDll)]
        public static extern NFM_CMD_RET nfmCmdSetCbk_HandsfreeScoStatus(IntPtr nfmHandle, NFM_CBK_HANDSFREESCOSTATUS pfn);
        [DllImport(_nForeMwDll)]
        public static extern NFM_CMD_RET nfmCmdSetCbk_VoiceRecongStatus(IntPtr nfmHandle, NFM_CBK_VOICERECONGSTATUS pfn);
        [DllImport(_nForeMwDll)]
        public static extern NFM_CMD_RET nfmCmdSetCbk_HandsfreeCurrentCall(IntPtr nfmHandle, NFM_CBK_HANDSFREECURRENTCALL pfn);

        [DllImport(_nForeMwDll)]
        public static extern NFM_CMD_RET nfmCmdStartup(out IntPtr nfmHandle, CNForeBridge theBridge);
        public bool CMD_Startup()
        {
            NFM_CMD_RET nRet = nfmCmdStartup(out m_nfmHandle, this);
            if (nRet > NFM_CMD_RET.NFM_CMD_SUCCESS_FIRST && nRet < NFM_CMD_RET.NFM_CMD_SUCCESS_LAST)
            {
                nfmCmdSetCbk_PowerStatus(m_nfmHandle, m_pfnNfmCbkPowerStatus);
                nfmCmdSetCbk_GetPairedList(m_nfmHandle, m_pfnNfmCbkGetPairedList);
                nfmCmdSetCbk_RemotePairRequest(m_nfmHandle, m_pfnNfmCbkRemotePairRequest);
                nfmCmdSetCbk_QueryPairService(m_nfmHandle, m_pfnNfmCbkQueryPairService);
                nfmCmdSetCbk_InquiryStatus(m_nfmHandle, m_pfnNfmCbkInquiryStatus);
                nfmCmdSetCbk_ConnectionStatus(m_nfmHandle, m_pfnNfmCbkConnectionStatus);
                nfmCmdSetCbk_DownloadStatus(m_nfmHandle, m_pfnNfmCbkDownloadStatus);
                nfmCmdSetCbk_ContactInform(m_nfmHandle, m_pfnNfmCbkContactInform);
                nfmCmdSetCbk_HandsfreeStatus(m_nfmHandle, m_pfnNfmCbkHandsfreeStatus);
                nfmCmdSetCbk_IncomingCall(m_nfmHandle, m_pfnNfmCbkIncomingCall);
                nfmCmdSetCbk_HandsfreeScoStatus(m_nfmHandle, m_pfnNfmCbkHandsfreeSCOStatus);
                nfmCmdSetCbk_VoiceRecongStatus(m_nfmHandle, m_pfnNfmCbkVoiceRecongStatus);
                nfmCmdSetCbk_HandsfreeCurrentCall(m_nfmHandle, m_pfnNfmCbkHandsfreeCurrentCall);
                return true;
            }
            else
                return false;
        }

        [DllImport(_nForeMwDll)]
        public static extern NFM_CMD_RET nfmCmdEnd(IntPtr nfmHandle);
        public bool CMD_End()
        {
            NFM_CMD_RET nRet = nfmCmdEnd(m_nfmHandle);
            if (nRet > NFM_CMD_RET.NFM_CMD_SUCCESS_FIRST && nRet < NFM_CMD_RET.NFM_CMD_SUCCESS_LAST)
                return true;
            else
                return false;
        }

        [DllImport(_nForeMwDll)]
        public static extern NFM_CMD_RET nfmCmdGetMwVersion(out NFM_VER ver);
        public bool CMD_GetMwVersion(out NFM_VER ver)
        {
            NFM_CMD_RET nRet = nfmCmdGetMwVersion(out ver);
            if (nRet > NFM_CMD_RET.NFM_CMD_SUCCESS_FIRST && nRet < NFM_CMD_RET.NFM_CMD_SUCCESS_LAST)
                return true;
            else
                return false;
        }

        [DllImport(_nForeMwDll)]
        public static extern NFM_CMD_RET nfmCmdGetLocalBtAddr(IntPtr nfmHandle, out BT_ADDR ba);
        public bool CMD_GetLocalBtAddr(out BT_ADDR ba)
        {
            NFM_CMD_RET nRet = nfmCmdGetLocalBtAddr(m_nfmHandle, out ba);
            if (nRet > NFM_CMD_RET.NFM_CMD_SUCCESS_FIRST && nRet < NFM_CMD_RET.NFM_CMD_SUCCESS_LAST)
                return true;
            else
                return false;
        }

        [DllImport(_nForeMwDll)]
        public unsafe static extern NFM_CMD_RET nfmCmdGetLocalDeviceName(IntPtr nfmHandle, WCHAR* pwzDevName, uint nDevName);
        public bool CMD_GetLocalDeviceName(WCHAR[] pwzDevName, uint nDevName)
        {
            unsafe
            {
                fixed (WCHAR* p = pwzDevName)
                {
                    NFM_CMD_RET nRet = nfmCmdGetLocalDeviceName(m_nfmHandle, p, nDevName);
                    if (nRet > NFM_CMD_RET.NFM_CMD_SUCCESS_FIRST && nRet < NFM_CMD_RET.NFM_CMD_SUCCESS_LAST)
                        return true;
                    else
                        return false;
                }
            }
        }

        [DllImport(_nForeMwDll)]
        public unsafe static extern NFM_CMD_RET nfmCmdSetLocalDeviceName(IntPtr nfmHandle, WCHAR* pwzDevName, uint nDevName);
        public bool CMD_SetLocalDeviceName(WCHAR[] pwzDevName, uint nDevName)
        {
            unsafe
            {
                fixed (WCHAR* p = pwzDevName)
                {
                    NFM_CMD_RET nRet = nfmCmdSetLocalDeviceName(m_nfmHandle, p, nDevName);
                    if (nRet > NFM_CMD_RET.NFM_CMD_SUCCESS_FIRST && nRet < NFM_CMD_RET.NFM_CMD_SUCCESS_LAST)
                        return true;
                    else
                        return false;
                }
            }
        }

        [DllImport(_nForeMwDll)]
        public static extern NFM_CMD_RET nfmCmdGetCOD(IntPtr nfmHandle, out uint cod);
        public bool CMD_GetCOD(out uint cod)
        {
            NFM_CMD_RET nRet = nfmCmdGetCOD(m_nfmHandle, out cod);
            if (nRet > NFM_CMD_RET.NFM_CMD_SUCCESS_FIRST && nRet < NFM_CMD_RET.NFM_CMD_SUCCESS_LAST)
                return true;
            else
                return false;
        }

        [DllImport(_nForeMwDll)]
        public static extern NFM_CMD_RET nfmCmdSetCOD(IntPtr nfmHandle, uint cod);
        public bool CMD_SetCOD(uint cod)
        {
            NFM_CMD_RET nRet = nfmCmdSetCOD(m_nfmHandle, cod);
            if (nRet > NFM_CMD_RET.NFM_CMD_SUCCESS_FIRST && nRet < NFM_CMD_RET.NFM_CMD_SUCCESS_LAST)
                return true;
            else
                return false;
        }

        [DllImport(_nForeMwDll)]
        public static extern NFM_CMD_RET nfmCmdGetScanEnable(IntPtr nfmHandle, out byte mask);
        public bool CMD_GetScanEnable(out byte mask)
        {
            NFM_CMD_RET nRet = nfmCmdGetScanEnable(m_nfmHandle, out mask);
            if (nRet > NFM_CMD_RET.NFM_CMD_SUCCESS_FIRST && nRet < NFM_CMD_RET.NFM_CMD_SUCCESS_LAST)
                return true;
            else
                return false;
        }

        [DllImport(_nForeMwDll)]
        public static extern NFM_CMD_RET nfmCmdSetScanEnable(IntPtr nfmHandle, byte mask);
        public bool CMD_SetScanEnable(byte mask)
        {
            NFM_CMD_RET nRet = nfmCmdSetScanEnable(m_nfmHandle, mask);
            if (nRet > NFM_CMD_RET.NFM_CMD_SUCCESS_FIRST && nRet < NFM_CMD_RET.NFM_CMD_SUCCESS_LAST)
                return true;
            else
                return false;
        }

        [DllImport(_nForeMwDll)]
        public static extern NFM_CMD_RET nfmCmdGetAuthEnable(IntPtr nfmHandle, out byte ae);
        public bool CMD_GetAuthEnable(out byte ae)
        {
            NFM_CMD_RET nRet = nfmCmdGetAuthEnable(m_nfmHandle, out ae);
            if (nRet > NFM_CMD_RET.NFM_CMD_SUCCESS_FIRST && nRet < NFM_CMD_RET.NFM_CMD_SUCCESS_LAST)
                return true;
            else
                return false;
        }

        [DllImport(_nForeMwDll)]
        public static extern NFM_CMD_RET nfmCmdSetAuthEnable(IntPtr nfmHandle, byte ae);
        public bool CMD_SetAuthEnable(byte ae)
        {
            NFM_CMD_RET nRet = nfmCmdSetAuthEnable(m_nfmHandle, ae);
            if (nRet > NFM_CMD_RET.NFM_CMD_SUCCESS_FIRST && nRet < NFM_CMD_RET.NFM_CMD_SUCCESS_LAST)
                return true;
            else
                return false;
        }

        [DllImport(_nForeMwDll)]
        public static extern NFM_CMD_RET nfmCmdGetPower(IntPtr nfmHandle, out NFM_POWER nfmPower);
        public bool CMD_GetPower(out NFM_POWER nfmPower)
        {
            NFM_CMD_RET nRet = nfmCmdGetPower(m_nfmHandle, out nfmPower);
            if (nRet > NFM_CMD_RET.NFM_CMD_SUCCESS_FIRST && nRet < NFM_CMD_RET.NFM_CMD_SUCCESS_LAST)
                return true;
            else
                return false;
        }

        [DllImport(_nForeMwDll)]
        public static extern NFM_CMD_RET nfmCmdSetPower(IntPtr nfmHandle, NFM_POWER nfmPower);
        public bool CMD_SetPower(NFM_POWER nfmPower)
        {
            NFM_CMD_RET nRet = nfmCmdSetPower(m_nfmHandle, nfmPower);
            if (nRet > NFM_CMD_RET.NFM_CMD_SUCCESS_FIRST && nRet < NFM_CMD_RET.NFM_CMD_SUCCESS_LAST)
                return true;
            else
                return false;
        }

        [DllImport(_nForeMwDll)]
        public static extern NFM_CMD_RET nfmCmdGetPairedList(IntPtr nfmHandle);
        public bool CMD_GetPairedList()
        {
            NFM_CMD_RET nRet = nfmCmdGetPairedList(m_nfmHandle);
            if (nRet > NFM_CMD_RET.NFM_CMD_SUCCESS_FIRST && nRet < NFM_CMD_RET.NFM_CMD_SUCCESS_LAST)
                return true;
            else
                return false;
        }

        [DllImport(_nForeMwDll)]
        public unsafe static extern NFM_CMD_RET nfmCmdPairRequest(IntPtr nfmHandle, ref BT_ADDR ba, int nPinLength, byte* ppin);
        public bool CMD_PairRequest(ref BT_ADDR ba, int nPinLength, byte[] ppin)
        {
            unsafe
            {
                fixed (byte* p = ppin)
                {
                    NFM_CMD_RET nRet = nfmCmdPairRequest(m_nfmHandle, ref ba, nPinLength, p);
                    if (nRet > NFM_CMD_RET.NFM_CMD_SUCCESS_FIRST && nRet < NFM_CMD_RET.NFM_CMD_SUCCESS_LAST)
                        return true;
                    else
                        return false;
                }
            }
        }

        [DllImport(_nForeMwDll)]
        public static extern NFM_CMD_RET nfmCmdDeletePairDevice(IntPtr nfmHandle, ref BT_ADDR ba);
        public bool CMD_DeletePairDevice(ref BT_ADDR ba)
        {
            NFM_CMD_RET nRet = nfmCmdDeletePairDevice(m_nfmHandle, ref ba);
            if (nRet > NFM_CMD_RET.NFM_CMD_SUCCESS_FIRST && nRet < NFM_CMD_RET.NFM_CMD_SUCCESS_LAST)
                return true;
            else
                return false;
        }

        [DllImport(_nForeMwDll)]
        public unsafe static extern NFM_CMD_RET nfmCmdAnswerPair(IntPtr nfmHandle, ref BT_ADDR ba, int nPinLength, byte* ppin);
        public bool CMD_AnswerPair(ref BT_ADDR ba, int nPinLength, byte[] ppin)
        {
            unsafe
            {
                fixed (byte* p = ppin)
                {
                    NFM_CMD_RET nRet = nfmCmdAnswerPair(m_nfmHandle, ref ba, nPinLength, p);
                    if (nRet > NFM_CMD_RET.NFM_CMD_SUCCESS_FIRST && nRet < NFM_CMD_RET.NFM_CMD_SUCCESS_LAST)
                        return true;
                    else
                        return false;
                }
            }
        }

        [DllImport(_nForeMwDll)]
        public static extern NFM_CMD_RET nfmCmdRefusePair(IntPtr nfmHandle, ref BT_ADDR ba);
        public bool CMD_RefusePair(ref BT_ADDR ba)
        {
            NFM_CMD_RET nRet = nfmCmdRefusePair(m_nfmHandle, ref ba);
            if (nRet > NFM_CMD_RET.NFM_CMD_SUCCESS_FIRST && nRet < NFM_CMD_RET.NFM_CMD_SUCCESS_LAST)
                return true;
            else
                return false;
        }

        [DllImport(_nForeMwDll)]
        public static extern NFM_CMD_RET nfmCmdQueryPairService(IntPtr nfmHandle, ref BT_ADDR ba);
        public bool CMD_QueryPairService(ref BT_ADDR ba)
        {
            NFM_CMD_RET nRet = nfmCmdQueryPairService(m_nfmHandle, ref ba);
            if (nRet > NFM_CMD_RET.NFM_CMD_SUCCESS_FIRST && nRet < NFM_CMD_RET.NFM_CMD_SUCCESS_LAST)
                return true;
            else
                return false;
        }

        [DllImport(_nForeMwDll)]
        public static extern NFM_CMD_RET nfmCmdInquiryStart(IntPtr nfmHandle);
        public bool CMD_InquiryStart()
        {
            NFM_CMD_RET nRet = nfmCmdInquiryStart(m_nfmHandle);
            if (nRet > NFM_CMD_RET.NFM_CMD_SUCCESS_FIRST && nRet < NFM_CMD_RET.NFM_CMD_SUCCESS_LAST)
                return true;
            else
                return false;
        }

        [DllImport(_nForeMwDll)]
        public static extern NFM_CMD_RET nfmCmdInquiryStop(IntPtr nfmHandle);
        public bool CMD_InquiryStop()
        {
            NFM_CMD_RET nRet = nfmCmdInquiryStop(m_nfmHandle);
            if (nRet > NFM_CMD_RET.NFM_CMD_SUCCESS_FIRST && nRet < NFM_CMD_RET.NFM_CMD_SUCCESS_LAST)
                return true;
            else
                return false;
        }

        [DllImport(_nForeMwDll)]
        public static extern NFM_CMD_RET nfmCmdConnectRemoteDevice(IntPtr nfmHandle, ref BT_ADDR ba, NFM_PROFILEID ProfileID);
        public bool CMD_ConnectRemoteDevice(ref BT_ADDR ba, NFM_PROFILEID ProfileID)
        {
            NFM_CMD_RET nRet = nfmCmdConnectRemoteDevice(m_nfmHandle, ref ba, ProfileID);
            if (nRet > NFM_CMD_RET.NFM_CMD_SUCCESS_FIRST && nRet < NFM_CMD_RET.NFM_CMD_SUCCESS_LAST)
                return true;
            else
                return false;
        }

        [DllImport(_nForeMwDll)]
        public static extern NFM_CMD_RET nfmCmdDisconnectRemoteDevice(IntPtr nfmHandle, ref BT_ADDR ba, NFM_PROFILEID ProfileID);
        public bool CMD_DisconnectRemoteDevice(ref BT_ADDR ba, NFM_PROFILEID ProfileID)
        {
            NFM_CMD_RET nRet = nfmCmdDisconnectRemoteDevice(m_nfmHandle, ref ba, ProfileID);
            if (nRet > NFM_CMD_RET.NFM_CMD_SUCCESS_FIRST && nRet < NFM_CMD_RET.NFM_CMD_SUCCESS_LAST)
                return true;
            else
                return false;
        }

        [DllImport(_nForeMwDll)]
        public unsafe static extern NFM_CMD_RET nfmCmdGetRemoteName(IntPtr nfmHandle, ref BT_ADDR ba, WCHAR* strDevName);
        public bool CMD_GetRemoteName(ref BT_ADDR ba, WCHAR[] strDevName)
        {
            unsafe
            {
                fixed (WCHAR* p = strDevName)
                {
                    NFM_CMD_RET nRet = nfmCmdGetRemoteName(m_nfmHandle, ref ba, p);
                    if (nRet > NFM_CMD_RET.NFM_CMD_SUCCESS_FIRST && nRet < NFM_CMD_RET.NFM_CMD_SUCCESS_LAST)
                        return true;
                    else
                        return false;
                }
            }
        }

        [DllImport(_nForeMwDll)]
        public static extern NFM_CMD_RET nfmCmdGetCallHistoryStart(IntPtr nfmHandle, ref BT_ADDR ba, NFM_PB_ACCESS iCHStorage);
        public bool CMD_GetCallHistoryStart(ref BT_ADDR ba, NFM_PB_ACCESS iCHStorage)
        {
            NFM_CMD_RET nRet = nfmCmdGetCallHistoryStart(m_nfmHandle, ref ba, iCHStorage);
            if (nRet > NFM_CMD_RET.NFM_CMD_SUCCESS_FIRST && nRet < NFM_CMD_RET.NFM_CMD_SUCCESS_LAST)
                return true;
            else
                return false;
        }

        [DllImport(_nForeMwDll)]
        public static extern NFM_CMD_RET nfmCmdDownloadPhonebookStart(IntPtr nfmHandle, ref BT_ADDR ba);
        public bool CMD_DownloadPhonebookStart(ref BT_ADDR ba)
        {
            NFM_CMD_RET nRet = nfmCmdDownloadPhonebookStart(m_nfmHandle, ref ba);
            if (nRet > NFM_CMD_RET.NFM_CMD_SUCCESS_FIRST && nRet < NFM_CMD_RET.NFM_CMD_SUCCESS_LAST)
                return true;
            else
                return false;
        }

        [DllImport(_nForeMwDll)]
        public static extern NFM_CMD_RET nfmCmdDownloadPhonebookStop(IntPtr nfmHandle, ref BT_ADDR ba);
        public bool CMD_DownloadPhonebookStop(ref BT_ADDR ba)
        {
            NFM_CMD_RET nRet = nfmCmdDownloadPhonebookStop(m_nfmHandle, ref ba);
            if (nRet > NFM_CMD_RET.NFM_CMD_SUCCESS_FIRST && nRet < NFM_CMD_RET.NFM_CMD_SUCCESS_LAST)
                return true;
            else
                return false;
        }

        [DllImport(_nForeMwDll)]
        public unsafe static extern NFM_CMD_RET nfmCmdDialCall(IntPtr nfmHandle, ref BT_ADDR ba, WCHAR* pwzNumber);
        public bool CMD_DialCall(ref BT_ADDR ba, WCHAR[] pwzNumber)
        {
            unsafe
            {
                fixed (WCHAR* p = pwzNumber)
                {
                    NFM_CMD_RET nRet = nfmCmdDialCall(m_nfmHandle, ref ba, p);
                    if (nRet > NFM_CMD_RET.NFM_CMD_SUCCESS_FIRST && nRet < NFM_CMD_RET.NFM_CMD_SUCCESS_LAST)
                        return true;
                    else
                        return false;
                }
            }
        }

        [DllImport(_nForeMwDll)]
        public static extern NFM_CMD_RET nfmCmdDialLast(IntPtr nfmHandle, ref BT_ADDR ba);
        public bool CMD_DialLast(ref BT_ADDR ba)
        {
            NFM_CMD_RET nRet = nfmCmdDialLast(m_nfmHandle, ref ba);
            if (nRet > NFM_CMD_RET.NFM_CMD_SUCCESS_FIRST && nRet < NFM_CMD_RET.NFM_CMD_SUCCESS_LAST)
                return true;
            else
                return false;
        }

        [DllImport(_nForeMwDll)]
        public static extern NFM_CMD_RET nfmCmdVoiceDial(IntPtr nfmHandle, ref BT_ADDR ba, int bActive);
        public bool CMD_VoiceDial(ref BT_ADDR ba, int bActive)
        {
            NFM_CMD_RET nRet = nfmCmdVoiceDial(m_nfmHandle, ref ba, bActive);
            if (nRet > NFM_CMD_RET.NFM_CMD_SUCCESS_FIRST && nRet < NFM_CMD_RET.NFM_CMD_SUCCESS_LAST)
                return true;
            else
                return false;
        }

        [DllImport(_nForeMwDll)]
        public static extern NFM_CMD_RET nfmCmdAudioTransfer(IntPtr nfmHandle, ref BT_ADDR ba, int iActive);
        public bool CMD_AudioTransfer(ref BT_ADDR ba, int iActive)
        {
            NFM_CMD_RET nRet = nfmCmdAudioTransfer(m_nfmHandle, ref ba, iActive);
            if (nRet > NFM_CMD_RET.NFM_CMD_SUCCESS_FIRST && nRet < NFM_CMD_RET.NFM_CMD_SUCCESS_LAST)
                return true;
            else
                return false;
        }

        [DllImport(_nForeMwDll)]
        public unsafe static extern NFM_CMD_RET nfmCmdTransmitDTMFCode(IntPtr nfmHandle, ref BT_ADDR ba, WCHAR* pwzNumber);
        public bool CMD_TransmitDTMFCode(ref BT_ADDR ba, WCHAR[] pwzNumber)
        {
            unsafe
            {
                fixed (WCHAR* p = pwzNumber)
                {
                    NFM_CMD_RET nRet = nfmCmdTransmitDTMFCode(m_nfmHandle, ref ba, p);
                    if (nRet > NFM_CMD_RET.NFM_CMD_SUCCESS_FIRST && nRet < NFM_CMD_RET.NFM_CMD_SUCCESS_LAST)
                        return true;
                    else
                        return false;
                }
            }
        }

        [DllImport(_nForeMwDll)]
        public static extern NFM_CMD_RET nfmCmdAnswerCall(IntPtr nfmHandle, ref BT_ADDR ba);
        public bool CMD_AnswerCall(ref BT_ADDR ba)
        {
            NFM_CMD_RET nRet = nfmCmdAnswerCall(m_nfmHandle, ref ba);
            if (nRet > NFM_CMD_RET.NFM_CMD_SUCCESS_FIRST && nRet < NFM_CMD_RET.NFM_CMD_SUCCESS_LAST)
                return true;
            else
                return false;
        }

        [DllImport(_nForeMwDll)]
        public static extern NFM_CMD_RET nfmCmdRejectCall(IntPtr nfmHandle, ref BT_ADDR ba);
        public bool CMD_RejectCall(ref BT_ADDR ba)
        {
            NFM_CMD_RET nRet = nfmCmdRejectCall(m_nfmHandle, ref ba);
            if (nRet > NFM_CMD_RET.NFM_CMD_SUCCESS_FIRST && nRet < NFM_CMD_RET.NFM_CMD_SUCCESS_LAST)
                return true;
            else
                return false;
        }

        [DllImport(_nForeMwDll)]
        public static extern NFM_CMD_RET nfmCmdTerminateCall(IntPtr nfmHandle, ref BT_ADDR ba);
        public bool CMD_TerminateCall(ref BT_ADDR ba)
        {
            NFM_CMD_RET nRet = nfmCmdTerminateCall(m_nfmHandle, ref ba);
            if (nRet > NFM_CMD_RET.NFM_CMD_SUCCESS_FIRST && nRet < NFM_CMD_RET.NFM_CMD_SUCCESS_LAST)
                return true;
            else
                return false;
        }

        [DllImport(_nForeMwDll)]
        public static extern NFM_CMD_RET nfmCmdGetCurrentCall(IntPtr nfmHandle, ref BT_ADDR ba);
        public bool CMD_GetCurrentCall(ref BT_ADDR ba)
        {
            NFM_CMD_RET nRet = nfmCmdGetCurrentCall(m_nfmHandle, ref ba);
            if (nRet > NFM_CMD_RET.NFM_CMD_SUCCESS_FIRST && nRet < NFM_CMD_RET.NFM_CMD_SUCCESS_LAST)
                return true;
            else
                return false;
        }
        
        [DllImport(_nForeMwDll)]
        public unsafe static extern NFM_CMD_RET nfmCmdCreateRasEntry(WCHAR* szAPN, WCHAR* lpszUserName, WCHAR* lpszPassWord, WCHAR* lpszPhoneNumber);
        public bool CMD_CreateRasEntry(WCHAR[] szAPN, WCHAR[] lpszUserName, WCHAR[] lpszPassWord, WCHAR[] lpszPhoneNumber)
        {
            unsafe
            {
                fixed (WCHAR* p = szAPN, q = lpszUserName, r = lpszPassWord, s = lpszPhoneNumber)
                {
                    NFM_CMD_RET nRet = nfmCmdCreateRasEntry(p, q, r, s);
                    if (nRet > NFM_CMD_RET.NFM_CMD_SUCCESS_FIRST && nRet < NFM_CMD_RET.NFM_CMD_SUCCESS_LAST)
                        return true;
                    else
                        return false;
                }
            }
        }
        
        [DllImport(_nForeMwDll)]
        public static extern NFM_CMD_RET nfmCmdRemoveRasEntry();
        public bool CMD_RemoveRasEntry()
        {
            NFM_CMD_RET nRet = nfmCmdRemoveRasEntry();
            if (nRet > NFM_CMD_RET.NFM_CMD_SUCCESS_FIRST && nRet < NFM_CMD_RET.NFM_CMD_SUCCESS_LAST)
                return true;
            else
                return false;
        }
        
        [DllImport(_nForeMwDll)]
        public static extern NFM_CMD_RET nfmCmdDunDialUp(IntPtr pParam);
        public bool CMD_DunDialUp(IntPtr pParam)
        {
            NFM_CMD_RET nRet = nfmCmdDunDialUp(pParam);
            if (nRet > NFM_CMD_RET.NFM_CMD_SUCCESS_FIRST && nRet < NFM_CMD_RET.NFM_CMD_SUCCESS_LAST)
                return true;
            else
                return false;
        }
        
        [DllImport(_nForeMwDll)]
        public static extern NFM_CMD_RET nfmCmdDunHangUp();
        public bool CMD_DunHangUp()
        {
            NFM_CMD_RET nRet = nfmCmdDunHangUp();
            if (nRet > NFM_CMD_RET.NFM_CMD_SUCCESS_FIRST && nRet < NFM_CMD_RET.NFM_CMD_SUCCESS_LAST)
                return true;
            else
                return false;
        }
        
        [DllImport(_nForeMwDll)]
        public unsafe static extern NFM_CMD_RET nfmCmdGetRasConnString(WCHAR* RasConnString);
        public bool CMD_GetRasConnString(WCHAR[] RasConnString)
        {
            unsafe
            {
                fixed (WCHAR* p = RasConnString)
                {
                    NFM_CMD_RET nRet = nfmCmdGetRasConnString(p);
                    if (nRet > NFM_CMD_RET.NFM_CMD_SUCCESS_FIRST && nRet < NFM_CMD_RET.NFM_CMD_SUCCESS_LAST)
                        return true;
                    else
                        return false;
                }
            }
        }
    }
}