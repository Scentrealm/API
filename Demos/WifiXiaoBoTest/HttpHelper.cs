using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using WifiXiaoBoTest.Models;

namespace WifiXiaoBoTest
{
    public class HttpHelper
    {
        private static string baseUrl = "https://xiaobo.qiweiwangguo.com";//
        private static string baseUrl_PRODUCTION = "http://api.oa.damosphere.com";

        private static string baseUrl_TEST = "https://xiaobo.qiweiwangguo.com/api"; //上传测试 //正式 https://xiaobo.qiweiwangguo.com/ 120.26.109.169

        private static string API_UploadResult = "/v1/rank";

        private static string API_Upload = "/upload";

        public static string API_SmellPlay = "/iot/playScene";
        public static string API_StopPlay = "/iot/stop";

        public static string API_QrCodeToken = "/activity/image/code";

        public static string API_GetScentList = "/api/partner/scent";

        public static string API_GetScent = "/api/partner/scent";

        public static string API_GetScents = "/api/partner/scent/list";

        /// <summary>
        /// 
        /// </summary>
        public static bool EnableRequestSimulate { get; set; } = true;

        public static string RequestToken { get; set; }

        public static string AccessType
        {
            get;
            set;
        } = "application/json";




        /// <summary>
        /// 
        /// </summary>
        /// <param name="IsProduction"></param>
        public static void SetURL_Env(bool IsProduction = true)
        {
            if (IsProduction)
                baseUrl = baseUrl_PRODUCTION;
            else
                baseUrl = baseUrl_TEST;
        }

        public static void SetUrl(string appurl)
        {
            baseUrl_TEST = appurl;
        }

        public static string HttpGet(string url, string method)
        {
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url + method);

    //        httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "GET";
            httpWebRequest.Timeout = 5000;
            httpWebRequest.Headers["Authorization"] = "Bearer " + RequestToken;

            HttpWebResponse httpWebResponse = null;

            try
            {
                httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            }
            catch (WebException wex)
            {
                Console.WriteLine("HttpPost [" + url + "] Error :" + wex.Message);
                if (wex.HResult == -2146233079)
                {
                    string ErrorNetMSG = "{\"meta\": {\"code\": 22, \"message\": \"网络连接异常\", \"data\": []}}";
                    return ErrorNetMSG;
                }
                if (wex.Status == WebExceptionStatus.ProtocolError)
                {
                    httpWebResponse = wex.Response as HttpWebResponse;
                }
                //连接中断
                string ErrorMSG = "{\"meta\": {\"code\": 22, \"message\": \"" + wex.Message + "\", \"data\": []}}";
                return ErrorMSG;
            }
            catch (Exception e)
            {
                Console.WriteLine("HttpPost [" + url + "] Error :" + e.Message);
                string ErrorMSG = "{\"meta\": {\"code\": 22, \"message\": \"" + e.Message + "\", \"data\": []}}";
                return ErrorMSG;
            }
            StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream());
            string responseContent = streamReader.ReadToEnd();

            httpWebResponse.Close();
            streamReader.Close();

