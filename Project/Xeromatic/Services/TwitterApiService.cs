using System.Collections.Generic;
using System.Linq;
using Tweetinvi;
using Tweetinvi.Core.Credentials;
using Tweet = Xeromatic.Models.Tweet;


namespace Xeromatic.Services
{
    public class TwitterApiService
    {
        // Get keys from: https://apps.twitter.com
        // Wiki for tweetinvi: https://github.com/linvi/tweetinvi/wiki

        readonly TwitterCredentials _creds;

        public TwitterApiService()
        {
            _creds = new TwitterCredentials
            {
                ConsumerKey = "4c0hybMEURve3dgLwJKlNtJkL",
                ConsumerSecret = "6ZvdxojCLjJS8tolObYKlixgfaIclOXSAeqptWQCacWnCnvbKY",
                AccessToken = "355836672-OUuzbTuW27WWEYSp375X6ZIqa5PQUNXwnCBTe9nI",
                AccessTokenSecret = "KobVQS2KffduwhQdLirxnOYejX4IErY4nA2MZEKIJm8o3"
            };
        }

        public IEnumerable<Tweet> GetTweets()
        {
            var tweets = Auth.ExecuteOperationWithCredentials(_creds, () => Timeline.GetUserTimeline("xero", 10))?.ToList();

            if (tweets != null && tweets.Any())
                return tweets.Select(t => new Tweet()
                {
                    Id = t.Id,
                    Text = t.Text
                });

            return new List<Tweet>();
        }

    }
}