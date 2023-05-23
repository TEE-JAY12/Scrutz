using Scrutz.Model;

namespace Scrutz.Repository.Interface
{
    public interface ITweetMetricRepo
    {
        Task<TweetMetric> FindByTweetID(string id);
    }
}
