using System;

namespace CyberSecurityChatbot
{
    public class Chatbot
    {
        private Random rand = new Random();

        
        private string lastTopic = "";
        private string userName = "";
        private string favouriteTopic = "";

        
        private string[] phishingTips =
        {
            "Be careful of emails asking for personal information.",
            "Never click suspicious links from unknown senders.",
            "Check the sender's email carefully before responding."
        };

       
        public void SetUserName(string name)
        {
            userName = name;
        }

        
        public string GetResponse(string input)
        {
            input = input.ToLower().Trim();

            
            if (input.Contains("thank you") || input.Contains("thanks"))
            {
                return "You're welcome! Stay safe online.";
            }

           
            bool worried = input.Contains("worried");
            bool frustrated = input.Contains("frustrated");
            bool curious = input.Contains("curious");

            string emotionIntro = "";

            if (worried)
                emotionIntro = "It's understandable to feel worried. ";
            else if (frustrated)
                emotionIntro = "I understand this can feel frustrating. ";
            else if (curious)
                emotionIntro = "Great curiosity! ";

            
            if (input.Contains("my name is"))
            {
                int start = input.IndexOf("my name is") + 11;
                string remaining = input.Substring(start).Trim();

                string[] stopWords =
                {
                    "tell me",
                    "password",
                    "privacy",
                    "phishing",
                    "scam",
                    "im interested in",
                    "i am interested in"
                };

                foreach (string stop in stopWords)
                {
                    int index = remaining.IndexOf(stop);
                    if (index != -1)
                        remaining = remaining.Substring(0, index).Trim();
                }

                string[] words = remaining.Split(' ');
                userName = words[0];

                return "Nice to meet you, " + userName + "!";
            }

            
            if (input.Contains("i am interested in") ||
                input.Contains("im interested in") ||
                input.Contains("my favourite topic is"))
            {
                if (input.Contains("password"))
                    favouriteTopic = "password";
                else if (input.Contains("scam"))
                    favouriteTopic = "scam";
                else if (input.Contains("privacy"))
                    favouriteTopic = "privacy";
                else if (input.Contains("phishing"))
                    favouriteTopic = "phishing";

                return "Great! I'll remember that you're interested in " + favouriteTopic + ".";
            }

            
            if (input.Contains("hello") || input.Contains("hi"))
            {
                string greeting = "Hello";

                if (!string.IsNullOrEmpty(userName))
                    greeting += " " + userName;

                greeting += "! ";

                if (!string.IsNullOrEmpty(favouriteTopic))
                    greeting += "I remember you're interested in " + favouriteTopic + ". ";

                greeting += "How can I help you stay safe online?";

                return greeting;
            }

            
            if (input.Contains("password"))
            {
                lastTopic = "password";

                string[] responses =
                {
                    "Use strong, unique passwords with symbols and numbers.",
                    "A password manager helps create secure passwords.",
                    "Avoid using personal info like birthdays."
                };

                return emotionIntro + responses[rand.Next(responses.Length)];
            }

           
            if (input.Contains("scam"))
            {
                lastTopic = "scam";

                string[] responses =
                {
                    "Never share banking details with strangers.",
                    "Scammers use urgency to trick people.",
                    "Always verify before sending money."
                };

                return emotionIntro + responses[rand.Next(responses.Length)];
            }

            
            if (input.Contains("privacy"))
            {
                lastTopic = "privacy";

                string[] responses =
                {
                    "Review your privacy settings regularly.",
                    "Limit personal information shared online.",
                    "Enable two-factor authentication."
                };

                return emotionIntro + responses[rand.Next(responses.Length)];
            }

            
            if (input.Contains("phishing"))
            {
                lastTopic = "phishing";

                return emotionIntro + phishingTips[rand.Next(phishingTips.Length)];
            }

            
            if (input.Contains("tell me more") ||
                input.Contains("another tip") ||
                input.Contains("explain more"))
            {
                return GetFollowUpResponse();
            }

            
            if (input.Contains("how are you"))
            {
                return "I'm functioning well and ready to help you stay safe online!";
            }

            
            return "I'm not sure I understand. Try asking about passwords, scams, privacy, or phishing.";
        }

        
        private string GetFollowUpResponse()
        {
            switch (lastTopic)
            {
                case "password":
                    return "Try using passphrases and never reuse passwords.";

                case "scam":
                    return "Be careful of fake urgency and requests for money.";

                case "privacy":
                    return "Check app permissions and privacy settings.";

                case "phishing":
                    return "Always check links before clicking.";

                default:
                    return "Ask me about a cybersecurity topic first.";
            }
        }
    }
}