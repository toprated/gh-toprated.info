﻿using System.Threading.Tasks;
using Octokit;
using TopRatedApp.Common;
using TopRatedApp.Common.BadgeClasses;

namespace TopRatedApp.Extensions
{
    public static class GitHubClientExtensions
    {
        public static async Task<RepoData> GetRepoData(this GitHubClient client, BadgeQueryData bqd)
        {
            var r = await client.Repository.Get(bqd.User, bqd.Repo);
            var rData = new RepoData(r.Id.ToString(), Languages.GetLangByName(r.Language), r.StargazersCount);
            return rData;
        }
    }
}