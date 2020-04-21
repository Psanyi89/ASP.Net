using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorServer.Data
{
    public class PublisherService : IPublisherService
    {
        public DateTime CreationDate { get; set; }
        public List<Publisher> Publishers { get; set; }

        public PublisherService()
        {
            CreationDate = DateTime.Now;
            Publishers = new List<Publisher>
            {
                new Publisher { PubId = 1, PublisherName = "Johnson White", City = "Menlo Park"},
                new Publisher { PubId = 2, PublisherName = "Marijor Green", City = "Oakland"},
                new Publisher { PubId = 3, PublisherName = "Cheryl Carson", City = "Berkley"},
                new Publisher { PubId = 4, PublisherName = "Micheal O'Leary", City = "San Jose"},
                new Publisher { PubId = 5, PublisherName = "Dean Straight",City = "Berkley" }
            };
        }
            public DateTime GetCreateDate()
        {
           return CreationDate;
        }

        public Publisher GetPublisherById(int pubId)
        {
            return Publishers.FirstOrDefault(x=>x.PubId==pubId) ;
        }

        public List<Publisher> GetPublishers()
        {
            return Publishers;
        }

        public string GetVersion()
        {
            return "v1";
        }

        public bool SavePublisher(Publisher publisher)
        {
            try
            {
            Publishers.Add(publisher);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
