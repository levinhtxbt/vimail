using System.Linq;

namespace ViMail.Common.Helper
{
    public static class CommonHelper
    {
        public static string GetTableName<T>() where T : class
        {
            string tableName = typeof(T).Name;
            var customAttributes = typeof(T).GetCustomAttributes(typeof(System.ComponentModel.DataAnnotations.Schema.TableAttribute),false);
            if (customAttributes.Count() > 0)
            {
                tableName = (customAttributes.First() as System.ComponentModel.DataAnnotations.Schema.TableAttribute).Name;
            }

            return tableName;
        }
    }
}