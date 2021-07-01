import React from "react";

export default function Loader() {
  return (
    <svg
      className="spinner"
      width="50px"
      height="50px"
      viewBox="0 0 66 66"
      xmlns="http://www.w3.org/2000/svg"
    >
      <circle
        className="path"
        fill="none"
        strokeWidth="4"
        strokeLinecap="round"
        cx="33"
        cy="33"
        r="20"
      ></circle>
    </svg>
  );
}