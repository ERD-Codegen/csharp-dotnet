using System.Linq;
using realworlddotnet.Api.Models;
using realworlddotnet.Core.Dto;
using realworlddotnet.Core.Entities;

namespace realworlddotnet.Api.Mappers
{
    public static class ArticlesMapper
    {
        public static ArticleResponse MapFromArticleEntity(Article article)
        {
            var tags = article.Tags.Select(tag => tag.Id);
            var author = article.Author;
            var result = new ArticleResponse(
                article.Slug,
                article.Title,
                article.Description,
                article.Body,
                article.CreatedAt,
                article.UpdatedAt,
                tags,
                new Author(author.Username,
                    author.Image,
                    author.Bio,
                    false),
                false,
                0);
            return result;
        }

        public static ArticlesResponse MapFromArticles(ArticlesResponseDto articlesResponseDto)
        {
            var articles = articlesResponseDto.Articles
                .Select(articleEntity => MapFromArticleEntity(articleEntity))
                .ToList();
            return new ArticlesResponse(articles, articlesResponseDto.ArticlesCount);
        }
    }
}