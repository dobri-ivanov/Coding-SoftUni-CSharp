using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Xml.Linq;

namespace FootballTeam.Tests
{
    public class Tests
    {
        private string playerName = "Ronaldo";
        private int playerNumber = 7;
        private string position = "Midfielder";
        private FootballPlayer footballPlayer;


        private FootballTeam footballTeam;
        private string teamName = "Name";
        private int teamCapacity = 15;

        [SetUp]
        public void Setup()
        {
            footballPlayer = new FootballPlayer(playerName, playerNumber, position);
            footballTeam = new FootballTeam(teamName, teamCapacity);
        }

        [Test]
        public void Player_Const()
        {
            footballPlayer = new FootballPlayer(playerName, playerNumber, position);
            footballTeam = new FootballTeam(teamName, teamCapacity);
            Assert.That(playerName, Is.EqualTo(footballPlayer.Name));
            Assert.That(playerNumber, Is.EqualTo(footballPlayer.PlayerNumber));
            Assert.That(position, Is.EqualTo(footballPlayer.Position));
            Assert.That(0, Is.EqualTo(footballPlayer.ScoredGoals));
        }
        [Test]
        public void Player_Const2()
        {
            footballPlayer = new FootballPlayer(playerName, playerNumber, position);
            footballTeam = new FootballTeam(teamName, teamCapacity);
            Assert.That(playerNumber, Is.EqualTo(footballPlayer.PlayerNumber));
        }
        [Test]
        public void Player_Const3()

        {
            footballPlayer = new FootballPlayer(playerName, playerNumber, position);
            footballTeam = new FootballTeam(teamName, teamCapacity);
            Assert.That(position, Is.EqualTo(footballPlayer.Position));
        }
        [Test]
        public void Player_Const4()
        {
            footballPlayer = new FootballPlayer(playerName, playerNumber, position);
            footballTeam = new FootballTeam(teamName, teamCapacity);
            int n = 0;
            Assert.That(n, Is.EqualTo(footballPlayer.ScoredGoals));
        }
        [Test]
        public void Player_Const5()
        {
            footballPlayer = new FootballPlayer(playerName, playerNumber, position);
            footballTeam = new FootballTeam(teamName, teamCapacity);
            Type teamType = footballPlayer.GetType();
            FieldInfo field1 = teamType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance).FirstOrDefault(x => x.Name == "scoredGoals");

            int value = (int)field1.GetValue(footballPlayer);
            Assert.That(0, Is.EqualTo(value));
        }
        [TestCase (null)]
        [TestCase ("")]
        public void Player_Name(string name)
        {
            footballPlayer = new FootballPlayer(playerName, playerNumber, position);
            footballTeam = new FootballTeam(teamName, teamCapacity);
            Assert.Catch<ArgumentException>(() => footballPlayer = new FootballPlayer(name, playerNumber, position));
        }
        [TestCase("Name")]
        public void Player_Name2(string name)
        {
            footballPlayer = new FootballPlayer(playerName, playerNumber, position);
            footballTeam = new FootballTeam(teamName, teamCapacity);
            footballPlayer = new FootballPlayer(name, playerNumber, position);
            Assert.Pass();
        }
        [TestCase(null)]
        [TestCase("")]
        public void Player_Namadade2(string name)
        {
            Assert.Catch<ArgumentException>(() => footballTeam.Name = name);
        }
        [TestCase("asd")]
        public void Player_Namadad13e2(string name)
        {
            footballTeam.Name = name;
            Assert.Pass();
        }
        [TestCase(-5)]
        [TestCase(0)]
        [TestCase(25)]
        public void Player_Number(int number)
        {
            footballPlayer = new FootballPlayer(playerName, playerNumber, position);
            footballTeam = new FootballTeam(teamName, teamCapacity);
            Assert.Catch<ArgumentException>(() => footballPlayer = new FootballPlayer(playerName, number, position));
        }
        [TestCase(1)]
        [TestCase(21)]
        [TestCase(15)]
        public void Player_Number2(int number)
        {
            
            Assert.Pass();
        }
        [TestCase("Goalkeeper")]
        [TestCase("Forward")]
        [TestCase("Midfielder")]
        public void Player_Possition(string possition)
        {
            footballPlayer = new FootballPlayer(playerName, playerNumber, position);
            footballTeam = new FootballTeam(teamName, teamCapacity);
            footballPlayer = new FootballPlayer(playerName, playerNumber, possition);
            Assert.Pass();
        }
        [TestCase("uNKNOWN")]
        public void Player_Possition2(string possition)
        {
            footballPlayer = new FootballPlayer(playerName, playerNumber, position);
            footballTeam = new FootballTeam(teamName, teamCapacity);
            Assert.Catch<ArgumentException>(() => footballPlayer = new FootballPlayer(playerName, playerNumber, possition));
        }

