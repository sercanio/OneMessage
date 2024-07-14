/** @type {import('tailwindcss').Config} */
module.exports = {
  darkMode: ['class', '[data-theme="dark"]'],
  content: [
    "./src/**/*.{html,ts}",
  ],
  theme: {
    extend: {
      colors: {
        primary: '#4A90E2', // New primary color
        secondary: '#50E3C2', // New secondary color
        tertiary: '#B8E986', // New tertiary color
        navbarInactive: '#B3B3B3', // New navbarInactive color
      },
      backgroundColor: {
        primary: '#F5F7FA', // New primary background color
        secondary: '#1A1A1A', // New secondary background color
        tertiary: '#E4E7EB', // New tertiary background color
        fourtiery: '#D1D5DB', // New fourtiery background color
        "primary-button": '#4A90E2', // New primary-button background color
        "secondary-button": '#50E3C2', // New secondary-button background color
        "disabled-button": '#95A5A6', // New disabled-button background color
      },
      borderColor: {
        primary: '#4A90E2', // New primary border color
        secondary: '#50E3C2', // New secondary border color
        tertiary: '#34495E', // New tertiary border color
        disabled: '#95A5A6', // New disabled border color
      },
      outlineColor: {
        primary: '#4A90E2', // New primary outline color
        secondary: '#50E3C2', // New secondary outline color
        tertiary: '#34495E', // New tertiary outline color
        disabled: '#95A5A6', // New disabled outline color
      },
      fontFamily: {
        sans: ['Arial', 'Helvetica', 'sans-serif', 'system-ui', 'BlinkMacSystemFont', '-apple-system'],
        title: ["'Roboto Slab'", 'sans-serif'],
        body: ["'Roboto'", 'sans-serif'],
      },
    },
    keyframes: theme => ({
      fadeIn: {
        '0%': { opacity: theme('opacity.90') },
        '100%': { opacity: theme('opacity.100') },
      }
    }),
  },
  plugins: [require("daisyui")],
  daisyUi: {
    themes: [
      {
        light: {
          ...require("daisyui/src/theming/themes")["light"],
          primary: "#4A90E2",
          secondary: "#50E3C2",
        },
      }, "dark"
    ],
    darkTheme: "dark",
    base: true,
    utils: false,
    logs: true,
    styled: false,
  }
}
