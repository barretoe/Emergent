using Emergent.DbContext;
using Emergent.Models;
using System;
using System.Collections.Generic;

namespace Emergent.Utilities
{
    public class SoftwareFilters
    {
        public static IEnumerable<Software> GetSoftwareByVersion(string strVersionFilter)
        {
            IEnumerable<Software> allRecords = SoftwareManager.GetAllSoftware();
            List<Software> lstAllRecords = new List<Software>(allRecords);
            List<Software> softwareByVersion = new List<Software>(allRecords);

            string[] strFilterSplit = addZeros(strVersionFilter.Split('.'));

            for (int x = 0; x < lstAllRecords.Count; x++){

                for(int y = 0; y < strFilterSplit.Length; y++)
                {
                    string[] strAllRecordSplit = addZeros(lstAllRecords[x].Version.Split('.'));

                    if (Int32.Parse(strAllRecordSplit[y]) < Int32.Parse(strFilterSplit[y]))
                    {
                        softwareByVersion.Remove(lstAllRecords[x]);
                        break; 
                    }
                    else if (Int32.Parse(strAllRecordSplit[y]) == Int32.Parse(strFilterSplit[y]))
                    {
                        continue;
                    }
                    else
                    {
                        break;
                    }
                }
            }

            return softwareByVersion; 
        }

        public static string[] addZeros(string[] strSplit)
        {
            List<string> list = new List<string>(strSplit);

            switch (strSplit.Length)
            {
                case 1:
                    list.Add("0");
                    list.Add("0");
                    break;
                case 2:
                    list.Add("0");
                    break;
            }

            string[] strUpdatedSplit = list.ToArray();
            return strUpdatedSplit; 
        }
    }
}
