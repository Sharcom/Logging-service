using Microsoft.EntityFrameworkCore;
using AL;
using DAL;

namespace FL
{
    public static class ILogCollectionFactory
    {
        public static ILogCollection Get(DbContext context)
        {
            return new LogDAL(context);
        }
    }
}