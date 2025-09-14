import { Link } from "react-router-dom";

const Logo = () => {
  return (
    <div>
      <Link to="/">
        <img
          src="/public/images/logo-sm.png"
          alt="logo-sm"
          className="md:hidden block cursor-pointer w-10 h-10"
        />

        <img
          src="/public/images/logo1.png"
          alt="logo-lg"
          className="hidden md:block cursor-pointer w-28 h-full"
        />
      </Link>
    </div>
  );
};

export default Logo;
