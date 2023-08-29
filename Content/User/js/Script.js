document.addEventListener("DOMContentLoaded", function () {
    const chatlog = document.getElementById("chatlog");
    const userInput = document.getElementById("userInput");
    const sendButton = document.getElementById("sendButton");

    sendButton.addEventListener("click", sendMessage);

    function sendMessage() {
        const userMessage = userInput.value;
        if (userMessage.trim() !== "") {
            appendMessage("You", userMessage);
            respondToUser(userMessage);
            userInput.value = "";
        }
    }

    function appendMessage(sender, message) {
        const messageDiv = document.createElement("div");
        messageDiv.innerHTML = `<strong>${sender}:</strong> ${message}`;
        chatlog.appendChild(messageDiv);
        chatlog.scrollTop = chatlog.scrollHeight;
    }

    function respondToUser(userMessage) {
        const responses = {
            "hi": "Hello there! How can I assist you?",
            "how are you": "I'm just a bot, but I'm here to help!",
            "what is your name": "I'm ChatBot, your virtual assistant.",
            "tell me a joke": "Sure, here's one: Why don't scientists trust atoms? Because they make up everything!",
            "how does the library work": "The Mac Digital Library is an innovative platform that provides access to a wide range of digital resources for students and faculty.",
            "can I upload my seminar report": "Yes, you can upload your seminar report in the 'Dbook' section of the library.",
            "how can I request a book": "To request a book, you can use the 'Request Book' feature and our staff will assist you.",
            "what formats of content are available": "The library offers a variety of formats including ebooks, audio books, and videos.",
            "how do I contact library staff": "You can contact our library staff through the 'Contact Us' page on the library's website.",
            // Add more question-response pairs as needed
        };

        const lowercaseUserMessage = userMessage.toLowerCase();
        const botMessage = responses[lowercaseUserMessage] || "I'm sorry, I don't have an answer for that question.";
        setTimeout(() => {
            appendMessage("ChatBot", botMessage);
        }, 500);
    }

});

