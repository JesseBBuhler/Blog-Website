function PostComponent(props) {
  if (props.type === "h1") {
    return <h1>{props.content}</h1>;
  } else if (props.type === "h2") {
    return <h2>{props.content}</h2>;
  } else if (props.type === "h3") {
    return <h3>{props.content}</h3>;
  } else if (props.type === "h4") {
    return <h4>{props.content}</h4>;
  } else if (props.type === "h5") {
    return <h5>{props.content}</h5>;
  } else if (props.type === "img") {
    return <img alt={props.content} />;
  } else {
    return <p>{props.content}</p>;
  }
}

export default PostComponent;
