using System;
using System.IO;
using System.Net;
using System.Text;
using System.Web.Script.Serialization;

namespace FCMMessageSender
{
    class Program
    {
        static void Main(string[] args)
        {
                string str = string.Empty;
                try
                {

                    string applicationID = "AIzaSyDbkony08MJq8pJneKFeLJeafAwtzbqp18";

                    string senderId = "799191692858";

                    string deviceId = "fku5MeYZDYE:APA91bFbi1Q8YUlxbCc9unEkbb6yTs33EHwCVG4DsY2tLmswt_19NtH-aZarKXW2UteWUC87UBV2MWcJ6Dnmd1zX_yNZUQ_7KY2pSh7PCLFaUi_DpaoXJ4nv_iwd_8CNKRCZ1CDI5UDC";
                    string deviceId2 = "e7VEDgkVJUE:APA91bHqC753kZD86ay8IPPzH8Gt1V-TeFdYw-y4bklfwpJzZ_v6pGiwrjaRfIghEG34t-JCvRyuJcNtHR9ZpXlorsXg-HFXHBR5IRCOVSIJP5IM7c6htQkV78QBxVIbBbiUh1b8S3Bq";

                    string[] reg_ids = new string[2];
                    reg_ids[0] = deviceId;
                    reg_ids[1] = deviceId2;

                    WebRequest tRequest = WebRequest.Create("https://fcm.googleapis.com/fcm/send");
                    tRequest.Method = "post";
                    tRequest.ContentType = "application/json";
                    var data = new
                    {
                        registration_ids = reg_ids,
                        notification = new
                        {
                            body = "Osama",
                            title = "AlBaami",
                            sound = "Enabled"
                        }
                    };
                    var serializer = new JavaScriptSerializer();
                    var json = serializer.Serialize(data);
                    Byte[] byteArray = Encoding.UTF8.GetBytes(json);
                    tRequest.Headers.Add(string.Format("Authorization: key={0}", applicationID));
                    tRequest.Headers.Add(string.Format("Sender: id={0}", senderId));
                    tRequest.ContentLength = byteArray.Length;
                    using (Stream dataStream = tRequest.GetRequestStream())
                    {
                        dataStream.Write(byteArray, 0, byteArray.Length);
                        using (WebResponse tResponse = tRequest.GetResponse())
                        {
                            using (Stream dataStreamResponse = tResponse.GetResponseStream())
                            {
                                using (StreamReader tReader = new StreamReader(dataStreamResponse))
                                {
                                    String sResponseFromServer = tReader.ReadToEnd();
                                    str = sResponseFromServer;
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                Console.WriteLine(str);
                Console.ReadKey();
        }
    }
}
