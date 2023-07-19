using Scrutz.Model;
using Scrutz.Repository.Interface;
using Scrutz.Service.Communication;
using Scrutz.Service.Interface;
using System.Collections;

namespace Scrutz.Service
{
    public class TweetService:ITweetService
    {
        private readonly ITweetRepo _tweetRepository;
        private readonly IUserRepo _userRepo;
        private readonly ITweetMetricRepo _tweetMetricRepo;
        private readonly IUnitOfWork _unitOfWork;

        public TweetService(ITweetRepo itweetRepo, IUserRepo iuserRepo, ITweetMetricRepo itweetMetricRepo, IUnitOfWork unitOfWork)
        {
            _tweetRepository = itweetRepo;
            _unitOfWork = unitOfWork;
            _tweetMetricRepo = itweetMetricRepo;
            _userRepo = iuserRepo;
        }

        public async Task<IEnumerable<Tweets>> FindByCampaignIdAsync(int id)
        {
            var tweet = await _tweetRepository.FindByCampaignIdAsync(id);
               

            return tweet;

            
        }

        public async Task<ArrayList> FindByCampaignIdAsyncs(int id)
        {
            ArrayList arrayList = new ArrayList();
            var tweet = await _tweetRepository.FindByCampaignIdAsync(id);

            foreach (var item in tweet)
            {
                Dictionary<string, object> hashMap = new Dictionary<string, object>();

                hashMap.Add("TweetID",item.TweetID);
                hashMap.Add("Lang", item.Lang);
                hashMap.Add("CreatedAt", item.CreatedAt);
                hashMap.Add("Text", item.Text);
                hashMap.Add("Sentiment", item.Sentiment);
                hashMap.Add("CampaignId", item.CampaignId);

                var tweetmetrics = await _tweetMetricRepo.FindByTweetID(item.TweetID);

                //hashMap.Add("TweetMetricID", tweetmetrics.Id);
                hashMap.Add("ImpressionCount", tweetmetrics.ImpressionCount);
                hashMap.Add("LikeCount", tweetmetrics.LikeCount);
                hashMap.Add("QuoteCount", tweetmetrics.QuoteCount);
                hashMap.Add("ReplyCount", tweetmetrics.ReplyCount);
                hashMap.Add("RetweetCount", tweetmetrics.RetweetCount);

                var user = await _userRepo.FindAsync(item.UserID);

                hashMap.Add("UserID", user.UserID);
                hashMap.Add("Name", user.Name);
                hashMap.Add("Username", user.Username);
                hashMap.Add("Description", user.Description);
                hashMap.Add("Image_URL", user.Image_URL);
                hashMap.Add("IsVerified", user.IsVerified);
                hashMap.Add("FollowersCount", user.FollowersCount);
                hashMap.Add("FollowingCount", user.FollowingCount);
                hashMap.Add("TweetCount", user.TweetCount);
                hashMap.Add("ListedCount", user.ListedCount);
                hashMap.Add("CreateDate", user.CreateDate);


                arrayList.Add(hashMap);

            }


            

            return arrayList;
        }

        public async Task<PagedList<Tweets>> PagedListAsync(PageQuery pageQuery, int campaignId)
        {

            var campaign = await _tweetRepository.FindByCampaignIdPaged(pageQuery, campaignId);

            return campaign;
        }

        public async Task<PagedList<Tweets>> PagedListAsync()
        {

            var campaign = await _tweetRepository.PagedListAsync();

            return campaign;
        }

        public async Task<PagedList<Tweets>> PagedListAsyncs(PageQuery pageQuery, int campaignId, DateTime? startDate, DateTime? endDate)
        {

            var campaign = await _tweetRepository.FindByCampaignIdPageds(pageQuery, campaignId,startDate,endDate);

            return campaign;
        }


    }
}
