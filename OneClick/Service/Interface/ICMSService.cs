using OneClick.Infrastructure.Model;
using OneClick.Models;

namespace OneClick.Service.Interface
{
    public interface ICMSService
    {
        ResponseMessage AddCMS(CMSRequest req, IFormFile file);
        ResponseMessage UpdateCMS(CMSRequest req, IFormFile file);
        CMS GetCMSValue(string Key);
        List<CMSResponse> GetCMSList(string Key);
        bool DeletedByKey(string Key);
        ResponseMessage FileUpload(IFormFile file);
        CmsResponse GetFiles();
        ResponseMessage DeleteFile(string path);
        List<CMSResponse> GetVideo(string Key);
    }
}