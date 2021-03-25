﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TVS.Dapper.Liass;
using PostSharp.Patterns.Model;
using TVS.Core.Models.Liass;
using TVS.Core.Interfaces.Liass;
using TVS.Core;
using TVS.Dapper.Settings;

namespace TVS.Dapper.Liass
{
    public partial class F6001Repository 
    {
        const string InsertSQL= @"INSERT INTO [dbo].[F6001]
           ([SocieteNo]
           ,[ExerciceId]
           ,[F60010001]
           ,[F60010002]
           ,[F60010003]
           ,[F60010004]
           ,[F60010005]
           ,[F60010006]
           ,[F60010007]
           ,[F60010008]
           ,[F60010009]
           ,[F60010010]
           ,[F60010011]
           ,[F60010012]
           ,[F60010013]
           ,[F60010014]
           ,[F60010015]
           ,[F60010016]
           ,[F60010017]
           ,[F60010018]
           ,[F60010019]
           ,[F60010020]
           ,[F60010021]
           ,[F60010022]
           ,[F60010023]
           ,[F60010024]
           ,[F60010025]
           ,[F60010026]
           ,[F60010027]
           ,[F60010028]
           ,[F60010029]
           ,[F60010030]
           ,[F60010031]
           ,[F60010032]
           ,[F60010033]
           ,[F60010034]
           ,[F60010035]
           ,[F60010036]
           ,[F60010037]
           ,[F60010038]
           ,[F60010039]
           ,[F60010040]
           ,[F60010041]
           ,[F60010042]
           ,[F60010043]
           ,[F60010044]
           ,[F60010045]
           ,[F60010046]
           ,[F60010047]
           ,[F60010048]
           ,[F60010049]
           ,[F60010050]
           ,[F60010051]
           ,[F60010052]
           ,[F60010053]
           ,[F60010054]
           ,[F60010055]
           ,[F60010056]
           ,[F60010057]
           ,[F60010058]
           ,[F60010059]
           ,[F60010060]
           ,[F60010061]
           ,[F60010062]
           ,[F60010063]
           ,[F60010064]
           ,[F60010065]
           ,[F60010066]
           ,[F60010067]
           ,[F60010068]
           ,[F60011001]
           ,[F60011002]
           ,[F60011003]
           ,[F60011004]
           ,[F60011005]
           ,[F60011006]
           ,[F60011007]
           ,[F60011008]
           ,[F60011009]
           ,[F60011010]
           ,[F60011011]
           ,[F60011012]
           ,[F60011013]
           ,[F60011014]
           ,[F60011015]
           ,[F60011016]
           ,[F60011017]
           ,[F60011018]
           ,[F60011019]
           ,[F60011020]
           ,[F60011021]
           ,[F60011022]
           ,[F60011023]
           ,[F60011024]
           ,[F60011025]
           ,[F60011026]
           ,[F60011027]
           ,[F60011028]
           ,[F60011029]
           ,[F60011030]
           ,[F60011031]
           ,[F60011032]
           ,[F60011033]
           ,[F60011034]
           ,[F60011035]
           ,[F60011036]
           ,[F60011037]
           ,[F60011038]
           ,[F60011039]
           ,[F60011040]
           ,[F60011041]
           ,[F60011042]
           ,[F60011043]
           ,[F60011044]
           ,[F60011045]
           ,[F60011046]
           ,[F60011047]
           ,[F60011048]
           ,[F60011049]
           ,[F60011050]
           ,[F60011051]
           ,[F60011052]
           ,[F60011053]
           ,[F60011054]
           ,[F60011055]
           ,[F60011056]
           ,[F60011057]
           ,[F60011058]
           ,[F60011059]
           ,[F60011060]
           ,[F60011061]
           ,[F60011062]
           ,[F60011063]
           ,[F60011064]
           ,[F60011065]
           ,[F60011066]
           ,[F60011067]
           ,[F60011068]
           ,[F60012001]
           ,[F60012002]
           ,[F60012003]
           ,[F60012004]
           ,[F60012005]
           ,[F60012006]
           ,[F60012007]
           ,[F60012008]
           ,[F60012009]
           ,[F60012010]
           ,[F60012011]
           ,[F60012012]
           ,[F60012013]
           ,[F60012014]
           ,[F60012015]
           ,[F60012016]
           ,[F60012017]
           ,[F60012018]
           ,[F60012019]
           ,[F60012020]
           ,[F60012021]
           ,[F60012022]
           ,[F60012023]
           ,[F60012024]
           ,[F60012025]
           ,[F60012026]
           ,[F60012027]
           ,[F60012028]
           ,[F60012029]
           ,[F60012030]
           ,[F60012031]
           ,[F60012032]
           ,[F60012033]
           ,[F60012034]
           ,[F60012035]
           ,[F60012036]
           ,[F60012037]
           ,[F60012038]
           ,[F60012039]
           ,[F60012040]
           ,[F60012041]
           ,[F60012042]
           ,[F60012043]
           ,[F60012044]
           ,[F60012045]
           ,[F60012046]
           ,[F60012047]
           ,[F60012048]
           ,[F60012049]
           ,[F60012050]
           ,[F60012051]
           ,[F60012052]
           ,[F60012053]
           ,[F60012054]
           ,[F60012055]
           ,[F60012056]
           ,[F60012057]
           ,[F60012058]
           ,[F60012059]
           ,[F60012060]
           ,[F60012061]
           ,[F60012062]
           ,[F60012063]
           ,[F60012064]
           ,[F60012065]
           ,[F60012066]
           ,[F60012067]
           ,[F60012068]
           ,[F60013001]
           ,[F60013002]
           ,[F60013003]
           ,[F60013004]
           ,[F60013005]
           ,[F60013006]
           ,[F60013007]
           ,[F60013008]
           ,[F60013009]
           ,[F60013010]
           ,[F60013011]
           ,[F60013012]
           ,[F60013013]
           ,[F60013014]
           ,[F60013015]
           ,[F60013016]
           ,[F60013017]
           ,[F60013018]
           ,[F60013019]
           ,[F60013020]
           ,[F60013021]
           ,[F60013022]
           ,[F60013023]
           ,[F60013024]
           ,[F60013025]
           ,[F60013026]
           ,[F60013027]
           ,[F60013028]
           ,[F60013029]
           ,[F60013030]
           ,[F60013031]
           ,[F60013032]
           ,[F60013033]
           ,[F60013034]
           ,[F60013035]
           ,[F60013036]
           ,[F60013037]
           ,[F60013038]
           ,[F60013039]
           ,[F60013040]
           ,[F60013041]
           ,[F60013042]
           ,[F60013043]
           ,[F60013044]
           ,[F60013045]
           ,[F60013046]
           ,[F60013047]
           ,[F60013048]
           ,[F60013049]
           ,[F60013050]
           ,[F60013051]
           ,[F60013052]
           ,[F60013053]
           ,[F60013054]
           ,[F60013055]
           ,[F60013056]
           ,[F60013057]
           ,[F60013058]
           ,[F60013059]
           ,[F60013060]
           ,[F60013061]
           ,[F60013062]
           ,[F60013063]
           ,[F60013064]
           ,[F60013065]
           ,[F60013066]
           ,[F60013067]
           ,[F60013068]
           ,[ActeDeDepot]
           ,[NatureDepot]
)
     VALUES
           (@SocieteNo,
           @ExerciceId,
           @F60010001, 
           @F60010002, 
           @F60010003, 
           @F60010004, 
           @F60010005, 
           @F60010006, 
           @F60010007, 
           @F60010008, 
           @F60010009, 
           @F60010010, 
           @F60010011, 
           @F60010012, 
           @F60010013, 
           @F60010014, 
           @F60010015, 
           @F60010016, 
           @F60010017, 
           @F60010018, 
           @F60010019, 
           @F60010020, 
           @F60010021, 
           @F60010022, 
           @F60010023, 
           @F60010024, 
           @F60010025, 
           @F60010026, 
           @F60010027, 
           @F60010028, 
           @F60010029, 
           @F60010030, 
           @F60010031, 
           @F60010032, 
           @F60010033, 
           @F60010034, 
           @F60010035, 
           @F60010036, 
           @F60010037, 
           @F60010038, 
           @F60010039, 
           @F60010040, 
           @F60010041, 
           @F60010042, 
           @F60010043, 
           @F60010044, 
           @F60010045, 
           @F60010046, 
           @F60010047, 
           @F60010048, 
           @F60010049, 
           @F60010050, 
           @F60010051, 
           @F60010052, 
           @F60010053, 
           @F60010054, 
           @F60010055, 
           @F60010056, 
           @F60010057, 
           @F60010058, 
           @F60010059, 
           @F60010060, 
           @F60010061, 
           @F60010062, 
           @F60010063, 
           @F60010064, 
           @F60010065, 
           @F60010066, 
           @F60010067, 
           @F60010068, 
           @F60011001, 
           @F60011002, 
           @F60011003, 
           @F60011004, 
           @F60011005, 
           @F60011006, 
           @F60011007, 
           @F60011008, 
           @F60011009, 
           @F60011010, 
           @F60011011, 
           @F60011012, 
           @F60011013, 
           @F60011014, 
           @F60011015, 
           @F60011016, 
           @F60011017, 
           @F60011018, 
           @F60011019, 
           @F60011020, 
           @F60011021, 
           @F60011022, 
           @F60011023, 
           @F60011024, 
           @F60011025, 
           @F60011026, 
           @F60011027, 
           @F60011028, 
           @F60011029, 
           @F60011030, 
           @F60011031, 
           @F60011032, 
           @F60011033, 
           @F60011034, 
           @F60011035, 
           @F60011036, 
           @F60011037, 
           @F60011038, 
           @F60011039, 
           @F60011040, 
           @F60011041, 
           @F60011042, 
           @F60011043, 
           @F60011044, 
           @F60011045, 
           @F60011046, 
           @F60011047, 
           @F60011048, 
           @F60011049, 
           @F60011050, 
           @F60011051, 
           @F60011052, 
           @F60011053, 
           @F60011054, 
           @F60011055, 
           @F60011056, 
           @F60011057, 
           @F60011058, 
           @F60011059, 
           @F60011060, 
           @F60011061, 
           @F60011062, 
           @F60011063, 
           @F60011064, 
           @F60011065, 
           @F60011066, 
           @F60011067, 
           @F60011068, 
           @F60012001, 
           @F60012002, 
           @F60012003, 
           @F60012004, 
           @F60012005, 
           @F60012006, 
           @F60012007, 
           @F60012008, 
           @F60012009, 
           @F60012010, 
           @F60012011, 
           @F60012012, 
           @F60012013, 
           @F60012014, 
           @F60012015, 
           @F60012016, 
           @F60012017, 
           @F60012018, 
           @F60012019, 
           @F60012020, 
           @F60012021, 
           @F60012022, 
           @F60012023, 
           @F60012024, 
           @F60012025, 
           @F60012026, 
           @F60012027, 
           @F60012028, 
           @F60012029, 
           @F60012030, 
           @F60012031, 
           @F60012032, 
           @F60012033, 
           @F60012034, 
           @F60012035, 
           @F60012036, 
           @F60012037, 
           @F60012038, 
           @F60012039, 
           @F60012040, 
           @F60012041, 
           @F60012042, 
           @F60012043, 
           @F60012044, 
           @F60012045, 
           @F60012046, 
           @F60012047, 
           @F60012048, 
           @F60012049, 
           @F60012050, 
           @F60012051, 
           @F60012052, 
           @F60012053, 
           @F60012054, 
           @F60012055, 
           @F60012056, 
           @F60012057, 
           @F60012058, 
           @F60012059, 
           @F60012060, 
           @F60012061, 
           @F60012062, 
           @F60012063, 
           @F60012064, 
           @F60012065, 
           @F60012066, 
           @F60012067, 
           @F60012068, 
           @F60013001, 
           @F60013002, 
           @F60013003, 
           @F60013004, 
           @F60013005, 
           @F60013006, 
           @F60013007, 
           @F60013008, 
           @F60013009, 
           @F60013010, 
           @F60013011, 
           @F60013012, 
           @F60013013, 
           @F60013014, 
           @F60013015, 
           @F60013016, 
           @F60013017, 
           @F60013018, 
           @F60013019, 
           @F60013020, 
           @F60013021, 
           @F60013022, 
           @F60013023, 
           @F60013024, 
           @F60013025, 
           @F60013026, 
           @F60013027, 
           @F60013028, 
           @F60013029, 
           @F60013030, 
           @F60013031, 
           @F60013032, 
           @F60013033, 
           @F60013034, 
           @F60013035, 
           @F60013036, 
           @F60013037, 
           @F60013038, 
           @F60013039, 
           @F60013040, 
           @F60013041, 
           @F60013042, 
           @F60013043, 
           @F60013044, 
           @F60013045, 
           @F60013046, 
           @F60013047, 
           @F60013048, 
           @F60013049, 
           @F60013050, 
           @F60013051, 
           @F60013052, 
           @F60013053, 
           @F60013054, 
           @F60013055, 
           @F60013056, 
           @F60013057, 
           @F60013058, 
           @F60013059, 
           @F60013060, 
           @F60013061, 
           @F60013062, 
           @F60013063, 
           @F60013064, 
           @F60013065, 
           @F60013066, 
           @F60013067, 
           @F60013068,
           @ActeDeDepot,
           @NatureDepot)";
        const string UpdateSQL = @"
UPDATE [dbo].[F6001]
   SET [F60010001] = @F60010001 
      ,[F60010002] = @F60010002 
      ,[F60010003] = @F60010003 
      ,[F60010004] = @F60010004 
      ,[F60010005] = @F60010005 
      ,[F60010006] = @F60010006 
      ,[F60010007] = @F60010007 
      ,[F60010008] = @F60010008 
      ,[F60010009] = @F60010009 
      ,[F60010010] = @F60010010 
      ,[F60010011] = @F60010011 
      ,[F60010012] = @F60010012 
      ,[F60010013] = @F60010013 
      ,[F60010014] = @F60010014 
      ,[F60010015] = @F60010015 
      ,[F60010016] = @F60010016 
      ,[F60010017] = @F60010017 
      ,[F60010018] = @F60010018 
      ,[F60010019] = @F60010019 
      ,[F60010020] = @F60010020 
      ,[F60010021] = @F60010021 
      ,[F60010022] = @F60010022 
      ,[F60010023] = @F60010023 
      ,[F60010024] = @F60010024 
      ,[F60010025] = @F60010025 
      ,[F60010026] = @F60010026 
      ,[F60010027] = @F60010027 
      ,[F60010028] = @F60010028 
      ,[F60010029] = @F60010029 
      ,[F60010030] = @F60010030 
      ,[F60010031] = @F60010031 
      ,[F60010032] = @F60010032 
      ,[F60010033] = @F60010033 
      ,[F60010034] = @F60010034 
      ,[F60010035] = @F60010035 
      ,[F60010036] = @F60010036 
      ,[F60010037] = @F60010037 
      ,[F60010038] = @F60010038 
      ,[F60010039] = @F60010039 
      ,[F60010040] = @F60010040 
      ,[F60010041] = @F60010041 
      ,[F60010042] = @F60010042 
      ,[F60010043] = @F60010043 
      ,[F60010044] = @F60010044 
      ,[F60010045] = @F60010045 
      ,[F60010046] = @F60010046 
      ,[F60010047] = @F60010047 
      ,[F60010048] = @F60010048 
      ,[F60010049] = @F60010049 
      ,[F60010050] = @F60010050 
      ,[F60010051] = @F60010051 
      ,[F60010052] = @F60010052 
      ,[F60010053] = @F60010053 
      ,[F60010054] = @F60010054 
      ,[F60010055] = @F60010055 
      ,[F60010056] = @F60010056 
      ,[F60010057] = @F60010057 
      ,[F60010058] = @F60010058 
      ,[F60010059] = @F60010059 
      ,[F60010060] = @F60010060 
      ,[F60010061] = @F60010061 
      ,[F60010062] = @F60010062 
      ,[F60010063] = @F60010063 
      ,[F60010064] = @F60010064 
      ,[F60010065] = @F60010065 
      ,[F60010066] = @F60010066 
      ,[F60010067] = @F60010067 
      ,[F60010068] = @F60010068 
      ,[F60011001] = @F60011001 
      ,[F60011002] = @F60011002 
      ,[F60011003] = @F60011003 
      ,[F60011004] = @F60011004 
      ,[F60011005] = @F60011005 
      ,[F60011006] = @F60011006 
      ,[F60011007] = @F60011007 
      ,[F60011008] = @F60011008 
      ,[F60011009] = @F60011009 
      ,[F60011010] = @F60011010 
      ,[F60011011] = @F60011011 
      ,[F60011012] = @F60011012 
      ,[F60011013] = @F60011013 
      ,[F60011014] = @F60011014 
      ,[F60011015] = @F60011015 
      ,[F60011016] = @F60011016 
      ,[F60011017] = @F60011017 
      ,[F60011018] = @F60011018 
      ,[F60011019] = @F60011019 
      ,[F60011020] = @F60011020 
      ,[F60011021] = @F60011021 
      ,[F60011022] = @F60011022 
      ,[F60011023] = @F60011023 
      ,[F60011024] = @F60011024 
      ,[F60011025] = @F60011025 
      ,[F60011026] = @F60011026 
      ,[F60011027] = @F60011027 
      ,[F60011028] = @F60011028 
      ,[F60011029] = @F60011029 
      ,[F60011030] = @F60011030 
      ,[F60011031] = @F60011031 
      ,[F60011032] = @F60011032 
      ,[F60011033] = @F60011033 
      ,[F60011034] = @F60011034 
      ,[F60011035] = @F60011035 
      ,[F60011036] = @F60011036 
      ,[F60011037] = @F60011037 
      ,[F60011038] = @F60011038 
      ,[F60011039] = @F60011039 
      ,[F60011040] = @F60011040 
      ,[F60011041] = @F60011041 
      ,[F60011042] = @F60011042 
      ,[F60011043] = @F60011043 
      ,[F60011044] = @F60011044 
      ,[F60011045] = @F60011045 
      ,[F60011046] = @F60011046 
      ,[F60011047] = @F60011047 
      ,[F60011048] = @F60011048 
      ,[F60011049] = @F60011049 
      ,[F60011050] = @F60011050 
      ,[F60011051] = @F60011051 
      ,[F60011052] = @F60011052 
      ,[F60011053] = @F60011053 
      ,[F60011054] = @F60011054 
      ,[F60011055] = @F60011055 
      ,[F60011056] = @F60011056 
      ,[F60011057] = @F60011057 
      ,[F60011058] = @F60011058 
      ,[F60011059] = @F60011059 
      ,[F60011060] = @F60011060 
      ,[F60011061] = @F60011061 
      ,[F60011062] = @F60011062 
      ,[F60011063] = @F60011063 
      ,[F60011064] = @F60011064 
      ,[F60011065] = @F60011065 
      ,[F60011066] = @F60011066 
      ,[F60011067] = @F60011067 
      ,[F60011068] = @F60011068 
      ,[F60012001] = @F60012001 
      ,[F60012002] = @F60012002 
      ,[F60012003] = @F60012003 
      ,[F60012004] = @F60012004 
      ,[F60012005] = @F60012005 
      ,[F60012006] = @F60012006 
      ,[F60012007] = @F60012007 
      ,[F60012008] = @F60012008 
      ,[F60012009] = @F60012009 
      ,[F60012010] = @F60012010 
      ,[F60012011] = @F60012011 
      ,[F60012012] = @F60012012 
      ,[F60012013] = @F60012013 
      ,[F60012014] = @F60012014 
      ,[F60012015] = @F60012015 
      ,[F60012016] = @F60012016 
      ,[F60012017] = @F60012017 
      ,[F60012018] = @F60012018 
      ,[F60012019] = @F60012019 
      ,[F60012020] = @F60012020 
      ,[F60012021] = @F60012021 
      ,[F60012022] = @F60012022 
      ,[F60012023] = @F60012023 
      ,[F60012024] = @F60012024 
      ,[F60012025] = @F60012025 
      ,[F60012026] = @F60012026 
      ,[F60012027] = @F60012027 
      ,[F60012028] = @F60012028 
      ,[F60012029] = @F60012029 
      ,[F60012030] = @F60012030 
      ,[F60012031] = @F60012031 
      ,[F60012032] = @F60012032 
      ,[F60012033] = @F60012033 
      ,[F60012034] = @F60012034 
      ,[F60012035] = @F60012035 
      ,[F60012036] = @F60012036 
      ,[F60012037] = @F60012037 
      ,[F60012038] = @F60012038 
      ,[F60012039] = @F60012039 
      ,[F60012040] = @F60012040 
      ,[F60012041] = @F60012041 
      ,[F60012042] = @F60012042 
      ,[F60012043] = @F60012043 
      ,[F60012044] = @F60012044 
      ,[F60012045] = @F60012045 
      ,[F60012046] = @F60012046 
      ,[F60012047] = @F60012047 
      ,[F60012048] = @F60012048 
      ,[F60012049] = @F60012049 
      ,[F60012050] = @F60012050 
      ,[F60012051] = @F60012051 
      ,[F60012052] = @F60012052 
      ,[F60012053] = @F60012053 
      ,[F60012054] = @F60012054 
      ,[F60012055] = @F60012055 
      ,[F60012056] = @F60012056 
      ,[F60012057] = @F60012057 
      ,[F60012058] = @F60012058 
      ,[F60012059] = @F60012059 
      ,[F60012060] = @F60012060 
      ,[F60012061] = @F60012061 
      ,[F60012062] = @F60012062 
      ,[F60012063] = @F60012063 
      ,[F60012064] = @F60012064 
      ,[F60012065] = @F60012065 
      ,[F60012066] = @F60012066 
      ,[F60012067] = @F60012067 
      ,[F60012068] = @F60012068 
      ,[F60013001] = @F60013001 
      ,[F60013002] = @F60013002 
      ,[F60013003] = @F60013003 
      ,[F60013004] = @F60013004 
      ,[F60013005] = @F60013005 
      ,[F60013006] = @F60013006 
      ,[F60013007] = @F60013007 
      ,[F60013008] = @F60013008 
      ,[F60013009] = @F60013009 
      ,[F60013010] = @F60013010 
      ,[F60013011] = @F60013011 
      ,[F60013012] = @F60013012 
      ,[F60013013] = @F60013013 
      ,[F60013014] = @F60013014 
      ,[F60013015] = @F60013015 
      ,[F60013016] = @F60013016 
      ,[F60013017] = @F60013017 
      ,[F60013018] = @F60013018 
      ,[F60013019] = @F60013019 
      ,[F60013020] = @F60013020 
      ,[F60013021] = @F60013021 
      ,[F60013022] = @F60013022 
      ,[F60013023] = @F60013023 
      ,[F60013024] = @F60013024 
      ,[F60013025] = @F60013025 
      ,[F60013026] = @F60013026 
      ,[F60013027] = @F60013027 
      ,[F60013028] = @F60013028 
      ,[F60013029] = @F60013029 
      ,[F60013030] = @F60013030 
      ,[F60013031] = @F60013031 
      ,[F60013032] = @F60013032 
      ,[F60013033] = @F60013033 
      ,[F60013034] = @F60013034 
      ,[F60013035] = @F60013035 
      ,[F60013036] = @F60013036 
      ,[F60013037] = @F60013037 
      ,[F60013038] = @F60013038 
      ,[F60013039] = @F60013039 
      ,[F60013040] = @F60013040 
      ,[F60013041] = @F60013041 
      ,[F60013042] = @F60013042 
      ,[F60013043] = @F60013043 
      ,[F60013044] = @F60013044 
      ,[F60013045] = @F60013045 
      ,[F60013046] = @F60013046 
      ,[F60013047] = @F60013047 
      ,[F60013048] = @F60013048 
      ,[F60013049] = @F60013049 
      ,[F60013050] = @F60013050 
      ,[F60013051] = @F60013051 
      ,[F60013052] = @F60013052 
      ,[F60013053] = @F60013053 
      ,[F60013054] = @F60013054 
      ,[F60013055] = @F60013055 
      ,[F60013056] = @F60013056 
      ,[F60013057] = @F60013057 
      ,[F60013058] = @F60013058 
      ,[F60013059] = @F60013059 
      ,[F60013060] = @F60013060 
      ,[F60013061] = @F60013061 
      ,[F60013062] = @F60013062 
      ,[F60013063] = @F60013063 
      ,[F60013064] = @F60013064 
      ,[F60013065] = @F60013065 
      ,[F60013066] = @F60013066 
      ,[F60013067] = @F60013067 
      ,[F60013068] = @F60013068
      ,[ActeDeDepot]=@ActeDeDepot
      ,[NatureDepot]= @NatureDepot
 WHERE Id = @Id
";
        const string DeleteSQL = @"DELETE From ";

