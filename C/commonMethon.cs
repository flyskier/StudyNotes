
////日志
public static void WriteLog(string msg)
{
    string fileName = string.Format("ServerLog_{0}.txt", DateTime.Now.ToString("yyyyMMdd"));
    string logPath = System.IO.Path.Combine(@"D:\ErrorLog", fileName);

    StreamWriter sw = new StreamWriter(logPath, true);
    string result = string.Format("{0} {1}", DateTime.Now.ToString(), msg);
    sw.WriteLine(result);
    sw.Close();
}

//C#调用wcf restful服务
/// <summary>
        /// Post方式请求一个URL地址
        /// </summary>
        /// <param name="url">请求的URL</param>
        /// <param name="objP">对象作为参数(将对象转换成json字符串后以字节流传输到服务器)</param>
        /// <returns>str</returns>
        public static string RequestURLByPost(string url, object objP)
        {
            JavaScriptSerializer j = new JavaScriptSerializer();
            string jsonStr = j.Serialize(objP);
            byte[] postBytes = Encoding.UTF8.GetBytes(jsonStr);
            HttpWebRequest webRequest = (HttpWebRequest)HttpWebRequest.Create(url);
            webRequest.Method = "POST";
            webRequest.ContentType = "application/json;charset=UTF-8";
            try
            {
                if (objP!=null)
                {
                    webRequest.ContentLength = postBytes.Length;
                    using (Stream reqStream = webRequest.GetRequestStream())//写入参数
                    {
                        reqStream.Write(postBytes, 0, postBytes.Length);
                    }
                }
               
                using (HttpWebResponse response = (HttpWebResponse)webRequest.GetResponse())
                {
                    using (StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
                    {
                        string strResult = sr.ReadToEnd();
                        return strResult;
                    }
                }
            }
            catch (WebException ex)
            {
                return "无法连接到服务器\r\n错误信息：" + ex.Message;
            }
        }
        /// <summary>
        /// Get方式请求一个URL地址
        /// </summary>
        /// <param name="url">请求的URL</param>
        /// <returns>str</returns>
        public static string RequestURLByGet(string url)
        {
            HttpWebRequest webRequest = (HttpWebRequest)HttpWebRequest.Create(url);
            webRequest.Method = "GET";
            webRequest.ContentType = "application/json;charset=UTF-8";
            //webRequest.ContentType = "application/x-www-form-urlencoded;charset=UTF-8";

            try
            {
                using (HttpWebResponse response = (HttpWebResponse)webRequest.GetResponse())
                {
                    using (StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
                    {
                        string strResult = sr.ReadToEnd();
                        return strResult;
                    }
                }
            }
            catch (WebException ex)
            {
                return "无法连接到服务器\r\n错误信息：" + ex.Message;
            }
        }
