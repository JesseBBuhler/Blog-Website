import breakOutHeader from "./breakOutHeader";
import breakOutImg from "./breakOutImg";

function postParser(content) {
  let contentString = content;
  const contentItems = [];

  while (contentString.length > 0) {
    let headerIndex = contentString.indexOf("#");
    let imgIndex = contentString.indexOf("![");
    let breakIndex = 0;

    if (headerIndex === -1 && imgIndex === -1) {
      contentItems.push({
        type: "p",
        content: contentString,
      });
      return contentItems;
    }

    if ((headerIndex < imgIndex && headerIndex !== -1) || imgIndex === -1) {
      breakIndex = headerIndex;
    } else {
      breakIndex = imgIndex;
    }

    if (breakIndex !== 0) {
      contentItems.push({
        type: "p",
        content: contentString.substring(0, breakIndex),
      });
      contentString = contentString.substring(breakIndex);
    }

    if (breakIndex === imgIndex) {
      let imgBreakdown = breakOutImg(contentString);

      contentString = imgBreakdown.remaining;
      contentItems.push({
        type: "img",
        content: { src: imgBreakdown.src, alt: imgBreakdown.alt },
      });
    } else if (breakIndex === headerIndex) {
      let headingBreakdown = breakOutHeader(contentString);

      contentString = headingBreakdown.remaining;
      contentItems.push({
        type: headingBreakdown.headerLevel,
        content: headingBreakdown.header,
      });
    }
  }

  return contentItems;
}

export default postParser;