        [Test]
        public void Player_Score()
        {
            footballPlayer = new FootballPlayer(playerName, playerNumber, position);
            footballTeam = new FootballTeam(teamName, teamCapacity);
            footballPlayer.Score();
            int n = 1;
            Assert.That(n, Is.EqualTo(footballPlayer.ScoredGoals));
        }
        [Test]
        public void Player_Score2()
        {
            footballPlayer = new FootballPlayer(playerName, playerNumber, position);
            footballTeam = new FootballTeam(teamName, teamCapacity);
            footballPlayer.Score();
            Type teamType = footballPlayer.GetType();
            FieldInfo field1 = teamType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance).FirstOrDefault(x => x.Name == "scoredGoals");

            int value = (int)field1.GetValue(footballPlayer);
            Assert.That(1, Is.EqualTo(value));
        }
        [Test]
        public void Team_Const()
        {
            footballPlayer = new FootballPlayer(playerName, playerNumber, position);
            footballTeam = new FootballTeam(teamName, teamCapacity);
            Assert.That(teamName, Is.EqualTo(footballTeam.Name));
            Assert.That(teamCapacity, Is.EqualTo(footballTeam.Capacity));
            Assert.That(0, Is.EqualTo(footballTeam.Players.Count));
            Assert.True(footballTeam.Players != null);
        }
        [Test]
        public void Team_Const2()
        {
            footballPlayer = new FootballPlayer(playerName, playerNumber, position);
            footballTeam = new FootballTeam(teamName, teamCapacity);
            Assert.That(teamCapacity, Is.EqualTo(footballTeam.Capacity));
        }
        [Test]
        public void Team_Const3()
        {
            footballPlayer = new FootballPlayer(playerName, playerNumber, position);
            footballTeam = new FootballTeam(teamName, teamCapacity);
            int n = 0;
            Assert.That(n, Is.EqualTo(footballTeam.Players.Count));
        }
        [Test]
        public void CONST25()
        {
            footballPlayer = new FootballPlayer(playerName, playerNumber, position);
            footballTeam = new FootballTeam(teamName, teamCapacity);
        }
        [Test]
        public void CONST4()
        {
            footballPlayer = new FootballPlayer(playerName, playerNumber, position);
            footballTeam = new FootballTeam(teamName, teamCapacity);
            Assert.True(footballTeam.Players != null);
        }
        [Test]
        public void CONST5()
        {
            footballPlayer = new FootballPlayer(playerName, playerNumber, position);
            footballTeam = new FootballTeam(teamName, teamCapacity);
            Type teamType = footballTeam.GetType();
            FieldInfo field1 = teamType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance).FirstOrDefault(x => x.Name == "players");

            var value = field1.GetValue(footballTeam);
            Assert.True(value != null);
        }
        [TestCase (null)]
        [TestCase ("")]
        public void Team_Name(string name)
        {
            footballPlayer = new FootballPlayer(playerName, playerNumber, position);
            footballTeam = new FootballTeam(teamName, teamCapacity);
            Assert.Catch<ArgumentException>(() => footballTeam = new FootballTeam(name, teamCapacity));
        }
        [TestCase(null)]
        [TestCase("")]
        public void Team_Na31me(string name)
        {
            Assert.Catch<ArgumentException>(() => footballTeam.Name = name);
        }
        [TestCase("Test")]
        public void Team_Name2(string name)
        {
            footballTeam.Name = name;
            Assert.Pass();
        }
        [TestCase(25)]
        [TestCase(15)]
        public void Team_Capacity1(int currentCapacity)
        {
            footballTeam.Capacity = currentCapacity;
            Assert.Pass();
        }
        [TestCase(-1)]
        [TestCase(7)]
        [TestCase(0)]
        public void Team_Capacity2(int currentCapacity)
        {
            Assert.Catch<ArgumentException>(() => footballTeam.Capacity = currentCapacity);
        }
        [Test]
        public void Team_Add()
        {
            string expected = $"Added player {footballPlayer.Name} in position {footballPlayer.Position} with number {footballPlayer.PlayerNumber}";
            string returned = footballTeam.AddNewPlayer(footballPlayer);
            Assert.That(expected, Is.EqualTo(returned));
            Assert.That(1, Is.EqualTo(footballTeam.Players.Count));
        }
        [Test]
        public void Team_Add2()
        {
            string expected = $"Added player {footballPlayer.Name} in position {footballPlayer.Position} with number {footballPlayer.PlayerNumber}";
            string returned = footballTeam.AddNewPlayer(footballPlayer);
            int n = 1;
            Assert.That(n, Is.EqualTo(footballTeam.Players.Count));
            Assert.That(expected, Is.EqualTo(returned));
        }
        [Test]
        public void Team_Add3()
        {
            for (int i = 0; i <= 15; i++)
            {
                footballTeam.AddNewPlayer(footballPlayer);
            }
            string returned = footballTeam.AddNewPlayer(footballPlayer);
            string expected = "No more positions available!";
            Assert.That(expected, Is.SameAs(returned));
        }
        [Test]
        public void Team_Add5()
        {
            for (int i = 1; i <= 18; i++)
            {
                footballTeam.Players.Add(footballPlayer);
            }
            
            
            string returned = footballTeam.AddNewPlayer(footballPlayer);

            string expected = "No more positions available!";
            Assert.That(expected, Is.SameAs(returned));
        }
        [Test]
        public void Team_Pick()
        {
            footballTeam.AddNewPlayer(footballPlayer);
            FootballPlayer currentPlayer = footballTeam.PickPlayer(footballPlayer.Name);
            Assert.That(footballPlayer, Is.SameAs(currentPlayer));
        }
        [Test]
        public void Team_Pick7()
        {
            footballTeam.AddNewPlayer(footballPlayer);
            FootballPlayer player = new FootballPlayer("asd", playerNumber, position);
            footballTeam.AddNewPlayer(player);
            FootballPlayer currentPlayer = footballTeam.PickPlayer(player.Name);
            Assert.That(player, Is.SameAs(currentPlayer));
        }
        [Test]
        public void Team_Pick2()
        {
            
            FootballPlayer currentPlayer = footballTeam.PickPlayer(footballPlayer.Name);
            Assert.That(currentPlayer, Is.SameAs(null));
        }
        [Test]
        public void Team_PlayerScore()
        {
            footballTeam.AddNewPlayer(footballPlayer);
            string returned = footballTeam.PlayerScore(footballPlayer.PlayerNumber);
            string expected = $"{footballPlayer.Name} scored and now has {footballPlayer.ScoredGoals} for this season!";
            Assert.That(expected, Is.EqualTo(returned));
        }
        [Test]
        public void Team_PlayerScore2()
        {
            Assert.Catch<NullReferenceException>(() => footballTeam.PlayerScore(footballPlayer.PlayerNumber));
        }
        [Test]
        public void Final()
        {
            footballTeam.AddNewPlayer(footballPlayer);
            Type teamType = footballTeam.GetType();
            FieldInfo field1 = teamType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance).FirstOrDefault(x => x.Name == "players");

            List<FootballPlayer> list1 = (List<FootballPlayer>)field1.GetValue(footballTeam);
            int count = list1.Count;
            Assert.That(list1, Is.SameAs(footballTeam.Players));

        }
        [Test]
        public void Final2()
        {
            footballPlayer.Score();
            Type teamType = footballPlayer.GetType();
            FieldInfo field1 = teamType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance).FirstOrDefault(x => x.Name == "scoredGoals");

            int value = (int)field1.GetValue(footballPlayer);
            Assert.That(value, Is.EqualTo(footballPlayer.ScoredGoals));

        }
        [Test]
        public void Final3()
        {
            footballPlayer.Score();
            Type teamType = footballPlayer.GetType();
            FieldInfo field1 = teamType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance).FirstOrDefault(x => x.Name == "scoredGoals");

            int value = (int)field1.GetValue(footballPlayer);
            Assert.That(1, Is.EqualTo(value));

        }
    }
}