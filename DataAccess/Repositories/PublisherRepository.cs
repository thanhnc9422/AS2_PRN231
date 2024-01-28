using BusinessObject.Model;
using DataAccess.DAO;

namespace DataAccess.Repositories
{
    public class PublisherRepository : IPublisherReposity
    {
        private PublisherDAO publisherDAO = new PublisherDAO();
        public void createPublisher(Publisher publisher)
        {
            publisherDAO.createPublisher(publisher);
        }

        public void deletePublisher(int id)
        {
            publisherDAO.deletePublisher(id);
        }

        public List<Publisher> listPublisher()
        {
            return publisherDAO.listPublisher();
        }

        public void updatePublisher(Publisher publisher)
        {
            publisherDAO.updatePublisher(publisher);
        }
    }
}
