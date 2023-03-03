using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class LinkCalculator
{
    public float LinkDamageCalculater(linkType linkType, int link)
    {
        switch (linkType)
        {
            case linkType.single:
               return SingleLink(link);
        }
        return 0;//링크없을경우
    }
    float SingleLink(int link)
    {
        return link;
    }
}
