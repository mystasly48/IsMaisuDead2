using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreTweet;

namespace IsMaisuDead2 {
  class Twitter {
    Tokens tokens;

    public Twitter(string ConsumerKey, string ConsumerSecret, string AccessToken, string AccessSecret) {
      tokens = Tokens.Create(ConsumerKey, ConsumerSecret, AccessToken, AccessSecret);
    }

    public void Tweet(string text) {
      tokens.Statuses.Update(status: text);
    }
  }
}
