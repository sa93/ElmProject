using Infrastructure.Models;

namespace API.Services
{
    public class BaseService
    {
        protected DbDataContext Db { get; }
        //protected ICachingHelper CachingHelper { get; }

        protected BaseService(IServiceProvider serviceProvider)
        {
            if (serviceProvider == null)
                throw new ArgumentNullException(nameof(serviceProvider));

            Db = serviceProvider.GetRequiredService<DbDataContext>();

            // CachingHelper = serviceProvider.GetRequiredService<ICachingHelper>();
        }
    }
}