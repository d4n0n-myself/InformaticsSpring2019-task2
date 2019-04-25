using System;
using System.Collections.Generic;
using Task2.Core.Entities;
using Task2.Infrastructure.ReposInterfaces;

namespace Task2.Domain
{
	public class PostDomainService
	{
		private readonly IPostRepository _repos;

		public PostDomainService(IPostRepository repos)
		{
			_repos = repos;
		}

		public Post GetOnlyTitle()
		{
			var enumerable = _repos.Get("123");
			enumerable.FileLink = null;
			enumerable.VideoUrl = null;
			return enumerable;
		}

		public bool Add(string title, string videoUrl, string fileLink)
		{
			throw new NotImplementedException();
		}

		public bool Delete(Post post)
		{
			throw new NotImplementedException();
		}

		public bool ContainPost(string header)
		{
			throw new NotImplementedException();
		}

		public Post Get(string title)
		{
			throw new NotImplementedException();
		}

		public Post Get(Guid postId)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<Post> Get()
		{
			throw new NotImplementedException();
		}
	}
}