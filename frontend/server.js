const express = require('express');
const path = require('path');
const app = express();

// Serve static files from the dist directory
app.use(express.static(path.join(__dirname, 'dist/weather-app')));

// Set content type for JSON files
app.use((req, res, next) => {
  if (req.url.endsWith('.json')) {
    res.setHeader('Content-Type', 'application/json');
  }
  next();
});

// Redirect all routes to index.html for Angular's client-side routing
app.get('*', (req, res) => {
  res.sendFile(path.join(__dirname, 'dist/weather-app/index.html'));
});

// Get port from environment or use 8080 as default
const port = process.env.PORT || 8080;

// Start the server
app.listen(port, () => {
  console.log(`Server running on port ${port}`);
  console.log(`Serving Angular app from ${path.join(__dirname, 'dist/weather-app')}`);
});
