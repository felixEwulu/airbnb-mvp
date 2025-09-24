import { SearchIcon } from "lucide-react";
import React from "react";

const Search = () => {
  return (
    <div className="transition-all duration-200 ease-out overflow-hidden max-h-32 opacity-100">
      {/* desktop search */}
      <div className="w-full px-6 sm:px-8 lg:px-4 xl:px-4 2xl:px-4 mb-4">
        <div className="flex justify-center py-2">
          <div className="hidden max-w-6xl sm:flex items-center border border-gray-300 rounded-full bg-white shadow-sm hover:shadow-md transition-shadow">
            <div className="flex items-center">
              <div className="flex items-center space-x-4">
                <div className="flex flex-col transition-colors duration-500 ease-in-out hover:bg-gray-200 rounded-full pr-20 py-3 pl-6 cursor-pointer">
                  <span className="text-sm font-medium text-gray-900">
                    Where
                  </span>
                  <span className="text-sm  text-gray-500">
                    Search destinations
                  </span>
                </div>
                <div className="w-px h-8 bg-gray-300"></div>
                <div className="flex flex-col transition-colors duration-500 ease-in-out hover:bg-gray-200 rounded-full px-12 py-3 cursor-pointer">
                  <span className="text-sm font-medium text-gray-900">
                    Check in
                  </span>
                  <span className="text-sm  text-gray-500">Add dates</span>
                </div>
                <div className="w-px h-8 bg-gray-300"></div>
                <div className="flex flex-col transition-colors duration-500 ease-in-out hover:bg-gray-200 rounded-full px-14 py-3 cursor-pointer">
                  <span className="text-sm font-medium text-gray-900">
                    Check out
                  </span>
                  <span className="text-sm  text-gray-500">Add dates</span>
                </div>
                <div className="w-px h-8 bg-gray-300"></div>
                <div className="flex flex-col transition-colors duration-500 ease-in-out hover:bg-gray-200 rounded-full px-14 py-3 cursor-pointer">
                  <span className="text-sm font-medium text-gray-900">Who</span>
                  <span className="text-sm  text-gray-500">Add guests</span>
                </div>
              </div>
              <div className="ml-12 pr-1">
                <div className="bg-rose-500 hover:bg-rose-600 text-white p-4 rounded-full transition-colors">
                  <SearchIcon className="w-6 h-6" />
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  );
};

export default Search;
