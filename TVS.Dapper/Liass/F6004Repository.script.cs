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
    public partial class F6004Repository 
    {
        const string InsertSQL= @"INSERT INTO [dbo].[F6004]
           ([SocieteNo]
           ,[ExerciceId]
           ,[ActeDeDepot]
           ,[NatureDepot]
           ,[F60040001]
           ,[F60040002]
           ,[F60040003]
           ,[F60040004]
           ,[F60040005]
           ,[F60040006]
           ,[F60040007]
           ,[F60040008]
           ,[F60040009]
           ,[F60040010]
           ,[F60040011]
           ,[F60040012]
           ,[F60040013]
           ,[F60040014]
           ,[F60040015]
           ,[F60040016]
           ,[F60040017]
           ,[F60040018]
           ,[F60040019]
           ,[F60040020]
           ,[F60040021]
           ,[F60040022]
           ,[F60040023]
           ,[F60040024]
           ,[F60040025]
           ,[F60040026]
           ,[F60040027]
           ,[F60040028]
           ,[F60040029]
           ,[F60040030]
           ,[F60040031]
           ,[F60040032]
           ,[F60040033]
           ,[F60040034]
           ,[F60040035]
           ,[F60040036]
           ,[F60040037]
           ,[F60040038]
           ,[F60040039]
           ,[F60040040]
           ,[F60040041]
           ,[F60040042]
           ,[F60040043]
           ,[F60040044]
           ,[F60040045]
           ,[F60040046]
           ,[F60040047]
           ,[F60040048]
           ,[F60040049]
           ,[F60040050]
           ,[F60040051]
           ,[F60040052]
           ,[F60040053]
           ,[F60040054]
           ,[F60040055]
           ,[F60040056]
           ,[F60040057]
           ,[F60040058]
           ,[F60040059]
           ,[F60040060]
           ,[F60040061]
           ,[F60040062]
           ,[F60040063]
           ,[F60040064]
           ,[F60040065]
           ,[F60040066]
           ,[F60040067]
           ,[F60040068]
           ,[F60040069]
           ,[F60040070]
           ,[F60040071]
           ,[F60040072]
           ,[F60040073]
           ,[F60040074]
           ,[F60040075]
           ,[F60040076]
           ,[F60040077]
           ,[F60040078]
           ,[F60040079]
           ,[F60040080]
           ,[F60040081]
           ,[F60040082]
           ,[F60040083]
           ,[F60040084]
           ,[F60040085]
           ,[F60040086]
           ,[F60040087]
           ,[F60040088]
           ,[F60040089]
           ,[F60040090]
           ,[F60040091]
           ,[F60040092]
           ,[F60040093]
           ,[F60040094]
           ,[F60040095]
           ,[F60040096]
           ,[F60040097]
           ,[F60040098]
           ,[F60040099]
           ,[F60040100]
           ,[F60040101]
           ,[F60040102]
           ,[F60040103]
           ,[F60040104]
           ,[F60040105]
           ,[F60040106]
           ,[F60040107]
           ,[F60040108]
           ,[F60040109]
           ,[F60040110]
           ,[F60040111]
           ,[F60040112]
           ,[F60040113]
           ,[F60040114]
           ,[F60040115]
           ,[F60040116]
           ,[F60040117]
           ,[F60041001]
           ,[F60041002]
           ,[F60041003]
           ,[F60041004]
           ,[F60041005]
           ,[F60041006]
           ,[F60041007]
           ,[F60041008]
           ,[F60041009]
           ,[F60041010]
           ,[F60041011]
           ,[F60041012]
           ,[F60041013]
           ,[F60041014]
           ,[F60041015]
           ,[F60041016]
           ,[F60041017]
           ,[F60041018]
           ,[F60041019]
           ,[F60041020]
           ,[F60041021]
           ,[F60041022]
           ,[F60041023]
           ,[F60041024]
           ,[F60041025]
           ,[F60041026]
           ,[F60041027]
           ,[F60041028]
           ,[F60041029]
           ,[F60041030]
           ,[F60041031]
           ,[F60041032]
           ,[F60041033]
           ,[F60041034]
           ,[F60041035]
           ,[F60041036]
           ,[F60041037]
           ,[F60041038]
           ,[F60041039]
           ,[F60041040]
           ,[F60041041]
           ,[F60041042]
           ,[F60041043]
           ,[F60041044]
           ,[F60041045]
           ,[F60041046]
           ,[F60041047]
           ,[F60041048]
           ,[F60041049]
           ,[F60041050]
           ,[F60041051]
           ,[F60041052]
           ,[F60041053]
           ,[F60041054]
           ,[F60041055]
           ,[F60041056]
           ,[F60041057]
           ,[F60041058]
           ,[F60041059]
           ,[F60041060]
           ,[F60041061]
           ,[F60041062]
           ,[F60041063]
           ,[F60041064]
           ,[F60041065]
           ,[F60041066]
           ,[F60041067]
           ,[F60041068]
           ,[F60041069]
           ,[F60041070]
           ,[F60041071]
           ,[F60041072]
           ,[F60041073]
           ,[F60041074]
           ,[F60041075]
           ,[F60041076]
           ,[F60041077]
           ,[F60041078]
           ,[F60041079]
           ,[F60041080]
           ,[F60041081]
           ,[F60041082]
           ,[F60041083]
           ,[F60041084]
           ,[F60041085]
           ,[F60041086]
           ,[F60041087]
           ,[F60041088]
           ,[F60041089]
           ,[F60041090]
           ,[F60041091]
           ,[F60041092]
           ,[F60041093]
           ,[F60041094]
           ,[F60041095]
           ,[F60041096]
           ,[F60041097]
           ,[F60041098]
           ,[F60041099]
           ,[F60041100]
           ,[F60041101]
           ,[F60041102]
           ,[F60041103]
           ,[F60041104]
           ,[F60041105]
           ,[F60041106]
           ,[F60041107]
           ,[F60041108]
           ,[F60041109]
           ,[F60041110]
           ,[F60041111]
           ,[F60041112]
           ,[F60041113]
           ,[F60041114]
           ,[F60041115]
           ,[F60041116]
           ,[F60041117])
     VALUES
           (@SocieteNo
           ,@ExerciceId
           ,@ActeDeDepot
           ,@NatureDepot
           ,@F60040001 
           ,@F60040002 
           ,@F60040003 
           ,@F60040004 
           ,@F60040005 
           ,@F60040006 
           ,@F60040007 
           ,@F60040008 
           ,@F60040009 
           ,@F60040010 
           ,@F60040011 
           ,@F60040012 
           ,@F60040013 
           ,@F60040014 
           ,@F60040015 
           ,@F60040016 
           ,@F60040017 
           ,@F60040018 
           ,@F60040019 
           ,@F60040020 
           ,@F60040021 
           ,@F60040022 
           ,@F60040023 
           ,@F60040024 
           ,@F60040025 
           ,@F60040026 
           ,@F60040027 
           ,@F60040028 
           ,@F60040029 
           ,@F60040030 
           ,@F60040031 
           ,@F60040032 
           ,@F60040033 
           ,@F60040034 
           ,@F60040035 
           ,@F60040036 
           ,@F60040037 
           ,@F60040038 
           ,@F60040039 
           ,@F60040040 
           ,@F60040041 
           ,@F60040042 
           ,@F60040043 
           ,@F60040044 
           ,@F60040045 
           ,@F60040046 
           ,@F60040047 
           ,@F60040048 
           ,@F60040049 
           ,@F60040050 
           ,@F60040051 
           ,@F60040052 
           ,@F60040053 
           ,@F60040054 
           ,@F60040055 
           ,@F60040056 
           ,@F60040057 
           ,@F60040058 
           ,@F60040059 
           ,@F60040060 
           ,@F60040061 
           ,@F60040062 
           ,@F60040063 
           ,@F60040064 
           ,@F60040065 
           ,@F60040066 
           ,@F60040067 
           ,@F60040068 
           ,@F60040069 
           ,@F60040070 
           ,@F60040071 
           ,@F60040072 
           ,@F60040073 
           ,@F60040074 
           ,@F60040075 
           ,@F60040076 
           ,@F60040077 
           ,@F60040078 
           ,@F60040079 
           ,@F60040080 
           ,@F60040081 
           ,@F60040082 
           ,@F60040083 
           ,@F60040084 
           ,@F60040085 
           ,@F60040086 
           ,@F60040087 
           ,@F60040088 
           ,@F60040089 
           ,@F60040090 
           ,@F60040091 
           ,@F60040092 
           ,@F60040093 
           ,@F60040094 
           ,@F60040095 
           ,@F60040096 
           ,@F60040097 
           ,@F60040098 
           ,@F60040099 
           ,@F60040100 
           ,@F60040101 
           ,@F60040102 
           ,@F60040103 
           ,@F60040104 
           ,@F60040105 
           ,@F60040106 
           ,@F60040107 
           ,@F60040108 
           ,@F60040109 
           ,@F60040110 
           ,@F60040111 
           ,@F60040112 
           ,@F60040113 
           ,@F60040114 
           ,@F60040115 
           ,@F60040116 
           ,@F60040117 
           ,@F60041001 
           ,@F60041002 
           ,@F60041003 
           ,@F60041004 
           ,@F60041005 
           ,@F60041006 
           ,@F60041007 
           ,@F60041008 
           ,@F60041009 
           ,@F60041010 
           ,@F60041011 
           ,@F60041012 
           ,@F60041013 
           ,@F60041014 
           ,@F60041015 
           ,@F60041016 
           ,@F60041017 
           ,@F60041018 
           ,@F60041019 
           ,@F60041020 
           ,@F60041021 
           ,@F60041022 
           ,@F60041023 
           ,@F60041024 
           ,@F60041025 
           ,@F60041026 
           ,@F60041027 
           ,@F60041028 
           ,@F60041029 
           ,@F60041030 
           ,@F60041031 
           ,@F60041032 
           ,@F60041033 
           ,@F60041034 
           ,@F60041035 
           ,@F60041036 
           ,@F60041037 
           ,@F60041038 
           ,@F60041039 
           ,@F60041040 
           ,@F60041041 
           ,@F60041042 
           ,@F60041043 
           ,@F60041044 
           ,@F60041045 
           ,@F60041046 
           ,@F60041047 
           ,@F60041048 
           ,@F60041049 
           ,@F60041050 
           ,@F60041051 
           ,@F60041052 
           ,@F60041053 
           ,@F60041054 
           ,@F60041055 
           ,@F60041056 
           ,@F60041057 
           ,@F60041058 
           ,@F60041059 
           ,@F60041060 
           ,@F60041061 
           ,@F60041062 
           ,@F60041063 
           ,@F60041064 
           ,@F60041065 
           ,@F60041066 
           ,@F60041067 
           ,@F60041068 
           ,@F60041069 
           ,@F60041070 
           ,@F60041071 
           ,@F60041072 
           ,@F60041073 
           ,@F60041074 
           ,@F60041075 
           ,@F60041076 
           ,@F60041077 
           ,@F60041078 
           ,@F60041079 
           ,@F60041080 
           ,@F60041081 
           ,@F60041082 
           ,@F60041083 
           ,@F60041084 
           ,@F60041085 
           ,@F60041086 
           ,@F60041087 
           ,@F60041088 
           ,@F60041089 
           ,@F60041090 
           ,@F60041091 
           ,@F60041092 
           ,@F60041093 
           ,@F60041094 
           ,@F60041095 
           ,@F60041096 
           ,@F60041097 
           ,@F60041098 
           ,@F60041099 
           ,@F60041100 
           ,@F60041101 
           ,@F60041102 
           ,@F60041103 
           ,@F60041104 
           ,@F60041105 
           ,@F60041106 
           ,@F60041107 
           ,@F60041108 
           ,@F60041109 
           ,@F60041110 
           ,@F60041111 
           ,@F60041112 
           ,@F60041113 
           ,@F60041114 
           ,@F60041115 
           ,@F60041116 
           ,@F60041117 )
  ";
        const string UpdateSQL = @"
UPDATE [dbo].[F6004]
   SET [SocieteNo] = @SocieteNo
      ,[ExerciceId] = @ExerciceId
      ,[ActeDeDepot] = @ActeDeDepot
      ,[NatureDepot] = @NatureDepot
      ,[F60040001] = @F60040001 
      ,[F60040002] = @F60040002 
      ,[F60040003] = @F60040003 
      ,[F60040004] = @F60040004 
      ,[F60040005] = @F60040005 
      ,[F60040006] = @F60040006 
      ,[F60040007] = @F60040007 
      ,[F60040008] = @F60040008 
      ,[F60040009] = @F60040009 
      ,[F60040010] = @F60040010 
      ,[F60040011] = @F60040011 
      ,[F60040012] = @F60040012 
      ,[F60040013] = @F60040013 
      ,[F60040014] = @F60040014 
      ,[F60040015] = @F60040015 
      ,[F60040016] = @F60040016 
      ,[F60040017] = @F60040017 
      ,[F60040018] = @F60040018 
      ,[F60040019] = @F60040019 
      ,[F60040020] = @F60040020 
      ,[F60040021] = @F60040021 
      ,[F60040022] = @F60040022 
      ,[F60040023] = @F60040023 
      ,[F60040024] = @F60040024 
      ,[F60040025] = @F60040025 
      ,[F60040026] = @F60040026 
      ,[F60040027] = @F60040027 
      ,[F60040028] = @F60040028 
      ,[F60040029] = @F60040029 
      ,[F60040030] = @F60040030 
      ,[F60040031] = @F60040031 
      ,[F60040032] = @F60040032 
      ,[F60040033] = @F60040033 
      ,[F60040034] = @F60040034 
      ,[F60040035] = @F60040035 
      ,[F60040036] = @F60040036 
      ,[F60040037] = @F60040037 
      ,[F60040038] = @F60040038 
      ,[F60040039] = @F60040039 
      ,[F60040040] = @F60040040 
      ,[F60040041] = @F60040041 
      ,[F60040042] = @F60040042 
      ,[F60040043] = @F60040043 
      ,[F60040044] = @F60040044 
      ,[F60040045] = @F60040045 
      ,[F60040046] = @F60040046 
      ,[F60040047] = @F60040047 
      ,[F60040048] = @F60040048 
      ,[F60040049] = @F60040049 
      ,[F60040050] = @F60040050 
      ,[F60040051] = @F60040051 
      ,[F60040052] = @F60040052 
      ,[F60040053] = @F60040053 
      ,[F60040054] = @F60040054 
      ,[F60040055] = @F60040055 
      ,[F60040056] = @F60040056 
      ,[F60040057] = @F60040057 
      ,[F60040058] = @F60040058 
      ,[F60040059] = @F60040059 
      ,[F60040060] = @F60040060 
      ,[F60040061] = @F60040061 
      ,[F60040062] = @F60040062 
      ,[F60040063] = @F60040063 
      ,[F60040064] = @F60040064 
      ,[F60040065] = @F60040065 
      ,[F60040066] = @F60040066 
      ,[F60040067] = @F60040067 
      ,[F60040068] = @F60040068 
      ,[F60040069] = @F60040069 
      ,[F60040070] = @F60040070 
      ,[F60040071] = @F60040071 
      ,[F60040072] = @F60040072 
      ,[F60040073] = @F60040073 
      ,[F60040074] = @F60040074 
      ,[F60040075] = @F60040075 
      ,[F60040076] = @F60040076 
      ,[F60040077] = @F60040077 
      ,[F60040078] = @F60040078 
      ,[F60040079] = @F60040079 
      ,[F60040080] = @F60040080 
      ,[F60040081] = @F60040081 
      ,[F60040082] = @F60040082 
      ,[F60040083] = @F60040083 
      ,[F60040084] = @F60040084 
      ,[F60040085] = @F60040085 
      ,[F60040086] = @F60040086 
      ,[F60040087] = @F60040087 
      ,[F60040088] = @F60040088 
      ,[F60040089] = @F60040089 
      ,[F60040090] = @F60040090 
      ,[F60040091] = @F60040091 
      ,[F60040092] = @F60040092 
      ,[F60040093] = @F60040093 
      ,[F60040094] = @F60040094 
      ,[F60040095] = @F60040095 
      ,[F60040096] = @F60040096 
      ,[F60040097] = @F60040097 
      ,[F60040098] = @F60040098 
      ,[F60040099] = @F60040099 
      ,[F60040100] = @F60040100 
      ,[F60040101] = @F60040101 
      ,[F60040102] = @F60040102 
      ,[F60040103] = @F60040103 
      ,[F60040104] = @F60040104 
      ,[F60040105] = @F60040105 
      ,[F60040106] = @F60040106 
      ,[F60040107] = @F60040107 
      ,[F60040108] = @F60040108 
      ,[F60040109] = @F60040109 
      ,[F60040110] = @F60040110 
      ,[F60040111] = @F60040111 
      ,[F60040112] = @F60040112 
      ,[F60040113] = @F60040113 
      ,[F60040114] = @F60040114 
      ,[F60040115] = @F60040115 
      ,[F60040116] = @F60040116 
      ,[F60040117] = @F60040117 
      ,[F60041001] = @F60041001 
      ,[F60041002] = @F60041002 
      ,[F60041003] = @F60041003 
      ,[F60041004] = @F60041004 
      ,[F60041005] = @F60041005 
      ,[F60041006] = @F60041006 
      ,[F60041007] = @F60041007 
      ,[F60041008] = @F60041008 
      ,[F60041009] = @F60041009 
      ,[F60041010] = @F60041010 
      ,[F60041011] = @F60041011 
      ,[F60041012] = @F60041012 
      ,[F60041013] = @F60041013 
      ,[F60041014] = @F60041014 
      ,[F60041015] = @F60041015 
      ,[F60041016] = @F60041016 
      ,[F60041017] = @F60041017 
      ,[F60041018] = @F60041018 
      ,[F60041019] = @F60041019 
      ,[F60041020] = @F60041020 
      ,[F60041021] = @F60041021 
      ,[F60041022] = @F60041022 
      ,[F60041023] = @F60041023 
      ,[F60041024] = @F60041024 
      ,[F60041025] = @F60041025 
      ,[F60041026] = @F60041026 
      ,[F60041027] = @F60041027 
      ,[F60041028] = @F60041028 
      ,[F60041029] = @F60041029 
      ,[F60041030] = @F60041030 
      ,[F60041031] = @F60041031 
      ,[F60041032] = @F60041032 
      ,[F60041033] = @F60041033 
      ,[F60041034] = @F60041034 
      ,[F60041035] = @F60041035 
      ,[F60041036] = @F60041036 
      ,[F60041037] = @F60041037 
      ,[F60041038] = @F60041038 
      ,[F60041039] = @F60041039 
      ,[F60041040] = @F60041040 
      ,[F60041041] = @F60041041 
      ,[F60041042] = @F60041042 
      ,[F60041043] = @F60041043 
      ,[F60041044] = @F60041044 
      ,[F60041045] = @F60041045 
      ,[F60041046] = @F60041046 
      ,[F60041047] = @F60041047 
      ,[F60041048] = @F60041048 
      ,[F60041049] = @F60041049 
      ,[F60041050] = @F60041050 
      ,[F60041051] = @F60041051 
      ,[F60041052] = @F60041052 
      ,[F60041053] = @F60041053 
      ,[F60041054] = @F60041054 
      ,[F60041055] = @F60041055 
      ,[F60041056] = @F60041056 
      ,[F60041057] = @F60041057 
      ,[F60041058] = @F60041058 
      ,[F60041059] = @F60041059 
      ,[F60041060] = @F60041060 
      ,[F60041061] = @F60041061 
      ,[F60041062] = @F60041062 
      ,[F60041063] = @F60041063 
      ,[F60041064] = @F60041064 
      ,[F60041065] = @F60041065 
      ,[F60041066] = @F60041066 
      ,[F60041067] = @F60041067 
      ,[F60041068] = @F60041068 
      ,[F60041069] = @F60041069 
      ,[F60041070] = @F60041070 
      ,[F60041071] = @F60041071 
      ,[F60041072] = @F60041072 
      ,[F60041073] = @F60041073 
      ,[F60041074] = @F60041074 
      ,[F60041075] = @F60041075 
      ,[F60041076] = @F60041076 
      ,[F60041077] = @F60041077 
      ,[F60041078] = @F60041078 
      ,[F60041079] = @F60041079 
      ,[F60041080] = @F60041080 
      ,[F60041081] = @F60041081 
      ,[F60041082] = @F60041082 
      ,[F60041083] = @F60041083 
      ,[F60041084] = @F60041084 
      ,[F60041085] = @F60041085 
      ,[F60041086] = @F60041086 
      ,[F60041087] = @F60041087 
      ,[F60041088] = @F60041088 
      ,[F60041089] = @F60041089 
      ,[F60041090] = @F60041090 
      ,[F60041091] = @F60041091 
      ,[F60041092] = @F60041092 
      ,[F60041093] = @F60041093 
      ,[F60041094] = @F60041094 
      ,[F60041095] = @F60041095 
      ,[F60041096] = @F60041096 
      ,[F60041097] = @F60041097 
      ,[F60041098] = @F60041098 
      ,[F60041099] = @F60041099 
      ,[F60041100] = @F60041100 
      ,[F60041101] = @F60041101 
      ,[F60041102] = @F60041102 
      ,[F60041103] = @F60041103 
      ,[F60041104] = @F60041104 
      ,[F60041105] = @F60041105 
      ,[F60041106] = @F60041106 
      ,[F60041107] = @F60041107 
      ,[F60041108] = @F60041108 
      ,[F60041109] = @F60041109 
      ,[F60041110] = @F60041110 
      ,[F60041111] = @F60041111 
      ,[F60041112] = @F60041112 
      ,[F60041113] = @F60041113 
      ,[F60041114] = @F60041114 
      ,[F60041115] = @F60041115 
      ,[F60041116] = @F60041116 
      ,[F60041117] = @F60041117 
 WHERE Id = @Id
";
        const string DeleteSQL = @"DELETE From ";

        const string GetSQL = @"SELECT [Id]
      ,[SocieteNo]
      ,[ExerciceId]
      ,[ActeDeDepot]
      ,[NatureDepot]
      ,[F60040001]
      ,[F60040002]
      ,[F60040003]
      ,[F60040004]
      ,[F60040005]
      ,[F60040006]
      ,[F60040007]
      ,[F60040008]
      ,[F60040009]
      ,[F60040010]
      ,[F60040011]
      ,[F60040012]
      ,[F60040013]
      ,[F60040014]
      ,[F60040015]
      ,[F60040016]
      ,[F60040017]
      ,[F60040018]
      ,[F60040019]
      ,[F60040020]
      ,[F60040021]
      ,[F60040022]
      ,[F60040023]
      ,[F60040024]
      ,[F60040025]
      ,[F60040026]
      ,[F60040027]
      ,[F60040028]
      ,[F60040029]
      ,[F60040030]
      ,[F60040031]
      ,[F60040032]
      ,[F60040033]
      ,[F60040034]
      ,[F60040035]
      ,[F60040036]
      ,[F60040037]
      ,[F60040038]
      ,[F60040039]
      ,[F60040040]
      ,[F60040041]
      ,[F60040042]
      ,[F60040043]
      ,[F60040044]
      ,[F60040045]
      ,[F60040046]
      ,[F60040047]
      ,[F60040048]
      ,[F60040049]
      ,[F60040050]
      ,[F60040051]
      ,[F60040052]
      ,[F60040053]
      ,[F60040054]
      ,[F60040055]
      ,[F60040056]
      ,[F60040057]
      ,[F60040058]
      ,[F60040059]
      ,[F60040060]
      ,[F60040061]
      ,[F60040062]
      ,[F60040063]
      ,[F60040064]
      ,[F60040065]
      ,[F60040066]
      ,[F60040067]
      ,[F60040068]
      ,[F60040069]
      ,[F60040070]
      ,[F60040071]
      ,[F60040072]
      ,[F60040073]
      ,[F60040074]
      ,[F60040075]
      ,[F60040076]
      ,[F60040077]
      ,[F60040078]
      ,[F60040079]
      ,[F60040080]
      ,[F60040081]
      ,[F60040082]
      ,[F60040083]
      ,[F60040084]
      ,[F60040085]
      ,[F60040086]
      ,[F60040087]
      ,[F60040088]
      ,[F60040089]
      ,[F60040090]
      ,[F60040091]
      ,[F60040092]
      ,[F60040093]
      ,[F60040094]
      ,[F60040095]
      ,[F60040096]
      ,[F60040097]
      ,[F60040098]
      ,[F60040099]
      ,[F60040100]
      ,[F60040101]
      ,[F60040102]
      ,[F60040103]
      ,[F60040104]
      ,[F60040105]
      ,[F60040106]
      ,[F60040107]
      ,[F60040108]
      ,[F60040109]
      ,[F60040110]
      ,[F60040111]
      ,[F60040112]
      ,[F60040113]
      ,[F60040114]
      ,[F60040115]
      ,[F60040116]
      ,[F60040117]
      ,[F60041001]
      ,[F60041002]
      ,[F60041003]
      ,[F60041004]
      ,[F60041005]
      ,[F60041006]
      ,[F60041007]
      ,[F60041008]
      ,[F60041009]
      ,[F60041010]
      ,[F60041011]
      ,[F60041012]
      ,[F60041013]
      ,[F60041014]
      ,[F60041015]
      ,[F60041016]
      ,[F60041017]
      ,[F60041018]
      ,[F60041019]
      ,[F60041020]
      ,[F60041021]
      ,[F60041022]
      ,[F60041023]
      ,[F60041024]
      ,[F60041025]
      ,[F60041026]
      ,[F60041027]
      ,[F60041028]
      ,[F60041029]
      ,[F60041030]
      ,[F60041031]
      ,[F60041032]
      ,[F60041033]
      ,[F60041034]
      ,[F60041035]
      ,[F60041036]
      ,[F60041037]
      ,[F60041038]
      ,[F60041039]
      ,[F60041040]
      ,[F60041041]
      ,[F60041042]
      ,[F60041043]
      ,[F60041044]
      ,[F60041045]
      ,[F60041046]
      ,[F60041047]
      ,[F60041048]
      ,[F60041049]
      ,[F60041050]
      ,[F60041051]
      ,[F60041052]
      ,[F60041053]
      ,[F60041054]
      ,[F60041055]
      ,[F60041056]
      ,[F60041057]
      ,[F60041058]
      ,[F60041059]
      ,[F60041060]
      ,[F60041061]
      ,[F60041062]
      ,[F60041063]
      ,[F60041064]
      ,[F60041065]
      ,[F60041066]
      ,[F60041067]
      ,[F60041068]
      ,[F60041069]
      ,[F60041070]
      ,[F60041071]
      ,[F60041072]
      ,[F60041073]
      ,[F60041074]
      ,[F60041075]
      ,[F60041076]
      ,[F60041077]
      ,[F60041078]
      ,[F60041079]
      ,[F60041080]
      ,[F60041081]
      ,[F60041082]
      ,[F60041083]
      ,[F60041084]
      ,[F60041085]
      ,[F60041086]
      ,[F60041087]
      ,[F60041088]
      ,[F60041089]
      ,[F60041090]
      ,[F60041091]
      ,[F60041092]
      ,[F60041093]
      ,[F60041094]
      ,[F60041095]
      ,[F60041096]
      ,[F60041097]
      ,[F60041098]
      ,[F60041099]
      ,[F60041100]
      ,[F60041101]
      ,[F60041102]
      ,[F60041103]
      ,[F60041104]
      ,[F60041105]
      ,[F60041106]
      ,[F60041107]
      ,[F60041108]
      ,[F60041109]
      ,[F60041110]
      ,[F60041111]
      ,[F60041112]
      ,[F60041113]
      ,[F60041114]
      ,[F60041115]
      ,[F60041116]
      ,[F60041117]
  FROM [dbo].[F6004]";
    }
}