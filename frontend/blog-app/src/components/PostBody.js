import PostComponent from "./PostComponent";
import postParser from "../utility/postParser";
function PostBody(props) {
  const listItems = postParser(props.content);
  const componentList = listItems.map((item, index) => (
    <PostComponent
      key={index}
      type={item.type}
      content={item.content}
    ></PostComponent>
  ));

  return componentList;
}

export default PostBody;
