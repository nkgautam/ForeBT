using System;

using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PND;

namespace nforeBT
{

    public partial class Form1 : Form
    {
        int		i_HandsfreeSCOStatus = 0;
        int		i_VoiceRecongStatus = 0;
        int m_nPBCount;
        String NFM_CMD_RET_STR_OK = "Ok";
		String NFM_CMD_RET_STR_FAIL = "Fail";
        public Form1()
        {
            InitializeComponent();
            AddCommandToList();
        }

        private void AddCommandToList()
        {
            this.comboBox1.BeginUpdate();
            this.comboBox1.Items.Add("startup");
	        this.comboBox1.Items.Add("end");
	        this.comboBox1.Items.Add("mw version");
	        this.comboBox1.Items.Add("mw state");
	        this.comboBox1.Items.Add("power on");
	        this.comboBox1.Items.Add("power off");
	        this.comboBox1.Items.Add("power status");
	        this.comboBox1.Items.Add("pair List");
	        this.comboBox1.Items.Add("pair request");
	        this.comboBox1.Items.Add("pair delete");
	        this.comboBox1.Items.Add("pair answer");
	        this.comboBox1.Items.Add("pair refuse");
	        this.comboBox1.Items.Add("pair service");
	        this.comboBox1.Items.Add("inquiry start");
	        this.comboBox1.Items.Add("inquiry stop");
	        this.comboBox1.Items.Add("local btaddr");
	        this.comboBox1.Items.Add("local name get");
	        this.comboBox1.Items.Add("local name set");
	        this.comboBox1.Items.Add("local cod get");
	        this.comboBox1.Items.Add("local cod set");
	        this.comboBox1.Items.Add("local scanenable get");
	        this.comboBox1.Items.Add("local scanenable set");
	        this.comboBox1.Items.Add("local authenable get");
	        this.comboBox1.Items.Add("local authenable set");
	        this.comboBox1.Items.Add("remote connect");
	        this.comboBox1.Items.Add("remote disconnect");
	        this.comboBox1.Items.Add("remote name");
	        this.comboBox1.Items.Add("phonebook download");
	        this.comboBox1.Items.Add("phonebook count");
	        this.comboBox1.Items.Add("phonebook get");
	        this.comboBox1.Items.Add("call answer");
	        this.comboBox1.Items.Add("call reject");
	        this.comboBox1.Items.Add("call terminate");
	        this.comboBox1.Items.Add("call dial");
	        this.comboBox1.Items.Add("call dtmf");
	        this.comboBox1.Items.Add("call redial");
	        this.comboBox1.Items.Add("call voicedial");
	        this.comboBox1.Items.Add("call audiotransfer");
	        this.comboBox1.Items.Add("call currentcall");
	        this.comboBox1.Items.Add("call history mc");
	        this.comboBox1.Items.Add("call history rc");
	        this.comboBox1.Items.Add("call history dc");
	        this.comboBox1.Items.Add("dun create_entry");
	        this.comboBox1.Items.Add("dun remove_entry");
	        this.comboBox1.Items.Add("dun dialup");
	        this.comboBox1.Items.Add("dun hangup");
	        this.comboBox1.Items.Add("dun get_ras_status");
            this.comboBox1.EndUpdate();


        }
        private bool SpliteCmdLine()
        {
            return false;
        }
        private void ShowMessage(String msg)
        {
            listBox1.Items.Add(msg);
            listBox1.Update();
        }
        private void UpdatePowerStatus(NFM_POWER nfmPower)
        {
            String Result;

	        switch(nfmPower)
	        {
	        case NFM_POWER.NFM_POWERON:
                    Result = "power status: on";
		        break;
	        case NFM_POWER.NFM_POWEROFF:
                Result = "power status: off";
		        break;
	        default:
                Result = "power status: unknown";
		        break;
	        }
            ShowMessage(Result);
        }
        private void UpdatePairedList(int nNum, NFM_PAIRED_LIST []pPairedList)
        {
            int i = 0;
	        String wzResult, wzBtAddr;
            
	        if(nNum == 0)
	        {
		       ShowMessage("paired list is empty");
		        return;
	        }
        	
	        for(i=0; i<nNum; i++)
	        {
		        //ConvertBTAddress(pPairedList[i].btAddr, wzBtAddr, NFM_LEN_SMALL, 0);
                wzBtAddr = pPairedList[i].btAddr.ToString();
                wzResult = String.Format("name:{0} bt addr:{1} major id:{2} minor id:{3}", 
			        pPairedList[i].wzName, wzBtAddr, pPairedList[i].devMajorID, pPairedList[i].devMinorID);
		        ShowMessage(wzResult);
	        }
        }
        private void RemotePairRequest(NFM_ANSWERPAIR_STATE state, UInt64 ba)
        {
            String Result,BtAddr, State;

	        ShowMessage("remote pair request");
	        //ConvertBTAddress(ba, BtAddr, NFM_LEN_SMALL, 0);
            BtAddr = ba.ToString();

	        switch(state)
	        {
	        case NFM_ANSWERPAIR_STATE.NFM_ANSWERPAIR_REQUEST:
		        State="answer pair: request";
		        break;
	        case NFM_ANSWERPAIR_STATE.NFM_ANSWERPAIR_TIMEOUT:
		        State="answer pair: timeout";
		        break;
	        default:
		        State="answer pair: unknown";
		        break;
	        }

	        Result=String.Format("bt addr:[{0}] %{1}", BtAddr, State);
	        ShowMessage(Result);
        }
        private void QueryPairService( UInt64 ba,  int nCount,  NFM_PROFILEID []pProfileID)
        {
            int i = 0;
	        String wzResult, wzBtAddr, wzTemp;

	        ShowMessage("pair service");
	        //ConvertBTAddress(ba, wzBtAddr, NFM_LEN_SMALL, 0);
            wzBtAddr = ba.ToString();
	        wzResult = String.Format( "bt addr:[{0}]", wzBtAddr);
	        ShowMessage(wzResult);

	        wzResult = String.Format( "support service:");
	        for(i=0; i<nCount; i++)
	        {
		        wzResult = String.Format("[%d]", pProfileID[i]);
		        //wcscat(wzResult, wzTemp);
                
	        }
	        ShowMessage(wzResult);
        }  
        private void InquiryStatus( NFM_INQUIRY_STATE state,  NFM_INQUIRY_REMOTEDEVICE pInquiryRemoteDevice)
        {
	        String wzResult, wzBtAddr;

	        switch(state)
	        {
                case NFM_INQUIRY_STATE.NFM_INQ_START:
		            ShowMessage("inquiry start");
		            break;
                case NFM_INQUIRY_STATE.NFM_INQ_INQUIRING:
		            ShowMessage("inquiring");
		            //ConvertBTAddress(pInquiryRemoteDevice.btAddr, wzBtAddr, NFM_LEN_SMALL, 0);
                    wzBtAddr = pInquiryRemoteDevice.btAddr.ToString();
		            wzResult = String.Format( "name:[%s] bt addr:[%s] major id:[%d] minor id:[%d]", 
			            pInquiryRemoteDevice.wzName, wzBtAddr, pInquiryRemoteDevice.devMajorID, pInquiryRemoteDevice.devMinorID);
		            ShowMessage(wzResult);
		            break;
                case NFM_INQUIRY_STATE.NFM_INQ_END:
		            ShowMessage("inquiry end");
		            break;
                case NFM_INQUIRY_STATE.NFM_INQ_END_RETRY:
		            ShowMessage("inquiry end retry");
		            break;
	            default:
		            break;
	        }
        }

