import { BrowserRouter, Routes, Route } from "react-router-dom";
import Login from "./pages/Login";
import Register from "./pages/Register";
import Dashboard from "./pages/Dashboard";
import Subjects from "./pages/Subjects";
import Task from "./pages/Task";

function App() {
  return (
    <BrowserRouter>
      <Routes>

        <Route path="/" element={<Login />} />
        <Route path="/register" element={<Register />} />

        <Route path="/dashboard" element={<Dashboard />}>
          <Route path="subjects" element={<Subjects />} />
          <Route path="tasks" element={<Task />} />
        </Route>

      </Routes>
    </BrowserRouter>
  );
}

export default App;
    