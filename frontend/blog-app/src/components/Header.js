import { Link } from "react-router-dom";
import React, { useState } from "react";
import "./Header.css";
// import logo from "/img/ThymeToGrowBlue.png";

function Header() {
  const [dropdown, setDropdown] = useState("hidden");
  const toggleDropdown = () => {
    setDropdown(dropdown === "hidden" ? "unhidden" : "hidden");
  };

  return (
    <div className="headerContainer">
      <div className="logoContainer">
        <img src="/img/ThymeToGrowBanner.png" alt="logo"></img>
      </div>
      <nav className="dropdown">
        <div className="dropdownBtn" onClick={toggleDropdown}>
          Menu
        </div>
        <div className={`dropdownContent ${dropdown}`}>
          <ul className="navList">
            <li>
              <Link onClick={toggleDropdown} to="/">
                Home
              </Link>
            </li>
            <li>
              <Link onClick={toggleDropdown} to="/recipes">
                Recipes
              </Link>
            </li>
            <li>
              <Link onClick={toggleDropdown} to="/blog">
                Blog
              </Link>
            </li>
            <li>
              <Link onClick={toggleDropdown} to="/about">
                About
              </Link>
            </li>
            <li>
              <Link onClick={toggleDropdown} to="/contact">
                Contact
              </Link>
            </li>
            <li>
              <a onClick={toggleDropdown} href="https://www.youtube.com/">
                Youtube
              </a>
            </li>
            <li>
              <a onClick={toggleDropdown} href="https://www.amazon.com/">
                Amazon Shop
              </a>
            </li>
          </ul>
        </div>
      </nav>
    </div>
  );
}

export default Header;