        const string GetSQL = @"SELECT [Id]
      ,[SocieteNo]
      ,[ExerciceId]
      ,[ActeDeDepot]
      ,[NatureDepot]
      ,[F60010001]
      ,[F60010002]
      ,[F60010003]
      ,[F60010004]
      ,[F60010005]
      ,[F60010006]
      ,[F60010007]
      ,[F60010008]
      ,[F60010009]
      ,[F60010010]
      ,[F60010011]
      ,[F60010012]
      ,[F60010013]
      ,[F60010014]
      ,[F60010015]
      ,[F60010016]
      ,[F60010017]
      ,[F60010018]
      ,[F60010019]
      ,[F60010020]
      ,[F60010021]
      ,[F60010022]
      ,[F60010023]
      ,[F60010024]
      ,[F60010025]
      ,[F60010026]
      ,[F60010027]
      ,[F60010028]
      ,[F60010029]
      ,[F60010030]
      ,[F60010031]
      ,[F60010032]
      ,[F60010033]
      ,[F60010034]
      ,[F60010035]
      ,[F60010036]
      ,[F60010037]
      ,[F60010038]
      ,[F60010039]
      ,[F60010040]
      ,[F60010041]
      ,[F60010042]
      ,[F60010043]
      ,[F60010044]
      ,[F60010045]
      ,[F60010046]
      ,[F60010047]
      ,[F60010048]
      ,[F60010049]
      ,[F60010050]
      ,[F60010051]
      ,[F60010052]
      ,[F60010053]
      ,[F60010054]
      ,[F60010055]
      ,[F60010056]
      ,[F60010057]
      ,[F60010058]
      ,[F60010059]
      ,[F60010060]
      ,[F60010061]
      ,[F60010062]
      ,[F60010063]
      ,[F60010064]
      ,[F60010065]
      ,[F60010066]
      ,[F60010067]
      ,[F60010068]
      ,[F60011001]
      ,[F60011002]
      ,[F60011003]
      ,[F60011004]
      ,[F60011005]
      ,[F60011006]
      ,[F60011007]
      ,[F60011008]
      ,[F60011009]
      ,[F60011010]
      ,[F60011011]
      ,[F60011012]
      ,[F60011013]
      ,[F60011014]
      ,[F60011015]
      ,[F60011016]
      ,[F60011017]
      ,[F60011018]
      ,[F60011019]
      ,[F60011020]
      ,[F60011021]
      ,[F60011022]
      ,[F60011023]
      ,[F60011024]
      ,[F60011025]
      ,[F60011026]
      ,[F60011027]
      ,[F60011028]
      ,[F60011029]
      ,[F60011030]
      ,[F60011031]
      ,[F60011032]
      ,[F60011033]
      ,[F60011034]
      ,[F60011035]
      ,[F60011036]
      ,[F60011037]
      ,[F60011038]
      ,[F60011039]
      ,[F60011040]
      ,[F60011041]
      ,[F60011042]
      ,[F60011043]
      ,[F60011044]
      ,[F60011045]
      ,[F60011046]
      ,[F60011047]
      ,[F60011048]
      ,[F60011049]
      ,[F60011050]
      ,[F60011051]
      ,[F60011052]
      ,[F60011053]
      ,[F60011054]
      ,[F60011055]
      ,[F60011056]
      ,[F60011057]
      ,[F60011058]
      ,[F60011059]
      ,[F60011060]
      ,[F60011061]
      ,[F60011062]
      ,[F60011063]
      ,[F60011064]
      ,[F60011065]
      ,[F60011066]
      ,[F60011067]
      ,[F60011068]
      ,[F60012001]
      ,[F60012002]
      ,[F60012003]
      ,[F60012004]
      ,[F60012005]
      ,[F60012006]
      ,[F60012007]
      ,[F60012008]
      ,[F60012009]
      ,[F60012010]
      ,[F60012011]
      ,[F60012012]
      ,[F60012013]
      ,[F60012014]
      ,[F60012015]
      ,[F60012016]
      ,[F60012017]
      ,[F60012018]
      ,[F60012019]
      ,[F60012020]
      ,[F60012021]
      ,[F60012022]
      ,[F60012023]
      ,[F60012024]
      ,[F60012025]
      ,[F60012026]
      ,[F60012027]
      ,[F60012028]
      ,[F60012029]
      ,[F60012030]
      ,[F60012031]
      ,[F60012032]
      ,[F60012033]
      ,[F60012034]
      ,[F60012035]
      ,[F60012036]
      ,[F60012037]
      ,[F60012038]
      ,[F60012039]
      ,[F60012040]
      ,[F60012041]
      ,[F60012042]
      ,[F60012043]
      ,[F60012044]
      ,[F60012045]
      ,[F60012046]
      ,[F60012047]
      ,[F60012048]
      ,[F60012049]
      ,[F60012050]
      ,[F60012051]
      ,[F60012052]
      ,[F60012053]
      ,[F60012054]
      ,[F60012055]
      ,[F60012056]
      ,[F60012057]
      ,[F60012058]
      ,[F60012059]
      ,[F60012060]
      ,[F60012061]
      ,[F60012062]
      ,[F60012063]
      ,[F60012064]
      ,[F60012065]
      ,[F60012066]
      ,[F60012067]
      ,[F60012068]
      ,[F60013001]
      ,[F60013002]
      ,[F60013003]
      ,[F60013004]
      ,[F60013005]
      ,[F60013006]
      ,[F60013007]
      ,[F60013008]
      ,[F60013009]
      ,[F60013010]
      ,[F60013011]
      ,[F60013012]
      ,[F60013013]
      ,[F60013014]
      ,[F60013015]
      ,[F60013016]
      ,[F60013017]
      ,[F60013018]
      ,[F60013019]
      ,[F60013020]
      ,[F60013021]
      ,[F60013022]
      ,[F60013023]
      ,[F60013024]
      ,[F60013025]
      ,[F60013026]
      ,[F60013027]
      ,[F60013028]
      ,[F60013029]
      ,[F60013030]
      ,[F60013031]
      ,[F60013032]
      ,[F60013033]
      ,[F60013034]
      ,[F60013035]
      ,[F60013036]
      ,[F60013037]
      ,[F60013038]
      ,[F60013039]
      ,[F60013040]
      ,[F60013041]
      ,[F60013042]
      ,[F60013043]
      ,[F60013044]
      ,[F60013045]
      ,[F60013046]
      ,[F60013047]
      ,[F60013048]
      ,[F60013049]
      ,[F60013050]
      ,[F60013051]
      ,[F60013052]
      ,[F60013053]
      ,[F60013054]
      ,[F60013055]
      ,[F60013056]
      ,[F60013057]
      ,[F60013058]
      ,[F60013059]
      ,[F60013060]
      ,[F60013061]
      ,[F60013062]
      ,[F60013063]
      ,[F60013064]
      ,[F60013065]
      ,[F60013066]
      ,[F60013067]
      ,[F60013068]
  FROM [dbo].[F6001]";
    }
}
