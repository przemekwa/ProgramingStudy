using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IBM.WMQ;

namespace ProgramingStudy.Study
{
    class MqStudy : IStudyTest
    {
        public MQQueueManager queueManager { get; set; }
        public MQQueue queue { get; set; }
        public MQMessage queueMessage { get; set; }
        public MQPutMessageOptions queuePutMessageOptions { get; set; }
        public MQGetMessageOptions queueGetMessageOptions { get; set; }

        public string QueueName { get; set; }
        public string QueueManagerName { get; set; }

        private const int NUMBEROFSTEP = 3;
        private Hashtable conectionProperties;


        public void Study()
        {
            this.conectionProperties = new Hashtable();

            conectionProperties.Add(MQC.HOST_NAME_PROPERTY, "10.151.67.113");

            conectionProperties.Add(MQC.CHANNEL_PROPERTY, "GBO.TO.QMSLINK");

            conectionProperties.Add(MQC.PORT_PROPERTY, 1414);

            //conectionProperties.Add(MQC.USER_ID_PROPERTY, "mqmTEST");

            //conectionProperties.Add(MQC.PASSWORD_PROPERTY, "");

            conectionProperties.Add(MQC.TRANSPORT_PROPERTY, MQC.TRANSPORT_MQSERIES_MANAGED);

            this.QueueName = "TESTS.FROM.PRZEMO.TO.SLINK";

            this.QueueManagerName = "QMSLINK";

            this.ConnectMQ();


            var q = queueManager.AccessQueue(QueueName, MQC.MQOO_OUTPUT + MQC.MQOO_FAIL_IF_QUIESCING);

            queueMessage = new MQMessage();
            queueMessage.Format = MQC.MQFMT_STRING;

            var st = new Stopwatch();
            st.Start();

            foreach (var item in Enumerable.Range(0, NUMBEROFSTEP))
            {
                var msg = $"Wiadomość numer {item} ";

                queueMessage.ClearMessage();

                queueMessage.WriteString(msg);

                Console.WriteLine($"Wysłanie wiadomości {msg}");

                this.WriteMsg(msg, q, queueMessage);
            }


            st.Stop();

            Console.WriteLine($"Czas wysłania {NUMBEROFSTEP} wiadomości: { new DateTime(st.ElapsedTicks).ToLongTimeString()}");
            GetMsqFromMq();
            Console.WriteLine();
            Console.WriteLine();

        }

        public void GetMsqFromMq()
        {
            foreach (var item in Enumerable.Range(0, NUMBEROFSTEP))
            {
                var test = this.ReadMsg();

                Console.WriteLine($"Odebranie wiadomości: {test}");
            }
        }

        public void ConnectMQ()
        {
            this.queueManager = new MQQueueManager(this.QueueManagerName, conectionProperties);
        }

        public string WriteMsg(string strInputMsg, MQQueue mqque, MQMessage mqm)
        {
            string strReturn = "";

            try
            {
                mqque.Put(mqm, new MQPutMessageOptions());

                strReturn = "Message sent to the queue successfully";
            }
            catch (MQException MQexp)
            {
                strReturn = "Exception: " + MQexp.Message;
            }
            catch (Exception exp)
            {
                strReturn = "Exception: " + exp.Message;
            }
            return strReturn;
        }

        public string ReadMsg()
        {
            String strReturn = "";
            try
            {
                queue = queueManager.AccessQueue(QueueName,
                MQC.MQOO_INPUT_AS_Q_DEF + MQC.MQOO_FAIL_IF_QUIESCING);
                queueMessage = new MQMessage();

                queueMessage.Format = MQC.MQFMT_STRING;

                queueGetMessageOptions = new MQGetMessageOptions();

                queue.Get(queueMessage, queueGetMessageOptions);


                strReturn = queueMessage.ReadString(queueMessage.MessageLength);
            }
            catch (MQException MQexp)
            {
                strReturn = "Exception : " + MQexp.Message;
            }
            catch (Exception exp)
            {
                strReturn = "Exception: " + exp.Message;
            }
            return strReturn;
        }
    }
}
