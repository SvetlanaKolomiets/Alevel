import React from "react";
import { CssBaseline, ThemeProvider } from "@mui/material";
import { createTheme } from "@mui/material/styles";
import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import { routes as appRoutes } from "./routes";
import Layout from "./components/Layout/Layout";

function App() {
  const theme = createTheme({
    palette: {
      primary: {
        light: "#6a1b9a",
        main: "#9c27b0",
        dark: "#4a148c",
        contrastText: "#fff",
      },
      secondary: {
        main: "#00897b",
        light: "#4db6ac",
        dark: "#004d40",
        contrastText: "#fff",
      },
    },
  });

  return (
    <ThemeProvider theme={theme}>
      <CssBaseline />
      <Router>
        <Layout>
          <Routes>
            {appRoutes.map((route) => (
              <Route
                key={route.key}
                path={route.path}
                element={<route.component />}
              />
            ))}
          </Routes>
        </Layout>
      </Router>
    </ThemeProvider>
  );
}

export default App;
