using System;
using Interop.ErpBS900;         // Use Primavera interop's [Path em C:\Program Files\Common Files\PRIMAVERA\SG900]
using Interop.StdPlatBS900;
using Interop.StdBE900;
using Interop.IGcpBS900;
using ADODB;




public class PriEngine
{

    public static StdPlatBS Platform { get; set; }
    public static ErpBS Engine { get; set; }

    public PriEngine()
	{
	}

    public static bool inicializarEmpresa(String empresa, String usuario, String senha)
    {
        StdBSConfApl objAplConf = new StdBSConfApl();
        stdPlatBs plataforma = new stdPlatBs();

        

    }
}
