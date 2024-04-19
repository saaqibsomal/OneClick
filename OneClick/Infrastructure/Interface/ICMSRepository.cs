using OneClick.Infrastructure.Model;

namespace OneClick.Infrastructure.Interface
{
    public interface ICMSRepository
    {
        void AddCMS(CMS homePage);
        void UpdateCMS(CMS req);
        CMS GetCMSByKey(string Key);
        List<CMS> GetCMSByKeyList(string Key);
        bool DeletedCMSByKey(string Key);
    }
}
