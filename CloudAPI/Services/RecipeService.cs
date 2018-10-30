using CloudAPI.ApplicationCore.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;
using CloudAPI.Models.Entities;
using CloudAPI.ViewModels;
using AutoMapper;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace CloudAPI.ApplicationCore.Services
{
    public class RecipeService : IRecipeService
    {
        public IMapper mapper;
        private readonly IAsyncRepository<Recipe> _recipeRepository;
        private readonly IAsyncRepository<RecipeRating> _recipeRatingRepository;
        private readonly IAsyncRepository<RecipeLike> _recipeLikeRepository;
        private readonly IAsyncRepository<RecipeComment> _recipeCommentRepository;

        public RecipeService(IAsyncRepository<Recipe> recipeRepository, 
            IAsyncRepository<RecipeRating> recipeRatingRepository, 
            IAsyncRepository<RecipeLike> recipeLikeRepository, 
            IAsyncRepository<RecipeComment> recipeCommentRepository)
        {
            _recipeRepository = recipeRepository;
            _recipeRatingRepository = recipeRatingRepository;
            _recipeLikeRepository = recipeLikeRepository;
            _recipeCommentRepository = recipeCommentRepository;

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Recipe, RecipeViewModel>();
                cfg.CreateMap<RecipeViewModel, Recipe>();

            });
            mapper = config.CreateMapper();
        }

        public async Task<List<RecipeViewModel>> GetRecipes()
        {
            var recipe = await _recipeRepository.ListAllAsync();
            List<RecipeViewModel> recipeView = mapper.Map<List<Recipe>, List<RecipeViewModel>>(recipe);
            foreach (var recipieItem in recipeView)
            {
                recipieItem.Rating = GetRatingCount(recipieItem.Id);
                recipieItem.LikeCount = GetLikeCount(recipieItem.Id);
                recipieItem.isLiked = GetIsLike(recipieItem.Id, recipieItem.UserId);
            }

            return recipeView;
        }

        public async Task<RecipeViewModel> GetRecipeById(int Id)
        {
            var recipe = await _recipeRepository.GetByIdAsync(Id);
            RecipeViewModel recipeView = mapper.Map<Recipe, RecipeViewModel>(recipe);
            recipeView.Comments = GetComments(recipeView.Id);
            recipeView.Rating = GetRatingCount(recipeView.Id);
            recipeView.LikeCount = GetLikeCount(recipeView.Id);
            recipeView.isLiked = GetIsLike(recipeView.Id, recipeView.UserId);
            return recipeView;
        }

        private List<RecipeComment> GetComments(int recipeId)
        {
            var comments = _recipeCommentRepository.ListAllAsync().Result.Where(r => r.RecipeId == recipeId).OrderByDescending(r=> r.Id).ToList();
            
            return comments;
        }

        private int GetRatingCount(int recipeId)
        {
            var ratings = _recipeRatingRepository.ListAllAsync().Result.Where(r => r.RecipeId == recipeId);
            int count = ratings.Count();
            int sum = ratings.Sum(r => r.Rating);
            int result = count ==0 ? 0 : sum/count;

            return result;
        }

        private int GetLikeCount(int recipeId)
        {
            var likes = _recipeLikeRepository.ListAllAsync().Result.Where(r => r.RecipeId == recipeId && r.IsLiked);
            int count = likes.Count();

            return count;
        }

        private bool GetIsLike(int recipeId, string UserId)
        {
            var likes = _recipeLikeRepository.ListAllAsync().Result.Where(r => r.RecipeId == recipeId && r.UserId == UserId).FirstOrDefault();
            bool result = likes == null ? false : likes.IsLiked;
            return result;
        }

        public async Task<RecipeViewModel> AddRecipe(RecipeViewModel recipeView)
        {
            Recipe recipe = mapper.Map<RecipeViewModel, Recipe>(recipeView);
            var response = await _recipeRepository.AddAsync(recipe);
            RecipeViewModel recipeVM = mapper.Map<Recipe, RecipeViewModel>(recipe);
            return recipeVM;
        }

        public async Task<RecipeRating> AddRating(RecipeRating rating)
        {
            return await _recipeRatingRepository.AddAsync(rating);
        }

        public async Task<RecipeLike> AddLike(RecipeLike like)
        {
            return await _recipeLikeRepository.AddAsync(like);
        }

        public async Task<RecipeComment> AddComment(RecipeComment comment)
        {
            return await _recipeCommentRepository.AddAsync(comment);
        }
    }
}
