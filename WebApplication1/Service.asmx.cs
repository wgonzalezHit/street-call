using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using System.Web.Services;
using WebApplication1.CustomClass;

namespace WebApplication1
{
    /// <summary>
    /// Summary description for Service 
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class Service : System.Web.Services.WebService
    {
        CustomClass.DAO db = new CustomClass.DAO();
        
        [WebMethod]
        public string UpdateCliente(string column, string value, string idsujeto, string type, string token)
        {
            if (token == "Gf@ap%z6wC#P8SZX7M4@@") { token = "CLIENTES"; 
                } else if (token == "mz&yc?V77kNaMq>m#4J") 
                { 
                     token = "tbIdentidadSujetoCampanya";
            }
            else
            {
                token = "";
            }

            if (token != "")
            {
                CustomClass.DAO db = new CustomClass.DAO();
                db.UpdateCustomer(Convert.ToInt32(idsujeto), "IDSUJETO", column, type, value, "EVOLUTIONDB", token);
                return "successfully";
            }
            else {
                return "error";
            }
        }

        [WebMethod]
        public string UpdateDatosCustomer(string strjson)
        {
            JObject json = JObject.Parse(strjson);
            var token = json["token"].ToString();
            var column = json["column"].ToString();
            var value = json["value"].ToString();
            var idsujeto = json["idsujeto"].ToString();
            if (token == "M5XXFAf*MYxy*@7") { token = "tbDatosCliente"; } else { token = ""; }
            if (token != "")
            {
                CustomClass.DAO db = new CustomClass.DAO();
                db.UpdateDatosCustomer( column,value, idsujeto);
                return "success";
            }
            else
            {
                return "error";
            }
        }


        //[WebMethod]
        //public void RealTimeReport()
        //{
        //        List<DataThree> percamp = new List<DataThree>();
        //        List<DataThree> perAgent = new List<DataThree>();
        //        percamp = db.GetRevenuesPerCamp();
        //        perAgent = db.GetRevenuesPerAgent();
        //        JavaScriptSerializer js = new JavaScriptSerializer();
        //        js.MaxJsonLength = 500000000;
        //        Context.Response.Write("{\"percamp\":" + js.Serialize(percamp) + ",\"peragent\":" + js.Serialize(perAgent)  + "}");

            
        //}

        //[WebMethod]
        //public void GetCountAvailableVerifier(string service)
        //{
            
        //    List<DataThree> dt = new List<DataThree>();
        //    dt = db.GetCountVerifierAvailable(service);
        //    JavaScriptSerializer js = new JavaScriptSerializer();
        //    Context.Response.Write("{\"obj\":" + js.Serialize(dt) + "}");

        //}

      //  [WebMethod]
        //public void GetAgentTimeReport(string strjson)
        //{
        //    JObject json = JObject.Parse(strjson);
        //    List<Twenty> dt = new List<Twenty>();
        //    dt = db.GetTwenty(json["agents"].ToString(), json["services"].ToString(), json["campaigns"].ToString(), json["segment"].ToString(), json["chanel"].ToString(), json["ini"].ToString(), json["fin"].ToString(), json["sentido"].ToString());
        //    JavaScriptSerializer js = new JavaScriptSerializer();
        //    Context.Response.Write("{\"obj\":" + js.Serialize(dt) + "}");

        //}

        [WebMethod]
        public void GetAgentBacks(string aid)
        {
            
            List<DataThree> dt = new List<DataThree>();
            dt = db.GetAgentCallbacks(aid);
            JavaScriptSerializer js = new JavaScriptSerializer();
            Context.Response.Write("{\"obj\":" + js.Serialize(dt) + "}");

        }

        
    //[WebMethod]
    //public void sendOkInfo(string strjson)
    //    {
    //        var msg = "";
    //        CustomClass.SendOk refi = new CustomClass.SendOk();
    //        msg=refi.SendOki(strjson);
    //        Context.Response.Write(msg);
    //    }

        //[WebMethod]
        //public void UniversalReport(string strjson)
        //{
        //    List<twentySix> dt = new List<twentySix>();
        //    dt = db.UniversalReport(strjson);
        //    JavaScriptSerializer js = new JavaScriptSerializer();
        //    js.MaxJsonLength = 500000000;
        //    Context.Response.Write("{\"json\":" + js.Serialize(dt) + "}");

        //}

        //[WebMethod]
        //public void getCallStatusCalls(string strjson)
        //{
        //    List<Twenty> dt = new List<Twenty>();
        //    dt = db.getCallStatusCalls(strjson);
        //    JavaScriptSerializer js = new JavaScriptSerializer();
        //    js.MaxJsonLength = 500000000;
        //    Context.Response.Write("{\"json\":" + js.Serialize(dt) + "}");

        //}

        //[WebMethod]
        //public void getAddicionalContacts(string strjson)
        //{
        //    JObject json = JObject.Parse(strjson);
        //    List<AddicionalContactList> dt = new List<AddicionalContactList>();
        //    dt = db.getAddicionalContacs(json["campaignId"].ToString(),json["empresa"].ToString());
        //    JavaScriptSerializer js = new JavaScriptSerializer();
        //    js.MaxJsonLength = 500000000;
        //    Context.Response.Write("{\"contacts\":" + js.Serialize(dt) + "}");

        //}

        [WebMethod]
        public void setCallback(string strjson)
        {
            var result = "";
            JObject json = JObject.Parse(strjson);
            result = db.setCallBack(strjson);
            if (result.Contains('|'))
            {
                List<DataThree> dt = new List<DataThree>(); 
                dt = db.GetAgentCallbacks(json["idsujeto"].ToString());
                JavaScriptSerializer js = new JavaScriptSerializer();
                Context.Response.Write("{\"obj\":" + js.Serialize(dt) + "}");
            }
            else {
                Context.Response.Write(result);
            }
            
        }

        //[WebMethod]
        //public void getRecordsPartialDelete(string strjson)
        //{
        //    List<PartialDelete> report = new List<PartialDelete>();
        //    report = db.getRecordsPartialDelete(strjson);
        //    JavaScriptSerializer js = new JavaScriptSerializer();
        //    js.MaxJsonLength = 500000000;
        //    Context.Response.Write("{\"json\":" + js.Serialize(report) + "}");

        //}
        //[WebMethod]
        //public void WarningPartialDelete(string token, string strjson)
        //{
        //    var result = db.WarningPartialDelete(token, strjson);
        //    Context.Response.Write(result);

        //}

       // [WebMethod]
        public void Eval(string str, string token)
        {
            if ((str == WebConfigurationManager.AppSettings["thetoken"]) && (token.Contains("&nbsp;")))
            {
                Context.Response.Write("true");
            }
            else
            {
                Context.Response.Write("false");
            }
        }
        //[WebMethod]
        //public void getCampaigns()
        //{
        //    List<Campaigns> camps = new List<Campaigns>();
        //    camps = db.getCamps();
        //    JavaScriptSerializer js = new JavaScriptSerializer();
        //    js.MaxJsonLength = 500000000;
        //    Context.Response.Write("{\"json\":" + js.Serialize(camps) + "}");

        //}

        [WebMethod]
        public void AddNumberToDoNotCall(string json)
        {
             var res = db.AddNumberToDoNotCall(json);
            
            Context.Response.Write(res);

        }
    //[WebMethod]
    public void getGroupDispositionsPerformance(string lstIdServicio,string lstIdCampanya,string lstIdSegmento,string lstIdAgente,string lstIdGrupoFinales,string lstIdFinal,string tInicio,string tFinal,string hInicio,string hFinal,string sEntregAg,string sOrigenTrans)
        {
            List<GroupFin> gf = new List<GroupFin>();
            List<AgentsGroupsDispos> agd = new List<AgentsGroupsDispos>();
            agd = db.getAgentGroupDispos(lstIdServicio,lstIdAgente,tInicio, tFinal,lstIdCampanya);
            gf=db. getGroupFin(lstIdServicio,lstIdCampanya,lstIdSegmento,lstIdAgente,lstIdGrupoFinales,lstIdFinal,tInicio,tFinal,hInicio,hFinal,sEntregAg,sOrigenTrans);
            JavaScriptSerializer js = new JavaScriptSerializer();
             js.MaxJsonLength = 500000000;
            Context.Response.Write("{\"gf\":" + js.Serialize(gf) + ",  \"agd\":" + js.Serialize(agd) + "}");

        }

    }
}
