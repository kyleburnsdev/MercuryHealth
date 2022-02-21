﻿using System.Reflection;

namespace MercuryHealth.Web;

public class MyAppVersion
{
    public static string GetAssemblyVersion()
    {
        Assembly assembly = Assembly.GetEntryAssembly();
        AssemblyInformationalVersionAttribute versionAttribute = assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>();
        string assemblyVersion = versionAttribute.InformationalVersion;

        return assemblyVersion;
    }

    public static string GetDateTimeFromVersion()
    {
        Assembly assembly = Assembly.GetEntryAssembly();
        AssemblyInformationalVersionAttribute versionAttribute = assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>();
        string myAssemblyVersion = versionAttribute.InformationalVersion;
        //string myAssemblyVersion = GetAssemblyVersion();

        if (myAssemblyVersion == "1.1.0")
        {
            myAssemblyVersion = "1.1.0.0";
        }

        // Split Major.Minor.Build.Revision
        string[] myVersion = myAssemblyVersion.Split('.');

        // Base date that build revision number is generated from
        DateTime baseDate = new DateTime(2022, 1, 1, 0, 0, 0);

        // #of Days from Revision #
        int numOfDays = Convert.ToInt32(myVersion[2]);

        // #of Seconds from Midnight
        int numOfSecs = Convert.ToInt32(myVersion[3]) * 2;

        // Add #of days to base date
        DateTime myModifedDate = baseDate.AddDays(numOfDays);

        // Add #of of seconds from Midnight
        myModifedDate = myModifedDate.AddSeconds(numOfSecs);

        string ReturnDateTimeFromVersion = myModifedDate.ToShortDateString() + " at " + myModifedDate.ToShortTimeString();

        return ReturnDateTimeFromVersion;

    }
}

