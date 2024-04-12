using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WifiXiaoBoTest.Models
{
    public class DevItem
    {
        [JsonProperty("mac")]
        public string DevMac
        {
            get;
            set;
        }
        [JsonProperty("name")]
        public string DevName
        {
            get;
            set;
        }

        [JsonProperty("nickname")]
        public string DevNickName
        {
            get;
            set;
        }

        [JsonProperty("type")]
        public string DevType
        {
            get;
            set;
        }
    }

    public class DevInfo
    {
        [JsonProperty("charging_state")]
        public int ChargingState
        {
            get;
            set;
        }


        [JsonProperty("time")]
        public DateTime DevTime
        {
            get;
            set;
        }

        [JsonProperty("version")]
        public string DevVersion
        {
            get;
            set;
        }

        [JsonProperty("voltage")]
        public float Voltage
        {
            get;
            set;
        }

        [JsonProperty("wifi")]
        public string WiFiName
        {
            get;
            set;
        }
    }

    public class DevStatus
    {
        [JsonProperty("id")]
        public string DevId
        {
            get;
            set;
        }

        [JsonProperty("version")]
        public string DevVersion
        {
            get;
            set;
        }

        [JsonProperty("time")]
        public long OnLine
        {
            get;
            set;
        }
    }

    public class DevMac
    {
        [JsonProperty("mac")]
        public string Mac
        {
            get;
            set;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class PlayParam
    {
        /// <summary>
        /// 设备MAC地址
        /// </summary>
        [JsonProperty("mac")]
        public string Mac
        {
            get;
            set;
        }
        /// <summary>
        /// 气路数，值1~6
        /// </summary>
        [JsonProperty("channel")]
        public int Channel
        {
            get;
            set;
        }
        /// <summary>
        /// 播放时长：播放时长（秒），0-一直播放
        /// </summary>
        [JsonProperty("times")]
        public int Duration
        {
            get;
            set;
        }
    }

    public class MixedPlayParam
    {
        /// <summary>
        /// 设备MAC地址
        /// </summary>
        [JsonProperty("mac")]
        public string Mac
        {
            get;
            set;
        }
        /// <summary>
        /// 气路数从1~6的播放量，英文逗号隔开，播放量计算方式：时间（秒）* 10ml
        /// 示例：20,0,10,0,40,50（表示1路播放2秒，2路不播放，3路播放1秒，4路不播放，5路播放4秒，6路播放5秒）
        /// </summary>
        [JsonProperty("mixed")]
        public string MixedParam
        {
            get;
            set;
        }

    }
}
