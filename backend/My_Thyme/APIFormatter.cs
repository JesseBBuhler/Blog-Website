using Microsoft.EntityFrameworkCore;
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


            for (int i = 0; i < model.Tags.Count; i++)
            {
                var tag = _context.Tags.FirstOrDefault(tag => tag.TagName == model.Tags[i]);
                
                if(tag is null)
                {
                    tag = new Tag();
                    tag.TagName = model.Tags[i];
                    _context.Tags.Add(tag);
                }

                returnPost.Content.Tags.Add(tag);
                
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
            postToEdit.Tags.Clear();

            for (int i = 0; i < model.Tags.Count; i++)
            {
                var tag = _context.Tags.FirstOrDefault(tag => tag.TagName == model.Tags[i]);

                if (tag is null)
                {
                    tag = new Tag();
                    tag.TagName = model.Tags[i];
                    _context.Tags.Add(tag);
                }

                postToEdit.Tags.Add(tag);

            }

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

            long averageRating = sumRating / (ratings.Count != 0 ? ratings.Count : 1); // prevent divide by zero

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

        public (bool success, string error) CreateRPAssociation(long recipeID, long postID)
        {
            (bool success, string error) returnTuple = (false, string.Empty);

            var post = _context.Posts.Find(postID);
            var recipe = _context.Recipes.Find(recipeID);

            

            if (post == null)
            {
                returnTuple.error += $"Post with id of ${postID} could not be found.\n";
            }

            if (recipe == null)
            {
                returnTuple.error += $"Recipe with id of ${recipeID} could not be found.\n";
            }

            if (post != null && recipe != null)
            {
                var existingPost = recipe.Posts.FirstOrDefault(p => p.PostId == post.PostId);
                if (existingPost != null)
                {
                    
                     returnTuple.error += $"post-{postID} and recipe-{recipeID} already associated.";
                        
                }
                else
                {
                    recipe.Posts.Add(post);
                    _context.SaveChanges();
                    returnTuple.success = true;
                }
                
                
            }         


            return returnTuple;
        }

        public (bool success, string error) DeleteRPAssociation(long recipeID, long postID)
        {
            (bool success, string error) returnTuple = (false, string.Empty);
            var post = _context.Posts.Find(postID);
            var recipe = _context.Recipes
                .Include(r => r.Posts)
                .FirstOrDefault(r => r.RecipeId == recipeID);

            if (post == null)
            {
                returnTuple.error += $"Post with id of ${postID} could not be found.\n";
            }

            if (recipe == null)
            {
                returnTuple.error += $"Recipe with id of ${recipeID} could not be found.\n";
            }

            if (post != null && recipe != null)
            {
                var existingPost = recipe.Posts.FirstOrDefault(p => p.PostId == post.PostId);
                if (existingPost != null)
                {
                    
                    recipe.Posts.Remove(existingPost);
                    _context.SaveChanges();
                    returnTuple.success = true;
                }
                else
                {
                    returnTuple.error += $"post-{postID} and recipe-{recipeID} are not associated.";
                }
                

            }


            return returnTuple;
        }

        public List<Tag> GetTags()
        {
            List<Tag> tags = _context.Tags.ToList();

            return tags;
        }

        public (Tag tag, String error) GetTag(long id)
        {
            (Tag tag, String error) returnTuple = (new Tag(), string.Empty);
            var tag = _context.Tags.Find(id);

            if (tag != null)
            {
                returnTuple.tag = tag;
            }
            else
            {
                returnTuple.error = $"Tag with id-{id} could not be found.";
            }

            return returnTuple;
        }

        public (bool success, string error) DeleteTag(long id)
        {
            (bool success, String error) returnTuple = (false,  string.Empty);

            var tag = _context.Tags.FirstOrDefault(t => t.TagId == id);
            if (tag != null)
            {
                 var posts = _context.Posts
                .Include(p => p.Tags)
                .Where(post => _context.Tags
                .Where(tag => tag.TagId == id)
                .Any(tag => tag.Posts.Any(postTag => postTag.PostId == post.PostId)))
                .ToList();

                for(int i = 0; i < posts.Count; i++)
                {
                    posts[i].Tags.Remove(tag);
                }

                _context.Tags.Remove(tag);
                _context.SaveChanges();
                returnTuple.success = true;
            }
            else 
            {
                returnTuple.error = $"Tag with id-{id} could not be found.";
            }

            return returnTuple;
        }

    }
}
