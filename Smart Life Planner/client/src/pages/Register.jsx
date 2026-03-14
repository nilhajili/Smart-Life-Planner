import planoraLogo from '../images/Planora-logo.png'; 
import Login from './Login';
export default function Register() {
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
              placeholder="Name"
              className="w-full border rounded-lg p-3 outline-none focus:ring-2 focus:ring-green-400"
            />

            <input
              type="email"
              placeholder="Email address"
              className="w-full border rounded-lg p-3 outline-none focus:ring-2 focus:ring-green-400"
            />

            <input
              type="password"
              placeholder="Password"
              className="w-full border rounded-lg p-3 outline-none focus:ring-2 focus:ring-green-400"
            />

            <button
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