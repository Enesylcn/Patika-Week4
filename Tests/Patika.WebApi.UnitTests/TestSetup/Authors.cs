using Patika.WebApi.DBOperations;
using Patika.WebApi.Entities;

namespace TestSetup
{
    public static class Authors
    {
        public static void AddAuthors(this BookStoreDbContext context)
        {

            context.Authors.AddRange
                (
                   new Author
                   {
                       Name = "Eric",
                       Surname = "Ries",
                       BirthDate = new DateTime(1978, 12, 9),

                   },
                   new Author
                   {
                       Name = "Charlotte",
                       Surname = "Perkins Stetson Gilm",
                       BirthDate = new DateTime(1860, 8, 18),
                   },
                   new Author
                   {
                       Name = "Frank",
                       Surname = "Herbert",
                       BirthDate = new DateTime(1920, 10, 1),
                   }
               );
        }
    }
}