        private void BasebandDisconnect( String ucReason)
        {
	        String wzResult;

	        wzResult = String.Format( "baseband disconnect [{0}]", ucReason);
	        ShowMessage(wzResult);
        }

        private void ConnectionStatus( UInt64 ba,  NFM_PROFILEID ProfileID,  NFM_CONNECTION_STATE state)
        {
	        String wzResult, wzBtAddr;

	        //ConvertBTAddress(ba, wzBtAddr, NFM_LEN_SMALL, 0);
            wzBtAddr = ba.ToString();
	        switch(state)
	        {
                case NFM_CONNECTION_STATE.NFM_CON_CONNECTION:
                    wzResult = String.Format("bt addr:[{0}] profile id:[{1}] connection", wzBtAddr, ProfileID);
		            break;
                case NFM_CONNECTION_STATE.NFM_CON_DISCONNECTION:
                    wzResult = String.Format("bt addr:[[{0}] profile id:[{1}] disconnection", wzBtAddr, ProfileID);
		            break;
                case NFM_CONNECTION_STATE.NFM_CON_NOT_SUPPORT:
                    wzResult = String.Format("bt addr:[{0}] profile id:[{1}] not support", wzBtAddr, ProfileID);
		            break;
	            default:
                    wzResult = String.Format("bt addr:[{0}] profile id:[{1}] unknown status", wzBtAddr, ProfileID);
		            break;
	        }
	        ShowMessage(wzResult);
        }

        private void DownloadStatus( NFM_DOWNLOAD_TYPE type,  NFM_DOWNLOAD_STATE state)
        {
            StringBuilder wzResult;

	        switch(type)
	        {
	        case NFM_DOWNLOAD_TYPE.NFM_DLT_MAIN:
		        wzResult = new StringBuilder("Phonebook");
		        break;
	        case NFM_DOWNLOAD_TYPE.NFM_DLT_PBAP:
		        wzResult = new StringBuilder("PBAP");
		        break;
	        case NFM_DOWNLOAD_TYPE.NFM_DLT_SYNCML:
		        wzResult = new StringBuilder("SyncML");
		        break;
	        case NFM_DOWNLOAD_TYPE.NFM_DLT_AT:
		        wzResult = new StringBuilder("AT Command");
		        break;
	        default:
		        wzResult = new StringBuilder("unknown");
		        break;
	        }

	        wzResult.Append("");

	        switch(state)
	        {
	        case NFM_DOWNLOAD_STATE.NFM_DLS_START:
                    wzResult.Append("download start");
		        break;
	        case NFM_DOWNLOAD_STATE.NFM_DLS_ING:
                wzResult.Append("downloading");
		        break;
	        case NFM_DOWNLOAD_STATE.NFM_DLS_END:
                wzResult.Append("download end");
		        break;
	        default:
		        wzResult.Append("unknown");
		        break;
	        }

	        ShowMessage(wzResult.ToString());

            if (type == NFM_DOWNLOAD_TYPE.NFM_DLT_MAIN && state == NFM_DOWNLOAD_STATE.NFM_DLS_END)
	        {
		        //String Result;
		        wzResult.Append(String.Format( "Phonebook count {0}", m_nPBCount));
                ShowMessage(wzResult.ToString());
	        }
        }

        private void ContactInform( NFM_PB_ACCESS PBAccess,  String pwzFamilyName,  String pwzGivenName,  String pwzTel)
        {
	        String wzResult;

	        m_nPBCount++;

	        if(pwzGivenName.Equals(String.Empty))
                wzResult = String.Format("PB[{0}]: [{1}, {2}] [{3}]", PBAccess, pwzFamilyName, pwzGivenName, pwzTel);
	        else
                wzResult = String.Format("PB[{0}]: [{1}] [{2}]", PBAccess, pwzFamilyName, pwzTel);

	        ShowMessage(wzResult);
        }

