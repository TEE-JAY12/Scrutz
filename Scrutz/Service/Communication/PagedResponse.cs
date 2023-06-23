using Scrutz.Model;

namespace Scrutz.Service.Communication
{
    public class PagedResponse<T>
    {
        public PagedList<T> Items { get; set; }
        public object Metadata { get; set; }
    }
}
