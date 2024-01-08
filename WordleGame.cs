using System;
using System.Collections.Generic;
using System.Linq;

namespace Wordle
{

    //for some reason I my code can no longer recognize the target word but it can tell my which letters are correct
    public class WordleGame
    {
        // The target word that the player needs to guess
        private string targetWord;

        // List to store correct letters guessed by the player
        private List<char> correctLetters;

        // Number of remaining attempts allowed
        private int remainingAttempts;

        // The current state of the word being guessed, with asterisks for unknown letters
        public string Word { get; private set; }

        // Result message to be displayed to the player after each guess
        public string Result { get; private set; }

        // Constant representing the maximum number of attempts allowed
        private const int MaxAttempts = 6;

        // Constructor to initialize the game
        public WordleGame()
        {
            InitializeGame();
        }

        // Method to initialize the game with a new target word
        private void InitializeGame()
        {
            targetWord = "holly";
            correctLetters = new List<char>();
            Word = new string('*', targetWord.Length);
            Result = string.Empty;
            remainingAttempts = MaxAttempts;
        }

        // Method to check the player's guess
        public void CheckGuess(string guess)
        {
            // Check if the player has run out of attempts
            if (remainingAttempts <= 0)
            {
                Result = $"Sorry, you've run out of attempts. The correct word was '{targetWord}'.";
                InitializeGame();
                return;
            }

            // Check if the guess length is valid
            if (guess.Length != targetWord.Length)
            {
                Result = "Invalid guess length.";
                return;
            }

            // Clear the list of correct letters for the new guess
            correctLetters.Clear();

            // Check each letter in the guess
            for (int i = 0; i < targetWord.Length; i++)
            {
                // If the letter is correct, update the correctLetters list and the Word being guessed
                if (targetWord[i] == guess[i])
                {
                    correctLetters.Add(targetWord[i]);
                    Word = Word.Substring(0, i) + guess[i] + Word.Substring(i + 1);
                }
            }

            // Check if the player has guessed the entire word correctly
            if (Word == targetWord)
            {
                Result = $"Congratulations! You've guessed the word '{targetWord}' with {MaxAttempts - remainingAttempts + 1} attempts.";
                InitializeGame();
            }
            else
            {
                // Decrement the remaining attempts and provide feedback
                remainingAttempts--;
                Result = $"Attempts remaining: {remainingAttempts}. {GetFeedback()}";
            }
        }

        // Method to provide feedback on the correctness of letters in the current guess
        public string GetFeedback()
        {
            if (correctLetters.Any())
            {
                return $"Correct letters: {string.Join(", ", correctLetters)}";
            }
            else
            {
                return "No correct letters. Try again.";
            }
        }
    }
}
