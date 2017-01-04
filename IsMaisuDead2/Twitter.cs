using CoreTweet;

namespace IsMaisuDead2 {
  class Twitter {
    Tokens tokens;
    const string ONLINE = " (Online)";
    const string OFFLINE = " (Offline)";

    public Twitter(string ConsumerKey, string ConsumerSecret, string AccessToken, string AccessSecret) {
      tokens = Tokens.Create(ConsumerKey, ConsumerSecret, AccessToken, AccessSecret);
    }

    public void Online() {
      UpdateStatus(ONLINE);
    }

    public void Offline() {
      UpdateStatus(OFFLINE);
    }

    private void UpdateStatus(string status) {
      string name = GetName();
      name = name.Replace(ONLINE, "");
      name = name.Replace(OFFLINE, "");
      UpdateName(name + status);
    }

    private string GetName() {
      return tokens.Account.UpdateProfile().Name;
    }

    private void UpdateName(string name) {
      tokens.Account.UpdateProfile(name: name);
    }
  }
}
