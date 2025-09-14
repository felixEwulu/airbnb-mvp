import { useState, useEffect, useRef } from "react";
import { Button } from "./ui/button";
import {
  Heart,
  User,
  Menu,
  Search,
  Globe,
  Calendar,
  Users,
  MapPin,
  HelpCircle,
  Settings,
  BookOpen,
  LogOut,
} from "lucide-react";

interface HeaderProps {
  currentUser: any;
  onLoginClick: () => void;
  onHostClick: () => void;
  isHostMode: boolean;
  onGuestClick: () => void;
  onLogout?: () => void;
}

export function Header({
  currentUser,
  onLoginClick,
  onHostClick,
  isHostMode,
  onGuestClick,
  onLogout,
}: HeaderProps) {
  const [showMenu, setShowMenu] = useState(false);
  const [isScrolled, setIsScrolled] = useState(false);
  const ticking = useRef(false);

  useEffect(() => {
    const handleScroll = () => {
      if (!ticking.current) {
        requestAnimationFrame(() => {
          const scrollY = window.scrollY;
          const shouldBeScrolled = scrollY > 80;

          if (shouldBeScrolled !== isScrolled) {
            setIsScrolled(shouldBeScrolled);
          }

          ticking.current = false;
        });
        ticking.current = true;
      }
    };

    window.addEventListener("scroll", handleScroll, { passive: true });
    return () => window.removeEventListener("scroll", handleScroll);
  }, [isScrolled]);

  const handleLogout = () => {
    setShowMenu(false);
    if (onLogout) {
      onLogout();
    }
  };

  return (
    <header
      className={`bg-white sticky top-0 z-50 border-b border-gray-200 will-change-transform ${
        isScrolled ? "shadow-md" : ""
      }`}
    >
      {/* Main Header */}
      <div className="w-full px-6 sm:px-8 lg:px-12 xl:px-16 2xl:px-20">
        <div
          className={`flex justify-between items-center transition-all duration-200 ease-out ${
            isScrolled ? "h-16" : "h-20"
          }`}
        >
          {/* Logo */}
          <div className="flex items-center">
            <button
              onClick={onGuestClick}
              className="flex items-center space-x-2 group"
            >
              <div className="w-8 h-8 bg-gradient-to-br from-rose-500 to-pink-500 rounded-lg flex items-center justify-center">
                <svg
                  className="w-5 h-5 text-white"
                  viewBox="0 0 24 24"
                  fill="currentColor"
                >
                  <path d="M12 2C13.1 2 14 2.9 14 4C14 5.1 13.1 6 12 6C10.9 6 10 5.1 10 4C10 2.9 10.9 2 12 2ZM21 9V7L15 1L9 7V9C9 10.1 9.9 11 11 11V14L13 16L15 14V11C16.1 11 17 10.1 17 9H21ZM11 22C10.4 22 10 21.6 10 21C10 20.4 10.4 20 11 20H13C13.6 20 14 20.4 14 21C14 21.6 13.6 22 13 22H11Z" />
                </svg>
              </div>
              <span className="hidden sm:block text-xl font-semibold text-rose-500 group-hover:text-rose-600 transition-colors">
                airbnb
              </span>
            </button>
          </div>

          {/* Center Content - changes based on scroll state */}
          {!isHostMode && (
            <div className="flex items-center justify-center flex-1">
              {/* Desktop Navigation and Search */}
              <div className="hidden md:block relative w-full max-w-md">
                {/* Navigation Items - show when not scrolled */}
                <nav
                  className={`flex items-center justify-center space-x-8 transition-all duration-200 ease-out ${
                    isScrolled
                      ? "opacity-0 scale-95 pointer-events-none absolute inset-0"
                      : "opacity-100 scale-100"
                  }`}
                >
                  <button className="px-4 py-2 text-gray-700 hover:text-gray-900 font-medium border-b-2 border-transparent hover:border-gray-300 transition-colors">
                    Homes
                  </button>
                  <button className="px-4 py-2 text-gray-700 hover:text-gray-900 font-medium border-b-2 border-transparent hover:border-gray-300 transition-colors">
                    Experiences
                  </button>
                  <button className="px-4 py-2 text-gray-700 hover:text-gray-900 font-medium border-b-2 border-transparent hover:border-gray-300 transition-colors">
                    Services
                  </button>
                </nav>

                {/* Compact Search - show when scrolled */}
                <div
                  className={`flex items-center justify-center transition-all duration-200 ease-out ${
                    isScrolled
                      ? "opacity-100 scale-100"
                      : "opacity-0 scale-95 pointer-events-none absolute inset-0"
                  }`}
                >
                  <div className="flex items-center border border-gray-300 rounded-full bg-white shadow-sm hover:shadow-md transition-shadow">
                    <div className="flex items-center px-4 py-2">
                      <div className="flex items-center space-x-3">
                        <span className="text-sm font-medium text-gray-900">
                          Anywhere
                        </span>
                        <div className="w-px h-4 bg-gray-300"></div>
                        <span className="text-sm font-medium text-gray-900">
                          Anytime
                        </span>
                        <div className="w-px h-4 bg-gray-300"></div>
                        <span className="text-sm text-gray-500">
                          Add guests
                        </span>
                      </div>
                      <div className="ml-3">
                        <div className="bg-rose-500 hover:bg-rose-600 text-white p-1.5 rounded-full transition-colors">
                          <Search className="w-3.5 h-3.5" />
                        </div>
                      </div>
                    </div>
                  </div>
                </div>
              </div>

              {/* Mobile Compact Search - always visible on mobile when scrolled */}
              <div
                className={`md:hidden transition-all duration-200 ease-out ${
                  isScrolled
                    ? "opacity-100 scale-100"
                    : "opacity-0 scale-95 pointer-events-none"
                }`}
              >
                <div className="flex items-center border border-gray-300 rounded-full bg-white shadow-sm hover:shadow-md transition-shadow">
                  <div className="flex items-center px-3 py-1.5">
                    <Search className="w-4 h-4 text-gray-400 mr-2" />
                    <div className="flex items-center space-x-2 text-sm">
                      <span className="font-medium text-gray-900">
                        Anywhere
                      </span>
                      <span className="text-gray-400">•</span>
                      <span className="text-gray-500">Add guests</span>
                    </div>
                  </div>
                </div>
              </div>
            </div>
          )}

          {/* Right side */}
          <div className="flex items-center space-x-2">
            {/* Airbnb your home button */}
            <button
              onClick={currentUser && isHostMode ? onGuestClick : onHostClick}
              className="hidden lg:block px-4 py-2 text-sm font-medium text-gray-700 hover:bg-gray-50 rounded-full transition-colors whitespace-nowrap"
            >
              {currentUser && isHostMode
                ? "Switch to Guest"
                : "Airbnb your home"}
            </button>

            {/* Language selector */}
            <button className="hidden sm:block p-3 text-gray-700 hover:bg-gray-50 rounded-full transition-colors">
              <Globe className="w-4 h-4" />
            </button>

            {/* User menu */}
            <div className="relative">
              <button
                onClick={() => setShowMenu(!showMenu)}
                className="flex items-center space-x-2 border border-gray-300 rounded-full p-1 pl-3 pr-1 hover:shadow-md transition-all"
              >
                <Menu className="w-4 h-4 text-gray-600" />
                {currentUser ? (
                  <div className="w-8 h-8 bg-gray-500 rounded-full flex items-center justify-center">
                    <span className="text-white text-sm font-medium">
                      {currentUser.name.charAt(0).toUpperCase()}
                    </span>
                  </div>
                ) : (
                  <div className="w-8 h-8 bg-gray-500 rounded-full flex items-center justify-center">
                    <User className="w-4 h-4 text-white" />
                  </div>
                )}
              </button>

              {/* Dropdown Menu */}
              {showMenu && (
                <div className="absolute right-0 mt-2 w-60 bg-white rounded-xl shadow-lg border border-gray-200 py-2 z-50">
                  {currentUser ? (
                    <>
                      <div className="px-4 py-3 border-b border-gray-100">
                        <p className="font-medium text-gray-900">
                          {currentUser.name}
                        </p>
                        <p className="text-sm text-gray-500">
                          {currentUser.email}
                        </p>
                      </div>

                      <div className="py-2">
                        <button
                          className="w-full text-left px-4 py-3 hover:bg-gray-50 flex items-center space-x-3 font-medium"
                          onClick={() => {
                            setShowMenu(false);
                            // Handle trips
                          }}
                        >
                          <span>Trips</span>
                        </button>

                        <button
                          className="w-full text-left px-4 py-3 hover:bg-gray-50 flex items-center space-x-3"
                          onClick={() => {
                            setShowMenu(false);
                            // Handle wishlists
                          }}
                        >
                          <span>Wishlists</span>
                        </button>
                      </div>

                      <div className="border-t border-gray-100 py-2">
                        <button
                          className="w-full text-left px-4 py-3 hover:bg-gray-50"
                          onClick={() => {
                            setShowMenu(false);
                            isHostMode ? onGuestClick() : onHostClick();
                          }}
                        >
                          {isHostMode ? "Switch to Guest" : "Host your home"}
                        </button>

                        <button
                          className="w-full text-left px-4 py-3 hover:bg-gray-50"
                          onClick={() => {
                            setShowMenu(false);
                            // Handle account
                          }}
                        >
                          Account
                        </button>

                        <button
                          className="w-full text-left px-4 py-3 hover:bg-gray-50"
                          onClick={() => {
                            setShowMenu(false);
                            // Handle help
                          }}
                        >
                          Help Center
                        </button>

                        <button
                          className="w-full text-left px-4 py-3 hover:bg-gray-50"
                          onClick={handleLogout}
                        >
                          Log out
                        </button>
                      </div>
                    </>
                  ) : (
                    <>
                      <div className="py-2">
                        <button
                          className="w-full text-left px-4 py-3 hover:bg-gray-50 font-medium"
                          onClick={() => {
                            setShowMenu(false);
                            onLoginClick();
                          }}
                        >
                          Log in
                        </button>
                        <button
                          className="w-full text-left px-4 py-3 hover:bg-gray-50"
                          onClick={() => {
                            setShowMenu(false);
                            onLoginClick();
                          }}
                        >
                          Sign up
                        </button>
                      </div>

                      <div className="border-t border-gray-100 py-2">
                        <button
                          className="w-full text-left px-4 py-3 hover:bg-gray-50"
                          onClick={() => {
                            setShowMenu(false);
                            onHostClick();
                          }}
                        >
                          Airbnb your home
                        </button>
                        <button
                          className="w-full text-left px-4 py-3 hover:bg-gray-50"
                          onClick={() => {
                            setShowMenu(false);
                            // Handle help
                          }}
                        >
                          Help Center
                        </button>
                      </div>
                    </>
                  )}
                </div>
              )}
            </div>
          </div>
        </div>
      </div>

      {/* Expanded Search Bar - only show when not scrolled and in guest mode */}
      {!isHostMode && (
        <div
          className={`border-t border-gray-200 transition-all duration-200 ease-out overflow-hidden ${
            isScrolled ? "max-h-0 opacity-0" : "max-h-32 opacity-100"
          }`}
        >
          <div className="w-full px-6 sm:px-8 lg:px-12 xl:px-16 2xl:px-20">
            <div className="flex justify-center py-4">
              {/* Desktop Expanded Search */}
              <div className="hidden sm:flex items-center border border-gray-300 rounded-full bg-white shadow-sm hover:shadow-md transition-shadow">
                <div className="flex items-center px-6 py-3">
                  <div className="flex items-center space-x-4">
                    <div className="flex flex-col">
                      <span className="text-sm font-medium text-gray-900">
                        Where
                      </span>
                      <span className="text-sm text-gray-500">
                        Search destinations
                      </span>
                    </div>
                    <div className="w-px h-8 bg-gray-300"></div>
                    <div className="flex flex-col">
                      <span className="text-sm font-medium text-gray-900">
                        Check in
                      </span>
                      <span className="text-sm text-gray-500">Add dates</span>
                    </div>
                    <div className="w-px h-8 bg-gray-300"></div>
                    <div className="flex flex-col">
                      <span className="text-sm font-medium text-gray-900">
                        Check out
                      </span>
                      <span className="text-sm text-gray-500">Add dates</span>
                    </div>
                    <div className="w-px h-8 bg-gray-300"></div>
                    <div className="flex flex-col">
                      <span className="text-sm font-medium text-gray-900">
                        Who
                      </span>
                      <span className="text-sm text-gray-500">Add guests</span>
                    </div>
                  </div>
                  <div className="ml-4">
                    <div className="bg-rose-500 hover:bg-rose-600 text-white p-2 rounded-full transition-colors">
                      <Search className="w-4 h-4" />
                    </div>
                  </div>
                </div>
              </div>

              {/* Mobile Expanded Search */}
              <div className="sm:hidden w-full">
                <div className="flex items-center border border-gray-300 rounded-full bg-white shadow-sm hover:shadow-md transition-shadow">
                  <div className="flex items-center w-full px-4 py-3">
                    <Search className="w-4 h-4 text-gray-400 mr-3 flex-shrink-0" />
                    <div className="flex flex-col flex-1 min-w-0">
                      <span className="text-sm font-medium text-gray-900">
                        Where to?
                      </span>
                      <span className="text-xs text-gray-500 truncate">
                        Anywhere • Any week • Add guests
                      </span>
                    </div>
                  </div>
                </div>
              </div>

              {/* Mobile Navigation Tabs - show below search on mobile */}
            </div>

            {/* Mobile Navigation - only show when not scrolled */}
            <div
              className={`sm:hidden transition-all duration-200 ease-out ${
                isScrolled
                  ? "max-h-0 opacity-0 overflow-hidden"
                  : "max-h-16 opacity-100"
              }`}
            >
              <nav className="flex justify-center space-x-6 pb-4">
                <button className="px-3 py-2 text-sm font-medium text-gray-700 hover:text-gray-900 border-b-2 border-transparent hover:border-gray-300 transition-colors">
                  Homes
                </button>
                <button className="px-3 py-2 text-sm font-medium text-gray-700 hover:text-gray-900 border-b-2 border-transparent hover:border-gray-300 transition-colors">
                  Experiences
                </button>
                <button className="px-3 py-2 text-sm font-medium text-gray-700 hover:text-gray-900 border-b-2 border-transparent hover:border-gray-300 transition-colors">
                  Services
                </button>
              </nav>
            </div>
          </div>
        </div>
      )}

      {/* Click outside to close menu */}
      {showMenu && (
        <div
          className="fixed inset-0 z-40"
          onClick={() => setShowMenu(false)}
        />
      )}
    </header>
  );
}
