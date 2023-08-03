﻿using System;
using System.Collections.Generic;

namespace HW3
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            List<ICard> deck = new List<ICard>()
            {
                new Card("Карта 1", "огонь", 15, 1, 2),
                new Card("Карта 2", "воздух", 10, 3, 1),
                new Card("Карта 3", "вода", 5, 2, 3),
                new Card("Карта 4", "земля", 18, 1, 1),
                new Card("Карта 5", "вода", 12, 3, 3)
            };

            int score = 0;
            
            while (true)
            {
                
                ICard chosenCard = ChooseCard(deck);
                
                IEnemy enemy = CreateRandomEnemy();

                Console.WriteLine("Вы сражаетесь с врагом: " + enemy.Name);
                Console.WriteLine("Сила вашей карты: " + chosenCard.Power);
                Console.WriteLine("Здоровье врага: " + enemy.Health);

                // Проверяем условия для победы
                if (IsVictory(chosenCard, enemy))
                {
                    Console.WriteLine("Вы победили врага!");
                    score++;
                }
                else
                {
                    Console.WriteLine("Вы проиграли...");

                    // Завершаем игру и выводим очки
                    break;
                }

                // Сбрасываем одну карту и получаем случайную новую
                ReplaceCard(deck);

                Console.WriteLine("Ваши очки: " + score);
                Console.WriteLine("-------------------------");
            }

            Console.WriteLine("Игра окончена. Ваши очки: " + score);
            Console.ReadLine();
        }
        static ICard ChooseCard(List<ICard> deck)
        {
            Console.WriteLine("Выберите карту для сражения, введя номер:");
            for (int i = 0; i < deck.Count; i++)
            {
                Console.WriteLine(i + 1 + ") " + deck[i].Name +
                                  ", стихия: " + deck[i].Element +
                                  ", сила: " + deck[i].Power +
                                  ", мировоззрение: " + deck[i].Morality + "-" + deck[i].Ethic);
            }

            int choice = Convert.ToInt32(Console.ReadLine());
            return deck[choice - 1];
        }
        static IEnemy CreateRandomEnemy()
        {
            Random random = new Random();
            string[] elements = { "огонь", "воздух", "вода", "земля" };
            string element = elements[random.Next(0, 4)];
            int health = random.Next(1, 21);
            int morality = random.Next(1, 4); ;
            int ethic = random.Next(1, 4);

            return new Enemy("Враг", element, health, morality, ethic);
        }
        static bool IsVictory(ICard card, IEnemy enemy)
        {
            // Проверяем применение силы
            if (enemy.Element == card.Element)
            {
                // Применяем модификатор к силе карты
                double modifiedPower = card.Power * 0.7;
                if (modifiedPower >= enemy.Health)
                    return true;
            }
            else
            {
                if (card.Power >= enemy.Health)
                    return true;
            }
            
            double diff = Math.Abs(card.Morality - enemy.Morality) +
                          Math.Abs(card.Ethic - enemy.Ethic);
            double maxDiff = 9;
            double chance = 1 - diff / maxDiff;
            Random random = new Random();
            double randomDouble = random.NextDouble();

            if (randomDouble < chance)
                return true;

            return false;
        }
        static void ReplaceCard(List<ICard> deck)
        {
            Random random = new Random();
            int index = random.Next(0, deck.Count);
            deck.RemoveAt(index);

            // Добавляем новую карту в колоду
            deck.Add(new Card("Новая карта", "случайная стихия",
                random.Next(1, 21), random.Next(1, 4), random.Next(1, 4)));
        }

    }
}