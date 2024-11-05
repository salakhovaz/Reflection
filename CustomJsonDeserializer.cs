using System.Reflection;

namespace Reflection
{
    public static class CustomJsonDeserializer
    {
        public static T Deserialize<T>(string json) where T : new()
        {
            json = json.Trim().TrimStart('{').TrimEnd('}');
            string[] pairs = json.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

            T obj = new T();
            Type type = typeof(T);

            foreach (string pair in pairs)
            {
                string[] keyValue = pair.Split(new[] { ':' }, 2);
                if (keyValue.Length != 2) continue;

                string key = keyValue[0].Trim().Trim('"');
                string valueStr = keyValue[1].Trim().Trim('"');

                PropertyInfo prop = type.GetProperty(key);
                if (prop != null && prop.CanWrite)
                {
                    object? value = ParseValue(valueStr, prop.PropertyType);

                    if (value != null)
                    {
                        prop.SetValue(obj, value);
                    }
                }
            }

            return obj;
        }

        private static object? ParseValue(string valueStr, Type propertyType)
        {
            if (propertyType == typeof(int))
            {
                if (int.TryParse(valueStr, out int intValue))
                    return intValue;
            }
            else if (propertyType == typeof(string))
            {
                return valueStr;
            }
            else if (propertyType == typeof(bool))
            {
                if (bool.TryParse(valueStr, out bool boolValue))
                    return boolValue;
            }
            //тут по идее надо и другие типы парсить
            return null;
        }
    }
}
