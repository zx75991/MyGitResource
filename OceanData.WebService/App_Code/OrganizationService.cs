using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

using Wicresoft.Framework.Common;
using Wicresoft.Framework.Organization;
using Wicresoft.Framework.Authentication;

using WebServiceSoapHeaderAuth;
using System.Web.Services.Protocols;

/// <summary>
/// OrganizationService 的摘要说明
/// </summary>
[WebService(Namespace = "http://wsaf.OceanData.com/", Description = "统一平台用户管理服务")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
// [System.Web.Script.Services.ScriptService]
public class OrganizationService : System.Web.Services.WebService
{
    public MySoapHeader header;
    public OrganizationService()
    {
        //如果使用设计的组件，请取消注释以下行 
        //InitializeComponent(); 
    }

    [WebMethod(Description = "获取部门在部门中的位置（从部门到用户的路径）")]
    [SoapHeader("header")]
    public string GetDepartmentDepartmentPath(string ancestorDepartmentID, string offspringDepartmentID)
    {
        if (!header.VerifyCredentials(header.UserName, header.Password, header.Type))
            return string.Empty;

        Guid gAncestorDepartmentID = (Guid)XmlSerializer.Deserialize(ancestorDepartmentID);

        Guid gOffspringDepartmentID = (Guid)XmlSerializer.Deserialize(offspringDepartmentID);

        return XmlSerializer.Serialize(OrganizationPublicHelper.GetDepartmentDepartmentPath(gAncestorDepartmentID, gOffspringDepartmentID));
    }

    [WebMethod(Description = "获取部门信息")]
    [SoapHeader("header")]
    public string GetDepartmentInfo(string departmentID)
    {
        if (!header.VerifyCredentials(header.UserName, header.Password, header.Type))
            return string.Empty;

        Guid gDepartmentID = (Guid)XmlSerializer.Deserialize(departmentID);

        return XmlSerializer.Serialize(OrganizationPublicHelper.GetDepartmentInfo(gDepartmentID));
    }

    [WebMethod(Description = "获取全体部门信息")]
    [SoapHeader("header")]
    public string GetDepartmentInfoList()
    {
        if (!header.VerifyCredentials(header.UserName, header.Password, header.Type))
            return string.Empty;

        return XmlSerializer.Serialize(OrganizationPublicHelper.GetDepartmentInfoList());
    }

    [WebMethod(Description = "获取部门下的所有部门，recursive表示是否包含下层部门")]
    [SoapHeader("header")]
    public string GetDepartmentInfoListByParentDepartment(string parentDepartmentID, bool recursive)
    {
        if (!header.VerifyCredentials(header.UserName, header.Password, header.Type))
            return string.Empty;

        Guid gParentDepartmentID = (Guid)XmlSerializer.Deserialize(parentDepartmentID);

        return XmlSerializer.Serialize(OrganizationPublicHelper.GetDepartmentInfoListByParentDepartment(gParentDepartmentID, recursive));
    }

    [WebMethod(Description = "获取用户在部门中的位置（从部门到用户的路径")]
    [SoapHeader("header")]
    public string GetDepartmentUserByIDPath(string departmentID, string userName)
    {
        if (!header.VerifyCredentials(header.UserName, header.Password, header.Type))
            return string.Empty;

        Guid gDepartmentID = (Guid)XmlSerializer.Deserialize(departmentID);

        return XmlSerializer.Serialize(OrganizationPublicHelper.GetDepartmentUserPath(gDepartmentID, userName));
    }

    [WebMethod(Description = "获取用户在部门中的位置（从部门到用户的路径")]
    [SoapHeader("header")]
    public string GetDepartmentUserByNamePath(string departmentID, string userID)
    {
        if (!header.VerifyCredentials(header.UserName, header.Password, header.Type))
            return string.Empty;

        Guid gDepartmentID = (Guid)XmlSerializer.Deserialize(departmentID);

        Guid gUserID = (Guid)XmlSerializer.Deserialize(userID);

        return XmlSerializer.Serialize(OrganizationPublicHelper.GetDepartmentUserPath(gDepartmentID, gUserID));
    }

    [WebMethod(Description = "获取团队信息")]
    [SoapHeader("header")]
    public string GetGroupInfo(string groupID)
    {
        if (!header.VerifyCredentials(header.UserName, header.Password, header.Type))
            return string.Empty;

        Guid gGroupID = (Guid)XmlSerializer.Deserialize(groupID);

        return XmlSerializer.Serialize(OrganizationPublicHelper.GetGroupInfo(gGroupID));
    }

    [WebMethod(Description = "获取全体团队信息")]
    [SoapHeader("header")]
    public string GetGroupInfoList()
    {
        if (!header.VerifyCredentials(header.UserName, header.Password, header.Type))
            return string.Empty;

        return XmlSerializer.Serialize(OrganizationPublicHelper.GetGroupInfoList());
    }

    [WebMethod(Description = "获取部门下所有的团队信息，recursive表示是否包含下层部门")]
    [SoapHeader("header")]
    public string GetGroupInfoListByDepartment(string departmentID, bool recursive)
    {
        if (!header.VerifyCredentials(header.UserName, header.Password, header.Type))
            return string.Empty;

        Guid gDepartmentID = (Guid)XmlSerializer.Deserialize(departmentID);

        return XmlSerializer.Serialize(OrganizationPublicHelper.GetGroupInfoListByDepartment(gDepartmentID, recursive));
    }

    [WebMethod(Description = "获取角色信息")]
    [SoapHeader("header")]
    public string GetRoleInfo(string roleID)
    {
        if (!header.VerifyCredentials(header.UserName, header.Password, header.Type))
            return string.Empty;

        Guid gRoleID = (Guid)XmlSerializer.Deserialize(roleID);

        return XmlSerializer.Serialize(OrganizationPublicHelper.GetRoleInfo(gRoleID));
    }

    [WebMethod(Description = "获取全体角色信息")]
    [SoapHeader("header")]
    public string GetRoleInfoList()
    {
        if (!header.VerifyCredentials(header.UserName, header.Password, header.Type))
            return string.Empty;

        return XmlSerializer.Serialize(OrganizationPublicHelper.GetRoleInfoList());
    }

    [WebMethod(Description = "获取某个应用的全部角色信息")]
    [SoapHeader("header")]
    public string GetRoleInfoListByApplication(string applicationID)
    {
        if (!header.VerifyCredentials(header.UserName, header.Password, header.Type))
            return string.Empty;

        Guid gApplicationID = (Guid)XmlSerializer.Deserialize(applicationID);

        return XmlSerializer.Serialize(OrganizationPublicHelper.GetRoleInfoListByApplication(gApplicationID));
    }

    [WebMethod(Description = "获取团队绑定的全部角色信息")]
    [SoapHeader("header")]
    public string GetRoleInfoListByGroup(string groupID)
    {
        if (!header.VerifyCredentials(header.UserName, header.Password, header.Type))
            return string.Empty;

        Guid gGroupID = (Guid)XmlSerializer.Deserialize(groupID);

        return XmlSerializer.Serialize(OrganizationPublicHelper.GetRoleInfoListByGroup(gGroupID));
    }

    [WebMethod(Description = "获取用户绑定的全部角色信息")]
    [SoapHeader("header")]
    public string GetRoleInfoListByUserID(string userID)
    {
        if (!header.VerifyCredentials(header.UserName, header.Password, header.Type))
            return string.Empty;

        Guid gUserID = (Guid)XmlSerializer.Deserialize(userID);

        return XmlSerializer.Serialize(OrganizationPublicHelper.GetRoleInfoListByUser(gUserID));
    }

    [WebMethod(Description = "获取用户绑定的全部角色信息")]
    [SoapHeader("header")]
    public string GetRoleInfoListByUserName(string userName)
    {
        if (!header.VerifyCredentials(header.UserName, header.Password, header.Type))
            return string.Empty;

        return XmlSerializer.Serialize(OrganizationPublicHelper.GetRoleInfoListByUser(userName));
    }

    [WebMethod(Description = "获取用户获得角色的方式（从角色到用户的路径）")]
    [SoapHeader("header")]
    public string GetRoleUserByIDPath(string roleID, string userID)
    {
        if (!header.VerifyCredentials(header.UserName, header.Password, header.Type))
            return string.Empty;

        Guid gRoleID = (Guid)XmlSerializer.Deserialize(roleID);

        Guid gUserID = (Guid)XmlSerializer.Deserialize(userID);

        return XmlSerializer.Serialize(OrganizationPublicHelper.GetRoleUserPath(gRoleID, gUserID));
    }

    [WebMethod(Description = "获取用户获得角色的方式（从角色到用户的路径）")]
    [SoapHeader("header")]
    public string GetRoleUserByNamePath(string roleID, string userName)
    {
        if (!header.VerifyCredentials(header.UserName, header.Password, header.Type))
            return string.Empty;

        Guid gRoleID = (Guid)XmlSerializer.Deserialize(roleID);

        return XmlSerializer.Serialize(OrganizationPublicHelper.GetRoleUserPath(gRoleID, userName));
    }

    [WebMethod(Description = "根据用户ID获得用户信息")]
    [SoapHeader("header")]
    public string GetUserInfoByID(string userID)
    {
        if (!header.VerifyCredentials(header.UserName, header.Password, header.Type))
            return string.Empty;

        string url = System.Configuration.ConfigurationManager.AppSettings["WSAF.PhotoUrl"];

        Guid gUserID = (Guid)XmlSerializer.Deserialize(userID);

        User user = OrganizationPublicHelper.GetUserInfo(gUserID);

        if (!string.IsNullOrEmpty(url) && !string.IsNullOrEmpty(user.Photo))
        {
            user.Photo = url + user.Photo;
        }
        return XmlSerializer.Serialize(user);
    }

    [WebMethod(Description = "根据用户名获得用户信息")]
    [SoapHeader("header")]
    public string GetUserInfoByName(string userName)
    {
        if (!header.VerifyCredentials(header.UserName, header.Password, header.Type))
            return string.Empty;

        string url = System.Configuration.ConfigurationManager.AppSettings["WSAF.PhotoUrl"];

        User user = OrganizationPublicHelper.GetUserInfo(userName);

        if (!string.IsNullOrEmpty(url) && !string.IsNullOrEmpty(user.Photo))
        {
            user.Photo = url + user.Photo;
        }
        return XmlSerializer.Serialize(user);
    }

    [WebMethod(Description = "获取全体用户信息")]
    [SoapHeader("header")]
    public string GetUserInfoList()
    {
        if (!header.VerifyCredentials(header.UserName, header.Password, header.Type))
            return string.Empty;

        string url = System.Configuration.ConfigurationManager.AppSettings["WSAF.PhotoUrl"];

        User[] users = OrganizationPublicHelper.GetUserInfoList();

        foreach (User user in users)
        {
            if (!string.IsNullOrEmpty(url) && !string.IsNullOrEmpty(user.Photo))
            {
                user.Photo = url + user.Photo;
            }
        }
        return XmlSerializer.Serialize(users);
    }

    [WebMethod(Description = "获取部门下的全体用户信息，recursive表示是否包含下层部门")]
    [SoapHeader("header")]
    public string GetUserInfoListByDepartment(string parentDepartmentID, bool recursive)
    {
        if (!header.VerifyCredentials(header.UserName, header.Password, header.Type))
            return string.Empty;

        Guid gParentDepartmentID = (Guid)XmlSerializer.Deserialize(parentDepartmentID);

        string url = System.Configuration.ConfigurationManager.AppSettings["WSAF.PhotoUrl"];

        User[] users = OrganizationPublicHelper.GetUserInfoListByDepartment(gParentDepartmentID, recursive);

        foreach (User user in users)
        {
            if (!string.IsNullOrEmpty(url) && !string.IsNullOrEmpty(user.Photo))
            {
                user.Photo = url + user.Photo;
            }
        }
        return XmlSerializer.Serialize(users);
    }

    [WebMethod(Description = "获取团队下的全体用户信息")]
    [SoapHeader("header")]
    public string GetUserInfoListByGroup(string groupID)
    {
        if (!header.VerifyCredentials(header.UserName, header.Password, header.Type))
            return string.Empty;

        Guid gGroupID = (Guid)XmlSerializer.Deserialize(groupID);

        string url = System.Configuration.ConfigurationManager.AppSettings["WSAF.PhotoUrl"];

        User[] users = OrganizationPublicHelper.GetUserInfoListByGroup(gGroupID, false);

        foreach (User user in users)
        {
            if (!string.IsNullOrEmpty(url) && !string.IsNullOrEmpty(user.Photo))
            {
                user.Photo = url + user.Photo;
            }
        }
        return XmlSerializer.Serialize(users);
    }

    [WebMethod(Description = "获取角色下的全体用户信息，recursive表示是否包含下层部门")]
    [SoapHeader("header")]
    public string GetUserInfoListByRole(string roleID, bool recursive)
    {
        if (!header.VerifyCredentials(header.UserName, header.Password, header.Type))
            return string.Empty;

        Guid gRoleID = (Guid)XmlSerializer.Deserialize(roleID);

        string url = System.Configuration.ConfigurationManager.AppSettings["WSAF.PhotoUrl"];

        User[] users = OrganizationPublicHelper.GetUserInfoListByRole(gRoleID, recursive);

        foreach (User user in users)
        {
            if (!string.IsNullOrEmpty(url) && !string.IsNullOrEmpty(user.Photo))
            {
                user.Photo = url + user.Photo;
            }
        }
        return XmlSerializer.Serialize(users);
    }

    [WebMethod(Description = "检验部门是否在部门中")]
    [SoapHeader("header")]
    public bool IsDepartmentInDepartment(string offspringDepartmentID, string ancestorDepartmentID, bool recursive)
    {
        if (!header.VerifyCredentials(header.UserName, header.Password, header.Type))
            return false;

        Guid gOffspringDepartmentID = (Guid)XmlSerializer.Deserialize(offspringDepartmentID);

        Guid gAncestorDepartmentID = (Guid)XmlSerializer.Deserialize(ancestorDepartmentID);

        return OrganizationPublicHelper.IsDepartmentInDepartment(gOffspringDepartmentID, gAncestorDepartmentID, recursive);
    }

    [WebMethod(Description = "检验权限组是否在部门中")]
    [SoapHeader("header")]
    public bool IsGroupInDepartment(string groupID, string departmentID)
    {
        if (!header.VerifyCredentials(header.UserName, header.Password, header.Type))
            return false;

        Guid gGroupID = (Guid)XmlSerializer.Deserialize(groupID);

        Guid gDepartmentID = (Guid)XmlSerializer.Deserialize(departmentID);

        return OrganizationPublicHelper.IsGroupInDepartment(gGroupID, gDepartmentID);
    }

    [WebMethod(Description = "检验权限组是否在角色中")]
    [SoapHeader("header")]
    public bool IsGroupInRole(string groupID, string roleID)
    {
        if (!header.VerifyCredentials(header.UserName, header.Password, header.Type))
            return false;

        Guid gGroupID = (Guid)XmlSerializer.Deserialize(groupID);

        Guid gRoleID = (Guid)XmlSerializer.Deserialize(roleID);

        return OrganizationPublicHelper.IsGroupInRole(gGroupID, gRoleID);
    }

    [WebMethod(Description = "检验用户是否在部门中")]
    [SoapHeader("header")]
    public bool IsUserByIDInDepartment(string userID, string departmentID)
    {
        if (!header.VerifyCredentials(header.UserName, header.Password, header.Type))
            return false;

        Guid gUserID = (Guid)XmlSerializer.Deserialize(userID);

        Guid gDepartmentID = (Guid)XmlSerializer.Deserialize(departmentID);

        return OrganizationPublicHelper.IsUserInDepartment(gUserID, gDepartmentID);
    }

    [WebMethod(Description = "检验用户是否在权限组中")]
    [SoapHeader("header")]
    public bool IsUserByIDInGroup(string userID, string groupID)
    {
        if (!header.VerifyCredentials(header.UserName, header.Password, header.Type))
            return false;

        Guid gUserID = (Guid)XmlSerializer.Deserialize(userID);

        Guid gGroupID = (Guid)XmlSerializer.Deserialize(groupID);

        return OrganizationPublicHelper.IsUserInGroup(gUserID, gGroupID);
    }

    [WebMethod(Description = "检验用户是否在角色中")]
    [SoapHeader("header")]
    public bool IsUserByIDInRole(string userID, string roleID)
    {
        if (!header.VerifyCredentials(header.UserName, header.Password, header.Type))
            return false;

        Guid gUserID = (Guid)XmlSerializer.Deserialize(userID);

        Guid gRoleID = (Guid)XmlSerializer.Deserialize(roleID);

        return OrganizationPublicHelper.IsUserInRole(gUserID, gRoleID);
    }

    [WebMethod(Description = "检验用户是否在部门中")]
    [SoapHeader("header")]
    public bool IsUserByNameInDepartment(string userName, string departmentID)
    {
        if (!header.VerifyCredentials(header.UserName, header.Password, header.Type))
            return false;

        Guid gDepartmentID = (Guid)XmlSerializer.Deserialize(departmentID);

        return OrganizationPublicHelper.IsUserInDepartment(userName, gDepartmentID);
    }

    [WebMethod(Description = "检验用户是否在权限组中")]
    [SoapHeader("header")]
    public bool IsUserByNameInGroup(string userName, string groupID)
    {
        if (!header.VerifyCredentials(header.UserName, header.Password, header.Type))
            return false;

        Guid gGroupID = (Guid)XmlSerializer.Deserialize(groupID);

        return OrganizationPublicHelper.IsUserInGroup(userName, gGroupID);
    }

    [WebMethod(Description = "检验用户是否在角色中")]
    [SoapHeader("header")]
    public bool IsUserByNameInRole(string userName, string roleID)
    {
        if (!header.VerifyCredentials(header.UserName, header.Password, header.Type))
            return false;

        Guid gRoleID = (Guid)XmlSerializer.Deserialize(roleID);

        return OrganizationPublicHelper.IsUserInRole(userName, gRoleID);
    }

    [WebMethod(Description = "在系统中搜索部门信息")]
    [SoapHeader("header")]
    public string SearchDepartment(string conditionXml)
    {
        if (!header.VerifyCredentials(header.UserName, header.Password, header.Type))
            return string.Empty;

        return XmlSerializer.Serialize(OrganizationPublicHelper.SearchDepartment(conditionXml));
    }

    [WebMethod(Description = "在部门下搜索部门，recursive表示是否包含下层部门")]
    [SoapHeader("header")]
    public string SearchDepartmentByParentDepartment(string parentDepartmentID, string conditionXml, bool recursive)
    {
        if (!header.VerifyCredentials(header.UserName, header.Password, header.Type))
            return string.Empty;

        Guid gParentDepartmentID = (Guid)XmlSerializer.Deserialize(parentDepartmentID);

        return XmlSerializer.Serialize(OrganizationPublicHelper.SearchDepartmentByParentDepartment(gParentDepartmentID, conditionXml, recursive));
    }

    [WebMethod(Description = "在系统中搜索团队信息")]
    [SoapHeader("header")]
    public string SearchGroup(string conditionXml)
    {
        if (!header.VerifyCredentials(header.UserName, header.Password, header.Type))
            return string.Empty;

        return XmlSerializer.Serialize(OrganizationPublicHelper.SearchGroup(conditionXml));
    }

    [WebMethod(Description = "在部门下搜索团队信息，recursive表示是否包含下层部门")]
    [SoapHeader("header")]
    public string SearchGroupByDepartment(string departmentID, string conditionXml, bool recursive)
    {
        if (!header.VerifyCredentials(header.UserName, header.Password, header.Type))
            return string.Empty;

        Guid gDepartmentID = (Guid)XmlSerializer.Deserialize(departmentID);

        return XmlSerializer.Serialize(OrganizationPublicHelper.SearchGroupByDepartment(gDepartmentID, conditionXml, recursive));
    }

    [WebMethod(Description = "在系统中搜索角色信息")]
    [SoapHeader("header")]
    public string SearchRole(string conditionXml)
    {
        if (!header.VerifyCredentials(header.UserName, header.Password, header.Type))
            return string.Empty;

        return XmlSerializer.Serialize(OrganizationPublicHelper.SearchRole(conditionXml));
    }

    [WebMethod(Description = "在应用中搜索角色")]
    [SoapHeader("header")]
    public string SearchRoleByApplication(string applicationID, string conditionXml)
    {
        if (!header.VerifyCredentials(header.UserName, header.Password, header.Type))
            return string.Empty;

        Guid gApplicationID = (Guid)XmlSerializer.Deserialize(applicationID);

        return XmlSerializer.Serialize(OrganizationPublicHelper.SearchRoleByApplication(gApplicationID, conditionXml));
    }

    [WebMethod(Description = "在系统中搜索用户信息")]
    [SoapHeader("header")]
    public string SearchUser(string conditionXml)
    {
        if (!header.VerifyCredentials(header.UserName, header.Password, header.Type))
            return string.Empty;

        string url = System.Configuration.ConfigurationManager.AppSettings["WSAF.PhotoUrl"];

        User[] users = OrganizationPublicHelper.SearchUser(conditionXml);

        foreach (User user in users)
        {
            if (!string.IsNullOrEmpty(url) && !string.IsNullOrEmpty(user.Photo))
            {
                user.Photo = url + user.Photo;
            }
        }
        return XmlSerializer.Serialize(users);
    }

    [WebMethod(Description = "在部门下搜索用户，recursive表示是否包含下层部门")]
    [SoapHeader("header")]
    public string SearchUserByDepartment(string departmentID, string conditionXml, bool recursive)
    {
        if (!header.VerifyCredentials(header.UserName, header.Password, header.Type))
            return string.Empty;

        string url = System.Configuration.ConfigurationManager.AppSettings["WSAF.PhotoUrl"];

        Guid gDepartmentID = (Guid)XmlSerializer.Deserialize(departmentID);

        User[] users = OrganizationPublicHelper.SearchUserByDepartment(gDepartmentID, conditionXml, recursive);

        foreach (User user in users)
        {
            if (!string.IsNullOrEmpty(url) && !string.IsNullOrEmpty(user.Photo))
            {
                user.Photo = url + user.Photo;
            }
        }
        return XmlSerializer.Serialize(users);
    }


}
