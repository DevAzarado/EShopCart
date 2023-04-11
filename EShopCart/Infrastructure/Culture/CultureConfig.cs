using System.Globalization;
using System.Threading
    ;
namespace EShopCart.Infrastructure.Culture
{
    public static class CultureConfig
    {

        public static void ConfigCulture()
        {
            //Definir a cultura padrão que vc deseja usar para a sua aplicação utilizando o método
            CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("en-US");
            //Definir a cultura padrão para as operações de formatação de números e datas usando o método 
            CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("pt-BR");
        }

        

    }
}
