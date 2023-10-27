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
        width: 200,
        position: "absolute",
        top: 50,
        left: 312,
        border: "3px solid black",
      }}
    >
      <div className="confirm-overlay bg-secondary">
        <div className="confirm-dialog ">
          <p className="text-center text-light">{message}</p>
          <div className="d-flex justify-content-around pb-2">
            <button onClick={handleConfirm} style={{ width: 70 }}>
              Xác nhận
            </button>
            <button onClick={handleCancel} style={{ width: 70 }}>
              Huỷ
            </button>
          </div>
        </div>
      </div>
    </div>
  );
};

export default Confirmm;
