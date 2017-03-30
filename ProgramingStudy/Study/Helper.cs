using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace ProgramingStudy.Study
{
    public static class Helper
    {
        public static readonly Dictionary<char, char> PolishDiacriticsLookup = new Dictionary<char, char>
            {
                {'ą','a'}, {'ć','c'}, {'ę','e'}, {'ł','l'}, {'ń','n'}, {'ó','o'}, {'ś','s'}, {'ź','z'}, {'ż','z'},
                {'Ą','A'}, {'Ć','C'}, {'Ę','E'}, {'Ł','L'}, {'Ń','N'}, {'Ó','O'}, {'Ś','S'}, {'Ź','Z'}, {'Ż','Z'}
            };

        public static T GetAppSetting<T>(string settingName) where T : IConvertible
        {
            return ConfigurationManager.AppSettings[settingName] == null ?
                default(T) : (T)Convert.ChangeType(ConfigurationManager.AppSettings[settingName], typeof(T));
        }

        public static string GetConnectionString(string connectionStringName)
        {
            return ConfigurationManager.ConnectionStrings[connectionStringName] == null ?
                null : ConfigurationManager.ConnectionStrings[connectionStringName].ConnectionString;
        }

        public static bool Contains(this string source, string toCheck, StringComparison comparison)
        {
            return source.IndexOf(toCheck, comparison) >= 0;
        }

        public static string ListToString(this List<string> list, string separator = ",")
        {
            return string.Join(separator, list.ToArray());
        }

        public static IEnumerable<TSource> DistinctBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            HashSet<TKey> seenKeys = new HashSet<TKey>();
            foreach (TSource element in source)
            {
                if (seenKeys.Add(keySelector(element)))
                {
                    yield return element;
                }
            }
        }

        public static string WriteBool(bool? val, string trueValTranslation, string falseValTranslation)
        {
            if (val.HasValue)
            {
                return val.Value ? trueValTranslation : falseValTranslation;
            }
            return null;
        }

        public static string WriteDate(DateTime? val, string defaultValue = null, string format = null)
        {

            string writeFormat = format == null ? "d" : format;
            return val.HasValue ? val.Value.ToString(writeFormat) : defaultValue;
        }

        /// <summary>
        /// Creates a deep clone of object. All objects in chain must be [Serializable].
        /// </summary>
        /// <param name="obj">Object to clone.</param>
        /// <returns>Cloned object.</returns>
        public static T DeepClone<T>(T obj)
        {
            object objResult;
            using (MemoryStream ms = new MemoryStream())
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(ms, obj);

                ms.Position = 0;
                objResult = bf.Deserialize(ms);
            }
            return (T)objResult;
        }

    }
}
