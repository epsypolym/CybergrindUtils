using MelonLoader;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

namespace CGUtils
{
    public static class BuildInfo
    {
        public const string Name = "CyberGrind Utilities"; // Name of the Mod.  (MUST BE SET)
        public const string Author = "epsypolym"; // Author of the Mod.  (Set as null if none)
        public const string Company = null; // Company that made the Mod.  (Set as null if none)
        public const string Version = "1.0.0"; // Version of the Mod.  (MUST BE SET)
        public const string DownloadLink = null; // Download Link for the Mod.  (Set as null if none)
    }
    public class CGUtils : MelonMod
    {
        public string enemyCount;
        public int currentWaveText;
        public int stykePointsText;


        public EndlessGrid gridRef;
        public StatsManager statman;
        public bool cg;
        public GameObject CGUtilsHUD;
        public GameObject CGUtilsController;
        public GameObject CGMusicManager;
        public static Slider volslider;
        private string modsdir;
        public static string musicdir;


        public override void OnApplicationStart()
        {
            modsdir = Directory.GetParent(Application.dataPath).ToString() + "\\Mods";
            musicdir = Directory.GetParent(Application.dataPath).ToString() + "\\CGUtilsMusic";
            if (!Directory.Exists(musicdir))
            {
                Directory.CreateDirectory(musicdir);
            }
            MusicImport.init();
        }

        public IEnumerator delaynuts(float seconds)
        {
            yield return new WaitForSeconds(seconds);
            MelonCoroutines.Start(bruhgau());
        }

        public IEnumerator bruhgau()
        {
            if (MusicImport.LoadCustomMusic)
            {
                GameObject.Destroy(GameObject.Find("Everything").transform.GetChild(3).transform.GetChild(0).gameObject);
                yield return new WaitForEndOfFrame();
            }
        }

        public override void OnLevelWasLoaded(int level)
        {
            if (GameObject.Find("Arena"))
            {
                AssetBundle joe = AssetBundle.LoadFromFile(Path.Combine(modsdir, "cybergrindutils.unity3d"));

                GameObject nuts = joe.LoadAsset<GameObject>("Assets/CGStatsController.prefab");
                GameObject balls = joe.LoadAsset<GameObject>("Assets/CGMusicManager.prefab");
                joe.Unload(false);
                gridRef = GameObject.Find("Arena").GetComponent<EndlessGrid>();
                statman = GameObject.Find("StatsManager").GetComponent<StatsManager>();
                cg = true;

                volslider = GameObject.Find("FirstRoom/Player/Canvas/OptionsMenu/Audio Options/Music Volume/Slider (1)").GetComponent<Slider>();

                CGUtilsController = GameObject.Instantiate(nuts);
                if (MusicImport.LoadCustomMusic) { CGMusicManager = GameObject.Instantiate(balls); }
                GameObject stylehud = GameObject.Find("FirstRoom/Player/Canvas");
                CGUtilsController.transform.SetParent(stylehud.transform);
                float stupidheightcalc = Screen.currentResolution.height - 10;
                CGUtilsController.transform.position = new Vector3(10, stupidheightcalc, 0);
                CGUtilsController.transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
                CGUtilsHUD = CGUtilsController.transform.GetChild(0).transform.gameObject;
                MelonCoroutines.Start(delaynuts(2f));
                CGUtilsHUD.GetComponent<UIHandler>().gridRef = gridRef;
                CGUtilsHUD.GetComponent<UIHandler>().statMan = statman;
                if (MusicImport.LoadCustomMusic) { statman.transform.GetChild(0).gameObject.SetActive(false); }
            }
            else
            {
                cg = false;

                if (CGUtilsController)
                {
                    GameObject.Destroy(CGUtilsController);
                }
            }
        }

    }
}