            return responseContent;
        }
        public static string HttpPost(string url, string method, string param, bool WithToken = true,bool jsonType = false)
        {
            //转换输入参数的编码类型，获取bytep[]数组 
            byte[] byteArray = Encoding.UTF8.GetBytes(param);
            //初始化新的webRequst
            //1． 创建httpWebRequest对象
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(new Uri(url + method));
            //2． 初始化HttpWebRequest对象
            webRequest.Method = "POST";
            if(jsonType)
            {
                webRequest.ContentType = "application/json;charset=UTF-8";
            }
            else
            {
                webRequest.ContentType = "application/x-www-form-urlencoded;charset=UTF-8";
            }

            webRequest.ContentLength = byteArray.Length;
            if(WithToken)
                webRequest.Headers["Authorization"] = "Bearer " + RequestToken;
            webRequest.Timeout = 5000;
            
            //3． 附加要POST给服务器的数据到HttpWebRequest对象(附加POST数据的过程比较特殊，它并没有提供一个属性给用户存取，需要写入HttpWebRequest对象提供的一个stream里面。)

            try
            {
                Stream newStream = webRequest.GetRequestStream();//创建一个Stream,赋值是写入HttpWebRequest对象提供的一个stream里面
                newStream.Write(byteArray, 0, byteArray.Length);
                newStream.Close();
            }
            catch (WebException wex)
            {
                HttpWebResponse res = wex.Response as HttpWebResponse;
                if(wex.HResult == -2146233079)
                {
                    string ErrorNetMSG = "{\"meta\": {\"code\": 22, \"message\": \"网络连接异常\", \"data\": []}}";
                    return ErrorNetMSG;
                }
                //连接中断
                string ErrorMSG = "{\"meta\": {\"code\": 22, \"message\": \""+ wex.Message +"\", \"data\": []}}";
                return ErrorMSG;
            }
            catch (Exception Ex)
            {
                String ErrorMSG = "{\"meta\": {\"code\": 22, \"message\": \"" + Ex.Message + "\", \"data\": []}}";
                return ErrorMSG;
            }

            //4． 读取服务器的返回信息
            HttpWebResponse response = null;//= (HttpWebResponse)webRequest.GetResponse();

            try
            {
                response = (HttpWebResponse)webRequest.GetResponse();
            }
            catch (WebException e)
            {
                Console.WriteLine("HttpPost ["+ url + method + "] Error :" + e.Message);
                if (e.Status == WebExceptionStatus.ProtocolError)
                {
                    response = e.Response as HttpWebResponse;
                }
            }

            StreamReader php = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
            string phpend = php.ReadToEnd();

            return phpend;
        }

        public static string HttpPostNew(string url, string method,string param,string strAuthorization,long timeStamp, int nonce)
        {
            //转换输入参数的编码类型，获取bytep[]数组 
            byte[] byteArray = Encoding.UTF8.GetBytes(param);
            //初始化新的webRequst
            //1． 创建httpWebRequest对象
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(new Uri(url + method));
            //2． 初始化HttpWebRequest对象
            webRequest.Method = "POST";

            webRequest.ContentType = "application/json;charset=UTF-8";

            webRequest.ContentLength = byteArray.Length;

            webRequest.Headers["Authorization"] = strAuthorization;
            webRequest.Headers["timestamp"] = timeStamp.ToString();
            webRequest.Headers["signature-nonce"] = nonce.ToString();
            webRequest.Headers["signature-version"] = "1.0";
            //webRequest.Headers["accept"] = "application/json";

            webRequest.Timeout = 5000;

            //3． 附加要POST给服务器的数据到HttpWebRequest对象(附加POST数据的过程比较特殊，它并没有提供一个属性给用户存取，需要写入HttpWebRequest对象提供的一个stream里面。)

            try
            {
                Stream newStream = webRequest.GetRequestStream();//创建一个Stream,赋值是写入HttpWebRequest对象提供的一个stream里面
                newStream.Write(byteArray, 0, byteArray.Length);
                newStream.Close();
            }
            catch (WebException wex)
            {
                HttpWebResponse res = wex.Response as HttpWebResponse;
                if (wex.HResult == -2146233079)
                {
                    string ErrorNetMSG = "{\"meta\": {\"code\": 22, \"message\": \"网络连接异常\", \"data\": []}}";
                    return ErrorNetMSG;
                }
                //连接中断
                string ErrorMSG = "{\"meta\": {\"code\": 22, \"message\": \"" + wex.Message + "\", \"data\": []}}";
                return ErrorMSG;
            }
            catch (Exception Ex)
            {
                String ErrorMSG = "{\"meta\": {\"code\": 22, \"message\": \"" + Ex.Message + "\", \"data\": []}}";
                return ErrorMSG;
            }

            //4． 读取服务器的返回信息
            HttpWebResponse response = null;//= (HttpWebResponse)webRequest.GetResponse();

            try
            {
                response = (HttpWebResponse)webRequest.GetResponse();
            }
            catch (WebException e)
            {
                Console.WriteLine("HttpPost [" + url + method + "] Error :" + e.Message);
                if (e.Status == WebExceptionStatus.ProtocolError)
                {
                    response = e.Response as HttpWebResponse;
                }
            }

            StreamReader php = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
            string phpend = php.ReadToEnd();

            return phpend;
        }

        public static MultipartFormDataContent GetFormDataBody(Dictionary<string, string> dictData)
        {
            MultipartFormDataContent content = new MultipartFormDataContent();
            foreach (var item in dictData)
            {
                if (item.Value.GetType() == typeof(string))
                {
                    content.Add(new StringContent(item.Value as string), item.Key);
                }
                else if (item.Value.GetType() == typeof(DateTime))
                {
                    content.Add(new StringContent(string.Format("'{0}'", item.Value)), item.Key);
                }
                //else if (item.Value.GetType() == typeof(FileParameter))
                //{
                //    var file = item.Value as FileParameter;
                //    content.Add(new ByteArrayContent(file.File), item.Key, file.FileName);
                //}
                else
                {
                    content.Add(new StringContent(item.Value.ToString()), item.Key);
                }
            }
            return content;
        }

        public static string HttpUpdateFile(string filename)
        {
            try
            {
                WebClient webClient = new WebClient();
                
                string url = baseUrl_TEST + API_Upload;
                var resp = webClient.UploadFile(url, "POST", filename);
                //string respStr = Encoding.UTF8.GetString(resp);
                using(MemoryStream ms = new MemoryStream(resp))
                {
                    StreamReader php = new StreamReader(ms, Encoding.UTF8);
                    string phpend = php.ReadToEnd();
                    return phpend;
                }
            }
            catch (WebException wex)
            {
                HttpWebResponse res = wex.Response as HttpWebResponse;
                if (wex.HResult == -2146233079)
                {
                    string ErrorNetMSG = "{\"meta\": {\"code\": 22, \"message\": \"网络连接异常\", \"data\": []}}";
                    return ErrorNetMSG;
                }
                //连接中断
                string ErrorMSG = "{\"meta\": {\"code\": 22, \"message\": \"" + wex.Message + "\", \"data\": []}}";
                return ErrorMSG;
            }
            catch (Exception Ex)
            {
                String ErrorMSG = "{\"meta\": {\"code\": 22, \"message\": \"" + Ex.Message + "\", \"data\": []}}";
                return ErrorMSG;
            }
            return string.Empty;
        }

        public static string HttpPUT(string url, string method, string param, bool WithToken = true)
        {
            //转换输入参数的编码类型，获取bytep[]数组 
            byte[] byteArray = Encoding.UTF8.GetBytes(param);
            //初始化新的webRequst
            //1． 创建httpWebRequest对象
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(new Uri(url + method));
            //2． 初始化HttpWebRequest对象
            webRequest.Method = "PUT";
            webRequest.ContentType = "application/json";
            webRequest.ContentLength = byteArray.Length;
            if (WithToken)
                webRequest.Headers["Authorization"] = "Bearer " + RequestToken;
            webRequest.Timeout = 5000;
            //3． 附加要POST给服务器的数据到HttpWebRequest对象(附加POST数据的过程比较特殊，它并没有提供一个属性给用户存取，需要写入HttpWebRequest对象提供的一个stream里面。)

            try
            {
                Stream newStream = webRequest.GetRequestStream();//创建一个Stream,赋值是写入HttpWebRequest对象提供的一个stream里面
                newStream.Write(byteArray, 0, byteArray.Length);
                newStream.Close();
            }
            catch (WebException wex)
            {
                HttpWebResponse res = wex.Response as HttpWebResponse;
                if (wex.HResult == -2146233079)
                {
                    string ErrorNetMSG = "{\"meta\": {\"code\": 22, \"message\": \"网络连接异常\", \"data\": []}}";
                    return ErrorNetMSG;
                }
                //连接中断
                string ErrorMSG = "{\"meta\": {\"code\": 22, \"message\": \"" + wex.Message + "\", \"data\": []}}";
                return ErrorMSG;
            }
            catch (HttpRequestException hex)
            {
                if (typeof(WebException) == hex.InnerException.GetType() && (hex.InnerException as WebException).HResult == -2146233079)
                {
                    //连接中断
                    string ErrorMSG = "{\"meta\": {\"code\": 22, \"message\": \"网络连接异常\", \"data\": []}}";
                    return ErrorMSG;
                }
                else
                {
                    string ErrorMSG = "{\"meta\": {\"code\": 22, \"message\": \"接口调用异常\", \"data\": []}}";
                    return ErrorMSG;
                }
            }
            catch (Exception Ex)
            {
                String ErrorMSG = "{\"meta\": {\"code\": 22, \"message\": \"" + Ex.Message + "\", \"data\": []}}";
                return ErrorMSG;
            }

            //4． 读取服务器的返回信息
            HttpWebResponse response = null;//= (HttpWebResponse)webRequest.GetResponse();

            try
            {
                response = (HttpWebResponse)webRequest.GetResponse();
            }
            catch (WebException e)
            {
                Console.WriteLine("HttpPost [" + url + method + "] Error :" + e.Message);
                if (e.Status == WebExceptionStatus.ProtocolError)
                {
                    response = e.Response as HttpWebResponse;
                }
            }

            StreamReader php = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
            string phpend = php.ReadToEnd();

            return phpend;
        }

        public static BaseResponse<ReportResult> UploadContest(string jsonStr)
        {
            string response = HttpPost(baseUrl, API_UploadResult, jsonStr, false);
            if (string.IsNullOrEmpty(response))
            {
                return null;
            }
            var sr = JsonConvert.DeserializeObject<BaseResponse<ReportResult>>(response);
            return sr;
        }


        public static BaseResponse<string> SmellPlay(int chl, int times,string macStr)
        {
            string paramsstr = string.Format(@"mac={0}&channel={1}&times={2}", macStr, chl, times);
            paramsstr = paramsstr.Replace('\'', '\"');
            string response = HttpPost(baseUrl_TEST, API_SmellPlay, paramsstr);
            if (string.IsNullOrEmpty(response))
                return null;
            var sr = JsonConvert.DeserializeObject<BaseResponse<string>>(response);
            return sr;
        }

        public static BaseResponse<string> StopPlay(int chl,string macStr)
        {
            string paramsstr = string.Format(@"mac={0}&channel={1}", macStr, chl);
            paramsstr = paramsstr.Replace('\'', '\"');
            string response = HttpPost(baseUrl_TEST, API_StopPlay, paramsstr);
            if (string.IsNullOrEmpty(response))
                return null;
            var sr = JsonConvert.DeserializeObject<BaseResponse<string>>(response);
            return sr;
        }

        /// <summary>
        /// 气味列表
        /// </summary>
        /// <returns></returns>
        public static BaseResponse<List<ScentItem>> GetScentList(int pg,int num, string authorization, long timestamp, int nonce)
        {
            string strApiSub = string.Format(@"?p={0}&n={1}", pg,num);
            string strApi = API_GetScentList + strApiSub;
            string response = HttpPostNew(baseUrl, strApi, "", authorization, timestamp, nonce);
            if (string.IsNullOrEmpty(response))
            {
                return null;
            }
            var sr = JsonConvert.DeserializeObject<BaseResponse<List<ScentItem>>>(response);
            return sr;
        }

        /// <summary>
        /// 气味信息（批量查询）
        /// </summary>
        /// <returns></returns>
        public static BaseResponse<List<ScentItem>> GetScents(string scents, string authorization,long timestamp,int nonce)
        {
            string response = HttpPostNew(baseUrl, API_GetScents, scents, authorization, timestamp, nonce);
            if (string.IsNullOrEmpty(response))
            {
                return null;
            }
            var sr = JsonConvert.DeserializeObject<BaseResponse<List<ScentItem>>>(response);
            return sr;
        }

        /// <summary>
        /// 气味信息（批量查询）
        /// </summary>
        /// <returns></returns>
        public static BaseResponse<ScentItem> GetScent(string scentid, string authorization, long timestamp, int nonce)
        {
            string strApi = API_GetScent + "/" + scentid;

            string response = HttpPostNew(baseUrl, strApi, "", authorization, timestamp, nonce);
            if (string.IsNullOrEmpty(response))
            {
                return null;
            }
            var sr = JsonConvert.DeserializeObject<BaseResponse<ScentItem>>(response);
            return sr;
        }


        public static T GetT<T>(string content)
        {
            try
            {
                var sr = JsonConvert.DeserializeObject<T>(content);
                return sr;
            }
            catch
            {

            }
            return default(T);
        }

        public static string GetTString(object obj)
        {
            try
            {
                string request = JsonConvert.SerializeObject(obj);
                return request;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return string.Empty;
        }

        public static string UrlEncode(string str)
        {
            StringBuilder sb = new StringBuilder();
            byte[] byStr = System.Text.Encoding.UTF8.GetBytes(str); //默认是System.Text.Encoding.Default.GetBytes(str)
            for (int i = 0; i < byStr.Length; i++)
            {
                sb.Append(@"%" + Convert.ToString(byStr[i], 16));
            }
            return (sb.ToString());
        }
    }


    public class HttpRequestSimulate
    {


    }

    /// <summary>
    /// 
    /// </summary>
    public class ReportResult
    {
        /// <summary>
        /// 返回的成绩分享ID
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public int ShareID { get; set; }
        /// <summary>
        /// 返回的信息
        /// </summary>
        [JsonProperty(PropertyName = "message")]
        public string Message { get; set; }
    }

    /// <summary>
    /// 请求json基础格式
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BaseResponse<T>
    {
        /// <summary>
        /// 描述成功与否，错误信息
        /// </summary>
        [JsonProperty(PropertyName = "code")]
        public int Code { get; set; }

        /// <summary>
        /// 描述请求内容
        /// </summary>
        [JsonProperty(PropertyName = "data")]
        public T Data { get; set; }

        public bool IsSuccess {
            get {
                return Code.ToString() == "200";
            }
        }
        [JsonProperty(PropertyName = "msg")]
        public string ErrorMSG
        {
            get;
            set;
        }

        [JsonProperty(PropertyName = "page")]
        public Page Page
        {
            get;
            set;
        }
    }


}
