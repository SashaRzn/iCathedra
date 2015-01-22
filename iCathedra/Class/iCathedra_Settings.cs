using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Reflection;
using System.Globalization;

namespace iCathedra
{
    public class iCathedra_Settings
    {
        public const string SettingsFileName = "Settings.cfg";

        public static int SchoolYearId
        {
            get { return getValue<int>(iCathedra_Settings.SettingsFileName, "SchoolYearId", 1); }
            set { setValue(iCathedra_Settings.SettingsFileName, "SchoolYearId", value); }
        }

        /// <summary>
        /// Процент отклонения нагрузки
        /// </summary>
        public static decimal LoadPercent
        {
            get { return getValue<decimal>(iCathedra_Settings.SettingsFileName, "LoadPercent", (decimal)20); }
            set { setValue(iCathedra_Settings.SettingsFileName, "LoadPercent", value); }
        }

        /// <summary>
        /// Коды сотрудников "Почасовой фонд"
        /// </summary>
        public static int PochFondKod
        {
            get { return getValue<int>(iCathedra_Settings.SettingsFileName, "PochFondKod", 23); }
            set { setValue(iCathedra_Settings.SettingsFileName, "PochFondKod", value); }
        }

        /// <summary>
        /// Коды сотрудника "Нераспределенная нагрузка" (неизвестный)
        /// </summary>
        public static int FreeHoursEmployeeId
        {
            get { return getValue<int>(iCathedra_Settings.SettingsFileName, "FreeHoursEmployeeId", 19); }
            set { setValue(iCathedra_Settings.SettingsFileName, "FreeHoursEmployeeId", value); }
        }


        //public static int[] PochFondKodArray
        //{
        //    get
        //    {
        //        string[] pochFondKodes = PochFondKod.Split(',');
        //        int[] rv = new int[pochFondKodes.Length];
        //        for (int i = 0; i < pochFondKodes.Length; i++)
        //        {
        //            rv[i] = Convert.ToInt32(pochFondKodes[i]);
        //        }
        //        return rv;
        //    }
        //}

        /// Получает значение параметра типа T. Если параметр отсутствует в файле конфигурации,
        /// то возвращает значение по умолчанию, переданное в качестве параметра.
        /// Используется в get-терах параметров-свойств.
        protected static T getValue<T>(string AFileName, string AVariableName, T DefaultValue)
        {
            string _variableValue = "";
            if (ConfigFile.ReadVariable(SettingsFileName,
                    AVariableName, out _variableValue))
                return ParseString<T>(_variableValue);
            else
                return DefaultValue;
        }

        /// <summary>
        /// Сохраняет значение параметра AVariableName в файле конфигурации.
        /// </summary>
        /// <param name="AVariableName"></param>
        /// <param name="AValue"></param>
        /// <returns></returns>
        protected static void setValue(string AFileName, string AVariableName, object AValue)
        {
            ConfigFile.SetVariable(SettingsFileName,
                AVariableName, AValue.ToString());
        }

        /// <summary>
        /// Преобразует строку AValue к заданному типу
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="AValue"></param>
        /// <returns></returns>
        public static T ParseString<T>(string AValue)
        {
            Type genericType = typeof(T);
            if (genericType.Equals(typeof(String)))
            {
                ConstructorInfo constructor = genericType.GetConstructor(new Type[] { typeof(char[]) });
                return (T)constructor.Invoke(new object[] { AValue.ToCharArray() });
            }
            ConstructorInfo defaultConstructor = genericType.GetConstructor(new Type[] { });
            T result;
            MethodInfo parseMethod = genericType.GetMethod("Parse", new Type[] { typeof(string), typeof(CultureInfo) });
            if (parseMethod != null)
            {
                try
                {
                    CultureInfo culture = new CultureInfo("ru-RU");
                    try
                    {
                        culture.NumberFormat.NumberDecimalSeparator = ",";
                        result = (T)parseMethod.Invoke(null, new object[] { AValue, culture });
                    }
                    catch
                    {
                        culture.NumberFormat.NumberDecimalSeparator = ".";
                        result = (T)parseMethod.Invoke(null, new object[] { AValue, culture });
                    }
                }
                catch
                {
                    CultureInfo culture = new CultureInfo("en-US");
                    try
                    {
                        culture.NumberFormat.NumberDecimalSeparator = ",";
                        result = (T)parseMethod.Invoke(null, new object[] { AValue, culture });
                    }
                    catch
                    {
                        culture.NumberFormat.NumberDecimalSeparator = ".";
                        result = (T)parseMethod.Invoke(null, new object[] { AValue, culture });
                    }
                }
            }
            else
            {
                parseMethod = genericType.GetMethod("Parse", new Type[] { typeof(string) });
                result = (T)parseMethod.Invoke(null, new object[] { AValue });
            }
            return result;
        }
    }

