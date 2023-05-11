using Scrutz.Model;
using Scrutz.Repository.Interface;
using Scrutz.Service.Communication;
using Scrutz.Service.Interface;

namespace Scrutz.Service
{
    public class TweetService:ITweetService
    {
        private readonly ITweetRepo _tweetRepository;
        private readonly IUnitOfWork _unitOfWork;

        public TweetService(ITweetRepo itweetRepo, IUnitOfWork unitOfWork)
        {
            _tweetRepository = itweetRepo;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Tweet>> FindByCampaignIdAsync(int id)
        {
            var tweet = await _tweetRepository.FindByCampaignIdAsync(id);

            return tweet;
        }
    }
}
