import { useState } from "react";
import planoraLogo from "../images/Planora-logo.png";

export default function Register() {

  const [fullName, setFullName] = useState("");
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");
  const [role, setRole] = useState("");

  const handleRegister = async () => {
    if (!fullName || !email || !password || !role) {
      alert("Please fill all fields!");
      return;
    }

    try {
      const response = await fetch("http://localhost:5196/api/Auth/register", {
        method: "POST",
        headers: {
          "Content-Type": "application/json"
        },
        body: JSON.stringify({
          fullName: fullName,
          email: email,
          password: password,
          role: role
        })
      });

      const data = await response.json();

      if (response.ok) {
        console.log("Register success:", data);
        alert("Registration successful!");

        if (data.token) {
          localStorage.setItem("token", data.token);
         
        }

        setFullName("");
        setEmail("");
        setPassword("");
        setRole("");

      } else {
        alert(data.message || "Register failed");
      }

    } catch (error) {
      console.error("Error:", error);
      alert("Server error");
    }
  };

  return (
    <div className="flex min-h-screen">
      <div className="flex-1 bg-gradient-to-br from-indigo-200 via-green-200 to-purple-200 p-20 flex flex-col justify-center">

        <h1 className="text-5xl font-bold text-indigo-900 mb-10">
          Plan your future. <br /> Track your progress.<br /> Achieve your goals.
        </h1>

        <div className="mb-8">
          <h3 className="font-semibold text-lg text-indigo-800">
            Goal-Based Planning
          </h3>
          <p className="text-gray-700">
            Set clear academic and work goals with measurable targets and track your progress automatically over time.
          </p>
        </div>

        <div className="mb-8">
          <h3 className="font-semibold text-lg text-indigo-800">
           Smart Productivity Analytics
          </h3>
          <p className="text-gray-700">
            Analyze your study sessions, completed tasks, and performance through interactive charts and real-time statistics.
          </p>
        </div>

        <div className="fixed bottom-0 left-0 m-4">
          <img src={planoraLogo} alt="Planora" className="w-64 h-auto " />
        </div>
      </div>
      <div className="flex-1 flex items-center justify-center bg-gray-50">

        <div className="bg-white p-10 rounded-xl shadow-lg w-[380px]">

          <h2 className="text-2xl font-semibold mb-6">
            Create an account
          </h2>

          <div className="space-y-4">

            <input
              type="text"
              placeholder="Full name"
              value={fullName}
              onChange={(e) => setFullName(e.target.value)}
              className="w-full border rounded-lg p-3 outline-none focus:ring-2 focus:ring-green-400"
            />

            <input
              type="email"
              placeholder="Email address"
              value={email}
              onChange={(e) => setEmail(e.target.value)}
              className="w-full border rounded-lg p-3 outline-none focus:ring-2 focus:ring-green-400"
            />

            <input
              type="password"
              placeholder="Password"
              value={password}
              onChange={(e) => setPassword(e.target.value)}
              className="w-full border rounded-lg p-3 outline-none focus:ring-2 focus:ring-green-400"
            />
            <div>
              <label className="block text-sm font-medium text-gray-700 mb-1">
                Select Role
              </label>
              <select
                value={role}
                onChange={(e) => setRole(e.target.value)}
                className="w-full border rounded-lg p-3 outline-none focus:ring-2 focus:ring-green-400"
              >
                <option value="">Choose a role</option>
                <option value="Student">Student</option>
                <option value="Worker">Worker</option>
                <option value="Both">Both</option>
              </select>
            </div>

            <button
              onClick={handleRegister}
              className="w-full bg-green-500 hover:bg-green-600 text-white p-3 rounded-lg font-medium"
            >
              Sign Up
            </button>

          </div>

          <div className="mt-6 text-center text-gray-500">
            or <a href="/login" className="text-green-500 hover:underline">
              log in
            </a>
          </div>

          <div className="flex gap-3 mt-4">

            <button className="flex-1 border rounded-lg p-2 hover:bg-gray-100">
              Github
            </button>

            <button className="flex-1 border rounded-lg p-2 hover:bg-gray-100">
              Google
            </button>

          </div>

        </div>

      </div>

    </div>
  )
}