import React, { useState } from "react";
function Blog() {
  const [postText, setPostText] = useState("Blog post will appear here");
  const [postTitle, setPostTitle] = useState("Welcome to the Post Page");
  const getPost = () => {
    fetch("https://localhost:7288/api/Posts/2")
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
      <p>{postText}</p>
    </div>
  );
}

export default Blog;
