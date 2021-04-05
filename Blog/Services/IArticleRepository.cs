﻿using System;
using System.Collections.Generic;
using Blog.Models;

namespace Blog.Services
{
    public interface IArticleRepository
    {
        IEnumerable<Article> GetArticles();

        Article GetArticle(Guid articleId);

        bool ArticleExists(Guid articleId);

        List<ArticlePicture> GetPicturesByArticleId(Guid articleId);
    }
}
