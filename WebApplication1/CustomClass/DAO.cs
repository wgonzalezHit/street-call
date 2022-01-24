using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.CustomClass
{
    public class DAO
    {

        private Connection cnx;

        public DAO()
        {
            cnx = new Connection();
        }

        //-----------------------------------------------------------GEt REvenues per camp
        public List<DataThree> GetRevenuesPerCamp()
        {
            cnx.connection.Open();
            string select = "  exec prGetAgentsVerifiersDayliReport_RealTimeC 0";
            cnx.sqlCommand = new System.Data.SqlClient.SqlCommand(select, cnx.connection);
            cnx.sqlDataReader = cnx.sqlCommand.ExecuteReader();

            List<DataThree> lst = new List<DataThree>();

            while (cnx.sqlDataReader.Read())
            {
                DataThree tbl = new DataThree();
                tbl.Data1 = cnx.sqlDataReader[0].ToString();
                tbl.Data2 = cnx.sqlDataReader[1].ToString();
                tbl.Data3 = cnx.sqlDataReader[2].ToString();
                lst.Add(tbl);
            }
            cnx.connection.Close();

            return lst;

        }
        //-----------------------------------------------------------GEt REvenues per Agent
        public List<DataThree> GetRevenuesPerAgent()
        {
            cnx.connection.Open();
            string select = "  exec prGetAgentsVerifiersDayliReport_RealTimeA 0";
            cnx.sqlCommand = new System.Data.SqlClient.SqlCommand(select, cnx.connection);
            cnx.sqlDataReader = cnx.sqlCommand.ExecuteReader();

            List<DataThree> lst = new List<DataThree>();

            while (cnx.sqlDataReader.Read())
            {
                DataThree tbl = new DataThree();
                tbl.Data1 = cnx.sqlDataReader[0].ToString();
                tbl.Data2 = cnx.sqlDataReader[1].ToString();
                tbl.Data3 = cnx.sqlDataReader[2].ToString();
                lst.Add(tbl);
            }
            cnx.connection.Close();

            return lst;

        }

        //-----------------------------------------------------------GEt REvenues per Agent
        public List<Campaigns> getCamps()
        {
            cnx.connection.Open();
            string select = " select IDCAMPANYA,cast(IDCAMPANYA as varchar)+'-'+ NOMBRE from  CAMPANYA WHERE IDCAMPANYA<>0";
            cnx.sqlCommand = new System.Data.SqlClient.SqlCommand(select, cnx.connection);
            cnx.sqlDataReader = cnx.sqlCommand.ExecuteReader();

            List<Campaigns> lst = new List<Campaigns>();

            while (cnx.sqlDataReader.Read())
            {
                Campaigns tbl = new Campaigns();
                tbl.Id = cnx.sqlDataReader[0].ToString();
                tbl.Nombre = cnx.sqlDataReader[1].ToString();
                lst.Add(tbl);
            }
            cnx.connection.Close();

            return lst;

        }
        //-----------------------------------------------------------WARNING PARTIAL DELETE
        public string WarningPartialDelete(string token, string strjson)
        {
            JObject json = JObject.Parse(strjson);
            var response = "";
            string select = "";
            cnx.connection.Open();
            if (json["type"].ToString() == "keep")
            {
                select = "exec prUpdate_Disable_Cliente '" + json["sujetos"].ToString().Remove(json["sujetos"].ToString().Length - 1) + "','" + token + "','" + json["notes"].ToString() + "'";
            }
            else
            {
                select = "exec prWarningClienteSystemCleanUp '" + json["sujetos"].ToString().Remove(json["sujetos"].ToString().Length - 1) + "','" + token + "','" + json["notes"].ToString() + "'";
            }
            try
            {
                cnx.sqlCommand = new System.Data.SqlClient.SqlCommand(select, cnx.connection);
                cnx.sqlDataReader = cnx.sqlCommand.ExecuteReader();

                while (cnx.sqlDataReader.Read())
                {
                    response = cnx.sqlDataReader[0].ToString();
                }

            }
            catch (Exception e)
            {
                response = e.Message;
            }

            cnx.connection.Close();

            return response;

        }

        //-----------------------------------------------------------GEt REvenues per Agent
        public List<PartialDelete> getRecordsPartialDelete(string strjson)
        {
            string select = "";
            JObject json = JObject.Parse(strjson);
            if (json["type"].ToString() == "campaign")
            {
                select = "SELECT c.NOMBRE, c.APELLIDO1,c.TELEFONO,c.TELEFONO2,EMAIL, tb.IDCAMPANYA,tb.nEstado,tb.IDAGENTEASIGNADO,tb.Atributo_Segmento,tb.atributoSkill,c.IDSUJETO";
                select += " FROM CLIENTES c";
                select += " inner join tbIdentidadSujetoCampanya tb on tb.IDSUJETO = c.IDSUJETO";
                select += " where tb.IDCAMPANYA = " + json["criterio"].ToString()+" and c.IDSUJETO>0";

            }
            else if (json["type"].ToString() == "email")
            {
                var obj = json["criterio"].ToString().Split(',');
                var str = "";
                for (var i = 0; i < obj.Length; i++)
                {
                    str += "'" + obj[i] + "',";
                }
                str = str.Remove(str.Length - 1, 1);
                select = "SELECT c.NOMBRE, c.APELLIDO1,c.TELEFONO,c.TELEFONO2,EMAIL, tb.IDCAMPANYA,tb.nEstado,tb.IDAGENTEASIGNADO,tb.Atributo_Segmento,tb.atributoSkill,c.IDSUJETO";
                select += " FROM CLIENTES c";
                select += " inner join tbIdentidadSujetoCampanya tb on tb.IDSUJETO = c.IDSUJETO";
                select += " where c.EMAIL in (" + str + ")";
            }
            else
            {
                var obj = json["criterio"].ToString().Split(',');
                var str = "";
                for (var i = 0; i < obj.Length; i++)
                {
                    str += "'" + obj[i] + "',";
                }
                str = str.Remove(str.Length - 1, 1);
                select = "SELECT c.NOMBRE, c.APELLIDO1,c.TELEFONO,c.TELEFONO2,EMAIL, tb.IDCAMPANYA,tb.nEstado,tb.IDAGENTEASIGNADO,tb.Atributo_Segmento,tb.atributoSkill,c.IDSUJETO";
                select += " FROM CLIENTES c";
                select += " inner join tbIdentidadSujetoCampanya tb on tb.IDSUJETO = c.IDSUJETO";
                select += " where c.TELEFONO in (" + str + ")";
            }
            cnx.connection.Open();

            cnx.sqlCommand = new System.Data.SqlClient.SqlCommand(select, cnx.connection);
            cnx.sqlDataReader = cnx.sqlCommand.ExecuteReader();

            List<PartialDelete> lst = new List<PartialDelete>();

            while (cnx.sqlDataReader.Read())
            {
                PartialDelete tbl = new PartialDelete();
                tbl.NOMBRE = cnx.sqlDataReader[0].ToString();
                tbl.APELLIDO1 = cnx.sqlDataReader[1].ToString();
                tbl.TELEFONO = cnx.sqlDataReader[2].ToString();
                tbl.TELEFONO2 = cnx.sqlDataReader[3].ToString();
                tbl.EMAIL = cnx.sqlDataReader[4].ToString();
                tbl.IDCAMPANYA = cnx.sqlDataReader[5].ToString();
                tbl.nEstado = cnx.sqlDataReader[6].ToString();
                tbl.IDAGENTEASIGNADO = cnx.sqlDataReader[7].ToString();

                tbl.Atributo_Segmento = cnx.sqlDataReader[8].ToString();
                tbl.atributoSkill = cnx.sqlDataReader[9].ToString();
                tbl.IdSujeto = cnx.sqlDataReader[10].ToString();
                lst.Add(tbl);
            }
            cnx.connection.Close();

            return lst;

        }


        //-----------------------------------------------------------Get Egents callbacks
        public List<AgentsGroupsDispos> getAgentGroupDispos(string lstIdServicio, string lstIdAgente,string tInicio, string tFinal,string campaigns)
        {
            cnx.connection.Open();
            string select = "  exec sp_Report_TiemposAgente_v2 ";
            if (lstIdServicio == "null") { select += "null,"; } else { select += "'" + lstIdServicio + "',"; }
            if (lstIdAgente == "null") { select += "null,"; } else { select += "'" + lstIdAgente + "',"; }
            if (campaigns == "null") { select += "null,"; } else { select += "'" + campaigns + "',"; }
            select +="'"+tInicio+"','"+tFinal+"'";
            cnx.sqlCommand = new System.Data.SqlClient.SqlCommand(select, cnx.connection);
            cnx.sqlDataReader = cnx.sqlCommand.ExecuteReader();

            List<AgentsGroupsDispos> lst = new List<AgentsGroupsDispos>();

            while (cnx.sqlDataReader.Read())
            {
                 AgentsGroupsDispos tbl = new AgentsGroupsDispos();

                tbl.Agents = cnx.sqlDataReader[0].ToString();
               
                tbl.CNA = cnx.sqlDataReader[1].ToString();
                tbl.CA = cnx.sqlDataReader[2].ToString();
                tbl.CMas = cnx.sqlDataReader[3].ToString();
                tbl.Fax = cnx.sqlDataReader[4].ToString();
                tbl.RapelRelance = cnx.sqlDataReader[5].ToString();
                tbl.RefusResponse = cnx.sqlDataReader[6].ToString();


                lst.Add(tbl);
            }
            cnx.connection.Close();

            return lst;

        }
        public List<GroupFin> getGroupFin(string lstIdServicio, string lstIdCampanya, string lstIdSegmento, string lstIdAgente, string lstIdGrupoFinales, string lstIdFinal, string tInicio, string tFinal, string hInicio, string hFinal, string sEntregAg, string sOrigenTrans)
        {
            cnx.connection.Open();
            string select = "  exec sp_Report_Trans_Gfin_v2 ";
            if (lstIdServicio == "null") { select += " null,"; } else { select += "'" + lstIdServicio + "',"; }
            if (lstIdCampanya == "null") { select += "null,"; } else { select += "'" + lstIdCampanya + "',"; }
            if (lstIdSegmento == "null") { select += "null,"; } else { select += "'" + lstIdSegmento + "',"; }
            if (lstIdAgente == "null") { select += "null,"; } else { select += "'" + lstIdAgente + "',"; }
            if (lstIdGrupoFinales == "null") { select += "null,"; } else { select += "'" + lstIdGrupoFinales + "',"; }
            if (lstIdFinal == "null") { select += "null,"; } else { select += "'" + lstIdFinal + "',"; }
            select += "'" + tInicio + "','" + tFinal + "',";
            if (hInicio == "null") { select += "null,"; } else { select += "'" + hInicio + "',"; }
            if (hFinal == "null") { select += "null,"; } else { select += "'" + hFinal + "',"; }
            if (sEntregAg == "null") { select += "null,"; } else { select += "'" + sEntregAg + "',"; }
            if (sOrigenTrans == "null") { select += "null"; } else { select += "'" + sOrigenTrans + "'"; }
            
            cnx.sqlCommand = new System.Data.SqlClient.SqlCommand(select, cnx.connection);
            cnx.sqlDataReader = cnx.sqlCommand.ExecuteReader();

            List<GroupFin> lst = new List<GroupFin>();

            while (cnx.sqlDataReader.Read())
            {
                GroupFin tbl = new GroupFin();

                tbl.Group = cnx.sqlDataReader[1].ToString();
                tbl.Resolution = cnx.sqlDataReader[2].ToString();
                tbl.Transactions = cnx.sqlDataReader[3].ToString();

                lst.Add(tbl);
            }
            cnx.connection.Close();

            return lst;

        }

        //-----------------------------------------------------------Get Egents callbacks
        public List<DataThree> GetAgentCallbacks(string aid)
        {
            cnx.connection.Open();
            string select = "  exec getAgentCallbacks '"+aid+"'";
            cnx.sqlCommand = new System.Data.SqlClient.SqlCommand(select, cnx.connection);
            cnx.sqlDataReader = cnx.sqlCommand.ExecuteReader();

            List<DataThree> lst = new List<DataThree>();

            while (cnx.sqlDataReader.Read())
            {
                DataThree tbl = new DataThree();
                tbl.Data1 = cnx.sqlDataReader[0].ToString();
                tbl.Data2 = cnx.sqlDataReader[1].ToString();
                tbl.Data3 = cnx.sqlDataReader[2].ToString();
                tbl.Data4 = cnx.sqlDataReader[3].ToString();
                lst.Add(tbl);
            }
            cnx.connection.Close();

            return lst;

        }
        //-----------------------------------------------------------Get Egents callbacks
        public string setCallBack(string strjson)
        {
            JObject json = JObject.Parse(strjson);
            var response = "";
            cnx.connection.Open();
            string select = " update tbIdentidadSujetocampanya set nEstado = 0,atributoSkill='next',TPROXIMOCONTACTO=(SELECT DATEADD(SS,-240,GETDATE())), IDAGENTEASIGNADO=" + json["agentId"].ToString()+" where IDSUJETO = "+json["idsujeto"].ToString();
            try
            {
                cnx.sqlCommand = new System.Data.SqlClient.SqlCommand(select, cnx.connection);
                cnx.sqlDataReader = cnx.sqlCommand.ExecuteReader();

                while (cnx.sqlDataReader.Read())
                {
                   
                   response+= cnx.sqlDataReader[0].ToString()+"|";
                    response += cnx.sqlDataReader[1].ToString() + "|";
                    response += cnx.sqlDataReader[2].ToString() + "|";
                    
                }
            }
            catch (Exception e)
            {
                response = e.Message;
            }

            cnx.connection.Close();

            return response;

        }

        //-----------------------------------------------------------GEt REvenues per Agent
        public List<Twenty> GetTwenty(string agents, string services, string campaigns, string segments, string chanel, string ini, string fin, string sentido)
        {

            if ((agents == "")||(agents==" ")) { agents = "null"; } else { agents = "'" + agents + "'"; }
            if ((services == "")||(services==" ")) { services = "null"; } else { services = "'" + services + "'"; }
            if ((campaigns == "") || (campaigns==" ")) { campaigns = "null"; } else { campaigns = "'" + campaigns + "'"; }
            if (segments == "") { segments = "null"; } else { segments = "'" + segments + "'"; }
            if (chanel == "") { chanel = "null"; } else { chanel = "'" + chanel + "'"; }
            cnx.connection.Open();
            string select = "  exec sp_Report_Contactos_Agen2 "+services+","+campaigns+","+segments+","+agents+",'" +ini+"','"+fin+"','" +sentido+"'," +chanel+ ",''";
            cnx.sqlCommand = new System.Data.SqlClient.SqlCommand(select, cnx.connection);
            cnx.sqlDataReader = cnx.sqlCommand.ExecuteReader();

            List<Twenty> lst = new List<Twenty>();

            while (cnx.sqlDataReader.Read())
            {
                Twenty tbl = new Twenty();
                tbl.Data0 = cnx.sqlDataReader[0].ToString(); 
                tbl.Data1 = cnx.sqlDataReader[1].ToString();
                tbl.Data2 = cnx.sqlDataReader[2].ToString();
                tbl.Data3 = cnx.sqlDataReader[3].ToString();
                tbl.Data4 = cnx.sqlDataReader[4].ToString();
                tbl.Data5 = cnx.sqlDataReader[5].ToString();
                tbl.Data6 = cnx.sqlDataReader[6].ToString();
                tbl.Data7 = cnx.sqlDataReader[7].ToString();
                tbl.Data8 = cnx.sqlDataReader[8].ToString();
                tbl.Data9 = cnx.sqlDataReader[9].ToString();
                tbl.Data10= cnx.sqlDataReader[10].ToString();
                tbl.Data11 = cnx.sqlDataReader[11].ToString();
                tbl.Data12= cnx.sqlDataReader[12].ToString();
                tbl.Data13= cnx.sqlDataReader[13].ToString();
                tbl.Data14= cnx.sqlDataReader[14].ToString();
                tbl.Data15= cnx.sqlDataReader[15].ToString();
                tbl.Data16 = cnx.sqlDataReader[16].ToString();
                tbl.Data17 = cnx.sqlDataReader[17].ToString();
                tbl.Data18 = cnx.sqlDataReader[18].ToString();
                tbl.Data19 = cnx.sqlDataReader[19].ToString();

                lst.Add(tbl);
            }
            cnx.connection.Close();

            return lst;

        }

        public void UpdateCustomer(int id, string idname, string column, string type, string value, string conn, string table)
        {
            string select = "EXEC [EVOLUTIONDB].[dbo].[prUpdateU] '" + id + "' ,'" + idname + "' ,'" + column + "','" + type + "','" + value + "' ,'" + conn + "' ,'" + table + "'";
            //Debug.WriteLine(select); exec proUpdateCLIENTES_field 100046156,'OBSERVACIONES','varchar','Commentssssss'
            DoSQL(select);

        }

        public string  AddNumberToDoNotCall(string json)
        {
            JObject ob = JObject.Parse(json);
            
            string select = "EXEC prAddNumberToDoNotCall '" + ob["phone"].ToString() + "' ," + ob["idcampanya"].ToString() + " ," + ob["idagent"].ToString();
            //Debug.WriteLine(select); exec proUpdateCLIENTES_field 100046156,'OBSERVACIONES','varchar','Commentssssss'
          return  DoSQL2(select);

        }
        public void UpdateDatosCustomer( string column, string value, string idsujeto)
        {
            string select = "exec prInsertUpldateDatosCliente '"+ idsujeto + "','"+column+"','"+value+"'";
            //Debug.WriteLine(select); exec proUpdateCLIENTES_field 100046156,'OBSERVACIONES','varchar','Commentssssss'
            DoSQL(select);

        }
/*  
        public void UpdateDatosCustomer(string column, string value, string idsujeto)
        {
            string select = "update [EVOLUTIONDB].[dbo].[tbDatosCliente] set valor='" + value + "' where clave ='" + column + "' and idSujeto =" + idsujeto;
            //Debug.WriteLine(select); exec proUpdateCLIENTES_field 100046156,'OBSERVACIONES','varchar','Commentssssss'
            DoSQL(select);

        }
*/


        //-----------------------------------------------------------GEt REvenues per Agent
        public List<DataThree> GetCountVerifierAvailable(string session)
        {
            cnx.connection.Open();
            string select = "exec prGetVerifiersReady '" + session + "'";
            cnx.sqlCommand = new System.Data.SqlClient.SqlCommand(select, cnx.connection);
            cnx.sqlDataReader = cnx.sqlCommand.ExecuteReader();

            List<DataThree> lst = new List<DataThree>();

            while (cnx.sqlDataReader.Read())
            {
                DataThree tbl = new DataThree();
                tbl.Data1 = cnx.sqlDataReader[0].ToString();
                tbl.Data2 = cnx.sqlDataReader[1].ToString();
                tbl.Data3 = cnx.sqlDataReader[2].ToString();
                lst.Add(tbl);
            }
            cnx.connection.Close();

            return lst;

        }

        //-----------------------------------------------------------GEt REvenues per Agent
        public List<twentySix> UniversalReport(string strjson)
        {
            var agents = ""; var services = ""; var campaigns = ""; var segments = ""; var chanel = "";

            JObject json = JObject.Parse(strjson);
            if ((json["agents"].ToString() == "") || (json["agents"].ToString() == " ")) { agents = "null"; } else { agents = "'" + json["agents"].ToString() + "'"; }
            if ((json["services"].ToString() == "") || (json["services"].ToString() == " ")) { services = "null"; } else { services = "'" + json["services"].ToString() + "'"; }
            if ((json["campaigns"].ToString() == "") || (json["campaigns"].ToString() == " ")) { campaigns = "null"; } else { campaigns = "'" + json["campaigns"].ToString() + "'"; }
            if (json["segment"].ToString() == "") { segments = "null"; } else { segments = "'" + json["segments"].ToString() + "'"; }
            if (json["chanel"].ToString() == "") { chanel = "null"; } else { chanel = "'" + json["chanel"].ToString() + "'"; }
            cnx.connection.Open();
            string select = "  exec " + json["procedure"].ToString() + " " + campaigns + "," + services + "," + agents + ",'" + json["ini"].ToString() + "','" + json["fin"].ToString() + "'";
            cnx.sqlCommand = new System.Data.SqlClient.SqlCommand(select, cnx.connection);
            cnx.sqlDataReader = cnx.sqlCommand.ExecuteReader();

            List<twentySix> lst = new List<twentySix>();

            while (cnx.sqlDataReader.Read())
            {
                twentySix tbl = new twentySix();
                tbl.Data0 = cnx.sqlDataReader[0].ToString();
                tbl.Data1 = cnx.sqlDataReader[1].ToString();
                tbl.Data2 = cnx.sqlDataReader[2].ToString();
                tbl.Data3 = cnx.sqlDataReader[3].ToString();
                tbl.Data4 = cnx.sqlDataReader[4].ToString();
                tbl.Data5 = cnx.sqlDataReader[5].ToString();
                tbl.Data6 = cnx.sqlDataReader[6].ToString();
                tbl.Data7 = cnx.sqlDataReader[7].ToString();
                tbl.Data8 = cnx.sqlDataReader[8].ToString();
                tbl.Data9 = cnx.sqlDataReader[9].ToString();
                tbl.Data10 = cnx.sqlDataReader[10].ToString();
                tbl.Data11 = cnx.sqlDataReader[11].ToString();
                tbl.Data12 = cnx.sqlDataReader[12].ToString();
                tbl.Data13 = cnx.sqlDataReader[13].ToString();
                tbl.Data14 = cnx.sqlDataReader[14].ToString();
                tbl.Data15 = cnx.sqlDataReader[15].ToString();
                tbl.Data16 = cnx.sqlDataReader[16].ToString();
                tbl.Data17 = cnx.sqlDataReader[17].ToString();
                tbl.Data18 = cnx.sqlDataReader[18].ToString();
                tbl.Data19 = cnx.sqlDataReader[19].ToString();
                tbl.Data20 = cnx.sqlDataReader[20].ToString();
                tbl.Data21 = cnx.sqlDataReader[21].ToString();
                tbl.Data22 = cnx.sqlDataReader[22].ToString();
                tbl.Data23 = cnx.sqlDataReader[23].ToString();
                tbl.Data24 = cnx.sqlDataReader[24].ToString();
                tbl.Data25 = cnx.sqlDataReader[25].ToString();
                //tbl.Data26 = cnx.sqlDataReader[26].ToString();
                lst.Add(tbl);
            }
            cnx.connection.Close();

            return lst;

        }

        //-----------------------------------------------------------GEt REvenues per Agent
        public List<AddicionalContactList> getAddicionalContacs(string campId, string empresa)
        {

            cnx.connection.Open();
            string select = "select tb.IDSUJETO,c.FAX,c.IDORIGINAL,c.NOMBRE,c.APELLIDO1,c.TELEFONO,c.TELEFONO2,c.MOVIL,c.EMAIL,c.TEXTO1,c.sEmpresa FROM CLIENTES c inner join tbIdentidadSujetoCampanya tb on tb.IDSUJETO = c.IDSUJETO where tb.IDCAMPANYA = "+campId+" and c.sEmpresa = '"+empresa+"'";
            cnx.sqlCommand = new System.Data.SqlClient.SqlCommand(select, cnx.connection);
            cnx.sqlDataReader = cnx.sqlCommand.ExecuteReader();
            List<AddicionalContactList> lst = new List<AddicionalContactList>();

            while (cnx.sqlDataReader.Read())
            {
                AddicionalContactList tbl = new AddicionalContactList();
                tbl.idsujeto = cnx.sqlDataReader[0].ToString();
                tbl.Fax = cnx.sqlDataReader[1].ToString();
                tbl.ClienID = cnx.sqlDataReader[2].ToString();
                tbl.First_Name = cnx.sqlDataReader[3].ToString();
                tbl.Last_Name = cnx.sqlDataReader[4].ToString();
                tbl.Phone = cnx.sqlDataReader[5].ToString();
                tbl.Direct_Phone = cnx.sqlDataReader[6].ToString();
                tbl.Mobile = cnx.sqlDataReader[7].ToString();
                tbl.Email = cnx.sqlDataReader[8].ToString();
                tbl.Function = cnx.sqlDataReader[9].ToString();
                tbl.sEmnpresa = cnx.sqlDataReader[10].ToString();

                lst.Add(tbl);
            }
            cnx.connection.Close();
            return lst;
        }


        //-----------------------------------------------------------GEt REvenues per Agent
        public List<Twenty> getCallStatusCalls(string strjson)
        {
            var agents = ""; var services = ""; var campaigns = ""; var segments = ""; var chanel = "";

            JObject json = JObject.Parse(strjson);

            if ((json["agents"].ToString() == "") || (json["agents"].ToString() == " ")) { agents = "null"; } else { agents = "'" + json["agents"].ToString() + "'"; }
            if ((json["services"].ToString() == "") || (json["services"].ToString() == " ")) { services = "null"; } else { services = "'" + json["services"].ToString() + "'"; }
            if ((json["campaigns"].ToString() == "") || (json["campaigns"].ToString() == " ")) { campaigns = "null"; } else { campaigns = "'" + json["campaigns"].ToString() + "'"; }
            if (json["segment"].ToString() == "") { segments = "null"; } else { segments = "'" + json["segment"].ToString() + "'"; }
            if (json["chanel"].ToString() == "") { chanel = "null"; } else { chanel = "'" + json["chanel"].ToString() + "'"; }

            cnx.connection.Open();
            string select = "  exec sp_Report_Trans_Camp3 " + campaigns + "," + services + "," + agents + ","+segments+",'" + json["ini"].ToString() + "','" + json["fin"].ToString() + "','"+json["final"].ToString()+"'";
            cnx.sqlCommand = new System.Data.SqlClient.SqlCommand(select, cnx.connection);
            cnx.sqlDataReader = cnx.sqlCommand.ExecuteReader();
            List<Twenty> lst = new List<Twenty>();

            while (cnx.sqlDataReader.Read())
            {
                Twenty tbl = new Twenty();
                tbl.Data0 = cnx.sqlDataReader[0].ToString();
                tbl.Data1 = cnx.sqlDataReader[1].ToString();
                tbl.Data2 = cnx.sqlDataReader[2].ToString();
                tbl.Data3 = cnx.sqlDataReader[3].ToString();
                tbl.Data4 = cnx.sqlDataReader[4].ToString();
                tbl.Data5 = cnx.sqlDataReader[5].ToString();
                tbl.Data6 = cnx.sqlDataReader[6].ToString();
                tbl.Data7 = cnx.sqlDataReader[7].ToString();
                tbl.Data8 = cnx.sqlDataReader[8].ToString();
                tbl.Data9 = cnx.sqlDataReader[9].ToString();
                tbl.Data10 = cnx.sqlDataReader[10].ToString();
                tbl.Data11 = cnx.sqlDataReader[11].ToString();
                tbl.Data12 = cnx.sqlDataReader[12].ToString();
                tbl.Data13 = cnx.sqlDataReader[13].ToString();
                tbl.Data14 = cnx.sqlDataReader[14].ToString();
                tbl.Data15 = cnx.sqlDataReader[15].ToString();
                tbl.Data16 = cnx.sqlDataReader[16].ToString();
                tbl.Data17 = cnx.sqlDataReader[17].ToString();
                //tbl.Data26 = cnx.sqlDataReader[26].ToString();
                lst.Add(tbl);
            }
            cnx.connection.Close();
            return lst;
       }


        //--------------------------------------------------get Path-----------------------
        public List<RecordingPath> GetPath(string idtransaction)
        {
            List<RecordingPath> lst = new List<RecordingPath>();
            var response = "";
            cnx.connection.Open(); 
            string select = "select [sFicheroVoz] from  [EVOLUTIONDB].[dbo].[tbGrabacion] where idTransaccion = "+ idtransaction;
            
            try{
                cnx.sqlCommand = new System.Data.SqlClient.SqlCommand(select, cnx.connection);
                cnx.sqlDataReader = cnx.sqlCommand.ExecuteReader();
                while (cnx.sqlDataReader.Read())
                {
                    RecordingPath ls = new RecordingPath();
                    ls.Path = cnx.sqlDataReader[0].ToString();
                    lst.Add(ls);
                }
                cnx.connection.Close();
            }
            catch (Exception e)
            {
                cnx.connection.Close();
            }


            return lst;
        }



        private void DoSQL(string consultaSQL)
        {

            try
            {
                cnx.connection.Open();
                cnx.sqlCommand = new System.Data.SqlClient.SqlCommand(consultaSQL, cnx.connection);
                cnx.sqlCommand.ExecuteNonQuery();
                cnx.connection.Close();
            }
            catch (Exception ex)
            {
                cnx.connection.Close();
                Console.WriteLine(ex);
            }

        }

        private string DoSQL2(string consultaSQL)
        {
            var res = "";
            try
            {
                cnx.connection.Open();
                cnx.sqlCommand = new System.Data.SqlClient.SqlCommand(consultaSQL, cnx.connection);
                cnx.sqlCommand.ExecuteNonQuery();
                cnx.connection.Close();
                res = "Added";
            }
            catch (Exception ex)
            {
                cnx.connection.Close();
                Console.WriteLine(ex);
                res = ex.Message;
            }
            return res;
        }
    }

}