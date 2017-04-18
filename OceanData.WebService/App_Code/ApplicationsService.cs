using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Wicresoft.Framework.Common;
using Wicresoft.Framework.Applications;
using System.Data;
using System.IO;
using WebServiceSoapHeaderAuth;
using System.Web.Services.Protocols;

/// <summary>
/// ApplicationsService 的摘要说明
/// </summary>
[WebService(Namespace = "http://wsaf.OceanData.com/", Description = "统一平台应用管理服务")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
// [System.Web.Script.Services.ScriptService]
public class ApplicationsService : System.Web.Services.WebService
{
    public MySoapHeader header;

    public ApplicationsService()
    {
        //如果使用设计的组件，请取消注释以下行 
        //InitializeComponent(); 
    }

    #region Application Operations

    [WebMethod(Description = "获取应用具体信息")]
    [SoapHeader("header")]
    public string GetApplicationInfo(string applicationID)
    {
        if (!header.VerifyCredentials(header.UserName, header.Password, header.Type))
            return string.Empty;

        Guid gApplicationID = (Guid)XmlSerializer.Deserialize(applicationID);

        return XmlSerializer.Serialize(ApplicationsPublicHelper.GetApplicationInfo(gApplicationID));
    }

    [WebMethod(Description = "获取某一产品在系统中注册的所有实例")]
    [SoapHeader("header")]
    public string GetApplicationInfoListByProductID(string productID)
    {
        if (!header.VerifyCredentials(header.UserName, header.Password, header.Type))
            return string.Empty;

        Guid gProductID = (Guid)XmlSerializer.Deserialize(productID);

        return XmlSerializer.Serialize(ApplicationsPublicHelper.GetApplicationInfoListByProductID(gProductID));
    }

    [WebMethod(Description = "获取公共配置项")]
    [SoapHeader("header")]
    public string GetPublicConfig(string key)
    {
        if (!header.VerifyCredentials(header.UserName, header.Password, header.Type))
            return string.Empty;

        return ApplicationsPublicHelper.GetPublicConfig(key);
    }

    [WebMethod(Description = "获取应用配置项（如果没有特别配置，会再去公共配置项中查找）")]
    [SoapHeader("header")]
    public string GetApplicationConfigByKey(string applicationID, string key)
    {
        if (!header.VerifyCredentials(header.UserName, header.Password, header.Type))
            return string.Empty;

        Guid gApplicationID = (Guid)XmlSerializer.Deserialize(applicationID);

        return ApplicationsPublicHelper.GetApplicationConfig(gApplicationID, key);
    }

    [WebMethod(Description = "获取应用配置项（包括所有公共配置项，除非被应用自己的配置项覆盖）")]
    [SoapHeader("header")]
    public string GetApplicationConfig(string applicationID)
    {
        if (!header.VerifyCredentials(header.UserName, header.Password, header.Type))
            return string.Empty;

        Guid gApplicationID = (Guid)XmlSerializer.Deserialize(applicationID);

        DataSet ds = new DataSet();

        DataTable dt = ApplicationsPublicHelper.GetApplicationConfig(gApplicationID);

        ds.Tables.Add(dt);

        MemoryStream ms = new MemoryStream();

        ds.WriteXml(ms);

        ms.Seek(0, SeekOrigin.Begin);

        StreamReader sr = new StreamReader(ms);

        return sr.ReadToEnd();
    }

    #endregion

    #region Service Operations

    [WebMethod(Description = "获取服务详细信息")]
    [SoapHeader("header")]
    public string GetServiceInfo(string serviceID)
    {
        if (!header.VerifyCredentials(header.UserName, header.Password, header.Type))
            return string.Empty;

        Guid gServiceID = (Guid)XmlSerializer.Deserialize(serviceID);

        return XmlSerializer.Serialize(ApplicationsPublicHelper.GetServiceInfo(gServiceID));
    }

    [WebMethod(Description = "获取某个应用所有服务的列表")]
    [SoapHeader("header")]
    public string GetServiceInfoListByApplication(string applicationID)
    {
        if (!header.VerifyCredentials(header.UserName, header.Password, header.Type))
            return string.Empty;

        Guid gApplicationID = (Guid)XmlSerializer.Deserialize(applicationID);

        return XmlSerializer.Serialize(ApplicationsPublicHelper.GetServiceInfoListByApplication(gApplicationID));
    }

    #endregion

    #region Event Opertations

    [WebMethod(Description = "发送一个预先注册的事件", TransactionOption = System.EnterpriseServices.TransactionOption.Supported)]
    [SoapHeader("header")]
    public string SendEvent(string applicationID, string eventDefinitionID, string eventData)
    {
        if (!header.VerifyCredentials(header.UserName, header.Password, header.Type))
            return string.Empty;

        Guid gApplicationID = (Guid)XmlSerializer.Deserialize(applicationID);

        Guid gEventDefinitionID = (Guid)XmlSerializer.Deserialize(eventDefinitionID);

        return ApplicationsPublicHelper.SendEvent(gApplicationID, gEventDefinitionID, eventData).ToString();
    }

    [WebMethod(Description = "获取一段时间内应用接收到的事件")]
    [SoapHeader("header")]
    public string GetEventInfoListByApplication(string applicationID, DateTime beginTime, DateTime endTime)
    {
        if (!header.VerifyCredentials(header.UserName, header.Password, header.Type))
            return string.Empty;

        Guid gApplicationID = (Guid)XmlSerializer.Deserialize(applicationID);

        return XmlSerializer.Serialize(ApplicationsPublicHelper.GetEventInfoListByApplication(gApplicationID, beginTime, endTime));
    }

    #endregion

    #region Check Operations

    [WebMethod(Description = "验证应用合法性")]
    [SoapHeader("header")]
    public bool CheckApplication(string applicationID)
    {
        if (!header.VerifyCredentials(header.UserName, header.Password, header.Type))
            return false;

        Guid gApplicationID = (Guid)XmlSerializer.Deserialize(applicationID);

        return ApplicationsPublicHelper.CheckApplication(gApplicationID);
    }

    #endregion

    #region Log Operations

    [WebMethod(Description = "应用写入日志", TransactionOption = System.EnterpriseServices.TransactionOption.Supported)]
    [SoapHeader("header")]
    public bool WriteLog(string applicationID, DateTime createTime, string eventData, string userID,
        string userName, int eventID, string category, string type)
    {
        if (!header.VerifyCredentials(header.UserName, header.Password, header.Type))
            return false;

        Guid gApplicationID = (Guid)XmlSerializer.Deserialize(applicationID);

        Guid gUserID = (Guid)XmlSerializer.Deserialize(userID);

        return ApplicationsPublicHelper.WriteLog(gApplicationID, createTime, eventData, gUserID,
            userName, eventID, category, type);
    }

    [WebMethod(Description = "应用获取日志")]
    [SoapHeader("header")]
    public string GetLogs(string applicationID)
    {
        if (!header.VerifyCredentials(header.UserName, header.Password, header.Type))
            return string.Empty;

        Guid gApplicationID = (Guid)XmlSerializer.Deserialize(applicationID);

        return XmlSerializer.Serialize(ApplicationsPublicHelper.GetLogsByApplication(gApplicationID));
    }

    [WebMethod(Description = "应用搜索日志")]
    [SoapHeader("header")]
    public string SearchLogs(string applicationID, string conditionXml)
    {
        if (!header.VerifyCredentials(header.UserName, header.Password, header.Type))
            return string.Empty;

        Guid gApplicationID = (Guid)XmlSerializer.Deserialize(applicationID);

        return XmlSerializer.Serialize(ApplicationsPublicHelper.SearchLogsByApplication(gApplicationID, conditionXml));
    }

    #endregion

}
