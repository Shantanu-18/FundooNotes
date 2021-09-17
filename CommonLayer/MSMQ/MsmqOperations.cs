﻿using System;
using System.Collections.Generic;
using System.Text;
using Experimental.System.Messaging;
using System.Net.Mail;
using Microsoft.Extensions.Configuration;
using System.Net;
using Microsoft.Extensions.Options;

namespace CommonLayer.MSMQ
{
    public class MsmqOperations
    {
        MessageQueue msmq = new MessageQueue();
        private readonly Smtp _smtp;
        public MsmqOperations(IOptions<Smtp> options)
        {
            _smtp = options.Value;
        }

        public MsmqOperations()
        {
        }

        public void SendingData(string token)
        {
            msmq.Path = @".\private$\tokenQueue";

            if (!MessageQueue.Exists(msmq.Path))
            {
                //if not exixts
                MessageQueue.Create(msmq.Path);
            }
            SendingToken(token);
        }

        public void SendingToken(string token)
        {
            //For adding Xml formatter to the message
            msmq.Formatter = new XmlMessageFormatter(new Type[] { typeof(string) });

            msmq.ReceiveCompleted += Msmq_ReceiveCompleted;

            //for sending token to the queue
            msmq.Send(token);
            msmq.BeginReceive();
            msmq.Close();
        }

        private void Msmq_ReceiveCompleted(object sender, ReceiveCompletedEventArgs e)
        {
            try
            {
                //getting  token from receiver
                var msg = msmq.EndReceive(e.AsyncResult);

                string token = msg.Body.ToString();
                //sending a mail via SMTP

                mailSending(token);
                msmq.BeginReceive();
            }
            catch (MessageQueueException ex)
            {
                throw ex;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void mailSending(string token)
        {
            MailMessage mailMessage = new MailMessage("sendertohost@gmail.com", "sendertohost@gmail.com");
            mailMessage.Subject = "Reset password link.";

            var body = new StringBuilder();
            
            body.AppendLine("Hello, To Reset your Account Password click the link below.");
            body.AppendLine("<a href=\"https://localhost:5001/User/ResetPassword/"+token+"\">Click Here</a>");
            mailMessage.Body = body.ToString();
            mailMessage.IsBodyHtml = true;

            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);

            smtpClient.Credentials = new NetworkCredential()
            {
                UserName = "sendertohost@gmail.com",
                Password = "Test@123"
            };

            //var smtpClient = new SmtpClient(_smtp.Host)
            //{
            //    Port = _smtp.Port,
            //    Credentials = new NetworkCredential(_smtp.UserName, _smtp.Password),
            //    EnableSsl = true,
            //};
            smtpClient.EnableSsl = true;
            smtpClient.Send(mailMessage);
        }
    }
}
