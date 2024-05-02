using Microsoft.EntityFrameworkCore;
using OneClick.Infrastructure.Db;
using OneClick.Infrastructure.Interface;
using OneClick.Infrastructure.Model;

namespace OneClick.Infrastructure.Repository
{
    public class CMSRepository: ICMSRepository
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
            return _context.CMS.Where(x => x.Key == Key && x.isActive == true).FirstOrDefault();
        }

        public List<CMS> GetCMSByKeyList(string Key)
        {
            return _context.CMS.Where(x => x.isActive == true).ToList();
        }

        public bool DeletedCMSByKey(string Key)
        {
            
            var Data = _context.CMS.Where(x => x.Key == Key).ToList();

            foreach (var item in Data)
            {
                _context.CMS.Remove(item);
            }
            _context.SaveChanges();
            return true;
        }
    }
}
