import { NavLink } from "react-router-dom";
import planoraLogo from "../images/Planora-logo.png";
import { GiExitDoor } from "react-icons/gi";
import { IoMdExit } from "react-icons/io";
import { TbHomeStar } from "react-icons/tb";
import { MdOutlineSettings } from "react-icons/md";
import { GoGoal } from "react-icons/go";
import { FaTasks } from "react-icons/fa";
import { IoSchoolOutline } from "react-icons/io5";

export default function Sidebar() {
  const linkClass =
  "flex items-center gap-2 py-2 px-3 rounded-xl shadow-sm hover:bg-[#ded0f4] transition";

  const activeClass = "bg-[#ded0f4] shadow-bottom-lg font-semibold";

  return (
    <div className="flex flex-col  ">
      <img
        src={planoraLogo}
        className="shadow-lg  brightness-0"
      />

      <nav className="flex flex-col gap-2 mt-20">
        <div className=" ">
        <NavLink
          to="/dashboard"
          className={({ isActive }) =>
            `${linkClass} ${isActive ? activeClass : ""}flex items-center gap-3`
          }
        >
          <TbHomeStar className="text-xl " />
          <span>Home</span>
        </NavLink>
        </div>

        <NavLink
          to="/subjects"
          className={({ isActive }) =>
            `${linkClass} ${isActive ? activeClass : ""} flex items-center gap-3`
          }
        >
          <IoSchoolOutline className="text-xl" />
          <span>Subjects</span>
        </NavLink>

        <NavLink
          to="/tasks"
          className={({ isActive }) =>
            `${linkClass} ${isActive ? activeClass : ""} flex items-center gap-3`
          }
        >
          <FaTasks className="text-xl" />
          <span>Tasks</span>
        </NavLink>

        <NavLink
          to="/statistics"
          className={({ isActive }) =>
            `${linkClass} ${isActive ? activeClass : ""} flex items-center gap-3`
          }
        >
         <GoGoal className="text-xl" /> 
         <span>Goals</span>
        </NavLink>

        <NavLink
          to="/profile"
          className={({ isActive }) =>
            `${linkClass} ${isActive ? activeClass : ""} flex items-center gap-3`
          }
        >
          <MdOutlineSettings className="text-xl" />
          <span>Settings</span>
        </NavLink>
      </nav>

      <div className="mt-auto  pt-80 pb-10 ">
        <button className="w-full text-white bg-[#330158] hover:bg-red-500 py-2 rounded-[1.5rem] flex items-center justify-center gap-2 font-semibold text-lg transition">
          <IoMdExit className="text-2xl" />
          <span>Logout</span>
        </button>
      </div>
    </div>
  );
}
