using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using WifiXiaoBoTest.Models;

namespace WifiXiaoBoTest
{
    public partial class mainFrm : Form
    {
        private string accessId = "mHPuJqgpbxMlBtF";//填写访问accessId   你的accessId
        private string accessSecret = "BLQ3ZxSznyXckF6zVbv2eHivybpuOcqtFYW";//填写访问accessSecret  你的accessSecret

        private const string accessType = "application/json";

        long timestamp = 0;

        public mainFrm()
        {
            InitializeComponent();
        }
        Random rd = new Random();

        /// <summary>
        /// 气味信息（批量查询）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnScentList_Click(object sender, EventArgs e)
        {
            timestamp = GetTimeStampTen();
            int nonce = (int)(rd.NextDouble() * 1e8);
            Console.WriteLine(string.Format("timestamp:{0},nonce:{1}", timestamp, nonce));
            string strResult = string.Format("accept:{0}*signature-nonce:{1}*signature-version:{2}*timestamp:{3}*{4}", accessType, nonce, "1.0", timestamp, HttpHelper.API_GetScents);

            string cryptoResult = HmacSHA1(strResult, accessSecret);//Base64String
            string authorization = string.Format("qwwg {0}:{1}", accessId, cryptoResult);

            //string scents = txtScents.Text.Trim().Trim(',');

            NosParam nosParam = new NosParam();
            nosParam.Nos = txtScents.Text.Trim().Trim(',');

            string strNos = HttpHelper.GetTString(nosParam);

            var lstResp =  HttpHelper.GetScents(strNos, authorization, timestamp, nonce);

            if(lstResp != null && lstResp.IsSuccess)
            {
                var lst = lstResp.Data;
                if (lst != null)
                {
                    txtInfo.Text = HttpHelper.GetTString(lst);
                }
            }
        }
        /// <summary>
        /// 单个气味信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnScentDetail_Click(object sender, EventArgs e)
        {
            string strScentList = txtScents.Text.Trim();
            string[] strScents = strScentList.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            int scentno = 0;
            if(strScents != null && strScents.Length > 0)
            {
                scentno = int.Parse(strScents[0]);
            }
            else
            {

                return;
            }

            timestamp = GetTimeStampTen();
            int nonce = (int)(rd.NextDouble() * 1e8);
            Console.WriteLine(string.Format("timestamp:{0},nonce:{1}", timestamp, nonce));
            string strResult = string.Format("accept:{0}*signature-nonce:{1}*signature-version:{2}*timestamp:{3}*{4}", accessType, nonce, "1.0", timestamp, HttpHelper.API_GetScent + "/" + scentno.ToString());

            string cryptoResult = HmacSHA1(strResult, accessSecret);//Base64String
            string authorization = string.Format("qwwg {0}:{1}", accessId, cryptoResult);

            var rtnResp = HttpHelper.GetScent(scentno.ToString(), authorization, timestamp, nonce);
            if (rtnResp != null && rtnResp.IsSuccess)
            {
                var item = rtnResp.Data;
                if(item != null)
                {
                    txtInfo.Text = HttpHelper.GetTString(item);
                }
            }
        }
        /// <summary>
        /// 气味列表 /api/partner/scent?p=1&n=15
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnScentSum_Click(object sender, EventArgs e)
        {
            int pg = 1;
            int pgn = 10;

            timestamp = GetTimeStampTen();
            int nonce = (int)(rd.NextDouble() * 1e8);
            Console.WriteLine(string.Format("timestamp:{0},nonce:{1}", timestamp, nonce));

            string strApiSub = string.Format(@"?p={0}&n={1}", pg, pgn);
            string strResult = string.Format("accept:{0}*signature-nonce:{1}*signature-version:{2}*timestamp:{3}*{4}", accessType, nonce, "1.0", timestamp, HttpHelper.API_GetScentList + strApiSub);

            string cryptoResult = HmacSHA1(strResult, accessSecret);//Base64String
            string authorization = string.Format("qwwg {0}:{1}", accessId, cryptoResult);

            var lstResp = HttpHelper.GetScentList(pg,pgn,authorization, timestamp, nonce);

            if (lstResp != null && lstResp.IsSuccess)
            {
                var lst = lstResp.Data;
                if (lst != null)
                {
                    txtInfo.Text = HttpHelper.GetTString(lst);
                }
            }
        }


        /// <summary>
        /// 获取时间10位戳
        /// </summary>
        /// <returns>时间长整形数据</returns>
        public long GetTimeStampTen()
        {
            return (DateTime.Now.ToUniversalTime().Ticks - 621355968000000000) / 10000000;
        }

