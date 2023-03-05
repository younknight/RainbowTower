using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class LinkCalculator
{
    public float LinkDamageCalculater(linkType linkType, int link)
    {
        switch (linkType)
        {
            case linkType.None:
                break;
            case linkType.single:
                return SingleLink(link);
            case linkType.outline:
                return link;
        }
        return 0;//링크없을경우
    }
    float SingleLink(int link)
    {
        return link;
    }
}
