using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace My_Thyme.Models;

public partial class MythymeContext : DbContext
{
    public MythymeContext()
    {
    }

    public MythymeContext(DbContextOptions<MythymeContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Comment> Comments { get; set; }

    public virtual DbSet<Post> Posts { get; set; }

    public virtual DbSet<Rating> Ratings { get; set; }

    public virtual DbSet<Recipe> Recipes { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Tag> Tags { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlite("Data Source=mythyme.sqlite");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Comment>(entity =>
        {
            entity.ToTable("comments");

            entity.HasIndex(e => e.CommentId, "IX_comments_comment_id").IsUnique();

            entity.Property(e => e.CommentId).HasColumnName("comment_id");
            entity.Property(e => e.CommentText).HasColumnName("comment_text");
            entity.Property(e => e.Edited).HasColumnName("edited");
            entity.Property(e => e.PostId).HasColumnName("post_id");
            entity.Property(e => e.PublishDate).HasColumnName("publish_date");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Post).WithMany(p => p.Comments)
                .HasForeignKey(d => d.PostId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.User).WithMany(p => p.Comments)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasMany(d => d.Originals).WithMany(p => p.Replies)
                .UsingEntity<Dictionary<string, object>>(
                    "Reply",
                    r => r.HasOne<Comment>().WithMany()
                        .HasForeignKey("OriginalId")
                        .OnDelete(DeleteBehavior.ClientSetNull),
                    l => l.HasOne<Comment>().WithMany()
                        .HasForeignKey("ReplyId")
                        .OnDelete(DeleteBehavior.ClientSetNull),
                    j =>
                    {
                        j.HasKey("OriginalId", "ReplyId");
                        j.ToTable("replies");
                        j.IndexerProperty<long>("OriginalId").HasColumnName("original_id");
                        j.IndexerProperty<long>("ReplyId").HasColumnName("reply_id");
                    });

            entity.HasMany(d => d.Replies).WithMany(p => p.Originals)
                .UsingEntity<Dictionary<string, object>>(
                    "Reply",
                    r => r.HasOne<Comment>().WithMany()
                        .HasForeignKey("ReplyId")
                        .OnDelete(DeleteBehavior.ClientSetNull),
                    l => l.HasOne<Comment>().WithMany()
                        .HasForeignKey("OriginalId")
                        .OnDelete(DeleteBehavior.ClientSetNull),
                    j =>
                    {
                        j.HasKey("OriginalId", "ReplyId");
                        j.ToTable("replies");
                        j.IndexerProperty<long>("OriginalId").HasColumnName("original_id");
                        j.IndexerProperty<long>("ReplyId").HasColumnName("reply_id");
                    });
        });

        modelBuilder.Entity<Post>(entity =>
        {
            entity.ToTable("posts");

            entity.HasIndex(e => e.PostId, "IX_posts_post_id").IsUnique();

            entity.Property(e => e.PostId).HasColumnName("post_id");
            entity.Property(e => e.AuthorId).HasColumnName("author_id");
            entity.Property(e => e.PostText).HasColumnName("post_text");
            entity.Property(e => e.PostTitle).HasColumnName("post_title");
            entity.Property(e => e.PublishDate).HasColumnName("publish_date");

            entity.HasOne(d => d.Author).WithMany(p => p.Posts)
                .HasForeignKey(d => d.AuthorId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasMany(d => d.Tags).WithMany(p => p.Posts)
                .UsingEntity<Dictionary<string, object>>(
                    "PostTag",
                    r => r.HasOne<Tag>().WithMany()
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.ClientSetNull),
                    l => l.HasOne<Post>().WithMany()
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.ClientSetNull),
                    j =>
                    {
                        j.HasKey("PostId", "TagId");
                        j.ToTable("post_tags");
                        j.IndexerProperty<long>("PostId").HasColumnName("post_id");
                        j.IndexerProperty<long>("TagId").HasColumnName("tag_id");
                    });
        });

        modelBuilder.Entity<Rating>(entity =>
        {
            entity.HasKey(e => new { e.RecipeId, e.UserId });

            entity.ToTable("ratings");

            entity.Property(e => e.RecipeId).HasColumnName("recipe_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.Rating1).HasColumnName("rating");

            entity.HasOne(d => d.Recipe).WithMany(p => p.Ratings)
                .HasForeignKey(d => d.RecipeId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.User).WithMany(p => p.Ratings)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Recipe>(entity =>
        {
            entity.ToTable("recipes");

            entity.HasIndex(e => e.RecipeId, "IX_recipes_recipe_id").IsUnique();

            entity.Property(e => e.RecipeId).HasColumnName("recipe_id");
            entity.Property(e => e.AuthorId).HasColumnName("author_id");
            entity.Property(e => e.CookTime).HasColumnName("cook_time");
            entity.Property(e => e.Cuisine).HasColumnName("cuisine");
            entity.Property(e => e.Ingredients).HasColumnName("ingredients");
            entity.Property(e => e.Instructions).HasColumnName("instructions");
            entity.Property(e => e.PrepTime).HasColumnName("prep_time");
            entity.Property(e => e.Servings).HasColumnName("servings");

            entity.HasOne(d => d.Author).WithMany(p => p.Recipes)
                .HasForeignKey(d => d.AuthorId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasMany(d => d.Posts).WithMany(p => p.Recipes)
                .UsingEntity<Dictionary<string, object>>(
                    "PostRecipe",
                    r => r.HasOne<Post>().WithMany()
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.ClientSetNull),
                    l => l.HasOne<Recipe>().WithMany()
                        .HasForeignKey("RecipeId")
                        .OnDelete(DeleteBehavior.ClientSetNull),
                    j =>
                    {
                        j.HasKey("RecipeId", "PostId");
                        j.ToTable("post_recipes");
                        j.IndexerProperty<long>("RecipeId").HasColumnName("recipe_id");
                        j.IndexerProperty<long>("PostId").HasColumnName("post_id");
                    });

            entity.HasMany(d => d.Tags).WithMany(p => p.Recipes)
                .UsingEntity<Dictionary<string, object>>(
                    "RecipeTag",
                    r => r.HasOne<Tag>().WithMany()
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.ClientSetNull),
                    l => l.HasOne<Recipe>().WithMany()
                        .HasForeignKey("RecipeId")
                        .OnDelete(DeleteBehavior.ClientSetNull),
                    j =>
                    {
                        j.HasKey("RecipeId", "TagId");
                        j.ToTable("recipe_tags");
                        j.IndexerProperty<long>("RecipeId").HasColumnName("recipe_id");
                        j.IndexerProperty<long>("TagId").HasColumnName("tag_id");
                    });
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.ToTable("roles");

            entity.HasIndex(e => e.RoleId, "IX_roles_role_id").IsUnique();

            entity.HasIndex(e => e.RoleName, "IX_roles_role_name").IsUnique();

            entity.Property(e => e.RoleId).HasColumnName("role_id");
            entity.Property(e => e.RoleName).HasColumnName("role_name");
        });

        modelBuilder.Entity<Tag>(entity =>
        {
            entity.ToTable("tags");

            entity.HasIndex(e => e.TagId, "IX_tags_tag_id").IsUnique();

            entity.HasIndex(e => e.TagName, "IX_tags_tag_name").IsUnique();

            entity.Property(e => e.TagId).HasColumnName("tag_id");
            entity.Property(e => e.TagName).HasColumnName("tag_name");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("users");

            entity.HasIndex(e => e.UserId, "IX_users_user_id").IsUnique();

            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.Email).HasColumnName("email");
            entity.Property(e => e.Password).HasColumnName("password");
            entity.Property(e => e.RoleId).HasColumnName("role_id");
            entity.Property(e => e.SignUpDate).HasColumnName("sign_up_date");
            entity.Property(e => e.UserName).HasColumnName("user_name");
            entity.Property(e => e.UserStanding).HasColumnName("user_standing");

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
