using System.Reflection;
using System.Text;

namespace Reflection
{
    public static class CustomJsonSerializer
    {
        public static string Serialize<T>(T obj)
        {
            Type type = typeof(T);
            PropertyInfo[] properties = type.GetProperties();

            StringBuilder sb = new StringBuilder();
            sb.Append("{");

            for (int i = 0; i < properties.Length; i++)
            {
                PropertyInfo prop = properties[i];
                object value = prop.GetValue(obj, null);
                sb.Append($"\"{prop.Name}\":");

                if (value is string)
                {
                    sb.Append($"\"{value}\"");
                }
                else if (value is bool)
                {
                    sb.Append(value.ToString().ToLower());
                }
                else
                {
                    sb.Append(value);
                }

                if (i < properties.Length - 1)
                    sb.Append(",");
            }

            sb.Append("}");
            return sb.ToString();
        }
    }
}