        private void HandsfreeStatus( UInt64 ba,  NFM_HANDSFREE_STATE state)
        {
	        String wzResult, wzBtAddr;

	       // ConvertBTAddress(ba, wzBtAddr, NFM_LEN_SMALL, 0);
            wzBtAddr = ba.ToString();

	        switch (state)
	        {
		        case NFM_HANDSFREE_STATE.NFM_HFSTATE_INITIALISING :
                    wzResult = String.Format("Handsfree: Initialising [{0}]", wzBtAddr);
			        break;
		        case NFM_HANDSFREE_STATE.NFM_HFSTATE_READY :
                    wzResult = String.Format("Handsfree: Ready [{0}]", wzBtAddr);
			        break;
		        case NFM_HANDSFREE_STATE.NFM_HFSTATE_SLCCONNECTING:
                    wzResult = String.Format("Handsfree: Connecting [{0}]", wzBtAddr);
			        break;
		        case NFM_HANDSFREE_STATE.NFM_HFSTATE_SLCCONNECTED:
                    wzResult = String.Format("Handsfree: Connected [{0}]", wzBtAddr);
			        break;
		        case NFM_HANDSFREE_STATE.NFM_HFSTATE_OUTGOINGCALLESTABLISH :
                    wzResult = String.Format("Handsfree: Outgoing call [{0}]", wzBtAddr);
			        break;
		        case NFM_HANDSFREE_STATE.NFM_HFSTATE_INCOMINGCALLESTABLISH :
                    wzResult = String.Format("Handsfree: Incoming call [{0}]", wzBtAddr);
			        break;
		        case NFM_HANDSFREE_STATE.NFM_HFSTATE_ACTIVECALL :
                    wzResult = String.Format("Handsfree: Active call [{0}]", wzBtAddr);
			        break;
		        default:
			        wzResult =  "unknown";
			        break;
	        }

	        ShowMessage(wzResult);
        }

        private void IncomingCall( UInt64 ba,  String []pwzNumber)
        {
	        String wzResult, wzBtAddr;

	        //ConvertBTAddress(ba, wzBtAddr, NFM_LEN_SMALL, 0);
            wzBtAddr = ba.ToString();

            wzResult = String.Format("incoming call [{0}] [{1}] connection", wzBtAddr, pwzNumber);
	        ShowMessage(wzResult);
        }

        private void HandsfreeSCOStatus( UInt64 ba,  NFM_HANDSFREE_SCO_STATE state)
        {
	        String wzResult, wzBtAddr;

	        //ConvertBTAddress(ba, wzBtAddr, NFM_LEN_SMALL, 0);
            wzBtAddr = ba.ToString();
	        i_HandsfreeSCOStatus = (int)state;

	        switch (state)
	        {
		        case NFM_HANDSFREE_SCO_STATE.NFM_HFSCOSTATE_OFF :
                    wzResult = String.Format("Handsfree SCO: Close [{0}]", wzBtAddr);
			        break;
		        case NFM_HANDSFREE_SCO_STATE.NFM_HFSCOSTATE_ON :
                    wzResult = String.Format("Handsfree SCO: Open [{0}]", wzBtAddr);
			        break;
		        default:
			        wzResult =  "unknown";
			        break;
	        }

	        ShowMessage(wzResult);
        }

        private void VoiceRecongStatus( UInt64 ba,  NFM_VOICE_RECONG_STATE state)
        {
	        String wzResult, wzBtAddr;

	        //ConvertBTAddress(ba, wzBtAddr, NFM_LEN_SMALL, 0);
            wzBtAddr = ba.ToString();
	        i_VoiceRecongStatus = (int)state;

	        switch (state)
	        {
		        case NFM_VOICE_RECONG_STATE.NFM_VOICE_RECONG_STATE_OFF :
                    wzResult = String.Format("VoiceRecong: Off [{0}]", wzBtAddr);
			        break;
		        case NFM_VOICE_RECONG_STATE.NFM_VOICE_RECONG_STATE_ON :
                    wzResult = String.Format("VoiceRecong: On [{0}]", wzBtAddr);
			        break;
		        case NFM_VOICE_RECONG_STATE.NFM_VOICE_RECONG_STATE_ERROR :
                    wzResult = String.Format("VoiceRecong: Not Support [{0}]", wzBtAddr);
			        break;
		        default:
			        wzResult =  "unknown";
			        break;
	        }

	        ShowMessage(wzResult);
        }

