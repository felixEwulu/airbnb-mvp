import React from "react";
import { Link } from "react-router-dom";

const Footer: React.FC = () => {
  const currentYear = new Date().getFullYear();

  const footerLinks = {
    Support: [
      { name: "Help Center", href: "/help" },
      { name: "Safety Information", href: "/safety" },
      { name: "Cancellation Options", href: "/cancellation" },
      { name: "Contact Us", href: "/contact" },
    ],
    Community: [
      { name: "Airbnb.org", href: "/community" },
      { name: "Support Afghan Refugees", href: "/refugees" },
      { name: "Combating Discrimination", href: "/discrimination" },
    ],
    Host: [
      { name: "Host Your Home", href: "/host" },
      { name: "Host an Experience", href: "/host-experience" },
      { name: "Responsible Hosting", href: "/responsible-hosting" },
      { name: "Resource Center", href: "/resource-center" },
    ],
    About: [
      { name: "Newsroom", href: "/newsroom" },
      { name: "Learn About New Features", href: "/features" },
      { name: "Letter from our Founders", href: "/founders" },
      { name: "Careers", href: "/careers" },
      { name: "Investors", href: "/investors" },
    ],
  };

  return (
    <footer className="bg-gray-50 border-t border-gray-200">
      <div className="container mx-auto px-4 sm:px-6 lg:px-8 py-12">
        {/* Main Footer Content */}
        <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-4 gap-8">
          {Object.entries(footerLinks).map(([category, links]) => (
            <div key={category}>
              <h3 className="text-sm font-semibold text-gray-900 mb-4">
                {category}
              </h3>
              <ul className="space-y-3">
                {links.map((link) => (
                  <li key={link.name}>
                    <Link
                      to={link.href}
                      className="text-sm text-gray-600 hover:text-gray-900 transition-colors"
                    >
                      {link.name}
                    </Link>
                  </li>
                ))}
              </ul>
            </div>
          ))}
        </div>

        {/* Divider */}
        <div className="border-t border-gray-200 my-8"></div>

        {/* Bottom Section */}
        <div className="flex flex-col lg:flex-row lg:items-center lg:justify-between space-y-4 lg:space-y-0">
          {/* Left Side */}
          <div className="flex flex-col sm:flex-row sm:items-center space-y-4 sm:space-y-0 sm:space-x-6">
            <p className="text-sm text-gray-600">
              © {currentYear} Airbnb MVP, Inc.
            </p>
            <div className="flex flex-wrap gap-4">
              <Link
                to="/privacy"
                className="text-sm text-gray-600 hover:text-gray-900"
              >
                Privacy
              </Link>
              <Link
                to="/terms"
                className="text-sm text-gray-600 hover:text-gray-900"
              >
                Terms
              </Link>
              <Link
                to="/sitemap"
                className="text-sm text-gray-600 hover:text-gray-900"
              >
                Sitemap
              </Link>
              <Link
                to="/company"
                className="text-sm text-gray-600 hover:text-gray-900"
              >
                Company Details
              </Link>
            </div>
          </div>

          {/* Right Side */}
          <div className="flex items-center space-x-6">
            {/* Language/Currency Selector */}
            <div className="flex items-center space-x-4">
              <button className="flex items-center space-x-1 text-sm text-gray-600 hover:text-gray-900">
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
                    d="M3 5h12M9 3v2m1.048 9.5A18.022 18.022 0 016.412 9m6.088 9h7M11 21l5-10 5 10M12.751 5C11.783 10.77 8.07 15.61 3 18.129"
                  />
                </svg>
                <span>English (US)</span>
              </button>
              <button className="flex items-center space-x-1 text-sm text-gray-600 hover:text-gray-900">
                <span>$ USD</span>
              </button>
            </div>

            {/* Social Media Links */}
            <div className="flex items-center space-x-4">
              <a
                href="https://facebook.com"
                target="_blank"
                rel="noopener noreferrer"
                className="text-gray-400 hover:text-gray-600"
              >
                <svg
                  className="w-5 h-5"
                  fill="currentColor"
                  viewBox="0 0 24 24"
                >
                  <path d="M24 12.073c0-6.627-5.373-12-12-12s-12 5.373-12 12c0 5.99 4.388 10.954 10.125 11.854v-8.385H7.078v-3.47h3.047V9.43c0-3.007 1.792-4.669 4.533-4.669 1.312 0 2.686.235 2.686.235v2.953H15.83c-1.491 0-1.956.925-1.956 1.874v2.25h3.328l-.532 3.47h-2.796v8.385C19.612 23.027 24 18.062 24 12.073z" />
                </svg>
              </a>
              <a
                href="https://twitter.com"
                target="_blank"
                rel="noopener noreferrer"
                className="text-gray-400 hover:text-gray-600"
              >
                <svg
                  className="w-5 h-5"
                  fill="currentColor"
                  viewBox="0 0 24 24"
                >
                  <path d="M23.953 4.57a10 10 0 01-2.825.775 4.958 4.958 0 002.163-2.723c-.951.555-2.005.959-3.127 1.184a4.92 4.92 0 00-8.384 4.482C7.69 8.095 4.067 6.13 1.64 3.162a4.822 4.822 0 00-.666 2.475c0 1.71.87 3.213 2.188 4.096a4.904 4.904 0 01-2.228-.616v.06a4.923 4.923 0 003.946 4.827 4.996 4.996 0 01-2.212.085 4.936 4.936 0 004.604 3.417 9.867 9.867 0 01-6.102 2.105c-.39 0-.779-.023-1.17-.067a13.995 13.995 0 007.557 2.209c9.053 0 13.998-7.496 13.998-13.985 0-.21 0-.42-.015-.63A9.935 9.935 0 0024 4.59z" />
                </svg>
              </a>
              <a
                href="https://instagram.com"
                target="_blank"
                rel="noopener noreferrer"
                className="text-gray-400 hover:text-gray-600"
              >
                <svg
                  className="w-5 h-5"
                  fill="currentColor"
                  viewBox="0 0 24 24"
                >
                  <path d="M12.017 0C5.396 0 .029 5.367.029 11.987c0 6.62 5.367 11.987 11.988 11.987 6.62 0 11.987-5.367 11.987-11.987C24.014 5.367 18.637.001 12.017.001zM8.449 16.988c-1.297 0-2.348-1.051-2.348-2.348 0-1.297 1.051-2.348 2.348-2.348 1.297 0 2.348 1.051 2.348 2.348 0 1.297-1.051 2.348-2.348 2.348zM12.017 7.729c-2.343 0-4.258 1.915-4.258 4.258s1.915 4.258 4.258 4.258 4.258-1.915 4.258-4.258-1.915-4.258-4.258-4.258z" />
                </svg>
              </a>
            </div>
          </div>
        </div>
      </div>
    </footer>
  );
};

export default Footer;
