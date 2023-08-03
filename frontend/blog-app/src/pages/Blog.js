import React, { useState } from "react";
import PostBody from "../components/PostBody";
import "./Blog.css";
function Blog() {
  const [postText, setPostText] = useState("Blog post will appear here");
  const [postTitle, setPostTitle] = useState("Welcome to the Post Page");
  const getPost = (postNum) => {
    fetch(`https://localhost:7288/api/Posts/${postNum}`)
      .then((response) => response.json())
      .then((data) => {
        setPostText(data.postText);
        setPostTitle(data.postTitle);
      })
      .catch((error) => console.error(error));
  };
  return (
    <div className="pageContainer">
      <div className="buttonContainer">
        <button onClick={() => getPost(0)}>Post 1</button>
        <button onClick={() => getPost(1)}>Post 2</button>
        <button onClick={() => getPost(2)}>Post 3</button>
      </div>
      <div className="postContainer">
        <h1 className="postTitle">{postTitle}</h1>
        <PostBody content={postText}></PostBody>
      </div>
    </div>
  );
}

export default Blog;
