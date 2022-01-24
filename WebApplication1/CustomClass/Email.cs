using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;


namespace WebApplication1.CustomClass
{
    public class Email
    {
        public static void sendTemplate1(string myjson)
        {

            
            JObject json = JObject.Parse(myjson);
            var nombre = json["nombre"];
            var cuerpo = "cuerpo";
            try
            {
                var to = json["correos"].ToString().Replace("\r\n", ",").Replace("\n", ",").Replace("\r", ",");
                using (StreamReader reader = new StreamReader(HttpContext.Current.Server.MapPath("template1.html")))
                {
                    cuerpo = reader.ReadToEnd();
                }
                cuerpo = cuerpo.Replace("{nombre}", nombre.ToString());
                cuerpo = cuerpo.Replace("{fecha}", json["fecha"].ToString());
                cuerpo = cuerpo.Replace("{time}", json["time"].ToString());
                SmtpClient client = new SmtpClient();
                client.Port = 587;
                client.Host = "smtp.gmail.com";
                client.EnableSsl = true;
                client.Timeout = 10000;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential("nobelbizreports@gmail.com", "vvQ43$Ma");

                var correos = to.Split(',');

                foreach (var item in correos)
                {
                    System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage("nobelbizreports@gmail.com", item, json["subject"].ToString(), cuerpo);
                    MailAddress from = new MailAddress("nobelbizreports@gmail.com", json["envia"].ToString());
                    mail.From = from;
                    mail.BodyEncoding = UTF8Encoding.UTF8;
                    mail.IsBodyHtml = true;
                    mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
                    //mail.Attachments.Add(data);
                    client.Send(mail);
                }



            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }
        }


        public static void sendTemplate2(string myjson)
        {
            JObject json = JObject.Parse(myjson);
           
            var cuerpo = "cuerpo";
            try
            {
                var to = json["correos"].ToString().Replace("\r\n", ",").Replace("\n", ",").Replace("\r", ",");
                using (StreamReader reader = new StreamReader(HttpContext.Current.Server.MapPath("template2.html")))
                {
                    cuerpo = reader.ReadToEnd();
                }
                cuerpo = cuerpo.Replace("{MODENSEIGNE}", json["MODENSEIGNE"].ToString());
                cuerpo = cuerpo.Replace("{POSTAL_CODE}", json["POSTAL_CODE"].ToString());
                cuerpo = cuerpo.Replace("{CITY}", json["CITY"].ToString());
                cuerpo = cuerpo.Replace("{PHONE_NUMBER}", json["PHONE_NUMBER"].ToString());
                cuerpo = cuerpo.Replace("{EMAIL}", json["EMAIL"].ToString());
                cuerpo = cuerpo.Replace("{DATERDV}", json["DATERDV"].ToString());
                cuerpo = cuerpo.Replace("{HEURERDV}", json["HEURERDV"].ToString());
                cuerpo = cuerpo.Replace("{NOM}", json["NOM"].ToString());
                cuerpo = cuerpo.Replace("{FONCTION}", json["FONCTION"].ToString());
                cuerpo = cuerpo.Replace("{ALT_PHONE}", json["ALT_PHONE"].ToString());
                cuerpo = cuerpo.Replace("{ADDRESS1}", json["ADDRESS1"].ToString());
                cuerpo = cuerpo.Replace("{FOURNISSEUR_ACTUEL}", json["FOURNISSEUR_ACTUEL"].ToString());
                cuerpo = cuerpo.Replace("{PUISSANCE_COMPTEUR}", json["PUISSANCE_COMPTEUR"].ToString());
                cuerpo = cuerpo.Replace("{POSTES}", json["POSTES"].ToString());
                cuerpo = cuerpo.Replace("{FOURNISSEUR_GAZ}", json["FOURNISSEUR_GAZ"].ToString());
                cuerpo = cuerpo.Replace("{ECHEANCE_GAZ}", json["ECHEANCE_GAZ"].ToString());
                cuerpo = cuerpo.Replace("{UTILISATION_GAZ}", json["UTILISATION_GAZ"].ToString());
                cuerpo = cuerpo.Replace("{SCORING}", json["SCORING"].ToString());
                cuerpo = cuerpo.Replace("{FACTURE}", json["FACTURE"].ToString());
                cuerpo = cuerpo.Replace("{ETUDE_PERSO}", json["ETUDE_PERSO"].ToString());
                cuerpo = cuerpo.Replace("{FOURNISSEUR_PERSO}", json["FOURNISSEUR_PERSO"].ToString());
                SmtpClient client = new SmtpClient();
                client.Port = 587;
                client.Host = "smtp.gmail.com";
                client.EnableSsl = true;
                client.Timeout = 10000;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential("nobelbizreports@gmail.com", "vvQ43$Ma");

                var correos = to.Split(',');

                foreach (var item in correos)
                {
                    System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage("nobelbizreports@gmail.com", item, json["subject"].ToString(), cuerpo);
                    MailAddress from = new MailAddress("nobelbizreports@gmail.com", json["envia"].ToString());
                    mail.From = from;
                    mail.BodyEncoding = UTF8Encoding.UTF8;
                    mail.IsBodyHtml = true;
                    mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
                    //mail.Attachments.Add(data);
                    client.Send(mail);
                }



            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }
        }

