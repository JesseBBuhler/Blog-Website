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

        public (string Error, getPost Content) GetPost(long id)
        {
            (string Error, getPost Content) returnTuple = (string.Empty, new getPost());

            Post? post = _context.Posts.FirstOrDefault(x => x.PostId == id);
            if (post == null)
            {
                returnTuple.Error = "Record not found";
                               
                return returnTuple;
            }

            List<long> recipes = _context.Recipes
            .Where(recipe => _context.Posts
            .Where(post => post.PostId == id)
            .Any(post => post.Recipes.Any(postRecipe => postRecipe.RecipeId == recipe.RecipeId)))
            .Select( recipe => recipe.RecipeId)
            .ToList();

            List<long> tags = _context.Tags
            .Where(tag => _context.Posts
            .Where(post => post.PostId == id)
            .Any(post => post.Tags.Any(postTag => postTag.TagId == tag.TagId)))
            .Select(tag => tag.TagId)
            .ToList();

            returnTuple.Content.post = post;
            returnTuple.Content.recipes = recipes;
            returnTuple.Content.tags = tags;

            return returnTuple;
        }

        public List<getPost> GetPosts()
        {
            List<getPost> postsObject = new List<getPost>();
            List<Post> posts = _context.Posts.ToList();
            for (int i = 0; i < posts.Count; i++)
            {
                postsObject.Add(GetPost(posts[i].PostId).Content);
            }

            return postsObject;
        }

        public (string Error, Post Content) PostPost(postPost model)
        {
            (string Error, Post Content) returnPost = (string.Empty, new Post());

            User author = _context.Users.Single(x => x.UserId == model.AuthorId);

            if(author is null)
            {
                returnPost.Error = $"Author with id {model.AuthorId} is not found.";
                return returnPost;
            }

            
            returnPost.Content.AuthorId = model.AuthorId;
            returnPost.Content.Author = author;
            returnPost.Content.PostText = model.PostText;
            returnPost.Content.PublishDate = model.PublishDate;
            returnPost.Content.PostTitle = model.PostTitle;
            returnPost.Content.CoverImg = model.CoverImg;

            _context.Posts.Add(returnPost.Content);
            _context.SaveChanges();

            return returnPost;
        }

        public (string Error, Post Content) EditPost(int id, postPost model)
        {
            string error = string.Empty;

            User author = _context.Users.Single(x => x.UserId == model.AuthorId);

            Post postToEdit = _context.Posts.Single(x=> x.PostId == id);
            postToEdit.AuthorId = model.AuthorId;
            postToEdit.Author = author;
            postToEdit.PostText = model.PostText;
            postToEdit.PublishDate = model.PublishDate;
            postToEdit.PostTitle = model.PostTitle;
            postToEdit.CoverImg = model.CoverImg;

            _context.SaveChanges();

            (string Error, Post Content) returnPost = (error, postToEdit);

            return returnPost;
        }

        public bool DeletePost(int id)
        {
            var recordToDelete = _context.Posts.FirstOrDefault(e => e.PostId == id);
            if (recordToDelete != null)
            {
                _context.Posts.Remove(recordToDelete);
                _context.SaveChanges();
                return true;
            }
            else { return false; }
        }

        public (string Error, getRecipe Content) GetRecipe(long id)
        {
            (string Error, getRecipe Content) returnTuple = (string.Empty, new getRecipe());
        
            Recipe recipe = _context.Recipes.FirstOrDefault(x => x.RecipeId == id) ?? new Recipe();

            if (recipe.RecipeId != id) {
                returnTuple.Error = $"Recipe with ID {id} could not be found";
                return returnTuple;
            }

            List<long> posts = _context.Posts
            .Where(post => _context.Recipes
            .Where(recipe => recipe.RecipeId == id)
            .Any(recipe => recipe.Posts.Any(postRecipe => postRecipe.PostId == post.PostId)))
            .Select(post => post.PostId)
            .ToList();

            List<long> tags = _context.Tags
            .Where(tag => _context.Recipes
            .Where(recipe => recipe.RecipeId == id)
            .Any(recipe => recipe.Tags.Any(recipeTag => recipeTag.TagId == tag.TagId)))
            .Select(tag => tag.TagId)
            .ToList();

            var ratings = _context.Ratings.Where(x => x.RecipeId == id).ToList();
            long sumRating = 0;
            for (int i = 0; i < ratings.Count; i++)
            {
                sumRating += ratings[i].Rating1;
            }

            long averageRating = sumRating / ratings.Count;

            returnTuple.Content.recipe = recipe;
            returnTuple.Content.tags = tags;
            returnTuple.Content.posts = posts;
            returnTuple.Content.rating = averageRating;            

            return returnTuple;
        }

        public List<getRecipe> GetRecipes()
        {
            List<getRecipe> recipesObject = new List<getRecipe>();
            List<Recipe> recipes = _context.Recipes.ToList();

            for (int i = 0; i < recipes.Count; i++)
            {
                recipesObject.Add(GetRecipe(recipes[i].RecipeId).Content);
            }
            return recipesObject;
        }

        public (string Error, Recipe Content) PostRecipe(postRecipe model)
        {
            (string Error, Recipe Content) returnRecipe = (string.Empty, new Recipe());

            User author = _context.Users.Single(x => x.UserId == model.AuthorId);

            if (author is null)
            {
                returnRecipe.Error = $"Author with id {model.AuthorId} is not found.";
               
                return returnRecipe;
            }

            returnRecipe.Content.Cuisine = model.Cuisine;
            returnRecipe.Content.PrepTime = model.PrepTime;
            returnRecipe.Content.CookTime = model.CookTime;
            returnRecipe.Content.Servings = model.Servings;
            returnRecipe.Content.AuthorId = model.AuthorId;
            returnRecipe.Content.Author = author;
            returnRecipe.Content.Ingredients = model.Ingredients;
            returnRecipe.Content.Instructions = model.Instructions;
            returnRecipe.Content.Title = model.Title;

            _context.Recipes.Add(returnRecipe.Content);
            _context.SaveChanges();

            return returnRecipe;
        }


        public (string Error, Recipe Content) EditRecipe(int id, postRecipe model)
        {
            (string Error, Recipe Content) returnRecipe = (string.Empty, new Recipe());

            User author = _context.Users.Single(x => x.UserId == model.AuthorId);

            if (author is null)
            {
                returnRecipe.Error = $"Author with id {model.AuthorId} is not found.";

                return returnRecipe;
            }

            returnRecipe.Content.Cuisine = model.Cuisine;
            returnRecipe.Content.PrepTime = model.PrepTime;
            returnRecipe.Content.CookTime = model.CookTime;
            returnRecipe.Content.Servings = model.Servings;
            returnRecipe.Content.AuthorId = model.AuthorId;
            returnRecipe.Content.Author = author;
            returnRecipe.Content.Ingredients = model.Ingredients;
            returnRecipe.Content.Instructions = model.Instructions;
            returnRecipe.Content.Title = model.Title;

            _context.SaveChanges();

            return returnRecipe;
        }


        public bool DeleteRecipe(int id)
        {
            var recordToDelete = _context.Recipes.FirstOrDefault(e => e.RecipeId == id);
            if (recordToDelete != null)
            {
                _context.Recipes.Remove(recordToDelete);
                _context.SaveChanges();
                return true;
            }
            else { return false; }
        }

    }
}
