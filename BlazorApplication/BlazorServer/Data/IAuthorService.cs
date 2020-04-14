using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorServer.Data
{
   public interface IAuthorService
   {

        List<Author> GetAuthors();
        Author GetAuthorById(string authorId);
        DateTime GetCreateDate();
        string GetVersion();
        void SaveAuthor(Author author);
        
   }
}
