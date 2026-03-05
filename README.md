# 🤖 AI Chat Mobile App (React Native + .NET + Ollama)

A **local AI chatbot mobile application** powered by **Llama3 running locally via Ollama**.

The project demonstrates how to build a **ChatGPT-style mobile app** using:

- 📱 React Native (Mobile UI)
- ⚙️ ASP.NET Core (.NET) API
- 🧠 Ollama Local LLM
- 🦙 Llama3 Model

The AI runs **100% locally** without any external AI API.

---

# 🚀 Features

- Local AI chatbot
- React Native mobile UI
- .NET backend API
- Ollama LLM integration
- Llama3 model
- Works offline
- Simple chat interface
- Extendable architecture

---

# 🏗 Architecture

```
React Native App
        │
        ▼
.NET Web API
        │
        ▼
Ollama Server
        │
        ▼
Llama3 Model
```

---

# 📂 Project Structure

```
ai-chat-project
│
├── mobile-app/              # React Native Mobile Application
│
├── ai-chat-backend/
│   └── AiChat.Api/          # ASP.NET Core API
│
└── README.md
```

---

# 🧰 Requirements

Install the following tools before running the project.

### 1️⃣ Node.js

https://nodejs.org

Verify installation:

```bash
node -v
npm -v
```

---

### 2️⃣ React Native CLI

Install globally:

```bash
npm install -g react-native-cli
```

---

### 3️⃣ .NET SDK

Install **.NET 8**

https://dotnet.microsoft.com/download

Verify:

```bash
dotnet --version
```

---

### 4️⃣ Ollama (Local LLM)

Install Ollama:

https://ollama.com/download

Verify:

```bash
ollama --version
```

---

### 5️⃣ iOS Requirements (Mac only)

Install:

- Xcode
- CocoaPods

Install CocoaPods:

```bash
sudo gem install cocoapods
```

---

# ⚙️ Setup Guide

## 1️⃣ Clone Repository

```bash
git clone https://github.com/yourusername/ai-chat-project.git
cd ai-chat-project
```

---

# 🔧 Backend Setup (.NET API)

Navigate to backend folder:

```bash
cd ai-chat-backend/AiChat.Api
```

Run API:

```bash
dotnet run
```

You should see:

```
Now listening on: http://localhost:5242
```

Swagger UI:

```
http://localhost:5242/swagger
```

---

# 🧠 Install AI Model (Ollama)

Pull the **Llama3 model**:

```bash
ollama pull llama3
```

Start Ollama server:

```bash
ollama serve
```

Default Ollama endpoint:

```
http://localhost:11434
```

---

# 📱 Mobile App Setup

Navigate to mobile app:

```bash
cd mobile-app
```

Install dependencies:

```bash
npm install
```

---

# 🍏 Install iOS Pods

```bash
cd ios
pod install
cd ..
```

---

# ▶ Run Mobile App

Start Metro:

```bash
npx react-native start
```

Run iOS:

```bash
npx react-native run-ios
```

Run Android:

```bash
npx react-native run-android
```

---

# 🔗 API Configuration

Inside the React Native app use:

### iOS Simulator

```javascript
http://localhost:5242/api/chat
```

### Android Emulator

```javascript
http://10.0.2.2:5242/api/chat
```

---

# 📡 API Flow

User sends message from mobile app

↓

React Native calls API

```
POST /api/chat
```

↓

.NET API sends request to Ollama

```
POST http://localhost:11434/api/generate
```

↓

Llama3 generates response

↓

Response returned to mobile app

---

# 📥 Example API Request

```
POST /api/chat
```

Request Body:

```json
{
  "conversationId": "mobile",
  "message": "Hello AI"
}
```

Response:

```json
{
  "reply": "Hello! How can I help you today?",
  "conversationId": "mobile"
}
```

---

# 🛠 Troubleshooting

### Ollama not running

Start server:

```bash
ollama serve
```

---

### Model not installed

```bash
ollama pull llama3
```

---

### iOS build issues

```bash
cd ios
pod install
```

---

### Clear React Native cache

```bash
npx react-native start --reset-cache
```

---

# 📌 Future Improvements

Possible enhancements:

- Streaming AI responses
- ChatGPT style UI
- Markdown support
- Code block rendering
- Voice input
- AI memory
- Vector database (RAG)
- PDF document chat

---

# 🧑‍💻 Author

Built using:

- React Native
- ASP.NET Core
- Ollama
- Llama3

---

# ⭐ Contribute

If you find this project useful, please consider giving it a ⭐ on GitHub.
