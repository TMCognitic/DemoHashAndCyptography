using System;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;

namespace DemoHashage
{
    class Program
    {
        static void Main(string[] args)
        {
            string preHash = "f0U5i10@O?YT8&O80*9pFf_*CRJ1s0daqjZ+WoBQchBXG=MORtg2LcZJKg2fH_U8S4zA13|+AT6caYG$WP^X&s5??bDoxRpZWG3b$D!z?DH6HKH^c$*+K-Rh?*4DhiUl0-O|fTa4P#_x6T2+KRkNoWZN$0WtADnGjcRf=f_$3h?PWv?dLGuKWp|+U41ezH^$7yK&kZYIXQoX0sHjkcx|?95IPUW%Yw#?H6esv@=JuHPt-%Z+dVqfR%#kX4agF_lGcKkSGtJ00v!Sq9#BoPJTf5DZw57hwY?i%-!9JTXZFPmiiAz9L$-TBX@L$X@!dLZItF-xAGuD4k1p6efjYZEL+7N3-s9r!TY%cGbD9Tr2FpgsV3*FN7?#4pO!%K-=Lc_skAp61wXbq!SmE|AEN+FhckCFdmPZH1O+7!2DE!d03-+2k%=x6es1XF$pEM3_@@^OP2%Lu^XPC#z6R6pS?dk2I%j$^YZ7P-nubFw|P=m+%YeVi7551w4GlF+5_O43I^Y_!6cXnr!$H2U^YvpSwyLwu7+l6CfR@ILSo*4wbNwQfsLK*uHpg4Kq&b^CsHShjXrgy5T!#7XVgWj^Tqwj0?!e0lPa&WK$R$SS@-c$s*&sMJmf56YQFvDWJ8u?A$#%IRn$b!x6!b77ToYJetI@a+3IK5h%PM8O4%d9Rul^Nxts&dT&J3a&shCEHubvO?VyX+4RdbDZd=T9G2l-9jDMB5Z=Hg!b3A*gMHLMJuzWEOsQ0YL^4v!YQ4jSxKGN5Sz_Tvw4k@CJ7@@4QNiDVY88nF?Re1oa^mLhc?0BIqafyKq4639gwU78qSuNpi?J2YVa5iE==EW_p45+D|EJ83J|?35eYlogkwVj@Om7S|pdxrOm=lFGedQ1yZ4#BAH3vKEc^%x#|mVtN&bfA3LZr%Yo5Jr#FPjfz@!srM*MIF@&Xc4IhhF|7mjB4sj3aG4vk4bL%4nWVhGNymf|z5k3v%TG0nH$PuVIhiLZG9?_hvBd7|mnmd&wwAY4&-%x765^ERA6_Iu*bk!1exL*%$ovVZS9P6zF%bVrp8%16u@5Mee@utB*I6CMD?8MO3PRhRqIcO@Mc?%Isa2#gHDj+k%#AFHlaAAdFHT!kU-?%mGAK=hGh0@Iqq3y!bdZY*P*bGd4eaxbSvDfl9DipPO^ILzCHH$CM3R!OdxhuO1?N+GijV9gZ&phpd@T+g0*-HVaRslfC|QvaCk3cWsA4ePiw@wrRdy18Tw&Su&5^zkSi@@U!vpp4zoyVF4?odpaH2TkurxtHzh5Cq?HBQh0f$5wsqm$0I8l-tZnz5BZDlqdCAwO9MVHzriYb1VZ^qX^uJ*RJ?Qg9QrX@Sf2z4$ot$QlXAqMi1YlpHYF?XkM#3xfE?NI9T4#H6?%=yq#ts&QG@6%8SnXUY!COTw?pBdYdll7CXZ7T+o2JpWQ-lG5$2S9Oy=^fB&&MvEnLra5XzqS5K$h$3VqB4w_fTB0_nB=o6y?z2l_mFb0mG#syuGcMKp_^nY_gQhtU_jOLQ8!jYO5RXi%_-M72_X2sllnKAZIFFualXTg0JEG-S$x+v*4lbKYVcepB-p8$OrSmOitqpo-NmW+7i7tpvU6G@dsZDCHXo&^V4nKt==obCxUAiM8&T3FiJEA!I_q$jW59j5oMicN?vFf=t_cDB*pa2kw&C?*weGO$4$a$v324IleHxVI=0cOk-9kg-x1n*9=Crt+n5-8$OSlJCJcf5P1|QB69hwRys|dbJumXXB^Y0Vj0iW+bAx5td|QElo%%N4Eh!wI6z1j_*uIRQ%8oL20?|vo^N9o8Bl=1D0dETVl#ImegqZYE=XHK+mDE7qRA3--di^gu*r-&vg^re7MR8owS*v42?Nyj%VF!Iw5VoSs9Cqlz^mCM^=yFA0#1KrSHA-jneR&$##ScUudyuFy7BX96Ftv+7?XOZN!L@8_B&Z1^Y=bCuwB67%N#vbOz^2liWTdt?UfGG=u=AS?_4azP&gNvVgHL$zhz#j%xSw$BU#04qr6AyLX!cuCZ77ir7CcXURd^Ue6|rpD|IMsO^ecNa@dBdbi";
            string postHash = "Ei7^whTC3lJ|WZJ!9y$#_+_DZs0vr$d0MB35WGnMrfzlPg&9T8yKDi1$yBm^N9Yr3?-PJva1g8LkjRoyy@YC0udBzF3eUF7dWegu&Om&$|?fe1EXX0KjDS!-%*|BDN%CAFP3rKeJIHgrlJH3FORcfo98&o|zg4^cEtweeEYCYOtB+aaloqbSpI|vbr+oJxA2FNMO23FyEMsHyt$Z663pkg6nZf76^vNpCXwwp^5ja@S5q18G=jrB#W0EcNhsDlIT@U5M6iOfcSG&buGd#8G3yR51?=rUoCEWA%^aJ_oyBl6#PdlPre06t!wqdJMjl#jRQCKPD9RqaBae5F$ZO0^tqS5i|?fmla3$%UeA-aa!B03JfROTnch!FA5AwEU_kb%0frEYOrqud37gWN346ZUf_2LdVn$E+SWJmmY+kL^C?ym!tI45C%IQysU9ebDKAjfSgaCnJ0gUQ%fo#jzFwlE5ZpLOUI3$a|@th9jb^ASV*26cR?_Z!xhIGk#&0K7mt6IDOq^jOdbE-S0%osZ=McxwMIPPyo1_nAQRQr14gjL&kmNNX@TN4Yo=uM3#xiq*sRxRt4=R3^#VdSriItteQE2%8nZ|7iX9sqhK|4STwGzfmO4HMf2h&QD+gaAQ*pW@WaFvM4aa*J@8wtUPtmD2tk0*IBGH^$hzYjc3X7Js5tMnHv--FnRYrh^y6eaUY0mfc%IU#mf+PV7OU8hskE|XcL@?9$2^rZt@wjKG6xks6a@fjMnAn-|F@y|oc*s=Gtzk79TMayv3f*1s8|swwSJT@aaShsvE65SttNODZJ81=?QK6r!H3znGRTaR2YqMxFHD5EY3nR@6FmwYqmxY-7#?w38jqZ*a+Ej*=r081uG6Bp#ZnI&f?_VJAZs&8l9LYg&p-6AK25DM7?2yq1GDl|4xCiwVpLsA2FegBfFLM+z?WJor_yQViF4PF2M%m@^C2-87eBH#m&Cz|9#V_0Wx!wr$_%=x8a8=bltP@r+7S6SCwP4+PK-&KJ*nyh2hfztJc8sOJSgCuIoU@lGy=9*#chfjF@7d=aDhG?#9^HxfA#84?-8q22rK%S8J8ZYi5Kokjd_heBZ9Ql7cwLq%&P0fk2-wsk&gN-I1pY=u2FCQDGtpOEo@A-i+3r#lNiWnmtl&CI5cL-k$cMU5!?GYEy^r9*=lZ2AWpOZ+t!RyQIPua4WnXSd_7KV%^5s84EbP8BP_aYj!xkyE73bI^D89jtfv!eQ$J$IvWKR&3ETk2e6ro&1mJ*%NCv%@KrR?PC?^Ttho9#8_Y=2s*#$vNjCQ1HQetPET&wfWWU*NHPVHz6wWqmEQ^SIp6opRgGck@0W+8N+fi_CGq5uJwA8KakJ?Co1+%V_nRjk+0mY&5xAvyvf&Cc%vtkVb#eziGrFF1GWsumgbKmxvBMWoLvP5|#fc0gENaI?Ad+!HR+C#NJ^#Zk|k!X5Vpsw$$AO&65A=vNZlI_S9z4Z$qf%edJiLD9F=B4c_*x6?-EDY2pvP3EOA+8tYawjnrn*2^oM|&xsTUfW@WkjOClxa^*i&=3LNrD#DAB+Ki%iy6VcA|NU!GJ+0B4zC+YO&$4Ij9kvW72L%KvscPEdQ-=@1QCujoP@lw%4b-UL8YA8XPd?wzB4ol?3rAQ^5T$j=3HnjB|idnUv_N4fT?x^nR5n56@!4dXasv-GCY%C!aGm$ptU7mZYpmEn6AOrR$^4&wLxm5kljs6z8z08dMIrO#_^DleQNWDvaFneyATiJSc!qTuz6-6X0DHAA!_0C55B3%|Vi%@qobIPfM*-BXM2c05xSLTdyahFg?Lqsj_ND1KFBTqk9F_3tST|@*XGNnY&s0_Ja_jJJkS!W6WcpML|-6y1a|nUTju02Wxou#692m35GjnPOSByzKxZdW*aT8r@uOmG_TFYgSI%?bm-XEO&5OWRY5gHFdag@rrcV5DjzGwdSDemy|uYwb9Vz9tALpQKZ+h9!nb^h1y_yP-$vTsjXzc%gYW2yz^x&BUt|jxjMO5MMKhl=jpqV-#N6BZk5YRu@HVmz^Ub##k%0A3OGcLf31%1f5+MD";
            string passwd = "test1234=";

            UnicodeEncoding unicodeEncoding = new UnicodeEncoding();

            byte[] result;

            HashAlgorithm hashAlgorithm = new SHA512Managed();
            //HashAlgorithm hashAlgorithm = MD5.Create();

            result = hashAlgorithm.ComputeHash(unicodeEncoding.GetBytes(preHash + passwd + postHash));

            string hashPasswd = Convert.ToBase64String(result);
            byte[] bytes = Convert.FromBase64String(hashPasswd);

            Console.WriteLine($"Longeur du résultat du Hashage : {result.Length}");
            Console.WriteLine(hashPasswd);

            //Récupération de la DB

            //Console.WriteLine("Attention SHA512 n'est pas le SHA2_512 de Sql Server!!!");
            //using (SqlConnection db = new SqlConnection())
            //{
            //    db.ConnectionString = @"Data Source=AW-BRIAREOS\SQL2016DEV;Initial Catalog=GestToDo;Integrated Security=True";

            //    using (SqlCommand command = db.CreateCommand())
            //    {
            //        //command.CommandText = "Select passwd from [User] where Id = 1;";
            //        //or
            //        command.CommandText = "SELECT CAST(N'' AS XML).value('xs:base64Binary(xs:hexBinary(sql:column(\"passwd\")))', 'VARCHAR(MAX)') from [User] where Id = 1;";

            //        db.Open();
            //        string dbHash = (string)command.ExecuteScalar();

            //        Console.WriteLine($"Longeur du résultat du Hashage : {dbHash.Length}");
            //        Console.WriteLine(dbHash);
            //    }
            //}
        }
    }
}
