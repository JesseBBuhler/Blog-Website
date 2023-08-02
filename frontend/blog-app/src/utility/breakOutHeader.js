function breakOutHeader(content) {
  let returnObject = { remaining: "", headerLevel: "", header: "" };
  let headerLevel = 1;
  let endIndex = content.indexOf("\n");

  if (content[1] !== "#") {
    headerLevel = 1;
  } else if (content[2] !== "#") {
    headerLevel = 2;
  } else if (content[3] !== "#") {
    headerLevel = 3;
  } else if (content[4] !== "#") {
    headerLevel = 4;
  } else {
    headerLevel = 5;
  }

  returnObject.remaining = content.substring(endIndex);
  returnObject.headerLevel = `h${headerLevel}`;
  returnObject.header = content.substring(headerLevel, endIndex);

  return returnObject;
}

export default breakOutHeader;
