using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace WebApplication1.CustomClass
{
    public class SendOk
    {
        public string  SendOki(string strjson)
        {
            var logs = "C:\\Logs\\logs.txt";
            DateTime adt = DateTime.Now;
            var msg = "";
            JObject json = JObject.Parse(strjson);
            var name = json["agent_name"].ToString();
            var lastName = json["agent_firstname"].ToString();
            var leadId = json["lead_id"].ToString();
            var phone = json["phone"].ToString();
            var listId = json["list_id"].ToString();
            var campaign_id = json["campaign_id"].ToString();
            var idtransaction = json["idtransaction"].ToString();
            var campaignName = json["campaignName"].ToString();
            var from = "";
            var client = new RestClient("http://giantlink.ma/glportal/WebHook/addLead");
            if (json["from"].ToString() != "script") { from = "RAPPORT"; } else { from = "SCRIPT"; }
            var recfile = "Exeption";

            client.Timeout = -1;
            CustomClass.sendFileToFTP snd = new CustomClass.sendFileToFTP();
            msg= snd.SendRecording(idtransaction);
            var ob = msg.Split('.');
            if (msg.Contains("wav")){ recfile = msg; }
            
            var request = new RestRequest(Method.POST);
            request.AddHeader("Ippo", "yO4uH9rI3hN3gK1uH7zK1fZ7gN8zB2oD");
            request.AddHeader("Content-Type", "application/json");
            //var jsonstr = "{agent_name:'" + name + "',agent_firstname:'" + lastName + "',lead_id:'" + leadId + "',phone:'" + phone + "',list_id:'" + listId + "',campaign_id:'" + campaign_id + "',userfile:'" + recfile + "',campaignName:'" + campaignName + "'}";
            //request.AddParameter("application/json", "{\r\n   \"ag○ent_name\":\"William\",\r\n   \"agent_firstname \":\"William\",\r\n   \"lead_id\":\"111\",\r\n   \"phone\":\"3310998778\",\r\n   \"list_id\":\"101\",\r\n   \"userfile\":\"/var/asterisk/mp3/records.mp3\"\r\n}\r\n", ParameterType.RequestBody);
            try {
                //    request.AddParameter("application/json", jsonstr, ParameterType.RequestBody);
                request.AddParameter("application/json", "{\r\n   \"agent_name\":\"" + name + "\",\r\n   \"agent_firstname\":\"" + lastName + "\",\r\n   \"lead_id\":\"" + leadId + "\",\r\n   \"phone\":\"" + phone + "\",\r\n   \"list_id\":\"" + listId + "\",\r\n   \"campaign_id\":\"" + campaign_id + "\",\r\n   \"userfile\":\"" + recfile + "\",\r\n   \"service\":\"" + from + "\",\r\n   \"campaignName\":\"" + campaignName + "\"\r\n}\r\n", ParameterType.RequestBody);

                IRestResponse response = client.Execute(request);
                //*********************************************wrhite to logs*********
                StringBuilder t = new StringBuilder();
                //File.Delete(logs);
                t.AppendLine(adt + ":" + response.ResponseStatus + "|" + msg);
                File.AppendAllText(logs, t.ToString());
                //*********************************************
                return response.ResponseStatus + "|" + msg;
            } catch (Exception e) {
                //*********************************************wrhite to logs*********
                StringBuilder t = new StringBuilder();
                //File.Delete(logs);
                t.AppendLine(adt + ":" + e.Message.ToString());
                File.AppendAllText(logs, t.ToString());
                //********************************************
                return e.Message;
            }
            
           
            //return "successfully";
        }
    }
}