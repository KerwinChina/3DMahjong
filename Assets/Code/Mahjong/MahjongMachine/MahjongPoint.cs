﻿using DG.Tweening;
using UnityEngine;
using Object = UnityEngine.Object;

namespace MahjongMachineNS
{
    public class MahjongPoint
    {
        MahjongMachine mjMachine;
        MahjongGame mjGame;
        MahjongAssets mjAssets;
        MahjongAssetsMgr mjAssetsMgr;
        Transform mjTable;
        GameObject prefabPoint;

        GameObject pointMj;

        Transform pointTransform;
        Tweener tweener;
        public void Setting(MahjongMachine mjMachine)
        {
            this.mjMachine = mjMachine;
            mjGame = mjMachine.mjGame;
            mjAssets = mjMachine.mjAssets;
            mjAssetsMgr = mjMachine.mjAssetsMgr;
            mjTable = mjMachine.mjtableTransform;

            prefabPoint = mjAssets.defaultPrefabDict[(int)PrefabIdx.MJPAI_POINT][0];
        }

        public void Load()
        {
            pointTransform = Object.Instantiate(prefabPoint, mjTable).transform;
            mjAssetsMgr.AppendToDestoryPool(pointTransform.gameObject);

            tweener = pointTransform.DOBlendableLocalMoveBy(new Vector3(0, 0.01f, 0), 0.6f);
            tweener.SetAutoKill(false);
            tweener.SetEase(Ease.Linear).SetLoops(-1, LoopType.Yoyo);
            tweener.Pause();
            mjAssetsMgr.AppendToDestoryPool(tweener);

            pointTransform.gameObject.SetActive(false);
        }

        public void Destory()
        {
            Object.Destroy(pointTransform.gameObject);
            tweener.Kill();
        }

        public void Show(GameObject mj)
        {
            if (mj.activeSelf == false)
                return;

            Vector3 pos;
            if (pointMj != mj)
            {
                pointMj = mj;
                pos = pointMj.transform.localPosition;
                pos.y += mjMachine.GetDeskMjSizeByAxis(Axis.Z) * 2.2f;
                Show(pos);
            }
            else
            {
                pos = pointTransform.localPosition;
                pos.x = pointMj.transform.localPosition.x;
                pos.z = pointMj.transform.localPosition.z;
                Show(pos);
            }
        }

        public void Show(Vector3 pos)
        {
            if (pointTransform.gameObject.activeSelf == false)
            {
                pointTransform.gameObject.SetActive(true);
                tweener.Play();
            }

            pointTransform.localPosition = pos;
        }

        public void Hide()
        {
            if (pointTransform.gameObject.activeSelf == true)
            {
                pointMj = null;
                pointTransform.gameObject.SetActive(false);
                tweener.Pause();
            }

        }
    }
}