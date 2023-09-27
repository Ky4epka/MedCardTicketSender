using System;
using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;
using System.Xml.Serialization;
using System.Threading.Tasks;

namespace TicketSender
{
    [Serializable]
    public class TicketManager
    {
        [Serializable]
        public class ResponseContentBody
        {
            [JsonProperty("RESULT_CONTENT_OK")]
            public string IsOK { get; set; } = "";
            [JsonProperty("RESULT_CONTENT_MESSAGE")]
            public string Message { get; set; } = "";
        }

        public event Action<string, LogType> LogEvent = null;
        public event Action<object> OnQueueChange = null;
        public event Action<object> OnSendingStart = null;
        public event Action<object, string> OnSendingError = null;
        public event Action<object> OnSendingSuccess = null;
        public event Action<object> OnSendingEnd = null;

        [JsonProperty("serverurl")]
        [XmlElement]
        public string ServerURL { get; set; }
        [JsonProperty("accessphrase")]
        [XmlElement]
        public string AccessPhrase { get; set; }
        [JsonProperty("tickets")]
        [XmlArrayItem("Ticket")]
        public TicketClass[] Tickets
        {
            get => iTickets.ToArray();
            set
            {
                iTickets.Clear();

                if (value == null)
                    return;

                foreach (var ticket in value)
                    AddTicketToQueue(ticket);
            }
        }

        [JsonIgnore]
        [XmlIgnore]
        protected List<TicketClass> iTickets = new List<TicketClass>();

        protected bool iIsSending = false;

        [XmlIgnore]
        protected static TicketManager iInstance = null;

        [XmlIgnore]
        public static TicketManager Instance => (iInstance == null) ? iInstance = new TicketManager() : iInstance;


        public void Assign(TicketManager instance)
        {
            if (instance == null)
                return;

            ServerURL = instance.ServerURL;
            AccessPhrase = instance.AccessPhrase;
            Tickets = instance.Tickets;
        }

        public bool AddTicketToQueue(TicketClass ticket)
        {
            int ticketHash = ticket.GetHashCode();

            foreach (var t in iTickets)
                if (t.GetHashCode() == ticketHash)
                    return false;
                        
            iTickets.Add(ticket);

            if (OnQueueChange != null)
                OnQueueChange(this);

            return true;
        }

        public bool DeleteTicketFromQueue(int index)
        {
            if ((index < 0) || (index >= iTickets.Count))
                return false;

            iTickets.RemoveAt(index);

            if (OnQueueChange != null)
                OnQueueChange(this);

            return true;
        }

        public void ClearQueue()
        {
            bool change = iTickets.Count > 0;
            iTickets.Clear();

            if (change && (OnQueueChange != null))
                OnQueueChange(this);
        }

        public void ProcessQueue()
        {
            if ((iTickets.Count > 0) && !iIsSending)
            {
                Task q = SendData();
            }
        }

        public async Task SendData()
        {
            HttpClient client = new HttpClient();

            _Log("Отправка данных...", LogType.Notify);
            try
            {
                iIsSending = true;

                if (OnSendingStart != null)
                    OnSendingStart(this); 


                string content = ToJSON();
                List<TicketClass> sendingTickets = new List<TicketClass>(iTickets);
                HttpResponseMessage response = await client.PostAsync(ServerURL, new StringContent(content, System.Text.Encoding.UTF8));

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    string responseContent = await response.Content.ReadAsStringAsync();
                    ResponseContentBody responseContentBody = JsonConvert.DeserializeObject<ResponseContentBody>(responseContent);

                    if (responseContentBody == null)
                    {
                        string error = $"Неизвестный ответ от сервера '{responseContent}'";

                        _Log(error, LogType.Error);

                        if (OnSendingError != null)
                            OnSendingError(this, error);
                    }
                    if (responseContentBody.IsOK == "1")
                    {
                        foreach (var ticket in sendingTickets)
                            iTickets.Remove(ticket);

                        if (OnQueueChange != null)
                            OnQueueChange(this);

                        _Log($"Успешно! {await response.Content.ReadAsStringAsync()}", LogType.Notify);

                        if (OnSendingSuccess != null)
                            OnSendingSuccess(this);
                    }
                    else
                    {
                        string error = $"Ошибка отправки '{responseContentBody.Message}";

                        _Log(error, LogType.Error);

                        if (OnSendingError != null)
                            OnSendingError(this, error);
                    }
                }
                else
                {
                    string error = $"Ошибка отправки '{response.StatusCode}': {await response.Content.ReadAsStringAsync()}";

                    _Log(error, LogType.Error);

                    if (OnSendingError != null)
                        OnSendingError(this, error);
                }
            }
            catch (Exception E)
            {
                string error = $"Ошибка на уровне протокола: {E.Message}";
                _Log(error, LogType.Exception);

                if (OnSendingError != null)
                    OnSendingError(this, error);
            }
            finally
            {
                iIsSending = false;

                if (OnSendingEnd != null)
                    OnSendingEnd(this);
            }
        }

        protected string ToJSON()
        {
            return JsonConvert.SerializeObject(this);
        }

        protected void _Log(string message, LogType logType)
        {
            if (LogEvent != null)
                LogEvent(message, logType);
        }
    }
}
