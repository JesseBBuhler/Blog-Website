function breakOutImg(content) {
  let returnObject = { remaining: "", src: "", alt: "" };

  returnObject.remaining = content.substring(content.indexOf("]") + 1);
  returnObject.src = content.substring(
    content.indexOf("[") + 1,
    content.indexOf("|")
  );
  returnObject.alt = content.substring(
    content.indexOf("|") + 1,
    content.indexOf("]")
  );

  return returnObject;
}

export default breakOutImg;
