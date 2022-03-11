using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAppZMS.Class
{
    public static class Ext
    {
        public static void AddRange<T>(this ObservableCollection<T> source, params T[] items)
        {
            foreach (var item in items)
            {
                source.Add(item);
            }
        }

        public static Entity.ZGLV ToEntity(this File.NPR_LIST file)
        {
            var item = new Entity.ZGLV
            {
                VERSION = file.ZLGV.VERSION,
                DATA = file.ZLGV.DATA,
                FILENAME = file.ZLGV.FILENAME,
                CODE = file.PACK.CODE,
                YEAR = file.PACK.YEAR,
                MONTH = file.PACK.MONTH,
                DAY = file.PACK.DAY,
                CODE_MO = file.PACK.CODE_MO.ToString(),
                CODE_LPU = file.PACK.CODE_LPU
            };

            foreach (var z in file.ZAP)
            {
                var zap = new Entity.ZAP
                {
                    COMENTP = z.PACIENT.COMENTP,
                    DR = z.PACIENT.DR,
                    FAM = z.PACIENT.FAM,
                    ID_PAC = z.PACIENT.ID_PAC,
                    IM = z.PACIENT.IM,
                    NPOLIS = z.PACIENT.NPOLIS,
                    N_ZAP = z.N_ZAP,
                    OT = z.PACIENT.OT,
                    PHONE = z.PACIENT.PHONE,
                    SMO = z.PACIENT.SMO,
                    SPOLIS = z.PACIENT.SPOLIS,
                    ST_OKATO = z.PACIENT.ST_OKATO,
                    VPOLIS = z.PACIENT.VPOLIS,
                    W = z.PACIENT.W
                };
                item.ZAP.Add(zap);
                foreach (var n in z.NPR)
                {
                    var npr = new Entity.NPR
                    {
                        PROFK = n.PROFK,
                        CODE_MD = n.CODE_MD,
                        PROFIL = n.PROFIL,
                        PODR = n.PODR,
                        PLAN_DATE = n.PLAN_DATE,
                        NPR_NUM = n.NPR_NUM,
                        COMENTN = n.COMENTN,
                        DATE = n.DATE,
                        DEST_LPU = n.DEST_LPU,
                        DEST_MO = n.DEST_MO,
                        DS = n.DS,
                        FOR_POM = n.FOR_POM,
                        IDNPR = n.IDNPR,
                        NPR_LPU = n.NPR_LPU,
                        NPR_MO = n.NPR_MO
                    };
                    zap.NPR.Add(npr);
                }
            }

            return item;
        }
    }
}
