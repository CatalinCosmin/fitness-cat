import { useState } from "react";
import { Navbar, Container, Nav, NavbarBrand } from "react-bootstrap";
import { Link, useLocation } from "react-router-dom";
import './NavBar.css';

const NavBar = (props: { token: any, setToken: any }) => {
  const [token, setToken] = [props.token, props.setToken];
  const [active, setActive] = useState("");

  const handleClick = (event: any) => {
    setActive(event.target.id);
    
  }
  return (
    <nav id="nav_bar" className="bg-navbar">
      <Navbar id="nav-bar-component" collapseOnSelect expand="lg" variant="dark">
        <Container className="nav-container w-100">
          <Navbar.Brand className="nav-brand pc" href="/">
            <img width="200px" src="/fitness-cat-logo.png" alt="Fitness Cat"/>
          </Navbar.Brand>
          <Navbar.Collapse id="responsive-navbar-nav">
            <Nav className="me-auto">
              <Link
                id="home"
                key="home"
                to="/"
                className={active === "home" ? "nav-link sc" : "nav-link"}
                onClick={handleClick}
              >
                Home
              </Link>
              {(token !== null && token.length > 2) &&
                <Link
                  id="workoutroutines"
                  key="workoutroutines"
                  to="/workoutroutines"
                  className={active === "workoutroutines" ? "nav-link sc" : "nav-link"}
                  onClick={handleClick}
                >
                  Workout Routines
                </Link>}
            </Nav>
            <Nav>
              {(token === null || token.length <= 2) &&
                <Link
                  id="register"
                  key="register"
                  to="/register"
                  className={active === "register" ? "nav-link sc" : "nav-link"}
                  onClick={handleClick}
                >
                  Sign-Up
                </Link>}
              {(token !== null && token.length > 2) &&
                <Link
                  to="/jwt"
                  className='nav-link'
                >
                  Jwt
                </Link>}
              {(token !== null && token.length > 2) &&
                <Link
                  to="/"
                  className="nav-link"
                  onClick={() => {setToken('')}}
                >
                  Logout
                </Link>
              }

            </Nav>
          </Navbar.Collapse>
        </Container>
      </Navbar>
    </nav>
  );
}

export default NavBar;