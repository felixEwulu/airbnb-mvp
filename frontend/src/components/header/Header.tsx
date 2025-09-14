import React from "react";
import Logo from "./Logo";
import Nav from "./Nav";
import UserMenu from "./UserMenu";
import Search from "./Search";

const Header: React.FC = () => {
  return (
    <header className="bg-white sticky top-0 border-b border-gray-200">
      {/* Main Nav */}
      <div className="w-full py-4 px-6 sm:px-8 lg:px-12">
        <div className="flex justify-between items-center h-20">
          <Logo />
          <Nav />
          <UserMenu />
        </div>
      </div>

      <Search />
    </header>
  );
};

export default Header;
