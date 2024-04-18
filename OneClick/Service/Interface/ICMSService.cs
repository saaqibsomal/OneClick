using OneClick.Infrastructure.Model;
using OneClick.Models;

namespace OneClick.Service.Interface
{
    public interface ICMSService
    {
        ResponseMessage AddCMS(CMS homePage);
        ResponseMessage UpdateCMS(CMS homePage);
        CMS GetCMSValue(string Key);
        List<CMS> GetCMSList(string Key);
    }
}
