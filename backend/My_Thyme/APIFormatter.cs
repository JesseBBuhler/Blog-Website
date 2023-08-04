using My_Thyme.APIObjects;
using My_Thyme.Models;
using My_Thyme.returnObjects;
using SQLitePCL;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace My_Thyme
{
    public class APIFormatter
    {
        private MythymeContext _context;
        public APIFormatter(MythymeContext context)
        {
            _context = context;
        }

        public getPost GetPost(int id)
        {
            getPost returnPost = new getPost();

            var post = _context.Posts.Where(x => x.PostId == id).FirstOrDefault();

            var recipes = _context.Recipes
            .Where(recipe => _context.Posts
            .Where(post => post.PostId == id)
            .Any(post => post.Recipes.Any(postRecipe => postRecipe.RecipeId == recipe.RecipeId)))
            .ToList();

            var tags = _context.Tags
            .Where(tag => _context.Posts
            .Where(post => post.PostId == id)
            .Any(post => post.Tags.Any(postTag => postTag.TagId == tag.TagId)))
            .ToList();

            var author = _context.Users.Where(x => x.UserId == post.AuthorId).FirstOrDefault();

            var recipesSummary = new Dictionary<long, string>();

            for (int i = 0; i < recipes.Count; i++)
            {
                recipesSummary.Add(recipes[i].RecipeId, recipes[i].Title);
            }

            var tagList = new List<string>();
            for (int i = 0; i < tags.Count; i++)
            {
                tagList.Add(tags[i].TagName);
            }

            returnPost.postId = post.PostId;
            returnPost.authorName = author?.UserName;
            returnPost.publishDate = post?.PublishDate;
            returnPost.postTitle = post?.PostTitle;
            returnPost.recipes = recipesSummary;
            returnPost.tags = tagList;
            returnPost.postText = post?.PostText;
           

            return returnPost;
        }

        public List<getPost> GetPosts()
        {
            List<getPost> postsObject = new List<getPost>();
            for (int i = 0; i < _context.Posts.ToList().Count; i++)
            {
                postsObject.Add(GetPost(i));
            }
            return postsObject;
        }

        public Post PostPost(postPost model)
        {
            User author = _context.Users.Single(x => x.UserId == model.AuthorId);

            Post newPost = new Post();
            newPost.AuthorId = model.AuthorId;
            newPost.Author = author;
            newPost.PostText = model.PostText;
            newPost.PublishDate = model.PublishDate;
            newPost.PostTitle = model.PostTitle;
            newPost.CoverImg = model.CoverImg;

            _context.Posts.Add(newPost);
            _context.SaveChanges();

            return newPost;
        }

        public getRecipe GetRecipe(int id)
        {
            getRecipe returnRecipe = new getRecipe();

            var recipe = _context.Recipes.Where(x => x.RecipeId == id).FirstOrDefault();

            var posts = _context.Posts
            .Where(post => _context.Recipes
            .Where(recipe => recipe.RecipeId == id)
            .Any(recipe => recipe.Posts.Any(postRecipe => postRecipe.PostId == post.PostId)))
            .ToList();

            var tags = _context.Tags
            .Where(tag => _context.Recipes
            .Where(recipe => recipe.RecipeId == id)
            .Any(recipe => recipe.Tags.Any(recipeTag => recipeTag.TagId == tag.TagId)))
            .ToList();

            var author = _context.Users.Where(x => x.UserId == recipe.AuthorId).FirstOrDefault();

            var postSummary = new Dictionary<long, string>();

            for (int i = 0; i < posts.Count; i++)
            {
                postSummary.Add(posts[i].PostId, posts[i].PostTitle);
            }

            var tagList = new List<string>();
            for (int i = 0; i < tags.Count; i++)
            {
                tagList.Add(tags[i].TagName);
            }

            var ratings = _context.Ratings.Where(x => x.RecipeId == id).ToList();
            long sumRating = 0;
            for (int i = 0; i < ratings.Count; i++)
            {
                sumRating += ratings[i].Rating1;
            }

            long averageRating = sumRating / ratings.Count;


            returnRecipe.recipeId = recipe.RecipeId;
            returnRecipe.cuisine = recipe.Cuisine;
            returnRecipe.prepTime = recipe.PrepTime;
            returnRecipe.cookTime = recipe.CookTime;
            returnRecipe.servings = recipe.Servings;
            returnRecipe.author = author.UserName;
            returnRecipe.ingredients = recipe.Ingredients;
            returnRecipe.instructions = recipe.Instructions;
            returnRecipe.title = recipe.Title;
            returnRecipe.rating = averageRating;
            returnRecipe.posts = postSummary;
            returnRecipe.tags = tagList;


            return returnRecipe;
        }

        public List<getRecipe> GetRecipes()
        {
            var recipesObject = new List<getRecipe>();
            for (int i = 0; i < _context.Recipes.ToList().Count; i++)
            {
                recipesObject.Add(GetRecipe(i));
            }
            return recipesObject;
        }
        
        
    }
}
