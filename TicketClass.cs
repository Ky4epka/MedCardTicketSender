using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Reflection;

namespace TicketSender
{

    [Serializable]
    public class TicketClass
    {
        [JsonIgnore]
        public Guid Id { get; } = new Guid();

        [JsonProperty("fullname")]
        [TicketPropertyMeta("ФИО", 150)]
        public string FullName { get; set; }
        [JsonProperty("address")]
        [TicketPropertyMeta("Адрес", 150)]
        public string Address { get; set; }
        [JsonProperty("birthyear")]
        [TicketPropertyMeta("Год рождения", 60)]
        public string BirthYear { get; set; }
        [JsonProperty("targetcabinet")]
        [TicketPropertyMeta("Целевой кабинет", 60)]
        public string TargetCabinet { get; set; }
        [JsonProperty("sendtime")]
        [TicketPropertyMeta("Время отправки", 120)]
        public DateTime SendTime { get; set; }
        [JsonProperty("HANDLER_NAME")]
        [TicketPropertyMeta("Подразделение", 100, true)]
        public string Departament { get; set; }

        protected static List<FieldData> iTableSchema = null;

        public static List<FieldData> TableSchema
        {
            get
            {
                if (iTableSchema == null)
                {
                    iTableSchema = new List<FieldData>();
                    UpdateSchema(iTableSchema);
                }

                return iTableSchema;
            }
        }

        public class FieldData
        {
            public string FieldName { get; set; }
            public string Title { get; set; }
            public PropertyInfo Property { get; set; }
            public TicketPropertyMetaAttribute Attribute { get; set; }

            public FieldData(string fieldName, string title, PropertyInfo property, TicketPropertyMetaAttribute attribute)
            {
                FieldName = fieldName;
                Title = title;
                Property = property;
                Attribute = attribute;
            }
        }

        public Dictionary<string, string> ToFormData()
        {
            Dictionary<string, string> result = new Dictionary<string, string>();

            foreach (var field in iTableSchema)
            {
                object value = field.Property.GetValue(this);
                string svalue = "";

                if (value == null) ;
                else if (value is string)
                    svalue = (string)value;
                else
                    svalue = value.ToString();

                result[field.FieldName] = svalue;
            }

            return result;
        }

        public override int GetHashCode()
        {
            int a =
                FullName?.GetHashCode() ?? 1;
            int b =
                Address?.GetHashCode() ?? 1;
            int c =
                BirthYear?.GetHashCode() ?? 1;
            int d =
                TargetCabinet?.GetHashCode() ?? 1;
            int f =
                Departament?.GetHashCode() ?? 1;

            return a + b + c + d + f;
        }

        protected static void UpdateSchema(List<FieldData> schema)
        {
            schema.Clear();
            PropertyInfo[] schemaProps = TicketPropertyMetaAttribute.TypePropertiesByThis(null);

            foreach (var prop in schemaProps)
            {
                string fieldName = prop.Name;
                JsonPropertyAttribute jsonProp = prop.GetCustomAttribute<JsonPropertyAttribute>(true);
                TicketPropertyMetaAttribute metaProp = prop.GetCustomAttribute<TicketPropertyMetaAttribute>(true);

                if (jsonProp != null)
                    fieldName = jsonProp.PropertyName;

                schema.Add(new FieldData(fieldName, metaProp.Title, prop, metaProp));
            }
        }
    }
}
