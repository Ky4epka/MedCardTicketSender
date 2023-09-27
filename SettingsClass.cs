using System;
using System.Drawing;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;
using System.Security.Cryptography;
using System.Data;

namespace TicketSender
{

    public struct KeyValuePair<T, T2>
    {
        public T Key { get; set; }
        public T Value { get; set; }
    }

    [Serializable]
    [XmlType()]
    public class SettingsClass
    {
        [XmlElement]
        public string ServerUrl
        {
            get => TicketManager.Instance.ServerURL;
            set => TicketManager.Instance.ServerURL = value;
        }

        [XmlElement]
        public string AccessPhrase
        {
            get
            {
                return TicketManager.Instance.AccessPhrase;
            }

            set
            {
                string phrase = "";

                if (value?.Length > 0)
                    phrase = BitConverter.ToString(SHA256.Create().ComputeHash(System.Text.Encoding.UTF8.GetBytes(value))).Replace("-", "");

                TicketManager.Instance.AccessPhrase = phrase;
            }
        }

        [XmlElement]
        public TicketManager TicketManager 
        { 
            get => TicketManager.Instance;
            set => TicketManager.Instance.Assign(value);
        }

        [XmlElement]
        public DataSet DepartamentData 
        {
            get => (iDepartamentData == null) ? iDepartamentData = new DataSet() : iDepartamentData;
            set
            {
                iDepartamentData = value?.Copy() ?? null;
            }
        }


        [XmlArray("FormData")]
        [XmlArrayItem("KeyValue")]
        public KeyValuePair<string, string>[] formData 
        {
            get
            {
                KeyValuePair<string, string>[] result = new KeyValuePair<string, string>[iformData.Keys.Count];
                int count = 0;

                foreach (var keyvalue in iformData)
                {
                    KeyValuePair<string, string> reskv = new KeyValuePair<string, string>();
                    reskv.Key = keyvalue.Key;
                    reskv.Value = keyvalue.Value;

                    result[count++] = reskv;
                }

                return result;
            }
            set
            {
                foreach (var keyvalue in value)
                {
                    iformData.Add(keyvalue.Key, keyvalue.Value);
                }
            } 
        }

        [XmlIgnore]
        public Dictionary<string, string> formDataAsDict
        {
            get => iformData;
            set
            {
                foreach (var keyvalue in value)
                {
                    iformData[keyvalue.Key] = keyvalue.Value;
                } 
            }
        }

        [XmlElement]
        public Rectangle WindowPosition { get; set; } = new Rectangle();
        [XmlElement]
        public bool TopmostForm { get; set; } = false;
        [XmlElement]
        public bool IsClipboardMonitorActive { get; set; } = false;

        [XmlArray]
        [XmlArrayItem("parseElement")]
        public string[] ClipboardParseTemplate { get; set; }

        [XmlIgnore]
        protected Dictionary<string, string> iformData = new Dictionary<string, string>();

        protected DataSet iDepartamentData = null;
        
        public static void SaveToFile(string fileName, SettingsClass settings)
        {
            using (FileStream fs = new FileStream(fileName, FileMode.Create))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(SettingsClass));
                serializer.Serialize(fs, settings);
            }
        }

        public static SettingsClass LoadFromFile(string fileName)
        {
            if (!File.Exists(fileName))
                return new SettingsClass();

            FileStream fs = new FileStream(fileName, FileMode.Open);
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(SettingsClass));
                return serializer.Deserialize(fs) as SettingsClass;
            }
            catch (InvalidOperationException)
            {
                fs.Close();
                File.Delete(fileName);

                return new SettingsClass();
            }
            finally
            {
                fs.Dispose();
            }
        }
    }
}