        private void HandsfreeCurrentCall( UInt64 ba,  String []pwzNumber)
        {
	        String wzResult, wzBtAddr;

	        //ConvertBTAddress(ba, wzBtAddr, NFM_LEN_SMALL, 0);

            wzBtAddr = ba.ToString();
            wzResult = String.Format("HF CurrentCall: [{0}] [{1}]", wzBtAddr, pwzNumber);

	        ShowMessage(wzResult);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //DEQUE_WStr	deqCmd;
	        String		wstrParam;
	        String		wstrParam2;
	        String		wzCmd, wzBtAddr;
            String      wzMsg;
	        UInt64		b;
	        String		szPinCode;
	        int			iTemp = 0;
            PND.CNForeBridge obj = new CNForeBridge();
            //m_cmbCmd.GetWindowText(wzCmd, lengthof(wzCmd));
            //SpliteCmdLine(wzCmd, wcslen(wzCmd), &deqCmd);
            wzCmd = this.comboBox1.Text;

            String[] deqCmd = wzCmd.Split(new Char[] { ' '});
            if (0 != deqCmd.Length)
            {
                if(deqCmd[0].Equals("help"))
		        {
			        ShowMessage("help");
		        }
		        else if(deqCmd[0].Equals("startup"))
		        {
			        ShowMessage("startup");
                    try
                    {
                        if (true == obj.CMD_Startup())
                            ShowMessage("Ok");
                        else
                            ShowMessage("Fail");
                    }
                    catch (ApplicationException ex)
                    {
                        MessageBox.Show(ex.Message.ToString());
                    }
                    
		        }
                else if(deqCmd[0].Equals("end"))
		        {
			        ShowMessage("end");

			        if(obj.CMD_End())
				        ShowMessage(NFM_CMD_RET_STR_OK);
			        else
				        ShowMessage(NFM_CMD_RET_STR_FAIL);
		        }
		        else if(deqCmd[0].Equals("mw"))
                {
                    if(2 <= deqCmd.Length) //make sure parameter exist
                    {
                        //wstrParam = deqCmd[1];
                        if(deqCmd[1].Equals("version"))
                        {
                            ShowMessage("mw version");

                            NFM_VER nfmVer;
                            if(obj.CMD_GetMwVersion(out nfmVer))
                            {
                                wzMsg =  String.Format("nForeMW Version:{0}.{1}.{2}.{3} build:{4}",
                                    nfmVer.iVer1, nfmVer.iVer2, nfmVer.iVer3, nfmVer.iVer4, nfmVer.wzBuild);
                                ShowMessage(wzMsg);
                                ShowMessage(NFM_CMD_RET_STR_OK);
                            }
                            else
                            {
                                ShowMessage(NFM_CMD_RET_STR_FAIL);
                            }
                        }
                        else
                        {
                            ShowMessage("usage: mw version");
                        }
                    }
                    else
                    {
                        ShowMessage("usage: mw version");
                    }
                }
		        else if(deqCmd[0].Equals("local"))
		        {
			        if(2 <= deqCmd.Length) //make sure parameter exist
			        {
				        //wstrParam = deqCmd.at(1);
				        if(deqCmd[1].Equals("btaddr"))
				        {
					        ShowMessage("local btaddr");
					        if(obj.CMD_GetLocalBtAddr(out b))
					        {
						        ShowMessage(NFM_CMD_RET_STR_OK);
						        wzBtAddr= b.ToString();
						        ShowMessage(wzBtAddr);
					        }
					        else
					        {
						        ShowMessage(NFM_CMD_RET_STR_FAIL);
					        }
				        }
				        else if(deqCmd[1].Equals("name"))
				        {
					        if(3 <= deqCmd.Length) //make sure parameter exist
					        {
						        //wstrParam = deqCmd.at(2);
						        if(deqCmd[2].Equals("get"))
						        { 
                                    
							        ShowMessage("local name get");
							        if(obj.CMD_GetLocalDeviceName(out wzMsg, b)
							        {
								        ShowMessage(wzMsg);
								        ShowMessage(NFM_CMD_RET_STR_OK);
							        }
							        else
							        {
								        UI_ShowMessage(NFM_CMD_RET_STR_FAIL);
							        }
						        }
						        else if(0 == wcsicmp(wstrParam.c_str(), L"set"))
						        {
							        if(4 <= deqCmd.size()) //make sure parameter exist
							        {
								        wstrParam = deqCmd.at(3);
								        UI_ShowMessage(L"local name set");
								        if(CMD_SetLocalDeviceName(wstrParam.c_str(), wstrParam.size()))
								        {
									        UI_ShowMessage(NFM_CMD_RET_STR_OK);
								        }
								        else
								        {
									        UI_ShowMessage(NFM_CMD_RET_STR_FAIL);
								        }
							        }
							        else
							        {
								        UI_ShowMessage(L"usage: local name [get | set]");
							        }
						        }
						        else
						        {
							        UI_ShowMessage(L"usage: local name [get | set]");
						        }
					        }
					        else
					        {
						        UI_ShowMessage(L"usage: local name [get | set]");
					        }
				        }
				        else if(0 == wcsicmp(wstrParam.c_str(), L"cod"))
				        {
					        if(3 <= deqCmd.size()) //make sure parameter exist
					        {
						        wstrParam = deqCmd.at(2);
						        if(0 == wcsicmp(wstrParam.c_str(), L"get"))
						        {
							        unsigned int cod;
							        UI_ShowMessage(L"local cod get");
							        if(CMD_GetCOD(&cod))
							        {
								        wsprintf(wzMsg, L"local cod: [%08x]", cod);
								        UI_ShowMessage(wzMsg);
								        UI_ShowMessage(NFM_CMD_RET_STR_OK);
							        }
							        else
							        {
								        UI_ShowMessage(NFM_CMD_RET_STR_FAIL);
							        }
						        }
						        else if(0 == wcsicmp(wstrParam.c_str(), L"set"))
						        {
							        if(4 <= deqCmd.size()) //make sure parameter exist
							        {
								        wstrParam = deqCmd.at(3);
								        unsigned int cod = _wtoi(wstrParam.c_str());
								        UI_ShowMessage(L"local cod set");
								        if(CMD_SetCOD(cod))
								        {
									        UI_ShowMessage(NFM_CMD_RET_STR_OK);
								        }
								        else
								        {
									        UI_ShowMessage(NFM_CMD_RET_STR_FAIL);
								        }
							        }
							        else
							        {
								        UI_ShowMessage(L"usage: local cod [get | set]");
							        }
						        }
						        else
						        {
							        UI_ShowMessage(L"usage: local cod [get | set]");
						        }
					        }
					        else
					        {
						        UI_ShowMessage(L"usage: local cod [get | set]");
					        }
				        }
				        else if(0 == wcsicmp(wstrParam.c_str(), L"scanenable"))
				        {
					        if(3 <= deqCmd.size()) //make sure parameter exist
					        {
						        wstrParam = deqCmd.at(2);
						        if(0 == wcsicmp(wstrParam.c_str(), L"get"))
						        {
							        unsigned char mask;
							        UI_ShowMessage(L"local scanenable get");
							        if(CMD_GetScanEnable(&mask))
							        {
								        wsprintf(wzMsg, L"local scanenable: [%d]", mask);
								        UI_ShowMessage(wzMsg);
								        UI_ShowMessage(NFM_CMD_RET_STR_OK);
							        }
							        else
							        {
								        UI_ShowMessage(NFM_CMD_RET_STR_FAIL);
							        }
						        }
						        else if(0 == wcsicmp(wstrParam.c_str(), L"set"))
						        {
							        if(4 <= deqCmd.size()) //make sure parameter exist
							        {
								        wstrParam = deqCmd.at(3);
								        unsigned char mask = (unsigned char)_wtoi(wstrParam.c_str());
								        UI_ShowMessage(L"local scanenable set");
								        if(CMD_SetScanEnable(mask))
								        {
									        UI_ShowMessage(NFM_CMD_RET_STR_OK);
								        }
								        else
								        {
									        UI_ShowMessage(NFM_CMD_RET_STR_FAIL);
								        }
							        }
							        else
							        {
								        UI_ShowMessage(L"usage: local scanenable [get | set]");
							        }
						        }
						        else
						        {
							        UI_ShowMessage(L"usage: local scanenable [get | set]");
						        }
					        }
					        else
					        {
						        UI_ShowMessage(L"usage: local cod [get | set]");
					        }
				        }
				        else if(0 == wcsicmp(wstrParam.c_str(), L"authenable"))
				        {
					        if(3 <= deqCmd.size()) //make sure parameter exist
					        {
						        wstrParam = deqCmd.at(2);
						        if(0 == wcsicmp(wstrParam.c_str(), L"get"))
						        {
							        unsigned char ae;
							        UI_ShowMessage(L"local authenable get");
							        if(CMD_GetAuthEnable(&ae))
							        {
								        wsprintf(wzMsg, L"local authenable: [%d]", ae);
								        UI_ShowMessage(wzMsg);
								        UI_ShowMessage(NFM_CMD_RET_STR_OK);
							        }
							        else
							        {
								        UI_ShowMessage(NFM_CMD_RET_STR_FAIL);
							        }
						        }
						        else if(0 == wcsicmp(wstrParam.c_str(), L"set"))
						        {
							        if(4 <= deqCmd.size()) //make sure parameter exist
							        {
								        wstrParam = deqCmd.at(3);
								        unsigned char ae = (unsigned char)_wtoi(wstrParam.c_str());
								        UI_ShowMessage(L"local authenable set");
								        if(CMD_SetAuthEnable(ae))
								        {
									        UI_ShowMessage(NFM_CMD_RET_STR_OK);
								        }
								        else
								        {
									        UI_ShowMessage(NFM_CMD_RET_STR_FAIL);
								        }
							        }
							        else
							        {
								        UI_ShowMessage(L"usage: local authenable [get | set]");
							        }
						        }
						        else
						        {
							        UI_ShowMessage(L"usage: local authenable [get | set]");
						        }
					        }
					        else
					        {
						        UI_ShowMessage(L"usage: local cod [get | set]");
					        }
				        }
				        else
				        {
					        UI_ShowMessage(L"usage: local [btaddr | name | cod | scanenable | authenable] [get | set]");
				        }
			        }
			        else
			        {
				        UI_ShowMessage(L"usage: local [btaddr | name | cod | scanenable | authenable] [get | set]");
			        }
		        }
		        else if(0 == wcsicmp(wstrParam.c_str(), L"power"))
		        {
			        if(2 <= deqCmd.size()) //make sure parameter exist
			        {
				        wstrParam = deqCmd.at(1);
				        if(0 == wcsicmp(wstrParam.c_str(), L"on"))
				        {
					        UI_ShowMessage(L"power on");
					        CMD_SetPower(NFM_POWERON);
				        }
				        else if(0 == wcsicmp(wstrParam.c_str(), L"off"))
				        {
					        UI_ShowMessage(L"power off");
					        CMD_SetPower(NFM_POWEROFF);
				        }
				        else if(0 == wcsicmp(wstrParam.c_str(), L"status"))
				        {
					        NFM_POWER nfmPower;
					        CMD_GetPower(&nfmPower);
					        UI_UpdatePowerStatus(nfmPower);
				        }
				        else
				        {
					        UI_ShowMessage(L"usage: power [on | off | status]");
				        }
			        }
			        else //no parameter
			        {
				        UI_ShowMessage(L"usage: power [on | off | status]");
			        }
		        }
		        else if(0 == wcsicmp(wstrParam.c_str(), L"pair"))
		        {
			        if(2 <= deqCmd.size()) //make sure parameter exist
			        {
				        wstrParam = deqCmd.at(1);
				        if(0 == wcsicmp(wstrParam.c_str(), L"list"))
				        {
					        UI_ShowMessage(L"paired list");
					        CMD_GetPairedList();
				        }
				        else if(0 == wcsicmp(wstrParam.c_str(), L"request"))
				        {
					        if(4 <= deqCmd.size()) //make sure parameter exist
					        {
						        UI_ShowMessage(L"paired request");
						        wstrParam = deqCmd.at(2);
						        if(FALSE == WStringToBTAddress(&b, wstrParam.c_str(), wstrParam.size()))
						        {
							        UI_ShowMessage(L"bt_addr format error");
						        }
						        else
						        {
							        wstrParam = deqCmd.at(3);
							        memset(szPinCode, 0x00, sizeof(szPinCode));
							        wcstombs((char*)szPinCode, wstrParam.c_str(), sizeof(szPinCode));
							        CMD_PairRequest(&b, strlen((char*)szPinCode), szPinCode);
						        }
					        }
					        else
					        {
						        UI_ShowMessage(L"usage: pair request bt_addr pin_code");
					        }
				        }
				        else if(0 == wcsicmp(wstrParam.c_str(), L"delete"))
				        {
					        if(3 <= deqCmd.size()) //make sure parameter exist
					        {
						        UI_ShowMessage(L"paired delete");
						        wstrParam = deqCmd.at(2);
						        if(FALSE == WStringToBTAddress(&b, wstrParam.c_str(), wstrParam.size()))
						        {
							        UI_ShowMessage(L"bt_addr format error");
						        }
						        else
						        {
							        CMD_DeletePairDevice(&b);
						        }
					        }
					        else
					        {
						        UI_ShowMessage(L"usage: pair delete bt_addr");
					        }
				        }
				        else if(0 == wcsicmp(wstrParam.c_str(), L"answer"))
				        {
					        if(4 <= deqCmd.size()) //make sure parameter exist
					        {
						        UI_ShowMessage(L"paired answer");
						        wstrParam = deqCmd.at(2);
						        if(FALSE == WStringToBTAddress(&b, wstrParam.c_str(), wstrParam.size()))
						        {
							        UI_ShowMessage(L"bt_addr format error");
						        }
						        else
						        {
							        wstrParam = deqCmd.at(3);
							        memset(szPinCode, 0x00, sizeof(szPinCode));
							        wcstombs((char*)szPinCode, wstrParam.c_str(), sizeof(szPinCode));
							        CMD_AnswerPair(&b, strlen((char*)szPinCode), szPinCode);
						        }
					        }
					        else
					        {
						        UI_ShowMessage(L"usage: pair answer bt_addr pin_code");
					        }
				        }
				        else if(0 == wcsicmp(wstrParam.c_str(), L"refuse"))
				        {
					        if(3 <= deqCmd.size()) //make sure parameter exist
					        {
						        UI_ShowMessage(L"paired refuse");
						        wstrParam = deqCmd.at(2);
						        if(FALSE == WStringToBTAddress(&b, wstrParam.c_str(), wstrParam.size()))
						        {
							        UI_ShowMessage(L"bt_addr format error");
						        }
						        else
						        {
							        CMD_RefusePair(&b);
						        }
					        }
					        else
					        {
						        UI_ShowMessage(L"usage: pair refuse bt_addr");
					        }
				        }
				        else if(0 == wcsicmp(wstrParam.c_str(), L"service"))
				        {
					        if(3 <= deqCmd.size()) //make sure parameter exist
					        {
						        UI_ShowMessage(L"pair service");
						        wstrParam = deqCmd.at(2);
						        if(FALSE == WStringToBTAddress(&b, wstrParam.c_str(), wstrParam.size()))
						        {
							        UI_ShowMessage(L"bt_addr format error");
						        }
						        else
						        {
							        CMD_QueryPairService(&b);
						        }
					        }
					        else
					        {
						        UI_ShowMessage(L"usage: pair service bt_addr");
					        }
				        }
				        else
				        {
					        UI_ShowMessage(L"usage: pair [list | request | delete | service] bt_addr pin_code");
				        }
			        }
			        else //no parameter
			        {
				        UI_ShowMessage(L"usage: pair [list | request | delete | service] bt_addr pin_code");
			        }
		        }
		        else if(0 == wcsicmp(wstrParam.c_str(), L"inquiry"))
		        {
			        if(2 <= deqCmd.size()) //make sure parameter exist
			        {
				        wstrParam = deqCmd.at(1);
				        if(0 == wcsicmp(wstrParam.c_str(), L"start"))
				        {
					        UI_ShowMessage(L"inquire start");
					        CMD_InquiryStart();
				        }
				        else if(0 == wcsicmp(wstrParam.c_str(), L"stop"))
				        {
					        UI_ShowMessage(L"inquire stop");
					        CMD_InquiryStop();
				        }
				        else
				        {
					        UI_ShowMessage(L"usage: inquiry [start | end]");
				        }
			        }
			        else //no parameter
			        {
				        UI_ShowMessage(L"usage: inquiry [start | end]");
			        }
		        }
		        else if(0 == wcsicmp(wstrParam.c_str(), L"remote"))
		        {
			        if(4 <= deqCmd.size()) //make sure parameter exist
			        {
				        wstrParam = deqCmd.at(1);
				        if(0 == wcsicmp(wstrParam.c_str(), L"connect"))
				        {
					        wstrParam = deqCmd.at(3);
					        iTemp = _wtoi(wstrParam.c_str());

					        wstrParam = deqCmd.at(2);
					        if(FALSE == WStringToBTAddress(&b, wstrParam.c_str(), wstrParam.size()))
					        {
						        UI_ShowMessage(L"bt_addr format error");
					        }
					        else
					        {
						        UI_ShowMessage(L"remote connect");
						        CMD_ConnectRemoteDevice(&b, (NFM_PROFILEID)iTemp);
					        }
				        }
				        else if(0 == wcsicmp(wstrParam.c_str(), L"disconnect"))
				        {
					        wstrParam = deqCmd.at(3);
					        iTemp = _wtoi(wstrParam.c_str());

					        wstrParam = deqCmd.at(2);
					        if(FALSE == WStringToBTAddress(&b, wstrParam.c_str(), wstrParam.size()))
					        {
						        UI_ShowMessage(L"bt_addr format error");
					        }
					        else
					        {
						        UI_ShowMessage(L"remote disconnect");
						        CMD_DisconnectRemoteDevice(&b, (NFM_PROFILEID)iTemp);
					        }
				        }
				        else
				        {
					        UI_ShowMessage(L"usage: remote [connect | disconnect] bt_addr profile_id");
				        }
			        }
			        else if(3 <= deqCmd.size())
			        {
				        wstrParam = deqCmd.at(1);
				        if(0 == wcsicmp(wstrParam.c_str(), L"name"))
				        {
					        wchar_t wzRemoteName[NFM_LEN_BIG];

					        wstrParam = deqCmd.at(2);
					        if(FALSE == WStringToBTAddress(&b, wstrParam.c_str(), wstrParam.size()))
					        {
						        UI_ShowMessage(L"bt_addr format error");
					        }
					        else
					        {
						        UI_ShowMessage(L"remote name");
						        if(CMD_GetRemoteName(&b, wzRemoteName))
						        {
							        wsprintf(wzMsg, L"[%s]", wzRemoteName);
							        UI_ShowMessage(wzMsg);
							        UI_ShowMessage(NFM_CMD_RET_STR_OK);
						        }
						        else
						        {
							        UI_ShowMessage(NFM_CMD_RET_STR_FAIL);
						        }
					        }
				        }
				        else
				        {
					        UI_ShowMessage(L"usage: remote name bt_addr");
				        }
			        }
			        else //no parameter
			        {
				        UI_ShowMessage(L"usage: remote [connect | disconnect] bt_addr profile_id");
				        UI_ShowMessage(L"       remote name bt_addr");
			        }
		        }
		        else if(0 == wcsicmp(wstrParam.c_str(), L"phonebook"))
		        {
			        if(3 <= deqCmd.size()) //make sure parameter exist
			        {
				        wstrParam = deqCmd.at(1);
				        if(FALSE == WStringToBTAddress(&b, wstrParam.c_str(), wstrParam.size()))
				        {
					        UI_ShowMessage(L"bt_addr format error");
				        }
				        else
				        {
					        wstrParam = deqCmd.at(2);
					        if(0 == wcsicmp(wstrParam.c_str(), L"start"))
					        {
						        m_nPBCount = 0;
						        UI_ShowMessage(L"phonebook download start");
						        CMD_DownloadPhonebookStart(&b);
					        }
					        else if(0 == wcsicmp(wstrParam.c_str(), L"stop"))
					        {
						        UI_ShowMessage(L"phonebook download stop");
						        CMD_DownloadPhonebookStop(&b);
					        }
					        else
					        {
						        UI_ShowMessage(L"usage: phonebook bt_addr [start | stop]");
					        }
				        }
			        }
			        else
			        {
				        UI_ShowMessage(L"usage: phonebook bt_addr [start | stop]");
			        }
		        }
		        else if(0 == wcsicmp(wstrParam.c_str(), L"call"))
		        {
			        if(3 <= deqCmd.size()) //make sure parameter exist
			        {
				        wstrParam = deqCmd.at(1);
				        if(FALSE == WStringToBTAddress(&b, wstrParam.c_str(), wstrParam.size()))
				        {
					        UI_ShowMessage(L"bt_addr format error");
				        }
				        else
				        {
					        wstrParam = deqCmd.at(2);
					        if(0 == wcsicmp(wstrParam.c_str(), L"answer"))
					        {
						        UI_ShowMessage(L"call answer");
						        CMD_AnswerCall(&b);
					        }
					        else if(0 == wcsicmp(wstrParam.c_str(), L"reject"))
					        {
						        UI_ShowMessage(L"call reject");
						        CMD_RejectCall(&b);
					        }
					        else if(0 == wcsicmp(wstrParam.c_str(), L"terminate"))
					        {
						        UI_ShowMessage(L"call terminate");
						        CMD_TerminateCall(&b);
					        }
					        else if(0 == wcsicmp(wstrParam.c_str(), L"redial"))
					        {
						        UI_ShowMessage(L"call redial");
						        CMD_DialLast(&b);
					        }
					        else if(0 == wcsicmp(wstrParam.c_str(), L"currentcall"))
					        {
						        UI_ShowMessage(L"call currentcall");
						        CMD_GetCurrentCall(&b);
					        }
					        else if(0 == wcsicmp(wstrParam.c_str(), L"dial"))
					        {
						        if(4 <= deqCmd.size())
						        {
							        UI_ShowMessage(L"call dial");
							        wstrParam = deqCmd.at(3);
							        CMD_DialCall(&b, (wchar_t*)wstrParam.c_str());
						        }
						        else
						        {
							        UI_ShowMessage(L"usage: call bt_addr dial number");
						        }
					        }
					        else if(0 == wcsicmp(wstrParam.c_str(), L"dtmf"))
					        {
						        if(4 <= deqCmd.size())
						        {
							        UI_ShowMessage(L"call dtmf");
							        wstrParam = deqCmd.at(3);
							        CMD_TransmitDTMFCode(&b, (wchar_t*)wstrParam.c_str());
						        }
						        else
						        {
							        UI_ShowMessage(L"usage: call bt_addr dtmf number");
						        }
					        }
					        else if(0 == wcsicmp(wstrParam.c_str(), L"voicedial"))
					        {
						        if(4 <= deqCmd.size())
						        {
							        wstrParam = deqCmd.at(3);
							        if(0 == wcsicmp(wstrParam.c_str(), L"on"))
							        {
								        UI_ShowMessage(L"call voicedial on");
								        CMD_VoiceDial(&b, true);
							        }
							        else if(0 == wcsicmp(wstrParam.c_str(), L"off"))
							        {
								        UI_ShowMessage(L"call voicedial off");
								        CMD_VoiceDial(&b, false);
							        }
							        else
							        {
								        UI_ShowMessage(L"usage: call bt_addr voicedial [on | off]");
							        }
						        }
						        else
						        {
							        UI_ShowMessage(L"call voicedial");
							        CMD_VoiceDial(&b, i_VoiceRecongStatus?false:true);
						        }
					        }
					        else if(0 == wcsicmp(wstrParam.c_str(), L"audiotransfer"))
					        {
						        if(4 <= deqCmd.size())
						        {
							        wstrParam = deqCmd.at(3);
							        if(0 == wcsicmp(wstrParam.c_str(), L"hfp"))
							        {
								        UI_ShowMessage(L"call audiotransfer to hfp");
								        CMD_AudioTransfer(&b, 0);
							        }
							        else if(0 == wcsicmp(wstrParam.c_str(), L"ag"))
							        {
								        UI_ShowMessage(L"call audiotransfer to ag");
								        CMD_AudioTransfer(&b, 1);
							        }
							        else
							        {
								        UI_ShowMessage(L"usage: call bt_addr audiotransfer [hfp | ag]");
							        }
						        }
						        else
						        {
							        UI_ShowMessage(L"call audiotransfer");
							        CMD_AudioTransfer(&b, i_HandsfreeSCOStatus);
						        }
					        }
					        else if(0 == wcsicmp(wstrParam.c_str(), L"history"))
					        {
						        if(4 <= deqCmd.size())
						        {
							        wstrParam = deqCmd.at(3);
							        if(0 == wcsicmp(wstrParam.c_str(), L"mc"))
							        {
								        m_nPBCount = 0;
								        UI_ShowMessage(L"call history mc");
								        CMD_GetCallHistoryStart(&b, NFM_PB_ACCESS_MISSED);
							        }
							        else if(0 == wcsicmp(wstrParam.c_str(), L"rc"))
							        {
								        m_nPBCount = 0;
								        UI_ShowMessage(L"call history rc");
								        CMD_GetCallHistoryStart(&b, NFM_PB_ACCESS_RECEIVED);
							        }
							        else if(0 == wcsicmp(wstrParam.c_str(), L"dc"))
							        {
								        m_nPBCount = 0;
								        UI_ShowMessage(L"call history dc");
								        CMD_GetCallHistoryStart(&b, NFM_PB_ACCESS_DIALED);
							        }
							        else
							        {
								        UI_ShowMessage(L"usage: call bt_addr history [mc | rc | dc]");
							        }
						        }
						        else
						        {
							        UI_ShowMessage(L"usage: call bt_addr history [mc | rc | dc]");
						        }
					        }
					        else
					        {
						        UI_ShowMessage(L"usage: call bt_addr [answer | reject | terminate | redial | currentcall]");
						        UI_ShowMessage(L"       call bt_addr [dial | dtmf] number");
						        UI_ShowMessage(L"       call bt_addr voicedial [on | off]");
						        UI_ShowMessage(L"       call bt_addr audiotransfer [hfp | ag]");
						        UI_ShowMessage(L"       call bt_addr history [mc | rc | dc]");
					        }
				        }
			        }
			        else
			        {
				        UI_ShowMessage(L"usage: call bt_addr [answer | reject | terminate | redial | currentcall]");
				        UI_ShowMessage(L"       call bt_addr [dial | dtmf] number");
				        UI_ShowMessage(L"       call bt_addr voicedial [on | off]");
				        UI_ShowMessage(L"       call bt_addr audiotransfer [hfp | ag]");
				        UI_ShowMessage(L"       call bt_addr history [mc | rc | dc]");
			        }
		        }
		        else if(0 == wcsicmp(wstrParam.c_str(), L"dun"))
		        {
			        if(2 <= deqCmd.size()) //make sure parameter exist
			        {
				        wstrParam = deqCmd.at(1);

				        if(0 == wcsicmp(wstrParam.c_str(), L"create_entry"))
				        {

					        if(deqCmd.size()<=2)
					        {
						        UI_ShowMessage(L"usage: dun create_entry phone_no szAPN");
					        }
					        else
					        {

						        wstrParam = deqCmd.at(2);
						        wstrParam2 = deqCmd.at(3);
						        WCHAR MSG[256];
						        wsprintf(MSG,L"dun create_entry %s %s",wstrParam.c_str(),wstrParam2.c_str());
						        UI_ShowMessage(MSG);
						        CMD_CreateRasEntry(wstrParam2.c_str(),L"",L"",wstrParam.c_str());
					        }
				        }
				        else if(0 == wcsicmp(wstrParam.c_str(), L"remove_entry"))
				        {
					        UI_ShowMessage(L"dun remove_entry");
					        CMD_RemoveRasEntry();

				        }
				        else if(0 == wcsicmp(wstrParam.c_str(), L"dialup"))
				        {
					        UI_ShowMessage(L"dun dialup");
					        CMD_DunDialUp(this->m_hWnd);

				        }
				        else if(0 == wcsicmp(wstrParam.c_str(), L"hangup"))
				        {
					        UI_ShowMessage(L"dun hangup");
					        CMD_DunHangUp();

				        }
				        else if(0 == wcsicmp(wstrParam.c_str(), L"get_ras_status"))
				        {
					        UI_ShowMessage(L"dun get_ras_status");
					        WCHAR currRasConnString[256];
					        CMD_GetRasConnString(currRasConnString);
					        UI_ShowMessage(currRasConnString);
				        }
				        else
				        {
					        UI_ShowMessage(L"usage: dun create_entry phone_no szAPN");
					        UI_ShowMessage(L"       dun [remove_entry|dialup|hangup|get_ras_status]");
				        }
			        }
			        else
			        {
				        UI_ShowMessage(L"usage: dun create_entry phone_no szAPN");
				        UI_ShowMessage(L"       dun [remove_entry|dialup|hangup|get_ras_status]");
			        }
		        }
		        else //unknown command
		        {
			        UI_ShowMessage(L"unknown command");
		        }
	        }
	        else //no command
	        {
		        UI_ShowMessage(L"no command");
	        }

            }

            


        }

        private void button1_Click(object sender, EventArgs e)
        {
            PND.CNForeBridge obj = new CNForeBridge();
            
            NFM_VER ver;
            try
            {
                if (obj.CMD_GetMwVersion(out ver))
                {
                    MessageBox.Show("Calling from C# wrapper\nnforeMW Version number : " + ver.iVer1.ToString()+"."+ver.iVer2.ToString()+"."+ver.iVer3.ToString()+"."+ver.iVer4.ToString()+" Build: "+ver.wzBuild.ToString());
                }
                else
                    MessageBox.Show("No version info");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            

        }

        
    }
}