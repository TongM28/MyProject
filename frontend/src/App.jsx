import React from "react";
import { Routes, Route } from "react-router-dom";
import Home from "./pages/Home";
import CarDetail from "./pages/CarDetail";

function App() {
  return (
    <div>
      {/* Bạn có thể thêm Navbar chung ở đây nếu muốn */}
      <Routes>
        <Route path="/" element={<Home />} />
        <Route path="/car/:id" element={<CarDetail />} />
      </Routes>
      {/* Footer nếu cần */}
    </div>
  );
}

export default App;
