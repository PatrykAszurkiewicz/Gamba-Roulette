# Roulette game

<H1>🎰 Roulette Game</H1>
A simple gambling-style roulette game created in Unity (C#).

The main goal is to bet on one of three colors — Red, Black, or Green — and try to win as much as possible before you lose all your coins.
Most of the visual assets were created in Photoshop.</br>
<i>Hopefully, this can help someone cope with gambling urges in a harmless way — it's completely free to play.</i>

<H1>🧠 How It Works</H1>
You start with a fixed number of coins and place bets on one or more colors.
If the wheel lands on your color, you win a multiplier of your bet. If not — you lose that amount.

# <H1>Roulette – Script Instructions:</H1>
There are 3 main scripts:
Generate:</br>
- Red/Green/Black Prefab - Objects that represent one slot in roulette.
- Slots Container - An empty object that is a parent of all instantiated prefabs.
- Total Slots - Amount of slots you want to instantiate.
Roulette Scroll:
- Slots Container - Same object that Generate.cs is using.
- Min Scroll Speed - Minimum value of how fast roulette is going to move.
- Max Scroll Speed - Maximum value of how fast roulette is going to move.
- Slot Width - Width of each instantiated slot.
- Red/Green/Black Button - Objects of type button that when you press it, it places a bet on chosen color.
Cash Balance:</br>
- Coins Text - Shows amount of coins you have.
- Coins - Starting amount of coins.
- Coins Input Field - Object of type Input Field where you can choose how much you want to bet.
- Red/Green/Black Text - Shows amount of coins that you bet of each color.

![generation](https://github.com/user-attachments/assets/61e1bdb8-b2c4-4421-a1e2-5eaba66081a0)</br>

![cash](https://github.com/user-attachments/assets/453129e1-b343-4817-9762-3f92ae2856a9)</br>

![Roulette](https://github.com/user-attachments/assets/424466f5-4c95-479b-bfa8-c7958ab61550)
