import ReactDOM from "react-dom/client";
import { BrowserRouter, Routes, Route } from "react-router-dom";
import PolicyDetails from "./PolicyDetails";
import Report from "./Report";

const App=()=> {
  return (
    <BrowserRouter>
      <Routes>
          <Route path="/" element={<PolicyDetails />} />
          <Route path="/Details" element={<PolicyDetails />} />
          <Route path="/Report" element={<Report />} />
       </Routes>
    </BrowserRouter>
  );
}

export default App;