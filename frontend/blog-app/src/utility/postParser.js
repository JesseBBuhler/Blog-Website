import breakOutHeader from "./breakOutHeader";

function postParser(content) {
  let contentString = content;
  const contentItems = [];

  while (contentString.length > 0) {
    let breakIndex = contentString.indexOf("#");
    if (breakIndex === -1) {
      contentItems.push({
        type: "p",
        content: contentString,
      });
      return contentItems;
    }

    if (breakIndex !== 0) {
      contentItems.push({
        type: "p",
        content: contentString.substring(0, breakIndex),
      });
      contentString = contentString.substring(breakIndex);
    }

    let headingBreakdown = breakOutHeader(contentString);

    contentString = headingBreakdown.remaining;
    contentItems.push({
      type: headingBreakdown.headerLevel,
      content: headingBreakdown.header,
    });
  }

  return contentItems;
}

export default postParser;
