# Roulette game

Gambling game of roulette made using UNITY and C#.

Main goal is to bet on one of 3 colors (red, black, green) and win as much as you can before you lose all your money.
Most of assets were made using Photoshop.
I hope it's gonna help someone's gambling addiction since it's totally free to play.

# <H1>Roulette – Script Instructions:</H1>
There are 3 main scripts:
Generate:
- Red/Green/Black Prefab - Objects that represent one slot in roulette.
- Slots Container - An empty object that is a parent of all instantiated prefabs.
- Total Slots - Amount of slots you want to instantiate.
Roulette Scroll:
- Slots Container - Same object that Generate.cs is using.
- Min Scroll Speed - Minimum value of how fast roulette is going to move.
- Max Scroll Speed - Maximum value of how fast roulette is going to move.
- Slot Width - Width of each instantiated slot.
- Red/Green/Black Button - Objects of type button that when you press it, it places a bet on chosen color.
Cash Balance:
- Coins Text - Shows amount of coins you have.
- Coins - Starting amount of coins.
- Coins Input Field - Object of type Input Field where you can choose how much you want to bet.
- Red/Green/Black Text - Shows amount of coins that you bet of each color.

![generation](https://github.com/user-attachments/assets/61e1bdb8-b2c4-4421-a1e2-5eaba66081a0)

![cash](https://github.com/user-attachments/assets/453129e1-b343-4817-9762-3f92ae2856a9)