        private string HmacSHA1(string message, string secret)
        {
            if(string.IsNullOrEmpty(secret))
            {
                secret = "";
            }
            var encoding = new System.Text.ASCIIEncoding();
            byte[] keyByte = encoding.GetBytes(secret);
            byte[] messageBytes = encoding.GetBytes(message);
            using (var hmacsha1 = new HMACSHA1(keyByte))
            {
                byte[] hashmessage = hmacsha1.ComputeHash(messageBytes);
                return Convert.ToBase64String(hashmessage);
            }
        }

        private void mainFrm_Load(object sender, EventArgs e)
        {

        }

        private void btnDevList_Click(object sender, EventArgs e)
        {
            int pg = 1;
            int pgn = 15;

            timestamp = GetTimeStampTen();
            int nonce = (int)(rd.NextDouble() * 1e8);
            Console.WriteLine(string.Format("timestamp:{0},nonce:{1}", timestamp, nonce));

            string strApiSub = string.Format(@"?p={0}&n={1}", pg, pgn);
            string strResult = string.Format("accept:{0}*signature-nonce:{1}*signature-version:{2}*timestamp:{3}*{4}", accessType, nonce, "1.0", timestamp, HttpHelper.API_DevInfo + strApiSub);

            string cryptoResult = HmacSHA1(strResult, accessSecret);//Base64String
            string authorization = string.Format("qwwg {0}:{1}", accessId, cryptoResult);

            var lstResp = HttpHelper.GetDevList(pg, pgn, authorization, timestamp, nonce);

            if (lstResp != null && lstResp.IsSuccess)
            {
                var lst = lstResp.Data;
                if (lst != null)
                {
                    txtInfo.Text = HttpHelper.GetTString(lst);
                }
            }
        }

        private void btnDevDetail_Click(object sender, EventArgs e)
        {
            string strMac = txtMac.Text.Trim();

            timestamp = GetTimeStampTen();
            int nonce = (int)(rd.NextDouble() * 1e8);
            Console.WriteLine(string.Format("timestamp:{0},nonce:{1}", timestamp, nonce));
            string strResult = string.Format("accept:{0}*signature-nonce:{1}*signature-version:{2}*timestamp:{3}*{4}", accessType, nonce, "1.0", timestamp, HttpHelper.API_DevDetail);

            string cryptoResult = HmacSHA1(strResult, accessSecret);//Base64String
            string authorization = string.Format("qwwg {0}:{1}", accessId, cryptoResult);

            var rtnResp = HttpHelper.GetDevDetail(strMac, authorization, timestamp, nonce);
            if (rtnResp != null && rtnResp.IsSuccess)
            {
                var item = rtnResp.Data;
                if (item != null)
                {
                    txtInfo.Text = HttpHelper.GetTString(item);
                }
            }
        }

