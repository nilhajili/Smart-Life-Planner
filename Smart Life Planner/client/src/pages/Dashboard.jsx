import Sidebar from "../components/Sidebar";
import { Outlet } from "react-router-dom";
import headerImg from "../images/Navbar1.jpeg";

export default function Dashboard() {
  return (
    <div className="flex min-h-screen">
      
      <div className="w-64 bg-white p-4">
        <Sidebar />
      </div>
      <div className="flex flex-col flex-1">
       <div className="w-full h-60 overflow-hidden">
          <img
            src={headerImg}
            className="w-full h-full object-cover object-right"
          />
        </div>

        <div className="flex-1 p-6 bg-[#e7dff3]">
          <Outlet />
        </div>

      </div>
    </div>
  );
}