# CoinHive DLL
This is a very small and simple library to implement the CoinHive miner (a JavaScript miner) into a C# program, using selenium.
It uses a "verification script" which you can adjust to how many threads you want to use and some various other settings. It will check whether a specified amount of hashes is accepted by CoinHive and will then continue the program.

## Usage of the DLL
### Prerequisites
- You need a C# program (on the Windows platform)
- You need to install Selenium & Selenium.Webdriver.ChromeDriver (installable through NuGet package manager)
- It will always need an internet connection

### Adding to your program
You can just make a reference to the DLL through "Add Reference" in your solution browser. After that install the required NuGet packages.
You have to import the library by typing this in the top of your file:
```
using CoinHive;
```

After that you can declare an object like this:
Everything between * must be replaced by the user.

```
CoinHive.CoinHive chMiner = new CoinHive.CoinHive(" *URL OF SCRIPT TO RUN HERE* ", "hidden");
chMiner.Ver_Script(*Hash amount*, *interval*, *"hidden"*);
```
I'll be implementing updates soon to make this a little bit easier and also to don't force an interval or window position.

### How does it work?
It's very simple, you upload the verification script (that can be adjusted in anyway you like), and then it'll be able to open that page in the selenium chromedriver and it will keep checking untill a certain amount of hashes is reached. After that the browser will be closed.
The browser is completely hidden (there is no icon in the taskbar or no window on the screen), it can be seen in the process list.

## Usage of the script
The script is now set to redirect to a page after a certain amount of hashes though that is not obligated for the C# program. Please do note that you can't change the ID's of the acceptedHashes... so Selenium can grab it by ID (might change this later that you can set this manually through the library.

### Prerequisites
- The script MUST be run on a web server (either local or online) in order to run.
- Some minor HTML + CSS knowledge to patch up the HTML
- An account on CoinHive and either need a public or private token inserted in the JavaScript file

### Adjusting the script
The script can be adjusted, I highly recommend not enabling autoThreads since it will slow the PC's too much down in my opinion (it's stille experimental as well).

You can find all the options you can change on the CoinHive website: https://coin-hive.com/documentation/miner

#### Note that I'm not related with CoinHive in anyway nor did I code the Coin-hive JavaScript miner.
