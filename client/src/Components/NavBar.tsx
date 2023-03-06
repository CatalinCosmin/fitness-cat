import { Navbar, Container, Nav } from "react-bootstrap";
import { Link } from "react-router-dom";

const NavBar = (props: { token: any, setToken: any }) => {
  const [token, setToken] = [props.token, props.setToken];
  return (
    <nav>
      <Navbar collapseOnSelect expand="lg" bg="dark" variant="dark">
        <Container>
          <Navbar.Brand href="/">React-Bootstrap</Navbar.Brand>
          <Navbar.Collapse id="responsive-navbar-nav">
            <Nav className="me-auto">
                <Link to="/" className='nav-link'>Home</Link>
            </Nav>
            <Nav>
              {(token === null || token.length <= 2) &&
                  <Link to="/login" className='nav-link'>Login</Link>}
                {(token === null || token.length <= 2) &&
                  <Link to="/register" className='nav-link'>Register</Link>}
              {(token !== null && token.length > 2) &&
                  <Link to="/jwt" className='nav-link'>Jwt</Link>}
            </Nav>
          </Navbar.Collapse>
        </Container>
      </Navbar>
    </nav>
  );
}

export default NavBar;