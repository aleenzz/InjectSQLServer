# InjectSQLServer

通过HarmonyLib Hook `System.Data.SqlClient.SqlConnection`的`Open`函数，钩子安装成功后，点击有数据库交互的功能，既可获得明文密码。

本程序只在本机测试研究，请勿用于实战环境。
