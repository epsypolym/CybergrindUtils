using MelonLoader;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace CGUtils
{
    public class UIHandler : MonoBehaviour
    {
        public Text wave;
        public Text enemies;
        public Text totalkills;
        public Text style;
        public Text time;

        private string joe;

        public EndlessGrid gridRef;
        public StatsManager statMan;

        void Update()
        {
            wave.text = (gridRef.currentWave.ToString());
            enemies.text = gridRef.enemiesLeftText.text;
            totalkills.text = statMan.kills.ToString();
            style.text = statMan.stylePoints.ToString();
            joe = (TimeSpan.FromSeconds(statMan.seconds).ToString());
            time.text = joe.Substring(0,joe.Length - 4);
        }

    }

}
