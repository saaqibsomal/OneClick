using OneClick.Infrastructure.Db;
using OneClick.Infrastructure.Interface;
using OneClick.Infrastructure.Model;

namespace OneClick.Infrastructure.Repository
{
    public class CMSRepository: ICSMRepository
    {
        private OneClickContext _context;
        public CMSRepository(OneClickContext context)
        {
            _context = context;
        }

        public void AddCMS(CMS req)
        {
            _context.CMS.Add(req);
            _context.SaveChanges();
        }

        public void UpdateCMS(CMS req)
        {
            _context.CMS.Update(req);
            _context.SaveChanges();
        }

        public CMS GetCMSByKey(string Key)
        {
            return _context.CMS.Where(x => x.Key == Key).FirstOrDefault();
        }

        public List<CMS> GetCMSByKeyList(string Key)
        {
            return _context.CMS.Where(x => x.Key == Key).ToList();
        }

    }
}
