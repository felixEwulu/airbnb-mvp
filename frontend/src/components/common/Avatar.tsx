import React from "react";
import { cn } from "../../utils";

export interface AvatarProps {
  src?: string;
  alt?: string;
  size?: "sm" | "md" | "lg" | "xl";
  fallback?: string;
  className?: string;
}

const Avatar: React.FC<AvatarProps> = ({
  src,
  alt,
  size = "md",
  className,
}) => {
  const sizeClasses = {
    sm: "h-8 w-8 text-xs",
    md: "h-10 w-10 text-sm",
    lg: "h-12 w-12 text-base",
    xl: "h-16 w-16 text-lg",
  };

  const baseClasses = cn(
    "inline-flex items-center justify-center rounded-full bg-gray-100 font-medium text-gray-600",
    sizeClasses[size],
    className
  );

  if (src) {
    return (
      <img
        src={src}
        alt={alt || "Avatar"}
        className={cn(baseClasses, "object-cover")}
      />
    );
  }

  return (
    <div>
      <img
        src="/public/images/avatar.png"
        alt="avatar"
        className="object-contain w-6 h-6"
      />
    </div>
  );
};

export default Avatar;
