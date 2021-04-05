﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Blog.Dtos;
using Blog.Models;
using Blog.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Blog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticlesController : ControllerBase
    {
        private IArticleRepository _articleRepository;
        private readonly IMapper _mapper;

        public ArticlesController(IArticleRepository articleRepository, IMapper mapper)
        {
            _articleRepository = articleRepository;
            _mapper = mapper;
        }


        [HttpGet]
        public IActionResult GetArticles()
        {
            var articlesFromRepo = _articleRepository.GetArticles();
            if(articlesFromRepo == null || articlesFromRepo.Count() < 0)
            {
                return NotFound("No Article Found");
            }
            var articles = _mapper.Map<IEnumerable<ArticleDto>>(articlesFromRepo);
            return Ok(articles);
        }

        [HttpGet("{articleId}")]
        public IActionResult GetArticle(Guid articleId)
        {
            Article articleFromRepo = _articleRepository.GetArticle(articleId);
            if(articleFromRepo == null)
            {
                return NotFound("No Article Found");
            }

            var articleDto = _mapper.Map<ArticleDto>(articleFromRepo);
            return Ok(articleDto);
        }
    }
}