    public static class ConfigFile
    {
        /// <summary>
        /// Читает значение параметра из файла конфигурации
        /// </summary>
        /// <param name="AFileName"></param>
        /// <param name="AVariableName"></param>
        /// <param name="AVariableValue"></param>
        /// <returns></returns>
        public static bool ReadVariable(string AFileName, string AVariableName, out string AVariableValue)
        {
            AVariableValue = "";
            if (!File.Exists(AFileName)) return false;
            string[] sa = File.ReadAllLines(AFileName);
            for (int i = 0; i < sa.Length; i++)
            {
                string[] _configVariable = sa[i].Split((new char[] { '=' }), 2);
                if (_configVariable[0] == AVariableName)
                {
                    AVariableValue = _configVariable[1];
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Сохраняет значение параметра в файле
        /// </summary>
        /// <param name="AFileName"></param>
        /// <param name="AVariableName"></param>
        /// <param name="AVariableValue"></param>
        public static void SetVariable(string AFileName, string AVariableName, string AVariableValue)
        {
            if (File.Exists(AFileName))
            {
                string[] sa = File.ReadAllLines(AFileName);
                for (int i = 0; i < sa.Length; i++)
                {
                    string[] _configVariable = sa[i].Split((new char[] { '=' }), 2);
                    if (_configVariable[0] == AVariableName)
                    {
                        _configVariable[1] = AVariableValue;
                        sa[i] = _configVariable[0] + "=" + _configVariable[1];
                        lock ("ConfigFile") File.WriteAllLines(AFileName, sa);
                        return;
                    }
                }
            }
            else if (!String.IsNullOrEmpty(Path.GetDirectoryName(AFileName)))
            {
                if (!Directory.Exists(Path.GetDirectoryName(AFileName)))
                    Directory.CreateDirectory(Path.GetDirectoryName(AFileName));
            }
            StreamWriter sw = File.AppendText(AFileName);
            lock ("ConfigFile") sw.WriteLine(AVariableName + "=" + AVariableValue);
            sw.Close();
            return;
        }

        /// <summary>
        /// Удаляет параметр из файла конфигурации
        /// </summary>
        /// <param name="AFileName"></param>
        /// <param name="AVariableName"></param>
        /// <returns></returns>
        public static bool RemoveVariable(string AFileName, string AVariableName)
        {
            if (File.Exists(AFileName))
            {
                string[] sa = File.ReadAllLines(AFileName);
                for (int i = 0; i < sa.Length; i++)
                {
                    string[] _configVariable = sa[i].Split((new char[] { '=' }), 2);
                    if (_configVariable[0] == AVariableName)
                    {
                        string[] _newsa = new string[sa.Length - 1];
                        for (int j = 0; j < i; j++) _newsa[j] = sa[j];
                        for (int j = i + 1; j < sa.Length; j++) _newsa[j - 1] = sa[j];
                        lock ("ConfigFile") File.WriteAllLines(AFileName, _newsa);
                        return true;
                    }
                }
            }
            return false;
        }
    }

}
