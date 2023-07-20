CREATE TABLE "roles" (
	"role_id" INTEGER NOT NULL UNIQUE,
	"role_name" INTEGER NOT NULL UNIQUE,
	PRIMARY KEY("role_id" AUTOINCREMENT)
);

CREATE TABLE "users" (
    "user_id"       INTEGER NOT NULL UNIQUE,
    "role_id"       INTEGER NOT NULL,
    "user_name"     TEXT NOT NULL,
    "sign_up_date"  TEXT NOT NULL,
    "password"      TEXT NOT NULL,
    "email"         TEXT NOT NULL,
    "user_standing" TEXT NOT NULL,
    PRIMARY KEY("user_id" AUTOINCREMENT),
    FOREIGN KEY("role_id") REFERENCES "roles"("role_id")
);

CREATE TABLE "posts" (
	"post_id" INTEGER NOT NULL UNIQUE,
	"post_title" TEXT NOT NULL,
	"author_id" INTEGER NOT NULL,
	"post_text" TEXT,
	"publish_date" TEXT NOT NULL,
	PRIMARY KEY("post_id" AUTOINCREMENT),
	FOREIGN KEY("author_id") REFERENCES "users"("user_id")
);

CREATE TABLE "tags" (
	"tag_id" INTEGER NOT NULL UNIQUE,
	"tag_name" TEXT NOT NULL UNIQUE,
	PRIMARY KEY("tag_id" AUTOINCREMENT)
);

CREATE TABLE "post_tags" (
	"post_id" INTEGER NOT NULL,
	"tag_id" INTEGER NOT NULL,
	PRIMARY KEY("post_id", "tag_id"),
	FOREIGN KEY("post_id") REFERENCES "posts"("post_id"),
	FOREIGN KEY("tag_id") REFERENCES "tags"("tag_id")
);

CREATE TABLE "recipes" (
	"recipe_id" INTEGER NOT NULL UNIQUE,
	"cuisine" TEXT,
	"prep_time" INTEGER,
	"cook_time" INTEGER,
	"servings" REAL,
	"author_id" INTEGER NOT NULL,
	"ingredients" TEXT,
	"instructions" TEXT,
	PRIMARY KEY("recipe_id" AUTOINCREMENT),
	FOREIGN KEY("author_id") REFERENCES "users"("user_id")
);

CREATE TABLE "ratings" (
	"recipe_id" INTEGER NOT NULL,
	"user_id" INTEGER NOT NULL,
	"rating" INTEGER NOT NULL,
	PRIMARY KEY("recipe_id", "user_id"),
	FOREIGN KEY("recipe_id") REFERENCES "recipes"("recipe_id"),
	FOREIGN KEY("user_id") REFERENCES "users"("user_id")
);

CREATE TABLE "recipe_tags" (
	"recipe_id" INTEGER NOT NULL,
	"tag_id" INTEGER NOT NULL,
	PRIMARY KEY("recipe_id", "tag_id"),
	FOREIGN KEY("recipe_id") REFERENCES "recipes"("recipe_id"),
	FOREIGN KEY("tag_id") REFERENCES "tags"("tag_id")
);

CREATE TABLE "post_recipes" (
	"recipe_id" INTEGER NOT NULL,
	"post_id" INTEGER NOT NULL,
	PRIMARY KEY("recipe_id", "post_id"),
	FOREIGN KEY("recipe_id") REFERENCES "recipes"("recipe_id"),
	FOREIGN KEY("post_id") REFERENCES "posts"("post_id")
);

CREATE TABLE "comments" (
	"comment_id" INTEGER NOT NULL UNIQUE,
	"post_id" INTEGER NOT NULL,
	"user_id" INTEGER NOT NULL,
	"comment_text" TEXT,
	"publish_date" TEXT NOT NULL,
	"edited" INTEGER CHECK ("edited" IN (0, 1)),
	PRIMARY KEY("comment_id" AUTOINCREMENT),
	FOREIGN KEY("post_id") REFERENCES "posts"("post_id"),
	FOREIGN KEY("user_id") REFERENCES "users"("user_id")
);

CREATE TABLE "replies" (
	"original_id" INTEGER NOT NULL,
	"reply_id" INTEGER NOT NULL,
	PRIMARY KEY("original_id", "reply_id"),
	FOREIGN KEY("original_id") REFERENCES "comments"("comment_id"),
	FOREIGN KEY("reply_id") REFERENCES "comments"("comment_id")
);
