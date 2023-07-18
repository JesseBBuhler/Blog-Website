import { Link } from "react-router-dom";

function Header() {
  return (
    <>
      <nav>
        <ul>
          <li>
            <Link to="/">Home</Link>
          </li>
          <li>
            <Link to="/recipes">Recipes</Link>
          </li>
          <li>
            <Link to="/blog">Blog</Link>
          </li>
          <li>
            <Link to="/about">About</Link>
          </li>
          <li>
            <Link to="/contact">Contact</Link>
          </li>
          <li>
            <a href="https://www.youtube.com/">Youtube</a>
          </li>
          <li>
            <a href="https://www.amazon.com/">Amazon Shop</a>
          </li>
        </ul>
      </nav>
    </>
  );
}

export default Header;