        public static void CONFIRMATION_MAIL_RDV_REPORTE_2Client2(string myjson)
        {
            JObject json = JObject.Parse(myjson);
            var nombre = json["nombre"];
            var cuerpo = "cuerpo";
            try
            {
                var to = json["correos"].ToString().Replace("\r\n", ",").Replace("\n", ",").Replace("\r", ",");
                using (StreamReader reader = new StreamReader(HttpContext.Current.Server.MapPath("CONFIRMATION_MAIL_RDV_REPORTE_2Client2.html")))
                {
                    cuerpo = reader.ReadToEnd();
                }
                cuerpo = cuerpo.Replace("@DATERDV1@", json["DATERDV1"].ToString());
                cuerpo = cuerpo.Replace("@HEURERDV1@", json["HEURERDV1"].ToString());
                cuerpo = cuerpo.Replace("@CCIAL@", json["CCIAL"].ToString());
                cuerpo = cuerpo.Replace("@DATERDV2@", json["DATERDV2"].ToString());
                cuerpo = cuerpo.Replace("@HEURERDV2@", json["HEURERDV2"].ToString());
                cuerpo = cuerpo.Replace("@MODCIV@", json["MODCIV"].ToString());
                cuerpo = cuerpo.Replace("@MODNOM@", json["MODNOM"].ToString());
                cuerpo = cuerpo.Replace("@CCIAL@", json["CCIAL"].ToString());
                cuerpo = cuerpo.Replace("@PORTCCIAL@", json["PORTCCIAL"].ToString());
                cuerpo = cuerpo.Replace("MAILCIAL@", json["MAILCIAL"].ToString());

                SmtpClient client = new SmtpClient();
                client.Port = 587;
                client.Host = "smtp.gmail.com";
                client.EnableSsl = true;
                client.Timeout = 10000;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential("nobelbizreports@gmail.com", "vvQ43$Ma");

                var correos = to.Split(',');

                foreach (var item in correos)
                {
                    System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage("nobelbizreports@gmail.com", item, json["subject"].ToString(), cuerpo);
                    MailAddress from = new MailAddress("nobelbizreports@gmail.com", json["envia"].ToString());
                    mail.From = from;
                    mail.BodyEncoding = UTF8Encoding.UTF8;
                    mail.IsBodyHtml = true;
                    mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
                    //mail.Attachments.Add(data);
                    client.Send(mail);
                }



            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }
        }
        public static void Fiche_Annulation_Rdv_TOTAL_5(string myjson)
        {
            JObject json = JObject.Parse(myjson);
            var nombre = json["nombre"];
            var cuerpo = "cuerpo";
            try
            {
                var to = json["correos"].ToString().Replace("\r\n", ",").Replace("\n", ",").Replace("\r", ",");
                using (StreamReader reader = new StreamReader(HttpContext.Current.Server.MapPath("Fiche_Annulation_Rdv_TOTAL_5.html")))
                {
                    cuerpo = reader.ReadToEnd();
                }
                cuerpo = cuerpo.Replace("@RESULTAT1@", json["RESULTAT1"].ToString());
                cuerpo = cuerpo.Replace("@CCIAL@", json["CCIAL"].ToString());
                cuerpo = cuerpo.Replace("@DATE_JOUR@", json["DATE_JOUR"].ToString());
                cuerpo = cuerpo.Replace("@LOGGIN@", json["LOGGIN"].ToString());
                cuerpo = cuerpo.Replace("@MODRS1@", json["MODRS1"].ToString());
                cuerpo = cuerpo.Replace("@MODRS2@", json["MODRS2"].ToString());
                cuerpo = cuerpo.Replace("@MODENSEIGNE@", json["MODENSEIGNE"].ToString());
                cuerpo = cuerpo.Replace("@MODADR1@", json["MODADR1"].ToString());
                cuerpo = cuerpo.Replace("@MODADR2@", json["MODADR2"].ToString());
                cuerpo = cuerpo.Replace("@MODADR3@", json["MODADR3"].ToString());
                cuerpo = cuerpo.Replace("@MODCP@", json["MODCP"].ToString());
                cuerpo = cuerpo.Replace("@MODVILLE@", json["MODVILLE"].ToString());
                cuerpo = cuerpo.Replace("@MODTEL@", json["MODTEL"].ToString());
                cuerpo = cuerpo.Replace("@MODMAIL@", json["MODMAIL"].ToString());
                cuerpo = cuerpo.Replace("@MODCIV@", json["MODCIV"].ToString());
                cuerpo = cuerpo.Replace("@MODNOM@", json["MODNOM"].ToString());
                cuerpo = cuerpo.Replace("@MODPRENOM@", json["MODPRENOM"].ToString());
                cuerpo = cuerpo.Replace("@MODFONCTION@", json["MODFONCTION"].ToString());
                cuerpo = cuerpo.Replace("@MODPORT@", json["MODPORT"].ToString());
                cuerpo = cuerpo.Replace("@MODMAIL@", json["MODMAIL"].ToString());
                cuerpo = cuerpo.Replace("@DATERDV1@", json["DATERDV1"].ToString());
                cuerpo = cuerpo.Replace("@HEURERDV1@", json["HEURERDV1"].ToString());
                cuerpo = cuerpo.Replace("@INDICATIONS@", json["INDICATIONS"].ToString());
                cuerpo = cuerpo.Replace("@FOURNISSEUR_ACTUEL@", json["FOURNISSEUR_ACTUEL"].ToString());
                cuerpo = cuerpo.Replace("@DATE_ECHEANCE@", json["DATE_ECHEANCE"].ToString());
                cuerpo = cuerpo.Replace("@COMM1@", json["COMM1"].ToString());
                cuerpo = cuerpo.Replace("@SUITECOMM1@", json["SUITECOMM1"].ToString());
                cuerpo = cuerpo.Replace("@COMMENTAIR1@", json["COMMENTAIR1"].ToString());
                SmtpClient client = new SmtpClient();
                client.Port = 587;
                client.Host = "smtp.gmail.com";
                client.EnableSsl = true;
                client.Timeout = 10000;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential("nobelbizreports@gmail.com", "vvQ43$Ma");

                var correos = to.Split(',');

                foreach (var item in correos)
                {
                    System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage("nobelbizreports@gmail.com", item, json["subject"].ToString(), cuerpo);
                    MailAddress from = new MailAddress("nobelbizreports@gmail.com", json["envia"].ToString());
                    mail.From = from;
                    mail.BodyEncoding = UTF8Encoding.UTF8;
                    mail.IsBodyHtml = true;
                    mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
                    //mail.Attachments.Add(data);
                    client.Send(mail);
                }



            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }
        }
        public static void Fiche_Modif_Rdv_TOTAL_4(string myjson)
        {
            JObject json = JObject.Parse(myjson);
            var nombre = json["nombre"];
            var cuerpo = "cuerpo";
            try
            {
                var to = json["correos"].ToString().Replace("\r\n", ",").Replace("\n", ",").Replace("\r", ",");
                using (StreamReader reader = new StreamReader(HttpContext.Current.Server.MapPath("Fiche_Modif_Rdv_TOTAL_4.html")))
                {
                    cuerpo = reader.ReadToEnd();
                }
                cuerpo = cuerpo.Replace("@RESULTAT1@", json["RESULTAT1"].ToString());
                cuerpo = cuerpo.Replace("@CCIAL@", json["CCIAL"].ToString());
                cuerpo = cuerpo.Replace("@DATE_JOUR@", json["DATE_JOUR"].ToString());
                cuerpo = cuerpo.Replace("@LOGGIN@", json["LOGGIN"].ToString());
                cuerpo = cuerpo.Replace("@MODIFRS1@", json["MODIFRS1"].ToString());
                cuerpo = cuerpo.Replace("@MODIFRS2@", json["MODIFRS2"].ToString());
                cuerpo = cuerpo.Replace("@MODIFENSEIGNE@", json["MODIFENSEIGNE"].ToString());
                cuerpo = cuerpo.Replace("@MODIFADR1@", json["MODIFADR1"].ToString());
                cuerpo = cuerpo.Replace("@MODIFADR2@", json["MODIFADR2"].ToString());
                cuerpo = cuerpo.Replace("@MODIFADR3@", json["MODIFADR3"].ToString());
                cuerpo = cuerpo.Replace("@MODIFCP@", json["MODIFCP"].ToString());
                cuerpo = cuerpo.Replace("@MODIFVILLE@", json["MODIFVILLE"].ToString());
                cuerpo = cuerpo.Replace("@MODIFTEL@", json["MODIFTEL"].ToString());
                cuerpo = cuerpo.Replace("@MODIFMAIL@", json["MODIFMAIL"].ToString());
                cuerpo = cuerpo.Replace("@MODIFCIV@", json["MODIFCIV"].ToString());
                cuerpo = cuerpo.Replace("@MODIFNOM@", json["MODIFNOM"].ToString());
                cuerpo = cuerpo.Replace("@MODIFPRENOM@", json["MODIFPRENOM"].ToString());
                cuerpo = cuerpo.Replace("@MODIFFONCTION@", json["MODIFFONCTION"].ToString());
                cuerpo = cuerpo.Replace("@MODIFLIGNEDIRECT@", json["MODIFLIGNEDIRECT"].ToString());
                cuerpo = cuerpo.Replace("@MODIFMAIL@", json["MODIFMAIL"].ToString());
                cuerpo = cuerpo.Replace("@DATERDV1@", json["DATERDV1"].ToString());
                cuerpo = cuerpo.Replace("@HEURERDV1@", json["HEURERDV1"].ToString());
                cuerpo = cuerpo.Replace("@INDICATIONS@", json["INDICATIONS"].ToString());
                cuerpo = cuerpo.Replace("@FOURNISSEUR_ACTUEL@", json["FOURNISSEUR_ACTUEL"].ToString());
                cuerpo = cuerpo.Replace("@DATE_ECHEANCE@", json["DATE_ECHEANCE"].ToString());
                cuerpo = cuerpo.Replace("@FOURNISSEUR_GAZ@", json["FOURNISSEUR_GAZ"].ToString());
                cuerpo = cuerpo.Replace("@ECHEANCE_GAZ@", json["ECHEANCE_GAZ"].ToString());
                cuerpo = cuerpo.Replace("@UTILISATION_GAZ@", json["UTILISATION_GAZ"].ToString());
                cuerpo = cuerpo.Replace("@AUTRE_GAZ@", json["AUTRE_GAZ"].ToString());
                cuerpo = cuerpo.Replace("@ENVOI_FACTURE@", json["ENVOI_FACTURE"].ToString());
                cuerpo = cuerpo.Replace("@COMM1@", json["COMM1"].ToString());
                cuerpo = cuerpo.Replace("@SUITECOMM1@", json["SUITECOMM1"].ToString());
                cuerpo = cuerpo.Replace("@COMMENTAIR1@", json["COMMENTAIR1"].ToString());


                SmtpClient client = new SmtpClient();
                client.Port = 587;
                client.Host = "smtp.gmail.com";
                client.EnableSsl = true;
                client.Timeout = 10000;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential("nobelbizreports@gmail.com", "vvQ43$Ma");

                var correos = to.Split(',');

                foreach (var item in correos)
                {
                    System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage("nobelbizreports@gmail.com", item, json["subject"].ToString(), cuerpo);
                    MailAddress from = new MailAddress("nobelbizreports@gmail.com", json["envia"].ToString());
                    mail.From = from;
                    mail.BodyEncoding = UTF8Encoding.UTF8;
                    mail.IsBodyHtml = true;
                    mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
                    //mail.Attachments.Add(data);
                    client.Send(mail);
                }



            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }
        }
        public static void Fiche_Report_Rdv_TOTAL_2(string myjson)
        {
            JObject json = JObject.Parse(myjson);
            var nombre = json["nombre"];
            var cuerpo = "cuerpo";
            try
            {
                var to = json["correos"].ToString().Replace("\r\n", ",").Replace("\n", ",").Replace("\r", ",");
                using (StreamReader reader = new StreamReader(HttpContext.Current.Server.MapPath("Fiche_Report_Rdv_TOTAL_2.html")))
                {
                    cuerpo = reader.ReadToEnd();
                }
                cuerpo = cuerpo.Replace("@RESULTAT1@", json["RESULTAT1"].ToString());
                cuerpo = cuerpo.Replace("@CCIAL@", json["CCIAL"].ToString());
                cuerpo = cuerpo.Replace("@DATE_JOUR@", json["DATE_JOUR"].ToString());
                cuerpo = cuerpo.Replace("@LOGGIN@", json["LOGGIN"].ToString());
                cuerpo = cuerpo.Replace("@MODRS1@", json["MODRS1"].ToString());
                cuerpo = cuerpo.Replace("@MODRS2@", json["MODRS2"].ToString());
                cuerpo = cuerpo.Replace("@MODENSEIGNE@", json["MODENSEIGNE"].ToString());
                cuerpo = cuerpo.Replace("@MODADR1@", json["MODADR1"].ToString());
                cuerpo = cuerpo.Replace("@MODADR2@", json["MODADR2"].ToString());
                cuerpo = cuerpo.Replace("@MODADR3@", json["MODADR3"].ToString());
                cuerpo = cuerpo.Replace("@MODCP@", json["MODCP"].ToString());
                cuerpo = cuerpo.Replace("@MODVILLE@", json["MODVILLE"].ToString());
                cuerpo = cuerpo.Replace("@MODTEL@", json["MODTEL"].ToString());
                cuerpo = cuerpo.Replace("@MODMAIL@", json["MODMAIL"].ToString());
                cuerpo = cuerpo.Replace("@MODCIV@", json["MODCIV"].ToString());
                cuerpo = cuerpo.Replace("@MODNOM@", json["MODNOM"].ToString());
                cuerpo = cuerpo.Replace("@MODPRENOM@", json["MODPRENOM"].ToString());
                cuerpo = cuerpo.Replace("@MODFONCTION@", json["MODFONCTION"].ToString());
                cuerpo = cuerpo.Replace("@MODPORT@", json["MODPORT"].ToString());
                cuerpo = cuerpo.Replace("@MODMAIL@", json["MODMAIL"].ToString());
                cuerpo = cuerpo.Replace("@DATERDV2@", json["DATERDV2"].ToString());
                cuerpo = cuerpo.Replace("@HEURERDV2@", json["HEURERDV2"].ToString());
                cuerpo = cuerpo.Replace("@INDICATIONS@", json["INDICATIONS"].ToString());
                cuerpo = cuerpo.Replace("@FOURNISSEUR_ACTUEL@", json["FOURNISSEUR_ACTUEL"].ToString());
                cuerpo = cuerpo.Replace("@DATE_ECHEANCE@", json["DATE_ECHEANCE"].ToString());
                cuerpo = cuerpo.Replace("@FOURNISSEUR_GAZ@", json["FOURNISSEUR_GAZ"].ToString());
                cuerpo = cuerpo.Replace("@ECHEANCE_GAZ@", json["ECHEANCE_GAZ"].ToString());
                cuerpo = cuerpo.Replace("@UTILISATION_GAZ@", json["UTILISATION_GAZ"].ToString());
                cuerpo = cuerpo.Replace("@AUTRE_GAZ@", json["AUTRE_GAZ"].ToString());
                cuerpo = cuerpo.Replace("@ENVOI_FACTURE@", json["ENVOI_FACTURE"].ToString());
                cuerpo = cuerpo.Replace("@COMM1@", json["COMM1"].ToString());
                cuerpo = cuerpo.Replace("@SUITECOMM1@", json["SUITECOMM1"].ToString());
                cuerpo = cuerpo.Replace("@COMMENTAIR1@", json["COMMENTAIR1"].ToString());

                SmtpClient client = new SmtpClient();
                client.Port = 587;
                client.Host = "smtp.gmail.com";
                client.EnableSsl = true;
                client.Timeout = 10000;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential("nobelbizreports@gmail.com", "vvQ43$Ma");
                
                var correos = to.Split(',');

                foreach (var item in correos)
                {
                    System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage("nobelbizreports@gmail.com", item, json["subject"].ToString(), cuerpo);
                    MailAddress from = new MailAddress("nobelbizreports@gmail.com", json["envia"].ToString());
                    mail.From = from;
                    mail.BodyEncoding = UTF8Encoding.UTF8;
                    mail.IsBodyHtml = true;
                    mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
                    //mail.Attachments.Add(data);
                    client.Send(mail);
                }



            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }
        }
        public static void MAIL_Modif_coordonnees_4(string myjson)
        {
            JObject json = JObject.Parse(myjson);
            var nombre = json["nombre"];
            var cuerpo = "cuerpo";
            try
            {
                var to = json["correos"].ToString().Replace("\r\n", ",").Replace("\n", ",").Replace("\r", ",");
                using (StreamReader reader = new StreamReader(HttpContext.Current.Server.MapPath("MAIL_Modif_coordonnees_4.html")))
                {
                    cuerpo = reader.ReadToEnd();
                }
                cuerpo = cuerpo.Replace("@CCIAL@", json["CCIAL"].ToString());
                cuerpo = cuerpo.Replace("@MODCIV@", json["MODCIV"].ToString());
                cuerpo = cuerpo.Replace("@MODNOM@", json["MODNOM"].ToString());
                cuerpo = cuerpo.Replace("@MODPRENOM@", json["MODPRENOM"].ToString());
                cuerpo = cuerpo.Replace("@DATERDV1@", json["DATERDV1"].ToString());
                cuerpo = cuerpo.Replace("@HEURERDV1@", json["HEURERDV1"].ToString());
                
                SmtpClient client = new SmtpClient();
                client.Port = 587;
                client.Host = "smtp.gmail.com";
                client.EnableSsl = true;
                client.Timeout = 10000;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential("nobelbizreports@gmail.com", "vvQ43$Ma");

                var correos = to.Split(',');

                foreach (var item in correos)
                {
                    System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage("nobelbizreports@gmail.com", item, json["subject"].ToString(), cuerpo);
                    MailAddress from = new MailAddress("nobelbizreports@gmail.com", json["envia"].ToString());
                    mail.From = from;
                    mail.BodyEncoding = UTF8Encoding.UTF8;
                    mail.IsBodyHtml = true;
                    mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
                    //mail.Attachments.Add(data);
                    client.Send(mail);
                }



            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }
        }
        public static void MAIL_RDV_A_REPORTER_ULTERIEUREMENT_3(string myjson)
        {
            JObject json = JObject.Parse(myjson);
            var nombre = json["nombre"];
            var cuerpo = "cuerpo";
            try
            {
                var to = json["correos"].ToString().Replace("\r\n", ",").Replace("\n", ",").Replace("\r", ",");
                using (StreamReader reader = new StreamReader(HttpContext.Current.Server.MapPath("MAIL_RDV_A_REPORTER_ULTERIEUREMENT_3.html")))
                    
                {
                    cuerpo = reader.ReadToEnd();
                }
                cuerpo = cuerpo.Replace("@DATERDV1@", json["DATERDV1"].ToString());
                cuerpo = cuerpo.Replace("@HEURERDV1@", json["HEURERDV1"].ToString());
                cuerpo = cuerpo.Replace("@MODCIV@", json["MODCIV"].ToString());
                cuerpo = cuerpo.Replace("@MODPRENOM@", json["MODPRENOM"].ToString());
                cuerpo = cuerpo.Replace("@MODNOM@", json["MODNOM"].ToString());
                cuerpo = cuerpo.Replace("@CCIAL@", json["CCIAL"].ToString());

                SmtpClient client = new SmtpClient();
                client.Port = 587;
                client.Host = "smtp.gmail.com";
                client.EnableSsl = true;
                client.Timeout = 10000;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential("nobelbizreports@gmail.com", "vvQ43$Ma");

                var correos = to.Split(',');

                foreach (var item in correos)
                {
                    System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage("nobelbizreports@gmail.com", item, json["subject"].ToString(), cuerpo);
                    MailAddress from = new MailAddress("nobelbizreports@gmail.com", json["envia"].ToString());
                    mail.From = from;
                    mail.BodyEncoding = UTF8Encoding.UTF8;
                    mail.IsBodyHtml = true;
                    mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
                    //mail.Attachments.Add(data);
                    client.Send(mail);
                }



            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }
        }
        public static void MAIL_RDV_A_REPORTER_ULTERIEUREMENT_RDV2(string myjson)
        {
            JObject json = JObject.Parse(myjson);
            var nombre = json["nombre"];
            var cuerpo = "cuerpo";
            try
            {
                var to = json["correos"].ToString().Replace("\r\n", ",").Replace("\n", ",").Replace("\r", ",");
                using (StreamReader reader = new StreamReader(HttpContext.Current.Server.MapPath("MAIL_RDV_A_REPORTER_ULTERIEUREMENT_RDV2.html")))
                {
                    cuerpo = reader.ReadToEnd();
                }
                cuerpo = cuerpo.Replace("@CCIAL@", json["CCIAL"].ToString());
                cuerpo = cuerpo.Replace("@DATERDV2@", json["DATERDV2"].ToString());
                cuerpo = cuerpo.Replace("@HEURERDV2@", json["HEURERDV2"].ToString());
                cuerpo = cuerpo.Replace("@MODCIV@", json["MODCIV"].ToString());
                cuerpo = cuerpo.Replace("@MODPRENOM@", json["MODPRENOM"].ToString());
                cuerpo = cuerpo.Replace("@MODNOM@", json["MODNOM"].ToString());
                
                SmtpClient client = new SmtpClient();
                client.Port = 587;
                client.Host = "smtp.gmail.com";
                client.EnableSsl = true;
                client.Timeout = 10000;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential("nobelbizreports@gmail.com", "vvQ43$Ma");

                var correos = to.Split(',');

                foreach (var item in correos)
                {
                    System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage("nobelbizreports@gmail.com", item, json["subject"].ToString(), cuerpo);
                    MailAddress from = new MailAddress("nobelbizreports@gmail.com", json["envia"].ToString());
                    mail.From = from;
                    mail.BodyEncoding = UTF8Encoding.UTF8;
                    mail.IsBodyHtml = true;
                    mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
                    //mail.Attachments.Add(data);
                    client.Send(mail);
                }



            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }
        }
        public static void MAIL_RDV_ANNULE_5(string myjson)
        {
            JObject json = JObject.Parse(myjson);
            var nombre = json["nombre"];
            var cuerpo = "cuerpo";
            try
            {
                var to = json["correos"].ToString().Replace("\r\n", ",").Replace("\n", ",").Replace("\r", ",");
                using (StreamReader reader = new StreamReader(HttpContext.Current.Server.MapPath("MAIL_RDV_ANNULE_5.html")))
                {
                    cuerpo = reader.ReadToEnd();
                }
                cuerpo = cuerpo.Replace("@CCIAL@", json["CCIAL"].ToString());
                cuerpo = cuerpo.Replace("@MODCIV@", json["MODCIV"].ToString());
                cuerpo = cuerpo.Replace("@MODNOM@", json["MODNOM"].ToString());
                cuerpo = cuerpo.Replace("@MODPRENOM@", json["MODPRENOM"].ToString());
                cuerpo = cuerpo.Replace("@DATERDV1@", json["DATERDV1"].ToString());
                cuerpo = cuerpo.Replace("@HEURERDV1@", json["HEURERDV1"].ToString());
                
                SmtpClient client = new SmtpClient();
                client.Port = 587;
                client.Host = "smtp.gmail.com";
                client.EnableSsl = true;
                client.Timeout = 10000;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential("nobelbizreports@gmail.com", "vvQ43$Ma");

                var correos = to.Split(',');

                foreach (var item in correos)
                {
                    System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage("nobelbizreports@gmail.com", item, json["subject"].ToString(), cuerpo);
                    MailAddress from = new MailAddress("nobelbizreports@gmail.com", json["envia"].ToString());
                    mail.From = from;
                    mail.BodyEncoding = UTF8Encoding.UTF8;
                    mail.IsBodyHtml = true;
                    mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
                    //mail.Attachments.Add(data);
                    client.Send(mail);
                }



            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }
        }
        public static void Mail_Rdv_Non_confirme_TEG_1(string myjson)
        {
            JObject json = JObject.Parse(myjson);
            var nombre = json["nombre"];
            var cuerpo = "cuerpo";
            try
            {
                var to = json["correos"].ToString().Replace("\r\n", ",").Replace("\n", ",").Replace("\r", ",");
                using (StreamReader reader = new StreamReader(HttpContext.Current.Server.MapPath("Mail_Rdv_Non_confirme_TEG_1.html")))
                {
                    cuerpo = reader.ReadToEnd();
                }
                cuerpo = cuerpo.Replace("@DATERDV1@", json["DATERDV1"].ToString());
                cuerpo = cuerpo.Replace("@HEURERDV1@", json["HEURERDV1"].ToString());
                cuerpo = cuerpo.Replace("@CCIAL@", json["CCIAL"].ToString());
                cuerpo = cuerpo.Replace("@CCIAL@", json["CCIAL"].ToString());
                cuerpo = cuerpo.Replace("@PORTCCIAL@", json["PORTCCIAL"].ToString());
                cuerpo = cuerpo.Replace("@MAILCIAL@", json["MAILCIAL"].ToString());
                
                SmtpClient client = new SmtpClient();
                client.Port = 587;
                client.Host = "smtp.gmail.com";
                client.EnableSsl = true;
                client.Timeout = 10000;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential("nobelbizreports@gmail.com", "vvQ43$Ma");

                var correos = to.Split(',');

                foreach (var item in correos)
                {
                    System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage("nobelbizreports@gmail.com", item, json["subject"].ToString(), cuerpo);
                    MailAddress from = new MailAddress("nobelbizreports@gmail.com", json["envia"].ToString());
                    mail.From = from;
                    mail.BodyEncoding = UTF8Encoding.UTF8;
                    mail.IsBodyHtml = true;
                    mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
                    //mail.Attachments.Add(data);
                    client.Send(mail);
                }



            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }
        }
        public static void MAIL_RDV_REPORTE_2(string myjson)
        {
            JObject json = JObject.Parse(myjson);
            var nombre = json["nombre"];
            var cuerpo = "cuerpo";
            try
            {
                var to = json["correos"].ToString().Replace("\r\n", ",").Replace("\n", ",").Replace("\r", ",");
                using (StreamReader reader = new StreamReader(HttpContext.Current.Server.MapPath("MAIL_RDV_REPORTE_2.html")))
                {
                    cuerpo = reader.ReadToEnd();
                }
                cuerpo = cuerpo.Replace("{CCIAL}", json["CCIAL"].ToString());
                cuerpo = cuerpo.Replace("{MODCIV}", json["MODCIV"].ToString());
                cuerpo = cuerpo.Replace("{MODNOM}", json["MODNOM"].ToString());
                cuerpo = cuerpo.Replace("{MODPRENOM}", json["MODPRENOM"].ToString());
                cuerpo = cuerpo.Replace("{DATERDV1}", json["DATERDV1"].ToString());
                cuerpo = cuerpo.Replace("{HEURERDV1}", json["HEURERDV1"].ToString());
                
                SmtpClient client = new SmtpClient();
                client.Port = 587;
                client.Host = "smtp.gmail.com";
                client.EnableSsl = true;
                client.Timeout = 10000;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential("nobelbizreports@gmail.com", "vvQ43$Ma");

                var correos = to.Split(',');

                foreach (var item in correos)
                {
                    System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage("nobelbizreports@gmail.com", item, json["subject"].ToString(), cuerpo);
                    MailAddress from = new MailAddress("nobelbizreports@gmail.com", json["envia"].ToString());
                    mail.From = from;
                    mail.BodyEncoding = UTF8Encoding.UTF8;
                    mail.IsBodyHtml = true;
                    mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
                    //mail.Attachments.Add(data);
                    client.Send(mail);
                }



            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }
        }
    }
}