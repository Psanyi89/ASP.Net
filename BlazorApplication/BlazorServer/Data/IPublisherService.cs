using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorServer.Data
{
  public  interface IPublisherService
    {
        List<Publisher> GetPublishers();
        Publisher GetPublisherById(int pubId);
        DateTime GetCreateDate();
        string GetVersion();
        bool SavePublisher(Publisher publisher);
    }
}
