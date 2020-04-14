using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorServer.Data
{
    public class AuthorService : IAuthorService
    {
        public DateTime CreationDate { get; set; }
        public List<Author> Authors { get; set; }

        public AuthorService()
        {
            CreationDate = DateTime.Now;
            Authors = new List<Author>
            {
                new Author { AuthorId = "172-32-1176", FirstName = "Johnson", LastName = "White", PhoneNumber = "408 496 7223", City = "Menlo Park",EmailAddress="johnson.white@gmail.com",Salary=11000  },
                new Author { AuthorId = "213-16-8915", FirstName = "Marijorie", LastName = "Green", PhoneNumber = "415 986 7020", City = "Oakland", EmailAddress="marijorie.green@gmail.com", Salary=22000 },
                new Author { AuthorId = "238-95-7766", FirstName = "Cheryl", LastName = "Carson", PhoneNumber = "415 548 7723", City = "Berkley", EmailAddress="cheryl.carson@gmail.com",Salary=39000 },
                new Author { AuthorId = "267-41-2394", FirstName = "Micheal", LastName = "O'Leary", PhoneNumber = "408 286 2919", City = "San Jose", EmailAddress="michael.oleary@gmail.com",Salary=31000 },
                new Author { AuthorId = "274-80-9391", FirstName = "Dean", LastName = "Straight", PhoneNumber = "415 834 2919", City = "Berkley", EmailAddress="dean.straight@gmail.com",Salary=29000 }
            };

        }
        public Author GetAuthorById(string authorId)
        {
            return Authors.Where(x => x.AuthorId == authorId).FirstOrDefault();
        }

        public List<Author> GetAuthors()
        {
            return Authors;
        }

        public DateTime GetCreateDate()
        {
            return CreationDate;
        }

        public string GetVersion()
        {
            return "v1";
        }

        public void SaveAuthor(Author author)
        {
            Authors.Add(author);
        }
    }
}
