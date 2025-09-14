import React, { useState } from "react";
import { Link } from "react-router-dom";
import Avatar from "../common/Avatar";

const UserMenu = () => {
  const [showMenu, setShowMenu] = useState(false);
  return (
    <div className="flex items-center justify-center space-x-6">
      <Link
        to="/become-host"
        className="hidden px-2 py-1 md:block font-medium text-gray-700 hover:bg-gray-100 rounded-full transition-colors"
      >
        Become a host
      </Link>

      <button className="p-3 text-gray-600 bg-gray-100 hover:text-gray-900 hover:bg-gray-200 rounded-full transition-colors">
        <svg
          className="w-4 h-4"
          fill="none"
          stroke="currentColor"
          viewBox="0 0 24 24"
        >
          <path
            strokeLinecap="round"
            strokeLinejoin="round"
            strokeWidth={2}
            d="M21 12a9 9 0 01-9 9m9-9a9 9 0 00-9-9m9 9H3m9 9a9 9 0 01-9-9m9 9c1.657 0 3-4.03 3-9s-1.343-9-3-9m0 18c-1.657 0-3-4.03-3-9s1.343-9 3-9m-9 9a9 9 0 919-9"
          />
        </svg>
      </button>

      {/* User Menu */}
      <div className="relative">
        <button
          className="flex items-center space-x-2 
        border border-gray-300 rounded-full
         p-1 pl-3 hover:shadow-md transition-all"
          onClick={() => setShowMenu(!showMenu)}
        >
          <svg
            className="w-4 h-4 text-gray-600"
            fill="none"
            stroke="currentColor"
            viewBox="0 0 24 24"
          >
            <path
              strokeLinecap="round"
              strokeLinejoin="round"
              strokeWidth={2}
              d="M4 6h16M4 12h16M4 18h16"
            />
          </svg>
          <Avatar className="sm" />
        </button>

        {/* Dropdown Menu */}
        {showMenu && (
          <div className="absolute right-0 mt-4 w-60 bg-white rounded-xl shadow-lg border border-gray-200 py-2 pb-4 z-50">
            <Link to="/">
              <span
                className="inline-block w-full text-left px-4 py-3
             hover:bg-gray-50 font-medium"
              >
                Log in
              </span>
            </Link>
            <Link to="/">
              <span
                className="inline-block w-full text-left px-4 py-3
             hover:bg-gray-50 font-medium"
              >
                Sign up
              </span>
            </Link>
            <Link to="/">
              <span
                className="inline-block w-full text-left px-4 py-3
             hover:bg-gray-50 font-medium"
              >
                Become a host
              </span>
            </Link>
            <Link to="/">
              <span
                className="inline-block w-full text-left px-4 py-3
             hover:bg-gray-50 font-medium"
              >
                Help Center
              </span>
            </Link>
          </div>
        )}
      </div>
    </div>
  );
};

export default UserMenu;