        private void btnCapuleInfo_Click(object sender, EventArgs e)
        {
            string strMac = txtMac.Text.Trim();

            timestamp = GetTimeStampTen();
            int nonce = (int)(rd.NextDouble() * 1e8);
            Console.WriteLine(string.Format("timestamp:{0},nonce:{1}", timestamp, nonce));
            string strResult = string.Format("accept:{0}*signature-nonce:{1}*signature-version:{2}*timestamp:{3}*{4}", accessType, nonce, "1.0", timestamp, HttpHelper.API_DevCapsuleDetail);

            string cryptoResult = HmacSHA1(strResult, accessSecret);//Base64String
            string authorization = string.Format("qwwg {0}:{1}", accessId, cryptoResult);

            var rtnResp = HttpHelper.GetDevCapsuleDetail(strMac, authorization, timestamp, nonce);
            if (rtnResp != null && rtnResp.IsSuccess)
            {
                var item = rtnResp.Data;
                if (item != null)
                {
                    txtInfo.Text = HttpHelper.GetTString(item);
                }
            }
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            string strMac = txtMac.Text.Trim();

            timestamp = GetTimeStampTen();
            int nonce = (int)(rd.NextDouble() * 1e8);
            Console.WriteLine(string.Format("timestamp:{0},nonce:{1}", timestamp, nonce));
            string strResult = string.Format("accept:{0}*signature-nonce:{1}*signature-version:{2}*timestamp:{3}*{4}", accessType, nonce, "1.0", timestamp, HttpHelper.API_Play);

            string cryptoResult = HmacSHA1(strResult, accessSecret);//Base64String
            string authorization = string.Format("qwwg {0}:{1}", accessId, cryptoResult);

            PlayParam playParam = new PlayParam();
            playParam.Mac = strMac;
            playParam.Channel = int.Parse(txtChl.Text);
            playParam.Duration = int.Parse(txtDura.Text);

            var rtnResp = HttpHelper.SmellPlay(playParam, authorization, timestamp, nonce);
            if (rtnResp != null && rtnResp.IsSuccess)
            {
                txtInfo.Text = "播放成功";
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            string strMac = txtMac.Text.Trim();

            timestamp = GetTimeStampTen();
            int nonce = (int)(rd.NextDouble() * 1e8);
            Console.WriteLine(string.Format("timestamp:{0},nonce:{1}", timestamp, nonce));
            string strResult = string.Format("accept:{0}*signature-nonce:{1}*signature-version:{2}*timestamp:{3}*{4}", accessType, nonce, "1.0", timestamp, HttpHelper.API_StopPlay);

            string cryptoResult = HmacSHA1(strResult, accessSecret);//Base64String
            string authorization = string.Format("qwwg {0}:{1}", accessId, cryptoResult);

            PlayParam playParam = new PlayParam();
            playParam.Mac = strMac;
            playParam.Channel = int.Parse(txtChl.Text);

            var rtnResp = HttpHelper.StopPlay(playParam, authorization, timestamp, nonce);
            if (rtnResp != null && rtnResp.IsSuccess)
            {
                txtInfo.Text = "停止播放成功";
            }
        }

        private void btnDevStatus_Click(object sender, EventArgs e)
        {
            string strMac = txtMac.Text.Trim();

            timestamp = GetTimeStampTen();
            int nonce = (int)(rd.NextDouble() * 1e8);
            Console.WriteLine(string.Format("timestamp:{0},nonce:{1}", timestamp, nonce));
            string strResult = string.Format("accept:{0}*signature-nonce:{1}*signature-version:{2}*timestamp:{3}*{4}", accessType, nonce, "1.0", timestamp, HttpHelper.API_DevStatus);

            string cryptoResult = HmacSHA1(strResult, accessSecret);//Base64String
            string authorization = string.Format("qwwg {0}:{1}", accessId, cryptoResult);

            var rtnResp = HttpHelper.GetDevStatus(strMac, authorization, timestamp, nonce);
            if (rtnResp != null && rtnResp.IsSuccess)
            {
                txtInfo.Text = HttpHelper.GetTString(rtnResp);
            }
        }

        private void btnRealTime_Click(object sender, EventArgs e)
        {
            string strMac = txtMac.Text.Trim();

            timestamp = GetTimeStampTen();
            int nonce = (int)(rd.NextDouble() * 1e8);
            Console.WriteLine(string.Format("timestamp:{0},nonce:{1}", timestamp, nonce));
            string strResult = string.Format("accept:{0}*signature-nonce:{1}*signature-version:{2}*timestamp:{3}*{4}", accessType, nonce, "1.0", timestamp, HttpHelper.API_DevOnlineStatus);

            string cryptoResult = HmacSHA1(strResult, accessSecret);//Base64String
            string authorization = string.Format("qwwg {0}:{1}", accessId, cryptoResult);

            var rtnResp = HttpHelper.GetDevStatus2(strMac, authorization, timestamp, nonce);
            if (rtnResp != null && rtnResp.IsSuccess)
            {
                var item = rtnResp.Data;
                if (item != null)
                {
                    txtInfo.Text = HttpHelper.GetTString(item);
                }
            }
        }

        private void btnMixed_Click(object sender, EventArgs e)
        {
            string strMac = txtMac.Text.Trim();

            timestamp = GetTimeStampTen();
            int nonce = (int)(rd.NextDouble() * 1e8);
            Console.WriteLine(string.Format("timestamp:{0},nonce:{1}", timestamp, nonce));
            string strResult = string.Format("accept:{0}*signature-nonce:{1}*signature-version:{2}*timestamp:{3}*{4}", accessType, nonce, "1.0", timestamp, HttpHelper.API_Mixed);

            string cryptoResult = HmacSHA1(strResult, accessSecret);//Base64String
            string authorization = string.Format("qwwg {0}:{1}", accessId, cryptoResult);

            MixedPlayParam playParam = new MixedPlayParam();
            playParam.Mac = strMac;
            playParam.MixedParam = "20,0,10,0,40,50";//

            var rtnResp = HttpHelper.MultiPlay(playParam, authorization, timestamp, nonce);
            if (rtnResp != null && rtnResp.IsSuccess)
            {
                txtInfo.Text = "多路播放成功";
            }
        }
    }
}
