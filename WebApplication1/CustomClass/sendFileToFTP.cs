using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;

namespace WebApplication1.CustomClass
{
    public class sendFileToFTP
    {
        string logs = "C:\\logs\\" + DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + ".txt";
        DateTime aDate = DateTime.Now;
        StringBuilder t = new StringBuilder();
        public string SendRecording(string idtransaction)
        {
            var result = "";
            var thepath = "";
            List<RecordingPath> path = new List<RecordingPath>();
            try {

                CustomClass.DAO db = new CustomClass.DAO();
                path = db.GetPath(idtransaction);
                foreach (var l in path) {
                    if (l.Path != "")
                    {
                        var p = l.Path;
                        thepath = p.Replace("/", "\\");
                        var ob = thepath.Split('\\');
                        var ln = ob.Length;
                        thepath = ob[0] + "\\\\" + ob[1] + "\\\\" + ob[2] + "\\\\" + ob[3] + "\\\\" + ob[4] + "\\\\" + ob[5] + "\\\\" + ob[6];
                        // path = "C:\\logs\\100063856.wav";
                        result += UploadFtpFile("Vente_Recordings", thepath, ob[6]);
                    }
                    else
                    {
                        result = "Does not exist audio for this transaction.";
                    }

                }

            }
            catch (Exception e) { result = e.Message; }
            return result;
           }


        public string UploadFtpFile(string folderName, string fileName,string audio)
        {
            var result = audio+";";
            FtpWebRequest request;
            var user = "server.records@giantlink.ma";
            var pass = "HY4$qZ7t7QD}";
            var msg = "";
            try {
                string absoluteFileName = Path.GetFileName(fileName);

                request = WebRequest.Create(new Uri(string.Format(@"ftp://{0}/{1}/{2}", "ftp.giantlink.ma", folderName, absoluteFileName))) as FtpWebRequest;
                request.Method = WebRequestMethods.Ftp.UploadFile;
                request.UseBinary = true;
                request.UsePassive = true;
                request.KeepAlive = true;
                request.Credentials = new NetworkCredential(user, pass);
                request.ConnectionGroupName = "group";

                using (FileStream fs = File.OpenRead(fileName))
                {
                    byte[] buffer = new byte[fs.Length];
                    fs.Read(buffer, 0, buffer.Length);
                    fs.Close();
                    Stream requestStream = request.GetRequestStream();
                    requestStream.Write(buffer, 0, buffer.Length);
                    requestStream.Flush();
                    requestStream.Close();
                }
            } catch (Exception e) {
                t.AppendLine(aDate + ":" + "Error: " + e.Message);
                File.AppendAllText(logs, t.ToString());
                result = "ErrorExeption-";
            }
            return result;
        }
    }
}