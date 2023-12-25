import React from "react";

const Confirmm = ({ message, onConfirm, onCancel }) => {
  const handleConfirm = () => {
    onConfirm();
  };

  const handleCancel = () => {
    onCancel();
  };

  return (
    <div
      style={{
        width: "200px",
        position: "fixed",
        top: "50%",
        left: "50%",
        transform: "translate(-50%, -50%)",
        border: "3px solid black",
        backgroundColor: "#fff", // Set your desired background color
        padding: "10px",
        borderRadius: "8px",
        boxShadow: "0 0 10px rgba(0, 0, 0, 0.2)",
      }}
    >
      <div className="confirm-dialog">
        <p style={{ textAlign: "center", color: "#333" }}>{message}</p>
        <div
          style={{
            display: "flex",
            justifyContent: "space-around",
            marginTop: "10px",
          }}
        >
          <button
            onClick={handleConfirm}
            style={{
              width: "80px",
              padding: "5px",
              borderRadius: "5px",
              background: "#28a745",
              color: "#fff",
              border: "none",
              cursor: "pointer",
            }}
          >
            Xác nhận
          </button>
          <button
            onClick={handleCancel}
            style={{
              width: "80px",
              padding: "5px",
              borderRadius: "5px",
              background: "#dc3545",
              color: "#fff",
              border: "none",
              cursor: "pointer",
            }}
          >
            Huỷ
          </button>
        </div>
      </div>
    </div>
  );
};

export default Confirmm;
