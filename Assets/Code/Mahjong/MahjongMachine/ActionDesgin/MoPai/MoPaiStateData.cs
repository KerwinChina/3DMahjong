﻿using ComponentDesgin;
using CoreDesgin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace ActionDesgin
{
    public class MoPaiStateData: ActionStateData
    {
        /// <summary>
        /// 摸牌开始
        /// </summary>
        public const int MO_PAI_START = 14;

        /// <summary>
        /// 摸牌结束
        /// </summary>
        public const int MO_PAI_END = 15;


        #region 摸牌动作数据
        public PlayerType handStyle = PlayerType.FEMALE;
        public ActionCombineNum actionCombineNum = ActionCombineNum.End;
        public MahjongFaceValue moPaiFaceValue;
        public GameObject curtMoPaiMj;
        public int curtMoPaiMjShadowIdx = 0;
        #endregion

        /// <summary>
        /// 设置摸牌动作数据
        /// </summary>
        /// <param name="mjFaceValue"></param>
        /// <param name="opCmdNode"></param>
        public void SetMoPaiData(MahjongFaceValue mjFaceValue, LinkedListNode<MahjongMachineCmd> opCmdNode = null)
        {
            this.moPaiFaceValue = mjFaceValue;
            this.opCmdNode = opCmdNode;
        }

    }
}
