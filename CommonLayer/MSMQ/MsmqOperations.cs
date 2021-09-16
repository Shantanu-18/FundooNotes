using System;
using System.Collections.Generic;
using System.Text;
using Experimental.System.Messaging;

namespace CommonLayer.MSMQ
{
    public class MsmqOperations
    {
        MessageQueue msmq = new MessageQueue();
        public void SendingData(string token)
        {
            msmq.Path = @".\private$\tohenQueue";

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
            throw new NotImplementedException();
        }
    }
}
