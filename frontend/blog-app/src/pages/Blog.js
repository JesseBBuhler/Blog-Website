import React, { useState } from "react";
import PostBody from "../components/PostBody";
function Blog() {
  const [postText, setPostText] = useState("Blog post will appear here");
  const [postTitle, setPostTitle] = useState("Welcome to the Post Page");
  const getPost = () => {
    fetch("https://localhost:7288/api/Posts/0")
      .then((response) => response.json())
      .then((data) => {
        setPostText(data.postText);
        setPostTitle(data.postTitle);
      })
      .catch((error) => console.error(error));
  };
  return (
    <div>
      <button onClick={getPost}>Get Post</button>
      <h1>{postTitle}</h1>
      <PostBody content={postText}></PostBody>
    </div>
  );
}

export default Blog;
