const PROXY_CONFIG = [
  {
    context: [
      "/image"
    ],
    target: "http://localhost:3000",
    secure: false
  }
]

module.exports = PROXY_CONFIG;
