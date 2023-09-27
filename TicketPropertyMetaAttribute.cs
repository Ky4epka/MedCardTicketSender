using System;
using System.Reflection;
using System.Collections.Generic;

namespace TicketSender
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class TicketPropertyMetaAttribute : Attribute
    {
        public string Title { get; private set; } = "";
        public int DefaultWidth { get; private set; } = 50;
        public bool IsHidden { get; private set; } = false;

        public TicketPropertyMetaAttribute(string title)
        {
            Title = title;
        }

        public TicketPropertyMetaAttribute(string title, int defaultWidth)
        {
            Title = title;
            DefaultWidth = defaultWidth;
        }

        public TicketPropertyMetaAttribute(string title, int defaultWidth, bool isHidden)
        {
            Title = title;
            DefaultWidth = defaultWidth;
            IsHidden = isHidden;
        }

        public static PropertyInfo[] TypePropertiesByThis(Predicate<PropertyInfo> filter)
        {
            List<PropertyInfo> result = new List<PropertyInfo>();
            Type t = typeof(TicketClass);

            foreach (var prop in t.GetProperties(BindingFlags.Public | BindingFlags.Instance))
            {
                if ((prop.GetCustomAttribute<TicketPropertyMetaAttribute>(true) != null) && ((filter == null) || filter(prop)))
                    result.Add(prop);
            }

            return result.ToArray();
        }
    }
}
