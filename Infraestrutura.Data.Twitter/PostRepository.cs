﻿using Dominio.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using TweetSharp;

namespace Infraestrutura.Data.Twitter
{
    public class PostRepository : IPostRepository
    {
        private readonly string _consumerKey;
        private readonly string _consumerSecret;
        private readonly string _accessToken;
        private readonly string _accessTokenSecret;

        public PostRepository()
        {
            // Colocar as chaves de acesso aqui
            _consumerKey = ""; 
            _consumerSecret = "";
            _accessToken = "";
            _accessTokenSecret = "";
        }


        public Post Get(long id)
        {
            var service = GetAuthenticatedService();
            var tweet = service.GetTweet(new GetTweetOptions() { Id = id });

            return new Post
            {
                PostId = tweet.Id,
                PostMessage = tweet.Text,
                PostDate = tweet.CreatedDate
            };

        }

        public IEnumerable<Post> GetAll()
        {
            var service = GetAuthenticatedService();
            var tweets = service.ListTweetsOnHomeTimeline(new ListTweetsOnHomeTimelineOptions());

            List<Post> posts = new List<Post>();
            foreach (var tweet in tweets)
            {
                posts.Add(new Post
                {
                    PostId = tweet.Id,
                    PostMessage = tweet.Text,
                    PostDate = tweet.CreatedDate
                });
            }

            return posts;
        }

        public Post SaveOrUpdate(Post post)
        {
            var service = GetAuthenticatedService();
            var tweet = service.SendTweet(new SendTweetOptions { Status = post.PostMessage });
            post.PostId = tweet.Id;
            post.PostDate = tweet.CreatedDate;
            return post;
        }


        private TwitterService GetAuthenticatedService()
        {
            var service = new TwitterService(_consumerKey, _consumerSecret);
            service.TraceEnabled = true;
            service.AuthenticateWith(_accessToken, _accessTokenSecret);
            return service;
        }

    }
}
