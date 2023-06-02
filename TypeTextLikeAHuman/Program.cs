
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TypeTextLikeAHuman.Extensions;

string texto = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse eros mi, " +
    "dignissim a auctor in, sollicitudin at odio. Integer non neque maximus tellus sagittis feugiat. " +
    "Proin condimentum pulvinar leo, id condimentum ligula vehicula imperdiet. Aliquam eu elit non " +
    "lectus blandit luctus sed at ex. Phasellus tempus elit at suscipit viverra. Mauris imperdiet" +
    " nulla nec vestibulum malesuada. Phasellus urna sem, commodo ac dolor et, tempor mollis felis." +
    " Etiam sed ex non nisl eleifend dignissim. Maecenas mattis condimentum volutpat. Maecenas" +
    " pharetra egestas ex et molestie. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices" +
    " posuere cubilia curae; Curabitur suscipit, felis ut.";


ChromeDriver driver = new ChromeDriver();

driver.Navigate().GoToUrl("https://www.google.com/intl/pt-PT/inputtools/try/");


driver.WaitElement(By.XPath("//*[@id='demobox']")).TypeTextLikeAHuman(texto);
