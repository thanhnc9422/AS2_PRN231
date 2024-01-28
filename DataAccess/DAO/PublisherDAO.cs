using BusinessObject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAO
{
    internal class PublisherDAO
    {
        readonly PRN231_AS2Context _context = new PRN231_AS2Context();
        public PublisherDAO() { }
        public PublisherDAO(PRN231_AS2Context context)
        {
            _context = context;
        }
        public void createPublisher(Publisher publisher)
        {
           _context.Publishers.Add(publisher);
            _context.SaveChanges();
        }

        public void deletePublisher(int id)
        {
            Publisher p = _context.Publishers.FirstOrDefault(x => x.PubId == id);
            if (p != null) {
                _context.Publishers.Remove(p);
                _context.SaveChanges();
            }
        }

        public List<Publisher> listPublisher()
        {
           return _context.Publishers.ToList();
        }

        public void updatePublisher(Publisher publisher)
        {
            Publisher p = _context.Publishers.FirstOrDefault(x => x.PubId == publisher.PubId);
            if (p != null)
            {
                p.PublishserName = publisher.PublishserName;
                p.Country = publisher.Country;
                p.State = publisher.State;
                p.Country = publisher.Country;
                _context.Publishers.Update(p);
                _context.SaveChanges();
            }
        }
    }
}
