import React, { useEffect, useRef, useState } from "react";
import { cn } from "../../utils";
import { Link } from "react-router-dom";

interface VideoIconProps {
  src: string;
  delay: number;
  iconType?: "home" | "experiences" | "services";
}

const VideoIcon: React.FC<VideoIconProps> = ({ src, delay, iconType }) => {
  const videoRef = useRef<HTMLVideoElement>(null);
  const [hasInitiallyPlayed, setHasInitiallyPlayed] = useState(false);

  useEffect(() => {
    if (!hasInitiallyPlayed) {
      const timer = setTimeout(() => {
        if (videoRef.current) {
          videoRef.current.currentTime = 0;
          videoRef.current
            .play()
            .then(() => {
              setHasInitiallyPlayed(true);
            })
            .catch((err) => console.log("Initial video play failed:", err));
        }
      }, delay);

      return () => clearTimeout(timer);
    }
  }, [delay, hasInitiallyPlayed]);

  const handleVideoEnded = () => {
    if (videoRef.current) {
      videoRef.current.currentTime = 0;
    }
  };

  return (
    <div className="relative">
      <div className="w-20 h-20 rounded-sm overflow-hidden">
        <video
          ref={videoRef}
          className="w-full h-full object-cover"
          muted
          playsInline
          onEnded={handleVideoEnded}
          style={{ display: src ? "block" : "none" }}
        >
          <source src={src} type="video/webm" />
        </video>
      </div>
    </div>
  );
};

const Nav: React.FC = () => {
  const [activeTab, setActiveTab] = useState("homes");

  const navigationTabs = [
    {
      id: "homes",
      label: "Homes",
      href: "/",
      videoSrc: "/videos/house-twirl-selected.webm",
      iconType: "home" as const,
      delay: 500,
      badge: null,
    },
    {
      id: "experiences",
      label: "Experiences",
      href: "/experiences",
      videoSrc: "/videos/balloon-twirl.webm",
      iconType: "experiences" as const,
      delay: 800,
      badge: "NEW",
    },
    {
      id: "services",
      label: "Services",
      href: "/services",
      videoSrc: "/videos/consierge-twirl.webm",
      iconType: "services" as const,
      delay: 1100,
      badge: "NEW",
    },
  ];
  return (
    <nav className="hidden md:flex items-center justify-center space-x-6">
      {navigationTabs.map((tab) => (
        <Link
          key={tab.id}
          to={tab.href}
          className={cn(
            "relative flex items-center px-2 py-3 group transition-colors",
            activeTab === tab.id
              ? "text-gray-900"
              : "text-gray-500 hover:text-gray-700"
          )}
          onClick={() => setActiveTab(tab.id)}
        >
          {/* Icon and Badge Container */}
          <div className="relative transform transition-transform hover:scale-110 duration-300">
            <VideoIcon
              src={tab.videoSrc}
              delay={tab.delay}
              iconType={tab.iconType}
            />

            {/* NEW Badge */}
            {tab.badge && (
              <div className="absolute bottom-14 left-12 bg-blue-600 text-white text-xs px-[3px] py-0.5 rounded-full font-sm">
                {tab.badge}
              </div>
            )}
          </div>

          {/* Tab Label */}
          <span className="text-lg font-medium whitespace-nowrap">
            {tab.label}
          </span>

          {/* Active Tab Indicator */}
          {activeTab === tab.id && (
            <div className="absolute top-20 -right-[50px] transform -translate-x-1/2 w-[80%] h-[3px] bg-gray-900 rounded-full" />
          )}
        </Link>
      ))}
    </nav>
  );
};

export default Nav;
