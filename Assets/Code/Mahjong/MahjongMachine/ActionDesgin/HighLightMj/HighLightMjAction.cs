﻿using ComponentDesgin;
using CoreDesgin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActionDesgin
{
    /// <summary>
    /// 高亮麻将动作
    /// </summary>
    public class HighLightMjAction : BaseHandAction
    {
        public static HighLightMjAction Instance { get; } = new HighLightMjAction();

        SelectDaPaiStateData stateData;
        public override void Init(MahjongMachine mjMachine)
        {
            base.Init(mjMachine);
            stateData = playerStateData[0].GetComponent<SelectDaPaiStateData>();
        }

        public override void Install()
        {
            mjMachineUpdater.Reg("HighLightMj", UpdateHighLightMjView);
        }

        public override void UnInstall()
        {
            mjMachineUpdater.UnReg("HighLightMj");
        }

        /// <summary>
        /// 更新高亮麻将的显示
        /// </summary>
        void UpdateHighLightMjView()
        {
            if (stateData.selectedUpMj)
            {
                MahjongFaceValue selectedMjFaceValue = stateData.selectedUpMj.GetComponent<MjPaiData>().mjFaceValue;
                if (selectedMjFaceValue == desk.highLightMjValue)
                    return;

                desk.OffDeskMjHighLight(desk.highLightMjValue);
                desk.OnDeskMjHighLight(selectedMjFaceValue);
                return;
            }
            else if (desk.mjSeatMoPaiLists[0].Count > 0)
            {
                MahjongFaceValue moPaiMjFaceValue = desk.mjSeatMoPaiLists[0][0].GetComponent<MjPaiData>().mjFaceValue;
                if (moPaiMjFaceValue == desk.highLightMjValue)
                    return;

                desk.OffDeskMjHighLight(desk.highLightMjValue);
                desk.OnDeskMjHighLight(moPaiMjFaceValue);
                return;
            }
            else
            {
                desk.OffDeskMjHighLight(desk.highLightMjValue);
            }
        }

    }
}
