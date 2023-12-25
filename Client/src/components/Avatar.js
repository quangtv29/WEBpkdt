import React from "react";
import "./Avatar.css"; // Import stylesheet for styling

const Avatar = (props) => {
  const imageUrl =
    props.Image ??
    "https://res.cloudinary.com/dimu08wco/image/upload/v1703320369/5f344979-d3a4-4205-a834-ef9d7f1c001b.jpg";
  return (
    <div className="avatar-container">
      <img className="avatar-image" src={imageUrl} alt="Avatar" />
    </div>
  );
};

export default Avatar;
