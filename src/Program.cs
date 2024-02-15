﻿using System;
using System.Linq;

namespace test;

class Program{
        static void Main(string[] args){
            // Instantiate ScoreCard
            bool isGameOver = false;
            int  playerCount = 0;
            ScoreCard[] scoreCards = new ScoreCard[Constants.MaxPlayers];

            while(!isGameOver){
                Methods.DisplayMenu();
                string? userInput = Console.ReadLine();

                switch(userInput){
                    case "1":
                        Methods.AddPlayer(ref playerCount, scoreCards);
                        break;
                    case "2":
                        if(playerCount >= 2){
                            Methods.StartGame(playerCount, scoreCards);
                            }
                        else{
                        Console.WriteLine("Not enough players to start game");
                    }
                        break;
                    case "3":
                        Methods.EnterScores(scoreCards, playerCount);
                        break;
                    case "4":
                        Methods.ScoreCardTests(scoreCards);
                        break;
                    case "5":
                        Methods.DisplayScores(scoreCards, playerCount);
                        break;
                    case "6":
                        isGameOver = true;
                        break;
                    default:
                        Console.WriteLine("Invalid input");
                        break;
                }
            }
        }
    }
