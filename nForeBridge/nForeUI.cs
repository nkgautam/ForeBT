
using System;

using BT_ADDR = System.UInt64;
using WCHAR = System.Char;

namespace PND
{
public partial class CNForeBridge
{
	public void UI_UpdatePowerStatus(NFM_POWER nfmPower)
	{
	}
	public void UI_UpdatePairedList(int nNum, IntPtr pPairedList)
	{
	}
	public void UI_RemotePairRequest(NFM_ANSWERPAIR_STATE state, BT_ADDR ba)
	{
	}
	public void UI_QueryPairService(BT_ADDR ba, int nCount, IntPtr UI_QueryPairService)
	{
	}
	public void UI_InquiryStatus(NFM_INQUIRY_STATE state, IntPtr pInquiryRemoteDevice)
	{
	}
	public void UI_ConnectionStatus(BT_ADDR ba, NFM_PROFILEID ProfileID, NFM_CONNECTION_STATE state)
	{
	}
	public void UI_DownloadStatus(NFM_DOWNLOAD_TYPE type, NFM_DOWNLOAD_STATE state)
	{
	}
    public void UI_ContactInform(NFM_PB_ACCESS PBAccess, IntPtr pwzFamilyName, IntPtr pwzGivenName, IntPtr pwzTel)
	{
	}
	public void UI_HandsfreeStatus(BT_ADDR ba, NFM_HANDSFREE_STATE state)
	{
	}
	public void UI_IncomingCall(BT_ADDR ba, IntPtr pwzNumber)
	{
	}
	public void UI_HandsfreeSCOStatus(BT_ADDR ba, NFM_HANDSFREE_SCO_STATE state)
	{
	}
	public void UI_VoiceRecongStatus(BT_ADDR ba, NFM_VOICE_RECONG_STATE state)
	{
	}
	public void UI_HandsfreeCurrentCall(BT_ADDR ba, IntPtr pwzNumber)
	{
	}
    }
}
