using System;
using System.Collections.Generic;
using System.Text;

namespace HttpClientFactoryConsoleApp.Model
{
    public class Tweet
    {
        public string Created_At { get; set; }
        public string Id { get; set; }
        public string Id_Str { get; set; }
        public string Text { get; set; }
        public string Source { get; set; }
        public int Retweet_count { get; set; }
        public int Reply_count { get; set; }
        public int Favorite_count { get; set; }

        public override string ToString()
        {
            return Text;
        }
    }
}
