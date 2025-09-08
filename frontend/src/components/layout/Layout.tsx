import React from "react";
import Header from "./Header";

interface LayoutProps {
  children: React.ReactNode;
  showHeader?: boolean;
  className?: string;
}

const Layout: React.FC<LayoutProps> = ({
  children,
  showHeader = true,
  className = "",
}) => {
  return (
    <div className="min-h-screen flex flex-col">
      {showHeader && <Header />}
      <main className={`flex-1 ${className}`}>{children}</main>
    </div>
  );
};

export default Layout;
