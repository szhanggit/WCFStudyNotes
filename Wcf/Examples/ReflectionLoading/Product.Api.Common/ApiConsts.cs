using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Api.Common
{
    public static class ApiConsts
    {
        public const string CONSUMERCODE = "ConsumerCode";
        public const string SENDER = "Sender";
        public const string SENDERDISPLAYNAME = "SenderDisplayName";
        public const string Namespace = "http://ticketxpress.com.tw/";
        public const char Seperator = '|';
        public const string VOUCHERNOTEXIST = "Voucher doesn't exist!";
        public const int MAXConcurrentDMLTryNumber = 99;
        public const int ConcurrentWaitInterval = 50;
        public const char SymbolEqual = '=';

        public const string LOWWATERMARK = "LowWaterMark";
        public const string HIGHWATERMARK = "HighWaterMark";
        public const string CACHENODEID = "CacheNodeId";
        public const string RELOADDELAY = "ReloadDelay";
        public const string SEVENELEVENPROGRAMCODE = "SevenElevenProgramCode";
        public const string FAMILYMARTPROGRAMCODE = "FamilyMartProgramCode";
        public const string FAMILYMARTBARDCODEONEPROGRAMCODE = "FamilyMartBardCodeOneProgramCode";
        public const string SOFTWORLDPROGRAMCODE = "SoftWorldProgramCode";
        public const string STARBUCKSPROGRAMCODE = "StarbucksProgramCode";
        public const string IQIYIPROGRAMCODE = "IQiYiProgramCode";

        public const string TAG_EMAILSUBJECT = "{EmailSubject}";
        public const string TAG_GREETINGS = "{Greetings}";
        public const string SecurityKey = "36097637CCB846F6";
    }
}
