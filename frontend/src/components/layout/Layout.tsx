import React from "react";
import Navbar from "../header/Header";
import Footer from "./Footer";

interface LayoutProps {
  children: React.ReactNode;
  showHeader?: boolean;
  showFooter?: boolean;
  className?: string;
}

const Layout: React.FC<LayoutProps> = ({
  children,
  showHeader = true,
  showFooter = true,
  className = "",
}) => {
  return (
    <div className="min-h-screen flex flex-col">
      {showHeader && <Navbar />}
      <main
        className={`flex-1 max-w-[2520px] mx-auto px-4 sm:px-2 md:px-10 xl:px-20 ${className}`}
      >
        {children}
      </main>
      {showFooter && <Footer />}
    </div>
  );
};

export default Layout;
