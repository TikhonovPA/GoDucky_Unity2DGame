using UnityEngine;
using System.Collections;
using UnityEngine.Advertisements;

public class ShowAds : MonoBehaviour
{
#if UNITY_ANDROID
    private string gameId = "4241275";
#else
    private string gameId = "4241274";
#endif
    private string type = "Interstitial_Android";
    private static int countLoses;
    private void Start()
    {
        Advertisement.Initialize(gameId, true);

        if (countLoses % 3 == 0 && countLoses != 0)
            StartCoroutine(ShowAd());
        countLoses++;
    }
    IEnumerator ShowAd()
    {
        while (!Advertisement.IsReady(type))
        {
            yield return new WaitForSeconds(0.5f);
        }

        Advertisement.Show(type);
    }

}
