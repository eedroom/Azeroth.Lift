using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace System
{
    public static class GutopExtension
    {
        public static object GetValue(this HttpSessionStateBase session,Gutop.Model.SessionIndex index)
        {
            return session[index.ToString()];
        }

        public static object GetValue<T>(this HttpSessionStateBase session)
        {
            return session[typeof(T).FullName];
        }

        public static void SetValue(this HttpSessionStateBase session, Gutop.Model.SessionIndex index,object value)
        {
            session[index.ToString()]=value;
        }

        public static void SetValue<T>(this HttpSessionStateBase session, object value)
        {
            session[typeof(T).FullName] = value;
        }

        public static void ForEach<K,V>(this IDictionary<K,V> dict,Action<KeyValuePair<K, V>> handler)
        {
            foreach (var kv in dict)
            {
                handler(kv);
            }
        }
    }
}