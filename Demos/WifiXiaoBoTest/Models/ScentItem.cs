using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WifiXiaoBoTest.Models
{
    public class ScentItem
    {
        /// <summary>
        /// 气味编号
        /// </summary>
        [JsonProperty("no")]
        public int ScentId
        {
            get;
            set;
        }
        /// <summary>
        /// 气味名称
        /// </summary>
        [JsonProperty("name")]
        public string Name
        {
            get;
            set;
        }
        /// <summary>
        /// 图标图片
        /// </summary>
        [JsonProperty("img")]
        public string Img
        {
            get;
            set;
        }
        /// <summary>
        /// 颜色值
        /// </summary>
        [JsonProperty("color")]
        public string ItemColor
        {
            get;
            set;
        }
        /// <summary>
        /// 寿命
        /// </summary>
        [JsonProperty("period")]
        public int Period
        {
            get;
            set;
        }
    }

    public class Page
    {
        [JsonProperty("total")]
        public int Total
        {
            get;
            set;
        }
        [JsonProperty("current_page")]
        public int CurPage
        {
            get;
            set;
        }
        [JsonProperty("last_page")]
        public int LastPage
        {
            get;
            set;
        }
        [JsonProperty("n")]
        public int PageSize
        {
            get;
            set;
        }
    }

    public class NosParam
    {
        /// <summary>
        /// 颜色值
        /// </summary>
        [JsonProperty("nos")]
        public string Nos
        {
            get;
            set;
        }
    }
    /// <summary>
    /// 胶囊信息
    /// </summary>
    public class Capsule
    {
        /// <summary>
        /// 气味编号
        /// </summary>
        [JsonProperty("no")]
        public int ScentId
        {
            get;
            set;
        }

        /// <summary>
        /// 气味通道
        /// </summary>
        [JsonProperty("channel")]
        public int ChannelId
        {
            get;
            set;
        }

        [JsonProperty("life")]
        public int Life
        {
            get;
            set;
        }

        [JsonProperty("status")]
        public int Status
        {
            get;
            set;
        }
    }
}
