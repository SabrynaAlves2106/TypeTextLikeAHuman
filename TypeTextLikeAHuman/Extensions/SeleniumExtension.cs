using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;


namespace TypeTextLikeAHuman.Extensions;

public static class SeleniumExtension
{
    public static void TypeTextLikeAHuman(this IWebElement element, string texto, bool allowError = false)
    {
        var palavras = texto.Split(' ');
        var ultimaPalavra = palavras.Count();
        int index = 0;

        Random rnd = new Random();

        foreach (string palavra in palavras)
        {
            Thread.Sleep(rnd.Next(150, 400));

            foreach (char letra in palavra)
            {
                element.SendKeys(letra.ToString());


                //Se for par digita rapido se for impar mais devagar
                if (rnd.Next(0, 10) % 2 == 0)
                {
                    Thread.Sleep(rnd.Next(100, 150));
                }
                else
                {
                    Thread.Sleep(rnd.Next(200, 300));
                }


                //Erra uma letra e depois apaga
                if (rnd.Next(0, 100) % 9 == 0 && allowError)
                {
                    element.SendKeys(Convert.ToChar(rnd.Next(97, 122)).ToString());
                    Thread.Sleep(rnd.Next(150, 300));
                    element.SendKeys(Keys.Backspace);
                }

            }

            //Insere o espaço que foi removido com o Split exceto para a ultima palavra
            if (++index != ultimaPalavra)
                element.SendKeys(" ");
        }
    }

    public static IWebElement WaitElement(this IWebDriver driver, By by, int seconds = 10)
    {
        try
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(seconds));
            var element = wait.Until(d => d.FindElement(by));
            return element;
        }
        catch
        {
            return null;
        }
    }
}
