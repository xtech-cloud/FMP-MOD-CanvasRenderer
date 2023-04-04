

using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using LibMVCS = XTC.FMP.LIB.MVCS;
using XTC.FMP.MOD.CanvasRenderer.LIB.Proto;
using XTC.FMP.MOD.CanvasRenderer.LIB.MVCS;

namespace XTC.FMP.MOD.CanvasRenderer.LIB.Unity
{
    /// <summary>
    /// 实例类
    /// </summary>
    public class MyInstance : MyInstanceBase
    {

        public MyInstance(string _uid, string _style, MyConfig _config, MyCatalog _catalog, LibMVCS.Logger _logger, Dictionary<string, LibMVCS.Any> _settings, MyEntryBase _entry, MonoBehaviour _mono, GameObject _rootAttachments)
            : base(_uid, _style, _config, _catalog, _logger, _settings, _entry, _mono, _rootAttachments)
        {
        }

        /// <summary>
        /// 当被创建时
        /// </summary>
        /// <remarks>
        /// 可用于加载主题目录的数据
        /// </remarks>
        public void HandleCreated()
        {
            var target = GameObject.Find(style_.target.path);
            if (null == target)
            {
                logger_.Error("target:'{0}' not found", style_.target.path);
                return;
            }

            var canvas = target.GetComponent<Canvas>();
            if (null == canvas)
            {
                logger_.Error("target:'{0}' miss Canvas Component", style_.target.path);
                return;
            }

            if (style_.target.mode == "Overlay")
            {
                canvas.renderMode = RenderMode.ScreenSpaceOverlay;
            }
            else if (style_.target.mode == "Camera")
            {
                canvas.renderMode = RenderMode.ScreenSpaceCamera;
                var camera = GameObject.Find(style_.target.cameraMode.camera);
                if (null == camera)
                    logger_.Error("Camera:{0} not found", style_.target.cameraMode.camera);
                else
                    canvas.worldCamera = camera.GetComponent<Camera>();
            }
            else if (style_.target.mode == "World")
            {
                canvas.renderMode = RenderMode.WorldSpace;
            }


        }

        /// <summary>
        /// 当被删除时
        /// </summary>
        public void HandleDeleted()
        {
        }

        /// <summary>
        /// 当被打开时
        /// </summary>
        /// <remarks>
        /// 可用于加载内容目录的数据
        /// </remarks>
        public void HandleOpened(string _source, string _uri)
        {
            rootUI.gameObject.SetActive(true);
            rootWorld.gameObject.SetActive(true);
        }

        /// <summary>
        /// 当被关闭时
        /// </summary>
        public void HandleClosed()
        {
            rootUI.gameObject.SetActive(false);
            rootWorld.gameObject.SetActive(false);
        }
    }
}
