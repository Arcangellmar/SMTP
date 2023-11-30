using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SMTP
{
    public class SMTP
    {

        static String correoQueEnvia = "rolando20022016@gmail.com";
        static String nombreQueEnvia = "SKF Portal";
        static String contraQueEnvia = ""; // LA CONTRA DEBE SER GENERADA SECRETA

        /// <summary>
        /// Envia a un destinatario
        /// </summary>
        /// <param name="destinatario"></param>
        /// <param name="asunto"></param>
        /// <param name="body"></param>
        /// <param name="file"></param>
        static public void SendEmail(String destinatario, String asunto, String body)
        {
            try
            {
                //QUIEN ESTA ENVIANDO
                MailMessage correo = new MailMessage();
                correo.From = new MailAddress(correoQueEnvia, nombreQueEnvia, System.Text.Encoding.UTF8);//Correo de salida

                correo.To.Add(destinatario); //Correo destino?
                correo.Subject = asunto; //Asunto
                correo.Body = body; //Mensaje del correo
                correo.IsBodyHtml = true;
                correo.Priority = MailPriority.Normal;

                SmtpClient smtp = new SmtpClient();
                smtp.UseDefaultCredentials = false;
                smtp.Host = "smtp.gmail.com"; //Host del servidor de correo
                smtp.Port = 25; //Puerto de salida
                smtp.Credentials = new System.Net.NetworkCredential(correoQueEnvia, contraQueEnvia);//Cuenta de correo

                //SI DA ERROR DESACTIVA LAS LINEAS DE ABAJO
                ServicePointManager.ServerCertificateValidationCallback = delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) { return true; };
                smtp.EnableSsl = true;//True si el servidor de correo permite ssl
                smtp.Send(correo);
            }
            catch (Exception ex)
            {
                //MANEJA EL ERROR EN SMTP
                throw;
            }
        }
        /// <summary>
        /// Envia a un destinatario con un archivo
        /// </summary>
        /// <param name="destinatario"></param>
        /// <param name="asunto"></param>
        /// <param name="body"></param>
        /// <param name="file"></param>
        static public void SendEmail(String destinatario, String asunto, String body, String file)
        {
            try
            {
                //QUIEN ESTA ENVIANDO
                MailMessage correo = new MailMessage();
                correo.From = new MailAddress(correoQueEnvia, nombreQueEnvia, System.Text.Encoding.UTF8);//Correo de salida

                correo.To.Add(destinatario); //Correo destino?
                correo.Subject = asunto; //Asunto
                correo.Body = body; //Mensaje del correo
                correo.IsBodyHtml = true;
                correo.Priority = MailPriority.Normal;
                Attachment attachment = new Attachment(file);
                correo.Attachments.Add(attachment);

                SmtpClient smtp = new SmtpClient();
                smtp.UseDefaultCredentials = false;
                smtp.Host = "smtp.gmail.com"; //Host del servidor de correo
                smtp.Port = 25; //Puerto de salida
                smtp.Credentials = new System.Net.NetworkCredential(correoQueEnvia, contraQueEnvia);//Cuenta de correo

                //SI DA ERROR DESACTIVA LAS LINEAS DE ABAJO
                ServicePointManager.ServerCertificateValidationCallback = delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) { return true; };
                smtp.EnableSsl = true;//True si el servidor de correo permite ssl
                smtp.Send(correo);
            }
            catch (Exception ex)
            {
                //MANEJA EL ERROR EN SMTP
                throw;
            }
        }
        /// <summary>
        /// Envia a un destinatario con una lista de archivos
        /// </summary>
        /// <param name="destinatario"></param>
        /// <param name="asunto"></param>
        /// <param name="body"></param>
        /// <param name="files"></param>
        static public void SendEmail(String destinatario, String asunto, String body, List<String> files)
        {
            try
            {
                //QUIEN ESTA ENVIANDO
                MailMessage correo = new MailMessage();
                correo.From = new MailAddress(correoQueEnvia, nombreQueEnvia, System.Text.Encoding.UTF8);//Correo de salida

                correo.To.Add(destinatario); //Correo destino?
                correo.Subject = asunto; //Asunto
                correo.Body = body; //Mensaje del correo
                correo.IsBodyHtml = true;
                correo.Priority = MailPriority.Normal;
                foreach (String file in files)
                {
                    try
                    {
                        Attachment attachment = new Attachment(file);
                        correo.Attachments.Add(attachment);
                    }
                    catch (Exception)
                    {
                        continue;
                    }
                }

                SmtpClient smtp = new SmtpClient();
                smtp.UseDefaultCredentials = false;
                smtp.Host = "smtp.gmail.com"; //Host del servidor de correo
                smtp.Port = 25; //Puerto de salida
                smtp.Credentials = new System.Net.NetworkCredential(correoQueEnvia, contraQueEnvia);//Cuenta de correo

                //SI DA ERROR DESACTIVA LAS LINEAS DE ABAJO
                ServicePointManager.ServerCertificateValidationCallback = delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) { return true; };
                smtp.EnableSsl = true;//True si el servidor de correo permite ssl
                smtp.Send(correo);
            }
            catch (Exception ex)
            {
                //MANEJA EL ERROR EN SMTP
                throw;
            }

        }
        /// <summary>
        /// Envia ana lista de destinatarios con una lista de archivos
        /// </summary>
        /// <param name="destinatario"></param>
        /// <param name="asunto"></param>
        /// <param name="body"></param>
        /// <param name="files"></param>
        static public void SendEmail(List<String> destinatarios, String asunto, String body, List<String> files)
        {
            try
            {
                foreach (String destinatario in destinatarios)
                {
                    //QUIEN ESTA ENVIANDO
                    MailMessage correo = new MailMessage();
                    correo.From = new MailAddress(correoQueEnvia, nombreQueEnvia, System.Text.Encoding.UTF8);//Correo de salida

                    correo.To.Add(destinatario); //Correo destino?

                    correo.Subject = asunto; //Asunto
                    correo.Body = body; //Mensaje del correo
                    correo.IsBodyHtml = true;
                    correo.Priority = MailPriority.Normal;
                    foreach (String file in files)
                    {
                        try
                        {
                            Attachment attachment = new Attachment(file);
                            correo.Attachments.Add(attachment);
                        }
                        catch (Exception)
                        {
                            continue;
                        }
                    }

                    SmtpClient smtp = new SmtpClient();
                    smtp.UseDefaultCredentials = false;
                    smtp.Host = "smtp.gmail.com"; //Host del servidor de correo
                    smtp.Port = 25; //Puerto de salida
                    smtp.Credentials = new System.Net.NetworkCredential(correoQueEnvia, contraQueEnvia);//Cuenta de correo

                    //SI DA ERROR DESACTIVA LAS LINEAS DE ABAJO
                    ServicePointManager.ServerCertificateValidationCallback = delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) { return true; };
                    smtp.EnableSsl = true;//True si el servidor de correo permite ssl
                    smtp.Send(correo);
                }
            }
            catch (Exception ex)
            {
                //MANEJA EL ERROR EN SMTP
                throw;
            }

        }
        /// <summary>
        /// Envia ana lista de destinatarios con una lista de archivos
        /// </summary>
        /// <param name="destinatario"></param>
        /// <param name="asunto"></param>
        /// <param name="body"></param>
        /// <param name="files"></param>
        static public void SendEmail(List<String> destinatarios, String asunto, String body, String file)
        {
            try
            {
                foreach (String destinatario in destinatarios)
                {
                    //QUIEN ESTA ENVIANDO
                    MailMessage correo = new MailMessage();
                    correo.From = new MailAddress(correoQueEnvia, nombreQueEnvia, System.Text.Encoding.UTF8);//Correo de salida

                    correo.To.Add(destinatario); //Correo destino?

                    correo.Subject = asunto; //Asunto
                    correo.Body = body; //Mensaje del correo
                    correo.IsBodyHtml = true;
                    correo.Priority = MailPriority.Normal;
                    Attachment attachment = new Attachment(file);
                    correo.Attachments.Add(attachment);

                    SmtpClient smtp = new SmtpClient();
                    smtp.UseDefaultCredentials = false;
                    smtp.Host = "smtp.gmail.com"; //Host del servidor de correo
                    smtp.Port = 25; //Puerto de salida
                    smtp.Credentials = new System.Net.NetworkCredential(correoQueEnvia, contraQueEnvia);//Cuenta de correo

                    //SI DA ERROR DESACTIVA LAS LINEAS DE ABAJO
                    ServicePointManager.ServerCertificateValidationCallback = delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) { return true; };
                    smtp.EnableSsl = true;//True si el servidor de correo permite ssl
                    smtp.Send(correo);
                }
            }
            catch (Exception ex)
            {
                //MANEJA EL ERROR EN SMTP
                throw;
            }

        }
    }
}