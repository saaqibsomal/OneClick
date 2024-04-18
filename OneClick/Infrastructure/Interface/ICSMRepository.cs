using OneClick.Infrastructure.Model;

namespace OneClick.Infrastructure.Interface
{
    public interface ICSMRepository
    {
        void AddCMS(CMS homePage);
        void UpdateCMS(CMS req);
        CMS GetCMSByKey(string Key);
        List<CMS> GetCMSByKeyList(string Key);
    }
}
