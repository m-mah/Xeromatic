using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Xeromatic.Models;

namespace Xeromatic.Services
{
    public interface iTwitterService
    {
        IEnumerable<Tweet> GetTweets();
    }
}