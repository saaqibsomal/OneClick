using OneClick.Infrastructure.Model;
using OneClick.Models;

namespace OneClick.Service.Interface
{
    public interface ICMSService
    {
        ResponseMessage AddCMS(CMSRequest req, IFormFile file);
        ResponseMessage UpdateCMS(CMSRequest req, IFormFile file);
        CMS GetCMSValue(string Key);
        List<CMS> GetCMSList(string Key);
    }
}
